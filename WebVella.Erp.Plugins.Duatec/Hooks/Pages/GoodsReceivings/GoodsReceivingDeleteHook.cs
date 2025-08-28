using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Delete)]
    internal class GoodsReceivingDeleteHook : TypedValidatedDeleteHook<GoodsReceiving>
    {
        protected override IActionResult? OnValidationSuccess(GoodsReceiving record, Entity entity, BaseErpPageModel pageModel)
        {
            void TransactionalAction()
            {
                var recMan = new RecordManager();
                var id = record.Id!.Value;


                if (new GoodsReceivingRepository(recMan).Delete(id) == null)
                    throw new DbException("Could not delete goods receiving record");

                if (record.HasBeenStored)
                {
                    var inventoryRepo = new InventoryRepository(recMan);
                    var entries = inventoryRepo.FindManyBookingsByTaggedRecord(record.EntityName, id);

                    foreach(var entry in entries)
                    {
                        if (inventoryRepo.ReverseBooking(entry.Id!.Value) == null)
                            throw new DbException("Could not reverse booking");
                    }
                }
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.BeforeRender();
                return pageModel.Page();
            }

            base.OnPostModification(record, entity, pageModel);
            return pageModel.LocalRedirect(GetReturnUrl(pageModel));
        }
    }
}
