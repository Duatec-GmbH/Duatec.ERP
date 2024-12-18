using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists.Entries
{
    [Snippet]
    internal class PartListEntryAmountSnippet : ArticleAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, PartListEntry.Amount) as decimal?;

        protected override Article? GetArticle(BaseErpPageModel pageModel)
            => Article.Create(GetDataSourcePropertyFromRecord(pageModel, $"${PartListEntry.Relations.Article}[0]") as EntityRecord);

        protected override ArticleType? GetArticleType(BaseErpPageModel pageModel)
            => ArticleType.Create(GetDataSourcePropertyFromRecord(pageModel, $"${PartListEntry.Relations.Article}[0].${Article.Relations.Type}[0]") as EntityRecord);
    }
}
