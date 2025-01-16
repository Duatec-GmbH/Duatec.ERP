using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Create)]
    internal class PartListCreateHook : TypedValidatedCreateHook<PartList>
    {
        protected override IActionResult? OnPreValidate(PartList record, Entity? entity, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue("pId", out var projectIdVal) || !Guid.TryParse(projectIdVal, out var projectId))
                return pageModel.BadRequest();

            record.Project = projectId;

            return null;
        }
    }
}
