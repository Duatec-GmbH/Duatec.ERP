using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class InventoryEntry : EntityRecordWrapper
    {
        public const string Entity = "article_stock";

        public static class Relations
        {
            public const string Article = "article";
            public const string Project = "project";
            public const string Location = "warehouse_location";
        }

        public static class Fields
        {
            public const string WarehouseLocation = "warehouse_location_id";
            public const string Article = "article_id";
            public const string Project = "project_id";
            public const string Amount = "amount";
        }

        public InventoryEntry() 
            : base() { }

        public InventoryEntry(EntityRecord record)
            : base(record) { }

        public Guid WarehouseLocation
        {
            get => TryGet<Guid>(Fields.WarehouseLocation);
            set => Properties[Fields.WarehouseLocation] = value;
        }

        public Guid Article
        {
            get => TryGet<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public Guid? Project
        {
            get => TryGet<Guid?>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }

        public decimal Amount
        {
            get => TryGet<decimal>(Fields.Amount); 
            set => Properties[Fields.Amount] = value;
        }
    }
}
