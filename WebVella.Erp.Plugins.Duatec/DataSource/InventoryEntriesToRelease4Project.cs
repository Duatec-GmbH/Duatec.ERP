using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class InventoryEntriesToRelease4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
        }

        public  InventoryEntriesToRelease4Project() : base()
        {
            Id = new Guid("7201ff59-3673-43e4-a984-cabe0de0fe39");
            Name = nameof(InventoryEntriesToRelease4Project);
            Description = "List of all inventory entries to realease for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Project, Type = "guid", Value = "null" });
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

        public static IEnumerable<SuperfluousInventoryArticle> Execute(Guid projectId)
        {
            var recMan = new RecordManager();
            var inventoryRepository = new InventoryRepository(recMan);

            var inventoryLookup = inventoryRepository.FindManyByProject(projectId)
                .GroupBy(ie => (ie.Article, ie.Denomination))
                .ToDictionary(g => g.Key, g => g.Sum(ie => ie.Amount));

            if (inventoryLookup.Count == 0)
                yield break;

            var articleIds = inventoryLookup.Select(kp => kp.Key.Article).ToArray();
            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            var articleLookup = new ArticleRepository(recMan).FindMany(select, articleIds);
            var demandLookup = new PartListRepository(recMan).FindManyEntriesByProject(projectId, true)
                .GroupBy(ple => (ple.ArticleId, ple.Denomination))
                .ToDictionary(g => g.Key, g => g.Sum(ple => ple.Amount));

            var reservedAmountLookup = inventoryRepository.GetReservedArticleAmountLookup(projectId);

            foreach(var (key, amount) in inventoryLookup)
            {
                var demand = demandLookup.TryGetValue(key, out var d) ? d : 0m;
                var reserved = reservedAmountLookup.TryGetValue(key, out d) ? d : 0m;

                if(demand < reserved)
                {
                    var available = amount;
                    var relativeDemand = Math.Max(0m, available - (reserved - demand));

                    var result = new SuperfluousInventoryArticle()
                    {
                        ArticleId = key.Article,
                        Denomination = key.Denomination,
                        AvailableAmount = available,
                        SelectedAmount = relativeDemand,
                        RelativeDemand = relativeDemand
                    };

                    result.SetArticle(articleLookup[key.Article]);

                    yield return result;
                }
            }
        }
    }
}
