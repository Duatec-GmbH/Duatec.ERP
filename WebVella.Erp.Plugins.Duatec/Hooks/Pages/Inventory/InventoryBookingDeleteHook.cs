using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: "inventory_booking_delete")]
    internal class InventoryBookingDeleteHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (pageModel.CurrentUser?.IsAdmin is not true)
                return pageModel.Unauthorized();

            if (!Guid.TryParse(pageModel.GetFormValue("id"), out var id))
                return pageModel.BadRequest();

            void TransactionalAction()
            {
                if (new InventoryRepository().DeleteBooking(id) == null)
                    throw new DbException("Could not delete booking");
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully deleted history entry");
                var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
                return pageModel.LocalRedirect(url);
            }

            return null;
        }
    }
}
