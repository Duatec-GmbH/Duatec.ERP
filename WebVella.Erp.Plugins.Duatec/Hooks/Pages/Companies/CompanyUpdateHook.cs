using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Companies
{
    using Images = Duatec.Images;

    [HookAttachment(key: HookKeys.Company.Update)]
    internal class CompanyUpdateHook : TypedValidatedManageHook<Company>
    {
        protected override IActionResult? OnValidationSuccess(Company record, Company unmodified, RecordManagePageModel pageModel)
        {
            if (record.LogoUrl != unmodified.LogoUrl)
            {
                var hasChanged = true;

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
                    hasChanged = unmodified.LogoUrl != file;
                    record.LogoUrl = file;
                }

                if (hasChanged)
                {
                    var repo = new CompanyRepository();
                    repo.DeleteLogoIfUnused(unmodified.LogoUrl, unmodified.Id);
                }
            }

            return base.OnValidationSuccess(record, unmodified, pageModel);
        }
    }
}
