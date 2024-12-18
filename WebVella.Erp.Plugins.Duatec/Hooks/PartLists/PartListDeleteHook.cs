using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Delete)]
    internal class PartListDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            var id = (Guid)rec["id"];
            var projectId = (Guid)rec[PartList.Project];

            QueryResponse TransactionalAction()
            {
                var entries = PartListEntry.FindMany(id, "id")
                    .ToIdArray();

                var recMan = new RecordManager();
                recMan.DeleteRecords(PartListEntry.Entity, entries);
                return recMan.DeleteRecord(PartList.Entity, id);
            }
            var returnUrl = $"/{pageModel.ErpRequestContext.App?.Name}/projects/projects/r/{projectId}";

            return Transactional.Delete(pageModel, TransactionalAction, returnUrl);
        }
    }
}
