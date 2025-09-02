using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        [Route("/api/v3.0/a/articles/denomination-lookup")]
        public ActionResult GetDenominationLookup()
        {
            var select = $"id, " +
                $"${Article.Relations.Type}.{ArticleType.Fields.IsDivisible}, " +
                $"${Article.Relations.Type}.{ArticleType.Fields.Unit}";

            var result = new ArticleRepository().FindAll(select)
                .ToDictionary(a => a.Id!.Value, a => new
                {
                    isDivisible = a.GetArticleType().IsDivisible,
                    unit = a.GetArticleType().Unit
                });

            return Json(result);
        }


        [HttpGet]
        [Route("/api/v3.0/a/articles/select-update-info")]
        public ActionResult GetUpdateInfo([FromQuery] DateTime dateTimeUtc)
        {
            if(dateTimeUtc < DateTime.MinValue.AddSeconds(2) || dateTimeUtc.AddSeconds(-2) > ChangeDetection.LastArticleChangeTimeUtc)
                return Json(new SelectUpdateInfo());

            var data = new ArticleRepository().FindAll()
                .OrderBy(r => r.PartNumber)
                .Select(r => new SelectOption() 
                { 
                    Id = r.Id!.Value, 
                    Text = $"{r.PartNumber} - {r.TypeNumber} - {r.Designation}" 
                })
                .ToList();

            return Json(new SelectUpdateInfo()
            {
                HasChanged = true,
                Data = data
            });
        }
    }
}
