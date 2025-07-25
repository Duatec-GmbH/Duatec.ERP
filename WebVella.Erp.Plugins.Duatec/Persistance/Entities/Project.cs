using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class Project : TypedEntityRecordWrapper
    {
        public const string Entity = "project";

        public static class Fields
        {
            public const string Number = "number";
            public const string Name = "name";
            public const string RequiresPartList = "requires_part_list";
            public const string IsInventoryProject = "inventory_project";
            public const string ReserveStoredArticles = "reserve_stored_articles";
        }

        public override string EntityName => Entity;

        public string Number
        {
            get => Get(Fields.Number, string.Empty);
            set => Properties[Fields.Number] = value;
        }

        public string Name
        {
            get => Get(Fields.Name, string.Empty);
            set => Properties[Name] = value;
        }

        public bool RequiresPartList
        {
            get => Get(Fields.RequiresPartList, true);
            set => Properties[Fields.RequiresPartList] = value;
        }

        public bool IsInventoryProject
        {
            get => Get(Fields.IsInventoryProject, false);
            set => Properties[Fields.IsInventoryProject] = value;
        }

        public bool ReserveStoredArticles
        {
            get => Get<bool>(Fields.ReserveStoredArticles);
            set => Properties[Fields.ReserveStoredArticles] = value;

        }
    }
}
