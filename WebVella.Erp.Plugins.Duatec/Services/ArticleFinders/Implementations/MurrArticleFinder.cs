using HtmlAgilityPack;
using System.Web;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations
{
    internal class MurrArticleFinder : ArticleFinder
    {
        public override SearchResult GetArticle(string orderNumber, LanguageKey language)
        {
            try
            {
                if (orderNumber.Any(char.IsAsciiLetterLower))
                    orderNumber = orderNumber.ToUpperInvariant().Replace('_', '-');

                var article = FindArticle(orderNumber, language);

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

        private static ArticlePreview? FindArticle(string orderNumber, LanguageKey language)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                return null;

            var doc = new HtmlWeb().Load(GetUrl(orderNumber, language));

            var searchString = language == LanguageKey.en_US
                ? "Art.-No.: " + orderNumber
                : "Art.-Nr.: " + orderNumber;

            var formQuery = $"//*[@id='searchList']//form[//.='{searchString}']";

            var form = doc.DocumentNode.SelectNodes(formQuery).Single();

            var imageSource = GetSource(form.SelectNodes($"{formQuery}//*[@class='pictureBox']//img").Single());
            var designation = GetFirstTextElement(form.SelectNodes($"{formQuery}//*[@class='title']").Single());
            var description = GetFirstTextElement(form.SelectNodes($"{formQuery}//*[@class='shortdesc']").Single());

            return new()
            {
                OrderNumber = orderNumber,
                Designation = (designation + " " + description).Trim(),
                ImageUrl = imageSource,
            };
        }

        private static string GetUrl(string orderNumber, LanguageKey language)
        {
            var lang = language == LanguageKey.en_US ? 1 : 0;
            return $"https://shop.murrelektronik.at/index.php?cl=search&searchparam={HttpUtility.UrlEncode(orderNumber)}&_artperpage=100&pgNr=0&lang={lang}";
        }

        private static string SuggestUrl(string orderNumberFragment, LanguageKey language)
        {
            orderNumberFragment = HttpUtility.UrlEncode(orderNumberFragment);
            var lan = language == LanguageKey.en_US ? "lv_shopat_en" : "lv_shopat_de";
            return $"https://shop.murrelektronik.at/modules/nfc/nfc_ff_suggest/Controller/Proxy/Suggest.php?query={orderNumberFragment}&channel={lan}";
        }

        private static string GetFirstTextElement(HtmlNode node)
            => node.ChildNodes.FirstOrDefault()?.InnerText.Trim() ?? node.InnerText.Trim();

        private static string GetSource(HtmlNode node)
            => node.GetAttributes("src").FirstOrDefault()?.Value ?? string.Empty;
    }
}
