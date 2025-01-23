using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Common
{
    internal static class RepositoryHelper
    {
        internal static bool Exists(RecordManager recMan, string entity, string field, object? fieldValue)
        {
            var response = recMan.Count(new EntityQuery(entity, "*",
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object > 0;
        }

        internal static EntityRecord? Find(RecordManager recMan, string entity, Guid id, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = "id", FieldValue = id, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        internal static EntityRecord? FindBy(RecordManager recMan, string entity, string field, object? fieldValue, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        internal static List<EntityRecord> FindManyBy(RecordManager recMan, string entity, string field, object? fieldValue, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data ?? [];
        }

        internal static EntityRecord? Insert(RecordManager recMan, string entity, EntityRecord rec)
        {
            if(!rec.Properties.TryGetValue("id", out var val) || val is not Guid)
                rec["id"] = Guid.NewGuid();

            var result = recMan.CreateRecord(entity, rec);

            return result.Success
                ? result.Object.Data.Single() : null;
        }

        internal static EntityRecord? Delete(RecordManager recMan, string entity, Guid id)
        {
            var response = recMan.DeleteRecord(entity, id);

            return response.Success
                ? response.Object.Data.Single() : null;
        }

        internal static List<EntityRecord> DeleteMany(RecordManager recMan, string entity, params Guid[] ids)
        {
            var response = recMan.DeleteRecords(entity, ids);

            return response.Object?.Data ?? [];
        }

        internal static bool ExistsByQuery(RecordManager recMan, string entity, QueryObject query)
        {
            var response = recMan.Count(new EntityQuery(entity, "*", query));

            return response.Object > 0;
        }

        internal static EntityRecord? FindByQuery(RecordManager recMan, string entity, QueryObject query, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select, query));

            return response.Object?.Data?.SingleOrDefault();
        }

        internal static List<EntityRecord> FindManyByQuery(RecordManager recMan, string entity, QueryObject query, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select, query));

            return response.Object?.Data ?? [];
        }

        public static Dictionary<T, EntityRecord?> FindManyByUniqueArgs<T>(RecordManager recMan, string entity, string fieldName, string select = "*", params T[] args)
            where T : notnull
        {
            if (args.Length == 0)
                return [];

            var subQuery = args
                .Select(id => new QueryObject() { QueryType = QueryType.EQ, FieldName = fieldName, FieldValue = id })
                .ToList();

            var queryResponse = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            var result = new Dictionary<T, EntityRecord?>(args.Length);
            foreach (var key in args)
                result[key] = null;

            if (queryResponse.Object?.Data != null)
            {
                foreach (var obj in queryResponse.Object.Data)
                    result[(T)obj[fieldName]] = obj;
            }

            return result;
        }

        internal static EntityRecord? Update(RecordManager recMan, string entity, EntityRecord record)
        {
            var response = recMan.UpdateRecord(entity, record);

            return response.Success
                ? response.Object.Data.Single()
                : null;
        }
    }
}
