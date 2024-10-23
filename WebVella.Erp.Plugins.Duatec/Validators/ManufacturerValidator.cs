using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ManufacturerValidator : IRecordValidator
    {
        private static readonly NameUniqueValidator _nameValidator = new(Manufacturer.Entity, Manufacturer.Name);
        private static readonly ShortNameUniqueValidator _shortNameValidator = new();

        public List<ValidationError> ValidateOnCreate(EntityRecord record)
        {
            var name = (string?)record[Manufacturer.Name] ?? string.Empty;
            var shortName = (string?)record[Manufacturer.ShortName] ?? string.Empty;

            var result = _nameValidator.ValidateOnCreate(name, Manufacturer.Name);
            if (result.Count == 0 && ValidateNameWithEplanApi(name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnCreate(shortName, Manufacturer.ShortName);
            if (shortNameErrors.Count == 0 && ValidateShortNameWithEplanApi(shortName) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(EntityRecord record)
        {
            var id = (Guid)record["id"];
            var name = (string?)record[Manufacturer.Name] ?? string.Empty;
            var shortName = (string?)record[Manufacturer.ShortName] ?? string.Empty;

            var result = _nameValidator.ValidateOnUpdate(name, Manufacturer.Name, id);
            if(result.Count == 0 && ValidateNameWithEplanApi(name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnUpdate(shortName, Manufacturer.ShortName, id);
            if (shortNameErrors.Count == 0 && ValidateShortNameWithEplanApi(name) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        private static ValidationError? ValidateNameWithEplanApi(string name)
        {
            if(EplanDataPortal.GetManufacturers().Exists(m => name.Equals(m.Name)))
                return new ValidationError(Manufacturer.Name, $"{ErrorPrefix(Manufacturer.Name, name)} is listed in EPLAN");
            return null;
        }

        private static ValidationError? ValidateShortNameWithEplanApi(string shortName)
        {
            if (EplanDataPortal.GetManufacturers().Exists(m => shortName.Equals(m.ShortName)))
                return new ValidationError(Manufacturer.ShortName, $"{ErrorPrefix(Manufacturer.ShortName, shortName)} is listed in EPLAN");
            return null;
        }

        private static string ErrorPrefix(string property, string value)
        {
            return $"{Text.FancyfySnakeCaseStartUpper(Manufacturer.Entity)} " +
                $"with {Text.FancyfySnakeCase(property)} '{value}'";
        }
    }
}
