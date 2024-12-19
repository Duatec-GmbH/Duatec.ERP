using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance;
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

            var location = Repository.Warehouse.FindEntry(entry.WarehouseLocation);
            if (location == null) 
                return null;

            var warehouse = Repository.Warehouse.Find(location.Warehouse);
            if (warehouse == null)
                return null;

            return $"{warehouse?.Designation} - {location?.Designation}";
        }
    }
}
