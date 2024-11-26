using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists
{
    [Snippet]
    internal class PartListImportSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => $"/{pageModel.ErpRequestContext.App.Name}/a/part-list-import?lId={pageModel.RecordId}";
    }
}
