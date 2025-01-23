﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class AvailableStocks4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
        }

        public AvailableStocks4Project() : base()
        {
            Id = new Guid("151d911a-f2fd-4cd5-95c6-ea6e8eb2a66a");
            Name = nameof(AvailableStocks4Project);
            Description = "List of all available stocks for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Project, Type = "guid", Value = "null" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Arguments.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var recMan = new RecordManager();

            var demandLookup = GetDemandLookup(recMan, projectId.Value);
            var stocks = new InventoryRepository(recMan).FindManyByProject(null)
                .Where(r => demandLookup.ContainsKey(r.Article))
                .ToArray();

            if (stocks.Length == 0)
                return new EntityRecordList();

            var articleLookup = GetArticleLookup(recMan, stocks);
            var records = stocks
                .GroupBy(s => s.Article)
                .Select(g => RecordFromGroup(g, articleLookup, demandLookup))
                .OrderBy(r => GetArticle(r).PartNumber);

            var result = new EntityRecordList();
            result.AddRange(records);
            result.TotalCount = result.Count;
            return result;
        }

        private static Dictionary<Guid, decimal> GetDemandLookup(RecordManager recMan, Guid projectId)
        {
            var demandLookup = new PartListRepository(recMan).FindManyEntriesByProject(projectId, true)
                .GroupBy(ple => ple.ArticleId)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var orderedLookup = new OrderRepository(recMan).FindManyEntriesByProject(projectId)
                .GroupBy(oe => oe.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var inventoryLookup = new InventoryRepository(recMan).FindManyByProject(projectId)
                .GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var result = new Dictionary<Guid, decimal>(demandLookup.Count);

            foreach(var (key, val) in demandLookup)
            {
                var orderVal = orderedLookup.TryGetValue(key, out var d) ? d : 0m;
                var fromStock = inventoryLookup.TryGetValue(key, out d) ? d : 0m;

                var demand = val - orderVal - fromStock;
                if (demand > 0)
                    result.Add(key, demand);
            }

            return result;
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(RecordManager recMan, InventoryEntry[] stocks)
        {
            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            var articleIds = stocks
                .Select(r => r.Article)
                .Distinct()
                .ToArray();

            return new ArticleRepository(recMan).FindMany(select, articleIds);
        }

        private static EntityRecord RecordFromGroup(
            IGrouping<Guid, InventoryEntry> g, 
            Dictionary<Guid, Article?> articleLookup, 
            Dictionary<Guid, decimal> demandLookup)
        {
            var articleId = g.Key;
            var demand = demandLookup[articleId];

            var available = g.Sum(r => r.Amount);
            var articles = new List<EntityRecord>();
            if (articleLookup[articleId] is EntityRecord article)
                articles.Add(article);

            var rec = new EntityRecord();
            rec["id"] = articleId;
            rec[$"${InventoryReservationEntry.Relations.Article}"] = articles;
            rec["available"] = available;
            rec["demand"] = demand;
            rec[InventoryReservationEntry.Fields.Amount] = Math.Min(available, demand);

            return rec;
        }

        private static Article GetArticle(EntityRecord rec)
        {
            var article = ((List<EntityRecord>)rec[$"${InventoryReservationEntry.Relations.Article}"])[0];
            return TypedEntityRecordWrapper.WrapElseDefault<Article>(article)!;
        }
    }
}
