using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.DeliveryNotes
{
    [HookAttachment(key: HookKeys.GoodsReceiving.DeliveryNotes.Create)]
    internal class DeliveryNotesCreateHook : TypedValidatedCreateHook<DeliveryNote>
    {
        private const string listArg = "grId";

        protected override IActionResult? OnPostModification(DeliveryNote record, Entity entity, RecordCreatePageModel pageModel)
        {
            var listId = pageModel.Request.Query[listArg];

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/goods-receiving/r/{listId}/detail";
            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));

            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(DeliveryNote record, Entity? entity, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();
            record.GoodsReceiving = listId;
            return null;
        }
    }
}
