using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class ArticleTypeValidations
    {
        public static bool LabelIsValid(string label, string formField, List<ValidationError> validationErrors)
        {
            if (!CommonValidations.NameIsValid(label, formField, validationErrors, "Article type label"))
                return false;

            if(ArticleType.FindId(label) != null)
            {
                validationErrors.Add(new ValidationError(formField, $"Article type with label '{label}' already exists."));
                return false;
            }
            return true;
        }

        public static bool UnitIsValid(string unit, string formField, List<ValidationError> validationErrors)
            => CommonValidations.NameIsValid(unit, formField, validationErrors, "Article type unit");
    }
}
