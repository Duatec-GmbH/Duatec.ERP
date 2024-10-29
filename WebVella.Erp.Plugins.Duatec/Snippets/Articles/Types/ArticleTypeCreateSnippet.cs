using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types
{
    [Snippet]
    public class ArticleTypeCreateSnippet : HookCallSnippetBase
    {
        protected override string HookKey => HookKeys.Article.Type.Create;

        protected override string[] ParametersToClear => [ "hId" ];
    }
}