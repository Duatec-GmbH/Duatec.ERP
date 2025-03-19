using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class Image : TypedEntityRecordWrapper
    {
        public const string Entity = "image";

        public static class Fields
        {
            public const string Name = "name";
            public const string Path = "image";
        }

        public override string EntityName => Entity;

        public string Name
        {
            get => Get(Fields.Name, string.Empty);
            set => Properties[Fields.Name] = value;
        }

        public string Path
        {
            get => Get(Fields.Path, string.Empty);
            set => Properties[Fields.Path] = value;
        }
    }
}
