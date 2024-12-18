using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockAmountSnippet : ArticleAmountSnippetBase
    {
        private const string articlePath = $"${InventoryEntry.Relations.Article}[0]";
        private const string articleTypePath = $"{articlePath}.${Article.Relations.Type}[0]";

        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, InventoryEntry.Fields.Amount) as decimal?;

        protected override Article? GetArticle(BaseErpPageModel pageModel)
            => Article.Create(GetDataSourcePropertyFromRecord(pageModel, articlePath) as EntityRecord);

        protected override ArticleType? GetArticleType(BaseErpPageModel pageModel)
            => ArticleType.Create(GetDataSourcePropertyFromRecord(pageModel, articleTypePath) as EntityRecord);
    }
}
