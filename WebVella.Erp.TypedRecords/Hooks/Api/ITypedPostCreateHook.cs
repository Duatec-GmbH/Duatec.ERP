using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public interface ITypedPostCreateHook<in T> : IErpPostCreateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        string EntityName { get; }

        void IErpPostCreateRecordHook.OnPostCreateRecord(string entityName, EntityRecord record)
        {
            if (entityName == EntityName)
                OnPostCreateRecord(TypedEntityRecordWrapper.Wrap<T>(record));
        }

        void OnPostCreateRecord(T record);
    }
}
