using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment("manufacturer_create")]
    internal class ManufacturerCreateHook : IRecordCreatePageHook
    {
        public IActionResult OnPostCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel)
        {
            return null!;
        }

        public IActionResult OnPreCreateRecord(EntityRecord record, Entity entity, RecordCreatePageModel pageModel, List<ValidationError> validationErrors)
        {
            throw new NotImplementedException();
        }
    }
}
