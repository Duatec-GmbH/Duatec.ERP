using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    public static class EplanDataPortal
    {
        private static DateTimeOffset _validUntil = DateTimeOffset.Now;
        private static readonly List<DataPortalManufacturerDto> _manufacturers = new(500);

        private static string GetArticleByPartNumberUrl(string partNumber)
            => $"https://dataportal.eplan.com/api/parts?search=%22{partNumber}%22&include=picture_file.preview,manufacturer";

        private static string GetArticleByIdUrl(long id)
            => $"https://dataportal.eplan.com/api/parts/{id}?include=picture_file.preview,manufacturer";

        public static List<DataPortalManufacturerDto> GetManufacturers()
        {
            if (DateTimeOffset.Now >= _validUntil || _manufacturers.Count == 0)
            {
                lock (_manufacturers)
                {
#pragma warning disable S1075 // URIs should not be hardcoded
                    var json = JsonFromUrl("https://dataportal.eplan.com/api/manufacturers");
#pragma warning restore S1075 // URIs should not be hardcoded

                    var values = json?["data"]?.AsArray();

                    if (values != null)
                    {
                        _manufacturers.Clear();
                        _manufacturers.AddRange(values
                            .Select(DataPortalManufacturerDto.FromJson)
                            .Where(m => m != null)!);

                        _validUntil = DateTimeOffset.Now.AddHours(2);
                    }
                }
            }

            return _manufacturers;
        }

        public static DataPortalManufacturerDto? GetManufacturerByShortName(string shortName)
        {
            return GetManufacturers()
                .Find(m => m.ShortName == shortName);
        }

        public static DataPortalManufacturerDto? GetManufacturerById(long id)
        {
            return GetManufacturers()
                .Find(m => m.EplanId == id);
        }

        public static DataPortalArticleDto? GetArticleByPartNumber(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            var json = JsonFromUrl(url);

            return DataPortalArticleDto.FromJson(json, partNumber);
        }

        public static async Task<DataPortalArticleDto?> GetArticleByPartNumberAsync(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            return await JsonFromUrlAsync(url)
                .ContinueWith(n => DataPortalArticleDto.FromJson(n.Result, partNumber));
        }

        public static Dictionary<string, DataPortalArticleDto?> GetArticlesByPartNumber(params string[] partNumbers)
        {
            if (partNumbers.Length == 0)
                return [];

            var tasks = partNumbers
                .Select(async pn => new { PartNumber = pn, Article = await GetArticleByPartNumberAsync(pn) })
                .ToArray();

            return Task.WhenAll(tasks).Result.ToDictionary(t => t.PartNumber, t => t.Article);
        }

        public static DataPortalArticleDto? GetArticleById(long id)
        {
            var url = GetArticleByIdUrl(id);

            var json = JsonFromUrl(url);

            return DataPortalArticleDto.FromJson(json, id);
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
