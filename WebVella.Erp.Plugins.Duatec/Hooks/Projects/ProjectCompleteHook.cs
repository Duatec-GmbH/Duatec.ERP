using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
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

            var reservedStocks = Project.Stocks(pageModel.RecordId.Value);

            if (reservedStocks.Count == 0)
                return null;

            void TransactionalAction()
            {
                var unreservedStocks = Project.Stocks()
                    .ToDictionary(GetKey, r => r);

                var recMan = new RecordManager();
                foreach (var reserved in reservedStocks)
                {
                    QueryResponse response;

                    if(!unreservedStocks.TryGetValue(GetKey(reserved), out var unreserved))
                    {
                        reserved[ArticleStock.Project] = null;
                        response = recMan.UpdateRecord(ArticleStock.Entity, reserved);
                    }
                    else
                    {
                        var amount = (decimal)unreserved[ArticleStock.Amount] 
                            + (decimal)reserved[ArticleStock.Amount];
                        unreserved[ArticleStock.Amount] = amount;
                        response = recMan.UpdateRecord(ArticleStock.Entity, unreserved);
                    }

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

        private static (Guid ArticleId, Guid LocationId) GetKey(EntityRecord rec)
            => ((Guid)rec[ArticleStock.Article], (Guid)rec[ArticleStock.WarehouseLocation]);

    }
}
