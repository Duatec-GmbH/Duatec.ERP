using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class ShortNameUniqueValidator : NameUniqueValidator
    {
        private static readonly ShortNameFormatValidator _formatValidator = new();

        public ShortNameUniqueValidator()
            : base(Company.Entity, Company.ShortName)
        { }

        protected override bool CharIsAllowed(char c)
            => _formatValidator.IsValidChar(c);
    }
}
