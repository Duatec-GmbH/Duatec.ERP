using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class InitializedGoodsToStore : CodeDataSource
    {
        public static class Arguments
        {
            public const string Page = "page";
            public const string PageSize = "pageSize";
            public const string GoodsReceiving = "goods_receiving";
        }

        public InitializedGoodsToStore() : base()
        {
            Name = nameof(InitializedGoodsToStore);
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

            return Execute(id, page, pageSize);
        }

        public static EntityRecordList Execute(Guid goodsReceivingId, int page = 1, int pageSize = int.MaxValue)
        {
            var recMan = new RecordManager();

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
            var manufacturerLookup = manufacturerRepo.FindMany("id, name", manufacturerIds);

            var entries = new List<EntityRecord>();

            foreach (var entry in allEntries.Where(e => e.Amount > e.StoredAmount).OrderBy(gr => gr.GetArticle().PartNumber))
            {
                entry.Amount -= entry.StoredAmount;

                var article = entry.GetArticle();

                if (typeLookup.TryGetValue(article.TypeId, out var t) && t != null)
                    article.SetArticleType(t);

                if (manufacturerLookup.TryGetValue(article.ManufacturerId, out var man) && man != null)
                    article.SetManufacturer(man);

                entries.Add(entry);                
            }

            var result = new EntityRecordList();
            result.AddRange(entries.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = entries.Count;

            return result;
        }
    }
}
