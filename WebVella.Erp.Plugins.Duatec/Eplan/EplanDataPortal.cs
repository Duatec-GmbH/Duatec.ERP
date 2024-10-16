using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Eplan
{
    public static class EplanDataPortal
    {
        private static DateTimeOffset ManufacturersValidUntil = DateTimeOffset.Now;
        private static List<ManufacturerDto> Manufacturers = [];

        private static string GetArticleByPartNumberUrl(string partNumber)
            => $"https://dataportal.eplan.com/api/parts?search=%22{partNumber}%22&include=picture_file.preview,manufacturer";

        private static string GetArticleByIdUrl(long id)
            => $"https://dataportal.eplan.com/api/parts/{id}?include=picture_file.preview,manufacturer";

        public static List<ManufacturerDto> GetManufacturers()
        {
            if (Manufacturers.Count == 0 || ManufacturersValidUntil < DateTimeOffset.Now)
            {
                var json = JsonFromUrl("https://dataportal.eplan.com/api/manufacturers");
                var values = json?["data"]?.AsArray();

                if (values != null && values.Count >= 0)
                {
                    Manufacturers = values
                        .Select(ManufacturerDto.FromJson)
                        .Where(m => m != null)!
                        .ToList()!;
                }
                ManufacturersValidUntil = DateTimeOffset.Now.AddHours(10);
            }

            return Manufacturers;
        }

        public static ManufacturerDto? GetManufacturerByShortName(string shortName)
        {
            return GetManufacturers()
                .FirstOrDefault(m => m.ShortName == shortName);
        }

        public static ManufacturerDto? GetManufacturerById(long id)
        {
            return GetManufacturers()
                .FirstOrDefault(m => m.EplanId == id);
        }

        public static ArticleDto? GetArticleByPartNumber(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            var json = JsonFromUrl(url);

            return ArticleDto.FromJson(json, partNumber);
        }

        public static ArticleDto? GetArticleById(long id)
        {
            var url = GetArticleByIdUrl(id);

            var json = JsonFromUrl(url);

            return ArticleDto.FromJson(json, id);
        }

        private static JsonNode? JsonFromUrl(string url)
        {
            using var client = GetClient();

            var t = client.GetStringAsync(url);
            t.Wait();

            return JsonNode.Parse(t.Result);
        }

        private static HttpClient GetClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
