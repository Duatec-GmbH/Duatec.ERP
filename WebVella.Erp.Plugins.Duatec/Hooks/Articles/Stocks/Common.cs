using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    internal static class Common
    {
        public static void RoundAmount(EntityRecord record)
        {
            var amount = (decimal)record[ArticleStock.Amount];
            amount = Math.Round(amount, 2);
            record[ArticleStock.Amount] = amount;
        }

        public static IActionResult? Create(EntityRecord record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            var article = (Guid)record[ArticleStock.Article];
            var location = (Guid)record[ArticleStock.WarehouseLocation];
            var project = record[ArticleStock.Project] as Guid?;
            var amount = (decimal)record[ArticleStock.Amount];

            var rec = ArticleStock.Find(article, location, project);
            var recMan = new RecordManager();

            ValidationError? error = null;
            Guid pageId;

            if (rec == null)
            {
                record["id"] = Guid.NewGuid();
                if (!recMan.CreateRecord(ArticleStock.Entity, record).Success)
                    error = new(string.Empty, "Could not create record");
                pageId = (Guid)record["id"];
            }
            else
            {
                rec[ArticleStock.Amount] = (decimal)rec[ArticleStock.Amount] + amount;
                if (!recMan.UpdateRecord(ArticleStock.Entity, rec).Success)
                    error = new(string.Empty, "Could not update record");
                pageId = (Guid)rec["id"];
            }

            if (error == null)
                return pageModel.LocalRedirect(PageUrl.EntityDetail(pageModel, pageId));

            validationErrors.Add(error);
            return null;
        }
    }
}
