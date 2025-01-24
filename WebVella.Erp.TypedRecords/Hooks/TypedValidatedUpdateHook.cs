using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Api;
using WebVella.Erp.TypedRecords.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.TypedRecords.Hooks
{
    public class TypedValidatedUpdateHook<T> : IRecordManagePageHook
        where T : TypedEntityRecordWrapper, new()
    {
        protected virtual string ActionNameInPastTense => "updated";

        protected virtual bool AutoSetUntouchedFields => true;

        IActionResult? IRecordManagePageHook.OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => OnPostUpdate(TypedEntityRecordWrapper.Wrap<T>(record), pageModel);

        IActionResult? IRecordManagePageHook.OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => OnPreUpdate(TypedEntityRecordWrapper.Wrap<T>(record), pageModel, validationErrors);

        protected virtual IActionResult? OnPreValidate(T record, T unmodified, RecordManagePageModel pageModel)
            => null;

        protected virtual IActionResult? OnValidationFailure(T record, T unmodified, RecordManagePageModel pageModel)
            => null;

        protected virtual IActionResult? OnValidationSuccess(T record, T unmodified, RecordManagePageModel pageModel)
            => null;

        protected virtual List<ValidationError> Validate(T record, T unmodified, RecordManagePageModel pageModel)
            => ValidationService.ValidateOnUpdate(record);

        protected virtual IActionResult? OnPostUpdate(T record, RecordManagePageModel pageModel)
        {
            var msg = SuccessMessage(record.EntityName);
            pageModel.PutMessage(ScreenMessageType.Success, msg);
            return null;
        }

        protected virtual IActionResult? OnPreUpdate(T record, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var unmodified = GetUnmodified(record.Id!.Value, record.EntityName);

            if(AutoSetUntouchedFields)
                SetNotPresentProperties(record, unmodified);

            var result = OnPreValidate(record, unmodified, pageModel);
            if (result != null)
                return result;

            validationErrors.AddRange(Validate(record, unmodified, pageModel));

            if (validationErrors.Count > 0)
                return OnValidationFailure(record, unmodified, pageModel);

            return OnValidationSuccess(record, unmodified, pageModel);
        }

        private static void SetNotPresentProperties(T record, T unmodified)
        {
            foreach (var (key, value) in unmodified.Properties)
            {
                if (!record.Properties.ContainsKey(key))
                    record[key] = value;
            }
        }

        private static T GetUnmodified(Guid recordId, string entity)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = "id",
                FieldValue = recordId
            };

            var recMan = new RecordManager();
            var rec = recMan.Find(new EntityQuery(entity, "*", query)).Object.Data
                .Single();

            return TypedEntityRecordWrapper.Wrap<T>(rec);
        }

        protected string SuccessMessage(string entity)
        {
            entity = EntityExtensions.FancyfyPascalCase(entity);
            return $"Successfully {ActionNameInPastTense} {entity}";
        }
    }
}
