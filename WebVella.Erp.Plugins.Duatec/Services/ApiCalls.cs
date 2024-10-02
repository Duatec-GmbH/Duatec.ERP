using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class ApiCalls
    {
        public async static Task<JsonNode?> JsonFromUrl(string url)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return JsonObject.Parse(await client.GetStringAsync(url));
        }
    }
}
