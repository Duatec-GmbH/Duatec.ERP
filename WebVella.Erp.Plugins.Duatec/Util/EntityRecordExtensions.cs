using Newtonsoft.Json;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class EntityRecordExtensions
    {
        public static string ToJson(this EntityRecord rec)
        {
            var properties = rec.Properties
                .Where(kp => !kp.Key.StartsWith('$'))
                .ToDictionary();

            return JsonConvert.SerializeObject(properties);
        }
    }
}
