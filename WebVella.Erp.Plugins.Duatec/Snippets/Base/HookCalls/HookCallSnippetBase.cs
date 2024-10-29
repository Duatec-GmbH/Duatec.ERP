using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls
{
    public abstract class HookCallSnippetBase : SnippetBase
    {
        protected abstract string HookKey { get; }

        protected virtual IEnumerable<string> ParametersToClear { get; } = [];

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            foreach (var p in ParametersToClear)
                url = Url.RemoveParameter(url, p);

            var paramsVal = $"hookKey={HookKey}";

            if (url.Contains('?'))
                return $"{url}&{paramsVal}";
            return $"{url}?{paramsVal}";
        }
    }
}
