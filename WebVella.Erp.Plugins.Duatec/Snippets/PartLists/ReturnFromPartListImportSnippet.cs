using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists
{
    [Snippet]
    internal class ReturnFromPartListImportSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (pageModel.Request?.Query?.TryGetValue("lId", out var idVal) is not true)
                return null;
            var app = pageModel.ErpRequestContext.App.Name;
            return $"/{app}/part-lists/part-lists/r/{idVal}/detail";
        }
    }
}
