using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockArticleDesignationSnippet : SnippetBase
    {
        private static readonly ArticleRepository _repo = new();

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var articleId = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")
                ?[InventoryEntry.Fields.Article] as Guid?;

            if (!articleId.HasValue || _repo.Find(articleId.Value) is not Article article)
                return null;

            return $"{article.PartNumber} - {article.Designation}";
        }
    }
}
