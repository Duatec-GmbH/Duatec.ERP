using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class Warehouse : TypedEntityRecordWrapper
    {
        public const string Entity = "warehouse";

        public static class Fields
        {
            public const string Designation = "designation";
        }

        public override string EntityName => Entity;

        public string Designation
        {
            get => Get(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }
    }
}
