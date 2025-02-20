using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists.Common;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.PartLists
{
    [HookAttachment(key: HookKeys.PartList.Create)]
    internal class PartListCreateHook : TypedValidatedCreateHook<PartList>
    {
        protected override IActionResult? OnPreValidate(PartList record, RecordCreatePageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue("pId", out var projectIdVal) || !Guid.TryParse(projectIdVal, out var projectId))
                return pageModel.BadRequest();

            record.Project = projectId;

            return null;
        }

        protected override List<ValidationError> Validate(PartList record, RecordCreatePageModel pageModel)
        {
            var errors = base.Validate(record, pageModel);
            errors.AddRange(PartListHook.ValidateEntries(pageModel));
            pageModel.Validation.Errors = errors;
            return errors;
        }

        protected override IActionResult? OnValidationFailure(PartList record, RecordCreatePageModel pageModel)
        {
            PartListHook.SetUpErrorPage(pageModel, record);
            return pageModel.Page();
        }

        protected override IActionResult? OnValidationSuccess(PartList record, RecordCreatePageModel pageModel)
        {
            var formValues = PartListHook.GetEntryFormValues(pageModel);

            void TransactionalAction()
            {
                var repo = new PartListRepository();
                record = repo.Insert(record)
                    ?? throw new DbException("Could not insert part list record");

                var entries = formValues.Select(fv => new PartListEntry()
                {
                    Amount = fv.Amount,
                    ArticleId = fv.ArticleId,
                    DeviceTag = string.Empty,
                    PartListId = record.Id!.Value

                }).ToArray();

                if (repo.InsertManyEntries(entries).Count != entries.Length)
                    throw new DbException("Could not insert part list entry record");
            }

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                PartListHook.SetUpErrorPage(pageModel, record);
                return pageModel.Page();
            }

            return pageModel.LocalRedirect(GetReturnUrl(pageModel, record.Id!.Value));
        }
    }
}
