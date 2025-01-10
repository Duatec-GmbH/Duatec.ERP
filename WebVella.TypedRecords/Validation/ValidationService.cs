using System.Reflection;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.TypedRecords.Attributes;

namespace WebVella.TypedRecords.Validation
{
    public static class ValidationService
    {
        private sealed class Lookup
        {
            private readonly Dictionary<Type, List<object>> _validatorsByType;
            private readonly Dictionary<string, List<object>> _validatorsByEntity;

            public Lookup(Dictionary<Type, List<object>> validatorsByType, Dictionary<string, List<object>> validatorsByEntity)
            {
                _validatorsByType = validatorsByType;
                _validatorsByEntity = validatorsByEntity;
            }

            public IEnumerable<IRecordValidator> GetByEntity(string entity)
            {
                if (_validatorsByEntity.TryGetValue(entity, out var objects))
                    return objects.Select(o => (IRecordValidator)o);
                return [];
            }

            public IEnumerable<IRecordValidator<T>> GetByType<T>() where T : TypedEntityRecordWrapper, new()
            {
                if (_validatorsByType.TryGetValue(typeof(T), out var l))
                    return l.Select(obj => (IRecordValidator<T>)obj);
                return [];
            }

            public IEnumerable<IRecordValidator> GetByType(Type type)
            {
                if (_validatorsByType.TryGetValue(type, out var l))
                    return l.Select(obj => (IRecordValidator)obj);
                return [];
            }
        }

        private static readonly object _lockObj = new();
        private static readonly Lookup _lookUp = LoadValidators();

        public static IEnumerable<IRecordValidator> GetValidators(Type type)
            => _lookUp.GetByType(type);

        public static IEnumerable<IRecordValidator<T>> GetValidators<T>() where T : TypedEntityRecordWrapper, new()
            => _lookUp.GetByType<T>();

        public static IEnumerable<IRecordValidator> GetValidatorsByEntity(string entity)
            => _lookUp.GetByEntity(entity);

        public static List<ValidationError> ValidateOnCreate(EntityRecord record, string entity)
            => ExecuteValidators(GetValidatorsByEntity(entity), v => v.ValidateOnCreate(record));

        public static List<ValidationError> ValidateOnCreate(EntityRecord record, Type recordType)
            => ExecuteValidators(GetValidators(recordType), v => v.ValidateOnCreate(record));

        public static List<ValidationError> ValidateOnCreate<T>(T record) where T : TypedEntityRecordWrapper, new()
            => ExecuteValidators(GetValidators<T>(), v => v.ValidateOnCreate(record));

        public static List<ValidationError> ValidateOnUpdate(EntityRecord record, string entity)
            => ExecuteValidators(GetValidatorsByEntity(entity), v => v.ValidateOnUpdate(record));

        public static List<ValidationError> ValidateOnUpdate(EntityRecord record, Type recordType)
            => ExecuteValidators(GetValidators(recordType), v => v.ValidateOnUpdate(record));

        public static List<ValidationError> ValidateOnUpdate<T>(T record) where T : TypedEntityRecordWrapper, new()
            => ExecuteValidators(GetValidators<T>(), v => v.ValidateOnUpdate(record));

        public static List<ValidationError> ValidateOnDelete(EntityRecord record, string entity)
            => ExecuteValidators(GetValidatorsByEntity(entity), v => v.ValidateOnDelete(record));

        public static List<ValidationError> ValidateOnDelete(EntityRecord record, Type recordType)
            => ExecuteValidators(GetValidators(recordType), v => v.ValidateOnDelete(record));

        public static List<ValidationError> ValidateOnDelete<T>(T record) where T : TypedEntityRecordWrapper, new()
            => ExecuteValidators(GetValidators<T>(), v => v.ValidateOnDelete(record));


        private static List<ValidationError> ExecuteValidators(
            IEnumerable<IRecordValidator> validators, 
            Func<IRecordValidator, List<ValidationError>> executeFun)
        {
            return validators
                .SelectMany(v => executeFun(v))
                .ToList();
        }

        private static Lookup LoadValidators()
        {
            var byType = new Dictionary<Type, List<object>>(512);
            var byEntity = new Dictionary<string, List<object>>(512);

            lock (_lockObj)
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.GetCustomAttribute<TypedValidatorAttribute>() != null)
                    .Select(t => new { Type = t, Attribute = t.GetCustomAttribute<TypedValidatorAttribute>()! });

                foreach (var tuple in types)
                {
                    var validator = Activator.CreateInstance(tuple.Type)
                        ?? throw new TypeLoadException($"Could not create type '{tuple.Type.FullName}'");

                    var targetType = tuple.Attribute.TargetType;

                    if (targetType != null)
                        AddToDictionary(byType, targetType, validator);


                    var entity = targetType?.GetCustomAttribute<TypedEntityAttribute>()?.Entity;
                    if (!string.IsNullOrEmpty(entity))
                        AddToDictionary(byEntity, entity, validator);
                }
            }

            return new(byType, byEntity);
        }

        private static void AddToDictionary<TKey>(Dictionary<TKey, List<object>> dict, TKey key, object value) where TKey : notnull
        {
            if (dict.TryGetValue(key, out var validatorsList))
                validatorsList.Add(value);
            else
            {
                validatorsList = [value];
                dict.Add(key, validatorsList);
            }
        }
    }
}
