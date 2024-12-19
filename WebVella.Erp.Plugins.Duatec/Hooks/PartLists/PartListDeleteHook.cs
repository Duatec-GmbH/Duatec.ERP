using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Delete)]
    internal class PartListDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return pageModel.BadRequest();

            var pl = new PartList(rec);

            if (!Repository.PartList.Delete(pl.Id!.Value))
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete part list");
                return null;
            }

            var returnUrl = $"/{pageModel.ErpRequestContext.App?.Name}/projects/projects/r/{pl.Project}";
            return pageModel.LocalRedirect(returnUrl);
        }
    }
}
