using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Hooks.Base;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Base
{
    internal abstract class ListFullModificationHookBase<TCollection, TEntry, TModel> : ValidatedModificationHookBase<TCollection, TModel>
        where TCollection : TypedEntityRecordWrapper, new()
        where TEntry : TypedEntityRecordWrapper
        where TModel : BaseErpPageModel
    {
        protected abstract string RelationName { get; }

        protected abstract void PersistanceAction(TCollection record, List<TEntry> entries);

        protected abstract List<ValidationError> ValidateRecord(TCollection record);

        protected abstract IEnumerable<ValidationError> ValidateEntries(TCollection record, List<TEntry> entries);

        protected abstract List<TEntry> GetEntries(TModel pageModel);

        protected override List<ValidationError> Validate(TCollection record, Entity entity, TModel pageModel)
        {
            var result = ValidateRecord(record);

            result.AddRange(ValidateEntries(record, GetEntries(pageModel)));

            return result;
        }

        protected override IActionResult? OnValidationSuccess(TCollection record, Entity entity, TModel pageModel)
        {
            record.Id ??= Guid.NewGuid();
            var entries = GetEntries(pageModel);

            void TransactionalAction()
                => PersistanceAction(record, entries);

            if (!Transactional.TryExecute(pageModel, TransactionalAction))
                return FailureResult(record, pageModel, entries, []);

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(entity));

            return pageModel.LocalRedirect(pageModel.EntityDetailUrl(record.Id!.Value));
        }

        protected override IActionResult? OnValidationFailure(TCollection record, Entity entity, TModel pageModel, List<ValidationError> validationErrors)
        {
            var entries = GetEntries(pageModel);

            return FailureResult(record, pageModel, entries, validationErrors);
        }

        protected IActionResult FailureResult(TCollection record, TModel pageModel, List<TEntry> entries, List<ValidationError> validationErrors)
        {
            pageModel.Validation.Errors.AddRange(validationErrors);

            record[$"${RelationName}"] = entries.Select(e => (EntityRecord)e).ToList();
            pageModel.DataModel.SetRecord(record);

            pageModel.BeforeRender();

            return pageModel.Page();
        }
    }
}
