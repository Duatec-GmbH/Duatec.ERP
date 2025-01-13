namespace WebVella.Erp.Plugins.Duatec.Validators.Properties.Base
{
    internal abstract class NameFormatValidatorBase : PropertyValidatorBase
    {
        protected NameFormatValidatorBase(string entity, string entityProperty, bool required)
            : base(entity, entityProperty, required)
        { }

        protected override bool CharIsAllowed(char c)
        {
            return char.IsLetterOrDigit(c)
                || c >= ' ' && c <= '~';
        }
    }
}
