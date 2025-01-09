using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Base
{
    public abstract class ManageOnListHookBase : IPageHook
    {
        protected virtual string IdParameter => "hId";

        protected abstract EntityRecord? Find(Guid id);

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(IdParameter, out var idValue) || !Guid.TryParse(idValue, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid format '{IdParameter}'");
                return null;
            }

            var rec = Find(id);
            pageModel.DataModel.SetRecord(rec);

            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }
    }
}
