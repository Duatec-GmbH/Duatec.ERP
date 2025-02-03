using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Articles.Common
{
    internal static class Actions
    {
        public static void DeleteAlternatives(Guid id, ArticleRepository? repository = null)
        {
            repository ??= new ArticleRepository();

            var alternatives = repository.FindAlternativeIds(id);

            foreach (var alternative in alternatives)
                repository.DeleteAlternativeMapping(id, alternative);
        }
    }
}
