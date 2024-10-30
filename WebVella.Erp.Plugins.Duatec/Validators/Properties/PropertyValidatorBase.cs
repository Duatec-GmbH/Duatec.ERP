using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal abstract class PropertyValidatorBase
    {
        protected readonly string _entity;
        protected readonly string _entityProperty;
        protected readonly string _entityPretty;
        protected readonly string _entityPropertyPretty;

        public PropertyValidatorBase(string entity, string entityProperty)
        {
            _entity = entity;
            _entityProperty = entityProperty;
            _entityPretty = Text.FancyfySnakeCaseStartWithUpper(entity);
            _entityPropertyPretty = Text.FancyfySnakeCase(entityProperty);
        }

        public virtual List<ValidationError> ValidateOnCreate(string value, string formField)
            => ValidateFormat(value, formField);

        public virtual List<ValidationError> ValidateOnUpdate(string value, string formField, Guid id)
            => ValidateFormat(value, formField);

        protected virtual List<ValidationError> ValidateFormat(string value, string formField)
        {
            var result = new List<ValidationError>();

            if (value.Any(c => !CharIsAllowed(c)))
            {
                var invalidCharString = Text.InvalidCharacters(value, CharIsAllowed);
                result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not contain invalid characters {invalidCharString}"));
            }
            return result;
        }

        protected abstract bool CharIsAllowed(char c);
    }
}
