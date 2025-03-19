using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Companies
{
    using Images = Duatec.Images;

    [HookAttachment(key: HookKeys.Company.Create)]
    internal class CompanyCreateHook : TypedValidatedCreateHook<Company>
    {
        protected override IActionResult? OnValidationSuccess(Company record, RecordCreatePageModel pageModel)
        {
            if (!string.IsNullOrWhiteSpace(record.LogoUrl))
            {
                var file = Images.GetOrDownload(record.LogoUrl, pageModel.CurrentUser.Id);
                if (string.IsNullOrEmpty(file))
                {
                    pageModel.PutMessage(ScreenMessageType.Error, "Could not download image");
                    pageModel.DataModel.SetRecord(record);
                    pageModel.BeforeRender();
                    return pageModel.Page();
                }
                record.LogoUrl = file;
            }

            return base.OnValidationSuccess(record, pageModel);
        }
    }
}
