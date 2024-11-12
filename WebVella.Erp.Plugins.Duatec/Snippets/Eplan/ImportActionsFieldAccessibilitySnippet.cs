using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Eplan
{
    [Snippet]
    internal class ImportActionsFieldAccessibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec?["available_actions"] is List<SelectOption> selectOptions && selectOptions.Count > 1)
                return WvFieldAccess.Full;
            return WvFieldAccess.ReadOnly;
        }
    }
}
