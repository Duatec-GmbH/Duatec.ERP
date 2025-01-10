using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles
{
    [HookAttachment(key: HookKeys.Article.Delete)]
    internal class ArticleDeleteHook : IRecordDetailsPageHook
    {
        public IActionResult? OnPost(RecordDetailsPageModel pageModel)
        {
            var id = (Guid)pageModel.TryGetDataSourceProperty<EntityRecord>("Record")["id"];
            var success = RepositoryService.ArticleRepository.Delete(id);

            if (!success)
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete record");
                return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
            }

            return pageModel.LocalRedirect(PageUrl.EntityList(pageModel));
        }
    }
}
