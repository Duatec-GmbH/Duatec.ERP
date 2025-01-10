using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Utilities;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.TypedRecords.Validation;
using WebVella.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = Company.Fields;

    [TypedValidator(typeof(Company))]
    internal class CompanyValidator : IRecordValidator<Company>
    {
        const string Entity = Company.Entity;
        private static readonly NameUniqueValidator _nameValidator = new(Entity, Fields.Name);
        private static readonly ShortNameUniqueValidator _shortNameValidator = new();

        public List<ValidationError> ValidateOnCreate(Company record)
        {
            var result = _nameValidator.ValidateOnCreate(record.Name, Fields.Name);
            if (result.Count == 0 && ValidateNameWithEplanApi(record.Name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnCreate(record.ShortName, Fields.ShortName);
            if (shortNameErrors.Count == 0 && ValidateShortNameWithEplanApi(record.ShortName) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(Company record)
        {
            var id = record.Id!.Value;

            var result = _nameValidator.ValidateOnUpdate(record.Name, Fields.Name, id);
            if(result.Count == 0 && string.IsNullOrEmpty(record.EplanId) && ValidateNameWithEplanApi(record.Name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnUpdate(record.ShortName, Fields.ShortName, id);
            if (shortNameErrors.Count == 0 && record.EplanId == null && ValidateShortNameWithEplanApi(record.Name) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        public List<ValidationError> ValidateOnDelete(Company record)
            => [];

        private static ValidationError? ValidateNameWithEplanApi(string name)
        {
            if(EplanDataPortal.GetManufacturers().Exists(m => name.Equals(m.Name)))
                return new ValidationError(Fields.Name, $"{ErrorPrefix(Fields.Name, name)} is listed in EPLAN");
            return null;
        }

        private static ValidationError? ValidateShortNameWithEplanApi(string shortName)
        {
            if (EplanDataPortal.GetManufacturers().Exists(m => shortName.Equals(m.ShortName)))
                return new ValidationError(Fields.ShortName, $"{ErrorPrefix(Fields.ShortName, shortName)} is listed in EPLAN");
            return null;
        }

        private static string ErrorPrefix(string property, string value)
        {
            var entityName = Text.FancyfySnakeCase(Entity);
            if (entityName.Length > 0)
                entityName = char.ToUpper(entityName[0]) + entityName[1..];

            return $"{entityName} " +
                $"with {Text.FancyfySnakeCase(property)} '{value}'";
        }
    }
}
