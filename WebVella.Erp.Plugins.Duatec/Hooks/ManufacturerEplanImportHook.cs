using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment("manufacturer_eplan_import")]
    internal class ManufacturerEplanImportHook : IPageHook
    {
        public IActionResult OnGet(BaseErpPageModel pageModel)
        {
            return null!;
        }

        public IActionResult OnPost(BaseErpPageModel pageModel)
        {
            var shortName = pageModel.GetFormValue("eplan_identifier");
            Import(pageModel, shortName);
            return null!;
        }

        private void Import(BaseErpPageModel pageModel, string shortName)
        {
            if (string.IsNullOrEmpty(shortName))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Please enter a manufacturer short name part number.");
                return;
            }
        }
    }
}
