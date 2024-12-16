using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
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

            var project = Project.Find((Guid)rec[PartList.Project]);
            return $"{project?[Project.Number]} - {rec[PartList.Name]}";
        }
    }
}
