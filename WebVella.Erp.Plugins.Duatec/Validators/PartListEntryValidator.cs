using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (Guid? PartList, Guid? Article, string DeviceTag);

    internal class PartListEntryValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _deviceTagValidator = new(PartListEntry.Entity, PartListEntry.DeviceTag);

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
            var (partList, article, deviceTag) = GetArgs(record);

            var result = _deviceTagValidator.Validate(deviceTag, PartListEntry.DeviceTag);
            if (!partList.HasValue)
                result.Add(new ValidationError(PartListEntry.PartList, "Part list entry 'part list' is required"));
            if (!article.HasValue)
                result.Add(new ValidationError(PartListEntry.Article, "Part list entry 'article' is required"));
            if (partList.HasValue && article.HasValue && PartListEntry.Exists(partList.Value, article.Value, id))
                result.Add(new ValidationError(PartListEntry.Article, "Part list entry with the same article already exists within part list"));

            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[PartListEntry.PartList] as Guid?,
                record[PartListEntry.Article] as Guid?,
                record[PartListEntry.DeviceTag] as string ?? string.Empty);
        }
    }
}
