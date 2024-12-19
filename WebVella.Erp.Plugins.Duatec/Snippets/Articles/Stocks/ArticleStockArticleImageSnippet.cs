using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockArticleImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 200;

        protected override int? Width => 200;

        protected override string? Url(BaseErpPageModel pageModel)
        {
            var articleId = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?
                [InventoryEntry.Fields.Article] as Guid?;

            if(!articleId.HasValue || Repository.Article.Find(articleId.Value)?.Image is not string url)
                return null;

            return url;
        }
    }
}
