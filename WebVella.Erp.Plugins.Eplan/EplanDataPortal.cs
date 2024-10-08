using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using WebVella.Erp.Plugins.Eplan.DataModel;

namespace WebVella.Erp.Plugins.Eplan
{
    public class EplanDataPortal
    {
        private static string GetArticleByIdUrl(long id)
            => $"https://dataportal.eplan.com/api/parts/{id}?include=picture_file.preview,manufacturer";

        private static string GetArticleByPartNumberUrl(string partNumber)
            => $"https://dataportal.eplan.com/api/parts?search=%22{partNumber}%22&include=picture_file.preview,manufacturer";


        public static async Task<IEnumerable<ManufacturerDto>> GetManufacturersAsync(string? search = null)
        {
            var url = "https://dataportal.eplan.com/api/manufacturers";
            if (!string.IsNullOrWhiteSpace(search))
                url += $"?search={search}";

            var json = await JsonFromUrlAsync(url);
            var values = json?["data"]?.AsArray();

            if (values == null || values.Count == 0)
                return [];

            return values
                .Select(ManufacturerDto.FromJson)
                .Where(m =>  m != null)!;
        }

        public static async Task<ManufacturerDto?> GetManufacturerAsync(long id, string? search = null)
        {
            return (await GetManufacturersAsync(search))
                .FirstOrDefault(m => m.Id == id);
        }

        public static ArticleDto? GetArticleById(long id)
        {
            var url = GetArticleByIdUrl(id);

            var json = JsonFromUrl(url);

            return ArticleDto.FromJson(json, id);
        }

        public static async Task<ArticleDto?> GetArticleByIdAsync(long id)
        {
            var url = GetArticleByIdUrl(id);

            var json = await JsonFromUrlAsync(url);
            
            return ArticleDto.FromJson(json, id);
        }

        public static ArticleDto? GetArticleByPartNumber(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            var json = JsonFromUrl(url);

            return ArticleDto.FromJson(json, partNumber);
        }

        public static async Task<ArticleDto?> GetArticleByPartNumberAsync(string partNumber)
        {
            var url = GetArticleByPartNumberUrl(partNumber);

            var json = await JsonFromUrlAsync(url);

            return ArticleDto.FromJson(json, partNumber);
        }

        public static async Task<IEnumerable<ArticleDto>> GetArticlesById(params long[] ids)
        {
            var articles = new List<ArticleDto>(ids.Length);
            foreach(var id in ids)
            {
                var article = await GetArticleByIdAsync(id);
                if (article != null)
                    articles.Add(article);
            }
            return articles;
        }



        public static async Task<IEnumerable<ArticleDto>> GetArticlesByPartNumber(params string[] partNumbers)
        {
            var articles = new List<ArticleDto>(partNumbers.Length);
            foreach (var partNumber in partNumbers)
            {
                var article = await GetArticleByPartNumberAsync(partNumber);
                if (article != null)
                    articles.Add(article);
            }
            return articles;
        }

        private async static Task<JsonNode?> JsonFromUrlAsync(string url)
        {
            using var client = GetClient();

            return JsonObject.Parse(await client.GetStringAsync(url));
        }

        private static JsonNode? JsonFromUrl(string url)
        {
            using var client = GetClient();

            var t = client.GetStringAsync(url);
            t.Wait();

            return JsonObject.Parse(t.Result);
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
