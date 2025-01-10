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
