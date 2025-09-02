using Newtonsoft.Json;

namespace WebVella.Erp.Plugins.Duatec.DataTransfere
{
    public class SelectUpdateInfo
    {
        [JsonProperty("hasChanged")]
        public bool HasChanged { get; set; }

        [JsonProperty("data")]
        public List<SelectOption> Data { get; set; } = [];
    }
}
