using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment("article_type_create")]
    internal class ArticleTypeCreateHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            Guid? id;

            try
            {
                connection.BeginTransaction();
                id = Db.CreateArticleType()!.Value;
                connection.CommitTransaction();
            }
            catch
            {
                connection.RollbackTransaction();
                return null;
            }

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, "hId");

            var hook = $"hookKey=article_type_manage&hId={id}";
            if (url.Contains('?'))
                url += $"&{hook}";
            else url += $"?{hook}";

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }
    }
}
