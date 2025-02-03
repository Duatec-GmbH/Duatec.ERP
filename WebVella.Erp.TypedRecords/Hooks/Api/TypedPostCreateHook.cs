using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public abstract class TypedPostCreateHook<T> : IErpPostCreateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        private readonly string _entityName = new T().EntityName;

        void IErpPostCreateRecordHook.OnPostCreateRecord(string entityName, EntityRecord record)
        {
            if (entityName == _entityName)
                OnPostCreateRecord(TypedEntityRecordWrapper.Wrap<T>(record));
        }

        protected abstract void OnPostCreateRecord(T record);
    }
}
