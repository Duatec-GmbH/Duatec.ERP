using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

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
    }
}
