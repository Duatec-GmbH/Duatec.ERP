using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
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
            if (rec?[ArticleStock.WarehouseLocation] is not Guid locationId)
                return null;

            var location = WarehouseLocation.Find(locationId);
            if (location?[WarehouseLocation.Warehouse] is not Guid warehouseId)
                return null;

            var warehouse = Warehouse.Find(warehouseId);
            if (warehouse?[Warehouse.Designation] is not string wh || location[WarehouseLocation.Designation] is not string whl)
                return null;

            return $"{wh} - {whl}";
        }
    }
}
