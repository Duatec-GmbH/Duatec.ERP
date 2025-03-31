using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    internal class ExtendedOrderEntry : OrderEntry
    {
        public static class ExtendedFields
        {
            public const string State = "state";
            public const string ReceivedAmount = "received_amount";
        }

        public static class ExtendedRelations
        {
            public const string GoodsReceivings = "goods_receivings";
        }

        public OrderEntryState State
        {
            get => Get<OrderEntryState>(ExtendedFields.State);
            set => Properties[ExtendedFields.State] = value;
        }

        public decimal ReceivedAmount
        {
            get => Get<decimal>(ExtendedFields.ReceivedAmount);
            set => Properties[ExtendedFields.ReceivedAmount] = value;
        }

        public override IEnumerable<GoodsReceiving> GetGoodsReceivings()
            => GetManyByRelation<GoodsReceiving>(ExtendedRelations.GoodsReceivings);

        public void SetGoodsReceivings(IEnumerable<GoodsReceiving> goodsReceivings)
            => SetRelationValues(ExtendedRelations.GoodsReceivings, goodsReceivings);
    }
}
