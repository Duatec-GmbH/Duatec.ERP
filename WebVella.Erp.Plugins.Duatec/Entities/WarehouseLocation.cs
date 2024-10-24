using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class WarehouseLocation
    {
        public const string Entity = "warehouse_location";
        public const string Warehouse = "warehouse_id";
        public const string Designation = "designation";

        public static EntityRecord? Find(Guid id)
        {
            var cmd = new EqlCommand($"select * from {Entity} where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault();
        }

        public static bool Exists(Guid warehouse, string designation, Guid? excludedId = null)
        {
            var cmd = new EqlCommand($"select * from {Entity} where " +
                $"{Warehouse} = @wh and {Designation} = @designation and id != @id",
                new EqlParameter("wh", warehouse),
                new EqlParameter("designation", designation),
                new EqlParameter("id", excludedId ?? Guid.Empty));

            return QueryResults.Exists(cmd.Execute());
        }
    }
}
