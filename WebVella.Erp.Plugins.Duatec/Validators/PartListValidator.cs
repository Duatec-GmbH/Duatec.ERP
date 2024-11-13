using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Args = (string Name, Guid? Project);

    internal class PartListValidator : IRecordValidator
    {
        private static readonly NameFormatValidator _nameFormatValidator = new(PartList.Entity, PartList.Name);

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var args = GetArgs(record);

            var result = ValidateFormat(record);

            if (result.Count == 0 && PartList.Exists(args.Project!.Value, args.Name))
                result.Add(NameUniqueError());

            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var args = GetArgs(record);

            var result = ValidateFormat(record);

            if (result.Count == 0 && PartList.Exists(args.Project!.Value, args.Name, id))
                result.Add(NameUniqueError());

            return result;
        }

        private static ValidationError NameUniqueError()
            => new (PartList.Name, "Part list name must be unique within projects");

        private static Args GetArgs(EntityRecord record)
        {
            return (record[PartList.Name] as string ?? string.Empty,
                record[PartList.Project] as Guid?);
        }

        private static List<ValidationError> ValidateFormat(EntityRecord record)
        {
            var name = record[PartList.Name] as string ?? string.Empty;
            var project = record[PartList.Project] as Guid?;

            var result = _nameFormatValidator.Validate(name, PartList.Name);
            if (!project.HasValue || !Project.Exists(project.Value))
                result.Add(new ValidationError(PartList.Project, "Part list project is required"));

            return result;
        }
    }
}
