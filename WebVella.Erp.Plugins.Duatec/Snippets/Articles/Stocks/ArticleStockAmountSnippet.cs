using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockAmountSnippet : ListArticleAmountSnippetBase
    {
        protected override decimal? GetAmount(EntityRecord rowRecord)
            => rowRecord[ArticleStock.Amount] as decimal?;

        protected override EntityRecord? GetArticle(EntityRecord rowRecord)
            => (rowRecord['$' + ArticleStock.Relations.Article] as List<EntityRecord>)?.FirstOrDefault();
    }
}
