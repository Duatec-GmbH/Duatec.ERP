using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Orders
{
    [Snippet]
    internal class OrderConfirmationFilesSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return new List<dynamic>();

            if (rec.Properties.TryGetValue("confirmations", out var list))
                return list;

            var order = TypedEntityRecordWrapper.WrapElseDefault<Order>(rec);
            var result = new List<dynamic>();
            if (order == null)
                return result;

            foreach(var c in order.GetConfirmations())
                result.Add(c);
            
            return result;
        }
    }
}
