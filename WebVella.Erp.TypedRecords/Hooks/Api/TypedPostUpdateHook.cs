using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public abstract class TypedPostUpdateHook<T> : IErpPostUpdateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        private readonly string _entityName = new T().EntityName;

        void IErpPostUpdateRecordHook.OnPostUpdateRecord(string entityName, EntityRecord record)
        {
            if (entityName == _entityName)
                OnPostUpdateRecord(TypedEntityRecordWrapper.Wrap<T>(record));
        }

        protected abstract void OnPostUpdateRecord(T record);
    }
}
