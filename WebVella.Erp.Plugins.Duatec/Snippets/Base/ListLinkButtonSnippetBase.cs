using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class ListLinkButtonSnippetBase : SnippetBase
    {
        protected virtual string? Icon { get; }

        protected abstract string Text { get; }

        protected abstract string Property { get; }

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = $"{pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Property]}";
            if (string.IsNullOrEmpty(url))
                return null;

            var result = $"<a href=\"{url}\" class=\"wv-button btn btn-white\">";
            if (!string.IsNullOrEmpty(Icon))
                result += $"<i class=\"{Icon}\"></i>";

            return result + Text + "</a>";
        }
    }
}
