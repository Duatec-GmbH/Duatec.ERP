using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleHasAlternativesSnippet : SnippetBase
    {
        private static readonly ArticleRepository _repo = new();

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return false;
            return _repo.ArticleHasAlternatives(pageModel.RecordId.Value);
        }
    }
}