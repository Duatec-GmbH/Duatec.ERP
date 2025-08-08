using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OpenOrderEntries4Booking : CodeDataSource
    {
        public static class Arguments
        {
            public const string Page = "page";
            public const string PageSize = "pageSize";
            public const string Order = "order";
        }

        public OpenOrderEntries4Booking() : base()
        {
            Name = nameof(OpenOrderEntries4Booking);
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

            var allEntries = Execute(id).ToArray();
            var result = new EntityRecordList();

            result.AddRange(allEntries
                .OrderBy(oe => oe.GetArticle().PartNumber)
                .Skip((page - 1) * pageSize)
                .Take(pageSize));

            result.TotalCount = allEntries.Length;

            return result;
        }

        public static IEnumerable<OrderEntry> Execute(Guid orderId, RecordManager? recMan = null)
        {
            recMan ??= new RecordManager();

            var orderRepo = new OrderRepository(recMan);
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);
            var manufacturerRepo = new CompanyRepository(recMan);

            var allEntries = orderRepo.FindManyEntriesByOrder(orderId, $"*, ${OrderEntry.Relations.Article}.*");

            const string receivedQuery = $"*, ${GoodsReceivingEntry.Relations.GoodsReceiving}.{GoodsReceiving.Fields.Order}";
            var recievedAmountLookup = goodsReceivingRepo.FindManyEntriesByOrder(orderId, receivedQuery)
                .GroupBy(e => (e.Article, e.Denomination))
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

            var typeIds = allEntries
                .Select(oe => oe.GetArticle().TypeId)
                .Distinct()
                .ToArray();

            var manufacturerIds = allEntries
                .Select(oe => oe.GetArticle().ManufacturerId)
                .Distinct()
                .ToArray();

            var typeLookup = articleRepo.FindManyTypesById(typeIds);
            var manufacturerLookup = manufacturerRepo.FindMany($"id, {Company.Fields.Name}", manufacturerIds);

            foreach (var orderEntry in allEntries)
            {
                var received = recievedAmountLookup.TryGetValue((orderEntry.Article, orderEntry.Denomination), out var d) ? d : 0m;
                if (received < orderEntry.Amount)
                {
                    orderEntry.Amount -= received;

                    var article = orderEntry.GetArticle();

                    if (typeLookup.TryGetValue(article.TypeId, out var type))
                        article.SetArticleType(type);

                    if (manufacturerLookup.TryGetValue(article.ManufacturerId, out var manufacturer))
                        article.SetManufacturer(manufacturer);

                    yield return orderEntry;
                }
            }
        }
    }
}
