using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public static class Warehouse
    {
        public const string Entity = "warehouse";
        public const string Designation = "designation";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static EntityRecord? FromWarehouseLocation(Guid warehouseLocationId)
        {
            if (WarehouseLocation.Find(warehouseLocationId)?[WarehouseLocation.Warehouse] is not Guid id)
                return null;
            return Find(id);
        }
    }
}
