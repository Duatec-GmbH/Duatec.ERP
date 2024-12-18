using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class AvailableStocks4Project : CodeDataSource
    {
        public static class Parameter
        {
            public const string Project = "project";
        }

        public AvailableStocks4Project() : base()
        {
            Id = new Guid("151d911a-f2fd-4cd5-95c6-ea6e8eb2a66a");
            Name = nameof(AvailableStocks4Project);
            Description = "List of all available stocks for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Parameter.Project, Type = "guid", Value = "null" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Parameter.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var demandLookup = GetDemandLookup(projectId.Value);
            var stocks = new InventoryRepository().FindManyByProject(null)
                .Where(r => demandLookup.ContainsKey(r.Article))
                .ToArray();

            if (stocks.Length == 0)
                return new EntityRecordList();

            var articleLookup = GetArticleLookup(stocks);
            var records = stocks
                .GroupBy(s => (Guid)s[InventoryEntry.Fields.Article])
                .Select(g => RecordFromGroup(g, articleLookup, demandLookup))
                .OrderBy(r => GetArticle(r)[Article.Fields.PartNumber]);

            var result = new EntityRecordList();
            result.AddRange(records);
            result.TotalCount = result.Count;
            return result;
        }

        private static Dictionary<Guid, decimal> GetDemandLookup(Guid projectId)
        {
            var demandLookup = PartListEntry.FindManyByProject(projectId)
                .GroupBy(ple => (Guid)ple[PartListEntry.Article])
                .ToDictionary(g => g.Key, g => g.Sum(r => (decimal)r[PartListEntry.Amount]));

            var orderedLookup = OrderEntry.FindManyByProject(projectId)
                .GroupBy(oe => (Guid)oe[OrderEntry.Article])
                .ToDictionary(g => g.Key, g => g.Sum(r => (decimal)r[OrderEntry.Amount]));

            var inventoryLookup = ArticleStockReservationEntry.FindManyByProject(projectId)
                .GroupBy(asre => (Guid)asre[ArticleStockReservationEntry.Article])
                .ToDictionary(g => g.Key, g => g.Sum(r => (decimal)r[ArticleStockReservationEntry.Amount]));

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

        private static Dictionary<Guid, Article?> GetArticleLookup(InventoryEntry[] stocks)
        {
            var articleIds = stocks
                .Select(r => r.Article)
                .Distinct()
                .ToArray();

            return new ArticleRepository().FindManyWithTypes(articleIds);
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
            rec[$"${ArticleStockReservationEntry.Relations.Article}"] = articles;
            rec["available"] = available;
            rec["demand"] = demand;
            rec[ArticleStockReservationEntry.Amount] = Math.Min(available, demand);
            rec["auto_reserve"] = true;

            return rec;
        }

        private static EntityRecord GetArticle(EntityRecord rec)
            => ((List<EntityRecord>)rec[$"${ArticleStockReservationEntry.Relations.Article}"])[0];
    }
}
