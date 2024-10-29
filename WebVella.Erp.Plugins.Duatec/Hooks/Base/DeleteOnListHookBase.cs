using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class DeleteOnListHookBase : IParameterizedPageHook
    {
        protected virtual string IdParameter => "hId";

        public string[] Parameters => [IdParameter];

        protected string EntityName => Text.FancyfySnakeCase(Entity);

        protected abstract string Entity { get; }

        protected abstract string? RecordLabel(Guid id);

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            pageModel.CurrentUrl = Url.RemoveParameter(url, IdParameter);

            if (!args.TryGetValue(IdParameter, out var idVal) || !Guid.TryParse(idVal, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format '{IdParameter}'");
                return null;
            }

            var label = RecordLabel(id);
            var response = new RecordManager().DeleteRecord(Entity, id);

            if (!response.Success)
                pageModel.PutMessage(ScreenMessageType.Error, $"Error: {response.Message}");
            else
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully deleted {EntityName} '{label}'");

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }
    }
}
