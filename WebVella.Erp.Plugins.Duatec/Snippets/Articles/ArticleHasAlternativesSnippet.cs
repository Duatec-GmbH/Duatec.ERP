using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleHasAlternativesSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return false;
            return Repository.Article.ArticleHasAlternatives(pageModel.RecordId.Value);
        }
    }
}