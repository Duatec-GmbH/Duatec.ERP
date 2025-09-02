using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Projects
{
    [HookAttachment(key: Project.Entity)]
    internal class ProjectChangeListenerHook : ITypedPostCreateHook<Project>, ITypedPostDeleteHook<Project>, ITypedPostUpdateHook<Project>
    {
        public string EntityName => Project.Entity;

        public bool ExecuteOnPostCreateMany => true;

        public bool ExecuteOnPostDeleteMany => true;

        public bool ExecuteOnPostUpdateMany => true;

        public void OnPostCreateRecord(Project record)
        {
            ChangeDetection.LastProjectChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostDeleteRecord(Project record)
        {
            ChangeDetection.LastProjectChangeTimeUtc = DateTime.UtcNow;
        }

        public void OnPostUpdateRecord(Project record)
        {
            ChangeDetection.LastProjectChangeTimeUtc = DateTime.UtcNow;
        }
    }
}
