using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public static class GoodsReceiving
    {
        public static class Relations
        {
            public const string Order = "goods_receiving_order";
        }

        public const string Entity = "goods_receiving";
        public const string Order = "order_id";
        public const string TimeStamp = "time_stamp";

        public static List<EntityRecord> FindManyByProject(Guid projectId, string select = "*")
        {
            var subQuery = Entities.Order.FindManyByProject(projectId)
                .Select(r => new QueryObject() { FieldName = Order, FieldValue = (Guid)r["id"], QueryType = QueryType.EQ })
                .ToList();

            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(Entity, select,
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            return response.Object?.Data ?? [];
        }
    }
}
