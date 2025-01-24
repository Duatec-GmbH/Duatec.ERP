using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.TypedRecords.Hooks.Base;
using WebVella.Erp.TypedRecords.Validation;
using WebVella.Erp.Api;

namespace WebVella.Erp.TypedRecords.Hooks
{
    [HookAttachment(key: "validated-update")]
    internal class ValidatedUpdateHook : ValidatedModificationHookBase<EntityRecord, RecordManagePageModel>, IRecordManagePageHook
    {
        protected override string ActionNameInPastTense => "updated";

        protected override IActionResult? OnPreValidate(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = "id",
                FieldValue = record["id"]
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

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
            => OnPostModification(record, entity, pageModel);

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
            => Execute(record, entity, pageModel, validationErrors);

        protected override List<ValidationError> Validate(EntityRecord record, Entity? entity, RecordManagePageModel pageModel)
            => ValidationService.ValidateOnUpdate(record, entity!.Name);
    }
}
