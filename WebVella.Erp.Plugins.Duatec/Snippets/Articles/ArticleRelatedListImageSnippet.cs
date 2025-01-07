using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Articles.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    internal class ArticleRelatedListImageSnippet : ArticleRelatedListSnippetBase
    {
        const int Height = ArticleListImageSnippet.Height;
        const int Width = ArticleListImageSnippet.Width;

        protected override object? GetValue(BaseErpPageModel pageModel, Article article)
        {
            return Html.UrlImage(article.Image, Height, Width);
        }
    }
}
