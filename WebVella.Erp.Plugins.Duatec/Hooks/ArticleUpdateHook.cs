using WebVella.Erp.Hooks;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "article_update")]
    public class ArticleUpdateHook : IRecordManagePageHook
    {
        public IActionResult OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null!;
        }

        public IActionResult OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            throw new NotImplementedException();
        }
    }
}
