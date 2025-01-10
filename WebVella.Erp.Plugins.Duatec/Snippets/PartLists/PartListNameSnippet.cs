using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists
{
    [Snippet]
    internal class PartListNameSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return null;

            var partList = TypedEntityRecordWrapper.Cast<PartList>(rec)!;
            var project = RepositoryService.ProjectRepository.Find(partList.Project);

            var result = $"{project?.Number} - {partList.Name}";
            if (!partList.IsActive)
                result += " (Not Active)";
            return result;
        }
    }
}
