using Newtonsoft.Json;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    public class UserActivityDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("timeString")]
        public string TimeString { get; set; } = string.Empty;

        [JsonProperty("page")]
        public string Page { get; set; } = string.Empty;
    }
}
