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
            => Validate(record);


        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var result = Validate(record);
            if (record["id"] is not Guid)
                result.Add(new ValidationError(string.Empty, $"Part list entry 'id' is required"));
            return result;
        }

        private static List<ValidationError> Validate(EntityRecord record)
        {
            var (partList, article, deviceTag) = GetArgs(record);

            var result = _deviceTagValidator.Validate(deviceTag, PartListEntry.DeviceTag);
            if (!partList.HasValue)
                result.Add(new ValidationError(PartListEntry.PartList, "Part list entry 'part list' is required"));
            if (!article.HasValue)
                result.Add(new ValidationError(PartListEntry.Article, "Part list entry 'article' is required"));
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
