using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Projects
{
    [Obsolete]
    [HookAttachment(key: HookKeys.Project.Complete)]
    internal class ProjectCompleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            if (!pageModel.RecordId.HasValue)
                return pageModel.BadRequest();

            return null;
        }
    }
}
