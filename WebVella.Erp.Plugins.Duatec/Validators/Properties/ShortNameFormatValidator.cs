using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class ShortNameFormatValidator : NameFormatValidator
    {
        public ShortNameFormatValidator()
            : base(Company.Entity, Company.Fields.ShortName, true)
        { }
    }
}
