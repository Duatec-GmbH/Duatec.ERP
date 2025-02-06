using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
{
    [Obsolete]
    [HookAttachment(key: HookKeys.PartList.Compare)]
    internal class PartListDiffHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            var rec = new EntityRecord();

            if (!Guid.TryParse(pageModel.Request.Form["part_list1"], out var id))
                return null;

            rec["part_list1"] = id;

            if (!Guid.TryParse(pageModel.Request.Form["part_list2"], out id))
                return null;

            rec["part_list2"] = id;

            pageModel.DataModel.SetRecord(rec);
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }
    }
}
