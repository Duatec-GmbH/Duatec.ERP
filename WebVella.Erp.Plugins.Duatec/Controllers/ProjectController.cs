using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class ProjectController : Controller
    {
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/p/projects/select-update-info")]
        public ActionResult GetUpdateInfo([FromQuery] DateTime dateTimeUtc)
        {
            if (dateTimeUtc < DateTime.MinValue.AddSeconds(2) || dateTimeUtc.AddSeconds(-2) > ChangeDetection.LastProjectChangeTimeUtc)
                return Json(new SelectUpdateInfo());

            var data = new ProjectRepository().FindAll()
                .OrderByDescending(r => r.Number)
                .Select(r => new SelectOption()
                {
                    Id = r.Id!.Value,
                    Text = $"{r.Number} - {r.Name}"
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
        [AllowAnonymous]
        [Route("/api/v3.0/p/projects/{id}/part-list-select-options")]
        public ActionResult GetPartListSelectOptionsForProject([FromRoute] Guid id)
        {
            var recMan = new RecordManager();

            var partLists = new PartListRepository(recMan).FindManyByProject(id);

            return Json(partLists.OrderBy(pl => pl.Name).Select(pl => new SelectOption() { Id = pl.Id!.Value, Text = pl.Name })
                .ToList());
        }
    }
}
