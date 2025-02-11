using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    [Obsolete]
    internal class UnstoredGoodsReceivingEntries : CodeDataSource
    {
        public static class Arguments
        {
            public const string Page = "page";
            public const string PageSize = "pageSize";
            public const string GoodsReceiving = "goodsReceiving";
        }

        public UnstoredGoodsReceivingEntries() : base()
        {
            Name = nameof(UnstoredGoodsReceivingEntries);
            ResultModel = nameof(EntityRecordList);
            Id = new Guid("535733e1-a48f-4f64-974b-59e4caffdfdd");

            Parameters.Add(new() { Name = Arguments.GoodsReceiving, Type = "Guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            if (!arguments.TryGetValue(Arguments.GoodsReceiving, out var guidVal) || guidVal is not Guid id || id == Guid.Empty)
                return new EntityRecordList();

            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];

            var result = new EntityRecordList();
            var allEntries = Execute(id).ToArray();

            result.AddRange(allEntries
                .OrderBy(gr => gr.GetArticle().PartNumber)
                .Skip((page - 1) * pageSize)
                .Take(pageSize));

            result.TotalCount = allEntries.Length;

            return result;
        }

        public static IEnumerable<GoodsReceivingEntry> Execute(Guid goodsReceivingId, RecordManager? recMan = null)
        {
            recMan ??= new RecordManager();

            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);
            var manufacturerRepo = new CompanyRepository(recMan);

            const string receivedQuery = $"*, ${GoodsReceivingEntry.Relations.Article}.*";
            var allEntries = goodsReceivingRepo.FindManyEntriesByGoodsReceiving(goodsReceivingId, receivedQuery);

            var typeIds = allEntries.Select(e => e.GetArticle().TypeId)
                .Distinct()
                .ToArray();

            var manufacturerIds = allEntries.Select(e => e.GetArticle().ManufacturerId)
                .Distinct()
                .ToArray();

            var typeLookup = articleRepo.FindManyTypesById(typeIds);
            var manufacturerLookup = manufacturerRepo.FindMany($"id, {Company.Fields.Name}", manufacturerIds);

            foreach (var entry in allEntries)
            {
                var article = entry.GetArticle();

                if (typeLookup.TryGetValue(article.TypeId, out var t) && t != null)
                    article.SetArticleType(t);

                if (manufacturerLookup.TryGetValue(article.ManufacturerId, out var man) && man != null)
                    article.SetManufacturer(man);

                yield return entry;              
            }
        }
    }
}
