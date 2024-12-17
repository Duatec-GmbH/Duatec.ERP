using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Projects
{
    [Snippet]
    internal class InventoryListNameSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            object? number;
            if(pageModel.TryGetDataSourceProperty<Entity>("Entity") is Entity entity && entity.Name == Project.Entity)
            {
                number = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[Project.Number];
            }
            else
            {
                var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
                if (rec == null)
                    return null;

                number = Project.Find((Guid)rec[ArticleStockReservation.Project])?[Project.Number];
            }

            return Result(number);
        }

        private static string Result(object? projectNumber)
            => $"{projectNumber} - Inventory List";
    }
}
