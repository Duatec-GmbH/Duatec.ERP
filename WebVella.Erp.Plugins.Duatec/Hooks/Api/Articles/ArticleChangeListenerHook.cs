using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Articles
{
    [HookAttachment(key: Article.Entity)]
    internal class ArticleChangeListenerHook : ITypedPostCreateHook<Article>, ITypedPostDeleteHook<Article>, ITypedPostUpdateHook<Article>
    {
        public string EntityName => Article.Entity;

        public bool ExecuteOnPostCreateMany => true;

        public bool ExecuteOnPostDeleteMany => true;

        public bool ExecuteOnPostUpdateMany => true;

        public void OnPostCreateRecord(Article record)
        {
            ChangeDetection.LastArticleChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostDeleteRecord(Article record)
        {
            ChangeDetection.LastArticleChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostUpdateRecord(Article record)
        {
            ChangeDetection.LastArticleChangeTimeUtc = DateTime.UtcNow;
        }
    }
}
