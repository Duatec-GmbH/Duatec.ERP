namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public static class DeliveryNotes
    {
        public static class Relations
        {
            public const string GoodsReceiving = "delivery_notes_goods_receiving";
        }

        public const string Entity = "delivery_notes";
        public const string GoodsReceiving = "goods_receiving_id";
        public const string DeliveryNote = "delivery_note";
    }
}
