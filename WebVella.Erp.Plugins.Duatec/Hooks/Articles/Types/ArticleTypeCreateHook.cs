using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Create)]
    internal class ArticleTypeCreateHook : CreateOnListHookBase
    {
        protected override string ManageHook => HookKeys.Article.Type.Manage;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var rec = new EntityRecord();
            rec[ArticleType.Label] = string.Empty;
            rec[ArticleType.Unit] = string.Empty;
            rec[ArticleType.IsInteger] = false;
            return rec;
        }
    }
}
