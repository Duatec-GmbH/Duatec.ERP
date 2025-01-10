using WebVella.TypedRecords;
using WebVella.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
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

        public override string EntityName => Entity;

        public Guid GoodsReceiving
        {
            get => Get<Guid>(Fields.GoodsReceiving);
            set => Properties[Fields.GoodsReceiving] = value;
        }

        public Guid Article
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public decimal Amount
        {
            get => Get<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
        }
    }
}
