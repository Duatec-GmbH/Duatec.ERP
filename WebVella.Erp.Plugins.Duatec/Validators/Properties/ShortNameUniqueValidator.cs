using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class ShortNameUniqueValidator : NameUniqueValidator
    {
        private static readonly ShortNameFormatValidator _formatValidator = new();

        public ShortNameUniqueValidator()
            : base(Manufacturer.Entity, Manufacturer.ShortName)
        { }

        protected override bool CharIsAllowed(char c)
            => _formatValidator.IsValidChar(c);
    }
}
