using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class InventoryEntry : TypedEntityRecord
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
            public const string Article = Entities.Article.AsForeignKey;
            public const string Project = "project_id";
            public const string Amount = "amount";
        }

        public InventoryEntry(EntityRecord? record = null)
            : base(record) { }

        public static InventoryEntry? Create(EntityRecord? record)
            => record == null ? null : new InventoryEntry(record);

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
            get => TryGet(Fields.Amount, decimal.MinValue); 
            set => Properties[Fields.Amount] = value;
        }
    }
}
