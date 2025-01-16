using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.TypedRecords.Util;

namespace WebVella.Erp.TypedRecords.Hooks.Base
{
    public abstract class ValidatedDeleteHookBase<TRecord, TModel> : ValidatedModificationHookBase<TRecord, TModel>
        where TRecord : EntityRecord
        where TModel : BaseErpPageModel
    {
        protected abstract TRecord MapRecord(EntityRecord rec);

        protected virtual Entity GetEntity(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<Entity>("Entity");

        protected IActionResult? Execute(TModel pageModel)
        {
            var entity = GetEntity(pageModel);
            var record = MapRecord(pageModel.TryGetDataSourceProperty<EntityRecord>("Record"));

            if (!record.Properties.TryGetValue("id", out var objId))
                record.Properties["id"] = pageModel.RecordId;

            var errors = new List<ValidationError>();
            var result = Execute(record, entity, pageModel, errors);
            if (result != null)
                return result;

            string url;

            if (errors.Count == 0)
            {
                var recMan = new RecordManager();

                var response = recMan.DeleteRecord(entity, pageModel.RecordId!.Value);
                if (!response.Success || response.Object?.Data == null || response.Object.Data.Count != 1)
                    return OnError(pageModel, entity, response);

                record = MapRecord(response.Object.Data[0]);

                result = OnPostModification(record, entity, pageModel);
                if (result != null)
                    return result;

                url = pageModel.EntityListUrl();
                return pageModel.LocalRedirect(url);
            }

            url = Url.RemoveParameters(pageModel.CurrentUrl);
            return pageModel.LocalRedirect(url);
        }

        protected virtual IActionResult? OnError(TModel pageModel, Entity entity, QueryResponse response)
        {
            var msg = $"Failed to delete '{entity.FancyName()}'";
            pageModel.PutMessage(ScreenMessageType.Error, msg);

            var url = Url.RemoveParameters(pageModel.CurrentUrl);
            return pageModel.LocalRedirect(url);
        }
    }
}
