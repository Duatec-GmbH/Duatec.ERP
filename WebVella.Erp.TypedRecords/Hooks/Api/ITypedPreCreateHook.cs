using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;

namespace WebVella.Erp.TypedRecords.Hooks.Api
{
    public interface ITypedPreCreateHook<in T> : IErpPreCreateRecordHook where T : TypedEntityRecordWrapper, new()
    {
        string EntityName { get; }

        void IErpPreCreateRecordHook.OnPreCreateRecord(string entityName, EntityRecord record, List<ErrorModel> errors)
        {
            if (entityName == EntityName)
                errors.AddRange(OnPreCreateRecord(TypedEntityRecordWrapper.Wrap<T>(record)));
        }

        IEnumerable<ErrorModel> OnPreCreateRecord(T record);
    }
}
