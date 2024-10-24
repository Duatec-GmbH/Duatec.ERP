using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class DeleteOnListHookBase : IParameterizedPageHook
    {
        protected virtual string IdProperty => "hId";

        public string[] Parameters => [IdProperty];

        protected string EntityName => Text.FancyfySnakeCase(Entity);

        protected abstract string Entity { get; }

        protected abstract string? RecordLabel(Guid id);

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if (!args.TryGetValue(IdProperty, out var idVal) || !Guid.TryParse(idVal, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format '{IdProperty}'");
                return null;
            }

            var label = RecordLabel(id);
            var response = new RecordManager().DeleteRecord(Entity, id);

            if (!response.Success)
                pageModel.PutMessage(ScreenMessageType.Error, $"Error: {response.Message}");
            else
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully deleted {EntityName} '{label}'");

            return pageModel.RedirectToPage();
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }
    }
}
