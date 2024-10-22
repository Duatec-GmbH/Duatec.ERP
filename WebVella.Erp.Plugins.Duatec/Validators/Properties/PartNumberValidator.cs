using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class PartNumberValidator : UniqueNameValidator
    {
        private static readonly ShortNameFormatValidator _shortNameValidator = new();
        private static readonly string manufacturer = Text.FancyfySnakeCase(Manufacturer.Entity);
        private static readonly string manufacturerShortName = Text.FancyfySnakeCase(Manufacturer.ShortName);

        public PartNumberValidator() 
            : base(Article.Entity, Article.PartNumber)
        { }

        public override List<ValidationError> ValidateOnCreate(string value, string formField)
        {
            var result = base.ValidateOnCreate(value, formField);
            List<ValidationError> validation(string shortName) 
                => _shortNameValidator.ValidateOnCreate(shortName, formField);

            Validate(value, formField, result, validation);
            return result;
        }

        public override List<ValidationError> ValidateOnUpdate(string value, string formField, Guid id)
        {
            var result = base.ValidateOnUpdate(value, formField, id);
            List<ValidationError> validation(string shortName) 
                => _shortNameValidator.ValidateOnUpdate(shortName, formField, id);

            Validate(value, formField, result, validation);
            return result;
        }

        private void Validate(string value, string formField, List<ValidationError> result, Func<string, List<ValidationError>> validation)
        {
            if (value.IndexOf('.') < 1)
                result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must contain {manufacturer}s {manufacturerShortName} followed by '.'"));

            if (result.Count == 0)
            {
                var shortName = value[..value.IndexOf('.')];
                var shortNameErrors = validation(shortName);
                result.AddRange(shortNameErrors);

                if (shortNameErrors.Count == 0)
                {
                    if (shortNameErrors.Count == 0 && !Manufacturer.WithShortNameExists(shortName))
                        result.Add(new ValidationError(formField, $"{manufacturer} with {manufacturerShortName} '{shortName}' does not exist"));

                    if (EplanDataPortal.GetArticleByPartNumber(value) != null)
                        result.Add(new ValidationError(formField, $"{_entityPretty} with {_entityPropertyPretty} '{value}' is an EPLAN article"));
                }
            }
        }
    }
}
