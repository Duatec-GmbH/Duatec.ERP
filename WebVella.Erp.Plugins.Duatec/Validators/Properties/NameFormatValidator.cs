using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class NameFormatValidator : PropertyValidatorBase
    {
        public NameFormatValidator(string entity, string entityProperty)
            : base(entity, entityProperty)
        { }

        protected override bool CharIsAllowed(char c)
        {
            return char.IsLetterOrDigit(c)
                || c >= ' ' && c <= '~';
        }

        protected override List<ValidationError> ValidateFormat(string value, string formField)
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
