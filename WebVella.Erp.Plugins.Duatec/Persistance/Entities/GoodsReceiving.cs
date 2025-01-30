using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class GoodsReceiving : TypedEntityRecordWrapper
    {
        public const string Entity = "goods_receiving";

        public static class Relations
        {
            public const string Order = "goods_receiving_order";
            public const string Entries = GoodsReceivingEntry.Relations.GoodsReceiving;
        }

        public static class Fields
        {
            public const string Order = "order_id";
            public const string TimeStamp = "time_stamp";
        }

        public override string EntityName => Entity;

        public Guid Order
        {
            get => Get<Guid>(Fields.Order);
            set => Properties[Fields.Order] = value;
        }

        public DateTime TimeStamp
        {
            get => Get<DateTime>(Fields.TimeStamp);
            set => Properties[Fields.TimeStamp] = value;
        }

        public IEnumerable<GoodsReceivingEntry> GetEntries()
            => GetManyByRelation<GoodsReceivingEntry>(Relations.Entries);

        public void SetEntries(IEnumerable<GoodsReceivingEntry> entries)
            => SetRelationValues(Relations.Entries, entries);

        internal Order GetOrder()
            => GetSingleByRelation<Order>(Relations.Entries)!;
    }
}
