using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Orders
{
    [HookAttachment(key: HookKeys.Order.Delete)]
    internal class OrderDeleteHook : TypedValidatedDeleteHook<Order>
    {
        protected override IActionResult? OnValidationSuccess(Order record, Entity entity, BaseErpPageModel pageModel)
        {
            void TransactionalAction()
            {
                if (new OrderRepository().Delete(record.Id!.Value) == null)
                    throw new DbException("Could not delete order");
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not delete order");

                var url = Url.RemoveParameters(pageModel.CurrentUrl);
                return pageModel.LocalRedirect(url);
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));
            return pageModel.LocalRedirect(GetReturnUrl(pageModel));
        }
    }
}
