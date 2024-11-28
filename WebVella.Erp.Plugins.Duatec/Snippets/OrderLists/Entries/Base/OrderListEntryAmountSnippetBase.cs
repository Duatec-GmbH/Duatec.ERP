using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base
{
    internal abstract class OrderListEntryAmountSnippetBase : ArticleAmountSnippetBase
    {
        protected abstract EntityRecord? Record(BaseErpPageModel pageModel);

        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => Record(pageModel)?[OrderListEntry.Amount] as decimal?;

        protected override EntityRecord? GetArticle(BaseErpPageModel pageModel)
            => (Record(pageModel)?['$' + OrderListEntry.Relations.Article] as List<EntityRecord>)?.FirstOrDefault();
    }
}
