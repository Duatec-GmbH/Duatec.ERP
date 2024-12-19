using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks
{
    [Snippet]
    internal class ArticleStockDetailProjectSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var projectId = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?
                [InventoryEntry.Fields.Project] as Guid?;

            if (!projectId.HasValue || Repository.Project.Find(projectId.Value) is not Project project)
                return null;

            return $"{project.Number} - {project.Name}";
        }
    }
}
