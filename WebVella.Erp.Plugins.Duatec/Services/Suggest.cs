using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class Suggest
    {
        public static Guid? WarehouseLocation(Article article, decimal denomination, Guid? projectId, RecordManager? recMan = null)
        {
            if (article.PreferedWarehouseLocation.HasValue)
                return article.PreferedWarehouseLocation.Value;

            recMan ??= new();
            var repo = new InventoryRepository(recMan);

            var entries = repo.FindManyByArticle(article.Id!.Value);
            var location = entries
                .FirstOrDefault(e => e.Project == projectId && e.Denomination == denomination)?.WarehouseLocation;

            if (location.HasValue)
                return location.Value;

            location = entries
                .FirstOrDefault(e => e.Project == projectId)?.WarehouseLocation;

            if (location.HasValue)
                return location.Value;

            location = entries
                .FirstOrDefault(e => e.Denomination == denomination)?.WarehouseLocation;

            if (location.HasValue)
                return location.Value;

            location = entries
                .FirstOrDefault()?.WarehouseLocation;

            if (location.HasValue)
                return location.Value;

            location = repo.FindManyBookingsByArticle(article.Id!.Value)
                .Where(b => b.Kind == InventoryBookingKind.Take)
                .OrderByDescending(b => b.Timestamp)
                .FirstOrDefault()?.WarehouseLocationSourceId;

            return location;
        }
    }
}
