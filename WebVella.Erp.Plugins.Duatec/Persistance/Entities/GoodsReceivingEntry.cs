using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public static class GoodsReceivingEntry
    {
        public static class Relations
        {
            public const string Article = "goods_receiving_entry_article";
            public const string GoodsReceiving = "goods_receiving_entry_goods_receiving";
        }

        public const string Entity = "goods_receiving_entry";
        public const string Article = "article_id";
        public const string GoodsReceiving = "goods_receiving_id";
        public const string Amount = "amount";

        public static List<EntityRecord> FindMany(Guid goodsReceiving, string select = "*")
            => Record.FindManyBy(Entity, GoodsReceiving, goodsReceiving, select);

        public static List<EntityRecord> FindManyByProject(Guid projectId, string select = "*")
        {
            var subQuery = Entities.GoodsReceiving.FindManyByProject(projectId)
                .Select(r => new QueryObject() { FieldName = GoodsReceiving, FieldValue = (Guid)r["id"] })
                .ToList();

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, select,
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            return response.Object?.Data ?? [];
        }

        public static List<EntityRecord> FindManyByProjectAndArticle(Guid projectId, Guid articleId)
        {
            var query = @$"SELECT * FROM {Entity} 
WHERE {Article} = @articleId 
AND ${Relations.GoodsReceiving}.${Entities.GoodsReceiving.Relations.Order}.${Order.Relations.Project}.id = @projectId";

            var command = new EqlCommand(query,
                new EqlParameter("articleId", articleId),
                new EqlParameter("projectId", projectId));

            return command.Execute();
        }

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static bool Exists(Guid goodsReceiving, Guid article, Guid? excluded = null)
        {
            var subQueries = new List<QueryObject>()
            {
                new() { FieldName = GoodsReceiving, FieldValue = goodsReceiving, QueryType = QueryType.EQ },
                new() { FieldName = Article, FieldValue = article, QueryType = QueryType.EQ }
            };
            if (excluded.HasValue)
            {
                subQueries.Add(new()
                {
                    QueryType = QueryType.NOT,
                    SubQueries = [new() { FieldName = "id", FieldValue = excluded.Value, QueryType = QueryType.EQ }]
                });
            }

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "id",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object > 0;
        }
    }
}
