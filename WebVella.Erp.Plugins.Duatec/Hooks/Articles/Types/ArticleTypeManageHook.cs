using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Manage)]
    public class ArticleTypeManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id)
            => ArticleType.Find(id);
    }
}
