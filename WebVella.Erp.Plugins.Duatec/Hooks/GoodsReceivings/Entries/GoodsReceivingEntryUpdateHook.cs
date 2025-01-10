using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Snippets;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.Entries
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
            var rec = TypedEntityRecordWrapper.WrapElseDefault<GoodsReceivingEntry>(record)!;

            var oldRec = RepositoryService.GoodsReceivingRepository.FindEntry(rec.Id!.Value);
            rec.GoodsReceiving = oldRec!.GoodsReceiving;

            validationErrors.AddRange(_validator.ValidateOnUpdate(rec));

            return null;
        }
    }
}
