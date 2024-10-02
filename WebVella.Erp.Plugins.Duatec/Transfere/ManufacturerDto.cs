using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.Transfere
{
    public class ManufacturerDto
    {
        private ManufacturerDto(long id, string shortName, string name, string? websiteUrl, string? logoUrl, bool hasCatalog)
        {
            Id = id;
            ShortName = shortName;
            Name = name;
            WebsiteUrl = websiteUrl;
            LogoUrl = logoUrl;
            HasCatalog = hasCatalog;
        }

        public long Id { get; }

        public string ShortName { get; }

        public string Name { get; }

        public string? WebsiteUrl { get; }

        public string? LogoUrl { get; }

        public bool HasCatalog { get; }

        public static ManufacturerDto? FromJson(JsonNode? json)
        {
            if(json == null || $"{json["type"]}" != "manufacturers")
                return null;

            var id = json["id"]!.GetValue<long>();
            json = json["attributes"]!;

            return new ManufacturerDto(
                id: id,
                shortName: json["short_name"]!.GetValue<string>(),
                name: json["name"]!.GetValue<string>()!,
                websiteUrl: json["website"]?.GetValue<string?>(),
                logoUrl: json["logo_url"]?.GetValue<string?>(),
                hasCatalog: json["has_catalog"]!.GetValue<bool>());
        }
    }
}
