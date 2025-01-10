namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class WarehouseLocation : TypedEntityRecordWrapper
    {
        public const string Entity = "warehouse_location";

        public static class Fields
        {
            public const string Warehouse = "warehouse_id";
            public const string Designation = "designation";
        }

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
