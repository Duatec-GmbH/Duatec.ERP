using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
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
        [ResponseCache(NoStore = true, Duration = 0)]
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

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/a/articles/{id}/location-suggestion")]
        public ActionResult GetWarehouseLocationSuggestion([FromRoute] Guid id, [FromQuery] decimal denomination = 0m)
        {
            var recMan = new RecordManager();

            var article = new ArticleRepository(recMan).Find(id);

            if (article == null)
                return Json(null);

            return Json(Suggest.WarehouseLocation(article, denomination, null, recMan));
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/a/articles/import/suggestion")]
        public async Task<ActionResult> GetArticleImportSuggesions([FromQuery] string search, [FromQuery] int resultSize = 0, [FromQuery] bool excludeArticlesFromDataBase = false)
        {
            if (string.IsNullOrWhiteSpace(search))
                return Json(Array.Empty<object>());

            var suggestions = await Suggest.Articles2Import(search, resultSize, excludeArticlesFromDataBase);

            if(resultSize > 0 && suggestions.Count > resultSize)
                suggestions = [.. suggestions.Take(resultSize)];

            return Json(suggestions);
        }
    }
}
