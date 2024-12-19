using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Manage)]
    public class ArticleTypeManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id)
            => Repository.Article.FindType(id);
    }
}
