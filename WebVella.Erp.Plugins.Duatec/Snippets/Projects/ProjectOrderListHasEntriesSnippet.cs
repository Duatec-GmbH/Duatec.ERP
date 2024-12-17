using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Projects
{
    [Snippet]
    internal class ProjectOrderListHasEntriesSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return false;

            return PartList.FindMany(pageModel.RecordId.Value)
                .Exists(pl => (bool)pl[PartList.IsActive] && PartListEntry.Exists((Guid)pl["id"]));
        }
    }
}
