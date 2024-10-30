using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class ImageSnippetBase : SnippetBase
    {
        protected virtual int? Width { get; }

        protected virtual int? Height { get; }

        protected abstract string? Url(BaseErpPageModel pageModel);

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = Url(pageModel);
            if (string.IsNullOrEmpty(url))
                return null!;

            var res = $"<img src=\"{url}\"";
            if (Height.HasValue)
                res += $"height=\"{Height.Value}\"";
            if (Width.HasValue)
                res += $"width=\"{Width.Value}\"";
            res += "/>";

            return res;
        }
    }
}
