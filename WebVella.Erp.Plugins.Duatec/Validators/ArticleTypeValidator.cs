using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleTypeValidator : IRecordValidator<ArticleType>
    {
        private static readonly NameUniqueValidator _labelValidator = new(ArticleType.Entity, ArticleType.Fields.Label);
        private static readonly NameFormatValidator _unitValidator = new(ArticleType.Entity, ArticleType.Fields.Unit);

        public List<ValidationError> ValidateOnCreate(ArticleType record)
        {
            var result = _labelValidator.ValidateOnCreate(record.Label, ArticleType.Fields.Label);
            var unitErrors = _unitValidator.Validate(record.Unit, ArticleType.Fields.Unit);

            result.AddRange(unitErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(ArticleType record)
        {
            var id = record.Id!.Value;

            var result = _labelValidator.ValidateOnUpdate(record.Label, ArticleType.Fields.Label, id);
            var unitErrors = _unitValidator.Validate(record.Unit, ArticleType.Fields.Unit);

            result.AddRange(unitErrors);
            return result;
        }
    }
}
