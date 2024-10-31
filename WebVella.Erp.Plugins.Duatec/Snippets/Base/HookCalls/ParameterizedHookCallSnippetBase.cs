using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls
{
    public abstract class ParameterizedHookCallSnippetBase : HookCallSnippetBase
    {
        protected abstract IEnumerable<string> Parameters { get; }

        protected abstract object? GetParameterValue(string parameter, BaseErpPageModel pageModel);

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = (string)base.GetValue(pageModel)!;
            foreach (var parameter in Parameters)
            {
                url = Url.RemoveParameter(url, parameter);

                var val = GetParameterValue(parameter, pageModel);
                if (val != null)
                    url += $"&{parameter}={val}";
            }
            return url;
        }
    }
}
