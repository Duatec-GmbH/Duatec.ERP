using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = Article.Fields;

    [TypedValidator(Entity)]
    public class ArticleValidator : IRecordValidator<Article>
    {
        const string Entity = Article.Entity;
        private static readonly PartNumberUniqueValidator _partNumberValidator = new();
        private static readonly NameFormatValidator _typeNumberValidator = new(Entity, Fields.TypeNumber, true);
        private static readonly NameFormatValidator _orderNumberValidator = new(Entity, Fields.OrderNumber, true);
        private static readonly NameFormatValidator _designationValidator = new(Entity, Fields.Designation, true);

        public List<ValidationError> ValidateOnCreate(Article record)
        {
            var errors = Validate(record);
            errors.AddRange(_partNumberValidator.ValidateOnCreate(record.PartNumber, Fields.PartNumber));

            return errors;
        }

        public List<ValidationError> ValidateOnUpdate(Article record)
        {
            var errors = Validate(record);
            errors.AddRange(_partNumberValidator.ValidateOnUpdate(record.PartNumber, Fields.PartNumber, record.Id!.Value));

            return errors;
        }

        public List<ValidationError> ValidateOnDelete(Article record)
            => [];

        private static List<ValidationError> Validate(Article record)
        {
            var result = _typeNumberValidator.Validate(record.TypeNumber, Fields.TypeNumber);
            result.AddRange(_orderNumberValidator.Validate(record.OrderNumber, Fields.OrderNumber));
            result.AddRange(_designationValidator.Validate(record.Designation, Fields.Designation));

            return result;
        }
    }
}
