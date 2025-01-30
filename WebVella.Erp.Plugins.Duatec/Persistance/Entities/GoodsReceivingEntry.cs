using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

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
            public const string StoredAmount = "stored_amount";
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

        public decimal StoredAmount
        {
            get => Get<decimal>(Fields.StoredAmount);
            set => Properties[Fields.StoredAmount] = value;
        }

        internal Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;

        public void SetArticle(Article article)
            => SetRelationValue(Relations.Article, article);

        internal GoodsReceiving GetGoodsReceiving()
            => GetSingleByRelation<GoodsReceiving>(Relations.GoodsReceiving)!;
    }
}
