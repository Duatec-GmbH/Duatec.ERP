using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class DataSourceExtensions
    {
        public static Dictionary<string, object> GetDefaultArgs(this DataSourceBase ds)
        {
            var result = new Dictionary<string, object>(32);
            var dsMan = new DataSourceManager();

            foreach (var param in ds.Parameters)
                result[param.Name] = dsMan.GetDataSourceParameterValue(param);
            return result;
        }
    }
}
