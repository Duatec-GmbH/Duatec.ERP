using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
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

            records = ApplyArticleFilter(article, records);
            records = ApplyManufacturerFilter(manufacturer, records);
            records = ApplyOrderFilter(order, records);
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
                .GroupBy(r => (r.Article, r.Denomination))
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var receivedAmountLookup = goodsReceivingRepo.FindManyEntriesByProject(projectId)
                .GroupBy(r => (r.Article, r.Denomination))
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var ordersLookup = orderEntries
                .GroupBy(r => (r.Article, r.Denomination))
                .ToDictionary(g => g.Key, g => g
                    .Select(r => orderLookup.TryGetValue(r.Order, out var v) ? v : null)
                    .Where(v => v != null)
                    .ToList()!);

            var inventoryAmountLookup = inventoryRepo.GetReservedArticleAmountLookup(projectId);

            var entriesFromPartList = (!articleId.HasValue
                ? new PartListRepository(recMan).FindManyEntriesByProject(projectId, true)
                : new PartListRepository(recMan).FindManyEntriesByProjectAndArticle(projectId, articleId.Value, true))
                .GroupBy(ple => (ple.ArticleId, ple.Denomination))
                .ToDictionary(g => g.Key, g => g.Sum(ple => ple.Amount));

            var articleIds = orderEntries.Select(oe => oe.Article)
                .Concat(inventoryAmountLookup.Keys.Select(kp => kp.ArticleId))
                .Concat(entriesFromPartList.Keys.Select(kp => kp.ArticleId))
                .Distinct()
                .ToArray();

            var articleLookup = GetArticleLookup(recMan, articleIds);

            var entriesFromOrder = orderedAmountLookup
                .Where(kp => !entriesFromPartList.ContainsKey(kp.Key))
                .Select(kp => new KeyValuePair<(Guid ArticleId, decimal Denomination), decimal>(kp.Key, 0m));

            var entriesFromInventory = inventoryAmountLookup
                .Where(kp => !orderedAmountLookup.ContainsKey(kp.Key) && !entriesFromPartList.ContainsKey(kp.Key))
                .Select(kp => new KeyValuePair<(Guid ArticleId, decimal Denomination), decimal>(kp.Key, 0m));

            return entriesFromPartList
                .Concat(entriesFromOrder)
                .Concat(entriesFromInventory)
                .Select(kp => BuildOrderEntry(
                    kp.Key, kp.Value, 
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
            (Guid ArticleId, decimal Denomination) key, decimal demand,
            Dictionary<Guid, Article?> articleLookup,
            Dictionary<(Guid ArticleId, decimal Denomination), List<Order>> ordersLookup, 
            Dictionary<(Guid ArticleId, decimal Denomination), decimal> orderedAmountLookup, 
            Dictionary<(Guid ArticleId, decimal Denomination), decimal> receivedAmountLookup, 
            Dictionary<(Guid ArticleId, decimal Denomination), decimal> inventoryAmountLookup,
            bool isInventoryProject,
            bool reserveStoredArticles)
        {

            var article = articleLookup[key.ArticleId];
            var orders = ordersLookup.TryGetValue(key, out var l) ? l : [];
            var orderedAmount = GetAmount(orderedAmountLookup, key);
            var receivedAmount = GetAmount(receivedAmountLookup, key);
            var fromInventory = GetAmount(inventoryAmountLookup, key);

            var toOrder = (isInventoryProject && reserveStoredArticles) 
                ? Math.Max(0m, demand - orderedAmount - Math.Max(0m, fromInventory - receivedAmount)) 
                : Math.Max(0m, demand - orderedAmount - fromInventory);

            var rec = new OrderListEntry()
            {
                Id = key.ArticleId,
                ArticleId = key.ArticleId,
                Denomination = key.Denomination,
                Demand = demand,
                OrderedAmount = orderedAmount,
                InventoryAmount = fromInventory,
                ToOrder = toOrder,
                ReceivedAmount = receivedAmount,
                State = GetState(demand, orderedAmount, receivedAmount, fromInventory, isInventoryProject, reserveStoredArticles),
            };

            rec.SetArticle(article);
            rec.SetOrders(orders);

            return rec;
        }

        private static OrderListEntryState GetState(decimal demand, decimal ordered, decimal received, decimal fromInventory, bool isInventoryProject, bool reserveStoredArticles)
        {
            if (fromInventory < 0)
                return OrderListEntryState.Error;

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

        private static decimal GetAmount(Dictionary<(Guid ArticleId, decimal Denomination), decimal> dict, (Guid ArticleId, decimal Denomination) key)
        {
            if (dict.TryGetValue(key, out var amount))
                return amount;
            return 0m;
        }
    }
}
