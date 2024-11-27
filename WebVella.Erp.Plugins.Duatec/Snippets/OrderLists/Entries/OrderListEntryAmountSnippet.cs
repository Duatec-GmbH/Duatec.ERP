using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryAmountSnippet : ListArticleAmountSnippetBase
    {
        protected override decimal? GetAmount(EntityRecord rowRecord)
            => rowRecord[OrderListEntry.Amount] as decimal?;

        protected override EntityRecord? GetArticle(EntityRecord rowRecord)
            => (rowRecord['$' + OrderListEntry.Relations.Article] as List<EntityRecord>)?.FirstOrDefault();
    }
}
