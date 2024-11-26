using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class ListEntityRecordExtensions
    {
        public static Guid[] ToIdArray(this List<EntityRecord> recList)
        {
            return recList.Select(r => (Guid)r["id"])
                .ToArray();
        }
    }
}
