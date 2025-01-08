using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
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

            // TODO replace record manager with repository
            var recMan = new RecordManager();
            var response = recMan.DeleteRecord(DeliveryNote.Entity, deliveryNoteId);

            if (!response.Success)
            {
                pageModel.PutMessage(ScreenMessageType.Error, response.GetMessage());
                return null;
            }

            var name = $"{response.Object.Data.Single()[DeliveryNote.File]}";
            if (name.Contains('/'))
                name = name[(name.LastIndexOf('/') + 1)..];

            pageModel.PutMessage(ScreenMessageType.Success, $"Successfully deleted delivery note '{name}'");

            return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
        }
    }
}
