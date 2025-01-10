namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class GoodsReceivingEntry : TypedEntityRecordWrapper
    {
        public const string Entity = "goods_receiving_entry";

        public static class Relations
        {
            public const string Article = "goods_receiving_entry_article";
            public const string GoodsReceiving = "goods_receiving_entry_goods_receiving";
        }

        public static class Fields
        {
            public const string Article = Entities.Article.AsForeignKey;
            public const string GoodsReceiving = "goods_receiving_id";
            public const string Amount = "amount";
        }

        public Guid GoodsReceiving
        {
            get => TryGet<Guid>(Fields.GoodsReceiving);
            set => Properties[Fields.GoodsReceiving] = value;
        }

        public Guid Article
        {
            get => TryGet<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public decimal Amount
        {
            get => TryGet<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
        }
    }
}
