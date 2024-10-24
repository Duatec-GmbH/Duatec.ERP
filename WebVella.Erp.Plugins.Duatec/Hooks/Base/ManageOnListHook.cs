using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class ManageOnListHook : IParameterizedPageHook
    {
        protected virtual string IdProperty => "hId";

        public string[] Parameters => [IdProperty];

        protected abstract EntityRecord? Find(Guid id);

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if (!args.TryGetValue(IdProperty, out var idValue) || !Guid.TryParse(idValue, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format '{IdProperty}'");
                return null;
            }

            pageModel.DataModel.SetRecord(Find(id));
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }
    }
}
