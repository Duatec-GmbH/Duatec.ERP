using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists
{
    [Snippet]
    internal class BackToProjectSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return null;

            var project = (Guid)rec[PartList.Project];
            return $"{pageModel.ErpRequestContext.App.Name}/projects/projects/r/{project}/";
        }
    }
}
