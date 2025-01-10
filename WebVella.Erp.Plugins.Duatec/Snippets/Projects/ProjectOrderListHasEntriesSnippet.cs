using WebVella.Erp.Plugins.Duatec.Services;
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

            return RepositoryService.PartListRepository.FindManyByProject(pageModel.RecordId.Value)
                .Exists(pl => pl.IsActive && RepositoryService.PartListRepository.EntryExistsWithinList(pl.Id!.Value));
        }
    }
}
