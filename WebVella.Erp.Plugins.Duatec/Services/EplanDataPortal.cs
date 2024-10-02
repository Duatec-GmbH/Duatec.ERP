using WebVella.Erp.Plugins.Duatec.Transfere;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    public class EplanDataPortal
    {
        public static async Task<IEnumerable<ManufacturerDto>> GetManufacturers(string? search = null)
        {
            var url = "https://dataportal.eplan.com/api/manufacturers";
            if (!string.IsNullOrWhiteSpace(search))
                url += $"?search={search}";

            var json = await ApiCalls.JsonFromUrl(url);
            var values = json?["data"]?.AsArray();

            if (values == null || values.Count == 0)
                return [];

            return values
                .Select(ManufacturerDto.FromJson)
                .Where(m =>  m != null)!;
        }

        public static async Task<ManufacturerDto?> GetManufacturer(long id, string? search = null)
        {
            return (await GetManufacturers(search))
                .FirstOrDefault(m => m.Id == id);
        }

        public static async Task<ArticleDto?> GetArticleById(long id)
        {
            var url = $"https://dataportal.eplan.com/api/parts/{id}?include=picture_file.preview";

            var json = await ApiCalls.JsonFromUrl(url);
            
            return ArticleDto.FromJson(json);
        }

        public static async Task<ArticleDto?> GetArticleByPartNumber(string manufacturerShortName, string orderNumber)
        {
            var url = $"https://dataportal.eplan.com/api/parts?search=%22{manufacturerShortName}.{orderNumber}%22&include=picture_file.preview";

            var json = await ApiCalls.JsonFromUrl(url);

            return ArticleDto.FromJson(json);
        }

        public static async Task<IEnumerable<ArticleDto>> GetArticlesById(params long[] ids)
        {
            var articles = new List<ArticleDto>(ids.Length);
            foreach(var id in ids)
            {
                var article = await GetArticleById(id);
                if (article != null)
                    articles.Add(article);
            }
            return articles;
        }

        public static async Task<IEnumerable<ArticleDto>> GetArticlesByPartNumber(params (string ManufacturerShortName, string OrderNumber)[] partNumbers)
        {
            var articles = new List<ArticleDto>(partNumbers.Length);
            foreach (var (man, orderNumb) in partNumbers)
            {
                var article = await GetArticleByPartNumber(man, orderNumb);
                if (article != null)
                    articles.Add(article);
            }
            return articles;
        }
    }
}
