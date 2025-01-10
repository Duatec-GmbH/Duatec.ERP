using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Manufacturers
{
    [HookAttachment(key: HookKeys.Manufacturer.Create)]
    internal class ManufacturerCreateHook : IRecordCreatePageHook
    {
        private readonly static CompanyValidator _validator = new();

        public IActionResult? OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            var rec = TypedEntityRecordWrapper.WrapElseDefault<Company>(record)!;
            var errors = _validator.ValidateOnCreate(rec);
            validationErrors.AddRange(errors);

            return null;
        }
    }
}
