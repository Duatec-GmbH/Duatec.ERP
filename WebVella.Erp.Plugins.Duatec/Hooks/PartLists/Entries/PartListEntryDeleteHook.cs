using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists.Entries
{
    [HookAttachment(key: HookKeys.PartList.Entry.Delete)]
    internal class PartListEntryDeleteHook : TypedValidatedDeleteHook<PartListEntry>
    {
        protected override IActionResult? OnPostModification(PartListEntry record, Entity entity, BaseErpPageModel pageModel)
        {
            var context = pageModel.ErpRequestContext;

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));

            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/part-lists/r/{record.PartList}/detail";
            return pageModel.LocalRedirect(url);
        }
    }
}
