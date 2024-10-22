using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleValidator : IValidator
    {
        private static readonly PartNumberValidator _partNumberValidator = new();

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var partNumber = record[Article.PartNumber] as string ?? string.Empty;
            return _partNumberValidator.ValidateOnCreate(partNumber, Article.PartNumber);
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var partNumber = record[Article.PartNumber] as string ?? string.Empty;
            return _partNumberValidator.ValidateOnUpdate(partNumber, Article.PartNumber, id);
        }
    }
}
