using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.TypedRecords.Attributes;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = Project.Fields;

    [TypedValidator(Entity)]
    internal class ProjectValidator : IRecordValidator<Project>
    {
        const string Entity = Project.Entity;
        private static readonly NameFormatValidator _nameValidator = new(Entity, Fields.Name);
        private static readonly ProjectNumberValidator _numberValidator = new();

        public List<ValidationError> ValidateOnCreate(Project record)
        {
            var result = _numberValidator.ValidateOnCreate(record.Number, Fields.Number);
            result.AddRange(_nameValidator.Validate(record.Name, Fields.Name));

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(Project record)
        {
            var result = _numberValidator.ValidateOnUpdate(record.Number, Fields.Number, record.Id!.Value);
            result.AddRange(_nameValidator.Validate(record.Name, Fields.Name));

            return result;
        }

        public List<ValidationError> ValidateOnDelete(Project record)
            => [];
    }
}
