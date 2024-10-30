using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleListImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 50;

        protected override int? Width => 50;

        protected override string? Url(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Article.Image]?.ToString();
    }
}