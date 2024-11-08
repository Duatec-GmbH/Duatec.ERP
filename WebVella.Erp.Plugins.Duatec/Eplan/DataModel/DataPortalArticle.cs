using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.Eplan.DataModel
{
    public class DataPortalArticle
    {
        private DataPortalArticle(
            long id,
            DataPortalManufacturer manufacturer,
            string partNumber,
            string typeNumber,
            string orderNumber,
            string designation,
            string pictureUrl)
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

        public DataPortalManufacturer Manufacturer { get; }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public string Designation { get; }

        public string PictureUrl { get; }

        public static DataPortalArticle? FromJson(JsonNode? json, string partNumber)
        {
            return FromJson(json, partNumber, GetDataFromPartNumber);
        }

        public static DataPortalArticle? FromJson(JsonNode? json, long id)
        {
            return FromJson(json, id, GetDataFromId);
        }

        private static DataPortalArticle? FromJson<T>(JsonNode? json, T idValue, Func<JsonNode?, T, JsonNode?> getDataNode)
        {
            var data = getDataNode(json, idValue);

            if (data == null || $"{data["type"]}" != "parts")
                return null;

            var attributes = data["attributes"]!;
            var id = long.Parse(data["id"]!.GetValue<string>());
            var manufacturer = GetManufacturer(json);

            LanguageKey? lang = LanguageKeys.Default;
            var designation = GetDesignation(attributes, lang.Value);

            while(designation == null)
            {
                lang = LanguageKeys.FallBackLanguage(lang!.Value);
                if (!lang.HasValue)
                    designation = string.Empty;
                else
                    designation = GetDesignation(attributes, lang.Value);
            }

            var partNumber = attributes["part_number"]!.GetValue<string>();
            var typeNumber = attributes["type_number"]?.GetValue<string>() ?? string.Empty;
            var orderNumber = attributes["order_number"]?.GetValue<string>() ?? string.Empty;
            var pictureId = data["relationships"]?["picture_file"]?["data"]?["id"]?.GetValue<string>();
            var pictureUrl = GetPictureUrl(json, pictureId) ?? string.Empty;

            return new DataPortalArticle(
                id: id,
                manufacturer: manufacturer,
                partNumber: partNumber,
                typeNumber: typeNumber,
                orderNumber: orderNumber,
                designation: designation,
                pictureUrl: pictureUrl);
        }

        private static DataPortalManufacturer GetManufacturer(JsonNode? json)
        {
            return DataPortalManufacturer.FromJson(json?["included"]?.AsArray()
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

        private static string? GetDesignation(JsonNode attributes, LanguageKey key)
        {
            var node = (attributes["designation"] as JsonObject)?[key.ToString()];
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
