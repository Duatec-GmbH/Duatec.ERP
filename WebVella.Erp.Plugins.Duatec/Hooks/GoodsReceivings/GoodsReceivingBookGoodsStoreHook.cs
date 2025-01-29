using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.GoodsReceivings
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Store)]
    internal class GoodsReceivingBookGoodsStoreHook : IPageHook
    {
        public IActionResult OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }
    }
}
