using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    public class OrderListEntries4Project : CodeDataSource
    {
        public static class Arguments
        {
            public const string Project = "project";
            public const string Article = "article";
            public const string Manufacturer = "manufacturer";
            public const string Order = "order";
            public const string State = "state";
            public const string StateFilterType = "state_filter_type";
            public const string Page = "page";
            public const string PageSize = "pageSize";
            public const string OrderType = "order_type";
            public const string OrderTypeFilterType = "order_type_filter_type";
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
            Parameters.Add(new() { Name = Arguments.Article, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Order, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.State, Type = typeof(OrderListEntryState).FullName, Value = "null" });
            Parameters.Add(new() { Name = Arguments.StateFilterType, Type = typeof(FilterType).FullName, Value = "null" });
            Parameters.Add(new() { Name = Arguments.OrderType, Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.OrderTypeFilterType, Type = typeof(FilterType).FullName, Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public Guid? ArticleId { get; }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Arguments.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var records = GetRecords(projectId.Value, ArticleId);

            var article = arguments[Arguments.Article]?.ToString();
            var manufacturer = arguments[Arguments.Manufacturer]?.ToString();
            var order = arguments[Arguments.Order]?.ToString();
            var state = EnumValueFromParameter<OrderListEntryState?>(arguments[Arguments.State]);
            var stateFilterType = EnumValueFromParameter<FilterType?>(arguments[Arguments.StateFilterType]);
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];
            var orderListType = arguments.TryGetValue(Arguments.OrderType, out var obj) ? obj as Guid? : null;
            var orderListTypeFilterType = EnumValueFromParameter<FilterType?>(arguments[Arguments.OrderTypeFilterType]);

            records = ApplyArticleFilter(article, records);
            records = ApplyManufacturerFilter(manufacturer, records);
            records = ApplyOrderFilter(order, records);
            records = ApplyOrderTypeFilter(orderListType, orderListTypeFilterType, records);
            records = ApplyStateFilter(state, stateFilterType, records);


            var filtered = records.ToList();
            var result = new EntityRecordList();

            if (pageSize <= 0)
            {
                pageSize = filtered.Count;
                page = 1;
            }
            result.AddRange(filtered.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = filtered.Count;

            return result;
        }

        public static IEnumerable<OrderListEntry> Execute(Guid projectId)
        {
            if (projectId == Guid.Empty)
                return [];

            return GetRecords(projectId);
        }

        private static IEnumerable<OrderListEntry> ApplyOrderTypeFilter(Guid? type, FilterType? filterType, IEnumerable<OrderListEntry> records)
        {
            if (!type.HasValue)
                return records;

            var ft = filterType.HasValue ? filterType : FilterType.EQ;

            if(type == Guid.Empty)
            {
                if (ft == FilterType.NOT)
                    return records.Where(ole => !ole.GetOrders().Any(o => o.Type == Guid.Empty || o.Type == null));
                else
                    return records.Where(ole => ole.GetOrders().Any(o => o.Type == Guid.Empty || o.Type == null));
            }
            else
            {
                if (ft == FilterType.NOT)
                    return records.Where(ole => !ole.GetOrders().Any(o => o.Type == type));
                else
                    return records.Where(ole => ole.GetOrders().Any(o => o.Type == type));
            }
        }

        private static IEnumerable<OrderListEntry> ApplyArticleFilter(string? filterValue, IEnumerable<OrderListEntry> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            var comp = StringComparison.OrdinalIgnoreCase;

            return records
                .Where(r =>
                {
                    var article = r.GetArticle();
                    return article.PartNumber.Contains(filterValue, comp)
                        || article.OrderNumber.Contains(filterValue, comp)
                        || article.TypeNumber.Contains(filterValue, comp)
                        || article.Designation.Contains(filterValue, comp);
                });
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

        private static IEnumerable<OrderListEntry> GetRecords(Guid projectId, Guid? articleId = null)
        {
            var recMan = new RecordManager();

            var orderRepository = new OrderRepository(recMan);
            var inventoryRepo = new InventoryRepository(recMan);
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);
            var project = new ProjectRepository(recMan).Find(projectId);
            var isInventoryProject = project?.IsInventoryProject ?? false;
            var reserveStoredArticles = project?.ReserveStoredArticles ?? true;

            var orderEntries = orderRepository.FindManyEntriesByProject(projectId);
            var orderLookup = orderRepository.FindManyByProject(projectId)
                .ToDictionary(r => r.Id!.Value, r => r);

            var orderedAmountLookup = orderEntries
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount * (r.Denomination == 0 ? 1 : r.Denomination)));

            var receivedAmountLookup = goodsReceivingRepo.FindManyEntriesByProject(projectId)
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount * (r.Denomination == 0 ? 1 : r.Denomination)));

            var ordersLookup = orderEntries
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g
                    .Select(r => orderLookup.TryGetValue(r.Order, out var v) ? v : null)
                    .Where(o => o?.Id != null && o.Id != Guid.Empty)
                    .DistinctBy(o => o!.Id)
                    .ToList()!);

            var inventoryAmountLookup = inventoryRepo.GetReservedArticleAmountLookup(projectId)
                .GroupBy(ie => ie.Key.ArticleId)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Value * (r.Key.Denomination == 0 ? 1 : r.Key.Denomination)));

            var entriesFromPartList = (!articleId.HasValue
                ? new PartListRepository(recMan).FindManyEntriesByProject(projectId, true)
                : new PartListRepository(recMan).FindManyEntriesByProjectAndArticle(projectId, articleId.Value, true))
                .GroupBy(ple => ple.ArticleId)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount * (r.Denomination == 0 ? 1 : r.Denomination)));

            var articleIds = orderEntries.Select(oe => oe.Article)
                .Concat(inventoryAmountLookup.Keys)
                .Concat(entriesFromPartList.Keys)
                .Distinct()
                .ToArray();

            var articleLookup = GetArticleLookup(recMan, articleIds);

            var entriesFromOrder = orderedAmountLookup
                .Where(kp => !entriesFromPartList.ContainsKey(kp.Key));

            var entriesFromInventory = inventoryAmountLookup
                .Where(kp => !orderedAmountLookup.ContainsKey(kp.Key) && !entriesFromPartList.ContainsKey(kp.Key));

            return entriesFromPartList
                .Concat(entriesFromOrder)
                .Concat(entriesFromInventory)
                .Select(kp => BuildOrderEntry(
                    kp.Key, entriesFromPartList.TryGetValue(kp.Key, out var demand) ? demand : 0m, 
                    articleLookup, ordersLookup!, orderedAmountLookup, receivedAmountLookup, inventoryAmountLookup, 
                    isInventoryProject, reserveStoredArticles))
                .OrderBy(r => r.GetArticle().PartNumber.ToString());
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(RecordManager recMan, Guid[] articleIds)
        {
            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            return new ArticleRepository(recMan).FindMany(select, articleIds);
        }

        private static OrderListEntry BuildOrderEntry(
            Guid articleId, decimal demand,
            Dictionary<Guid, Article?> articleLookup,
            Dictionary<Guid, List<Order>> ordersLookup, 
            Dictionary<Guid, decimal> orderedAmountLookup, 
            Dictionary<Guid, decimal> receivedAmountLookup, 
            Dictionary<Guid, decimal> inventoryAmountLookup,
            bool isInventoryProject,
            bool reserveStoredArticles)
        {

            var article = articleLookup[articleId];
            var orders = ordersLookup.TryGetValue(articleId, out var l) ? l : [];
            var orderedAmount = GetAmount(orderedAmountLookup, articleId);
            var receivedAmount = GetAmount(receivedAmountLookup, articleId);
            var fromInventory = GetAmount(inventoryAmountLookup, articleId);
            var type = article?.GetArticleType();
            var isDivisible = type?.IsDivisible is true;

            var toOrder = (isInventoryProject && reserveStoredArticles) 
                ? Math.Max(0m, demand - orderedAmount - Math.Max(0m, fromInventory - receivedAmount)) 
                : Math.Max(0m, demand - orderedAmount - fromInventory);

            var rec = new OrderListEntry()
            {
                Id = articleId,
                ArticleId = articleId,
                Denomination = isDivisible ? toOrder : 0m,
                Demand = demand,
                OrderedAmount = orderedAmount,
                InventoryAmount = fromInventory,
                ToOrder = isDivisible ? 1m : toOrder,
                ReceivedAmount = receivedAmount,
                State = GetState(demand, orderedAmount, receivedAmount, fromInventory, isInventoryProject, reserveStoredArticles),
            };

            rec.SetArticle(article);
            rec.SetOrders(orders);

            return rec;
        }

        private static OrderListEntryState GetState(decimal demand, decimal ordered, decimal received, decimal fromInventory, bool isInventoryProject, bool reserveStoredArticles)
        {
            if (isInventoryProject && reserveStoredArticles)
                fromInventory -= received;

            if (Math.Max(ordered, received) + fromInventory > demand)
                return OrderListEntryState.Abundance;

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
