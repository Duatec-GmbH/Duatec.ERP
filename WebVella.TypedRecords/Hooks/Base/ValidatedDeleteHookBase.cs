using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;

namespace WebVella.TypedRecords.Hooks.Base
{
    public abstract class ValidatedDeleteHookBase<TRecord, TModel> : ValidatedModificationHookBase<TRecord, TModel>
        where TRecord : EntityRecord
        where TModel : BaseErpPageModel
    {
        protected virtual TRecord GetRecord(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<TRecord>("Record");

        protected virtual Entity? GetEntity(BaseErpPageModel pageModel)
            => pageModel.TryGetDataSourceProperty<Entity>("Entity");

        protected IActionResult? Execute(TModel pageModel)
        {
            var entity = GetEntity(pageModel);
            var record = GetRecord(pageModel);

            var errors = new List<ValidationError>();
            var result = Execute(record, entity!, pageModel, errors);
            if (result != null)
                return result;

            if (errors.Count == 0)
                return pageModel.LocalRedirect(pageModel.EntityListUrl());

            var url = pageModel.EntityListUrl(Url.RemoveParameters(pageModel.CurrentUrl));
            return pageModel.LocalRedirect(url);
        }

        protected virtual void PutErrorMessage(TModel pageModel, Entity? entity)
        {
            var msg = entity == null ? "Failure"
                : $"Failed to delete '{entity.FancyName()}'";

            pageModel.PutMessage(ScreenMessageType.Error, msg);
        }
    }
}
