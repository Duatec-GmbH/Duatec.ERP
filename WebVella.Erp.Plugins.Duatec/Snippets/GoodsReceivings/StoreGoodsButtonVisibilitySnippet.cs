using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceivings
{
    [Snippet]
    [Obsolete]
    internal class StoreGoodsButtonVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var goodsReceivingId = pageModel.RecordId!.Value;
            return false;
        }
    }
}
