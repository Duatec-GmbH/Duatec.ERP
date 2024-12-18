using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class ShortNameFormatValidator : NameFormatValidator
    {
        public ShortNameFormatValidator()
            : base(Manufacturer.Entity, Manufacturer.ShortName)
        { }

        public bool IsValidChar(char c)
            => CharIsAllowed(c);

        protected override bool CharIsAllowed(char c)
        {
            return c >= 'A' && c <= 'Z'
                || c >= '0' && c <= '9'
                || c == '-'
                || c == '+'
                || c == '_';
        }
    }
}
