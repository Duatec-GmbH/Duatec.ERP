using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    public class Order : TypedEntityRecordWrapper
    {
        public const string Entity = "order";

        public static class Relations
        {
            public const string Supplier = "order_supplier";
            public const string Project = "order_project";
        }

        public static class Fields
        {
            public const string Supplier = "supplier_id";
            public const string Number = "order_number";
            public const string Project = "project_id";
        }

        public override string EntityName => Entity;

        public Guid Supplier
        {
            get => Get<Guid>(Fields.Supplier);
            set => Properties[Fields.Supplier] = value;
        }

        public string Number
        {
            get => Get(Fields.Number, string.Empty);
            set => Properties[Fields.Number] = value;
        }

        public Guid Project
        {
            get => Get<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }
    }
}
