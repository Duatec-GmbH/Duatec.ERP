using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Orders.Entries
{
    [HookAttachment(key: OrderEntry.Entity)]
    internal class OrderEntryPreDeleteHook : ITypedPreDeleteHook<OrderEntry>
    {
        public string EntityName => throw new NotImplementedException();

        public IEnumerable<ErrorModel> OnPreDeleteRecord(OrderEntry record)
        {
            var article = record.Article;
            var id = record.Order;

            if (article != Guid.Empty && id != Guid.Empty)
            {
                var storedAmount = new GoodsReceivingRepository().FindManyEntriesByOrder(id)
                    .Where(e => e.Article == article)
                    .Aggregate(0m, (sum, e) => sum + e.StoredAmount);

                if (storedAmount > 0)
                    yield return new ErrorModel() { Message = "Can not delete order entry when articles have already been stored within warehouse" };
            }
        }
    }
}
