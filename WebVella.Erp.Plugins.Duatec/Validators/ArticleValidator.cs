using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (string PartNumber, string TypeNumber, string OrderNumber, string Designation);

    internal class ArticleValidator : IRecordValidator
    {
        private static readonly PartNumberUniqueValidator _partNumberValidator = new();
        private static readonly NameFormatValidator _typeNumberValidator = new(Article.Entity, Article.TypeNumber);
        private static readonly NameFormatValidator _orderNumberValidator = new(Article.Entity, Article.OrderNumber);
        private static readonly NameFormatValidator _designationValidator = new(Article.Entity, Article.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var args = GetArgs(record);

            var errors = Validate(args);
            errors.AddRange(_partNumberValidator.ValidateOnCreate(args.PartNumber, Article.PartNumber));

            return errors;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var args = GetArgs(record);

            var errors = Validate(args);
            errors.AddRange(_partNumberValidator.ValidateOnUpdate(args.PartNumber, Article.PartNumber, id));

            return errors;
        }

        private static List<ValidationError> Validate(Args args)
        {
            var (_, typeNumber, orderNumber, designation) = args;

            var result = _typeNumberValidator.Validate(typeNumber, Article.TypeNumber);
            result.AddRange(_orderNumberValidator.Validate(orderNumber, Article.OrderNumber));
            result.AddRange(_designationValidator.Validate(designation, Article.Designation));

            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[Article.PartNumber] as string ?? string.Empty,
                record[Article.TypeNumber] as string ?? string.Empty,
                record[Article.OrderNumber] as string ?? string.Empty,
                record[Article.Designation] as string ?? string.Empty);
        }
    }
}
