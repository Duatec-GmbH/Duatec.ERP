using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.OrderLists.Entries
{
    [HookAttachment(key: HookKeys.OrderList.Entry.Delete)]
    internal class OrderListEntryDeleteHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return null;

            var recMan = new RecordManager();
            var listId = OrderListEntry.Find(pageModel.RecordId.Value)
                ?[OrderListEntry.OrderList] as Guid?;

            var response = recMan.DeleteRecord(OrderListEntry.Entity, pageModel.RecordId.Value);

            if (!response.Success)
            {
                pageModel.PutMessage(ScreenMessageType.Error, response.GetMessage());
                return null;
            }

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App.Name}/{context.SitemapArea.Name}/order-lists/r/{listId}/detail";

            return pageModel.LocalRedirect(url);
        }
    }
}
