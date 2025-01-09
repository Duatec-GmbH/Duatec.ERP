using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Update)]
    internal class PartListEntryUpdateHook : IRecordManagePageHook
    {
        private static readonly PartListEntryValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var context = pageModel.ErpRequestContext;
            var id = record[PartListEntry.Fields.PartList];
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/part-lists/r/{id}/detail";
            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var entry = new PartListEntry(record);
            var oldRec = Repository.PartList.FindEntry(entry.Id!.Value)!;

            entry.PartList = oldRec.PartList;
            validationErrors.AddRange(_validator.ValidateOnUpdate(entry));

            return null;
        }
    }
}
