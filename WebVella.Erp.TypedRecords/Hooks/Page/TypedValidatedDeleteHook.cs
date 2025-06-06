﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.TypedRecords.Hooks.Page.Base;

namespace WebVella.Erp.TypedRecords.Hooks.Page
{
    public class TypedValidatedDeleteHook<T> : ValidatedDeleteHookBase<T, BaseErpPageModel>, IPageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected override string ActionNameInPastTense => "deleted";

        protected override T MapRecord(EntityRecord rec)
            => TypedEntityRecordWrapper.Wrap<T>(rec);

        public IActionResult? OnGet(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPost(BaseErpPageModel pageModel)
            => Execute(pageModel);

        protected override List<ValidationError> Validate(T record, Entity entity, BaseErpPageModel pageModel)
            => ValidationService.ValidateOnDelete(record);
    }
}
