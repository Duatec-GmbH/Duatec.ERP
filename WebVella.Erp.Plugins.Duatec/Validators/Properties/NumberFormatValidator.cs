using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class NumberFormatValidator
    {
        protected readonly string _entity;
        protected readonly string _entityProperty;
        protected readonly string _entityPretty;
        protected readonly string _entityPropertyPretty;
        protected readonly bool _isInteger;
        protected readonly bool _mustBePositive;
        protected readonly bool _zeroAllowed;

        public NumberFormatValidator(string entityProperty, bool isInteger = false, bool mustBePositive = false, bool zeroAllowed = true)
            : this(string.Empty, entityProperty, isInteger, mustBePositive, zeroAllowed)
        { }

        public NumberFormatValidator(string entity, string entityProperty, bool isInteger = false, bool mustBePositive = false, bool zeroAllowed = true)
        {
            _entity = entity;
            _entityProperty = entityProperty;
            _isInteger = isInteger;
            _mustBePositive = mustBePositive;
            _zeroAllowed = zeroAllowed;

            _entityPretty = Text.FancyfySnakeCase(entity);
            _entityPropertyPretty = Text.FancyfySnakeCase(entityProperty);
        }

        public List<ValidationError> Validate(decimal value, string formField = "")
        {
            if (value == decimal.MinValue)
                return [new ValidationError(formField, ErrorMessage("must not be empty"))];

            var result = new List<ValidationError>();
            if (_isInteger && value % 1 != 0)
                result.Add(new ValidationError(formField, ErrorMessage("is expected to be an integer")));
            if (value == 0 && !_zeroAllowed)
                result.Add(new ValidationError(formField, ErrorMessage("must be positive")));
            if (value < 0 && _mustBePositive)
                result.Add(new ValidationError(formField, ErrorMessage("must not be negative")));
            
            return result;
        }

        private string ErrorMessage(string message)
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
