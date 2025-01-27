using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryStateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var state = (pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")
                ?[OrderListEntries4Project.Record.Fields.State] as string)?.Trim();

            var stateAsLower = state?.ToLowerInvariant();

            if (stateAsLower == "complete")
                return State("fas fa-check go-green", state);
            if (stateAsLower == "to order")
                return State("fas fa-times go-red", state);
            if (stateAsLower == "incomming")
                return State("fas fa-question go-gray", state);

            return null;
        }

        private static string State(string image, string? value)
            => $"{value} <i class=\"{image} icon\"/>";
    }
}
