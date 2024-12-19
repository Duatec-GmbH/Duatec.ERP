using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ProjectValidator : IRecordValidator<Project>
    {
        private static readonly NameFormatValidator _nameValidator = new(Project.Entity, Project.Fields.Name);
        private static readonly ProjectNumberValidator _numberValidator = new();

        public List<ValidationError> ValidateOnCreate(Project record)
        {
            var result = _numberValidator.ValidateOnCreate(record.Number, Project.Fields.Number);
            result.AddRange(_nameValidator.Validate(record.Name, Project.Fields.Name));

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(Project record)
        {
            var result = _numberValidator.ValidateOnUpdate(record.Number, Project.Fields.Number, record.Id!.Value);
            result.AddRange(_nameValidator.Validate(record.Name, Project.Fields.Name));

            return result;
        }
    }
}
