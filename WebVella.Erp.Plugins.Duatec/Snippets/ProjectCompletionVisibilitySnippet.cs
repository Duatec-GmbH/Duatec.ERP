using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    internal class ProjectCompletionVisibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            return pageModel.RecordId.HasValue
                && Project.HasReservedStocks(pageModel.RecordId.Value);
        }
    }
}
