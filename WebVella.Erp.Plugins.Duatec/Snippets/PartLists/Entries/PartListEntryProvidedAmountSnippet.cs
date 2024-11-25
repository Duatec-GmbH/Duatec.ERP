using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists.Entries
{
    [Snippet]
    internal class PartListEntryProvidedAmountSnippet : ListArticleAmountSnippetBase
    {
        protected override decimal? GetAmount(EntityRecord rowRecord)
            => rowRecord[PartListEntry.ProvidedAmount] as decimal?;

        protected override EntityRecord? GetArticle(EntityRecord rowRecord)
            => (rowRecord['$' + PartListEntry.Relations.Article] as List<EntityRecord>)?.FirstOrDefault();
    }
}
