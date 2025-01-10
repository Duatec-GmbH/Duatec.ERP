using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class PartListEntryValidator : IRecordValidator<PartListEntry>
    {
        public List<ValidationError> ValidateOnCreate(PartListEntry record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(PartListEntry record)
        {
            var result = new List<ValidationError>();
            if (!record.Id.HasValue)
                result.Add(new ValidationError(string.Empty, $"Part list entry 'id' is required"));

            result.AddRange(Validate(record, record.Id));
            return result;
        }

        private static List<ValidationError> Validate(PartListEntry record, Guid? id)
        {
            var result = new List<ValidationError>();
            if (record.PartList == Guid.Empty)
                result.Add(new ValidationError(PartListEntry.Fields.PartList, "Part list entry 'part list' is required"));
            if (record.Article == Guid.Empty)
                result.Add(new ValidationError(PartListEntry.Fields.Article, "Part list entry 'article' is required"));

            if (result.Count == 0 && RepositoryService.PartListRepository.EntryExistsWithinList(record.PartList, record.Article, id))
                result.Add(new ValidationError(PartListEntry.Fields.Article, "Part list entry with the same article already exists within part list"));

            if (record.Article != Guid.Empty)
            {
                var type = RepositoryService.ArticleRepository.FindTypeByArticleId(record.Article);
                var amountValidator = GetNumberFormatValidator(PartListEntry.Fields.Amount, type);

                result.AddRange(amountValidator.Validate(record.Amount, PartListEntry.Fields.Amount));
            }

            return result;
        }

        private static NumberFormatValidator GetNumberFormatValidator(string entityProperty, ArticleType? type)
        {
            var isInteger = type?.IsInteger is true;
            return new NumberFormatValidator(PartListEntry.Entity, entityProperty, isInteger, true);
        }
    }
}
