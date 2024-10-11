using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.DataModel
{
    public class ManufacturerDto
    {
        private ManufacturerDto(long id, string shortName, string name, string? websiteUrl, string? logoUrl)
        {
            EplanId = id;
            ShortName = shortName;
            Name = name;
            WebsiteUrl = websiteUrl ?? string.Empty;
            LogoUrl = logoUrl ?? string.Empty;
        }

        public long EplanId { get; }

        public string ShortName { get; }

        public string Name { get; }

        public string WebsiteUrl { get; }

        public string LogoUrl { get; }

        public static ManufacturerDto? FromJson(JsonNode? json)
        {
            if(json == null || $"{json["type"]}" != "manufacturers")
                return null;

            var id = long.Parse(json["id"]!.GetValue<string>());
            json = json["attributes"]!;

            var shortName = json["short_name"]!.GetValue<string>();
            var name = json["long_name"]!.GetValue<string>()!;

            var websiteUrl = json["website"]?.GetValue<string?>();
            var logoUrl = json["logo_url"]?.GetValue<string>();

            return new ManufacturerDto(
                id: id,
                shortName: shortName,
                name: name,
                websiteUrl: websiteUrl,
                logoUrl: logoUrl);
        }
    }
}
