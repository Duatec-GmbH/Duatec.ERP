using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public abstract class TypedPreUpdateHook<T> : IErpPreUpdateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        private readonly string _entityName = new T().EntityName;

        void IErpPreUpdateRecordHook.OnPreUpdateRecord(string entityName, EntityRecord record, List<ErrorModel> errors)
        {
            if (entityName == _entityName)
                errors.AddRange(OnPreUpdateRecord(TypedEntityRecordWrapper.Wrap<T>(record)));
        }

        protected abstract List<ErrorModel> OnPreUpdateRecord(T record);
    }
}
