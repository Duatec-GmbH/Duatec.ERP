namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class DeliveryNote : TypedEntityRecordWrapper
    {
        public const string Entity = "delivery_notes";

        public static class Fields
        {
            public const string GoodsReceiving = "goods_receiving_id";
            public const string File = "delivery_note";
        }

        public static class Relations
        {
            public const string GoodsReceiving = "delivery_notes_goods_receiving";
        }

        public Guid GoodsReceiving
        {
            get => TryGet<Guid>(Fields.GoodsReceiving);
            set => Properties[Fields.GoodsReceiving] = value;
        }

        public object File
        {
            get => TryGet<object>(Fields.File);
            set => Properties[Fields.File] = value;
        }
    }
}
