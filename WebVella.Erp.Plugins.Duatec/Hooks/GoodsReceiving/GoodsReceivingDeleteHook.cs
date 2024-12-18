using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceiving
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Delete)]
    internal class GoodsReceivingDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];

            var entries = GoodsReceivingEntry.FindMany(id, "id")
                .Select(r => (Guid)r["id"])
                .ToArray();

            QueryResponse TransactionalAction()
            {
                var recMan = new RecordManager();
                recMan.DeleteRecords(GoodsReceivingEntry.Entity, entries);
                return recMan.DeleteRecord(Persistance.Entities.GoodsReceiving.Entity, id);
            }

            return Transactional.Delete(pageModel, TransactionalAction);
        }
    }
}
