using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Page;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Update)]
    internal class PartListEntryUpdateHook : TypedValidatedManageHook<PartListEntry>
    {
        protected override IActionResult? OnPostUpdate(PartListEntry record, RecordManagePageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/part-lists/r/{record.PartListId}/detail";
            return pageModel.LocalRedirect(url);
        }
    }
}
