using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryDetailAmountSnippet : OrderListEntryAmountSnippetBase
    {
        protected override EntityRecord? Record(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
    }
}
