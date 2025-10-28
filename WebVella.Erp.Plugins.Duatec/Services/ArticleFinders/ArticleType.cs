using Newtonsoft.Json;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    internal class ArticleType
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;
    }
}
