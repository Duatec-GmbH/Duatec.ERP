using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class WarehouseLocationValidator : IRecordValidator<WarehouseLocation>
    {
        private static readonly NameFormatValidator _labelValidator = new(Warehouse.Entity, Warehouse.Fields.Designation);
        private static readonly string _warehousePretty = Text.FancyfySnakeCase(Warehouse.Entity);
        private static readonly string _entityPretty = Text.FancyfySnakeCaseStartWithUpper(WarehouseLocation.Entity);
        private static readonly string _entityPropertyPretty = Text.FancyfySnakeCase(WarehouseLocation.Fields.Designation);

        public List<ValidationError> ValidateOnCreate(WarehouseLocation record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(WarehouseLocation record)
            => Validate(record, record.Id!.Value);

        private static List<ValidationError> Validate(WarehouseLocation record, Guid? id)
        {
            var result = _labelValidator.Validate(record.Designation, WarehouseLocation.Fields.Designation);

            if (record.Warehouse == Guid.Empty)
                result.Add(new ValidationError(WarehouseLocation.Fields.Warehouse, $"Please select a {_warehousePretty}"));

            if (result.Count == 0 && RepositoryService.Warehouse.EntryExistsWithinWarehouse(record.Warehouse, record.Designation, id))
            {
                var message = $"{_entityPretty} {_entityPropertyPretty} '{record.Designation}' already exists within selected {_warehousePretty}";
                result.Add(new ValidationError(WarehouseLocation.Fields.Designation, message));
            }

            return result;
        }
    }
}
