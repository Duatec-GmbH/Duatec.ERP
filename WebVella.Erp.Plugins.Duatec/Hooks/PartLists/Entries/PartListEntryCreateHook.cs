using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Create)]
    internal class PartListEntryCreateHook : TypedValidatedCreateHook<PartListEntry>
    {
        private const string listArg = "plId";

        protected override IActionResult? OnPostCreate(PartListEntry record, RecordCreatePageModel pageModel)
        {
            var listId = Guid.Parse(pageModel.Request.Query[listArg]!);

            pageModel.PutMessage(ScreenMessageType.Success,  SuccessMessage(record.EntityName));

            var url = Url.RemoveParameters(pageModel.CurrentUrl) + $"?{listArg}={listId}";
            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(PartListEntry record, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            record.PartListId = listId;
            return null;
        }
    }
}
