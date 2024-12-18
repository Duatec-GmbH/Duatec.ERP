using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class WareHouseValidator : IRecordValidator<EntityRecord>
    {
        private static readonly NameUniqueValidator _labelValidator = new(Warehouse.Entity, Warehouse.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var designation = record[Warehouse.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(designation, Warehouse.Designation);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var designation = record[Warehouse.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(designation, Warehouse.Designation, id);

            return result;
        }
    }
}
