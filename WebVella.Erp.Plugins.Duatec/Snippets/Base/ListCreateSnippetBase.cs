using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class ListCreateSnippetBase : ParameterizedHookFromListSnippetBase
    {
        protected override (string HookParameter, string RecordParameter)[] ParameterInfos
            => [];

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            pageModel.CurrentUrl = Url.RemoveParameter(pageModel.CurrentUrl, "hId");
            return base.GetValue(pageModel);
        }
    }
}
