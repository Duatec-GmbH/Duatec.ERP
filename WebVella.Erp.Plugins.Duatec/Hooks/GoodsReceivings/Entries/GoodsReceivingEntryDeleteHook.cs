using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Delete)]
    internal class GoodsReceivingEntryDeleteHook : TypedValidatedDeleteHook<GoodsReceivingEntry>
    {
        protected override IActionResult? OnPostModification(GoodsReceivingEntry record, Entity entity, BaseErpPageModel pageModel)
        {
            base.OnPostModification(record, entity, pageModel);

            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/goods-receiving/r/{record.GoodsReceiving}/detail";

            return pageModel.LocalRedirect(url);
        }
    }
}
