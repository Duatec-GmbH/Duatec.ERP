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
            => GetDataSourcePropertyFromRecord(pageModel, PartListEntry.ProvidedAmount) as decimal?;

        protected override EntityRecord? GetArticle(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, $"${PartListEntry.Relations.Article}[0]") as EntityRecord;

        protected override EntityRecord? GetArticleType(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, $"${PartListEntry.Relations.Article}[0].${Article.Relations.Type}[0]") as EntityRecord;
    }
}
