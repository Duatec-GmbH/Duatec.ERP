using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Images
{
    [HookAttachment(key: HookKeys.Image.Create)]
    internal class ImageCreateHook : TypedValidatedCreateHook<Image>
    {
        protected override IActionResult? OnPostCreate(Image record, RecordCreatePageModel pageModel)
        {
            if(!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect(pageModel.EntityListUrl());
        }
    }
}
