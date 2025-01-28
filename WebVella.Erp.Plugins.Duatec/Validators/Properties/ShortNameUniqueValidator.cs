using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    using Fields = Company.Fields;

    internal class ShortNameUniqueValidator : NameUniqueValidator
    {
        public ShortNameUniqueValidator()
            : base(Company.Entity, Fields.ShortName)
        { }
    }
}
