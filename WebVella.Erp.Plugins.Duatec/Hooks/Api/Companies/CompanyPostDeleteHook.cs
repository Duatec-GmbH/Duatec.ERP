using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.Companies
{
    [HookAttachment(key: Company.Entity)]
    internal class CompanyPostDeleteHook : ITypedPostDeleteHook<Company>
    {
        public string EntityName => Company.Entity;

        public bool ExecuteOnPostDeleteMany => true;

        public void OnPostDeleteRecord(Company record)
        {
            var repo = new CompanyRepository();
            repo.DeleteLogoIfUnused(record.LogoUrl, record.Id);
        }
    }
}
