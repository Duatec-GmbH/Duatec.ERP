namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public class Company : TypedEntityRecordWrapper
    {
        public const string Entity = "manufacturer";

        public static class Fields
        {
            public const string EplanId = "eplan_id";
            public const string ShortName = "short_name";
            public const string Name = "name";
            public const string WebsiteUrl = "website";
            public const string LogoUrl = "logo";
        }

        public string? EplanId
        {
            get => TryGet<string?>(Fields.EplanId);
            set => Properties[Fields.EplanId] = value;
        }

        public string ShortName
        {
            get => TryGet(Fields.ShortName, string.Empty);
            set => Properties[Fields.ShortName] = value;
        }

        public string Name
        {
            get => TryGet(Fields.Name, string.Empty);
            set => Properties[Fields.Name] = value;
        }

        public string? WebsiteUrl
        {
            get => TryGet<string?>(Fields.WebsiteUrl);
            set => Properties[Fields.WebsiteUrl] = value;
        }

        public string? LogoUrl
        {
            get => TryGet<string?>(Fields.LogoUrl);
            set => Properties[Fields.LogoUrl] = value;
        }
    }
}
