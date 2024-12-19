using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class WarehouseLocation : TypedEntityRecord
    {
        public const string Entity = "warehouse_location";

        public static class Fields
        {
            public const string Warehouse = "warehouse_id";
            public const string Designation = "designation";
        }

        public WarehouseLocation(EntityRecord? entityRecord = null)
            : base(entityRecord) { }

        public static WarehouseLocation? Create(EntityRecord? record)
            => record == null ? null : new WarehouseLocation(record);

        public Guid Warehouse
        {
            get => TryGet<Guid>(Fields.Warehouse);
            set => Properties[Fields.Warehouse] = value;
        }

        public string Designation
        {
            get => TryGet(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }
    }
}
