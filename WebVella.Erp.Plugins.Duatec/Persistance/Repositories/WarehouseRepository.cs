using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class WarehouseRepository : TypedListRepositoryBase<Warehouse, WarehouseLocation>
    {
        protected override string EntryParentIdPath => WarehouseLocation.Fields.Warehouse;

        public bool EntryExistsWithinWarehouse(Guid warehouseId, string designation, Guid? excludedId)
        {
            var subQueries = new List<QueryObject>()
            {
                new()
                {
                    FieldName = WarehouseLocation.Fields.Warehouse,
                    FieldValue = warehouseId,
                    QueryType = QueryType.EQ
                },
                new()
                {
                    FieldName = WarehouseLocation.Fields.Designation,
                    FieldValue = designation,
                    QueryType = QueryType.EQ
                }
            };
            if (excludedId.HasValue)
                subQueries.Add(ExcludeIdQuery(excludedId.Value));

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries = subQueries
            };

            return EntryExistsByQuery(query);
        }
    }
}
