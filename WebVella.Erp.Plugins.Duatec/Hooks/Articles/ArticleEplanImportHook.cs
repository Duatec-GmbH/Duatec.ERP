using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.EplanImport)]
    public class ArticleEplanImportHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            var id = pageModel.GetFormValue("eplan_identifier");
            var type = pageModel.GetFormValue("article_type");
            Import(pageModel, id, type);
            return pageModel.RedirectToPage();
        }

        public static void Import(BaseErpPageModel pageModel, string partNumber, string type)
        {
            if (string.IsNullOrEmpty(partNumber))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Please enter an article part number.");
                return;
            }

            if (string.IsNullOrEmpty(type))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Please select a type.");
                return;
            }

            if(!Guid.TryParse(type, out var typeId) || ArticleType.Find(typeId) == null)
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Type with id '{type}' does not exist.");
                return;
            }

            if (!TryGetArticle(pageModel, partNumber, out var article))
                return;

            void TransactionalAction()
            {
                var manufacturer = Manufacturer.FindId(article.Manufacturer.ShortName)
                    ?? Manufacturer.Insert(article.Manufacturer)
                    ?? throw new DbException($"Could not create manufacturer '{article.Manufacturer.Name}'.");

                if (Article.Insert(article, manufacturer, typeId) == null)
                    throw new DbException($"Could not create article '{article.PartNumber}'.");
            }

            if(Transactional.TryExecute(pageModel, TransactionalAction))
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported article '{article.PartNumber}'.");
        }


        private static bool TryGetArticle(BaseErpPageModel pageModel, string partNumber, [NotNullWhen(true)] out DataPortalArticle? article)
        {
            article = DataPortal.GetArticleByPartNumber(partNumber);

            if (article == null)
                pageModel.PutMessage(ScreenMessageType.Error, $"Article '{partNumber}' does not exist.");
            else if (Article.Exists(article.PartNumber))
                pageModel.PutMessage(ScreenMessageType.Error, $"Article '{partNumber}' already exists in the data base.");
            else if (Article.Exists(article.EplanId))
                pageModel.PutMessage(ScreenMessageType.Error, $"An article with the same EPLAN ID already exists.");
            else return true;

            article = null;
            return false;
        }
    }
}
