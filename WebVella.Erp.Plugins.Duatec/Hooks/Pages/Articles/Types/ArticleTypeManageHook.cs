using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Manage)]
    public class ArticleTypeManageHook : ManageOnListHookBase
    {
        protected override EntityRecord? Find(Guid id)
            => new ArticleRepository().FindType(id);
    }
}
