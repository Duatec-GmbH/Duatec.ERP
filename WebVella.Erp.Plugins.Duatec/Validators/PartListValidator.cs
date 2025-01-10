using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class PartListValidator : IRecordValidator<PartList>
    {
        private static readonly NameFormatValidator _nameFormatValidator = new(PartList.Entity, PartList.Fields.Name);

        public List<ValidationError> ValidateOnCreate(PartList record)
            => Validate(record, null);

        public List<ValidationError> ValidateOnUpdate(PartList record)
            => Validate(record, record.Id!.Value);

        private static ValidationError NameUniqueError()
            => new (PartList.Fields.Name, "Part list name must be unique within projects");

        private static List<ValidationError> Validate(PartList record, Guid? id)
        {
            var result = _nameFormatValidator.Validate(record.Name, PartList.Fields.Name);

            if (record.Project == Guid.Empty)
                result.Add(new ValidationError(PartList.Fields.Project, "Part list project is required"));
            else if (result.Count == 0 && RepositoryService.PartList.ExistsWithinProject(record.Project, record.Name, id))
                result.Add(NameUniqueError());

            return result;
        }
    }
}
