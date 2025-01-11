using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.TypedRecords.Attributes;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = PartListEntry.Fields;

    [TypedValidator(Entity)]
    internal class PartListEntryValidator : IRecordValidator<PartListEntry>
    {
        const string Entity = PartListEntry.Entity;

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

        public List<ValidationError> ValidateOnDelete(PartListEntry record)
            => [];

        private static List<ValidationError> Validate(PartListEntry record, Guid? id)
        {
            var result = new List<ValidationError>();
            if (record.PartList == Guid.Empty)
                result.Add(new ValidationError(Fields.PartList, "Part list entry 'part list' is required"));
            if (record.Article == Guid.Empty)
                result.Add(new ValidationError(Fields.Article, "Part list entry 'article' is required"));

            if (result.Count == 0 && RepositoryService.PartListRepository.EntryExistsWithinList(record.PartList, record.Article, id))
                result.Add(new ValidationError(Fields.Article, "Part list entry with the same article already exists within part list"));

            if (record.Article != Guid.Empty)
            {
                var type = RepositoryService.ArticleRepository.FindTypeByArticleId(record.Article);
                var amountValidator = GetNumberFormatValidator(Fields.Amount, type);

                result.AddRange(amountValidator.Validate(record.Amount, Fields.Amount));
            }

            return result;
        }

        private static NumberFormatValidator GetNumberFormatValidator(string entityProperty, ArticleType? type)
        {
            var isInteger = type?.IsInteger is true;
            return new NumberFormatValidator(Entity, entityProperty, isInteger, true);
        }
    }
}
