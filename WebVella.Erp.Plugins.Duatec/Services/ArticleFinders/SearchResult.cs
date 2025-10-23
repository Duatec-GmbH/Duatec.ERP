using System.Diagnostics.CodeAnalysis;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    internal class SearchResult
    {
        [MemberNotNullWhen(true, nameof(Value))]
        public bool IsValid { get; set; }

        public ArticlePreview? Value { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}
