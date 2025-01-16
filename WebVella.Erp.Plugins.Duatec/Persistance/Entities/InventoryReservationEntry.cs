using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class InventoryReservationEntry : TypedEntityRecordWrapper
    {
        public const string Entity = "article_stock_reservation_entry";

        public static class Relations
        {
            public const string InventoryReservationList = "article_stock_reservation_entry_article_stock_reservation";
            public const string Article = "article_stock_reservation_entry_article";
        }

        public static class Fields
        {
            public const string InventoryReservationList = "article_stock_reservation_id";
            public const string Article = Entities.Article.AsForeignKey;
            public const string Amount = "amount";
        }

        public override string EntityName => Entity;

        public Guid InventoryReservationList
        {
            get => Get<Guid>(Fields.InventoryReservationList);
            set => Properties[Fields.InventoryReservationList] = value;
        }

        public Guid Article
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public decimal Amount
        {
            get => Get(Fields.Amount, decimal.MinValue);
            set => Properties[Fields.Amount] = value;
        }
    }
}
