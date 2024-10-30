using EcmaScript.NET;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Delete)]
    internal class ArticleDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];
            var equivalents = ArticleEquivalent.AllTargetsForSource(id);

            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            connection.BeginTransaction();

            try
            {
                foreach (var eq in equivalents)
                    ArticleEquivalent.DeleteMapping(id, eq);

                var recMan = new RecordManager();
                var result = recMan.DeleteRecord(Article.Entity, id);

                if (result.Success)
                {
                    connection.CommitTransaction();
                    var context = pageModel.ErpRequestContext;
                    return pageModel.LocalRedirect($"/{context.App.Name}/{context.SitemapArea.Name}/{context.SitemapNode.Name}/l/");
                }
                else
                {
                    pageModel.PutMessage(ScreenMessageType.Error, result.Message);
                    connection.RollbackTransaction();
                }
            }
            catch(Exception ex)
            {
                pageModel.PutMessage(ScreenMessageType.Error, ex.Message);
                connection.RollbackTransaction();
            }

            return null;
        }
    }
}
