using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class WarehouseLocationController : Controller
    {
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/w/warehouse-locations/select-update-info")]
        public ActionResult GetUpdateInfo([FromQuery] DateTime dateTimeUtc)
        {
            if (dateTimeUtc < DateTime.MinValue.AddSeconds(2) 
                || (dateTimeUtc.AddSeconds(-2) > ChangeDetection.LastWarehouseLocationChangeTimeUtc && dateTimeUtc.AddSeconds(-2) > ChangeDetection.LastWarehouseChangeTimeUtc))
                return Json(new SelectUpdateInfo());

            var data = new WarehouseRepository().FindAllEntries($"*, ${WarehouseLocation.Relations.Warehouse}.{Warehouse.Fields.Designation}")
                .OrderBy(r => r.GetWarehouse().Designation)
                .ThenBy(r => r.Designation)
                .Select(r => new SelectOption()
                {
                    Id = r.Id!.Value,
                    Text = $"{r.GetWarehouse().Designation} - {r.Designation}"
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
