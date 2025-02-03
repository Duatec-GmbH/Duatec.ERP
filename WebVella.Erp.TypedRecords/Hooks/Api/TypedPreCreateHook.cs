using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public abstract class TypedPreCreateHook<T> : IErpPreCreateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        private readonly string _entityName = new T().EntityName;

        void IErpPreCreateRecordHook.OnPreCreateRecord(string entityName, EntityRecord record, List<ErrorModel> errors)
        {
            if (entityName == _entityName)
                errors.AddRange(OnPreCreateRecord(TypedEntityRecordWrapper.Wrap<T>(record)));
        }

        protected abstract List<ErrorModel> OnPreCreateRecord(T record);
    }
}
