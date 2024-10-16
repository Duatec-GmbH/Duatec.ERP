using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment("article_type_delete")]
    internal class ArticleTypeDeleteHook : IParameterizedPageHook
    {
        private const string idParam = "hId";

        public string[] Parameters => [ idParam ];

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if(!args.TryGetValue(idParam, out var idVal) || !Guid.TryParse(idVal, out var id))
            {
                pageModel.PutMessage(ScreenMessageType.Error, $"Invalid argument '{idParam}'");
                return null;
            }

            var response = new RecordManager().DeleteRecord(ArticleType.Entity, id);
            if (!response.Success)
                pageModel.PutMessage(ScreenMessageType.Error, $"Error: {response.Message}");

            return null!;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }
    }
}
