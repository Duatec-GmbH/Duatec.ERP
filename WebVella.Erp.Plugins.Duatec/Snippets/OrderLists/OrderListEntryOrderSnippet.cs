﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists
{
    [Snippet]
    internal class OrderListEntryOrderSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            // TODO

            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            if (rec == null)
                return null;

            var listId = (Guid)rec[OrderListEntry.OrderList];
            var projectId = (Guid)OrderList.Find(listId)![OrderList.Project];
            var articleId = (Guid)rec[OrderEntry.Article];

            var orders = Order.FindManyByProjectAndArticle(projectId, articleId);
            if (orders.Count == 0)
                return string.Empty;

            return string.Join("<br/>", orders.Select(o => o[Order.Number]));
        }
    }
}
