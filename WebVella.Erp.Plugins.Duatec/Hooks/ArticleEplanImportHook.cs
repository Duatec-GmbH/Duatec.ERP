﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "article_eplan_import")]
    public class ArticleEplanImportHook : IPageHook
    {
        public IActionResult OnGet(BaseErpPageModel pageModel)
        {
            return null!;
        }

        public IActionResult OnPost(BaseErpPageModel pageModel)
        {
            var id = pageModel.GetFormValue("eplan_identifier");
            var type = pageModel.GetFormValue("article_type");
            Import(pageModel, id, type);
            return null!;
        }

        public static void Import(BaseErpPageModel pageModel, string partNumber, string type)
        {
            if (string.IsNullOrEmpty(partNumber))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Please enter a article part number.");
                return;
            }

            if (string.IsNullOrEmpty(type))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Please select a type.");
                return;
            }

            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            using var scope = SecurityContext.OpenSystemScope();

            try
            {
                if (!TryGetArticle(pageModel, partNumber, out var article))
                    return;

                connection.BeginTransaction();

                var manufacturer = Db.GetManufacturerIdByShortName(article.Manufacturer.ShortName)
                    ?? Db.InsertManufacturer(article.Manufacturer);

                if (manufacturer == null)
                {
                    connection.RollbackTransaction();
                    pageModel.PutMessage(ScreenMessageType.Error, $"Could not create manufacturer '{article.Manufacturer.Name}'.");
                    return;
                }

                if (!CreateArticle(pageModel, article, manufacturer.Value, type))
                {
                    connection.RollbackTransaction();
                    pageModel.PutMessage(ScreenMessageType.Error, $"Could not create article '{article.PartNumber}'.");
                    return;
                }

                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported article '{article.PartNumber}'.");
                connection.CommitTransaction();
            }
            catch
            {
                connection.RollbackTransaction();
                throw;
            }
        }

        private static bool CreateArticle(BaseErpPageModel pageModel, ArticleDto article, Guid manufacturer, string type)
        {
            if (Db.InsertArticle(article, manufacturer, type) != null)
                return true;

            pageModel.PutMessage(ScreenMessageType.Error, $"Could not create article '{article.PartNumber}'.");
            return false;
        }

        private static bool TryGetArticle(BaseErpPageModel pageModel, string partNumber, [NotNullWhen(true)] out ArticleDto? article)
        {
            article = EplanDataPortal.GetArticleByPartNumber(partNumber);

            if (article == null)
                pageModel.PutMessage(ScreenMessageType.Error, $"Article '{partNumber}' does not exist.");
            else if (Db.GetArticleIdByEplanId(article.EplanId.ToString()) != null)
                pageModel.PutMessage(ScreenMessageType.Error, $"An article with the same EPLAN ID already exists.");
            else if (Db.GetArticleIdByPartNumber(article.PartNumber) != null)
                pageModel.PutMessage(ScreenMessageType.Error, $"Article '{partNumber}' already exists in the data base.");
            else return true;

            article = null;
            return false;
        }
    }
}
