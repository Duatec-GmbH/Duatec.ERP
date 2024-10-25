using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class ListUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var app = pageModel.TryGetDataSourceProperty<App>("App");

            var url = $"/{app.Name}/";
            var idx = pageModel.CurrentUrl.IndexOf(url);

            idx += url.Length;
            var areaName = pageModel.CurrentUrl[idx..pageModel.CurrentUrl.IndexOf('/', idx)];
            var area = app?.Sitemap.Areas.FirstOrDefault(a => a.Name == areaName);

            idx += areaName.Length + 1;
            var nodeName = pageModel.CurrentUrl[idx..pageModel.CurrentUrl.IndexOf('/', idx)];
            var node = area?.Nodes.FirstOrDefault(n => n.Name == nodeName);

            return $"/{app?.Name}/{area?.Name}/{node?.Name}/l";
        }
    }
}
