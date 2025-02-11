using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderListEntries4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
            public const string PartNumber = "partNumber";
            public const string TypeNumber = "typeNumber";
            public const string OrderNumber = "orderNumber";
            public const string Designation = "designation";
            public const string Manufacturer = "manufacturer";
            public const string Order = "order";
            public const string State = "state";
            public const string StateFilterType = "state_filter_type";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public OrderListEntries4Project(Guid articleId)
            : this()
        {
            ArticleId = articleId;
        }

        public OrderListEntries4Project() : base()
        {
            Id = new Guid("93e148b7-fdcd-4031-b0ad-97b92139db96");
            Name = nameof(OrderListEntries4Project);
            Description = "List of all order list entries for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Project, Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.PartNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.TypeNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.OrderNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Designation, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Order, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.State, Type = typeof(OrderListEntryState).FullName, Value = "null" });
            Parameters.Add(new() { Name = Arguments.StateFilterType, Type = typeof(FilterType).FullName, Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public Guid? ArticleId { get; }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Arguments.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var records = GetRecords(projectId.Value);

            var partNumber = arguments[Arguments.PartNumber]?.ToString();
            var typeNumber = arguments[Arguments.TypeNumber]?.ToString();
            var orderNumber = arguments[Arguments.OrderNumber]?.ToString();
            var designation = arguments[Arguments.Designation]?.ToString();
            var manufacturer = arguments[Arguments.Manufacturer]?.ToString();
            var order = arguments[Arguments.Order]?.ToString();
            var state = EnumValueFromParameter<OrderListEntryState?>(arguments[Arguments.State]);
            var stateFilterType = EnumValueFromParameter<FilterType?>(arguments[Arguments.StateFilterType]);
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];

            records = ApplyArticleFilter(partNumber, Article.Fields.PartNumber, records);
            records = ApplyArticleFilter(typeNumber, Article.Fields.TypeNumber, records);
            records = ApplyArticleFilter(orderNumber, Article.Fields.OrderNumber, records);
            records = ApplyArticleFilter(designation, Article.Fields.Designation, records);
            records = ApplyManufacturerFilter(manufacturer, records);
            records = ApplyOrderFilter(order, records);
            records = ApplyStateFilter(state, stateFilterType, records);

            var filtered = records.ToList();
            
            var result = new EntityRecordList();
            result.AddRange(filtered.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = filtered.Count;

            return result;
        }

        private static IEnumerable<OrderListEntry> ApplyArticleFilter(string? filterValue, string property, IEnumerable<OrderListEntry> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records
                .Where(r => r.GetArticle()[property].ToString()!.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<OrderListEntry> ApplyOrderFilter(string? filterValue, IEnumerable<OrderListEntry> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records.Where(r => r.GetOrders().Any(
                o => o.Number.Contains(filterValue, StringComparison.OrdinalIgnoreCase)));
        }

        private static IEnumerable<OrderListEntry> ApplyManufacturerFilter(string? filterValue, IEnumerable<OrderListEntry> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records
                .Where(r => r.GetArticle().GetManufacturer().Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<OrderListEntry> ApplyStateFilter(OrderListEntryState? filterValue, FilterType? filterType, IEnumerable<OrderListEntry> records)
        {
            if (filterValue == null)
                return records;

            if(filterType == null || filterType == FilterType.EQ)
                return records.Where(r => filterValue.Value.Equals(r.State));
            if (filterType == FilterType.NOT)
                return records.Where(r => !filterValue.Value.Equals(r.State));

            throw new NotImplementedException($"Filter type '{filterType}' not implemented");
        }

        private IEnumerable<OrderListEntry> GetRecords(Guid projectId)
        {
            var recMan = new RecordManager();

            if (new ProjectRepository(recMan).Find(projectId) is not Project project)
                return [];

            var orderRepository = new OrderRepository(recMan);

            var projectOrderEntries = orderRepository.FindManyEntriesByProject(projectId);
            var orderEntries = orderRepository.FindManyByProject(projectId)
                .ToDictionary(r => r.Id!.Value, r => r);

            var orderedAmountLookup = projectOrderEntries
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var receivedAmountLookup = new GoodsReceivingRepository(recMan).FindManyEntriesByProject(projectId)
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var ordersLookup = projectOrderEntries
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g
                    .Select(r => orderEntries.TryGetValue(r.Order, out var v) ? v : null)
                    .Where(v => v != null)
                    .ToList()!);

            var inventoryAmountLookup = new InventoryRepository(recMan).FindManyReservationEntriesByProject(projectId)
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var partListEntries = !ArticleId.HasValue
                ? new PartListRepository(recMan).FindManyEntriesByProject(projectId, true)
                : new PartListRepository(recMan).FindManyEntriesByProjectAndArticle(projectId, ArticleId.Value, true);

            var articleLookup = GetArticleLookup(recMan, partListEntries);

            return partListEntries
                .GroupBy(ple => ple.ArticleId)
                .Select(g => RecordFromGroup(g, 
                    articleLookup, ordersLookup!, 
                    orderedAmountLookup, receivedAmountLookup, inventoryAmountLookup))
                .OrderBy(r => r.GetArticle().PartNumber.ToString());
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(RecordManager recMan, List<PartListEntry> partListEntries)
        {
            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            var articleIds = partListEntries
                .Select(ple => ple.ArticleId)
                .Distinct()
                .ToArray();

            return new ArticleRepository(recMan).FindMany(select, articleIds);
        }

        private static OrderListEntry RecordFromGroup(
            IGrouping<Guid, PartListEntry> group, 
            Dictionary<Guid, Article?> articleLookup,
            Dictionary<Guid, List<Order>> ordersLookup, 
            Dictionary<Guid, decimal> orderedAmountLookup, 
            Dictionary<Guid, decimal> receivedAmountLookup, 
            Dictionary<Guid, decimal> inventoryAmountLookup)
        {

            var commons = group.First();
            var articleId = commons.ArticleId;
            var article = articleLookup[articleId];
            var demand = group.Sum(r => r.Amount);

            var orders = ordersLookup.TryGetValue(articleId, out var l) ? l : [];
            var orderedAmount = GetAmount(orderedAmountLookup, articleId);
            var receivedAmount = GetAmount(receivedAmountLookup, articleId);
            var inventoryAmount = GetAmount(inventoryAmountLookup, articleId);
            var toOrder = Math.Max(0m, demand - orderedAmount - inventoryAmount);

            var rec = new OrderListEntry()
            {
                Id = articleId,
                ArticleId = articleId,
                Demand = demand,
                OrderedAmount = orderedAmount,
                InventoryAmount = inventoryAmount,
                ToOrder = toOrder,
                ReceivedAmount = receivedAmount,
                State = GetState(demand, orderedAmount, receivedAmount, inventoryAmount),
            };

            rec.SetArticle(article!);
            rec.SetOrders(orders);

            return rec;
        }

        private static OrderListEntryState GetState(decimal demand, decimal ordered, decimal received, decimal fromInventory)
        {
            if (demand <= received + fromInventory)
                return OrderListEntryState.Complete;
            if (demand > ordered + fromInventory)
                return OrderListEntryState.ToOrder;
            return OrderListEntryState.Incomplete;
        }

        private static decimal GetAmount(Dictionary<Guid, decimal> dict, Guid key)
        {
            if (dict.TryGetValue(key, out var amount))
                return amount;
            return 0m;
        }
    }
}
