using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ManufacturerValidator : IRecordValidator<EntityRecord>
    {
        private static readonly NameUniqueValidator _nameValidator = new(Company.Entity, Company.Name);
        private static readonly ShortNameUniqueValidator _shortNameValidator = new();

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var name = (string?)record[Company.Name] ?? string.Empty;
            var shortName = (string?)record[Company.ShortName] ?? string.Empty;

            var result = _nameValidator.ValidateOnCreate(name, Company.Name);
            if (result.Count == 0 && ValidateNameWithEplanApi(name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnCreate(shortName, Company.ShortName);
            if (shortNameErrors.Count == 0 && ValidateShortNameWithEplanApi(shortName) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var name = (string?)record[Company.Name] ?? string.Empty;
            var shortName = (string?)record[Company.ShortName] ?? string.Empty;

            var result = _nameValidator.ValidateOnUpdate(name, Company.Name, id);
            if(result.Count == 0 && record[Company.EplanId] == null && ValidateNameWithEplanApi(name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnUpdate(shortName, Company.ShortName, id);
            if (shortNameErrors.Count == 0 && record[Company.EplanId] == null && ValidateShortNameWithEplanApi(name) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        private static ValidationError? ValidateNameWithEplanApi(string name)
        {
            if(DataPortal.GetManufacturers().Exists(m => name.Equals(m.Name)))
                return new ValidationError(Company.Name, $"{ErrorPrefix(Company.Name, name)} is listed in EPLAN");
            return null;
        }

        private static ValidationError? ValidateShortNameWithEplanApi(string shortName)
        {
            if (DataPortal.GetManufacturers().Exists(m => shortName.Equals(m.ShortName)))
                return new ValidationError(Company.ShortName, $"{ErrorPrefix(Company.ShortName, shortName)} is listed in EPLAN");
            return null;
        }

        private static string ErrorPrefix(string property, string value)
        {
            return $"{Text.FancyfySnakeCaseStartWithUpper(Company.Entity)} " +
                $"with {Text.FancyfySnakeCase(property)} '{value}'";
        }
    }
}
