﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes.DataModel;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.FileImport)]
    internal class ArticleFileImportHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if(!TryGetArticleImportInfo(pageModel, out var importInfos))
                return pageModel.BadRequest();

            if (importInfos.Count == 0)
                return null;

            var types = importInfos.ToDictionary(i => i.PartNumber, i => i.TypeId);
            var articles = EplanDataPortal.GetArticlesByPartNumber([.. types.Keys]);

            if(articles.Values.Any(v => v == null))
                return pageModel.BadRequest();

            return Import(pageModel, articles.Values!, types);
        }

        private static bool TryGetArticleImportInfo(BaseErpPageModel pageModel, out List<ArticleImportInfo> importInfos)
        {
            var partNumbers = pageModel.GetFormValues(Article.Fields.PartNumber);
            var actions = pageModel.GetFormValues("action");
            var typeStrings = pageModel.GetFormValues(Article.Fields.Type);

            importInfos = new List<ArticleImportInfo>(partNumbers.Length);

            if (partNumbers.Length != actions.Length
                || partNumbers.Length != typeStrings.Length
                || !Array.TrueForAll(actions, ArticleImportAction.IsValidAction))
            {
                return false;
            }

            for (var i = 0; i < partNumbers.Length; i++)
            {
                if (!Guid.TryParse(typeStrings[i], out var typeId) || typeId == Guid.Empty)
                    return false;

                if (actions[i].Equals(ArticleImportAction.Import, StringComparison.OrdinalIgnoreCase))
                    importInfos.Add(new (partNumbers[i], actions[i], typeId));
            }
            return true;
        }

        private static LocalRedirectResult? Import(BaseErpPageModel pageModel, IEnumerable<DataPortalArticleDto> articles, Dictionary<string, Guid> types)
        {
            void TransactionalAction()
            {
                foreach (var article in articles)
                {
                    var manufacturer = RepositoryService.CompanyRepository.FindByShortName(article!.Manufacturer.ShortName)?.Id
                        ?? RepositoryService.CompanyRepository.Insert(article.Manufacturer)?.Id
                        ?? throw new DbException($"Could not create manufacturer '{article.Manufacturer.Name}'."); ;

                    if (RepositoryService.ArticleRepository.Insert(article, manufacturer, types[article.PartNumber]) == null)
                        throw new DbException($"Could not create article '{article.PartNumber}'.");
                }
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return null;

            pageModel.PutMessage(ScreenMessageType.Success, "Successfully imported articles");
            return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
        }
    }
}
