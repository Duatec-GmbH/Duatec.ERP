using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class OrderEntry : TypedEntityRecord
    {
        public const string Entity = "order_entry";

        public static class Relations
        {
            public const string Article = "order_entry_article";
            public const string Order = "order_entry_order";
        }

        public static class Fields
        {
            public const string Article = "article_id";
            public const string Order = "order_id";
            public const string Amount = "amount";
        }

        public OrderEntry(EntityRecord record)
            : base(record) { }

        public OrderEntry()
            : base() { }

        public static OrderEntry? Create(EntityRecord? record)
            => record == null ? null : new OrderEntry(record);

        public Guid Article
        {
            get => TryGet<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public Guid Order
        {
            get => TryGet<Guid>(Fields.Order);
            set => Properties[Fields.Order] = value;
        }

        public decimal Amount
        {
            get => TryGet<decimal>(Fields.Amount);
            set => Properties[Fields.Amount] = value;
        }
    }
}
