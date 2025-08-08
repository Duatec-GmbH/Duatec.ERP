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
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: HookKeys.Inventory.Create)]
    internal class InventoryEntryCreateHook : TypedValidatedCreateHook<InventoryEntry>
    {
        protected override IActionResult? OnValidationSuccess(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            var userId = pageModel.TryGetDataSourceProperty<ErpUser>("CurrentUser")!.Id;

            var id = Guid.NewGuid();
            record.Id = id;
            var comment = pageModel.GetFormValue("comment");

            void TransactionalAction()
            {
                var amount = record.Amount; // gets changed on insert, thats why we save that here

                var repo = new InventoryRepository();
                if (repo.Insert(record) == null)
                    throw new DbException("Could not create inventory entry record");

                var booking = new InventoryBooking()
                {
                    Amount = amount,
                    ArticleId = record.Article,
                    Kind = InventoryBookingKind.Store,
                    Timestamp = DateTime.Now,
                    ProjectId = record.Project,
                    ProjectSourceId = record.Project,
                    WarehouseLocationId = record.WarehouseLocation,
                    WarehouseLocationSourceId = record.WarehouseLocation,
                    Denomination = record.Denomination,
                    UserId = userId,
                    Comment = comment,
                };

                if (repo.InsertBooking(booking) == null)
                    throw new DbException("Could not create booking entry");
            }

            if (!Transactional.TryExecute(TransactionalAction))
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not create inventory entry");
                return pageModel.LocalRedirect(Url.RemoveParameter(pageModel.CurrentUrl, "hookKey"));
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect(pageModel.EntityListUrl());
        }
    }
}
