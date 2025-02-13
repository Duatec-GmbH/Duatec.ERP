using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles
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

        private static void Import(BaseErpPageModel pageModel, string partNumber, string type)
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

            var recMan = new RecordManager();
            var articleRepository = new ArticleRepository(recMan);

            if (!Guid.TryParse(type, out var typeId) || articleRepository.FindType(typeId) == null)
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Type with id '{type}' does not exist.");
                return;
            }

            if (!TryGetArticle(articleRepository, pageModel, partNumber, out var article))
                return;

            void TransactionalAction()
            {
                var companyRepository = new CompanyRepository(recMan);

                var manufacturer = companyRepository.FindByShortName(article.Manufacturer.ShortName)?.Id
                    ?? companyRepository.Insert(article.Manufacturer)?.Id
                    ?? throw new DbException($"Could not create manufacturer '{article.Manufacturer.Name}'.");

                if (articleRepository.Insert(article, manufacturer, typeId) == null)
                    throw new DbException($"Could not create article '{article.PartNumber}'.");
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported article '{article.PartNumber}'.");
        }


        private static bool TryGetArticle(ArticleRepository articleRepository, BaseErpPageModel pageModel, string partNumber, [NotNullWhen(true)] out DataPortalArticleDto? article)
        {
            article = EplanDataPortal.GetArticleByPartNumber(partNumber);

            if (article == null)
                pageModel.PutMessage(ScreenMessageType.Error, $"Article '{partNumber}' does not exist.");

            else if (articleRepository.Exists(article.PartNumber))
                pageModel.PutMessage(ScreenMessageType.Error, $"Article '{partNumber}' already exists in the data base.");

            else if (articleRepository.Exists(article.EplanId))
                pageModel.PutMessage(ScreenMessageType.Error, $"An article with the same EPLAN ID already exists.");

            else return true;

            article = null;
            return false;
        }
    }
}
