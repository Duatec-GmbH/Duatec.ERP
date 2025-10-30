using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders.Implementations
{
    internal class IgusArticleFinder : ArticleFinder
    {
        public override SearchResult GetArticle(string orderNumber, LanguageKey language, List<ArticleType> types)
        {
            throw new NotImplementedException();
        }

        public override void Initialize(JsonNode? settings)
        {
            throw new NotImplementedException();
        }

        public override List<ArticleSuggestion> Suggest(string orderNumberFragment, LanguageKey language, int resultCount)
        {
            throw new NotImplementedException();
        }
    }
}
