using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailAmountSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return null;

            var entry = new InventoryEntry(rec);
            var type = GetArticleType(entry);
            var isInteger = type?.IsInteger is true;

            return isInteger
                ? $"{entry.Amount:0} {type?.Unit}"
                : $"{entry.Amount:0.00} {type?.Unit}";
        }

        private static ArticleType? GetArticleType(InventoryEntry rec)
        {
            return rec.Article != Guid.Empty
                ? new ArticleRepository().FindTypeByArticleId(rec.Article)
                : null;
        }
    }
}
