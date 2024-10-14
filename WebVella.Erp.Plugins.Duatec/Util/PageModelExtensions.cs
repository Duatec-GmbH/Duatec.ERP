using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class PageModelExtensions
    {
        public static string GetFormValue(this BaseErpPageModel pageModel, string id)
        {
            var form = pageModel.Request.Form;
            if (form.ContainsKey(id) && !string.IsNullOrWhiteSpace(form[id]))
                return form[id]!;
            return string.Empty;
        }

        public static void PutMessage(this BaseErpPageModel pageModel, ScreenMessageType type, string message)
        {
            pageModel.TempData.Put("ScreenMessage", new ScreenMessage()
            {
                Message = message,
                Type = type,
                Title = type.ToString()
            });
        }
    }
}
