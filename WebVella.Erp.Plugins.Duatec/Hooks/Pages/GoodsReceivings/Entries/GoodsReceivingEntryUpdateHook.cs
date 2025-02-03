using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Page;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Update)]
    internal class GoodsReceivingEntryUpdateHook : TypedValidatedManageHook<GoodsReceivingEntry>
    {
        protected override IActionResult? OnPostUpdate(GoodsReceivingEntry record, RecordManagePageModel pageModel)
        {
            base.OnPostUpdate(record, pageModel);
            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/goods-receiving/r/{record.GoodsReceiving}/detail";

            return pageModel.LocalRedirect(url);
        }
    }
}
