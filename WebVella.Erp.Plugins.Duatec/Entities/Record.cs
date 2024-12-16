﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal static class Record
    {
        public static bool Exists(string entity, string field, object? fieldValue)
        {
            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(entity, "*",
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object > 0;
        }

        public static EntityRecord? Find(string entity, Guid id, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = "id", FieldValue = id, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        public static EntityRecord? FindBy(string entity, string field, object? fieldValue, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data?.SingleOrDefault();
        }

        public static List<EntityRecord> FindManyBy(string entity, string field, object? fieldValue, string select = "*")
        {
            var recMan = new RecordManager();
            var response = recMan.Find(new EntityQuery(entity, select,
                new QueryObject() { FieldName = field, FieldValue = fieldValue, QueryType = QueryType.EQ }));

            return response.Object?.Data ?? [];
        }

        public static Guid? Insert(string entity, EntityRecord rec)
        {
            var recMan = new RecordManager();
            var id = Guid.NewGuid();

            rec["id"] = id;
            var result = recMan.CreateRecord(entity, rec);

            return result.Success
                ? id : null;
        }

        public static bool Delete(string entity, Guid id)
        {
            var recMan = new RecordManager();

            return recMan.DeleteRecord(entity, id).Success;
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
    }
}
