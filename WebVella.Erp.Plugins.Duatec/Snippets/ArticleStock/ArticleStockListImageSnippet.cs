using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Articles;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.ArticleStock
{
    [Snippet]
    internal class ArticleStockListImageSnippet : ArticleListImageSnippet
    {
        protected override string? Url(BaseErpPageModel pageModel)
        {
            return (pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?["$article"] as List<EntityRecord>)
                ?[0][Article.Image]?.ToString();
        }
    }
}
