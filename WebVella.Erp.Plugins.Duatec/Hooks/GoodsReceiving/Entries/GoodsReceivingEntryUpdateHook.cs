using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceiving.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Update)]
    internal class GoodsReceivingEntryUpdateHook : IRecordManagePageHook
    {
        private static readonly GoodsReceivingEntryValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var url = $"{new ListUrlSnippet().Evaluate(pageModel)}";
            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var oldRec = GoodsReceivingEntry.Find((Guid)record["id"]);
            record[GoodsReceivingEntry.GoodsReceiving] = oldRec![GoodsReceivingEntry.GoodsReceiving];

            validationErrors.AddRange(_validator.ValidateOnUpdate(record));

            return null;
        }
    }
}
