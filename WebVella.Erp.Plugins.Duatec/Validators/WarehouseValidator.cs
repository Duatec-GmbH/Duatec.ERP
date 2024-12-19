using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class WareHouseValidator : IRecordValidator<Warehouse>
    {
        private static readonly NameUniqueValidator _labelValidator = new(Warehouse.Entity, Warehouse.Fields.Designation);

        public List<ValidationError> ValidateOnCreate(Warehouse record)
            => _labelValidator.ValidateOnCreate(record.Designation, Warehouse.Fields.Designation);

        public List<ValidationError> ValidateOnUpdate(Warehouse record)
            => _labelValidator.ValidateOnUpdate(record.Designation, Warehouse.Fields.Designation, record.Id!.Value);
    }
}
