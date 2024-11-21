using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Delete)]
    internal class PartListDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];

            var entries = PartListEntry.FindMany(id, "id")
                .Select(r => (Guid)r["id"])
                .ToArray();

            QueryResponse TransactionalAction()
            {
                var recMan = new RecordManager();
                recMan.DeleteRecords(PartListEntry.Entity, entries);
                return recMan.DeleteRecord(PartList.Entity, id);
            }

            return Transactional.Delete(pageModel, TransactionalAction);
        }
    }
}
