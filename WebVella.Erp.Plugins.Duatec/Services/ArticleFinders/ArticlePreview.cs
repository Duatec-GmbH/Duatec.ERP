using Newtonsoft.Json;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    internal class ArticlePreview
    {
        [JsonProperty(PropertyName = "partNumber")]
        public string PartNumber { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "typeNumber")]
        public string TypeNumber { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "designation")]
        public string Designation { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "articleType")]
        public ArticleType? Type { get; set; }
    }
}
