using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class CreateOnListHookBase : IPageHook
    {
        protected virtual string IdProperty => "hId";

        protected abstract string ManageHook { get; }

        protected abstract EntityRecord CreateRecord(BaseErpPageModel pageModel);

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, IdProperty);

            pageModel.DataModel.SetRecord(CreateRecord(pageModel));

            var hook = $"hookKey={ManageHook}";
            if (url.Contains('?'))
                url += $"&{hook}";
            else url += $"?{hook}";

            pageModel.CurrentUrl = url;

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }
    }
}
