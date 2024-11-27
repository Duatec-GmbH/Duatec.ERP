using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal class OrderListEntry
    {
        public static class Relations
        {
            public const string OrderList = "order_list_entry_order_list";
            public const string Article = "order_list_entry_article";
            public const string Order = "order_list_entry_order";
        }

        public const string Entity = "order_list_entry";
        public const string Article = "article_id";
        public const string OrderList = "order_list_id";
        public const string Order = "order_id";
        public const string Amount = "amount";
        public const string IsFromPartList = "is_from_part_list";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static List<EntityRecord> FindMany(Guid orderListId, string select = "*")
            => Record.FindManyBy(Entity, OrderList, orderListId, select);

        public static bool Exists(Guid orderListId, Guid articleId, Guid? orderId, Guid? excludedId)
        {
            var subQuery = new List<QueryObject>()
            {
                new() { QueryType = QueryType.EQ, FieldName = OrderList, FieldValue = orderListId },
                new() { QueryType = QueryType.EQ, FieldName = Article, FieldValue = articleId },
                new() { QueryType = QueryType.EQ, FieldName = Order, FieldValue = orderId },
            };

            if (excludedId.HasValue)
                subQuery.Add(new() { QueryType = QueryType.NOT, SubQueries = [new() { QueryType = QueryType.EQ, FieldName = "id", FieldValue = excludedId }] });

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "*",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQuery }));

            return response.Object > 0;
        }
    }
}
