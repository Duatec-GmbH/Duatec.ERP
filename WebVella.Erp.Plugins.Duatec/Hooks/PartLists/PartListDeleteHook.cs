using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Delete)]
    internal class PartListDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var record = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            var rec = TypedEntityRecordWrapper.WrapElseDefault<PartList>(record);

            if (rec == null)
                return pageModel.BadRequest();

            if (!RepositoryService.PartListRepository.Delete(rec.Id!.Value))
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete part list");
                return null;
            }

            var returnUrl = $"/{pageModel.ErpRequestContext.App?.Name}/projects/projects/r/{rec.Project}";
            return pageModel.LocalRedirect(returnUrl);
        }
    }
}
