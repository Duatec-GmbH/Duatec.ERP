namespace WebVella.Erp.Plugins.Duatec.Services.Eplan
{
    internal static class ArticleImportAction
    {
        public const string NoAction = "No action required";
        public const string Skip = "Do not import";
        public const string Import = "Import";

        public static bool IsValidAction(string action)
        {
            return action.Equals(NoAction, StringComparison.OrdinalIgnoreCase)
                || action.Equals(Skip, StringComparison.OrdinalIgnoreCase)
                || action.Equals(Import, StringComparison.OrdinalIgnoreCase);
        }

        public static string[] AvailableActions(ArticleImportState state)
        {
            return state switch
            {
                ArticleImportState.DbArticle => [NoAction],
                ArticleImportState.BlockedArticle => [NoAction],
                ArticleImportState.EplanArticle => [Import, Skip],
                ArticleImportState.UnknownArticle => [Skip],
                _ => throw new NotImplementedException($"{state} is not implemented")
            };
        }

        public static string Default(ArticleImportState state)
        {
            return state switch
            {
                ArticleImportState.DbArticle => NoAction,
                ArticleImportState.BlockedArticle => NoAction,
                ArticleImportState.EplanArticle => Import,
                ArticleImportState.UnknownArticle => Skip,
                _ => throw new NotImplementedException($"{state} is not implemented")
            };
        }
    }
}
