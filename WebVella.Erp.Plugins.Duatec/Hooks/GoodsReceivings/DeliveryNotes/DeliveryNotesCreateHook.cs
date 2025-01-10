using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.DeliveryNotes
{
    [HookAttachment(key: HookKeys.GoodsReceiving.DeliveryNotes.Create)]
    internal class DeliveryNotesCreateHook : IRecordCreatePageHook
    {
        private const string listArg = "grId";
        private static readonly DeliveryNotesValidator _validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            var listId = pageModel.Request.Query[listArg];

            pageModel.PutMessage(Web.Models.ScreenMessageType.Success, "Successfully created goods receiving entry");

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/goods-receiving/r/{listId}/detail";

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            var rec = TypedEntityRecordWrapper.Cast<DeliveryNote>(record)!;
            validationErrors.AddRange(_validator.ValidateOnCreate(rec));

            return null;
        }
    }
}
