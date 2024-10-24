using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types
{
    [Snippet]
    public class ArticleTypeDeleteSnippet : ListManageSnippetBase
    {
        protected override string HookKey => HookKeys.Article.Type.Delete;
    }
}