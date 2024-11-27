using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.OrderLists
{
    [HookAttachment(key: HookKeys.OrderList.Delete)]
    internal class OrderListDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];
            var projectId = OrderList.Find(id)?[OrderList.Project];

            void TransactionalAction()
            {
                var entries = OrderListEntry.FindMany(id, "id")
                    .ToIdArray();

                var recMan = new RecordManager();
                recMan.DeleteRecords(OrderListEntry.Entity, entries);
                recMan.DeleteRecord(OrderList.Entity, id);
            }
            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return null;

            var app = pageModel.ErpRequestContext.App.Name;
            var url = $"/{app}/projects/projects/r/{projectId}/detail";
            return pageModel.LocalRedirect(url);
        }
    }
}
