using System.Reflection;
using WebVella.Erp.Plugins.Duatec.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal class ValidatorFactory
    {
        private static Dictionary<Type, List<object>>? _validators = null;

        public static IEnumerable<IRecordValidator<T>> GetValidators<T>() where T : TypedEntityRecordWrapper, new()
        {
            if (Validators.TryGetValue(typeof(T), out var l) && l.Count > 0)
                return l.Select(obj => (IRecordValidator<T>)obj);

            return [];
        }

        private static Dictionary<Type, List<object>> Validators
        {
            get
            {
                if (_validators == null)
                {
                    var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(a => a.GetTypes())
                        .Where(t => t.GetCustomAttribute<ValidatorAttribute>() != null)
                        .Select(t => new { Type = t, Attribute = t.GetCustomAttribute<ValidatorAttribute>()! });

                    _validators = new(512);

                    foreach (var tuple in types)
                    {
                        var validator = Activator.CreateInstance(tuple.Type)
                            ?? throw new TypeLoadException($"Could not create type '{tuple.Type.FullName}'");

                        var targetType = tuple.Attribute.TargetType;

                        if (_validators.TryGetValue(targetType, out var validatorsList))
                            validatorsList.Add(validator);
                        else
                        {
                            validatorsList = [validator];
                            _validators.Add(targetType, validatorsList);
                        }
                    }

                }
                return _validators;
            }
        }
    }
}
