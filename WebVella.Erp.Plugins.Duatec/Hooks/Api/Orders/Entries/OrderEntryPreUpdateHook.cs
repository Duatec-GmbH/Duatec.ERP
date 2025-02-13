using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Orders.Entries
{
    [HookAttachment(key: OrderEntry.Entity)]
    internal class OrderEntryPreUpdateHook : ITypedPreUpdateHook<OrderEntry>
    {
        public string EntityName => OrderEntry.Entity;

        public bool ExecuteOnPreUpdateMany => true;

        public IEnumerable<ErrorModel> OnPreUpdateRecord(OrderEntry record)
        {
            var article = record.Article;
            var id = record.Order;

            if(article != Guid.Empty && id != Guid.Empty)
            {
                var bookedAmount = new GoodsReceivingRepository().FindManyEntriesByOrder(id)
                    .Where(e => e.Article == article)
                    .Aggregate(0m, (sum, e) => sum + e.Amount);

                if (bookedAmount > 0 && record.Amount < bookedAmount)
                    yield return new ErrorModel() { Message = "Can not update order entry when goods receiving has already been done" };
            }
        }
    }
}
