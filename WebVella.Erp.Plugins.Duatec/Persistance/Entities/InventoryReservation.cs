using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class InventoryReservationList : TypedEntityRecordWrapper
    {
        public const string Entity = "article_stock_reservation";

        public static class Relations
        {
            public const string Project = "article_stock_reservation_project";
        }

        public static class Fields
        {
            public const string Project = "project_id";
        }

        public InventoryReservationList(EntityRecord? record = null)
            : base (record) { }

        public static InventoryReservationList? Create(EntityRecord? rec)
            => rec == null ? null : new InventoryReservationList(rec);

        public Guid Project
        {
            get => TryGet<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }
    }
}
