using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailProjectSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var projectId = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[ArticleStock.Project] as Guid?;
            if (!projectId.HasValue || Project.Find(projectId.Value) is not EntityRecord project)
                return null;

            return $"{project[Project.Number]} - {project[Project.Name]}";
        }
    }
}
