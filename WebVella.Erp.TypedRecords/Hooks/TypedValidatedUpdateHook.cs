using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Base;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Api;

namespace WebVella.Erp.TypedRecords.Hooks
{
    public class TypedValidatedUpdateHook<T> : ValidatedModificationHookBase<T, RecordManagePageModel>, IRecordManagePageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected override string ActionNameInPastTense => "updated";

        protected override IActionResult? OnPreValidate(T record, Entity entity, RecordManagePageModel pageModel)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = "id",
                FieldValue = record.Id
            };

            var recMan = new RecordManager();
            var unchanged = recMan.Find(new EntityQuery(entity.Name, "*", query)).Object?.Data?
                .SingleOrDefault();

            if (unchanged != null)
            {
                foreach (var (key, value) in unchanged.Properties)
                {
                    if (!record.Properties.ContainsKey(key))
                        record[key] = value;
                }
            }
            return null;
        }

        protected override List<ValidationError> Validate(T record, Entity entity, RecordManagePageModel pageModel)
            => ValidationService.ValidateOnUpdate(record);

        public IActionResult? OnPostManageRecord(T record, Entity entity, RecordManagePageModel pageModel)
            => OnPostModification(record, entity, pageModel);

        public IActionResult? OnPreManageRecord(T record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        IActionResult? IRecordManagePageHook.OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => OnPostManageRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel);

        IActionResult? IRecordManagePageHook.OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => OnPreManageRecord(TypedEntityRecordWrapper.Wrap<T>(record), entity, pageModel, validationErrors);
    }
}
