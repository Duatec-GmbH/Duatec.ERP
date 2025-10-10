using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Diagnostics;
using WebVella.Erp.Web.Services;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class FileController : Controller
    {
        [AllowAnonymous]
        [Route("api/v3.0/f/files/javascript")]
#if !DEBUG
        [ResponseCache(NoStore = false, Duration = 24 * 3600)]
#endif
        [HttpGet]
        public ContentResult GetScript([FromQuery] string file = "")
        {
            if (string.IsNullOrWhiteSpace(file))
                return Content("", "text/javascript");
            try
            {
                var cacheKey = new RenderService().GetCacheKey();

                if (!string.IsNullOrWhiteSpace(cacheKey) && file.EndsWith($"-{cacheKey}.js"))
                    file = file[0..file.LastIndexOf($"-{cacheKey}.js")] + ".js";

                var jsContent = FileService.GetEmbeddedTextResource(file, "WebVella.Erp.Plugins.Duatec.Scripts", "WebVella.Erp.Plugins.Duatec");

                return Content(jsContent, "text/javascript");
            }
            catch (Exception ex)
            {
                new Log().Create(LogType.Error, file + " API File get Method Error", ex);
                throw;
            }
        }
    }
}
