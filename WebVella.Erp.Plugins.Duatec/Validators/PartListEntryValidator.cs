using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (Guid? PartList, Guid? Article, string DeviceTag, decimal Amount, decimal ProvidedAmount);

    internal class PartListEntryValidator : IRecordValidator
    {
        public List<ValidationError> ValidateOnCreate(EntityRecord record)
            => Validate(record, null);


        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var result = new List<ValidationError>();
            if (record["id"] is Guid id)
                result.AddRange(Validate(record, id));
            else
            {
                result.Add(new ValidationError(string.Empty, $"Part list entry 'id' is required"));
                result.AddRange(Validate(record, null));
            }
            return result;
        }

        private static List<ValidationError> Validate(EntityRecord record, Guid? id)
        {
            var (partList, article, _, amount, providedAmount) = GetArgs(record);

            var result = new List<ValidationError>();
            if (!partList.HasValue)
                result.Add(new ValidationError(PartListEntry.PartList, "Part list entry 'part list' is required"));
            if (!article.HasValue)
                result.Add(new ValidationError(PartListEntry.Article, "Part list entry 'article' is required"));
            if (partList.HasValue && article.HasValue && PartListEntry.Exists(partList.Value, article.Value, id))
                result.Add(new ValidationError(PartListEntry.Article, "Part list entry with the same article already exists within part list"));
            if (providedAmount > amount)
                result.Add(new ValidationError(PartListEntry.ProvidedAmount, "Part list entry provided amount can not be greater than amount"));

            if (article.HasValue)
            {
                var type = ArticleType.FromArticle(article.Value);
                var amountValidator = GetNumberFormatValidator(PartListEntry.Amount, type);
                var providedAmountValidator = GetNumberFormatValidator(PartListEntry.ProvidedAmount, type);

                result.AddRange(amountValidator.Validate(amount.ToString(), PartListEntry.Amount));
                result.AddRange(providedAmountValidator.Validate(providedAmount.ToString(), PartListEntry.ProvidedAmount));
            }

            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[PartListEntry.PartList] as Guid?,
                record[PartListEntry.Article] as Guid?,
                record[PartListEntry.DeviceTag] as string ?? string.Empty,
                record[PartListEntry.Amount] as decimal? ?? 0m,
                record[PartListEntry.ProvidedAmount] as decimal? ?? 0m);
        }

        private static NumberFormatValidator GetNumberFormatValidator(string entityProperty, EntityRecord? type)
        {
            var isInteger = type == null || (bool)type[ArticleType.IsInteger];
            return new NumberFormatValidator(PartListEntry.Entity, entityProperty, isInteger, true);
        }
    }
}
