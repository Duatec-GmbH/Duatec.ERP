﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Delete)]
    internal class PartListDeleteHook : TypedValidatedDeleteHook<PartList>
    {
        protected override IActionResult? OnValidationSuccess(PartList record, Entity entity, BaseErpPageModel pageModel)
        {
            if (new PartListRepository().Delete(record.Id!.Value) is not PartList deleted)
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete part list");
                return pageModel.LocalRedirect(Url.RemoveParameter(pageModel.CurrentUrl, "hookKey"));
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(GetReturnUrl(pageModel));

            var returnUrl = $"/{pageModel.ErpRequestContext.App?.Name}/projects/projects/r/{deleted.Project}";
            return pageModel.LocalRedirect(returnUrl);
        }
    }
}
