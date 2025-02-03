using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class AvailableInventoryEntries4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
        }

        public static class FieldExtensions
        {
            public const string AvailableAmount = "available";
            public const string Demand = "demand";
        }

        public AvailableInventoryEntries4Project() : base()
        {
            Id = new Guid("151d911a-f2fd-4cd5-95c6-ea6e8eb2a66a");
            Name = nameof(AvailableInventoryEntries4Project);
            Description = "List of all available inventory entries for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Project, Type = "guid", Value = "null" });
        }

        public static IEnumerable<InventoryEntry> Execute(Guid projectId)
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
                .OrderBy(r => GetArticle(r).PartNumber);
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

            var inventoryLookup = new InventoryRepository(recMan).FindManyByProject(projectId)
                .GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var result = new Dictionary<Guid, decimal>(demandLookup.Count);

            foreach(var (key, val) in demandLookup)
            {
                var orderVal = orderedLookup.TryGetValue(key, out var d) ? d : 0m;
                var fromInventory = inventoryLookup.TryGetValue(key, out d) ? d : 0m;

                var demand = val - orderVal - fromInventory;
                if (demand > 0)
                    result.Add(key, demand);
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

        private static InventoryEntry RecordFromGroup(
            IGrouping<Guid, InventoryEntry> g, 
            Dictionary<Guid, Article?> articleLookup, 
            Dictionary<Guid, decimal> demandLookup)
        {
            var articleId = g.Key;
            var demand = demandLookup[articleId];

            var available = g.Sum(r => r.Amount);

            var rec = new InventoryEntry
            {
                Id = Guid.Empty,
                Article = articleId,
                Amount = Math.Min(available, demand),
            };

            if (articleLookup[articleId] is Article article)
                rec.SetArticle(article);

            rec[FieldExtensions.AvailableAmount] = available;
            rec[FieldExtensions.Demand] = demand;

            return rec;
        }

        private static Article GetArticle(EntityRecord rec)
        {
            var article = ((List<EntityRecord>)rec[$"${InventoryReservationEntry.Relations.Article}"])[0];
            return TypedEntityRecordWrapper.WrapElseDefault<Article>(article)!;
        }
    }
}
