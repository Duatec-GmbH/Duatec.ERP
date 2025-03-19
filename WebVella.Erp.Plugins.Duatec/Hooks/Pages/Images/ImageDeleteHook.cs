using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Images
{
    [HookAttachment(key: HookKeys.Image.Delete)]
    internal class ImageDeleteHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!Guid.TryParse(pageModel.GetFormValue("id"), out var id) || id == Guid.Empty)
                return pageModel.BadRequest();

            var repo = new ImageRepository();
            var record = repo.Find(id);

            if (record == null)
                return pageModel.BadRequest();

            var validationErrors = ValidationService.ValidateOnDelete(record);

            if(validationErrors.Count > 0)
            {
                var msg = string.Join(" ", validationErrors.Select(e => e.Message));
                pageModel.PutMessage(ScreenMessageType.Error, msg);
                pageModel.BeforeRender();
                return pageModel.Page();
            }
            
            void TransactionalAction()
            {
                if (repo.Delete(id) == null)
                    throw new DbException("Could not delete image");
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return pageModel.Page();

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            pageModel.PutMessage(ScreenMessageType.Success, "Successfully deleted image");

            return pageModel.LocalRedirect(url);
        }
    }
}
