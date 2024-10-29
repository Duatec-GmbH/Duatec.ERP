using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types
{
    [Snippet]
    public class ArticleTypeManageSnippet : ListIdHookCallSnippetBase
    {
        protected override string HookKey => HookKeys.Article.Type.Manage;
    }
}