namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class Warehouse : TypedEntityRecordWrapper
    {
        public const string Entity = "warehouse";

        public static class Fields
        {
            public const string Designation = "designation";
        }

        public string Designation
        {
            get => TryGet(Fields.Designation, string.Empty);
            set => Properties[Fields.Designation] = value;
        }
    }
}
