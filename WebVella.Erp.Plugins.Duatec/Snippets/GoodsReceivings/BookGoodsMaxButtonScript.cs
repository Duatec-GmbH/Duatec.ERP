using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.GoodsReceivings
{
    [Snippet]
    internal class BookGoodsMaxButtonScript : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var amount = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[InventoryEntry.Fields.Amount] as decimal? ?? 0m;

            return $"this.parentNode.parentNode.previousElementSibling.previousElementSibling.getElementsByTagName('input')[0].value = {amount}";
        }
    }
}
