using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Delete)]
    internal class ArticleTypeDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => ArticleType.Entity;

        protected override string? RecordLabel(Guid id)
            => new ArticleRepository().FindType(id)?.Label;
    }
}
