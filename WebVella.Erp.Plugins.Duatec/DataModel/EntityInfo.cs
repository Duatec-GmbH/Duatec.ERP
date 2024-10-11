
namespace WebVella.Erp.Plugins.Duatec.DataModel
{
    public static class EntityInfo
    {
        public static class Manufacturer
        {
            public const string Entity = "manufacturer";
            public const string EplanId = "eplan_id";
            public const string ShortName = "short_name";
            public const string Name = "name";
            public const string WebsiteUrl = "website";
            public const string LogoUrl = "logo";
        }

        public static class Article
        {
            public const string Entity = "article";
            public const string EplanId = "eplan_id";
            public const string PartNumber = "part_number";
            public const string Designation = "designation";
            public const string Type = "article_type";
            public const string ManufacturerId = "manufacturer_id";
            public const string Image = "preview";
        }
    }
}
