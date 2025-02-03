using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public abstract class TypedPostDeleteHook<T> : IErpPostDeleteRecordHook where T : TypedEntityRecordWrapper, new()
    {
        private readonly string _entityName = new T().EntityName;

        void IErpPostDeleteRecordHook.OnPostDeleteRecord(string entityName, EntityRecord record)
        {
            if (entityName == _entityName)
                OnPostDeleteRecord(TypedEntityRecordWrapper.Wrap<T>(record));
        }

        protected abstract void OnPostDeleteRecord(T record);
    }
}
