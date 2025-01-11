using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.TypedRecords.Hooks.Base;
using WebVella.TypedRecords.Validation;

namespace WebVella.TypedRecords.Hooks
{
    [HookAttachment(key: "validated-delete")]
    internal class ValidatedDeleteHook : ValidatedDeleteHookBase<EntityRecord, BaseErpPageModel>, IPageHook
    {
        protected override string ActionNameInPastTense => "deleted";

        protected override List<ValidationError> Validate(EntityRecord record, Entity? entity)
            => ValidationService.ValidateOnCreate(record, entity!.Name);

        public virtual IActionResult? OnGet(BaseErpPageModel pageModel)
            => null;

        public virtual IActionResult? OnPost(BaseErpPageModel pageModel)
            => Execute(pageModel);
    }
}
