using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Create)]
    internal class PartListEntryCreateHook : IRecordCreatePageHook
    {
        private const string listArg = "plId";
        private static readonly PartListEntryValidator _validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            var listId = Guid.Parse(pageModel.Request.Query[listArg]!);

            var url = Url.RemoveParameters(pageModel.CurrentUrl) + $"?{listArg}={listId}";
            pageModel.PutMessage(Web.Models.ScreenMessageType.Success, "Successfully created part list entry");

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            var entry = TypedEntityRecordWrapper.Cast<PartListEntry>(record);
            entry!.PartList = listId;

            validationErrors.AddRange(_validator.ValidateOnCreate(entry));
            return null;
        }
    }
}
