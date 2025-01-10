namespace WebVella.Erp.Plugins.Duatec.Validators.Properties.Base
{
    internal abstract class NameFormatValidatorBase : PropertyValidatorBase
    {
        protected NameFormatValidatorBase(string entity, string entityProperty)
            : base(entity, entityProperty)
        { }

        protected override bool CharIsAllowed(char c)
        {
            return char.IsLetterOrDigit(c)
                || c >= ' ' && c <= '~';
        }
    }
}
