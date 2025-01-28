using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Api;
using WebVella.Erp.TypedRecords.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.TypedRecords.Hooks
{
    [HookAttachment(key: "validated-update")]
    internal class ValidatedUpdateHook : IRecordManagePageHook
    {

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var msg = SuccessMessage(entity.Name);
            pageModel.PutMessage(ScreenMessageType.Success, msg);
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var unmodified = GetUnmodified((Guid)record["id"], entity.Name);
            SetNotPresentProperties(record, unmodified);

            validationErrors.AddRange(
                ValidationService.ValidateOnUpdate(record, entity.Name));

            return null;

        }

        private static void SetNotPresentProperties(EntityRecord record, EntityRecord unmodified)
        {
            foreach (var (key, value) in unmodified.Properties)
            {
                if (!record.Properties.ContainsKey(key))
                    record[key] = value;
            }
        }

        private static EntityRecord GetUnmodified(Guid recordId, string entity)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = "id",
                FieldValue = recordId
            };

            var recMan = new RecordManager();
            return recMan.Find(new EntityQuery(entity, "*", query)).Object.Data
                .Single();
        }

        protected static string SuccessMessage(string entity)
        {
            entity = EntityExtensions.FancyfySnakeCase(entity);
            return $"Successfully updated {entity}";
        }
    }
}
