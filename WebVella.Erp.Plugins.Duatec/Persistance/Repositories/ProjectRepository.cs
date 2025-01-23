using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class ProjectRepository : TypedRepositoryBase<Project>
    { 
        public ProjectRepository(RecordManager? recordManager = null)
            : base(recordManager) { }
    }
}
