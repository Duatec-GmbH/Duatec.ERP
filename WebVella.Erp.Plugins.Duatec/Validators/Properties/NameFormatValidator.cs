using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Validators.Properties.Base;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class NameFormatValidator : NameFormatValidatorBase
    {
        public NameFormatValidator(string entity, string entityProperty, bool required) 
            : base(entity, entityProperty, required)
        { }

        public virtual List<ValidationError> Validate(string value, string formField)
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

                result.AddRange(base.ValidateFormat(value, formField));
            }
            return result;
        }
    }
}
