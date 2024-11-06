using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockArticleDesignationSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var articleId = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[ArticleStock.Article] as Guid?;
            if (!articleId.HasValue || Article.Find(articleId.Value) is not EntityRecord article)
                return null;

            return $"{article[Article.PartNumber]} - {article[Article.Designation]}";
        }
    }
}
