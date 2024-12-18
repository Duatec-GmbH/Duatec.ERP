using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderListEntries4Project : CodeDataSource
    {
        public static class Parameter
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

            Parameters.Add(new() { Name = Parameter.Project, Type = "guid", Value = "null" });
            Parameters.Add(new() { Name = Parameter.PartNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.TypeNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.OrderNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.Designation, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.Order, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.State, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Parameter.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Parameter.PageSize, Type = "int", Value = "10" });
        }

        public Guid? ArticleId { get; }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments[Parameter.Project] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var records = GetRecords(projectId.Value);

            var partNumber = arguments[Parameter.PartNumber]?.ToString();
            var typeNumber = arguments[Parameter.TypeNumber]?.ToString();
            var orderNumber = arguments[Parameter.OrderNumber]?.ToString();
            var designation = arguments[Parameter.Designation]?.ToString();
            var manufacturer = arguments[Parameter.Manufacturer]?.ToString();
            var order = arguments[Parameter.Order]?.ToString();
            var state = arguments[Parameter.State]?.ToString();
            var page = (int)arguments[Parameter.Page];
            var pageSize = (int)arguments[Parameter.PageSize];

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
            const string orders = $"${OrderListEntry.Relations.Order}";

            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records.Where(r => ((List<EntityRecord>)r[orders])
                    .Any(o => o[Order.Number].ToString()!.Contains(filterValue, StringComparison.OrdinalIgnoreCase)));
        }

        private static IEnumerable<EntityRecord> ApplyManufacturerFilter(string? filterValue, IEnumerable<EntityRecord> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records
                .Where(r => GetManufacturer(r)[Company.Name].ToString()!.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<EntityRecord> ApplyStateFilter(string? filterValue, IEnumerable<EntityRecord> records)
        {
            if (string.IsNullOrEmpty(filterValue))
                return records;

            return records.Where(r => ((string)r[OrderListEntry.State]).Contains(filterValue, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<EntityRecord> GetRecords(Guid projectId)
        {
            if (Project.Find(projectId) is not EntityRecord project)
                return [];

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

            var inventoryAmountLookup = InventoryReservationEntry.FindManyByProject(projectId)
                .GroupBy(r => (Guid)r[InventoryReservationEntry.Article])
                .ToDictionary(g => g.Key, g => g.Sum(r => (decimal)r[InventoryReservationEntry.Amount]));

            var partListEntries = !ArticleId.HasValue
                ? PartListEntry.FindManyByProject(projectId, true)
                : PartListEntry.FindManyByProjectAndArticle(projectId, ArticleId.Value, true);

            var articleLookup = GetArticleLookup(partListEntries);

            return partListEntries
                .GroupBy(ple => (Guid)ple[PartListEntry.Article])
                .Select(g => RecordFromGroup(g, project, 
                    articleLookup, ordersLookup, 
                    orderedAmountLookup, receivedAmountLookup, inventoryAmountLookup))
                .OrderBy(r => GetArticle(r)[Article.Fields.PartNumber].ToString());
        }

        private static Dictionary<Guid, Article?> GetArticleLookup(List<EntityRecord> partListEntries)
        {
            var articleRepo = new ArticleRepository();
            var articleIds = partListEntries
                .Select(ple => (Guid)ple[PartListEntry.Article])
                .Distinct()
                .ToArray();

            return articleRepo.FindManyWithTypes(articleIds);
        }


        private static EntityRecord RecordFromGroup(
            IGrouping<Guid, EntityRecord> group, 
            EntityRecord project,
            Dictionary<Guid, Article?> articleLookup,
            Dictionary<Guid, List<EntityRecord>> ordersLookup, 
            Dictionary<Guid, decimal> orderedAmountLookup, 
            Dictionary<Guid, decimal> receivedAmountLookup, 
            Dictionary<Guid, decimal> inventoryAmountLookup)
        {
            var rec = new EntityRecord();

            var commons = group.First();
            var articleId = (Guid)commons[PartListEntry.Article];
            var article = articleLookup[articleId];
            var articles = article == null ? [] : new List<EntityRecord>() { article };
            var amount = group.Sum(r => (decimal)r[PartListEntry.Amount]);

            rec["id"] = articleId;
            rec[OrderListEntry.Project] = (Guid)project["id"];
            rec[OrderListEntry.Article] = articleId;

            rec[$"${OrderListEntry.Relations.Article}"] = articles;
            rec[$"${OrderListEntry.Relations.Project}"] = new List<EntityRecord>() { project };
            rec[$"${OrderListEntry.Relations.Order}"] = GetOrders(articleId, ordersLookup);
            SetFields(rec, amount, orderedAmountLookup, receivedAmountLookup, inventoryAmountLookup);

            return rec;
        }

        private static List<EntityRecord> GetOrders(Guid articleId, Dictionary<Guid, List<EntityRecord>> ordersLookup)
        {
            if (!ordersLookup.TryGetValue(articleId, out var orders))
                return [];
            return orders;
        }

        private static void SetFields(
            EntityRecord rec, 
            decimal demand, 
            Dictionary<Guid, decimal> orderedAmountLookup, 
            Dictionary<Guid, decimal> receivedAmountLookup, 
            Dictionary<Guid, decimal> inventoryAmountLookup)
        {
            var article = (Guid)GetArticle(rec)["id"];
            var orderedAmount = GetAmount(orderedAmountLookup, article);
            var receivedAmount = GetAmount(receivedAmountLookup, article);
            var inventoryAmount = GetAmount(inventoryAmountLookup, article);

            rec[OrderListEntry.Demand] = demand;
            rec[OrderListEntry.OrderedAmount] = orderedAmount;
            rec[OrderListEntry.ReceivedAmount] = receivedAmount;
            rec[OrderListEntry.InventoryAmount] = inventoryAmount;
            rec[OrderListEntry.State] = GetState(demand, orderedAmount, receivedAmount, inventoryAmount);
        }

        private static EntityRecord GetArticle(EntityRecord record)
            => ((List<EntityRecord>)record[$"${OrderListEntry.Relations.Article}"])[0];

        private static string GetState(decimal demand, decimal ordered, decimal received, decimal fromInventory)
        {
            if (demand <= received + fromInventory)
                return "Complete";
            if (demand > ordered + fromInventory)
                return "To Order";
            return "Incomming";
        }

        private static EntityRecord GetManufacturer(EntityRecord rec)
        {
            var article = GetArticle(rec);
            return ((List<EntityRecord>)article[$"${Article.Relations.Manufacturer}"])[0];
        }

        private static decimal GetAmount(Dictionary<Guid, decimal> dict, Guid key)
        {
            if (dict.TryGetValue(key, out var amount))
                return amount;
            return 0m;
        }
    }
}
