using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.Reservations.Entries
{
    [Snippet]
    internal class ArticleStockReservationEntryDemandSnippet : ArticleStockReservationEntryAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetRecord(pageModel)?["demand"] as decimal?;
    }
}
