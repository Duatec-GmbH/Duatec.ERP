using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    internal class ManufacturerValidator : IRecordValidator<Company>
    {
        private static readonly NameUniqueValidator _nameValidator = new(Company.Entity, Company.Fields.Name);
        private static readonly ShortNameUniqueValidator _shortNameValidator = new();

        public List<ValidationError> ValidateOnCreate(Company record)
        {
            var result = _nameValidator.ValidateOnCreate(record.Name, Company.Fields.Name);
            if (result.Count == 0 && ValidateNameWithEplanApi(record.Name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnCreate(record.ShortName, Company.Fields.ShortName);
            if (shortNameErrors.Count == 0 && ValidateShortNameWithEplanApi(record.ShortName) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(Company record)
        {
            var id = record.Id!.Value;

            var result = _nameValidator.ValidateOnUpdate(record.Name, Company.Fields.Name, id);
            if(result.Count == 0 && string.IsNullOrEmpty(record.EplanId) && ValidateNameWithEplanApi(record.Name) is ValidationError nameError)
                result.Add(nameError);

            var shortNameErrors = _shortNameValidator.ValidateOnUpdate(record.ShortName, Company.Fields.ShortName, id);
            if (shortNameErrors.Count == 0 && record.EplanId == null && ValidateShortNameWithEplanApi(record.Name) is ValidationError shortNameError)
                shortNameErrors.Add(shortNameError);

            result.AddRange(shortNameErrors);
            return result;
        }

        private static ValidationError? ValidateNameWithEplanApi(string name)
        {
            if(DataPortal.GetManufacturers().Exists(m => name.Equals(m.Name)))
                return new ValidationError(Company.Fields.Name, $"{ErrorPrefix(Company.Fields.Name, name)} is listed in EPLAN");
            return null;
        }

        private static ValidationError? ValidateShortNameWithEplanApi(string shortName)
        {
            if (DataPortal.GetManufacturers().Exists(m => shortName.Equals(m.ShortName)))
                return new ValidationError(Company.Fields.ShortName, $"{ErrorPrefix(Company.Fields.ShortName, shortName)} is listed in EPLAN");
            return null;
        }

        private static string ErrorPrefix(string property, string value)
        {
            return $"{Text.FancyfySnakeCaseStartWithUpper(Company.Entity)} " +
                $"with {Text.FancyfySnakeCase(property)} '{value}'";
        }
    }
}
