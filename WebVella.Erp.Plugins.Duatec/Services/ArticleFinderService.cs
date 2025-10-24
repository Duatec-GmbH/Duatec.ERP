using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders;
using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class ArticleFinderService
    {
        private static readonly Dictionary<string, ArticleFinder> _finderLookup = GetFinders();

        public static SearchResult GetArticle(string partNumber)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumber);

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return finder.GetArticle(orderNumber, GetLanguage());

            return NotFound(shortName);
        }

        public static async Task<SearchResult> GetArticleAsync(string partNumber)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumber);

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return await finder.GetArticleAsync(orderNumber, GetLanguage());

            return NotFound(shortName);
        }

        public static List<ArticleSuggestion> Suggest(string partNumberFragment, int resultCount)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumberFragment);

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return finder.Suggest(orderNumber, GetLanguage(), resultCount);

            return [];
        }

        public static async Task<List<ArticleSuggestion>> SuggestAsync(string partNumberFragment, int resultCount)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumberFragment);

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return await finder.SuggestAsync(orderNumber, GetLanguage(), resultCount);

            return [];
        }

        private static Dictionary<string, ArticleFinder> GetFinders()
        {
            return new Dictionary<string, ArticleFinder>
            {
                ["MURR"] = new MurrArticleFinder()
            };
        }

        private static SearchResult NotFound(string partNumber)
        {
            return new SearchResult()
            {
                IsValid = false,
                ErrorMessage = $"Could not find article with part number '{partNumber}'."
            };
        }

        private static LanguageKey GetLanguage() => LanguageKey.de_DE;

        private static (string ShortName, string OrderNumber) ExtractFromPartNumber(string partNumber)
        {
            var pointIndex = partNumber.IndexOf('.');

            if (pointIndex < 0)
                return (string.Empty, string.Empty);

            return (partNumber[..pointIndex], partNumber[(pointIndex + 1)..]);
        }
    }
}
