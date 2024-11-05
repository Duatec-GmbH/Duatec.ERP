using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockAmountSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec == null)
                return null;
            
            // TODO get decimal places; 
            var amount = rec[ArticleStock.Amount]?.ToString();
            var article = (rec['$' + ArticleStock.Relations.Article] as List<EntityRecord>)?[0];
            var type = (article?['$' + Article.Relations.Type] as List<EntityRecord>)?[0];
            var unit = type?[ArticleType.Unit]?.ToString();

            return $"{amount} {unit}";
        }
    }
}
