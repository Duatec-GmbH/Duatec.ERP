using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleListImageSnippet : SnippetBase
    {
        public const int Height = 50;
        public const int Width = 50;

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Article.Fields.Image]?.ToString();
            return Html.UrlImage(url, Height, Width);
        }
    }
}