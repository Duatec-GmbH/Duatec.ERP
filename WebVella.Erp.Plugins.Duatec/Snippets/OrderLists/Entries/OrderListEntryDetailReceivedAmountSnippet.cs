using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryDetailReceivedAmountSnippet : OrderListEntryCalculatedAmountSnippetBase
    {
        protected override IEnumerable<decimal> GetAmounts(Guid project, Guid article)
            => GoodsReceivingEntry.FindManyByProjectAndArticle(project, article).Select(r => (decimal)r[GoodsReceivingEntry.Amount]);
    }
}
