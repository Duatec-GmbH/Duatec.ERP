using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    internal class CommissioningInventoryEntry : InventoryEntry
    {
        public static class ExtendedFields
        {
            public const string AvailableAmount = "available_amount";
            public const string ReservedAmount = "reserved_amount";
            public const string PartListAmount = "part_list_amount";
        }

        public decimal AvailableAmount
        {
            get => Get<decimal>(ExtendedFields.AvailableAmount);
            set => Properties[ExtendedFields.AvailableAmount] = value;
        }

        public decimal ReservedAmount
        {
            get => Get<decimal>(ExtendedFields.ReservedAmount);
            set => Properties[ExtendedFields.ReservedAmount] = value;
        }

        public decimal PartListAmount
        {
            get => Get<decimal>(ExtendedFields.PartListAmount);
            set => Properties[ExtendedFields.PartListAmount] = value;
        }
    }
}
