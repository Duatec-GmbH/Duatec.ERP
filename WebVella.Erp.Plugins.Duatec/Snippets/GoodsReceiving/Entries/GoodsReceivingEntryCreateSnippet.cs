using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceiving.Entries
{
    [Snippet]
    internal class GoodsReceivingEntryCreateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var context = pageModel.ErpRequestContext;
            return $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/goods-receiving-entries/c/create"
                + $"?grId={pageModel.RecordId}";
        }
    }
}
