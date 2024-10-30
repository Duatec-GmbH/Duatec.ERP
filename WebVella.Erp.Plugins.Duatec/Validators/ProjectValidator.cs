using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ProjectValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _nameValidator = new(Project.Entity, Project.Name);
        private static readonly ProjectNumberValidator _numberValidator = new();

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var name = record[Project.Name] as string ?? string.Empty;
            var number = record[Project.Number] as string ?? string.Empty;

            var result = _numberValidator.ValidateOnCreate(number, Project.Number);
            var nameErrors = _nameValidator.ValidateOnCreate(name, Project.Name);
            result.AddRange(nameErrors);

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var name = record[Project.Name] as string ?? string.Empty;
            var number = record[Project.Number] as string ?? string.Empty;

            var result = _numberValidator.ValidateOnUpdate(number, Project.Number, id);
            var nameErrors = _nameValidator.ValidateOnUpdate(name, Project.Name, id);
            result.AddRange(nameErrors);

            return result;
        }
    }
}
