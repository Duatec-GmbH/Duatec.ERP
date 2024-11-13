using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (string Name, string Number);

    internal class ProjectValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _nameValidator = new(Project.Entity, Project.Name);
        private static readonly ProjectNumberValidator _numberValidator = new();

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var (name, number) = GetArgs(record);

            var result = _numberValidator.ValidateOnCreate(number, Project.Number);
            result.AddRange(_nameValidator.Validate(name, Project.Name));

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var (name, number) = GetArgs(record);

            var result = _numberValidator.ValidateOnUpdate(number, Project.Number, id);
            result.AddRange(_nameValidator.Validate(name, Project.Name));

            return result;
        }

        private static Args GetArgs(EntityRecord record)
        {
            return (record[Project.Name] as string ?? string.Empty,
                record[Project.Number] as string ?? string.Empty);
        }
    }
}
