using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class ArticleDetailImageSnippet : Articles.ArticleDetailImageSnippet
    {
        protected override string? Url(BaseErpPageModel pageModel)
        {
            var articleId = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[OrderListEntry.Article] as Guid?;
            if (!articleId.HasValue)
                return null;

            return Article.Find(articleId.Value)?[Article.Image] as string;
        }
    }
}
