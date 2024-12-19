using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class PartList : TypedEntityRecord
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

        public PartList(EntityRecord record)
            : base(record) { }

        public static PartList? Create(EntityRecord? record)
            => record == null ? null : new PartList(record);

        public Guid Project
        {
            get => TryGet<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }

        public string Name
        {
            get => TryGet(Fields.Name, string.Empty);
            set => Properties[Fields.Name] = value;
        }

        public bool IsActive
        {
            get => TryGet<bool>(Fields.IsActive);
            set => Properties[Fields.IsActive] = value;
        }
    }
}
