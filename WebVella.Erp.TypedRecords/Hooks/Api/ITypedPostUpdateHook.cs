using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public interface ITypedPostUpdateHook<in T> : IErpPostUpdateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        string EntityName { get; }

        void IErpPostUpdateRecordHook.OnPostUpdateRecord(string entityName, EntityRecord record)
        {
            if (entityName == EntityName)
                OnPostUpdateRecord(TypedEntityRecordWrapper.Wrap<T>(record));
        }

        void OnPostUpdateRecord(T record);
    }
}
