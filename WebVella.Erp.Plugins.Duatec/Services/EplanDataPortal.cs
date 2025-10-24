using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using NetBox.Extensions;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    public static class EplanDataPortal
    {
        private static DateTimeOffset _validUntil = DateTimeOffset.Now;
        private static readonly List<DataPortalManufacturerDto> _manufacturers = new(500);

        private static string GetArticleExactSearchUrl(string partNumber)
            => $"https://dataportal.eplan.com/api/parts?search=%22{partNumber}%22&include=picture_file.preview,manufacturer";

        private static string GetArticleSearchUrl(string partNumber, int resultCount)
        {
            if (resultCount <= 0 || resultCount > 200)
                resultCount = 200;

            return $"https://dataportal.eplan.com/api/parts?search={partNumber}&page%5Blimit%5D={resultCount}&include=picture_file.preview,manufacturer";
        }

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
            var url = GetArticleExactSearchUrl(partNumber);

            var json = JsonFromUrl(url);

            return DataPortalArticleDto.FromJsonByPartNumber(json, partNumber);
        }

        public static List<DataPortalArticleDto> SuggestArticles(string partNumber, int resultCount)
        {
            var url = GetArticleSearchUrl(partNumber, resultCount);

            var json = JsonFromUrl(url);

            return DataPortalArticleDto.ManyFromJson(json);
        }

        public static async Task<List<DataPortalArticleDto>> SuggestArticlesAsync(string partNumber, int resultCount)
        {
            var url = GetArticleSearchUrl(partNumber, resultCount);

            return await JsonFromUrlAsync(url)
                .ContinueWith(t => DataPortalArticleDto.ManyFromJson(t.Result));
        }

        public static DataPortalArticleDto? GetArticleByOrderNumber(string orderNumber)
        {
            var url = GetArticleExactSearchUrl(orderNumber);

            var json = JsonFromUrl(url);

            return DataPortalArticleDto.FromJsonByOrderNumber(json, orderNumber);
        }

        public static async Task<DataPortalArticleDto?> GetArticleByPartNumberAsync(string partNumber)
        {
            var url = GetArticleExactSearchUrl(partNumber);

            return await JsonFromUrlAsync(url)
                .ContinueWith(n => DataPortalArticleDto.FromJsonByPartNumber(n.Result, partNumber));
        }

        public static async Task<DataPortalArticleDto?> GetArticleByOrderNumberAsync(string orderNumber)
        {
            var url = GetArticleExactSearchUrl(orderNumber);

            return await JsonFromUrlAsync(url)
                .ContinueWith(n => DataPortalArticleDto.FromJsonByOrderNumber(n.Result, orderNumber));
        }

        public static Dictionary<string, DataPortalArticleDto?> GetArticlesByPartNumber(params string[] partNumbers)
        {
            if (partNumbers.Length == 0)
                return [];

            var result = new Dictionary<string, DataPortalArticleDto?>(partNumbers.Length);
            for(var i = 0; i < partNumbers.Length; i += 10)
            {
                var pile = partNumbers.Skip(i).Take(10).ToArray();
                var t = GetMax10ArticlesByPartNumber(pile);

                t.Wait();
                Thread.Sleep(10);

                result.AddRange(t.Result);
            }

            return result;
        }

        private static Task<Dictionary<string, DataPortalArticleDto?>> GetMax10ArticlesByPartNumber(string[] partNumbers)
        {
            if (partNumbers.Length > 10)
                throw new ArgumentException("Can not process more than 10 part numbers");

            var tasks = partNumbers
                .Select(async pn => new { PartNumber = pn, Article = await GetArticleByPartNumberAsync(pn) })
                .ToArray();

            return Task.WhenAll(tasks).ContinueWith(r => r.Result.ToDictionary(t => t.PartNumber, t => t.Article));
        }

        public static Dictionary<string, DataPortalArticleDto?> GetArticlesByOrderNumber(params string[] orderNumbers)
        {
            if (orderNumbers.Length == 0)
                return [];

            var tasks = orderNumbers
                .Select(async on => new { OrderNumber = on, Article = await GetArticleByOrderNumberAsync(on) })
                .ToArray();

            return Task.WhenAll(tasks).Result.ToDictionary(t => t.OrderNumber, t => t.Article);
        }

        public static DataPortalArticleDto? GetArticleById(long id)
        {
            var url = GetArticleByIdUrl(id);

            var json = JsonFromUrl(url);

            return DataPortalArticleDto.FromJsonById(json, id);
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
