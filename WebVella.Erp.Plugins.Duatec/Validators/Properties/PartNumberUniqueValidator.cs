using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class PartNumberUniqueValidator : NameUniqueValidator
    {
        private static readonly ShortNameFormatValidator _shortNameValidator = new();
        private static readonly string _manufacturer = Text.FancyfySnakeCase(Manufacturer.Entity);
        private static readonly string _manufacturerShortName = Text.FancyfySnakeCase(Manufacturer.ShortName);

        public PartNumberUniqueValidator() 
            : base(Article.Entity, Article.PartNumber)
        { }

        public override List<ValidationError> ValidateOnCreate(string value, string formField)
        {
            var result = base.ValidateOnCreate(value, formField);
            result.AddRange(Validate(value, formField));
            return result;
        }

        public override List<ValidationError> ValidateOnUpdate(string value, string formField, Guid id)
        {
            var result = base.ValidateOnUpdate(value, formField, id);
            result.AddRange(Validate(value, formField));
            return result;
        }

        private List<ValidationError> Validate(string value, string formField)
        {
            var result = new List<ValidationError>();

            if (value.IndexOf('.') < 1)
                result.Add(new ValidationError(formField, $"{_entityPretty} {_entityPropertyPretty} must contain {_manufacturer}s {_manufacturerShortName} followed by '.'"));

            if (result.Count == 0)
            {
                var shortName = value[..value.IndexOf('.')];
                var shortNameErrors = _shortNameValidator.Validate(shortName, formField);
                result.AddRange(shortNameErrors);

                if (shortNameErrors.Count == 0)
                {
                    if (shortNameErrors.Count == 0 && !Manufacturer.FindId(shortName).HasValue)
                        result.Add(new ValidationError(formField, $"{_manufacturer} with {_manufacturerShortName} '{shortName}' does not exist"));

                    if (DataPortal.GetArticleByPartNumber(value) != null)
                        result.Add(new ValidationError(formField, $"{_entityPretty} with {_entityPropertyPretty} '{value}' is an EPLAN article"));
                }
            }

            return result;
        }
    }
}
