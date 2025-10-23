using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes;
using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class ArticleImportService
    {
        private static readonly Dictionary<string, ArticleFinder> _finderLookup = GetFinders();

        public static SearchResult GetArticle(string partNumber)
        {
            var pointIndex = partNumber.IndexOf('.');
            if (pointIndex <= 0)
                return NotFound(partNumber);

            var language = LanguageKey.de_DE;
            var shortName = partNumber[0..partNumber.IndexOf('.')];

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return finder.GetArticle(partNumber[(pointIndex + 1)..], language);

            return NotFound(shortName);
        }

        public static async Task<SearchResult> GetArticleAsync(string partNumber)
        {
            var pointIndex = partNumber.IndexOf('.');
            if (pointIndex <= 0)
                return NotFound(partNumber);

            var language = LanguageKey.de_DE;
            var shortName = partNumber[0..partNumber.IndexOf('.')];

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return await finder.GetArticleAsync(partNumber[(pointIndex + 1)..], language);

            return NotFound(shortName);
        }

        public static List<ArticleSuggestion> Suggest(string partNumberFragment)
        {
            var pointIndex = partNumberFragment.IndexOf('.');
            if (pointIndex <= 0)
                return [];

            var language = LanguageKey.de_DE;
            var shortName = partNumberFragment[0..partNumberFragment.IndexOf('.')];

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return finder.Suggest(partNumberFragment[(pointIndex + 1)..], language);

            return [];
        }

        public static async Task<List<ArticleSuggestion>> SuggestAsync(string partNumberFragment)
        {
            var pointIndex = partNumberFragment.IndexOf('.');
            if (pointIndex <= 0)
                return [];

            var language = LanguageKey.de_DE;
            var shortName = partNumberFragment[0..partNumberFragment.IndexOf('.')];

            if (_finderLookup.TryGetValue(shortName.ToUpperInvariant(), out var finder))
                return await finder.SuggestAsync(partNumberFragment[(pointIndex + 1)..], language);

            return [];
        }


        private static Dictionary<string, ArticleFinder> GetFinders()
        {
            throw new NotImplementedException();
        }

        private static SearchResult NotFound(string partNumber)
        {
            return new SearchResult()
            {
                IsValid = false,
                ErrorMessage = $"Could not find article with part number '{partNumber}'."
            };
        }
    }
}
