using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/qr/inventory")]
        public IActionResult ResolveInventoryQRCode([FromQuery] Guid articleId, [FromQuery] decimal? denomination, [FromQuery] Guid warehouseLocationId)
        {
            var recMan = new RecordManager();

            var article = new ArticleRepository(recMan).Find(articleId, $"*, ${Article.Relations.Type}.*");

            if (article == null)
                return NotFound();

            var location = new WarehouseRepository(recMan).FindEntry(warehouseLocationId);

            if (location == null)
                return NotFound();

            var inventoryRepo = new InventoryRepository(recMan);

            var resultSet = inventoryRepo.FindManyByArticle(articleId)
                .Where(r => r.WarehouseLocation == warehouseLocationId);

            if (denomination.HasValue)
            {
                if (!article.GetArticleType().IsDivisible && denomination.Value != 0)
                    return NotFound();

                resultSet = resultSet.Where(r => r.Denomination == denomination.Value);
            }

            var entries = resultSet.ToList();

            var url = string.Empty;
            if (entries.Count == 0)
                url = $"/inventory-management/inventory/inventory/c/create?article={articleId}&denomination={denomination ?? 0}&location={warehouseLocationId}";
            else if (entries.Count == 1 && !entries[0].Project.HasValue)
                url = $"/inventory-management/inventory/inventory/r/{entries[0].Id}/detail";
            else
            {
                url = $"/inventory-management/inventory/inventory/l/all?q_article_v={articleId}&q_warehouse_location_v={warehouseLocationId}";
                if (denomination.HasValue)
                    url += $"&q_denomination_t=EQ&q_denomination_t={denomination}";
            }

            return LocalRedirect(url);
        }
    }
}
