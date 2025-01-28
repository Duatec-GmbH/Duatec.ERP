using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Services.EplanTypes
{
    internal enum ArticleImportState
    {
        UnknownArticle,
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
