using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Delete)]
    internal class GoodsReceivingEntryDeleteHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return null;

            // TODO Replace Record manager with repo
            var recMan = new RecordManager();
            var response = recMan.DeleteRecord(GoodsReceivingEntry.Entity, pageModel.RecordId.Value);

            if (!response.Success)
            {
                pageModel.PutMessage(ScreenMessageType.Error, response.GetMessage());
                return null;
            }

            return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
        }
    }
}
