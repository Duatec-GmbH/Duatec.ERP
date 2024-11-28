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
            => Record(pageModel)?[ArticleStock.Amount] as decimal?;

        protected override EntityRecord? GetArticle(BaseErpPageModel pageModel)
            => (Record(pageModel)?['$' + ArticleStock.Relations.Article] as List<EntityRecord>)?.FirstOrDefault();

        private static EntityRecord? Record(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
    }
}
