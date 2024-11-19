using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Database;
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

            var stocks = Project.Stocks(pageModel.RecordId.Value);
            if (stocks.Count == 0)
                return null;

            void TransactionalAction()
            {
                var recMan = new RecordManager();
                foreach (var rec in stocks)
                {
                    rec[ArticleStock.Project] = null;
                    var response = recMan.UpdateRecord(ArticleStock.Entity, rec);

                    if (!response.Success)
                        throw new DbException("Could not update entity record");
                }
            }

            if(Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully removed project reservations from stocks");
                return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
            }
            return null;
        }
    }
}
