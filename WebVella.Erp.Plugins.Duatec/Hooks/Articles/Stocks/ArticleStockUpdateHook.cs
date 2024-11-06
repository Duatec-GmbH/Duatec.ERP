using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Update)]
    internal class ArticleStockUpdateHook : IRecordManagePageHook
    {
        private static readonly ArticleStockValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var id = (Guid)record["id"];
            if (record[ArticleStock.Amount] is null || record[ArticleStock.Amount] is decimal d && d == 0)
            {
                var recordManager = new RecordManager();
                var result = recordManager.DeleteRecord(ArticleStock.Entity, id);
                string url;

                if (result.Success)
                {
                    var context = pageModel.ErpRequestContext;
                    url = $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/{context?.SitemapNode?.Name}/l/";
                    return pageModel.LocalRedirect(url);
                }

                url = Url.RemoveParameters(pageModel.CurrentUrl);
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete article stock entry");
                return pageModel.LocalRedirect(url);
            }

            var entry = ArticleStock.Find(id)!;

            record[ArticleStock.Article] = entry[ArticleStock.Article];
            record[ArticleStock.Project] = entry[ArticleStock.Project];
            record[ArticleStock.WarehouseLocation] = entry[ArticleStock.WarehouseLocation];

            validationErrors.AddRange(_validator.ValidateOnUpdate(record));

            return null;
        }
    }
}
