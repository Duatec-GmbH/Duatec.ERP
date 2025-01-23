using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.TypedRecords.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Delete)]
    internal class GoodsReceivingDeleteHook : TypedValidatedDeleteHook<GoodsReceiving>
    {
        protected override IActionResult? OnPostModification(GoodsReceiving record, Entity? entity, BaseErpPageModel pageModel)
        {
            var repo = new GoodsReceivingRepository();

            if (repo.FindManyEntriesByGoodsReceiving(record.Id!.Value, "id").Count > 0)
                pageModel.PutMessage(ScreenMessageType.Error, "Can not delete goods receiving when there are still items atached");
            else if (repo.Delete(record.Id.Value) == null)
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete goods receiving");
            else
                return pageModel.LocalRedirect(pageModel.EntityListUrl());

            return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
        }
    }
}
