using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.DataModel
{
    public class ArticleDto
    {
        private ArticleDto(
            long id,
            ManufacturerDto manufacturer,
            string partNumber, 
            string description, 
            string partType, 
            string pictureUrl)
        {
            Id = id;
            Manufacturer = manufacturer;
            PartNumber = partNumber;
            Description = description;
            PartType = partType;
            PictureUrl = pictureUrl;
        }

        public long Id { get; }

        public ManufacturerDto Manufacturer { get; }

        public string PartNumber { get; }

        public string Description { get; }

        public string PartType { get; }

        public string PictureUrl { get; }

        public static ArticleDto? FromJson(JsonNode? json, string partNumber)
        {
            return FromJson(json, partNumber, GetDataFromPartNumber);
        }

        public static ArticleDto? FromJson(JsonNode? json, long id)
        {
            return FromJson(json, id, GetDataFromId);
        }

        private static ArticleDto? FromJson<T>(JsonNode? json, T idValue, Func<JsonNode?, T, JsonNode?> getDataNode)
        {
            var data = getDataNode(json, idValue);

            if (data == null || $"{data["type"]}" != "parts")
                return null;

            var attributes = data["attributes"]!;
            var id = long.Parse(data["id"]!.GetValue<string>());
            var manufacturer = GetManufacturer(json);
            var description = GetDescription(attributes, LanguageKey.de_DE)
                ?? GetDescription(attributes, LanguageKey.en_US)
                ?? string.Empty;

            var partType = attributes["part_type"]!.GetValue<string>();
            var partNumber = attributes["part_number"]!.GetValue<string>();

            var pictureId = data["relationships"]?["picture_file"]?["data"]?["id"]?.GetValue<string>();
            var pictureUrl = GetPictureUrl(json, pictureId) ?? string.Empty;

            return new ArticleDto(
                id: id,
                manufacturer: manufacturer,
                partNumber: partNumber,
                description: description,
                partType: partType,
                pictureUrl: pictureUrl);
        }

        private static ManufacturerDto GetManufacturer(JsonNode? json)
        {
            return ManufacturerDto.FromJson(json?["included"]?.AsArray()
                .FirstOrDefault(n => $"{n?["type"]}" == "manufacturers"))!;
        }

        private static JsonNode? GetDataFromPartNumber(JsonNode? json, string partNumber)
        {
            static string IdFromNode(JsonNode? n) => $"{n?["attributes"]?["part_number"]}";
            return GetData(json, partNumber, IdFromNode);
        }

        private static JsonNode? GetDataFromId(JsonNode? json, long id)
        {
            static string IdFromNode(JsonNode? n) => $"{n?["id"]}";
            return GetData(json, id.ToString(), IdFromNode);
        }

        private static JsonNode? GetData(JsonNode? json, string id, Func<JsonNode?, string> idFromNode)
        {
            var data = json?["data"];
            if (data is JsonArray jArr)
            {
                var idString = id.ToString();
                var arr = jArr
                    .Where(n => idFromNode(n) == id)
                    .ToArray();

                if (arr.Length != 1)
                    return null;
                return arr[0];
            }
            return data;
        }

        private static string? GetDescription(JsonNode attributes, LanguageKey key)
        {
            var node = (attributes["description"] as JsonObject)?[key.ToString()]
                ?? (attributes["designation"] as JsonObject)?[key.ToString()];

            var value = node?.GetValue<string>();

            if (!string.IsNullOrEmpty(value))
                return value;

            return null;
        }

        private static string? GetPictureUrl(JsonNode? json, string? id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            id = json?["included"]?.AsArray()
                .FirstOrDefault(n => $"{n?["type"]}" == "picturefile" && $"{n?["id"]}" == id)?["relationships"]?["preview"]?["data"]?["id"]?.GetValue<string?>();

            if (string.IsNullOrEmpty(id)) return null;

            var node = json?["included"]!.AsArray()
                .FirstOrDefault(n => $"{n?["type"]}" == "preview" && $"{n?["id"]}" == id)?["attributes"];

            return node?["512"]?.GetValue<string?>();
        }
    }
}
