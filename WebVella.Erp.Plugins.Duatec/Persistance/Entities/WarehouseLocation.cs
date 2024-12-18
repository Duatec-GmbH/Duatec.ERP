using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    public static class WarehouseLocation
    {
        public const string Entity = "warehouse_location";
        public const string Warehouse = "warehouse_id";
        public const string Designation = "designation";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static bool Exists(Guid warehouse, string designation, Guid? excludedId = null)
        {
            var subQueries = new List<QueryObject>()
            {
                new() { FieldName = Warehouse, FieldValue = warehouse, QueryType = QueryType.EQ },
                new() { FieldName = Designation, FieldValue = designation, QueryType = QueryType.EQ },
                new() { QueryType = QueryType.NOT, SubQueries = [new() { FieldName = "id", FieldValue = excludedId ?? Guid.Empty, QueryType = QueryType.EQ }] }
            };

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "*",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object > 0;
        }
    }
}
