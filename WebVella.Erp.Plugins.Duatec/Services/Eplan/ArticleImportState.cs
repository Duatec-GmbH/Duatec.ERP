using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Services.Eplan
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
