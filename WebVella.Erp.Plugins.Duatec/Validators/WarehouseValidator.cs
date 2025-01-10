using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = Warehouse.Fields;

    internal class WareHouseValidator : IRecordValidator<Warehouse>
    {
        const string Entity = Warehouse.Entity;
        private static readonly NameUniqueValidator _labelValidator = new(Entity, Fields.Designation);

        public List<ValidationError> ValidateOnCreate(Warehouse record)
            => _labelValidator.ValidateOnCreate(record.Designation, Fields.Designation);

        public List<ValidationError> ValidateOnUpdate(Warehouse record)
            => _labelValidator.ValidateOnUpdate(record.Designation, Fields.Designation, record.Id!.Value);

        public List<ValidationError> ValidateOnDelete(Warehouse record)
            => [];
    }
}
