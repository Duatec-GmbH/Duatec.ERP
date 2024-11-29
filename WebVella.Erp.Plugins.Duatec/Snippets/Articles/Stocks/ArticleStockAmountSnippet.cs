using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockAmountSnippet : ArticleAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, ArticleStock.Amount) as decimal?;

        protected override EntityRecord? GetArticle(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, $"${ArticleStock.Relations.Article}[0]") as EntityRecord;

        protected override EntityRecord? GetArticleType(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, $"${ArticleStock.Relations.Article}[0].${Article.Relations.Type}[0]") as EntityRecord;
    }
}
