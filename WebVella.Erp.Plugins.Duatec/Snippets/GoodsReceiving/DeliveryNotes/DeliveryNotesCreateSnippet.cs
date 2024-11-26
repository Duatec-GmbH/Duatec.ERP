using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceiving.DeliveryNotes
{
    [Snippet]
    internal class DeliveryNotesCreateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var context = pageModel.ErpRequestContext;
            return $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/delivery-notes/c/create"
                + $"?grId={pageModel.RecordId}";
        }
    }
}
