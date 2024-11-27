using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryManageAccessibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var isFromPartList = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[OrderListEntry.IsFromPartList] as bool? ?? true;
            return isFromPartList
                ? WvFieldAccess.ReadOnly
                : WvFieldAccess.Full;
        }
    }
}
