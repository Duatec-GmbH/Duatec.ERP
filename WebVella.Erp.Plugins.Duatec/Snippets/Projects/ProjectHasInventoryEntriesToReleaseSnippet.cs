using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Projects
{
    [Snippet]
    internal class ProjectHasInventoryEntriesToReleaseSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            return InventoryEntriesToRelease4Project.Execute(pageModel.RecordId!.Value).Any();
        }
    }
}
