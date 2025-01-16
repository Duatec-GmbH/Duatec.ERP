using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
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

        public override string EntityName => Entity;

        public string? EplanId
        {
            get => Get<string?>(Fields.EplanId);
            set => Properties[Fields.EplanId] = value;
        }

        public string ShortName
        {
            get => Get(Fields.ShortName, string.Empty);
            set => Properties[Fields.ShortName] = value;
        }

        public string Name
        {
            get => Get(Fields.Name, string.Empty);
            set => Properties[Fields.Name] = value;
        }

        public string? WebsiteUrl
        {
            get => Get<string?>(Fields.WebsiteUrl);
            set => Properties[Fields.WebsiteUrl] = value;
        }

        public string? LogoUrl
        {
            get => Get<string?>(Fields.LogoUrl);
            set => Properties[Fields.LogoUrl] = value;
        }
    }
}
