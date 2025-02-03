using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public abstract class TypedPreDeleteHook<T> : IErpPreDeleteRecordHook where T : TypedEntityRecordWrapper, new()
    {
        private readonly string _entityName = new T().EntityName;

        void IErpPreDeleteRecordHook.OnPreDeleteRecord(string entityName, EntityRecord record, List<ErrorModel> errors)
        {
            if (entityName == _entityName)
                errors.AddRange(OnPreDeleteRecord(TypedEntityRecordWrapper.Wrap<T>(record)));
        }

        protected abstract List<ErrorModel> OnPreDeleteRecord(T record);
    }
}
