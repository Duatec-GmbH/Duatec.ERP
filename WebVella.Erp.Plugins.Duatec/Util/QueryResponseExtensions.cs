using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class QueryResponseExtensions
    {
        public static string GetMessage(this QueryResponse response)
        {
            var messages = response.Errors
                .Select(e => e.Message)
                .Prepend(response.Message);

            return string.Join(Environment.NewLine, messages);
        }
    }
}
