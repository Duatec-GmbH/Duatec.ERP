using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryCreateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var context = pageModel.ErpRequestContext;
            return $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/order-list-entries/c/create"
                + $"?olId={pageModel.RecordId}";
        }
    }
}
