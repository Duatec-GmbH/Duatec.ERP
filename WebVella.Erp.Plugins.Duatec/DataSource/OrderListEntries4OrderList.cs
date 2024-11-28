using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderListEntries4OrderList : CodeDataSource
    {
        public OrderListEntries4OrderList() : base()
        {
            Id = new Guid("93e148b7-fdcd-4031-b0ad-97b92139db96");
            Name = nameof(OrderListEntries4OrderList);
            Description = "List of all order list entries for given order list";
            ResultModel = "EntityRecordList";

            Parameters.Add(new() { Name = "orderListId", Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = "partNumber", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "typeNumber", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "orderNumber", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "designation", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "manufacturer", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "order", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "state", Type = "text", Value = "null" });
            Parameters.Add(new() { Name = "page", Type = "int", Value = "1" });
            Parameters.Add(new() { Name = "pageSize", Type = "int", Value = "10" });
        }


        public override object Execute(Dictionary<string, object> arguments)
        {
            var orderListId = arguments["orderListId"] as Guid?;
            var partNumber = arguments["partNumber"]?.ToString();
            var typeNumber = arguments["typeNumber"]?.ToString();
            var orderNumber = arguments["orderNumber"]?.ToString();
            var designation = arguments["designation"]?.ToString();
            var manufacturer = arguments["manufacturer"]?.ToString();
            var order = arguments["order"]?.ToString();
            var state = arguments["state"]?.ToString();
            var page = (int)arguments["page"];
            var pageSize = (int)arguments["pageSize"];

            var query =
@"SELECT *, 
    $order_list_entry_article.*, 
    $order_list_entry_article.$article_article_type.*, 
    $order_list_entry_article.$article_manufacturer.name, 
    $order_list_entry_order_list.*
FROM order_list_entry
WHERE order_list_id = @orderListId
    AND (@partNumber = null OR $order_list_entry_article.part_number ~* @partNumber)
    AND (@typeNumber = null OR $order_list_entry_article.type_number ~* @typeNumber)
    AND (@orderNumber = null OR $order_list_entry_article.order_number ~* @orderNumber)
    AND (@designation = null OR $order_list_entry_article.designation ~* @designation)
    AND (@manufacturer = null OR $order_list_entry_article.$article_manufacturer.name ~* @manufacturer)
ORDER BY $order_list_entry_article.part_number";


            var command = new EqlCommand(query,
                new EqlParameter("orderListId", orderListId),
                new EqlParameter("partNumber", partNumber),
                new EqlParameter("typeNumber", typeNumber),
                new EqlParameter("orderNumber", orderNumber),
                new EqlParameter("designation", designation),
                new EqlParameter("manufacturer", manufacturer));

            var queryResult = command.Execute();
            if (queryResult.Count == 0)
                return queryResult;

            var projectId = GetProjectId(queryResult[0]);

            var projectOrderEntries = OrderEntry.FindManyByProject(projectId);
            var orderEntries = Order.FindManyByProject(projectId)
                .ToDictionary(r => (Guid)r["id"], r => r);

            var orderedAmountLookup = projectOrderEntries
                .GroupBy(r => (Guid)r[OrderEntry.Article])
                .ToDictionary(g => g.Key, g => g.Sum(r => (decimal)r[OrderEntry.Amount]));

            var receivedAmountLookup = GoodsReceivingEntry.FindManyByProject(projectId)
                .GroupBy(r => (Guid)r[GoodsReceivingEntry.Article])
                .ToDictionary(g => g.Key, g => g.Sum(r => (decimal)r[GoodsReceivingEntry.Amount]));

            var ordersLookup = projectOrderEntries
                .GroupBy(r => (Guid)r[OrderEntry.Article])
                .ToDictionary(g => g.Key, g => g.Select(r => orderEntries[(Guid)r[OrderEntry.Order]]).ToList());


            foreach (var rec in queryResult)
            {
                SetState(rec, orderedAmountLookup, receivedAmountLookup);
                SetOrders(rec, ordersLookup);
            }

            List<EntityRecord> filtered = queryResult;

            if (!string.IsNullOrEmpty(state))
            {
                filtered = filtered
                    .Where(r => ((string)r["state"]).Contains(state, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(order))
            {
                filtered = filtered
                    .Where(r => ((string)r["order"]).Contains(order, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            
            var result = new EntityRecordList();
            result.AddRange(filtered.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = filtered.Count;

            return result;
        }

        private static void SetOrders(EntityRecord rec, Dictionary<Guid, List<EntityRecord>> ordersLookup)
        {
            var article = (Guid)rec[OrderListEntry.Article];
            if (!ordersLookup.TryGetValue(article, out var orders))
                rec["order"] = string.Empty;
            else
                rec["order"] = string.Join("<br/>", orders.Select(r => r[Order.Number]));
        }

        private static void SetState(EntityRecord rec, Dictionary<Guid, decimal> orderedAmountLookup, Dictionary<Guid, decimal> receivedAmountLookup)
        {
            var article = (Guid)rec[OrderListEntry.Article];

            var orderedAmount = GetAmount(orderedAmountLookup, article);
            string state;

            if (orderedAmount == 0m)
                state = "Not ordered";
            else
            {
                var demand = (decimal)rec[OrderListEntry.Amount];
                var receivedAmount = GetAmount(receivedAmountLookup, article);

                if (receivedAmount >= demand)
                    state = "Complete";
                else  
                {
                    var type = GetType(rec);
                    var isInt = (bool)type[ArticleType.IsInteger];
                    var unit = type[ArticleType.Unit]?.ToString();

                    state = $"Ordered: {FormatAmount(orderedAmount, isInt, unit)}<br/>" +
                        $"Received: {FormatAmount(receivedAmount, isInt, unit)}";
                }
            }
            rec["state"] = state;
        }

        private static Guid GetProjectId(EntityRecord rec)
            => (Guid)((List<EntityRecord>)rec[$"${OrderListEntry.Relations.OrderList}"])[0][OrderList.Project];

        private static EntityRecord GetType(EntityRecord rec)
        {
            var article = ((List<EntityRecord>)rec[$"${OrderListEntry.Relations.Article}"])[0];
            var type = ((List<EntityRecord>)article[$"${Article.Relations.Type}"])[0];
            return type;
        }

        private static decimal GetAmount(Dictionary<Guid, decimal> dict, Guid key)
        {
            if (dict.TryGetValue(key, out var amount))
                return amount;
            return 0m;
        }

        private static string FormatAmount(decimal amount, bool isInt, string? unit)
        {
            return isInt ? $"{amount:0} {unit}"
                : $"{amount:0.00} {unit}";
        }
    }
}
