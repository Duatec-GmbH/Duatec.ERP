using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class CompartmentValidator : IValidator
    {
        private static readonly UniqueNameValidator _labelValidator = new(Compartment.Entity, Compartment.Designation);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var designation = record[Compartment.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnCreate(designation, Compartment.Designation);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var designation = record[Compartment.Designation] as string ?? string.Empty;

            var result = _labelValidator.ValidateOnUpdate(designation, Compartment.Designation, id);

            return result;
        }
    }
}
