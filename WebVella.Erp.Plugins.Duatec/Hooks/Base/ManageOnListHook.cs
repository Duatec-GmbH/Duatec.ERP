using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class ManageOnListHook : IParameterizedPageHook
    {
        private const string idParam = "hId";

        public string[] Parameters => [idParam];

        protected abstract EntityRecord? Find(Guid id);

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if (!args.TryGetValue(idParam, out var idValue) || !Guid.TryParse(idValue, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format '{idParam}'");
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
