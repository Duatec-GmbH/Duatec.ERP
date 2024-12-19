using WebVella.Erp.Plugins.Duatec.Persistance;
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

            return Repository.PartList.FindManyByProject(pageModel.RecordId.Value)
                .Exists(pl => pl.IsActive && Repository.PartList.EntryExistsWithinList(pl.Id!.Value));
        }
    }
}
