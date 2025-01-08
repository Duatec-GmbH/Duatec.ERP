using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
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

            var orders = rec[$"${OrderListEntries4Project.Record.Relations.Order}"] as List<EntityRecord>;
            if (orders == null || orders.Count == 0)
                return string.Empty;

            return string.Join(", ", orders.Select(o => o[Order.Fields.Number].ToString()).Order());
        }
    }
}
