using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Eplan
{
    public static class DataPortal
    {
        private static DateTimeOffset ManufacturersValidUntil = DateTimeOffset.Now;
        private static List<DataPortalManufacturer> Manufacturers = [];

        private static string GetArticleByPartNumberUrl(string partNumber)
            => $"https://dataportal.eplan.com/api/parts?search=%22{partNumber}%22&include=picture_file.preview,manufacturer";

        private static string GetArticleByIdUrl(long id)
            => $"https://dataportal.eplan.com/api/parts/{id}?include=picture_file.preview,manufacturer";

        public static List<DataPortalManufacturer> GetManufacturers()
        {
            if (Manufacturers.Count == 0 || ManufacturersValidUntil < DateTimeOffset.Now)
            {
                lock (Manufacturers)
                {
                    var json = JsonFromUrl("https://dataportal.eplan.com/api/manufacturers");
                    var values = json?["data"]?.AsArray();

                    if (values != null && values.Count >= 0)
                    {

                        Manufacturers = values
                            .Select(DataPortalManufacturer.FromJson)
                            .Where(m => m != null)!
                            .ToList()!;

                        ManufacturersValidUntil = DateTimeOffset.Now.AddHours(2);
                    }
                }
            }

            return Manufacturers;
        }

        public static DataPortalManufacturer? GetManufacturerByShortName(string shortName)
        {
            return GetManufacturers()
                .FirstOrDefault(m => m.ShortName == shortName);
        }

        public static DataPortalManufacturer? GetManufacturerById(long id)
        {
            return GetManufacturers()
                .FirstOrDefault(m => m.EplanId == id);
        }

        public static DataPortalArticle? GetArticleByPartNumber(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            var json = JsonFromUrl(url);

            return DataPortalArticle.FromJson(json, partNumber);
        }

        public static async Task<DataPortalArticle?> GetArticleByPartNumberAsync(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            return await JsonFromUrlAsync(url)
                .ContinueWith(n => DataPortalArticle.FromJson(n.Result, partNumber));
        }

        public static Dictionary<string, DataPortalArticle?> GetArticlesByPartNumber(params string[] partNumbers)
        {
            if (partNumbers.Length == 0)
                return[];

            var tasks = partNumbers
                .Select(async pn => new { PartNumber = pn, Article = await GetArticleByPartNumberAsync(pn) })
                .ToArray();

            return Task.WhenAll(tasks).Result.ToDictionary(t => t.PartNumber, t => t.Article);
        }

        public static DataPortalArticle? GetArticleById(long id)
        {
            var url = GetArticleByIdUrl(id);

            var json = JsonFromUrl(url);

            return DataPortalArticle.FromJson(json, id);
        }

        private static JsonNode? JsonFromUrl(string url)
        {
            using var client = GetClient();

            var t = client.GetStringAsync(url);
            t.Wait();

            return JsonNode.Parse(t.Result);
        }

        private static async Task<JsonNode?> JsonFromUrlAsync(string url)
        {
            using var client = GetClient();

            var json = await client.GetStringAsync(url);

            return JsonNode.Parse(json);
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
