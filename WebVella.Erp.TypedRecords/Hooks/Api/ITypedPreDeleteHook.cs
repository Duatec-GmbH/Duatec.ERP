using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public interface ITypedPreDeleteHook<in T> : IErpPreDeleteRecordHook where T : TypedEntityRecordWrapper, new()
    {
        string EntityName { get; }

        void IErpPreDeleteRecordHook.OnPreDeleteRecord(string entityName, EntityRecord record, List<ErrorModel> errors)
        {
            if (entityName == EntityName)
                errors.AddRange(OnPreDeleteRecord(TypedEntityRecordWrapper.Wrap<T>(record)));
        }

        protected abstract IEnumerable<ErrorModel> OnPreDeleteRecord(T record);
    }
}
