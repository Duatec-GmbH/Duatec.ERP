using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class ArticleValidations
    {
        public static string ExtractManufacturerShortName(string partNumber)
            => partNumber[..partNumber.IndexOf('.')];

        public static bool PartNumberFormatIsValid(string partNumber, string formField, List<ValidationError> validationErrors)
        {
            if (partNumber.Length == 0)
            {
                validationErrors.Add(new ValidationError(formField, "Article part number must not be empty"));
                return false;
            }

            var result = true;
            if (char.IsWhiteSpace(partNumber[0]))
            {
                result = false;
                validationErrors.Add(new ValidationError(formField, "Article part number must not start with white space"));
            }
            if (char.IsWhiteSpace(partNumber[^1]))
            {
                result = false;
                validationErrors.Add(new ValidationError(formField, "Article part number must not end with white space"));
            }
            if (partNumber.Where(c => !char.IsWhiteSpace(c)).Any(c => !IsValidPartNumberCharacter(c)))
            {
                result = false;
                var invalidChars = Common.InvalidCharacters(partNumber, IsValidPartNumberCharacter);
                validationErrors.Add(new ValidationError(formField, "Article part number contains invalid characters"));
            }
            if (partNumber.IndexOf('.') < 1)
            {
                validationErrors.Add(new ValidationError(formField, "Article part number must contain manufacturers short name followed by '.'"));
                return false;
            }
            var manufacturerShortName = partNumber[..partNumber.IndexOf('.')];

            if (!ManufacturerValidations.ShortNameFormatIsValid(manufacturerShortName, formField, validationErrors))
                return false;

            return result;
        }

        public static bool PartNumberIsNotTaken(string partNumber, string formField, List<ValidationError> validationErrors)
        {
            if (Db.GetArticleIdByPartNumber(partNumber) != null)
                validationErrors.Add(new ValidationError(formField, $"Article with part number '{partNumber}' already exists"));
            else if (EplanDataPortal.GetArticleByPartNumber(partNumber) != null)
                validationErrors.Add(new ValidationError(formField, $"Article with part number '{partNumber}' is an EPLAN article use EPLAN import instead"));
            else return true;

            return false;
        }

        private static bool IsValidPartNumberCharacter(char c)
        {
            return c >= ' ' && c <= '~';
        }
    }
}
