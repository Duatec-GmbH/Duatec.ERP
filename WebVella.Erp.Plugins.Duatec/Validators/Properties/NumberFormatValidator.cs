using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Validators.Properties.Base;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class NumberFormatValidator : PropertyValidatorBase
    {
        protected readonly bool _isInteger;
        protected readonly bool _mustBePositive;
        protected readonly bool _zeroAllowed;

        public NumberFormatValidator(string entity, string entityProperty, bool isInteger = false, bool mustBePositive = false, bool zeroAllowed = true)
            : base(entity, entityProperty)
        {
            _isInteger = isInteger;
            _mustBePositive = mustBePositive;
            _zeroAllowed = zeroAllowed;
        }

        protected override bool CharIsAllowed(char c)
        {
            return c >= '0' && c <= '9'
                || c == '+'
                || c == '.'
                || c == ','
                || c == '-';
        }

        public List<ValidationError> Validate(string value, string formField)
        {
            var result = base.ValidateFormat(value, formField);

            if (!decimal.TryParse(value, out var number))
                result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} is not a number"));

            if(result.Count == 0)
            {
                if (_isInteger && number % 1 != 0)
                    result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} is expected to be an integer"));

                if (number == 0 && !_zeroAllowed)
                    result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must be positive"));
                if (number < 0 && _mustBePositive)
                    result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not be negative"));
            }
            return result;
        }
    }
}
