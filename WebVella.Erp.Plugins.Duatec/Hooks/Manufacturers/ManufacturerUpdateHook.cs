using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Manufacturers
{
    [HookAttachment(key: HookKeys.Manufacturer.Update)]
    internal class ManufacturerUpdateHook : TypedValidatedUpdateHook<Company>
    {
        protected override IActionResult? OnPreValidate(Company record, Entity? entity, RecordManagePageModel pageModel)
        {
            var oldRec = RepositoryService.CompanyRepository.Find(record.Id!.Value);
            record.EplanId = oldRec!.EplanId;

            return null;
        }
    }
}
