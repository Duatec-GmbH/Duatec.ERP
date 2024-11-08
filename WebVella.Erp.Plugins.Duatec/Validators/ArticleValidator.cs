using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleValidator : IRecordValidator
    {
        private static readonly PartNumberUniqueValidator _partNumberValidator = new();
        private static readonly NameFormatValidator _typeNumberValidator = new(Article.Entity, Article.TypeNumber);
        private static readonly NameFormatValidator _orderNumberValidator = new(Article.Entity, Article.OrderNumber);
        private static readonly NameFormatValidator _designationValidator = new(Article.Entity, Article.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var partNumber = record[Article.PartNumber] as string ?? string.Empty;
            var typeNumber = record[Article.TypeNumber] as string ?? string.Empty;
            var orderNumber = record[Article.OrderNumber] as string ?? string.Empty;
            var designation = record[Article.Designation] as string ?? string.Empty;

            var errors = _partNumberValidator.ValidateOnCreate(partNumber, Article.PartNumber);
            errors.AddRange(_typeNumberValidator.ValidateOnCreate(typeNumber, Article.TypeNumber));
            errors.AddRange(_orderNumberValidator.ValidateOnCreate(orderNumber, Article.OrderNumber));
            errors.AddRange(_designationValidator.ValidateOnCreate(designation, Article.Designation));
            return errors;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var partNumber = record[Article.PartNumber] as string ?? string.Empty;
            var typeNumber = record[Article.TypeNumber] as string ?? string.Empty;
            var orderNumber = record[Article.OrderNumber] as string ?? string.Empty;
            var designation = record[Article.Designation] as string ?? string.Empty;

            var errors = _partNumberValidator.ValidateOnUpdate(partNumber, Article.PartNumber, id);
            errors.AddRange(_typeNumberValidator.ValidateOnUpdate(typeNumber, Article.TypeNumber, id));
            errors.AddRange(_orderNumberValidator.ValidateOnUpdate(orderNumber, Article.OrderNumber, id));
            errors.AddRange(_designationValidator.ValidateOnUpdate(designation, Article.Designation, id));

            return errors;
        }
    }
}
