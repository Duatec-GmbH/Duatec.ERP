using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists
{
    [Snippet]
    internal class ReturnToProjectSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var id = GetProjectId(pageModel);
            return $"/{pageModel.ErpRequestContext.App?.Name}/projects/projects/r/{id}";
        }

        private static string? GetProjectId(BaseErpPageModel pageModel)
        {
            var query = pageModel.Request?.Query;

            if (query != null && query.TryGetValue("pId", out var projectIdVal))
                return projectIdVal;
            return null;
        }
    }
}
