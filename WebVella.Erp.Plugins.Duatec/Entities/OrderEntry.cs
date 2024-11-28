using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal static class OrderEntry
    {
        public static class Relations
        {
            public static string Article = "order_entry_article";
            public static string Order = "order_entry_order";
        }

        public const string Entity = "order_entry";
        public const string Article = "article_id";
        public const string Order = "order_id";
        public const string Amount = "amount";

        internal static List<EntityRecord> FindManyByProject(Guid project)
        {
            var subQueries = Entities.Order.FindManyByProject(project)
                .Select(o => new QueryObject() { QueryType = QueryType.EQ, FieldName = Order, FieldValue = (Guid)o["id"] })
                .ToList();

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, "*",
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQueries }));

            return response.Object?.Data ?? [];
        }
    }
}
