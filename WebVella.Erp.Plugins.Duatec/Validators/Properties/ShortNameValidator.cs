using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class ShortNameValidator : UniqueNameValidator
    {
        private static readonly ShortNameFormatValidator _formatValidator = new();

        public ShortNameValidator()
            : base(Manufacturer.Entity, Manufacturer.ShortName)
        { }

        protected override bool CharIsAllowed(char c)
            => _formatValidator.IsValidChar(c);
    }
}
