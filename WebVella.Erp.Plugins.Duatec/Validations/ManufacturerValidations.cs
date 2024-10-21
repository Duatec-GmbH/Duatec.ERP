using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;

namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class ManufacturerValidations
    {
        public static void ValidateName(string name, string formField, List<ValidationError> validationErrors)
        {
            if (NameFormatIsValid(name, formField, validationErrors))
            {
                if (Manufacturer.WithNameExists(name))
                    validationErrors.Add(new ValidationError(formField, $"A manufacturer with name '{name}' already exists."));
                if (EplanDataPortal.GetManufacturers().Exists(m => name.Equals(m.Name, StringComparison.OrdinalIgnoreCase)))
                    validationErrors.Add(new ValidationError(formField, $"A manufacturer with name '{name}' is listed in EPLAN use EPLAN import instead"));
            }
        }

        public static void ValidateShortName(string shortName, string formField, List<ValidationError> validationErrors)
        {
            if (ShortNameFormatIsValid(shortName, formField, validationErrors))
            {
                if (Manufacturer.WithShortNameExists(shortName))
                    validationErrors.Add(new ValidationError(formField, $"A manufacturer with short name '{shortName}' already exists"));
                if (EplanDataPortal.GetManufacturers().Exists(m => shortName.Equals(m.ShortName, StringComparison.OrdinalIgnoreCase)))
                    validationErrors.Add(new ValidationError(formField, $"A manufacturer with short name '{shortName}' is listed in EPLAN use EPLAN import instead"));
            }
        }

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
                var invalidCharString = CommonValidations.InvalidCharacters(shortName, IsValidShortNameChar);
                validationErrors.Add(new ValidationError(formField, $"Manufacturer short name must not contain invalid characters {invalidCharString}"));
            }
            return result;
        }

        public static bool NameFormatIsValid(string name, string formField, List<ValidationError> validationErrors)
        {
            var result = CommonValidations.NameIsValid(name, formField, validationErrors, "Manufacturer name");

            if(name.Where(c => !char.IsWhiteSpace(c)).Any(c => !IsValidNameChar(c)))
            {
                result = false;
                var invalidCharString = CommonValidations.InvalidCharacters(name, IsValidNameChar);
                validationErrors.Add(new ValidationError(formField, $"Manufacturer name must not contain invalid characters {invalidCharString}"));
            }
            return result;
        }

        public static bool ManufacturerWithShortNameExists(string shortName, string formField, List<ValidationError> validationErrors)
        {
            if (Manufacturer.FindId(shortName) == null)
            {
                validationErrors.Add(new ValidationError(formField, $"Manufacturer with short name '{shortName}' does not exist"));
                return false;
            }
            return true;
        }

        private static bool IsValidNameChar(char c)
        {
            return char.IsLetterOrDigit(c)
                || c >= ' ' && c <= '~';
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
