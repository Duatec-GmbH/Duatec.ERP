using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists.Entries
{
    [Snippet]
    internal class PartListEntryProvidedAmountSnippet : ArticleAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => Record(pageModel)?[PartListEntry.ProvidedAmount] as decimal?;

        protected override EntityRecord? GetArticle(BaseErpPageModel pageModel)
            => (Record(pageModel)?['$' + PartListEntry.Relations.Article] as List<EntityRecord>)?.FirstOrDefault();

        private static EntityRecord? Record(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
    }
}
