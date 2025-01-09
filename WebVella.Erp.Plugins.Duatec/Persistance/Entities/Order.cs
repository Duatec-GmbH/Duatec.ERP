using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
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

        public Order(EntityRecord? record = null)
            : base(record) { }

        public static Order? Create(EntityRecord? record)
            => record == null ? null : new Order(record);

        public Guid Supplier
        {
            get => TryGet<Guid>(Fields.Supplier);
            set => Properties[Fields.Supplier] = value;
        }

        public string Number
        {
            get => TryGet(Fields.Number, string.Empty);
            set => Properties[Fields.Number] = value;
        }

        public Guid Project
        {
            get => TryGet<Guid>(Fields.Project);
            set => Properties[Fields.Project] = value;
        }
    }
}
