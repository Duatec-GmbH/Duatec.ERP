using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OpenOrders : CodeDataSource
    {
        public static class Arguments
        {
            public const string OrderNumber = "orderNumber";
            public const string ProjectNumber = "projectNumber";
            public const string ProjectName = "projectName";
            public const string Project = "project";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public OpenOrders() : base()
        {
            Id = new Guid("4e02017e-156f-4f22-b3d2-f979c6a052e6");
            Description = "Open orders";
            Name = nameof(OpenOrders);
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.OrderNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.ProjectNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.ProjectName, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Project, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });            
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
            
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];
            if (pageSize <= 0)
            {
                pageSize = int.MaxValue;
                page = 1;
            }

            var recMan = new RecordManager();
            var orderRepo = new OrderRepository(recMan);
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);

            var openOrders = GetOpenOrders(orderRepo, goodsReceivingRepo);

            if (openOrders.Count == 0)
                return new EntityRecordList();

            var orderSelect = $"*, ${Order.Relations.Project}.*";
            var orders = orderRepo.FindMany(orderSelect, openOrders.ToArray()).Values
                .Where(o => o != null);

            var allOrders = ApplyFilters(arguments, orders!)
                .ToList();

            var result = new EntityRecordList();
            result.AddRange(allOrders.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = allOrders.Count;

            return result;
        }

        private static List<Guid> GetOpenOrders(OrderRepository orderRepo, GoodsReceivingRepository goodsReceivingRepo)
        {
            var orderEntries = orderRepo.FindAllEntries()
                .GroupBy(e => e.Order)
                .ToDictionary(g => g.Key, g => g.ToList());

            if (orderEntries.Count == 0)
                return [];

            var receivedSelect = $"*, ${GoodsReceivingEntry.Relations.GoodsReceiving}.{GoodsReceiving.Fields.Order}";
            var receivedEntries = goodsReceivingRepo.FindManyEntriesByOrders(receivedSelect, orderEntries.Keys.ToArray())
                .GroupBy(e => e.GetGoodsReceiving().Order)
                .ToDictionary(g => g.Key, g => g.ToList());


            var openOrders = new List<Guid>(256);

            foreach (var (orderId, entries) in orderEntries)
            {
                if (!receivedEntries.TryGetValue(orderId, out var received))
                    openOrders.Add(orderId);
                else
                {
                    var receivedLookup = received
                        .GroupBy(re => re.Article)
                        .ToDictionary(g => g.Key, g => g.Sum(re => re.Amount));

                    if (entries.Exists(e => e.Amount > 0 && (!receivedLookup.TryGetValue(e.Article, out var d) || e.Amount > d)))
                        openOrders.Add(orderId);
                }
            }

            return openOrders;
        }

        private static IEnumerable<Order> ApplyFilters(Dictionary<string, object> arguments, IEnumerable<Order> orders)
        {
            var orderNumber = arguments[Arguments.OrderNumber] as string;
            var projectNumber = arguments[Arguments.ProjectNumber] as string;
            var projectName = arguments[Arguments.ProjectName] as string;
            var project = arguments[Arguments.Project] as string;

            const StringComparison comparison = StringComparison.OrdinalIgnoreCase;

            if (!string.IsNullOrWhiteSpace(orderNumber))
                orders = orders.Where(o => o.Number.Contains(orderNumber, comparison));

            if (!string.IsNullOrWhiteSpace(projectNumber))
                orders = orders.Where(o => o.GetProject()?.Number.Contains(projectNumber, comparison) is true);

            if (!string.IsNullOrWhiteSpace(projectName))
                orders = orders.Where(o => o.GetProject()?.Name.Contains(projectName, comparison) is true);

            if(!string.IsNullOrWhiteSpace(project))
            {
                orders = orders.Where(o =>
                {
                    var p = o.GetProject();
                    if (p != null)
                    {
                        return p.Name.Contains(project, comparison)
                            || p.Number.Contains(project, comparison);
                    }
                    return false;
                });
            }

            return orders.OrderByDescending(o => o.GetProject()?.Number)
                .ThenBy(o => o.Number);
        }
    }
}
