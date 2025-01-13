using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings.Entries
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Entry.Update)]
    internal class GoodsReceivingEntryUpdateHook : TypedValidatedUpdateHook<GoodsReceivingEntry>
    {
        protected override IActionResult? OnPostModification(GoodsReceivingEntry record, Entity entity, RecordManagePageModel pageModel)
        {
            base.OnPostModification(record, entity, pageModel);
            var context = pageModel.ErpRequestContext;
            var url = $"/{context.App?.Name}/{context.SitemapArea?.Name}/goods-receiving/r/{record.GoodsReceiving}/detail";

            return pageModel.LocalRedirect(url);
        }

        protected override IActionResult? OnPreValidate(GoodsReceivingEntry record, Entity? entity, RecordManagePageModel pageModel)
        {
            var oldRec = RepositoryService.GoodsReceivingRepository.FindEntry(record.Id!.Value);
            record.GoodsReceiving = oldRec!.GoodsReceiving;
            if (record.Article == Guid.Empty)
                record.Article = oldRec.Article;

            return null;
        }
    }
}
