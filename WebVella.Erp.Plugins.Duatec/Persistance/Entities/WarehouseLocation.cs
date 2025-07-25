using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

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

        public static class Relations
        {
            public const string Warehouse = "warehouse";
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

        public Warehouse GetWarehouse()
            => GetSingleByRelation<Warehouse>(Relations.Warehouse)!;

        public void SetWarehouse(Warehouse warehouse)
            => SetRelationValue(Relations.Warehouse, warehouse);
    }
}
