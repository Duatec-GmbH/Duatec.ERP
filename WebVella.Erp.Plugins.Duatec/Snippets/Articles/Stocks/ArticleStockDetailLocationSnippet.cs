using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailLocationSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return null;

            var entry = new InventoryEntry(rec);

            if (entry?.WarehouseLocation == null)
                return null;

            var location = WarehouseLocation.Find(entry.WarehouseLocation);
            if (location?[WarehouseLocation.Warehouse] is not Guid warehouseId)
                return null;

            var warehouse = Warehouse.Find(warehouseId);
            if (warehouse?[Warehouse.Designation] is not string wh || location[WarehouseLocation.Designation] is not string whl)
                return null;

            return $"{wh} - {whl}";
        }
    }
}
