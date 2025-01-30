using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings.DeliveryNotes
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
                return pageModel.BadRequest();

            var rec = new GoodsReceivingRepository().DeleteDeliveryNote(deliveryNoteId);

            if (rec == null)
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete delivery note");
            else
            {
                var name = $"{rec.File}";
                if (name.Contains('/'))
                    name = name[(name.LastIndexOf('/') + 1)..];

                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully deleted delivery note '{name}'");
            }

            var url = Url.RemoveParameters(pageModel.CurrentUrl);
            return pageModel.LocalRedirect(url);
        }
    }
}
