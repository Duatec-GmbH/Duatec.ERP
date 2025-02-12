using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.TypedRecords.Util
{
    public static class ListOfTypedEntityRecordWrapperExtensions
    {
        public static List<T> Join<T>(this List<T> records, string relationName, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
        {
            if (records.Count == 0)
                return records;

            recMan ??= new();
            var entityName = new T().EntityName;
            var relations = recMan.EntityRelationManager.Read().Object;

            IEnumerable<EntityRecord> currentRecords = records;

            var path = relationName.Split('.', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            foreach(var access in path)
            {
                if (!access.StartsWith('$'))
                    throw new ArgumentException($"argument '{relationName}' must only contain realations");

                var relName = access[1..];
                var relation = relations.FirstOrDefault(r => r.Name == relName)
                    ?? throw new InvalidOperationException($"relation '{relName}' does not exist");

                if (relation.RelationType == EntityRelationType.OneToOne)
                    currentRecords = JoinSingle(currentRecords, relation, recMan, ref entityName);
                else if (relation.RelationType == EntityRelationType.OneToMany)
                {
                    if (relation.TargetEntityName == entityName)
                        currentRecords = JoinSingle(currentRecords, relation, recMan, ref entityName);
                    else
                    {
                        if (i < path.Length - 1)
                            throw new InvalidOperationException($"can not join many records, this is only supported on last relation path element");

                        JoinMultiple(currentRecords, relation, recMan, entityName);
                        break;
                    }
                }
                else throw new InvalidOperationException($"relation '{relName}' has an invalid relation type only one to one and one to many are supported");

                i++;
            }

            return records;
        }

        private static IEnumerable<EntityRecord> JoinSingle(IEnumerable<EntityRecord> currentRecords, EntityRelation relation, RecordManager recMan, ref string entityName)
        {
            var (recordProperty, nextIdProperty, nextEntityName) = GetJoinInfo(relation, entityName);
            var ids = GetIds(currentRecords, recordProperty);

            var result = RepositoryHelper.FindManyByUniqueArgs(recMan, nextEntityName, nextIdProperty, "*", ids);
            foreach (var r in currentRecords)
            {
                if (r.Properties.TryGetValue($"${relation.Name}", out var l) && l is List<EntityRecord>)
                    continue;     

                if (r[recordProperty] is not Guid id || !result.TryGetValue(id, out var rec) || rec == null)
                    r[$"${relation.Name}"] = new List<EntityRecord>();
                else
                    r[$"${relation.Name}"] = new List<EntityRecord>() { rec };
            }

            entityName = nextEntityName;
            return currentRecords.Where(v => v != null)!.ToArray();
        }


        private static void JoinMultiple(IEnumerable<EntityRecord> currentRecords, EntityRelation relation, RecordManager recMan, string entityName)
        {
            var (recordProperty, nextIdProperty, nextEntityName) = GetJoinInfo(relation, entityName);

            var subQueries = GetIds(currentRecords, recordProperty)
                .Select(id => new QueryObject() 
                { 
                    FieldName = nextIdProperty, 
                    FieldValue = id, 
                    QueryType = QueryType.EQ 
                })
                .ToList();

            if (subQueries.Count == 0)
                return;

            var query = subQueries.Count == 1 ? subQueries[0] : new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQueries
            };

            var result = RepositoryHelper.FindManyByQuery(recMan, nextEntityName, query)
                .GroupBy(r => (Guid)r[nextIdProperty])
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach(var r in currentRecords)
            {
                if (r.Properties.TryGetValue($"${relation.Name}", out var l) && l is List<EntityRecord>)
                    continue;

                if (r[recordProperty] is Guid id && result.TryGetValue(id, out var records))
                    r[$"${relation.Name}"] = records;
                else
                    r[$"${relation.Name}"] = new List<EntityRecord>();
            }
        }

        private static Guid[] GetIds(IEnumerable<EntityRecord> records, string property)
        {
            return records.Select(r => r[property] as Guid?)
                .Where(id => id.HasValue)
                .Select(id => id!.Value)
                .Distinct()
                .ToArray();
        }

        private static (string RecordProperty, string NextIdProperty, string NextEntityName) GetJoinInfo(EntityRelation relation, string entityName)
        {
            string recordProperty;
            string nextIdProperty;
            string nextEntityName;

            if (relation.OriginEntityName == entityName)
            {
                recordProperty = relation.OriginFieldName;
                nextIdProperty = relation.TargetFieldName;
                nextEntityName = relation.TargetEntityName;
            }
            else
            {
                recordProperty = relation.TargetEntityName;
                nextIdProperty = relation.OriginFieldName;
                nextEntityName = relation.OriginEntityName;
            }

            return (recordProperty, nextIdProperty, nextEntityName);
        }
    }
}
