using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Projects
{
    [Snippet]
    internal class CreatePartListSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return null;

            return $"/{pageModel.ErpRequestContext?.App?.Name}/part-lists/part-lists/c/create?pId={pageModel.RecordId}";
        }
    }
}
