using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceiving
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Delete)]
    internal class GoodsReceivingDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];

            if (Repository.GoodsReceiving.FindManyEntriesByGoodsReceiving(id, "id").Count > 0)
                pageModel.PutMessage(ScreenMessageType.Error, "Can not delete goods receiving when there are still items atached");
            else if(!Repository.GoodsReceiving.Delete(id))
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete goods receiving");
            else
                return pageModel.LocalRedirect(PageUrl.EntityList(pageModel));

            return null;
        }
    }
}
