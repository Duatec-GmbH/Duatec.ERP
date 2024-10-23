using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ArticleTypeValidator : IRecordValidator
    {
        private static readonly NameUniqueValidator _labelValidator = new(ArticleType.Entity, ArticleType.Label);
        private static readonly NameFormatValidator _unitValidator = new(ArticleType.Entity, ArticleType.Unit);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var label = record[ArticleType.Label] as string ?? string.Empty;
            var unit = record[ArticleType.Unit] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(label, ArticleType.Label);
            var unitErrors = _unitValidator.ValidateOnCreate(unit, ArticleType.Unit);

            result.AddRange(unitErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var label = record[ArticleType.Label] as string ?? string.Empty;
            var unit = record[ArticleType.Unit] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(label, ArticleType.Label, id);
            var unitErrors = _unitValidator.ValidateOnUpdate(unit, ArticleType.Unit, id);

            result.AddRange(unitErrors);
            return result;
        }
    }
}
