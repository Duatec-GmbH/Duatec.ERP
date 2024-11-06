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
    [HookAttachment(key: HookKeys.Article.Stock.Create)]
    internal class ArticleStockCreateHook : IRecordCreatePageHook
    {
        private static readonly ArticleStockValidator validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var errors = validator.ValidateOnCreate(record);
            validationErrors.AddRange(errors);

            if (errors.Count > 0)
                return null;

            var context = pageModel.ErpRequestContext;
            var url = $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/{context?.SitemapNode?.Name}/r/";

            var article = (Guid)record[ArticleStock.Article];
            var location = (Guid)record[ArticleStock.WarehouseLocation];
            var project = record[ArticleStock.Project] as Guid?;
            var amount = (decimal)record[ArticleStock.Amount];          

            var rec = ArticleStock.Find(article, location, project);
            var recMan = new RecordManager();

            QueryResponse? response;
            if (rec == null)
            {
                record["id"] = Guid.NewGuid();
                response = recMan.CreateRecord(ArticleStock.Entity, record);
                url += record["id"].ToString();
            }
            else
            {
                rec[ArticleStock.Amount] = (decimal)rec[ArticleStock.Amount] + amount;
                response = recMan.UpdateRecord(ArticleStock.Entity, rec);
                url += rec["id"].ToString();
            }

            if (response.Success)
                return pageModel.LocalRedirect(url);

            pageModel.PutMessage(ScreenMessageType.Error, $"Error: {response.Message}");
            return pageModel.LocalRedirect(pageModel.CurrentUrl);
        }
    }
}
