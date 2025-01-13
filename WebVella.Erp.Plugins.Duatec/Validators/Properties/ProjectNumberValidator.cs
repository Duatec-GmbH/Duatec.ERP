using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Validators.Properties
{
    internal class ProjectNumberValidator : NameUniqueValidator
    {
        public ProjectNumberValidator() 
            : base(Project.Entity, Project.Fields.Number)
        { }

        protected override bool CharIsAllowed(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
