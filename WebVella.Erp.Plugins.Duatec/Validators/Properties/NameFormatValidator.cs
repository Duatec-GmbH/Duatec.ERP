using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class NameFormatValidator
    {
        protected readonly string _entity;
        protected readonly string _entityProperty;
        protected readonly string _entityPretty;
        protected readonly string _entityPropertyPretty;

        public NameFormatValidator(string entity, string entityProperty)
        {
            _entity = entity;
            _entityProperty = entityProperty;
            _entityPretty = Text.FancyfySnakeCaseStartUpper(entity);
            _entityPropertyPretty = Text.FancyfySnakeCase(entityProperty);
        }

        protected virtual bool CharIsAllowed(char c)
        {
            return char.IsLetterOrDigit(c)
                || c >= ' ' && c <= '~';
        }

        public virtual List<ValidationError> ValidateOnCreate(string value, string formField)
            => ValidateFormat(value, formField);

        public virtual List<ValidationError> ValidateOnUpdate(string value, string formField, Guid id)
            => ValidateFormat(value, formField);

        protected virtual List<ValidationError> ValidateFormat(string value, string formField)
        {
            var result = new List<ValidationError>();

            if (value.Length == 0)
                result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not be empty"));
            else
            {
                if (char.IsWhiteSpace(value[0]))
                    result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not start with whitespace characters"));
                if (char.IsWhiteSpace(value[^1]))
                    result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not end with whitespace characters"));
                if (value.Any(c => !CharIsAllowed(c)))
                {
                    var invalidCharString = InvalidCharacters(value);
                    result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not contain invalid characters {invalidCharString}"));
                }
            }
            return result;
        }

        protected string InvalidCharacters(string value)
        {
            var invalidChars = value.Where(value => !CharIsAllowed(value))
                .Order()
                .Distinct()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();

            if (invalidChars.Length == 0)
                return string.Empty;

            if (invalidChars.Length == 1)
                return $"'{invalidChars[0]}'";

            return $"{{ {string.Join(", ", invalidChars.Select(c => $"'{c}'"))}}}";
        }
    }
}
