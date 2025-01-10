using WebVella.TypedRecords;
using WebVella.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class WarehouseLocation : TypedEntityRecordWrapper
    {
        public const string Entity = "warehouse_location";

        public static class Fields
        {
            public const string Warehouse = "warehouse_id";
            public const string Designation = "designation";
        }

        public override string EntityName => Entity;

        public Guid Warehouse
        {
            get => Get<Guid>(Fields.Warehouse);
            set => Properties[Fields.Warehouse] = value;
        }

        public string Designation
        {
            get => Get(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }
    }
}
