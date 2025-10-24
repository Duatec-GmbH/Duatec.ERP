using Newtonsoft.Json;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    internal class ArticleSuggestion
    {
        [JsonProperty(PropertyName = "partNumber")]
        public string PartNumber { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;


        public override bool Equals(object? obj)
        {
            return obj is ArticleSuggestion other
                && PartNumber.Equals(other.PartNumber)
                && ImageUrl.Equals(other.ImageUrl);
        }

        public override int GetHashCode()
        {
            return PartNumber.GetHashCode();
        }
    }
}
