using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailAmountSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            var amount = rec?[ArticleStock.Amount] as decimal?;
            var type = GetArticleType(rec);
            var unit = type?[ArticleType.Unit];

            // TODO get decimal places and format amount
            return $"{amount} {unit}";
        }

        private static EntityRecord? GetArticleType(EntityRecord? rec)
        {
            if (rec?[ArticleStock.Article] is not Guid articleId)
                return null;

            var article = Article.Find(articleId);
            if (article?[Article.Type] is not Guid typeId)
                return null;

            return ArticleType.Find(typeId);
        }
    }
}
