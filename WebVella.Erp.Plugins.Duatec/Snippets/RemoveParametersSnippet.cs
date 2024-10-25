using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class RemoveParametersSnippet : SnippetBase
    {
        protected virtual string[] Parameters => ["hookKey", "hId"];

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            if (!pageModel.CurrentUrl.Contains('?'))
                return pageModel.CurrentUrl;

            var parms = pageModel.Request.Query
                .Where(p => !Parameters.Contains(p.Key))
                .Select(p => $"{p.Key}={p.Value}")
                .ToArray();

            var url = pageModel.CurrentUrl[..pageModel.CurrentUrl.IndexOf('?')];
            if (parms.Length == 0)
                return url;
            
            return $"{url}?{string.Join('&', parms)}";
        }
    }
}
