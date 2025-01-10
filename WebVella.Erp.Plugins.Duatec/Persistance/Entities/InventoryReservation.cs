using WebVella.TypedRecords;
using WebVella.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
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

        public override string EntityName => Entity;

        public Guid Project
        {
            get => Get<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }
    }
}
