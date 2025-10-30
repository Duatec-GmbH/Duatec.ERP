using HtmlAgilityPack;
using System.Text.Json.Nodes;
using System.Web;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations
{
    internal class MurrArticleFinder : ArticleFinder
    {
        private readonly object _lockObject = new();
        private string? _searchUrl;
        private string? _suggestUrl;
        private string? _articleNumberSearchStringEnglish;
        private string? _articleNumberSearchStringGerman;
        private XPathQuery? _designationQuery;
        private XPathQuery? _descriptionQuery;
        private XPathQuery? _imageQuery;

        public override void Initialize(JsonNode? settings)
        {
            lock (_lockObject)
            {
                var searchOptions = settings?["searchOptions"];
                var suggestOptions = settings?["suggestOptions"];
                _searchUrl = searchOptions?["url"]?.GetValue<string>() ?? string.Empty;
                _suggestUrl = suggestOptions?["url"]?.GetValue<string>() ?? string.Empty;
                _articleNumberSearchStringEnglish = searchOptions?["articleNumberEnglish"]?.GetValue<string>() ?? string.Empty;
                _articleNumberSearchStringGerman = searchOptions?["articleNumberGerman"]?.GetValue<string>() ?? string.Empty;
                _designationQuery = XPathQuery.FromJsonNode(searchOptions?["designationQuery"]);
                _descriptionQuery = XPathQuery.FromJsonNode(searchOptions?["descriptionQuery"]);
                _imageQuery = XPathQuery.FromJsonNode(searchOptions?["imageQuery"]);
            }
        }

        public override SearchResult GetArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            try
            {
                if (orderNumber.Any(char.IsAsciiLetterLower))
                    orderNumber = orderNumber.ToUpperInvariant().Replace('_', '-');

                var article = FindArticle(orderNumber, language, types);

                return new()
                {
                    IsValid = article != null,
                    Value = article,
                    ErrorMessage = article != null ? string.Empty : $"Could not find article with order number '{orderNumber}'."
                };
            }
            catch
            {
                return new()
                {

                    IsValid = false,
                    Value = null,
                    ErrorMessage = $"Could not find article with order number '{orderNumber}'."
                };
            }
        }

        public override async Task<List<ArticleSuggestion>> SuggestAsync(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            try
            {
                if (resultCount <= 0 || resultCount > 100)
                    resultCount = 100;

                var url = SuggestUrl(orderNumberFragment, language);

                using var client = new HttpClient();

                var text = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(text))
                    return [];

                return [.. text.Split('\n')
                    .Select(l => l.TrimEnd('\r').Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s) && (s.Contains("#Product Number#") || s.Contains("#Artikelnummer#")))
                    .Select(s => {

                        var orderNumberEnd = s.IndexOf('#');
                        if(orderNumberEnd < 0)
                            return null;

                        var orderNumber = s[..orderNumberEnd];

                        var imageStart = s.LastIndexOf("https://");
                        var imageUrl = imageStart < 0 ? string.Empty : s[imageStart..];

                        return new ArticleSuggestion()
                        {
                            PartNumber = "MURR." + orderNumber,
                            ImageUrl = imageUrl,
                        };
                    }).Where(sugg => sugg != null)
                    .Take(resultCount)];
            }
            catch
            {
                return [];
            }
        }

        public override List<ArticleSuggestion> Suggest(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            var t = SuggestAsync(orderNumberFragment, language, resultCount);
            t.Wait();
            return t.Result;
        }

        private ArticlePreview? FindArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                return null;

            if(_imageQuery == null || _designationQuery == null || _descriptionQuery == null)
                return null;

            var url = GetUrl(orderNumber, language);
            var doc = new HtmlWeb().Load(url);

            var searchString = language == LanguageKey.en_US
                ? _articleNumberSearchStringEnglish + orderNumber
                : _articleNumberSearchStringGerman + orderNumber;

            var imageSource = ReplaceSearchString(_imageQuery, searchString).Execute(doc.DocumentNode);
            var designation = ReplaceSearchString(_designationQuery, searchString).Execute(doc.DocumentNode);
            var description = ReplaceSearchString(_descriptionQuery, searchString).Execute(doc.DocumentNode)
                .Replace(searchString, "");

            return new()
            {
                PartNumber = "MURR." + orderNumber,
                OrderNumber = orderNumber,
                TypeNumber = orderNumber,
                Designation = (designation + " " + description)
                    .Replace("\r\n", " ")
                    .Replace("\n", " ")
                    .Replace("  ", " ")
                    .Replace("  ", " ")
                    .Trim(),
                ImageUrl = imageSource,
                Type = types.SingleOrDefault((t) => t.Name.Equals("component", StringComparison.OrdinalIgnoreCase))
            };
        }

        private static XPathQuery ReplaceSearchString(XPathQuery query, string searchString)
        {
            return new XPathQuery()
            {
                Arguments = query.Arguments,
                ResolveKind = query.ResolveKind,
                Query = query.Query.Replace("{searchString}", searchString)
            };
        }

        private string GetUrl(string orderNumber, LanguageKey language)
        {
            var lang = language == LanguageKey.en_US ? 1 : 0;
            orderNumber = HttpUtility.UrlEncode(orderNumber);

            var url = _searchUrl?.Replace("{orderNumber}", orderNumber)
                .Replace("{language}", lang.ToString());

            return url ?? string.Empty;
        }

        private string SuggestUrl(string orderNumberFragment, LanguageKey language)
        {
            orderNumberFragment = HttpUtility.UrlEncode(orderNumberFragment);
            var lang = language == LanguageKey.en_US ? "lv_shopat_en" : "lv_shopat_de";

            var url = _suggestUrl?.Replace("{orderNumber}", orderNumberFragment)
                .Replace("{language}", lang);
            
            return url ?? string.Empty;
        }
    }
}
