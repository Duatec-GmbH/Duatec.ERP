using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class ParameterizedHookFromListSnippetBase : SnippetBase
    {
        protected abstract string HookKey { get; }

        protected abstract (string HookParameter, string RecordParameter)[] ParameterInfos { get; }

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            foreach (var p in ParameterInfos.Select(pi => pi.HookParameter))
                url = Url.RemoveParameter(url, p);

            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            var paramInfos = ParameterInfos
                .Select(pi => new { pi.HookParameter, Value = rec?[pi.RecordParameter]?.ToString() });

            var paramsVal = $"hookKey={HookKey}";
            foreach (var p in paramInfos)
                paramsVal += $"&{p.HookParameter}={p.Value}";

            if (url.Contains('?'))
                return $"{url}&{paramsVal}";
            return $"{url}?{paramsVal}";
        }
    }
}
