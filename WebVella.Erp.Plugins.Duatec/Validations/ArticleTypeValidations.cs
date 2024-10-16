using WebVella.Erp.Exceptions;

namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class ArticleTypeValidations
    {
        public static IEnumerable<string> GetLabelValidationErrors(string label)
        {
            var res = new List<ValidationError>();
            LabelIsValid(label, string.Empty, res);
            return res.Select(ve => ve.Message);
        }

        public static IEnumerable<string> GetUnitValidationErrors(string unit)
        {
            var res = new List<ValidationError>();
            UnitIsValid(unit, string.Empty, res);
            return res.Select(ve => ve.Message);
        }

        public static bool LabelIsValid(string label, string formField, List<ValidationError> validationErrors)
        {
            if (!Common.NameIsValid(label, formField, validationErrors, "Article type label"))
                return false;

            if(Db.GetArticleTypeByLabel(label) != null)
            {
                validationErrors.Add(new ValidationError(formField, $"Article type with label '{label}' already exists."));
                return false;
            }
            return true;
        }

        public static bool UnitIsValid(string unit, string formField, List<ValidationError> validationErrors)
            => Common.NameIsValid(unit, formField, validationErrors, "Article type unit");
    }
}
