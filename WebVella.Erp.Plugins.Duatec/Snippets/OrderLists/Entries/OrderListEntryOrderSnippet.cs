using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
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

            var orders = rec[$"${OrderListEntry.Relations.Order}"] as List<EntityRecord>;
            if (orders == null || orders.Count == 0)
                return string.Empty;

            var links = orders
                .OrderBy(o => o[Order.Fields.Number].ToString())
                .Select(o => AnchorTag(o, pageModel));

            return string.Join(", ", links);
        }

        private static string AnchorTag(EntityRecord record, BaseErpPageModel pageModel)
            => $"<a href=\"{Url(record, pageModel)}\">{record[Order.Fields.Number]}</a>";

        private static string Url(EntityRecord record, BaseErpPageModel pageModel)
        {
            var currentUrlEncoded = $"{pageModel.DataModel.GetProperty("CurrentUrlEncoded")}";
            return $"/order-management/orders/orders/r/{record["id"]}/detail?returnUrl={currentUrlEncoded}";
        }
    }
}
