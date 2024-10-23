using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class CompartmentValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _labelValidator = new(Compartment.Entity, Compartment.Designation);
        private static readonly string _shelfPretty = Text.FancyfySnakeCase(Shelf.Entity);
        private static readonly string _entityPretty = Text.FancyfySnakeCaseStartUpper(Compartment.Entity);
        private static readonly string _entityPropertyPretty = Text.FancyfySnakeCase(Compartment.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var designation = record[Compartment.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(designation, Compartment.Designation);
            Validate(record, designation, result, null);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var designation = record[Compartment.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(designation, Compartment.Designation, id);
            Validate(record, designation, result, id);

            return result;
        }

        private static void Validate(EntityRecord record, string designation, List<ValidationError> result, Guid? id)
        {
            var shelf = record[Compartment.Shelf] as Guid?;

            if (!shelf.HasValue)
                result.Add(new ValidationError(Compartment.Shelf, $"Please select a {_shelfPretty}"));

            if (result.Count == 0 && Compartment.Exists(shelf!.Value, designation, id))
                result.Add(new ValidationError(Compartment.Designation, $"{_entityPretty} {_entityPropertyPretty} '{designation}' already exists within selected {_shelfPretty}"));
        }
    }
}
