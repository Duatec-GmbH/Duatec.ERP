using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations
{
    internal class LappArticleFinder : ArticleFinder
    {
        private string? _url;
        private string? _designationProperty;
        private string? _imagesProperty;
        private string? _descriptionProperty;
        private string? _orderNumberProperty;

        public override void Initialize(JsonNode? settings)
        {
            _url = settings?["url"]?.GetValue<string>();
            _orderNumberProperty = settings?["orderNumberProperty"]?.GetValue<string>();
            _designationProperty = settings?["designationProperty"]?.GetValue<string>();
            _descriptionProperty = settings?["descriptionProperty"]?.GetValue<string>();
            _imagesProperty = settings?["imagesProperty"]?.GetValue<string>();
        }

        public override List<ArticleSuggestion> Suggest(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            try
            {
                return [..FindArticle(orderNumberFragment, language, resultCount, [])
                    .Select(p => new ArticleSuggestion() { ImageUrl = p.ImageUrl, PartNumber = p.PartNumber})];
            }
            catch
            {
                return [];
            }
        }

        public override SearchResult GetArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            try
            {
                var preview = FindArticle(orderNumber, language, 1, types).FirstOrDefault(p => p.OrderNumber == orderNumber);

                return new SearchResult()
                {
                    IsValid = preview != null,
                    Value = preview,
                    ErrorMessage = preview != null ? string.Empty : $"Could not find article with order number '{orderNumber}'."
                };
            }
            catch
            {
                return new SearchResult()
                {
                    IsValid = false,
                    ErrorMessage = $"Could not find article with order number '{orderNumber}'."
                };
            }
        }

        private List<ArticlePreview> FindArticle(string orderNumber, LanguageKey language, int resultCount, List<ArticleType> types)
        {
            if (_orderNumberProperty == null || _descriptionProperty == null || _designationProperty == null || _imagesProperty == null)
                return [];

            var url = GetUrl(orderNumber, language, resultCount);

            using var client = new HttpClient();
            var t = client.GetStringAsync(url);
            t.Wait();

            if (t.Result == null)
                return [];

            var node = JsonNode.Parse(t.Result);
            var type = types.FirstOrDefault(t => t.Name.Equals("component", StringComparison.OrdinalIgnoreCase));
            var products = node?["products"]?.AsArray();

            return (products?
                .Select(n =>
                {
                    if (n == null)
                        return null;

                    var orderNumber = n[_orderNumberProperty]?.GetValue<string>() ?? string.Empty;
                    var typeNumber = n[_designationProperty]?.GetValue<string>() ?? string.Empty;
                    var designation = $"{n[_descriptionProperty]?.GetValue<string>()}".Trim();
                    var images = n[_imagesProperty]?.AsArray() ?? [];
                    var image = (images.FirstOrDefault(jn => "searchImage".Equals(jn?["format"]?.GetValue<string>()))
                        ?? images.FirstOrDefault())?["url"]?.GetValue<string>() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(orderNumber))
                        return null;

                    if (string.IsNullOrWhiteSpace(typeNumber))
                        typeNumber = orderNumber;

                    return new ArticlePreview()
                    {
                        Designation = designation,
                        OrderNumber = orderNumber,
                        ImageUrl = image,
                        PartNumber = "LAPP." + orderNumber,
                        TypeNumber = typeNumber,
                        Type = type,
                    };
                }).Where(p => p != null)
                .ToList() ?? [])!;
        }

        private string GetUrl(string orderNumber, LanguageKey language, int resultCount)
        {
            if (resultCount > 100 || resultCount <= 0)
                resultCount = 100;

            var lang = language == LanguageKey.en_US ? "en" : "de";

            var url = _url?.Replace("{language}", lang)
                .Replace("{resultSize}", resultCount.ToString())
                .Replace("{orderNumber}", orderNumber);

            return url ?? string.Empty;
        }
    }
}
