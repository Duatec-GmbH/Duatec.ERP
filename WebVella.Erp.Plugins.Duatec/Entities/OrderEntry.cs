using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class OrderEntry
    {
        public static class Relations
        {
            public const string Article = "order_entry_article";
            public const string Order = "order_entry_order";
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

        internal static List<EntityRecord> FindManyByProjectAndArticle(Guid project, Guid article)
        {
            var orderIdQueries = Entities.Order.FindManyByProject(project)
                .Select(o => new QueryObject() { QueryType = QueryType.EQ, FieldName = Order, FieldValue = (Guid)o["id"] })
                .ToList();

            var orderQuery = new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = orderIdQueries
            };

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, "*",
                new QueryObject() 
                { 
                    QueryType = QueryType.AND, 
                    SubQueries = [orderQuery, new() { FieldName = Article, FieldValue = article, QueryType = QueryType.EQ }] 
                }));

            return response.Object?.Data ?? [];
        }
    }
}
