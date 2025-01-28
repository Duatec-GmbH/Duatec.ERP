using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Services.EplanTypes;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.PartLists
{
    [Snippet]
    internal class PartListImportActionAccessibilitySnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec?["import_state"] is ArticleImportState state && (state == ArticleImportState.DbArticle || state == ArticleImportState.InvalidDbArticle))
                return WvFieldAccess.Full;
            return WvFieldAccess.ReadOnly;
        }
    }
}
