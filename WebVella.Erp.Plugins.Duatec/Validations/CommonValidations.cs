using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class CommonValidations
    {
        public static string InvalidCharacters(string value, Predicate<char> isValid)
        {
            var invalidChars = value.Where(value => !isValid(value))
                .Order()
                .Distinct()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();

            if (invalidChars.Length == 0)
                return string.Empty;

            if (invalidChars.Length == 1)
                return $"'{invalidChars[0]}'";

            return $"{{ {string.Join(", ", invalidChars.Select(c => $"'{c}'")) }}}";
        }

        public static bool NameIsValid(string name, string formField, List<ValidationError> validationErrors, string who)
        {
            if (name.Length == 0)
            {
                validationErrors.Add(new ValidationError(formField, $"{who} must not be empty"));
                return false;
            }
            var result = true;
            if (char.IsWhiteSpace(name[0]))
            {
                result = false;
                validationErrors.Add(new ValidationError(formField, $"{who} must not start with whitespace characters"));
            }
            if (char.IsWhiteSpace(name[^1]))
            {
                result = false;
                validationErrors.Add(new ValidationError(formField, $"{who} must not end with whitespace characters"));
            }
            return result;
        }
    }
}
