using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.TypedRecords.Util;

namespace WebVella.Erp.TypedRecords.Persistance
{
    public static class RepositoryHelper
    {
        public static EntityRecord? Insert(RecordManager recMan, string entity, EntityRecord rec)
        {
            if (!rec.Properties.TryGetValue("id", out var val) || val is not Guid)
                rec["id"] = Guid.NewGuid();

            var result = recMan.CreateRecord(entity, rec);

            return result.Success
                ? result.Object.Data.Single() : null;
        }

        public static List<EntityRecord> InsertMany(RecordManager recMan, string entity, IEnumerable<EntityRecord> records)
        {
            var response = recMan.CreateRecords(entity, records.WithoutRelations());

            return response.Object?.Data ?? [];
        }

        public static EntityRecord? Delete(RecordManager recMan, string entity, Guid id)
        {
            var response = recMan.DeleteRecord(entity, id);

            return response.Success
                ? response.Object.Data.Single() : null;
        }

        public static List<EntityRecord> DeleteMany(RecordManager recMan, string entity, params Guid[] ids)
        {
            var response = recMan.DeleteRecords(entity, ids);

            return response.Object?.Data ?? [];
        }

        public static EntityRecord? Update(RecordManager recMan, string entity, EntityRecord record)
        {
            var unchanged = Find(recMan, entity, (Guid)record["id"]);

            if (AreEqual(record, unchanged!))
                return unchanged;

            var response = recMan.UpdateRecord(entity, record);

            return response.Success
                ? response.Object.Data.Single()
                : null;
        }

        private static bool AreEqual(EntityRecord a, EntityRecord b)
        {
            if (a.Properties.Count != b.Properties.Count)
                return false;

            foreach(var (key, value) in a.Properties)
            {
                if (!b.Properties.TryGetValue(key, out var otherVal))
                    return false;

                if (value == null ^ otherVal == null)
                    return false;

                if (value != null && !value.Equals(otherVal))
                    return false;
            }
            return true;
        }


        public static bool Exists(RecordManager recMan, string entity, string field, object? fieldValue)
        {
            var response = recMan.Count(new EntityQuery(entity, "*",
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object > 0;
        }

        public static EntityRecord? Find(RecordManager recMan, string entity, Guid id, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = "id", FieldValue = id, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        public static EntityRecord? FindBy(RecordManager recMan, string entity, string field, object? fieldValue, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        public static List<EntityRecord> FindManyBy(RecordManager recMan, string entity, string field, object? fieldValue, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data ?? [];
        }

        public static List<EntityRecord> FindMany(RecordManager recMan, string entity, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select));

            return response.Object?.Data ?? [];
        }

        public static bool ExistsByQuery(RecordManager recMan, string entity, QueryObject query)
        {
            var response = recMan.Count(new EntityQuery(entity, "*", query));

            return response.Object > 0;
        }

        public static EntityRecord? FindByQuery(RecordManager recMan, string entity, QueryObject query, string select = "*")
        {
            var response = recMan.Find(new EntityQuery(entity, select, query));

            return response.Object?.Data?.SingleOrDefault();
        }

        public static List<EntityRecord> FindManyByQuery(RecordManager recMan, string entity, QueryObject query, string select = "*")
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

            var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQuery
            };

            var queryResponse = recMan.Find(new EntityQuery(entity, select, query));

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
    }
}
