using WebVella.TypedRecords;
using WebVella.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
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

        public override string EntityName => Entity;

        public Guid GoodsReceiving
        {
            get => Get<Guid>(Fields.GoodsReceiving);
            set => Properties[Fields.GoodsReceiving] = value;
        }

        public object File
        {
            get => Get<object>(Fields.File);
            set => Properties[Fields.File] = value;
        }
    }
}
