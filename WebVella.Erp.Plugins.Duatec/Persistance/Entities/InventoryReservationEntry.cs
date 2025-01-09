using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
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

        public InventoryReservationEntry(EntityRecord? record = null)
            : base(record) { }

        public static InventoryReservationEntry? Create(EntityRecord? record)
            => record == null ? null : new InventoryReservationEntry(record);

        public Guid InventoryReservationList
        {
            get => TryGet<Guid>(Fields.InventoryReservationList);
            set => Properties[Fields.InventoryReservationList] = value;
        }

        public Guid Article
        {
            get => TryGet<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public decimal Amount
        {
            get => TryGet(Fields.Amount, decimal.MinValue);
            set => Properties[Fields.Amount] = value;
        }
    }
}
