﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class AvailableInventoryEntries4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
        }

        public AvailableInventoryEntries4Project() : base()
        {
            Id = new Guid("151d911a-f2fd-4cd5-95c6-ea6e8eb2a66a");
            Name = nameof(AvailableInventoryEntries4Project);
            Description = "List of all available inventory entries for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Project, Type = "guid", Value = "null" });
        }

        public static IEnumerable<AvailableInventoryArticle> Execute(Guid projectId)
        {
            var recMan = new RecordManager();

            var demandLookup = GetDemandLookup(recMan, projectId);
            var inventoryEntries = new InventoryRepository(recMan).FindManyByProject(null)
                .Where(r => demandLookup.ContainsKey(r.Article))
                .ToArray();

            if (inventoryEntries.Length == 0)
                return [];

            var articleLookup = GetArticleLookup(recMan, inventoryEntries);
            return inventoryEntries
                .GroupBy(s => s.Article)
                .Select(g => RecordFromGroup(g, articleLookup, demandLookup))
                .OrderBy(r => r.GetArticle().PartNumber);
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Arguments.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var result = new EntityRecordList();
            result.AddRange(Execute(projectId.Value));
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

            var inventoryRepo = new InventoryRepository(recMan);
            var reservedLookup = inventoryRepo.GetReservedArticleAmountLookup(projectId);

            var result = new Dictionary<Guid, decimal>(demandLookup.Count);

            foreach(var (articleId, demand) in demandLookup)
            {
                var ordered = orderedLookup.TryGetValue(articleId, out var d) ? d : 0m;
                var fromInventory = reservedLookup.TryGetValue(articleId, out d) ? d : 0m;

                var relativeDemand = demand - ordered - fromInventory;
                if (relativeDemand > 0)
                    result.Add(articleId, relativeDemand);
            }

            return result;
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(RecordManager recMan, InventoryEntry[] inventoryEntries)
        {
            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            var articleIds = inventoryEntries
                .Select(r => r.Article)
                .Distinct()
                .ToArray();

            return new ArticleRepository(recMan).FindMany(select, articleIds);
        }

        private static AvailableInventoryArticle RecordFromGroup(
            IGrouping<Guid, InventoryEntry> g, 
            Dictionary<Guid, Article?> articleLookup, 
            Dictionary<Guid, decimal> demandLookup)
        {
            var articleId = g.Key;
            var demand = demandLookup[articleId];

            var available = g.Sum(r => r.Amount);

            var rec = new AvailableInventoryArticle
            {
                Id = Guid.Empty,
                ArticleId = articleId,
                Amount = Math.Min(available, demand),
                AvailableAmount = available,
                Demand = demand
            };

            rec.SetArticle(articleLookup[articleId]);

            return rec;
        }
    }
}
