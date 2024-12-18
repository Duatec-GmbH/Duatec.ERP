using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleValidator : IRecordValidator<Article>
    {
        private static readonly PartNumberUniqueValidator _partNumberValidator = new();
        private static readonly NameFormatValidator _typeNumberValidator = new(Article.Entity, Article.Fields.TypeNumber);
        private static readonly NameFormatValidator _orderNumberValidator = new(Article.Entity, Article.Fields.OrderNumber);
        private static readonly NameFormatValidator _designationValidator = new(Article.Entity, Article.Fields.Designation);

        public List<ValidationError> ValidateOnCreate(Article record)
        {
            var errors = Validate(record);
            errors.AddRange(_partNumberValidator.ValidateOnCreate(record.PartNumber, Article.Fields.PartNumber));

            return errors;
        }

        public List<ValidationError> ValidateOnUpdate(Article record)
        {
            var errors = Validate(record);
            errors.AddRange(_partNumberValidator.ValidateOnUpdate(record.PartNumber, Article.Fields.PartNumber, record.Id!.Value));

            return errors;
        }

        private static List<ValidationError> Validate(Article record)
        {
            var result = _typeNumberValidator.Validate(record.TypeNumber, Article.Fields.TypeNumber);
            result.AddRange(_orderNumberValidator.Validate(record.OrderNumber, Article.Fields.OrderNumber));
            result.AddRange(_designationValidator.Validate(record.Designation, Article.Fields.Designation));

            return result;
        }
    }
}
