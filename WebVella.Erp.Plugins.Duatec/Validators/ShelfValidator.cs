using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ShelfValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _labelValidator = new(Shelf.Entity, Shelf.Designation);
        private static readonly string _warehousePretty = Text.FancyfySnakeCase(Warehouse.Entity);
        private static readonly string _entityPretty = Text.FancyfySnakeCaseStartUpper(Shelf.Entity);
        private static readonly string _entityPropertyPretty = Text.FancyfySnakeCase(Shelf.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var designation = record[Shelf.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(designation, Shelf.Designation);
            Validate(record, designation, result, null);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var designation = record[Shelf.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(designation, Shelf.Designation, id);
            Validate(record, designation, result, id);

            return result;
        }

        private static void Validate(EntityRecord record, string designation, List<ValidationError> result, Guid? id)
        {
            var warehouse = record[Shelf.Warehouse] as Guid?;

            if (!warehouse.HasValue)
                result.Add(new ValidationError(Shelf.Warehouse, $"Please select a {_warehousePretty}"));

            if (result.Count == 0 && Shelf.Exists(warehouse!.Value, designation, id))
                result.Add(new ValidationError(Shelf.Designation, $"{_entityPretty} {_entityPropertyPretty} '{designation}' already exists within selected {_warehousePretty}"));
        }
    }
}
