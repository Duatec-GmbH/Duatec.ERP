using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class PartList : TypedEntityRecordWrapper
    {
        public const string Entity = "part_list";

        public static class Relations
        {
            public const string Entries = PartListEntry.Relations.PartsList;
            public const string Project = "part_list_project";
        }

        public static class Fields
        {
            public const string Project = "project_id";
            public const string Name = "name";
            public const string IsActive = "is_active";
        }

        public override string EntityName => Entity;

        public Guid Project
        {
            get => Get<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }

        public string Name
        {
            get => Get(Fields.Name, string.Empty);
            set => Properties[Fields.Name] = value;
        }

        public bool IsActive
        {
            get => Get<bool>(Fields.IsActive);
            set => Properties[Fields.IsActive] = value;
        }
    }
}
