using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists.Common;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Update)]
    internal class PartListUpdateHook : TypedValidatedManageHook<PartList>
    {
        protected override List<ValidationError> Validate(PartList record, PartList unmodified, RecordManagePageModel pageModel)
        {
            var errors = base.Validate(record, unmodified, pageModel);
            errors.AddRange(PartListHook.ValidateEntries(pageModel));
            pageModel.Validation.Errors = errors;
            return errors;
        }

        protected override IActionResult? OnValidationFailure(PartList record, PartList unmodified, RecordManagePageModel pageModel)
        {
            PartListHook.SetUpErrorPage(pageModel, record);
            return pageModel.Page();
        }

        protected override IActionResult? OnValidationSuccess(PartList record, PartList unmodified, RecordManagePageModel pageModel)
        {
            var formValues = PartListHook.GetEntryFormValues(pageModel);
            var repo = new PartListRepository();
            var oldPartListEntries = repo.FindManyEntriesByPartList(record.Id!.Value);

            var toAdd = formValues
                .Where(t => !oldPartListEntries.Exists(ple => ple.ArticleId == t.ArticleId))
                .ToArray();

            var toUpdate = oldPartListEntries
                .Where(ple => formValues.Exists(fv => fv.ArticleId == ple.ArticleId && fv.Amount != ple.Amount));

            var toDelete = oldPartListEntries
                .Where(ple => !formValues.Exists(fv => fv.ArticleId == ple.ArticleId))
                .Select(ple => ple.Id!.Value)
                .ToArray();
            
            void TransactionalAction()
            {
                if (repo.Update(record) == null)
                    throw new DbException($"could not update record");

                if (toDelete.Length > 0 && repo.DeleteManyEntries(toDelete).Count == 0)
                    throw new DbException($"Could not delete part list entry records");

                if(toAdd.Length > 0)
                {
                    var entries = toAdd.Select(fv => new PartListEntry()
                    {
                        Amount = fv.Amount,
                        ArticleId = fv.ArticleId,
                        DeviceTag = string.Empty,
                        PartListId = record.Id.Value
                    });

                    if (repo.InsertManyEntries(entries).Count != toAdd.Length)
                        throw new DbException("Could not insert part list entries");
                }

                foreach(var entry in toUpdate)
                {
                    var amount = formValues.Find(t => t.ArticleId == entry.ArticleId).Amount;
                    if(entry.Amount != amount)
                    {
                        entry.Amount = amount;
                        if (repo.UpdateEntry(entry) == null)
                            throw new DbException("Could not update record");
                    }
                }
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                PartListHook.SetUpErrorPage(pageModel, record);
                return pageModel.Page();
            }

            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }
    }
}
