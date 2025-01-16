using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = ArticleType.Fields;

    [TypedValidator(Entity)]
    internal class ArticleTypeValidator : IRecordValidator<ArticleType>
    {
        const string Entity = ArticleType.Entity;
        private static readonly NameUniqueValidator _labelValidator = new(Entity, Fields.Label);
        private static readonly NameFormatValidator _unitValidator = new(Entity, Fields.Unit, true);

        public List<ValidationError> ValidateOnCreate(ArticleType record)
        {
            var result = _labelValidator.ValidateOnCreate(record.Label, Fields.Label);
            var unitErrors = _unitValidator.Validate(record.Unit, Fields.Unit);

            result.AddRange(unitErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(ArticleType record)
        {
            var id = record.Id!.Value;

            var result = _labelValidator.ValidateOnUpdate(record.Label, Fields.Label, id);
            var unitErrors = _unitValidator.Validate(record.Unit, Fields.Unit);

            result.AddRange(unitErrors);
            return result;
        }

        public List<ValidationError> ValidateOnDelete(ArticleType record)
            => [];
    }
}
