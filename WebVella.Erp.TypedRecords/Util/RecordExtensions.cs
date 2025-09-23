using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Util
{
    public static class RecordExtensions
    {
        public static T WithoutRelations<T>(this T record) where T : EntityRecord, new()
        {
            var result = new T();

            foreach (var (k, p) in record.Properties.Where(kp => !kp.Key.StartsWith('$')))
                result[k] = p;

            return result;
        }
    }
}
