using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists.Entries
{
    [Snippet]
    internal class ArticleListImageSnippet : Articles.ArticleListImageSnippet
    {
        protected override string? Url(BaseErpPageModel pageModel)
        {
            return (pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[$"${PartListEntry.Relations.Article}"] 
                as List<EntityRecord>)?.FirstOrDefault()?[Article.Image] as string;
        }
    }
}
