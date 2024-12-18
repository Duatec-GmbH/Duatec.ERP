using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceiving.Entries;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceiving.DeliveryNotes
{
    [HookAttachment(key: HookKeys.GoodsReceiving.DeliveryNotes.Delete)]
    internal class DeliveryNotesDeleteHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!Guid.TryParse(pageModel.GetFormValue("id"), out Guid deliveryNoteId))
                return null;

            var recMan = new RecordManager();
            var response = recMan.DeleteRecord(Persistance.Entities.DeliveryNotes.Entity, deliveryNoteId);

            if (!response.Success)
            {
                pageModel.PutMessage(ScreenMessageType.Error, response.GetMessage());
                return null;
            }

            pageModel.DataModel.SetRecord(response.Object.Data.Single());
            var url = $"{new ReturnToGoodsReceivingSnippet().Evaluate(pageModel)}";
            return pageModel.LocalRedirect(url);
        }
    }
}
