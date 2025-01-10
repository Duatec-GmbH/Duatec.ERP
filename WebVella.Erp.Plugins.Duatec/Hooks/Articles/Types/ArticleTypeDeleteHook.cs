using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Delete)]
    internal class ArticleTypeDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => ArticleType.Entity;

        protected override string? RecordLabel(Guid id)
            => RepositoryService.ArticleRepository.FindType(id)?.Label;
    }
}
