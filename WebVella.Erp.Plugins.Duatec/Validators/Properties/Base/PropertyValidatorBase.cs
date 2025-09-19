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
            _entityPretty = Text.FancyfySnakeCase(entity);
            _entityPropertyPretty = Text.FancyfySnakeCase(entityProperty);
            _required = required;
        }

        protected virtual List<ValidationError> ValidateFormat(string value, string formField)
        {
            var result = new List<ValidationError>();
            if (_required && string.IsNullOrWhiteSpace(value))
                result.Add(new ValidationError(_entityProperty, ErrorMessage("is required")));

            if (value.Any(c => !CharIsAllowed(c)))
            {
                var invalidCharString = Util.Text.InvalidCharacters(value, CharIsAllowed);
                result.Add(new ValidationError(formField, ErrorMessage($"must not contain invalid characters {invalidCharString}")));
            }
            return result;
        }

        protected virtual bool CharIsAllowed(char c) => true;

        protected virtual string ErrorMessage(string message)
        {
            var result = string.Empty;

            if (!string.IsNullOrWhiteSpace(_entityPretty))
                result += $"{_entityPretty} ";

            if (!string.IsNullOrWhiteSpace(_entityPropertyPretty))
                result += $"{_entityPropertyPretty} ";

            return (result + message).FirstToUpper();
        }
    }
}
