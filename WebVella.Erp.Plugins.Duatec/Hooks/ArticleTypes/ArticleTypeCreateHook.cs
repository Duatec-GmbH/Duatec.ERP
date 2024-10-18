using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.ArticleTypes
{
    [HookAttachment("article_type_create")]
    internal class ArticleTypeCreateHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, "hId");

            var rec = new EntityRecord();
            rec[ArticleType.Label] = string.Empty;
            rec[ArticleType.Unit] = string.Empty;
            pageModel.DataModel.SetRecord(rec);

            var hook = "hookKey=article_type_manage";
            if (url.Contains('?'))
                url += $"&{hook}";
            else url += $"?{hook}";

            pageModel.CurrentUrl = url;

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }
    }
}
