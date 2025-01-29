using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class InitializedGoods : CodeDataSource
    {
        public static class Arguments
        {
            public const string Page = "page";
            public const string PageSize = "pageSize";
            public const string Order = "order";
        }

        public InitializedGoods() : base()
        {
            Name = nameof(InitializedGoods);
            ResultModel = nameof(EntityRecordList);
            Id = new Guid("1a0750b2-5dd4-4beb-9e4a-5ba774d2d268");

            Parameters.Add(new() { Name = Arguments.Order, Type = "Guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            if (!arguments.TryGetValue(Arguments.Order, out var idVal) || idVal is not Guid id || id == Guid.Empty)
                return new EntityRecordList();

            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];

            var recMan = new RecordManager();

            var orderRepo = new OrderRepository(recMan);
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);
            var articleRepos = new ArticleRepository(recMan);

            var allEntries = orderRepo.FindManyEntriesByOrder(id, $"*, ${OrderEntry.Relations.Article}.*");

            const string receivedQuery = $"*, ${GoodsReceivingEntry.Relations.GoodsReceiving}.{GoodsReceiving.Fields.Order}";
            var recievedAmountLookup = goodsReceivingRepo.FindManyEntriesByOrder(id, receivedQuery)
                .GroupBy(e => e.Article)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

            var typeIds = allEntries
                .Select(oe => oe.GetArticle()!.TypeId)
                .Distinct()
                .ToArray();

            var typeLookup = articleRepos.FindManyTypesById(typeIds);

            var entries = new List<EntityRecord>();
            foreach (var orderEntry in allEntries.OrderBy(oe => oe.GetArticle()!.PartNumber))
            {
                var received = recievedAmountLookup.TryGetValue(orderEntry.Article, out var d) ? d : 0m;
                if(received < orderEntry.Amount)
                {
                    orderEntry.Amount -= received;
                    entries.Add(orderEntry);

                    var article = orderEntry.GetArticle()!;

                    if (typeLookup.TryGetValue(article.TypeId, out var type) && type != null)
                        article.SetArticleType(type);
                }
            }

            var result = new EntityRecordList();
            result.AddRange(entries.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = entries.Count;

            return result;
        }
    }
}
