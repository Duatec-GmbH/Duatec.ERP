using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;
using WebVella.Erp.TypedRecords.Util;
using System.Web;

namespace WebVella.Erp.TypedRecords.Hooks.Page.Base
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
            var recMan = new RecordManager();

            var entity = GetEntity(pageModel);
            var record = MapRecord(GetRecord(pageModel, recMan, entity));

            var errors = new List<ValidationError>();
            var result = Execute(record, entity, pageModel, errors);
            if (result != null)
                return result;

            string url;

            if (errors.Count == 0)
            {
                var response = recMan.DeleteRecord(entity, pageModel.RecordId!.Value);
                if (!response.Success || response.Object?.Data == null || response.Object.Data.Count != 1)
                    return OnError(pageModel, entity, response);

                record = MapRecord(response.Object.Data[0]);

                result = OnPostModification(record, entity, pageModel);
                if (result != null)
                    return result;

                return pageModel.LocalRedirect(GetReturnUrl(pageModel));
            }

            pageModel.PutMessage(ScreenMessageType.Error, string.Join(Environment.NewLine, errors.Select(e => e.Message)));

            url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            return pageModel.LocalRedirect(url);
        }

        private EntityRecord GetRecord(TModel pageModel, RecordManager recMan, Entity entity)
        {
            var record = MapRecord(pageModel.TryGetDataSourceProperty<EntityRecord>("Record"));
            if (!record.Properties.ContainsKey("id"))
                record.Properties["id"] = pageModel.RecordId;

            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = "id",
                FieldValue = (Guid)record["id"]
            };

            return recMan.Find(new EntityQuery(entity.Name, "*", query)).Object.Data
                .Single();
        }

        protected virtual IActionResult? OnError(TModel pageModel, Entity entity, QueryResponse response)
        {
            var msg = $"Could not delete '{entity.FancyName()}'";
            pageModel.PutMessage(ScreenMessageType.Error, msg);

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            return pageModel.LocalRedirect(url);
        }

        protected static string GetReturnUrl(TModel pageModel)
        {
            if (string.IsNullOrWhiteSpace(pageModel.ReturnUrl))
                return pageModel.EntityListUrl();

            const string pattern = "returnUrl=";

            var idx = pageModel.ReturnUrl.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);
            if (idx < 0)
                return pageModel.ReturnUrl;

            idx += pattern.Length;
            return HttpUtility.UrlDecode(pageModel.ReturnUrl[idx..]);
        }
    }
}
