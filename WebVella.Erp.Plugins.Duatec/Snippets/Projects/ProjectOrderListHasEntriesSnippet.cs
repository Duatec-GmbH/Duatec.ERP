using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
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

            var repo = new PartListRepository();
            return repo.FindManyByProject(pageModel.RecordId.Value)
                .Exists(pl => pl.IsActive && repo.EntryExistsWithinList(pl.Id!.Value));
        }
    }
}
