using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class OrderType : TypedEntityRecordWrapper
    {
        public const string Entity = "order_type";

        public static class Fields
        {
            public const string Name = "name";
        }

        public override string EntityName => Entity;

        public string Name
        {
            get => Get<string>(Fields.Name);
            set => Properties[Fields.Name] = value;
        }
    }
}
