using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validations;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment("article_type_manage")]
    internal class ArticleTypeManageHook : IParameterizedPageHook
    {
        public string[] Parameters => ["hId"];

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if (!args.TryGetValue("hId", out var idValue) || !Guid.TryParse(idValue, out var id))
                return null;

            var articleType = Db.GetArticleTypeById(id);
            pageModel.DataModel.SetRecord(articleType);

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }
    }
}
