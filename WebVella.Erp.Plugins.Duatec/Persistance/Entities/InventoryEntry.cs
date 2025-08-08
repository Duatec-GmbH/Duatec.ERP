using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class InventoryEntry : TypedEntityRecordWrapper
    {
        public const string Entity = "inventory_entry";

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
            public const string Denomination = "denomination";
        }

        public override string EntityName => Entity;

        public Guid WarehouseLocation
        {
            get => Get<Guid>(Fields.WarehouseLocation);
            set => Properties[Fields.WarehouseLocation] = value;
        }

        public Guid Article
        {
            get => Get<Guid>(Fields.Article);
            set => Properties[Fields.Article] = value;
        }

        public Guid? Project
        {
            get => Get<Guid?>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }

        public decimal Amount
        {
            get => Get(Fields.Amount, decimal.MinValue); 
            set => Properties[Fields.Amount] = value;
        }

        public decimal Denomination
        {
            get => Get(Fields.Denomination, 0m);
            set => Properties[Fields.Denomination] = value;
        }

        public Article GetArticle()
            => GetSingleByRelation<Article>(Relations.Article)!;

        public void SetArticle(Article? article)
            => SetRelationValue(Relations.Article, article);

        public WarehouseLocation GetWarehouseLocation()
            => GetSingleByRelation<WarehouseLocation>(Relations.Location)!;

        public void SetWarehouseLocation(WarehouseLocation location)
            => SetRelationValue(Relations.Location, location);

        public Project? GetProject()
            => GetSingleByRelation<Project>(Relations.Project);

        public void SetProject(Project project)
            => SetRelationValue(Relations.Project, project);
    }
}
