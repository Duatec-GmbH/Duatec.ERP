using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class WarehouseLocationValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _labelValidator = new(Warehouse.Entity, Warehouse.Designation);
        private static readonly string _warehousePretty = Text.FancyfySnakeCase(Warehouse.Entity);
        private static readonly string _entityPretty = Text.FancyfySnakeCaseStartWithUpper(WarehouseLocation.Entity);
        private static readonly string _entityPropertyPretty = Text.FancyfySnakeCase(WarehouseLocation.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var designation = record[WarehouseLocation.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(designation, WarehouseLocation.Designation);
            Validate(record, designation, result, null);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var designation = record[WarehouseLocation.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(designation, WarehouseLocation.Designation, id);
            Validate(record, designation, result, id);

            return result;
        }

        private static void Validate(EntityRecord record, string designation, List<ValidationError> result, Guid? id)
        {
            var warehouse = record[WarehouseLocation.Warehouse] as Guid?;

            if (!warehouse.HasValue)
                result.Add(new ValidationError(WarehouseLocation.Warehouse, $"Please select a {_warehousePretty}"));

            if (result.Count == 0 && WarehouseLocation.Exists(warehouse!.Value, designation, id))
                result.Add(new ValidationError(WarehouseLocation.Designation, $"{_entityPretty} {_entityPropertyPretty} '{designation}' already exists within selected {_warehousePretty}"));
        }
    }
}
