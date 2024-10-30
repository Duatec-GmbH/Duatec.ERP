using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleDetailImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 200;

        protected override int? Width => 200;

        protected override string? Url(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[Article.Image]?.ToString();
    }
}