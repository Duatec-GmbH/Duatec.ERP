using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class Project : TypedEntityRecordWrapper
    {
        public const string Entity = "project";

        public static class Fields
        {
            public const string Number = "number";
            public const string Name = "name";
        }

        public Project(EntityRecord? record)
            : base(record) { }

        public static Project? Create(EntityRecord? record)
            => record == null ? null : new Project(record);

        public string Number
        {
            get => TryGet(Fields.Number, string.Empty);
            set => Properties[Fields.Number] = value;
        }

        public string Name
        {
            get => TryGet(Fields.Name, string.Empty);
            set => Properties[Name] = value;
        }
    }
}
