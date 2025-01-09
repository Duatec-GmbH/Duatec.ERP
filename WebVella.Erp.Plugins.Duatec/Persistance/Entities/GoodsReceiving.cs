using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class GoodsReceiving : TypedEntityRecordWrapper
    {
        public const string Entity = "goods_receiving";

        public static class Relations
        {
            public const string Order = "goods_receiving_order";
        }

        public static class Fields
        {
            public const string Order = "order_id";
            public const string TimeStamp = "time_stamp";
        }

        public GoodsReceiving(EntityRecord? record = null)
            : base(record) { }

        public static GoodsReceiving? Create(EntityRecord? record)
            => record == null ? null : new GoodsReceiving(record);

        public Guid Order
        {
            get => TryGet<Guid>(Fields.Order);
            set => Properties[Fields.Order] = value;
        }

        public DateTime TimeStamp
        {
            get => TryGet<DateTime>(Fields.TimeStamp);
            set => Properties[Fields.TimeStamp] = value;
        }
    }
}
