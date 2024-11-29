using WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryReceivedAmountSnippet : OrderListEntryAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, "received") as decimal?;
    }
}
