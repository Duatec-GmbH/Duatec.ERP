using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailUnitSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            return GetUnit(rec) ?? string.Empty;
        }

        private static string? GetUnit(EntityRecord? rec)
        {
            if (rec?[ArticleStock.Article] is not Guid articleId)
                return null;
            return ArticleType.FromArticle(articleId)?[ArticleType.Unit]?.ToString();
        }
    }
}
