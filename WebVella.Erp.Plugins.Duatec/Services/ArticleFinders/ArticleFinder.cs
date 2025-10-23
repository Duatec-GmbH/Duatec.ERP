using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    internal abstract class ArticleFinder
    {
        public abstract SearchResult GetArticle(string orderNumber, LanguageKey language);

        public virtual Task<SearchResult> GetArticleAsync(string orderNumber, LanguageKey language)
            => Task.Run(() => GetArticle(orderNumber, language));

        public abstract List<ArticleSuggestion> Suggest(string orderNumberFragment, LanguageKey language);

        public virtual Task<List<ArticleSuggestion>> SuggestAsync(string orderNumberFragment, LanguageKey language)
            => Task.Run(() => Suggest(orderNumberFragment, language));
    }
}
