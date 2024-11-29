using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Order
    {
        public static class Relations
        {
            public const string Supplier = "order_supplier";
            public const string Project = "order_project";
        }

        public const string Entity = "order";
        public const string Supplier = "supplier_id";
        public const string Number = "order_number";
        public const string Project = "project_id";

        internal static List<EntityRecord> FindManyByProject(Guid project)
            => Record.FindManyBy(Entity, Project, project);

        internal static List<EntityRecord> FindManyByProjectAndArticle(Guid project, Guid article)
        {
            var entries = OrderEntry.FindManyByProjectAndArticle(project, article);
            if (entries.Count == 0)
                return [];

            var subQuery = entries
                .Select(r => (Guid)r[OrderEntry.Order])
                .Distinct()
                .Select(id => new QueryObject() { FieldName = "id", FieldValue = id, QueryType = QueryType.EQ })
                .ToList();

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, "*",
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            return response.Object?.Data ?? [];
        }


        public static int GetMissingArticleCount(Guid orderId, Guid articleId)
        {
            var recMan = new RecordManager();

            var query = new QueryObject
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new QueryObject
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Order,
                        FieldValue = orderId,
                    },
                    new QueryObject
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Article,
                        FieldValue = articleId,
                    }
                ],
            };

            var entity = recMan.Find(new EntityQuery(OrderEntry.Entity, "amount", query: query)).Object?.Data.SingleOrDefault();
            return (int)(entity?["amount"] as decimal? ?? 0);
        }

        public static int GetMissingArticleCount(Guid orderId, Guid articleId)
        {
            var recMan = new RecordManager();

            var query = new QueryObject
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new QueryObject
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Order,
                        FieldValue = orderId,
                    },
                    new QueryObject
                    {
                        QueryType = QueryType.EQ,
                        FieldName = OrderEntry.Article,
                        FieldValue = articleId,
                    }
                ],
            };

            var entity = recMan.Find(new EntityQuery(OrderEntry.Entity, "amount", query: query)).Object?.Data.SingleOrDefault();
            return (int)(entity?["amount"] as decimal? ?? 0);
        }
    }
}
