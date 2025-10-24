using Microsoft.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders;

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

        public static async Task<List<ArticleSuggestion>> Articles2Import(string search, int resultCount = 0, bool excludeArticlesFromDataBase = true)
        {
            var manufacturerTask = ArticleFinderService.SuggestAsync(search, resultCount);
            var dataPortalTask = EplanDataPortal.SuggestArticlesAsync(search, resultCount)
                .ContinueWith(t => t.Result?.Select(n => new ArticleSuggestion() { PartNumber = n.PartNumber, ImageUrl = n.PictureUrl}).ToList() ?? []);

            Task<HashSet<string>>? dbTask = null;

            if (excludeArticlesFromDataBase)
            {
                var recMan = new RecordManager(DbContext.Current, ignoreSecurity: true, executeHooks: false);

                dbTask = Task.Run(() =>
                {
                    return new ArticleRepository(recMan).FindAll("part_number")
                        .Select(a => a.PartNumber)
                        .ToHashSet();
                });
            }

            var dataPortalSuggestions = await dataPortalTask;
            var manufacturerSuggestions = await manufacturerTask;
            var dbArticles = dbTask != null ? await dbTask : [];

            var dpSuggLookup = dataPortalSuggestions.ToDictionary(sugg => sugg.PartNumber);

            foreach(var suggestion in manufacturerSuggestions)
            {
                if (dpSuggLookup.TryGetValue(suggestion.PartNumber, out var dpSugg) && !string.IsNullOrWhiteSpace(dpSugg.ImageUrl))
                    suggestion.ImageUrl = dpSugg.ImageUrl;
            }

            manufacturerSuggestions.AddRange(dataPortalSuggestions.Where(dpSugg => !manufacturerSuggestions.Exists(mSugg => mSugg.PartNumber == dpSugg.PartNumber)));

            if (excludeArticlesFromDataBase && dbArticles.Count > 0 && manufacturerSuggestions.Count > 0)
            {
                for(var i = manufacturerSuggestions.Count; i >= 0; i--)
                {
                    if (dbArticles.Contains(manufacturerSuggestions[i].PartNumber))
                        manufacturerSuggestions.RemoveAt(i);
                }
            }

            if (manufacturerSuggestions.Count > resultCount && resultCount >= 1)
                manufacturerSuggestions = [..manufacturerSuggestions.Take(resultCount)];

            return manufacturerSuggestions;
        }
    }
}
