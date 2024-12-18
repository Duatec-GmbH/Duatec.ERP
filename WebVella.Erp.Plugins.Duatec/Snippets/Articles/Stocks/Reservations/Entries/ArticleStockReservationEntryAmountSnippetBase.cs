using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.Reservations.Entries
{
    internal abstract class ArticleStockReservationEntryAmountSnippetBase : ArticleAmountSnippetBase
    {
        protected override Article? GetArticle(BaseErpPageModel pageModel)
        {
            var rec = GetRecord(pageModel);
            if (rec == null)
                return null;
            return Article.Create((rec[$"${InventoryReservationEntry.Relations.Article}"] as List<EntityRecord>)?.FirstOrDefault());
        }

        protected override ArticleType? GetArticleType(BaseErpPageModel pageModel)
        {
            var article = GetArticle(pageModel);
            if (article == null)
                return null;
            return ArticleType.Create((article[$"${Article.Relations.Type}"] as List<EntityRecord>)?.FirstOrDefault());
        }

        protected static EntityRecord? GetRecord(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>(TargetRecord(pageModel));
    }
}
