using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: HookKeys.Inventory.Move)]
    internal class InventoryEntryMoveHook : TypedValidatedManageHook<InventoryEntry>
    {
        const decimal eps = 0.005m;

        protected override string ActionNameInPastTense => "moved";

        protected override List<ValidationError> Validate(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var result = base.Validate(record, unmodified, pageModel);

            if (OriginAndTargetAreSame(record, unmodified))
                result.Add(new ValidationError(string.Empty, "Can not move article without changes at project and/or location"));

            var max = unmodified.Amount;
            var amount = record.Amount;

            if (amount >= max + eps)
                result.Add(new ValidationError(InventoryEntry.Fields.Amount, $"Amount must not be greater than {max}"));

            return result;
        }

        protected override IActionResult? OnValidationFailure(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            pageModel.DataModel.SetRecord(record);
            return null;
        }

        protected override IActionResult? OnValidationSuccess(InventoryEntry record, InventoryEntry unmodified, RecordManagePageModel pageModel)
        {
            var id = record.Id!.Value;
            var comment = pageModel.GetFormValue("comment");

            var article = record.GetArticle();
            var articleType = article.GetArticleType();

            if (!articleType.IsDivisible)
                record.Denomination = 0;

            void TransactionalAction()
            {
                var booking = new InventoryBooking()
                {
                    Amount = record.Amount,
                    Denomination = record.Denomination,
                    ArticleId = record.Article,
                    ProjectId = record.Project,
                    ProjectSourceId = unmodified.Project,
                    WarehouseLocationId = record.WarehouseLocation,
                    WarehouseLocationSourceId = unmodified.WarehouseLocation,
                    UserId = pageModel.CurrentUser.Id,
                    Kind = InventoryBookingKind.Move,
                    Timestamp = DateTime.Now,
                    Comment = comment,
                    TaggedRecordId = null,
                    TaggedEntityName = null,
                    TaggedObject = null,
                };

                var repo = new InventoryRepository();

                record = (record.Amount >= unmodified.Amount - eps
                    ? repo.Update(record)
                    : repo.MovePartial(record))!;

                if (record == null)
                    throw new DbException("Could not move inventory entry");
                
                if(record.WarehouseLocation != Guid.Empty 
                    && article.PreferedWarehouseLocation.HasValue
                    && article.PreferedWarehouseLocation != Guid.Empty 
                    && unmodified.WarehouseLocation == article.PreferedWarehouseLocation)
                {

                    var entries = repo.FindManyByArticle(unmodified.Article);

                    if(!entries.Exists(e => e.WarehouseLocation == article.PreferedWarehouseLocation))
                    {
                        article.PreferedWarehouseLocation = record.WarehouseLocation;

                        try
                        {
                            new ArticleRepository(new RecordManager(null, true, true)).Update(article);
                        }
                        catch 
                        { 
                            // if this fails, prefered warehouse location is not updated
                        }                        
                    }
                }

                if (repo.InsertBooking(booking) == null)
                    throw new DbException("Could not insert booking");
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                OnValidationFailure(record, unmodified, pageModel);
                pageModel.BeforeRender();
                return pageModel.Page();
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
            {
                if (pageModel.ReturnUrl.Contains($"{id}"))
                    pageModel.ReturnUrl = pageModel.ReturnUrl.Replace($"{id}", $"{record.Id!.Value}");
                return pageModel.LocalRedirect(pageModel.ReturnUrl);
            }
            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }

        private static bool OriginAndTargetAreSame(InventoryEntry a, InventoryEntry b)
        {
            return a.WarehouseLocation == b.WarehouseLocation
                && (NullOrEmpty(a.Project) && NullOrEmpty(b.Project)
                || a.Project == b.Project);
        }

        private static bool NullOrEmpty(Guid? id)
            => !id.HasValue || id.Value == Guid.Empty;
    }
}
