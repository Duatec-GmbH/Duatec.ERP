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
            private readonly Dictionary<Type, List<IRecordValidator>> _validatorsByType;
            private readonly Dictionary<string, List<IRecordValidator>> _validatorsByEntity;

            public Lookup(Dictionary<Type, List<IRecordValidator>> validatorsByType, Dictionary<string, List<IRecordValidator>> validatorsByEntity)
            {
                _validatorsByType = validatorsByType;
                _validatorsByEntity = validatorsByEntity;
            }

            public IEnumerable<IRecordValidator> GetByEntity(string entity)
            {
                if (_validatorsByEntity.TryGetValue(entity, out var objects))
                    return objects;
                return [];
            }

            public IEnumerable<IRecordValidator<T>> GetByType<T>() where T : TypedEntityRecordWrapper, new()
            {
                if (_validatorsByType.TryGetValue(typeof(T), out var l))
                    return l.Select(obj => (IRecordValidator<T>)obj);
                return [];
            }
        }

        private static readonly object _lockObj = new();
        private static readonly Lookup _lookUp = LoadLookup();

        public static IEnumerable<IRecordValidator<T>> GetValidators<T>() where T : TypedEntityRecordWrapper, new()
            => _lookUp.GetByType<T>();

        public static IEnumerable<IRecordValidator> GetValidatorsByEntity(string entity)
            => _lookUp.GetByEntity(entity);

        public static List<ValidationError> ValidateOnCreate(EntityRecord record, string entity)
            => ExecuteValidators(GetValidatorsByEntity(entity), v => v.ValidateOnCreate(record));

        public static List<ValidationError> ValidateOnCreate<T>(T record) where T : TypedEntityRecordWrapper, new()
            => ExecuteValidators(GetValidators<T>(), v => v.ValidateOnCreate(record));

        public static List<ValidationError> ValidateOnUpdate(EntityRecord record, string entity)
            => ExecuteValidators(GetValidatorsByEntity(entity), v => v.ValidateOnUpdate(record));

        public static List<ValidationError> ValidateOnUpdate<T>(T record) where T : TypedEntityRecordWrapper, new()
            => ExecuteValidators(GetValidators<T>(), v => v.ValidateOnUpdate(record));

        public static List<ValidationError> ValidateOnDelete(EntityRecord record, string entity)
            => ExecuteValidators(GetValidatorsByEntity(entity), v => v.ValidateOnDelete(record));

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

        private static Lookup LoadLookup()
        {
            var byType = new Dictionary<Type, List<IRecordValidator>>(512);
            var byEntity = new Dictionary<string, List<IRecordValidator>>(512);

            lock (_lockObj)
            {
                var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .ToArray();

                var validatorTypeInfos = allTypes
                    .Where(t => t.GetCustomAttribute<TypedValidatorAttribute>() != null)
                    .Select(t => new { Type = t, t.GetCustomAttribute<TypedValidatorAttribute>()!.Entity });

                var entityTypeLookup = allTypes
                    .Where(t => t.GetCustomAttribute<TypedEntityAttribute>() != null)
                    .ToDictionary(t => t.GetCustomAttribute<TypedEntityAttribute>()!.Entity, t => t);

                foreach (var validatorInfo in validatorTypeInfos)
                {
                    var instance = Activator.CreateInstance(validatorInfo.Type)
                        ?? throw new TypeLoadException($"Could not create type '{validatorInfo.Type.FullName}'");

                    var validator = (IRecordValidator)instance;
                    var entity = validatorInfo.Entity;

                    if (!string.IsNullOrEmpty(entity))
                    {
                        AddToDictionary(byEntity, entity, validator);

                        if(entityTypeLookup.TryGetValue(entity, out var entityType))
                            AddToDictionary(byType, entityType, validator);
                    }
                }
            }

            return new(byType, byEntity);
        }

        private static void AddToDictionary<TKey>(Dictionary<TKey, List<IRecordValidator>> dict, TKey key, IRecordValidator value) where TKey : notnull
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
