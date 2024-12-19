using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class ProjectRepository : RepositoryBase<Project>
    {
        public override string Entity => Project.Entity;

        protected override Project? MapToTypedRecord(EntityRecord? record)
            => Project.Create(record);
    }
}
