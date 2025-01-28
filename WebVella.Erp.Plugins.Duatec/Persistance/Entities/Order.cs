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
            public const string Project = "order_project";
            public const string Entries = OrderEntry.Relations.Order;
        }

        public static class Fields
        {
            public const string Number = "order_number";
            public const string Project = "project_id";
        }

        public override string EntityName => Entity;

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


        public IEnumerable<OrderEntry> GetEntries()
            => GetManyByRelation<OrderEntry>(Relations.Entries);


        public void SetEntries(IEnumerable<OrderEntry> entries)
            => SetRelationValues(Relations.Entries, entries);
    }
}
