using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class OrderConfirmation : TypedEntityRecordWrapper
    {
        public const string Entity = "order_confirmation";

        public static class Fields
        {
            public const string OrderId = "order_id";
            public const string File = "file";
        }

        public static class Relations
        {
            public const string Order = Entities.Order.Relations.Confirmations;
        }

        public override string EntityName => Entity;

        public Guid OrderId
        {
            get => Get<Guid>(Fields.OrderId);
            set => Properties[Fields.OrderId] = value;
        }


#pragma warning disable IDE1006
        // must be like this because component multi file
        public string path
#pragma warning restore IDE1006
        {
            get => Get(Fields.File, string.Empty);
            set => Properties[Fields.File] = value;
        }
    }
}
