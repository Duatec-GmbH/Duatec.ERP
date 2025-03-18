using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel
{
    public class DataPortalArticleDto
    {
        private DataPortalArticleDto(long id, DataPortalManufacturerDto manufacturer,
            string partNumber, string typeNumber, string orderNumber,
            string designation, string pictureUrl)
        {
            EplanId = id;
            Manufacturer = manufacturer;
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Designation = designation;
            PictureUrl = pictureUrl;
        }

        public long EplanId { get; }

        public DataPortalManufacturerDto Manufacturer { get; }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public string Designation { get; }

        public string PictureUrl { get; }

        public static DataPortalArticleDto? FromJsonByPartNumber(JsonNode? json, string partNumber)
        {
            return FromJson(json, partNumber, GetDataFromPartNumber);
        }

        public static DataPortalArticleDto? FromJsonByOrderNumber(JsonNode? json, string orderNumber)
        {
            return FromJson(json, orderNumber, GetDataFromOrderNumber);
        }

        public static DataPortalArticleDto? FromJsonById(JsonNode? json, long id)
        {
            return FromJson(json, id, GetDataFromId);
        }

        private static DataPortalArticleDto? FromJson<T>(JsonNode? json, T idValue, Func<JsonNode?, T, JsonNode?> getDataNode)
        {
            var data = getDataNode(json, idValue);

            if (data == null || $"{data["type"]}" != "parts")
                return null;

            var attributes = data["attributes"]!;
            var id = long.Parse(data["id"]!.GetValue<string>());
            var manufacturer = GetManufacturer(json);

            var pictureId = data["relationships"]?["picture_file"]?["data"]?["id"]?.GetValue<string>();

            return new DataPortalArticleDto(
                id: id,
                manufacturer: manufacturer,
                partNumber: attributes["part_number"]!.GetValue<string>(),
                typeNumber: attributes["type_number"]?.GetValue<string>() ?? string.Empty,
                orderNumber: attributes["order_number"]?.GetValue<string>() ?? string.Empty,
                designation: GetDesignation(attributes),
                pictureUrl: GetPictureUrl(json, pictureId) ?? string.Empty);
        }

        private static DataPortalManufacturerDto GetManufacturer(JsonNode? json)
        {
            return DataPortalManufacturerDto.FromJson(json?["included"]?.AsArray()
                .FirstOrDefault(n => $"{n?["type"]}" == "manufacturers"))!;
        }

        private static JsonNode? GetDataFromPartNumber(JsonNode? json, string partNumber)
        {
            static string IdFromNode(JsonNode? n) => $"{n?["attributes"]?["part_number"]}";
            return GetData(json, partNumber, IdFromNode);
        }

        private static JsonNode? GetDataFromOrderNumber(JsonNode? json, string orderNumber)
        {
            static string IdFromNode(JsonNode? n) => $"{n?["attributes"]?["order_number"]}";
            return GetData(json, orderNumber, IdFromNode);
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
                var arr = jArr
                    .Where(n => idFromNode(n) == id)
                    .ToArray();

                if (arr.Length != 1)
                    return null;
                return arr[0];
            }
            return data;
        }

        private static string GetDesignation(JsonNode attributes)
        {
            var result = GetLanguageItem(attributes, "designation");
            if (string.IsNullOrEmpty(result))
                return GetLanguageItem(attributes, "description");
            return result;
        }


        private static string GetLanguageItem(JsonNode attributes, string property)
        {
            LanguageKey? lang = LanguageKeys.Default;
            var designation = GetLanguageItem(attributes, lang.Value, property);

            while (designation == null)
            {
                lang = LanguageKeys.FallBackLanguage(lang!.Value);
                if (!lang.HasValue)
                    designation = string.Empty;
                else
                    designation = GetLanguageItem(attributes, lang.Value, property);
            }
            return designation;
        }

        private static string? GetLanguageItem(JsonNode attributes, LanguageKey key, string property)
        {
            var node = (attributes[property] as JsonObject)?[key.ToString()];
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
