using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    internal static class Common
    {
        public static void Insert(InventoryEntry record)
        {
            if (Repository.Inventory.Insert(record) == null)
                throw new DbException("Could not create inventory entry");
        }
    }
}
