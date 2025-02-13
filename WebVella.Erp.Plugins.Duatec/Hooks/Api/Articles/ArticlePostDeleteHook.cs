using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Api.Articles.Common;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Articles
{
    [HookAttachment(key: Article.Entity)]
    internal class ArticlePostDeleteHook : ITypedPostDeleteHook<Article>
    {
        public string EntityName => Article.Entity;

        public bool ExecuteOnPostDeleteMany => true;

        public void OnPostDeleteRecord(Article record)
            => Actions.DeleteAlternatives(record.Id!.Value);
    }
}
