using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [HookAttachment(key: HookKeys.Project.Complete)]
    internal class ProjectCompleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return pageModel.BadRequest();

            var reservedStocks = Project.Stocks(pageModel.RecordId.Value);

            if (reservedStocks.Count == 0)
                return null;

            if(Transactional.TryExecute(pageModel, () => Project.UnreserveStocks(pageModel.RecordId.Value)))
            {
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully removed project reservations from stocks");
                return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
            }
            return null;
        }
    }
}
