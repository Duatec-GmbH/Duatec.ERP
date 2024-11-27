using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists
{
    [Snippet]
    internal class ReturnToOrderListSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var listId = GetListId(pageModel);

            var context = pageModel.ErpRequestContext;
            return $"/{context?.App?.Name}/{context?.SitemapArea?.Name}/order-lists/r/{listId}";
        }

        private static Guid? GetListId(BaseErpPageModel pageModel)
        {
            Guid? id = null;
            if (Try.Get(() => pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[OrderListEntry.OrderList] as Guid?, out var recId))
                id = recId;

            id ??= pageModel.Request.Query.TryGetValue("olId", out var idArg) && Guid.TryParse(idArg, out var listId)
                ? listId : null;
            return id;
        }
    }
}
