using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.FileImports;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Eplan
{
    [Snippet]
    internal class ArticleImportStateSnippet : SnippetBase
    {
        private static readonly Dictionary<ArticleImportState, string> _stateImageInfos = new()
        {
            [ArticleImportState.EplanArticle] = "fas fa-check go-green",
            [ArticleImportState.DbArticle] = "fas fa-check go-green",
            [ArticleImportState.UnknownArticle] = "fas fa-times go-red",
            [ArticleImportState.BlockedArticle] = "fas fa-times go-red",
            [ArticleImportState.InvalidEplanArticle] = "fas fa-times go-red",
            [ArticleImportState.InvalidDbArticle] = "fas fa-times go-red",
        };

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var s = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?["import_state"];
            if (s is not ArticleImportState state)
                return null;

            var text = state.ToPrettyString();
            var image = _stateImageInfos[state];

            return $"<div>{text}<i class=\"ml-2 {image}\"/></div>";
        }
    }
}
