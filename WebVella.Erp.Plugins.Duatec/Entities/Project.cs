using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Project
    {
        public const string Entity = "project";
        public const string Number = "number";
        public const string Name = "name";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static bool Exists(Guid id)
            => Record.Exists(Entity, "id", id);

        public static bool HasReservedStocks(Guid id)
            => Record.Exists(ArticleStock.Entity, ArticleStock.Project, id);

        public static List<EntityRecord> Stocks(Guid? id = null)
            => Record.FindManyBy(ArticleStock.Entity, ArticleStock.Project, id);

        public static void UnreserveStocks(Guid id)
        {
            var reservedStocks = Stocks(id);
            if (reservedStocks.Count == 0)
                return;

            var unreservedStocks = Stocks()
                .ToDictionary(GetKey, r => r);

            var recMan = new RecordManager();

            // TODO: increase performance

            foreach (var reserved in reservedStocks)
            {
                QueryResponse response;

                if (!unreservedStocks.TryGetValue(GetKey(reserved), out var unreserved))
                {
                    reserved[ArticleStock.Project] = null;
                    response = recMan.UpdateRecord(ArticleStock.Entity, reserved);
                }
                else
                {
                    var amount = (decimal)unreserved[ArticleStock.Amount]
                        + (decimal)reserved[ArticleStock.Amount];
                    unreserved[ArticleStock.Amount] = amount;
                    response = recMan.UpdateRecord(ArticleStock.Entity, unreserved);
                }

                if (!response.Success)
                    throw new DbException("Could not update entity record");
            }
        }

        private static (Guid ArticleId, Guid LocationId) GetKey(EntityRecord rec)
            => ((Guid)rec[ArticleStock.Article], (Guid)rec[ArticleStock.WarehouseLocation]);
    }
}
