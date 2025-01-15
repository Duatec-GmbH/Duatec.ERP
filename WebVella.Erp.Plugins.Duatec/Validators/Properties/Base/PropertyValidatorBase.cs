using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Utilities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties.Base
{
    internal abstract class PropertyValidatorBase
    {
        protected readonly string _entity;
        protected readonly string _entityProperty;
        protected readonly string _entityPretty;
        protected readonly string _entityPropertyPretty;
        protected readonly bool _required;

        protected PropertyValidatorBase(string entity, string entityProperty, bool required)
        {
            _entity = entity;
            _entityProperty = entityProperty;
            _entityPretty = Text.FancyfySnakeCase(entity).FirstToUpper();
            _entityPropertyPretty = Text.FancyfySnakeCase(entityProperty);
            _required = required;
        }

        protected virtual List<ValidationError> ValidateFormat(string value, string formField)
        {
            var result = new List<ValidationError>();
            if (_required && string.IsNullOrWhiteSpace(value))
                result.Add(new ValidationError(_entityProperty, $"{_entityPropertyPretty.FirstToUpper()} is required"));

            if (value.Any(c => !CharIsAllowed(c)))
            {
                var invalidCharString = Util.Text.InvalidCharacters(value, CharIsAllowed);
                result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not contain invalid characters {invalidCharString}"));
            }
            return result;
        }

        protected abstract bool CharIsAllowed(char c);
    }
}
