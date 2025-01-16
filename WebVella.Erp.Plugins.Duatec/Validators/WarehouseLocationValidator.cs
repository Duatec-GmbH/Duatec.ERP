using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = WarehouseLocation.Fields;

    [TypedValidator(Entity)]
    internal class WarehouseLocationValidator : IRecordValidator<WarehouseLocation>
    {
        const string Entity = WarehouseLocation.Entity;
        private static readonly NameFormatValidator _labelValidator = new(Entity, Fields.Designation, true);
        private static readonly string _warehousePretty = Text.FancyfySnakeCase(Warehouse.Entity);
        private static readonly string _entityPretty = Text.FancyfySnakeCase(Entity).FirstToUpper();
        private static readonly string _entityPropertyPretty = Text.FancyfySnakeCase(Fields.Designation);

        public List<ValidationError> ValidateOnCreate(WarehouseLocation record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(WarehouseLocation record)
            => Validate(record, record.Id!.Value);

        public List<ValidationError> ValidateOnDelete(WarehouseLocation record)
            => [];

        private static List<ValidationError> Validate(WarehouseLocation record, Guid? id)
        {
            var result = _labelValidator.Validate(record.Designation, Fields.Designation);

            if (record.Warehouse == Guid.Empty)
                result.Add(new ValidationError(Fields.Warehouse, $"Please select a {_warehousePretty}"));

            if (result.Count == 0 && RepositoryService.WarehouseRepository.EntryExistsWithinWarehouse(record.Warehouse, record.Designation, id))
            {
                var message = $"{_entityPretty} {_entityPropertyPretty} '{record.Designation}' already exists within selected {_warehousePretty}";
                result.Add(new ValidationError(Fields.Designation, message));
            }

            return result;
        }
    }
}
