using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class PartListDiff : CodeDataSource
    {
        public static class Arguments
        {
            public const string PartList1 = "partList1";
            public const string PartList2 = "partList2";
            public const string Article = "article";
            public const string Manufacturer = "manufacturer";
            public const string IsEqual = "isEqual";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public PartListDiff() : base()
        {
            Name = nameof(PartListDiff);
            Id = new Guid("52b4b242-c82a-44dc-8b5c-4fd585eaa55b");
            ResultModel = nameof(EntityRecordList);
            Description = "Makes a differenece list with given part lists";

            Parameters.Add(new() { Name = Arguments.PartList1, Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.PartList2, Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Article, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.IsEqual, Type = "bool", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var pl1Id = arguments[Arguments.PartList1] as Guid? ?? Guid.Empty;
            var pl2Id = arguments[Arguments.PartList2] as Guid? ?? Guid.Empty;
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];
            if (pageSize <= 0)
            {
                pageSize = int.MaxValue;
                page = 1;
            }

            var entries = ApplyFilters(arguments, Execute(pl1Id, pl2Id)).ToArray();
            var result = new EntityRecordList { TotalCount = entries.Length };
            result.AddRange(entries.Skip((page - 1) * pageSize).Take(pageSize));
            return result;
        }

        public static IEnumerable<PartListEntryDiff> Execute(Guid partList1, Guid partList2)
        {
            if (partList1 == Guid.Empty && partList2 == Guid.Empty)
                yield break;

            var recMan = new RecordManager();
            var partListRepo = new PartListRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);

            var pl1Entries = partListRepo.FindManyEntriesByPartList(partList1)
                .ToDictionary(ple => ple.ArticleId, ple => ple.Amount);

            var pl2Entries = partListRepo.FindManyEntriesByPartList(partList2)
                .ToDictionary(ple => ple.ArticleId, ple => ple.Amount);

            var allArticleIds = pl1Entries.Keys.Union(pl2Entries.Keys).ToArray();

            const string articleSelect = $"*, " +
                $"${Article.Relations.Manufacturer}.name," +
                $"${Article.Relations.Type}.*";

            var articleLookup = articleRepo.FindMany(articleSelect, allArticleIds);

            foreach(var articleId in allArticleIds)
            {
                var pl1Amount = pl1Entries.TryGetValue(articleId, out var d) ? d : 0m;
                var pl2Amount = pl2Entries.TryGetValue(articleId, out d) ? d : 0m;

                var rec = new PartListEntryDiff()
                {
                    Amount1 = pl1Amount,
                    Amount2 = pl2Amount,
                    ArticleId = articleId,
                    Diff = Math.Abs(pl1Amount - pl2Amount),
                };

                if (articleLookup.TryGetValue(articleId, out var article))
                    rec.SetArticle(article);

                yield return rec;
            }
        }

        private static IEnumerable<PartListEntryDiff> ApplyFilters(Dictionary<string, object> arguments, IEnumerable<PartListEntryDiff> entries)
        {
            var articleFilter = arguments[Arguments.Article] as string;
            var manufacturer = arguments[Arguments.Manufacturer] as string;
            var isEqual = arguments[Arguments.IsEqual] as bool?;
            var comp = StringComparison.OrdinalIgnoreCase;

            if (!string.IsNullOrWhiteSpace(articleFilter))
            {
                entries = entries.Where(e =>
                {
                    var article = e.GetArticle();
                    return article.PartNumber.Contains(articleFilter, comp)
                        || article.TypeNumber.Contains(articleFilter, comp)
                        || article.OrderNumber.Contains(articleFilter, comp)
                        || article.Designation.Contains(articleFilter, comp);
                });
            }
            if (!string.IsNullOrWhiteSpace(manufacturer))
                entries = entries.Where(e => e.GetArticle().GetManufacturer().Name.Contains(manufacturer, StringComparison.OrdinalIgnoreCase));

            if (isEqual.HasValue)
                entries = entries.Where(e => isEqual.Value == (e.Amount1 == e.Amount2));

            return entries.OrderBy(e => e.GetArticle().PartNumber);
        }
    }
}
