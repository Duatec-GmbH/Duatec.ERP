using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base
{
    internal abstract class OrderListEntryAmountSnippetBase : ArticleAmountSnippetBase
    {
        protected override EntityRecord? GetArticle(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, $"${OrderListEntry.Relations.Article}[0]") as EntityRecord;

        protected override EntityRecord? GetArticleType(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, $"${OrderListEntry.Relations.Article}[0].${Article.Relations.Type}[0]") as EntityRecord;
    }
}
