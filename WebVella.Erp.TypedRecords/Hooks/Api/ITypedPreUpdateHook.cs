using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public interface ITypedPreUpdateHook<in T> : IErpPreUpdateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        string EntityName { get; }

        void IErpPreUpdateRecordHook.OnPreUpdateRecord(string entityName, EntityRecord record, List<ErrorModel> errors)
        {
            if (entityName == EntityName)
                errors.AddRange(OnPreUpdateRecord(TypedEntityRecordWrapper.Wrap<T>(record)));
        }

        protected abstract IEnumerable<ErrorModel> OnPreUpdateRecord(T record);
    }
}
