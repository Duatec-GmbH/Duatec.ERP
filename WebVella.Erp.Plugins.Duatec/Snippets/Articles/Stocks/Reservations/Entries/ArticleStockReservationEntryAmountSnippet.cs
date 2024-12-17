using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.Reservations.Entries
{
    [Snippet]
    internal class ArticleStockReservationEntryAmountSnippet : ArticleStockReservationEntryAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetRecord(pageModel)?[ArticleStockReservationEntry.Amount] as decimal?;
    }
}
