using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Orders
{
    [Snippet]
    internal class OrderEntryModifiableDateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec == null || !rec.Properties.TryGetValue(OrderEntry.Fields.ExpectedArrival, out var dtObj))
                return null;

            if (dtObj is DateTime dt)
                return dt.ToSimpleDateString();

            return dtObj;
        }
    }
}
