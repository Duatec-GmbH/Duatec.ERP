using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
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
        protected override IActionResult? OnPreValidate(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            if (!record.GetArticle().GetArticleType().IsDivisible)
                record.Denomination = 0;

            return null;
        }

        protected override IActionResult? OnValidationFailure(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            pageModel.DataModel.SetRecord(record);
            return null;
        }

        protected override List<ValidationError> Validate(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            var result = base.Validate(record, pageModel);

            if (!IsStockTaking(pageModel) && (!record.Project.HasValue || record.Project == Guid.Empty))
                result.Add(new ValidationError(InventoryEntry.Fields.Project, $"Project is required"));

            return result;
        }

        protected static bool IsStockTaking(BaseErpPageModel pageModel)
        {
            var comment = pageModel.GetFormValue("comment");

            if (string.IsNullOrWhiteSpace(comment))
                return false;

            comment = comment.Trim();

            return comment.Equals("inventur", StringComparison.OrdinalIgnoreCase) // German
                || comment.Equals("stocktaking", StringComparison.OrdinalIgnoreCase) // English
                ;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            var userId = pageModel.TryGetDataSourceProperty<ErpUser>("CurrentUser")!.Id;

            var id = Guid.NewGuid();
            record.Id = id;
            var comment = pageModel.GetFormValue("comment");

            void TransactionalAction()
            {
                var amount = record.Amount; // gets changed on insert, thats why we save that here

                var project = record.Project;
                record.Project = null;

                var repo = new InventoryRepository();
                if (repo.Insert(record) == null)
                    throw new DbException("Could not create inventory entry record");

                var booking = new InventoryBooking()
                {
                    Amount = amount,
                    ArticleId = record.Article,
                    Kind = InventoryBookingKind.Store,
                    Timestamp = DateTime.Now,
                    ProjectId = null,
                    ProjectSourceId = project,
                    WarehouseLocationId = record.WarehouseLocation,
                    WarehouseLocationSourceId = record.WarehouseLocation,
                    Denomination = record.Denomination,
                    UserId = userId,
                    Comment = comment,
                    TaggedRecordId = null,
                    TaggedEntityName = null,
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
