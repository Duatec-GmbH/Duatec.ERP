using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Common
{
    internal static class RepositoryHelper
    {
        internal static bool Exists(string entity, string field, object? fieldValue)
        {
            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(entity, "*",
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object > 0;
        }

        internal static EntityRecord? Find(string entity, Guid id, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = "id", FieldValue = id, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        internal static EntityRecord? FindBy(string entity, string field, object? fieldValue, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        internal static List<EntityRecord> FindManyBy(string entity, string field, object? fieldValue, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data ?? [];
        }

        internal static EntityRecord? Insert(string entity, EntityRecord rec)
        {
            var recMan = new RecordManager();

            if(!rec.Properties.TryGetValue("id", out var val) || val is not Guid)
                rec["id"] = Guid.NewGuid();

            var result = recMan.CreateRecord(entity, rec);

            return result.Success
                ? result.Object.Data.Single() : null;
        }

        internal static EntityRecord? Delete(string entity, Guid id)
        {
            var recMan = new RecordManager();

            var response = recMan.DeleteRecord(entity, id);

            return response.Success
                ? response.Object.Data.Single() : null;
        }

        internal static List<EntityRecord> DeleteMany(string entity, params Guid[] ids)
        {
            var recMan = new RecordManager();

            var response = recMan.DeleteRecords(entity, ids);

            return response.Object?.Data ?? [];
        }

        internal static bool ExistsByQuery(string entity, QueryObject query)
        {
            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(entity, "*", query));

            return response.Object > 0;
        }

        internal static EntityRecord? FindByQuery(string entity, QueryObject query, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select, query));

            return response.Object?.Data?.SingleOrDefault();
        }

        internal static List<EntityRecord> FindManyByQuery(string entity, QueryObject query, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select, query));

            return response.Object?.Data ?? [];
        }

        public static Dictionary<T, EntityRecord?> FindManyByUniqueArgs<T>(string entity, string fieldName, string select = "*", params T[] args)
            where T : notnull
        {
            if (args.Length == 0)
                return [];

            var recMan = new RecordManager();
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

        internal static EntityRecord? Update(string entity, EntityRecord record)
        {
            var recMan = new RecordManager();
            var response = recMan.UpdateRecord(entity, record);

            return response.Success
                ? response.Object.Data.Single()
                : null;
        }
    }
}
