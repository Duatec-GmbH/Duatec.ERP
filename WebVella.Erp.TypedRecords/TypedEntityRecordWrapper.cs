using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;

namespace WebVella.Erp.TypedRecords
{
    public abstract class TypedEntityRecordWrapper : EntityRecord
    {
        private Dictionary<string, EntityRelation>? _queriedRelations = null;
        private Dictionary<string, object>? _unmodifiedFields = null;

        public abstract string EntityName { get; }

        public Guid? Id
        {
            get => Get<Guid?>("id");
            set => Properties["id"] = value;
        }

        protected virtual void Init(EntityRecord? record)
        {
            if (record != null)
                Properties = record.Properties;

            // TODO: maybe initialize fields here, maybe define default values, but first check if it is possible
        }

        public static T? WrapElseDefault<T>(EntityRecord? record) where T : TypedEntityRecordWrapper, new()
        {
            if (record == null) return null;
            if (record is T r) return r;

            var result = new T();
            result.Init(record);

            return result;
        }

        public static T Wrap<T>(EntityRecord? record) where T : TypedEntityRecordWrapper, new()
        {
            return WrapElseDefault<T>(record)
                ?? throw new ArgumentException($"Argument {nameof(record)} must not be null");
        }

        protected T Get<T>(string property, T defaultValue = default!)
        {
            if (!Properties.TryGetValue(property, out var v) || v is not T value)
                return defaultValue;
            return value;
        }

        protected T GetEnumValueFromString<T>(string property, T defaultValue = default!, bool ignoreCase = false) where T : unmanaged
        {
            if (!Properties.TryGetValue(property, out var v) || v is not string text)
                return defaultValue;

            var comp = ignoreCase 
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;

            foreach(var val in Enum.GetValues(typeof(T)))
            {
                if (text.Equals($"{val}", comp))
                    return (T)val;
            }
            return defaultValue;
        }

        protected void SetRelationValue(string relationName, EntityRecord? value)
        {
            var l = value == null ? [] : new List<EntityRecord>() { value };
            Properties[$"${relationName}"] = l;
        }

        protected void SetRelationValues(string relationName, IEnumerable<EntityRecord> values)
        {
            var newValue = values is List<EntityRecord> l ? l : values.ToList();

            Properties[$"${relationName}"] = newValue;
        }

        protected IReadOnlyList<T> GetManyByRelation<T>(string relationName) where T : TypedEntityRecordWrapper, new()
            => GetRelatedRecords<T>(relationName).ToList();
        

        protected T? GetSingleByRelation<T>(string relationName) where T : TypedEntityRecordWrapper, new()
            => GetRelatedRecords<T>(relationName).SingleOrDefault();
        

        public bool TryGet<T>(string property, out T result, T defaultValue = default!)
        {
            if(!Properties.TryGetValue(property, out var obj) || obj is not T value)
            {
                result = defaultValue;
                return false;
            }
            result = value;
            return true;
        }

        private IEnumerable<T> GetRelatedRecords<T>(string relationName) where T : TypedEntityRecordWrapper, new()
        {
            if (TryGet<IEnumerable<EntityRecord>>($"${relationName}", out var res))
            {
                if (res == null) return [];
                if (res is List<T> list) return list;

                return res.Select(Wrap<T>);
            }

            var relation = GetRelation(relationName);

            return FindRelatedRecords(relation)
                .Select(Wrap<T>);
        }

        private EntityRelation GetRelation(string relationName)
        {
            relationName = relationName.TrimStart('$');

            if (_queriedRelations == null || !_queriedRelations.TryGetValue(relationName, out var relation))
                relation = null;

            if (relation != null)
                return relation;

            var relMan = new EntityRelationManager();
            var response = relMan.Read(relationName);

            if (!response.Success || response.Object == null)
                throw new ArgumentException($"Relation with name '{relationName}' does not exist");

            relation = response.Object;
            if (relation.TargetEntityName != EntityName && relation.OriginEntityName != EntityName)
                throw new ArgumentException($"Relation '{relationName}' does not target entity '{EntityName}'");

            if(_queriedRelations == null)
                _queriedRelations = new(32) { [relationName] = relation };
            else _queriedRelations.Add(relationName, relation);

            return relation;
        }

        private Dictionary<string, object>? GetUnmodifiedFields()
        {
            if (!Id.HasValue || Id.Value == Guid.Empty)
                return null;

            var unmodified = new RecordManager().Find(EntityName, Id.Value)?.Object?.Data.SingleOrDefault();
            if (unmodified == null)
                return null;

            return unmodified.Properties;
        }

        private List<EntityRecord> FindRelatedRecords(EntityRelation relation)
        {
            var isOrigin = relation.OriginEntityName == EntityName;

            string otherFieldName;
            string thisFieldName;
            string otherEntityName;

            if (isOrigin)
            {
                thisFieldName = relation.OriginFieldName;
                otherFieldName = relation.TargetFieldName;
                otherEntityName = relation.TargetEntityName;
            }
            else
            {
                thisFieldName = relation.TargetFieldName;
                otherFieldName = relation.OriginFieldName;
                otherEntityName = relation.OriginEntityName;
            }

            if (!Properties.TryGetValue(thisFieldName, out var value))
            {
                _unmodifiedFields ??= GetUnmodifiedFields();
                if (_unmodifiedFields == null)
                    throw new DbException($"Entity '{EntityName}' does not have a field with name '{thisFieldName}'");

                value = _unmodifiedFields[thisFieldName];
            }

            var expr = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = otherFieldName,
                FieldValue = value
            };

            var result = new RecordManager()
                .Find(new EntityQuery(otherEntityName, "*", expr));

            if (!result.Success || result.Object?.Data == null)
                throw new DbException("Could not execute query");

            return result.Object.Data;
        }
    }
}
