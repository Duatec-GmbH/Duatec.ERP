using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Create)]
    internal class PartListEntryCreateHook : TypedValidatedCreateHook<PartListEntry>
    {
        private const string listArg = "plId";

        public override IActionResult? OnPostCreateRecord(PartListEntry record, Entity entity, RecordCreatePageModel pageModel)
        {
            var listId = Guid.Parse(pageModel.Request.Query[listArg]!);

            pageModel.PutMessage(ScreenMessageType.Success,  SuccessMessage(entity));

            var url = Url.RemoveParameters(pageModel.CurrentUrl) + $"?{listArg}={listId}";
            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(PartListEntry record, Entity? entity, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(listArg, out var idVal) || !Guid.TryParse(idVal, out var listId))
                return pageModel.BadRequest();

            record.PartList = listId;
            return null;
        }
    }
}
