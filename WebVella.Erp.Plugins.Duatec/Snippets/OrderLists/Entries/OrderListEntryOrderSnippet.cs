using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryOrderSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec == null)
                return string.Empty;

            var orders = (List<EntityRecord>)rec[$"${OrderListEntry.Relations.Order}"];
            if (orders == null || orders.Count == 0)
                return string.Empty;

            return string.Join(", ", orders.Select(o => o[Order.Number].ToString()).Order());
        }
    }
}
