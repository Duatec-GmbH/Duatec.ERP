using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class Warehouse : TypedEntityRecord
    {
        public const string Entity = "warehouse";

        public static class Fields
        {
            public const string Designation = "designation";
        }

        public Warehouse(EntityRecord? record = null)
            : base(record) { }

        public static Warehouse? Create(EntityRecord? record)
            => record == null ? null : new Warehouse(record);

        public string Designation
        {
            get => TryGet(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }
    }
}
