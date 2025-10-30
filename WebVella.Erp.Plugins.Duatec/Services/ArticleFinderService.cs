using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders;
using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class ArticleFinderService
    {
        public static SearchResult GetArticle(string partNumber, List<ArticleType> types)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumber);

            if (GetFinder(shortName) is ArticleFinder finder)
                return finder.GetArticle(orderNumber, GetLanguage(), types);

            return NotFound(shortName);
        }

        public static async Task<SearchResult> GetArticleAsync(string partNumber, List<ArticleType> types)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumber);

            if (GetFinder(shortName) is ArticleFinder finder)
                return await finder.GetArticleAsync(orderNumber, GetLanguage(), types);

            return NotFound(shortName);
        }

        public static List<ArticleSuggestion> Suggest(string partNumberFragment, int resultCount)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumberFragment);

            if (GetFinder(shortName) is ArticleFinder finder)
                return finder.Suggest(orderNumber, GetLanguage(), resultCount);

            return [];
        }

        public static async Task<List<ArticleSuggestion>> SuggestAsync(string partNumberFragment, int resultCount)
        {
            var (shortName, orderNumber) = ExtractFromPartNumber(partNumberFragment);

            if (GetFinder(shortName) is ArticleFinder finder)
                return await finder.SuggestAsync(orderNumber, GetLanguage(), resultCount);

            return [];
        }

        private static ArticleFinder? GetFinder(string shortName)
        {
            shortName = shortName.ToUpperInvariant();
            ArticleFinder? finder = null;

            if (shortName == "MURR")
                finder = new MurrArticleFinder();
            else if (shortName == "RIT")
                finder = new RittalArticleFinder();

            if(finder != null)
            {
                var recMan = new RecordManager(ignoreSecurity: true, executeHooks: false);
                var config = new FinderConfigRepository(recMan)
                    .Find(shortName);

                finder.Initialize(config?.Config);
            }
            return finder;
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
