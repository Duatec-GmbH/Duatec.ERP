using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: "inventory_booking_undo")]
    internal class InventoryBookingUndoHook : IPageHook
    {
        public IActionResult? OnGet(BaseErpPageModel pageModel)
            => null;

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!Guid.TryParse(pageModel.GetFormValue("id"), out var id))
                return pageModel.BadRequest();

            void TransactionalAction()
            {
                if (new InventoryRepository().ReverseBooking(id) == null)
                    throw new DbException("Could not reverse booking");
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully restored inventory entry");

            return null;
        }
    }
}
