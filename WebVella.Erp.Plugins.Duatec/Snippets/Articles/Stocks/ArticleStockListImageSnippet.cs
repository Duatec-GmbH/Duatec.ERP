using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockListImageSnippet : ArticleListImageSnippet
    {
        protected override string? Url(BaseErpPageModel pageModel)
        {
            return (pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?['$' + InventoryEntry.Relations.Article] as List<EntityRecord>)
                ?.FirstOrDefault()?[Article.Fields.Image]?.ToString();
        }
    }
}
