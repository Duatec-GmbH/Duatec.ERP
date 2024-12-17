using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.Reservations.Entries
{
    [Snippet]
    internal class ArticleStockReservationEntryAvailableAmountSnippet : ArticleStockReservationEntryAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetRecord(pageModel)?["available"] as decimal?;
    }
}
