using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.TypedRecords;

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
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public static class Record
        {
            public static class Relations
            {
                public const string Project = "order_list_entry_project";
                public const string Article = "order_list_entry_article";
                public const string Order = "order_list_entry_order";
            }

            public static class Fields
            {
                public const string Project = "project_id";
                public const string Article = Persistance.Entities.Article.AsForeignKey;
                public const string Demand = "demand";
                public const string OrderedAmount = "ordered_amount";
                public const string ReceivedAmount = "received_amount";
                public const string InventoryAmount = "inventory_amount";
                public const string State = "state";
            }
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
            Parameters.Add(new() { Name = Arguments.State, Type = "text", Value = "null" });
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
            var state = arguments[Arguments.State]?.ToString();
            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];

            records = ApplyArticleFilter(partNumber, Article.Fields.PartNumber, records);
            records = ApplyArticleFilter(typeNumber, Article.Fields.TypeNumber, records);
            records = ApplyArticleFilter(orderNumber, Article.Fields.OrderNumber, records);
            records = ApplyArticleFilter(designation, Article.Fields.Designation, records);
            records = ApplyManufacturerFilter(manufacturer, records);
            records = ApplyOrderFilter(order, records);
            records = ApplyStateFilter(state, records);

            var filtered = records.ToList();
            
            var result = new EntityRecordList();
            result.AddRange(filtered.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = filtered.Count;

            return result;
        }

        private static IEnumerable<EntityRecord> ApplyArticleFilter(string? filterValue, string property, IEnumerable<EntityRecord> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records
                .Where(r => GetArticle(r)[property].ToString()!.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<EntityRecord> ApplyOrderFilter(string? filterValue, IEnumerable<EntityRecord> records)
        {
            const string orders = $"${Record.Relations.Order}";

            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records.Where(r => ((List<EntityRecord>)r[orders]).Exists(
                o => o[Order.Fields.Number].ToString()!.Contains(filterValue, StringComparison.OrdinalIgnoreCase)));
        }

        private static IEnumerable<EntityRecord> ApplyManufacturerFilter(string? filterValue, IEnumerable<EntityRecord> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records
                .Where(r => GetManufacturer(r).Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<EntityRecord> ApplyStateFilter(string? filterValue, IEnumerable<EntityRecord> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records.Where(r => ((string)r[Record.Fields.State]).Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<EntityRecord> GetRecords(Guid projectId)
        {
            if (RepositoryService.ProjectRepository.Find(projectId) is not Project project)
                return [];

            var projectOrderEntries = RepositoryService.OrderRepository.FindManyEntriesByProject(projectId);
            var orderEntries = RepositoryService.OrderRepository.FindManyByProject(projectId)
                .ToDictionary(r => r.Id!.Value, r => r);

            var orderedAmountLookup = projectOrderEntries
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var receivedAmountLookup = RepositoryService.GoodsReceivingRepository.FindManyEntriesByProject(projectId)
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var ordersLookup = projectOrderEntries
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Select(r => orderEntries[r.Order]).ToList());

            var inventoryAmountLookup = RepositoryService.InventoryRepository.FindManyReservationEntriesByProject(projectId)
                .GroupBy(r => r.Article)
                .ToDictionary(g => g.Key, g => g.Sum(r => r.Amount));

            var partListEntries = !ArticleId.HasValue
                ? RepositoryService.PartListRepository.FindManyEntriesByProject(projectId, true)
                : RepositoryService.PartListRepository.FindManyEntriesByProjectAndArticle(projectId, ArticleId.Value, true);

            var articleLookup = GetArticleLookup(partListEntries);

            return partListEntries
                .GroupBy(ple => ple.Article)
                .Select(g => RecordFromGroup(g, project, 
                    articleLookup, ordersLookup, 
                    orderedAmountLookup, receivedAmountLookup, inventoryAmountLookup))
                .OrderBy(r => GetArticle(r).PartNumber.ToString());
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(List<PartListEntry> partListEntries)
        {
            const string select = $"*, " +
                $"${Article.Relations.Manufacturer}.{Company.Fields.Name}, " +
                $"${Article.Relations.Type}.*";

            var articleIds = partListEntries
                .Select(ple => ple.Article)
                .Distinct()
                .ToArray();

            return RepositoryService.ArticleRepository.FindMany(select, articleIds);
        }

        private static EntityRecord RecordFromGroup(
            IGrouping<Guid, PartListEntry> group, 
            Project project,
            Dictionary<Guid, Article?> articleLookup,
            Dictionary<Guid, List<Order>> ordersLookup, 
            Dictionary<Guid, decimal> orderedAmountLookup, 
            Dictionary<Guid, decimal> receivedAmountLookup, 
            Dictionary<Guid, decimal> inventoryAmountLookup)
        {
            var rec = new EntityRecord();

            var commons = group.First();
            var articleId = commons.Article;
            var article = articleLookup[articleId];
            var articles = article == null ? [] : new List<EntityRecord>() { article };
            var demand = group.Sum(r => r.Amount);
            var orders = new List<EntityRecord>();
            orders.AddRange(GetOrders(articleId, ordersLookup));

            rec["id"] = articleId;
            rec[Record.Fields.Project] = (Guid)project["id"];
            rec[Record.Fields.Article] = articleId;

            rec[$"${Record.Relations.Article}"] = articles;
            rec[$"${Record.Relations.Project}"] = new List<EntityRecord>() { project };
            rec[$"${Record.Relations.Order}"] = orders;

            var orderedAmount = GetAmount(orderedAmountLookup, articleId);
            var receivedAmount = GetAmount(receivedAmountLookup, articleId);
            var inventoryAmount = GetAmount(inventoryAmountLookup, articleId);

            rec[Record.Fields.Demand] = demand;
            rec[Record.Fields.OrderedAmount] = orderedAmount;
            rec[Record.Fields.ReceivedAmount] = receivedAmount;
            rec[Record.Fields.InventoryAmount] = inventoryAmount;
            rec[Record.Fields.State] = GetState(demand, orderedAmount, receivedAmount, inventoryAmount);

            return rec;
        }

        private static string GetState(decimal demand, decimal ordered, decimal received, decimal fromInventory)
        {
            if (demand <= received + fromInventory)
                return "Complete";
            if (demand > ordered + fromInventory)
                return "To Order";
            return "Incomming";
        }

        private static List<Order> GetOrders(Guid articleId, Dictionary<Guid, List<Order>> ordersLookup)
        {
            if (!ordersLookup.TryGetValue(articleId, out var orders))
                return [];
            return orders;
        }

        private static Article GetArticle(EntityRecord record)
        {
            var article = ((List<EntityRecord>)record[$"${Record.Relations.Article}"])[0];
            return TypedEntityRecordWrapper.WrapElseDefault<Article>(article)!;
        }

        private static Company GetManufacturer(EntityRecord rec)
            => GetArticle(rec).GetManufacturer();

        private static decimal GetAmount(Dictionary<Guid, decimal> dict, Guid key)
        {
            if (dict.TryGetValue(key, out var amount))
                return amount;
            return 0m;
        }
    }
}
