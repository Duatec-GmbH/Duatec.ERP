using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.FileImports
{
    internal enum ArticleImportState
    {
        UnknownArticle,
        DuplicateArticle,
        InvalidDbArticle,
        BlockedArticle,
        InvalidEplanArticle,
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
