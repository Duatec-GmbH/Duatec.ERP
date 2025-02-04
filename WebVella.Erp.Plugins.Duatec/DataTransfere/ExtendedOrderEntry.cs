using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    internal class ExtendedOrderEntry : OrderEntry
    {
        public static class ExtendedFields
        {
            public const string State = "state";
            public const string ReceivedAmount = "received_amount";
            public const string StoredAmount = "stored_amount";
        }

        public string State
        {
            get => Get(ExtendedFields.State, string.Empty);
            set => Properties[ExtendedFields.State] = value;
        }

        public decimal ReceivedAmount
        {
            get => Get<decimal>(ExtendedFields.ReceivedAmount);
            set => Properties[ExtendedFields.ReceivedAmount] = value;
        }

        public decimal StoredAmount
        {
            get => Get<decimal>(ExtendedFields.StoredAmount); 
            set => Properties[ExtendedFields.StoredAmount] = value;
        }
    }
}
