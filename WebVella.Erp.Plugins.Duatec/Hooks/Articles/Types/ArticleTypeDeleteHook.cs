using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Delete)]
    internal class ArticleTypeDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => ArticleType.Entity;

        protected override string? RecordLabel(Guid id)
            => Repository.Article.FindType(id)?.Label;
    }
}
