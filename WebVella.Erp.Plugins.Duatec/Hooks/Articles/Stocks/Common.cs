using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    internal static class Common
    {
        public static void RoundAmount(InventoryEntry record)
            => record.Amount = Math.Round(record.Amount, 2);

        public static void PartialMove(InventoryEntry record)
        {
            var unchanged = Repository.Inventory.Find(record.Id!.Value)!;
            unchanged.Amount -= record.Amount;
            RoundAmount(unchanged);

            if(!Repository.Inventory.Update(unchanged))
                throw new DbException("Could not update inventoryentry");

            record.Id = null;
            Create(record);
        }

        public static void CompleteMove(InventoryEntry record)
        {
            if (!Repository.Inventory.Delete(record.Id!.Value))
                throw new DbException("Could not delete inventory entry");

            record.Id = null;
            Create(record);
        }

        public static void Create(InventoryEntry record)
        {
            var rec = Repository.Inventory.Find(record.Article, record.WarehouseLocation, record.Project);

            if (rec == null)
            {
                record.Id = Guid.NewGuid();
                if (Repository.Inventory.Insert(record) == null)
                    throw new DbException("Could not create inventory entry");
            }
            else
            {
                rec.Amount += record.Amount;
                if (!Repository.Inventory.Update(rec))
                    throw new DbException("Could not update inventory entry");
            }
        }
    }
}
