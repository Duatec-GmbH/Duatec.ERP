using WebVella.Erp.Api;
using WebVella.Erp.Utilities;

namespace WebVella.Erp.TypedRecords.Util
{
    public static class ListOfTypedEntityRecordWrapperExtensions
    {
        public static IEnumerable<T> Select<T>(IEnumerable<T> records, string relationName, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
        {
            var entityName = new T().EntityName;
            records.Select(relationName, entityName, recMan);

            return records;
        }

        public static List<T> Select<T>(List<T> records, string relationName, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
        {
            var entityName = new T().EntityName;
            records.Select(relationName, entityName, recMan);

            return records;
        }
    }
}
