using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    internal static class Common
    {
        public static void RoundAmount(InventoryEntry record)
            => record.Amount = Math.Round(record.Amount, 2);

        public static void PartialMove(InventoryEntry record)
        {
            var repo = new InventoryRepository();

            var unchanged = repo.Find(record.Id!.Value)!;
            unchanged.Amount -= record.Amount;
            RoundAmount(unchanged);

            if (!new RecordManager().UpdateRecord(InventoryEntry.Entity, unchanged).Success)
                throw new DbException("Could not update article stock entry");

            record.Id = null;
            Create(record);
        }

        public static void CompleteMove(InventoryEntry record)
        {
            var repo = new InventoryRepository();

            if (!repo.Delete(record.Id!.Value))
                throw new DbException("Could not delete article stock entry");

            record.Id = null;
            Create(record);
        }

        public static void Create(InventoryEntry record)
        {
            var repo = new InventoryRepository();

            var rec = repo.Find(record.Article, record.WarehouseLocation, record.Project);
            var recMan = new RecordManager();

            if (rec == null)
            {
                record.Id = Guid.NewGuid();
                if (!recMan.CreateRecord(InventoryEntry.Entity, record).Success)
                    throw new DbException("Could not create article stock entry");
            }
            else
            {
                rec.Amount += record.Amount;
                if (!recMan.UpdateRecord(InventoryEntry.Entity, rec).Success)
                    throw new DbException("Could not update article stock entry");
            }
        }
    }
}
