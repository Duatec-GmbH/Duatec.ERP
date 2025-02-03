using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public interface ITypedPostDeleteHook<in T> : IErpPostDeleteRecordHook where T : TypedEntityRecordWrapper, new()
    {
        string EntityName { get; }

        void IErpPostDeleteRecordHook.OnPostDeleteRecord(string entityName, EntityRecord record)
        {
            if (entityName == EntityName)
                OnPostDeleteRecord(TypedEntityRecordWrapper.Wrap<T>(record));
        }

        void OnPostDeleteRecord(T record);
    }
}
