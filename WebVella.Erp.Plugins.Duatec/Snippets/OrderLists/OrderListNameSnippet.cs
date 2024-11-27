using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists
{
    [Snippet]
    internal class OrderListNameSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec?[OrderList.Project] is not Guid id || Project.Find(id) is not EntityRecord project)
                return null;

            return $"{project[Project.Number]} - Order List";
        }
    }
}
