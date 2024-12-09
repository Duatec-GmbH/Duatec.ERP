﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Delete)]
    internal class ArticleDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];
            var equivalents = ArticleAlternative.AllTargetsForSource(id);

            QueryResponse TransactionalAction()
            {
                foreach (var eq in equivalents)
                    ArticleAlternative.DeleteMapping(id, eq);

                var recMan = new RecordManager();
                return recMan.DeleteRecord(Article.Entity, id);
            }

            return Transactional.Delete(pageModel, TransactionalAction);
        }
    }
}
