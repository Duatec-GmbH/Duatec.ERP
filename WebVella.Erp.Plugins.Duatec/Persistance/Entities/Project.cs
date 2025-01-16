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
    }
}
