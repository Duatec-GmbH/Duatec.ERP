using HtmlAgilityPack;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations
{
    internal class IgusArticleFinder : ArticleFinder
    {
        private string? _searchUrl;
        private string? _suggestUrl;
        private XPathQuery? _suggestQuery;
        private XPathQuery? _designationQuery;
        private XPathQuery? _designationAppendixQuery;
        private XPathQuery? _imageQuery;

        public override void Initialize(JsonNode? settings)
        {
            var suggestOptions = settings?["suggestOptions"];
            var searchOptions = settings?["searchOptions"];

            _suggestUrl = suggestOptions?["url"]?.GetValue<string>();
            _suggestQuery = XPathQuery.FromJsonNode(suggestOptions?["query"]);

            _searchUrl = searchOptions?["url"]?.GetValue<string>();
            _imageQuery = XPathQuery.FromJsonNode(searchOptions?["imageQuery"]);
            _designationQuery = XPathQuery.FromJsonNode(searchOptions?["designationQuery"]);
            _designationAppendixQuery = XPathQuery.FromJsonNode(searchOptions?["designationAppendixQuery"]);
        }

        public override SearchResult GetArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            var t = GetArticleAsync(orderNumber, language, types);
            t.Wait();
            return t.Result;
        }

        public async override Task<SearchResult> GetArticleAsync(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            var article = (await Search(orderNumber, 10, types))
                .Find(p => p.OrderNumber == orderNumber);

            return new SearchResult()
            {
                IsValid = article != null,
                Value = article,
                ErrorMessage = article != null ? string.Empty : $"Could not find article with order number '{orderNumber}'"
            };
        }

        public override List<ArticleSuggestion> Suggest(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            var t = SuggestAsync(orderNumberFragment, language, resultCount);
            t.Wait();
            return t.Result;
        }

        public override async Task<List<ArticleSuggestion>> SuggestAsync(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            return [..(await Search(orderNumberFragment, resultCount, []))
                .Select(p => new ArticleSuggestion()
                {
                    ImageUrl = p.ImageUrl,
                    PartNumber = p.PartNumber,
                })];
        }

        private async Task<List<ArticlePreview>> Search(string orderNumber, int resultCount, List<ArticleType> types)
        {
            if (string.IsNullOrWhiteSpace(_suggestUrl) || _suggestQuery == null)
                return [];

            using var client = new HttpClient();

            var method = new HttpMethod("POST");
            var reqMessage = new HttpRequestMessage(method, _suggestUrl)
            {
                Content = JsonContent.Create(new
                {
                    searchWords = orderNumber,
                    pageSize = resultCount
                })
            };

            var response = await client.SendAsync(reqMessage);
            var text = await response.Content.ReadAsStringAsync();

            var jNode = JsonNode.Parse(text);
            var html = jNode?["Html"]?.GetValue<string>();

            if (string.IsNullOrEmpty(html))
                return [];

            html = html.Replace("\\n", "\n")
                    .Replace("\\\"", "\"")
                    .Trim();

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var tasks = new List<Task<ArticlePreview?>>();

            foreach (var node in doc.DocumentNode.SelectNodes(_suggestQuery.Query))
            {
                var pageUrl = node.Attributes[_suggestQuery.Arguments[0]].Value;
                tasks.Add(LoadFromPageAsync(pageUrl, types));
            }

            return [..(await Task.WhenAll(tasks))
                .Where(p => p != null)];
        }

        private async Task<ArticlePreview?> LoadFromPageAsync(string url, List<ArticleType> types)
        {
            try
            {
                if (_designationQuery == null || _searchUrl == null)
                    return null;

                if (!url.Contains("://"))
                    url = _searchUrl[.._searchUrl.IndexOf('/', _searchUrl.IndexOf("://") + 3)] + url;

                var (typeNumber, orderNumber) = ExtractFromUrl(url);
                if (string.IsNullOrWhiteSpace(typeNumber) || string.IsNullOrWhiteSpace(orderNumber))
                    return null;

                var doc = await new HtmlWeb().LoadFromWebAsync(url);

                if (doc == null)
                    return null;

                var designation = _designationQuery.Execute(doc.DocumentNode);
                var designationAppendix = _designationAppendixQuery?.Execute(doc.DocumentNode) ?? string.Empty;
                var imageQuery = _imageQuery?.SetQueryParameter("orderNumber", orderNumber);
                var imageUrl = imageQuery?.Execute(doc.DocumentNode) ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(designationAppendix))
                    designation = (designation + " " + designationAppendix).Trim();

                return new ArticlePreview()
                {
                    Designation = designation,
                    ImageUrl = imageUrl,
                    OrderNumber = orderNumber,
                    TypeNumber = typeNumber,
                    PartNumber = "IGUS." + orderNumber,
                    Type = types.FirstOrDefault(t => t.Name.Equals("component", StringComparison.OrdinalIgnoreCase))
                };
            }
            catch
            {
                return null;
            }
        }

        private (string TypeNumber, string OrderNumber) ExtractFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(_searchUrl) || !url.Contains('?') || !url.Contains('='))
                return (string.Empty, string.Empty);

            var startLength = _searchUrl.IndexOf("{typeNumber}");

            if (startLength < 0)
                return (string.Empty, string.Empty);

            var midEnd = _searchUrl.IndexOf("{orderNumber}");

            if (midEnd < startLength)
                return (string.Empty, string.Empty);

            var start = _searchUrl[..startLength];
            if (!url.StartsWith(start))
                return (string.Empty, string.Empty);

            var typeNumberEnd = url.IndexOf('?');
            var typeNumber = url[startLength..typeNumberEnd];
            var mid = _searchUrl[(startLength + "{typeNumber}".Length)..midEnd];

            var orderNumberStart = startLength + typeNumber.Length + mid.Length;

            if (url.IndexOf('&', orderNumberStart) >= 0)
                return (typeNumber, url[orderNumberStart..url.IndexOf('&', orderNumberStart)]);


            return (typeNumber, url[orderNumberStart..]);
        }
    }
}
