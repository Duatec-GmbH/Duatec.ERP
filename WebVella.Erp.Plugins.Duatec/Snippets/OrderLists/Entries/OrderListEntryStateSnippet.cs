using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryStateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var state = (pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")
                ?[OrderListEntry.Fields.State]?.ToString())?.Trim();

            var stateAsLower = state?.ToLowerInvariant();
            if (string.IsNullOrEmpty(stateAsLower))
                return string.Empty;

            return GetState(stateAsLower);
        }

        private static string GetState(string state)
        {
            var comparison = StringComparison.OrdinalIgnoreCase;
            OrderListEntryState typedState;
            string imgClass;

            if (state == "complete" || state.Equals(OrderListEntryState.Complete.ToString(), comparison))
            {
                typedState = OrderListEntryState.Complete;
                imgClass = "fas fa-check go-green";
            }
            else if (state == "to order" || state.Equals(OrderListEntryState.ToOrder.ToString(), comparison))
            {
                typedState = OrderListEntryState.ToOrder;
                imgClass = "fas fa-times go-red";
            }
            else if (state == "incomming" || state.Equals(OrderListEntryState.Incomplete.ToString(), comparison))
            {
                typedState = OrderListEntryState.Incomplete;
                imgClass = "fas fa-question go-gray";
            }
            else return string.Empty;

            var stateValue = Text.FancyfyPascalCase(typedState.ToString()).FirstToUpper();

            return $"{stateValue} <i class=\"{imgClass} icon\"/>";
        }
    }
}
