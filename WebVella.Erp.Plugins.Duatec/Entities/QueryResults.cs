using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class QueryResults
    {
        public static Guid? Id(EntityRecordList? recList)
        {
            return recList?.SingleOrDefault()?["id"] as Guid?;
        }

        public static bool Exists(EntityRecordList? recList)
        {
            return recList != null && recList.Count > 0;
        }
    }
}
