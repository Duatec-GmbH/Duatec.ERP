using WebVella.Erp.Utilities;

namespace WebVella.Erp.Plugins.Duatec.Services.EplanTypes
{
    internal enum ArticleImportState
    {
        UnknownArticle,
        BlockedArticle,
        EplanArticle,
        DbArticle,
    }

    internal static class ArticleImportStateExtensions
    {
        public static string ToPrettyString(this ArticleImportState state)
        {
            return Text.FancyfyPascalCase(state.ToString());
        }
    }
}
