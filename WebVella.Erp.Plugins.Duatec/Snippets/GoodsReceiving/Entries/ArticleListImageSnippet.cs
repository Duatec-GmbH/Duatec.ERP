using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceiving.Entries
{
    [Snippet]
    internal class ArticleListImageSnippet : Articles.ArticleListImageSnippet
    {
        protected override string? Url(BaseErpPageModel pageModel)
        {
            return (pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[$"${GoodsReceivingEntry.Relations.Article}"] 
                as List<EntityRecord>)?.FirstOrDefault()?[Article.Fields.Image] as string;
        }
    }
}
