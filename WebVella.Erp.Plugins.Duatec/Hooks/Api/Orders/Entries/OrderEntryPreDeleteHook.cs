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
        public string EntityName => OrderEntry.Entity;

        public IEnumerable<ErrorModel> OnPreDeleteRecord(OrderEntry record)
        {
            var article = record.Article;
            var orderId = record.Order;

            if (article != Guid.Empty && orderId != Guid.Empty)
            {
                var goodsReceivingEntryExist = new GoodsReceivingRepository().FindManyEntriesByOrder(orderId)
                    .Any(e => e.Article == article);

                if (goodsReceivingEntryExist)
                    yield return new ErrorModel() { Message = "Can not delete order entry when goods receiving has already been done" };
            }
        }
    }
}
