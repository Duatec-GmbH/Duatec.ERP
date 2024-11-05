using System.Numerics;
using WebVella.Erp.Exceptions;

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
                || c == '.' && !_isInteger
                || c == '-' && !_mustBePositive;
        }

        protected override List<ValidationError> ValidateFormat(string value, string formField)
        {
            var result = base.ValidateFormat(value, formField);
            if(result.Count == 0)
            {
                if (_isInteger)
                {
                    if (!BigInteger.TryParse(value, out var i))
                        result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must be an integer"));
                    else if (i < 0 && _mustBePositive)
                        result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not be negative"));
                    else if (i == 0 && !_zeroAllowed)
                        result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not be '0'"));
                }
                else
                {
                    if (!decimal.TryParse(value, out var d))
                        result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must be a number"));
                    else if(d < 0 && _mustBePositive)
                        result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not be negative"));
                    else if (d == 0 && !_zeroAllowed)
                        result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must not be '0'"));
                }
            }
            return result;
        }
    }
}
