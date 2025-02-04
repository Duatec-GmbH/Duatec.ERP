using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Create)]
    internal class ArticleTypeCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Article.Type.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            return new ArticleType
            {
                Label = string.Empty,
                Unit = string.Empty,
                IsInteger = true
            };
        }
    }
}
