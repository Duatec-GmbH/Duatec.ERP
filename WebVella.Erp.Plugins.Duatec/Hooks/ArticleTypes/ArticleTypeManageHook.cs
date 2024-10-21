using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.ArticleTypes
{
    [HookAttachment("article_type_manage")]
    internal class ArticleTypeManageHook : IParameterizedPageHook
    {
        public string[] Parameters => ["hId"];

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if (!args.TryGetValue("hId", out var idValue) || !Guid.TryParse(idValue, out var id))
                return null;

            var articleType = ArticleType.Find(id);
            pageModel.DataModel.SetRecord(articleType);

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }
    }
}
