using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    using Fields = Company.Fields;

    internal class ShortNameUniqueValidator : NameUniqueValidator
    {
        private static readonly ShortNameFormatValidator _formatValidator = new();

        public ShortNameUniqueValidator()
            : base(Company.Entity, Fields.ShortName)
        { }

        protected override bool CharIsAllowed(char c)
            => _formatValidator.IsValidChar(c);
    }
}
