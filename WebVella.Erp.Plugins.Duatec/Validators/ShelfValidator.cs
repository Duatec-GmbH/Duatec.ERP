using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ShelfValidator : IRecordValidator
    {
        private static readonly NameUniqueValidator _labelValidator = new(Shelf.Entity, Shelf.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var designation = record[Shelf.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(designation, Shelf.Designation);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var designation = record[Shelf.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(designation, Shelf.Designation, id);

            return result;
        }
    }
}
