using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = PartList.Fields;

    [TypedValidator(Entity)]
    internal class PartListValidator : IRecordValidator<PartList>
    {
        const string Entity = PartList.Entity;
        private static readonly NameFormatValidator _nameFormatValidator = new(Entity, Fields.Name, true);

        public List<ValidationError> ValidateOnCreate(PartList record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(PartList record)
            => Validate(record, record.Id!.Value);

        public List<ValidationError> ValidateOnDelete(PartList record)
            => [];

        private static List<ValidationError> Validate(PartList record, Guid? id)
        {
            var result = _nameFormatValidator.Validate(record.Name, Fields.Name);

            if (record.Project == Guid.Empty)
                result.Add(new ValidationError(Fields.Project, "Part list project is required"));
            else if (result.Count == 0 && new PartListRepository().ExistsWithinProject(record.Project, record.Name, id))
                result.Add(NameUniqueError());

            return result;
        }

        private static ValidationError NameUniqueError()
            => new (Fields.Name, "Part list name must be unique within projects");
    }
}
