using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class DeleteOnListHookBase : IPageHook
    {
        protected virtual string IdParameter => "hId";

        protected string EntityName => Text.FancyfySnakeCase(Entity);

        protected abstract string Entity { get; }

        protected abstract string? RecordLabel(Guid id);

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, IdParameter);

            if(!pageModel.Request.Query.TryGetValue(IdParameter, out var idVal) || !Guid.TryParse(idVal, out var id) || id == Guid.Empty)
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Error: no id");
                return null;
            }

            var label = RecordLabel(id);
            var response = new RecordManager().DeleteRecord(Entity, id);

            if (!response.Success)
                pageModel.PutMessage(ScreenMessageType.Error, $"Error: {response.GetMessage()}");
            else
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully deleted {EntityName} '{label}'");

            return pageModel.LocalRedirect(url);
        }
    }
}
