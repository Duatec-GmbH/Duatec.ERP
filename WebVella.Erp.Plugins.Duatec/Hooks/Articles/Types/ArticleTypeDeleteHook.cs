﻿using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Delete)]
    internal class ArticleTypeDeleteHook : DeleteOnListHookBase
    {
        protected override string Entity => ArticleType.Entity;

        protected override string? RecordLabel(Guid id)
            => ArticleType.Find(id)?[ArticleType.Label] as string;
    }
}
