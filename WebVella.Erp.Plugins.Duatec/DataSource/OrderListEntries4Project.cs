using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class OrderListEntries4Project : CodeDataSource
    {
        public OrderListEntries4Project(Guid articleId)
            : this()
        {
            Article = articleId;
        }

        public OrderListEntries4Project() : base()
        {
            Id = new Guid("93e148b7-fdcd-4031-b0ad-97b92139db96");
            Name = nameof(OrderListEntries4Project);
            Description = "List of all order list entries for given project";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = "project", Type = "guid", Value = "null" });
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

        public Guid? Article { get; }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var projectId = arguments["project"] as Guid?;
            if (!projectId.HasValue || projectId.Value == Guid.Empty)
                return new EntityRecordList();

            var records = GetRecords(projectId.Value);

            var partNumber = arguments["partNumber"]?.ToString();
            var typeNumber = arguments["typeNumber"]?.ToString();
            var orderNumber = arguments["orderNumber"]?.ToString();
            var designation = arguments["designation"]?.ToString();
            var manufacturer = arguments["manufacturer"]?.ToString();
            var order = arguments["order"]?.ToString();
            var state = arguments["state"]?.ToString();
            var page = (int)arguments["page"];
            var pageSize = (int)arguments["pageSize"];

            records = ApplyArticleFilter(partNumber, Entities.Article.PartNumber, records);
            records = ApplyArticleFilter(typeNumber, Entities.Article.TypeNumber, records);
            records = ApplyArticleFilter(orderNumber, Entities.Article.OrderNumber, records);
            records = ApplyArticleFilter(designation, Entities.Article.Designation, records);
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
                .Where(r => GetManufacturer(r)[Manufacturer.Name].ToString()!.Contains(filterValue, StringComparison.OrdinalIgnoreCase));
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

            // TODO
            var inventoryAmountLookup = new Dictionary<Guid, decimal>();

            var partListEntries = !Article.HasValue
                ? PartListEntry.FindManyByProject(projectId, true)
                : PartListEntry.FindManyByProjectAndArticle(projectId, Article.Value, true);

            var articleLookup = GetArticleLookup(partListEntries);

            return partListEntries
                .GroupBy(ple => (Guid)ple[PartListEntry.Article])
                .Select(g => RecordFromGroup(g, project, articleLookup, ordersLookup, orderedAmountLookup, receivedAmountLookup, inventoryAmountLookup))
                .OrderBy(r => GetArticle(r)[Entities.Article.PartNumber].ToString());
        }

        private static Dictionary<Guid, EntityRecord?> GetArticleLookup(List<EntityRecord> partListEntries)
        {
            var articleIds = partListEntries
                .Select(ple => (Guid)ple[PartListEntry.Article])
                .Distinct()
                .ToArray();

            var result = Entities.Article.FindMany(articleIds);
            SetArticleTypes(result);
            return result;
        }

        private static void SetArticleTypes(Dictionary<Guid, EntityRecord?> articleLookup)
        {
            var articleTypeIds = articleLookup
                .Where(kp => kp.Value != null)
                .Select(kp => (Guid)kp.Value![Entities.Article.Type])
                .Distinct()
                .ToArray();

            var articleTypes = ArticleType.FindMany(articleTypeIds);

            foreach(var rec in articleLookup.Values.Where(r => r != null))
            {
                var list = new List<EntityRecord>();
                var typeId = (Guid)rec![Entities.Article.Type];
                if (articleTypes.TryGetValue(typeId, out var type) && type != null)
                    list.Add(type);
                rec[$"${Entities.Article.Relations.Type}"] = list;
            }
        }

        private static EntityRecord RecordFromGroup(
            IGrouping<Guid, EntityRecord> group, 
            EntityRecord project,
            Dictionary<Guid, EntityRecord?> articleLookup,
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
            return ((List<EntityRecord>)article[$"${Entities.Article.Relations.Manufacturer}"])[0];
        }

        private static decimal GetAmount(Dictionary<Guid, decimal> dict, Guid key)
        {
            if (dict.TryGetValue(key, out var amount))
                return amount;
            return 0m;
        }
    }
}
