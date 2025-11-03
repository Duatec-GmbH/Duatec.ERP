using HtmlAgilityPack;
using System.Text.Json.Nodes;
using System.Web;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations
{
    internal class RittalArticleFinder : ArticleFinder
    {
        private readonly object _lockObject = new();

        private string? _url;
        private XPathQuery? _designationQuery;
        private XPathQuery? _imageQuery;
        private XPathQuery? _typeNumberQuery;

        public override void Initialize(JsonNode? settings)
        {
            lock(_lockObject)
            {
                _url = settings?["url"]?.GetValue<string>();
                _designationQuery = XPathQuery.FromJsonNode(settings?["designationQuery"]);
                _imageQuery = XPathQuery.FromJsonNode(settings?["imageQuery"]);
                _typeNumberQuery = XPathQuery.FromJsonNode(settings?["typeNumberQuery"]);
            }
        }

        public override SearchResult GetArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            try
            {
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

        public override List<ArticleSuggestion> Suggest(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            try
            {
                var article = FindArticle(orderNumberFragment, language, []);

                if (article != null)
                {
                    return
                    [
                        new ArticleSuggestion()
                        {
                            PartNumber = article.PartNumber,
                            ImageUrl = article.ImageUrl,
                        }
                    ];
                }
                return [];
            }
            catch
            {
                return [];
            }
        }

        private ArticlePreview? FindArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            if(string.IsNullOrWhiteSpace(orderNumber) || !orderNumber.All(char.IsDigit))
                return null;

            if(_designationQuery == null || _imageQuery == null || _typeNumberQuery == null || string.IsNullOrEmpty(_url))
                return null;

            var langText = language == LanguageKey.en_US ? "com-en" : "at-de_AT";

            var url = _url.Replace("{orderNumber}", orderNumber)
                .Replace("{language}", langText);

            var doc = new HtmlWeb().Load(url);

            var designation = _designationQuery.Execute(doc.DocumentNode);
            var image = _imageQuery.Execute(doc.DocumentNode);
            var typeNumber = _typeNumberQuery.Execute(doc.DocumentNode);

            if (!string.IsNullOrWhiteSpace(designation))
                designation = HttpUtility.HtmlDecode(designation);

            var idx = typeNumber.LastIndexOf(' ');
            if (idx > 0)
                typeNumber = typeNumber[0..idx] + '.' + typeNumber[(idx + 1)..];

            return new()
            {
                PartNumber = "RIT." + orderNumber,
                OrderNumber = orderNumber,
                TypeNumber = typeNumber,
                ImageUrl = image,
                Designation = designation,
                Type = types.SingleOrDefault(t => t.Name.Equals("component", StringComparison.OrdinalIgnoreCase))
            };
        }
    }
}
