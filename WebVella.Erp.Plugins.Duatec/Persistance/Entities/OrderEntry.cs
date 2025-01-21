using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class OrderEntry : TypedEntityRecordWrapper
    {
        public const string Entity = "order_entry";

        public static class Relations
        {
            public const string Article = "order_entry_article";
            public const string Order = "order_entry_order";
        }

        public static class Fields
        {
            public const string Article = Entities.Article.AsForeignKey;
            public const string Order = "order_id";
            public const string Amount = "amount";
        }

        public override string EntityName => Entity;

        public Guid Article
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public Guid Order
        {
            get => Get<Guid>(Fields.Order);
            set => Properties[Fields.Order] = value;
        }

        public decimal Amount
        {
            get => Get(Fields.Amount, decimal.MinValue);
            set => Properties[Fields.Amount] = value;
        }

        public Article? GetArticle()
            => GetSingleByRelation<Article>(Relations.Article);

        public Order? GetOrder()
            => GetSingleByRelation<Order>(Relations.Order);
    }
}
