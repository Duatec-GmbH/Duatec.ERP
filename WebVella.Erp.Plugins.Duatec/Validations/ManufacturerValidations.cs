using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class ManufacturerValidations
    {
        public static bool ShortNameFormatIsValid(string shortName, string formField, List<ValidationError> validationErrors)
        {
            var result = true;
            if (shortName.Length == 0)
            {
                validationErrors.Add(new ValidationError(formField, "Manufacturer short name must not be empty"));
                return false;
            }
            if(shortName.Any(char.IsWhiteSpace))
            {
                result = false;
                validationErrors.Add(new ValidationError(formField, "Manufacturer short name must not contain any whitespace character"));
            }
            if (shortName.Where(c => !char.IsWhiteSpace(c)).Any(c => !IsValidShortNameChar(c)))
            {
                result = false;
                var invalidCharString = Common.InvalidCharacters(shortName, IsValidShortNameChar);
                validationErrors.Add(new ValidationError(formField, $"Manufacturer short name must not contain invalid characters {invalidCharString}"));
            }
            return result;
        }

        public static bool ManufacturerExists(string shortName, string formField, List<ValidationError> validationErrors)
        {
            if (Db.GetManufacturerIdByShortName(shortName) == null)
            {
                validationErrors.Add(new ValidationError(formField, $"Manufacturer with short name '{shortName}' does not exist"));
                return false;
            }
            return true;
        }

        private static bool IsValidShortNameChar(char c)
        {
            return c >= 'A' && c <= 'Z'
                || c >= '0' && c <= '9'
                || c == '-'
                || c == '+'
                || c == '_';
        }
    }
}
