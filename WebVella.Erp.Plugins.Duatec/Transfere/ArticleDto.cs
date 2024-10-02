using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebVella.Erp.Plugins.Duatec.Transfere
{
    public class ArticleDto
    {
        private ArticleDto(
            long id, 
            long manufacturerId,
            string partNumber, 
            string orderNumber, 
            string typeNumber, 
            IReadOnlyDictionary<string, string> designations, 
            string partType, 
            string identCode,
            string? pictureUrl)
        {
            Id = id;
            ManufacturerId = manufacturerId;
            PartNumber = partNumber;
            OrderNumber = orderNumber;
            TypeNumber = typeNumber;
            Designations = designations;
            PartType = partType;
            IdentCode = identCode;
            PictureUrl = pictureUrl;
        }

        public long Id { get; }

        public long ManufacturerId { get; }

        public string PartNumber { get; }

        public string OrderNumber { get; }

        public string TypeNumber { get; }

        public IReadOnlyDictionary<string, string> Designations { get; }

        public string PartType { get; }

        public string IdentCode { get; }

        public string? PictureUrl { get; }

        public static ArticleDto? FromJson(JsonNode? json)
        {
            var data = GetData(json);

            if (data == null || $"{data["type"]}" != "parts")
                return null;

            var id = data["id"]!.GetValue<long>();
            var attributes = data["attributes"]!;
            var relationships = data["relationships"]!;

            return new ArticleDto(
                id: id,
                manufacturerId: GetManufacturer(relationships["manufacturer"]!),
                partNumber: attributes["part_number"]!.GetValue<string>(),
                orderNumber: attributes["order_number"]!.GetValue<string>(),
                typeNumber: attributes["type_number"]!.GetValue<string>(),
                designations: GetDesignations(attributes["designation"]),
                partType: attributes["part_type"]!.GetValue<string>(),
                identCode: attributes["ident_code"]!.GetValue<string>(),
                pictureUrl: GetPictureUrl(GetPictureNode(json)));
        }

        private static JsonNode? GetPictureNode(JsonNode? json)
        {
            return json?["included"]?.AsArray()
                .FirstOrDefault(n => $"{n?["type"]}" == "preview")?["attributes"];
        }

        private static JsonNode? GetData(JsonNode? json)
        {
            var data = json?["data"];
            if (data is JsonArray arr)
            {
                if (arr.Count > 1 || arr.Count == 0)
                    return null;
                return arr[0];
            }
            return data;
        }

        private static Dictionary<string, string> GetDesignations(JsonNode? json)
        {
            var result = new Dictionary<string, string>(8);

            foreach(var key in LanguageKey.All)
            {
                var value = GetDesignation(json, key);
                if(!string.IsNullOrEmpty(value))
                    result[key] = value;
            }
            return result;
        }

        private static long GetManufacturer(JsonNode json)
        {
            var data = json["data"]!;
            if ($"{data["type"]}" != "manufacturers")
                throw new InvalidDataException($"invalid type of manufacturer node.");
            return data["id"]!.GetValue<long>();
        }

        private static string? GetDesignation(JsonNode? json, string languageKey)
        {
            return json?[languageKey]?.GetValue<string?>();
        }

        private static string? GetPictureUrl(JsonNode? json)
        {
            return json?["512"]?.GetValue<string?>();
        }
    }
}
