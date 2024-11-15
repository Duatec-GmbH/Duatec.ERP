using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal static class ArticleStock
    {
        public static class Relations
        {
            public const string Article = "article";
            public const string Project = "project";
            public const string Location = "warehouse_location";
        }

        public const string Entity = "article_stock";
        public const string WarehouseLocation = "warehouse_location_id";
        public const string Article = "article_id";
        public const string Project = "project_id";
        public const string Amount = "amount";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static EntityRecord? Find(Guid articleId, Guid locationId, Guid? projectId)
        {
            var subQueries = new List<QueryObject>()
            {
                new() { FieldName = Article, FieldValue = articleId, QueryType = QueryType.EQ },
                new() { FieldName = WarehouseLocation, FieldValue = locationId, QueryType = QueryType.EQ },
                new() { FieldName = Project, FieldValue = projectId, QueryType = QueryType.EQ },
            };

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, "*",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object?.Data?.SingleOrDefault();
        }

        public static bool Delete(Guid id)
        {
            var recordManager = new RecordManager();
            return recordManager.DeleteRecord(Entity, id).Success;
        }
    }
}
