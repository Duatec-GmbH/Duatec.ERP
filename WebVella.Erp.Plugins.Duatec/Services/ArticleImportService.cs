using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services.ArticleFinders;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class ArticleImportService
    {
        public static async Task<ArticlePreview?> GetPreviewAsync(string partNumber)
        {
            var recMan = new RecordManager(DbContext.Current, ignoreSecurity: true, executeHooks: false);
            var repo = new ArticleRepository(recMan);

            var types = repo.FindManyTypes()
                .Select(t => new ArticleFinders.ArticleType()
                {
                    Id = t.Id!.Value,
                    Name = t.Label,
                })
                .ToList();

            Task<ArticlePreview?> edpTask;
            Task<ArticlePreview?> finderTask;

            try
            {
                edpTask = EplanDataPortal.GetArticleByPartNumberAsync(partNumber)
                    .ContinueWith(t => t.Result == null ? null : new ArticlePreview()
                    {
                        PartNumber = t.Result.PartNumber,
                        OrderNumber = t.Result.OrderNumber,
                        TypeNumber = t.Result.TypeNumber,
                        Designation = t.Result.Designation,
                        ImageUrl = t.Result.PictureUrl,
                        Type = types.FirstOrDefault(t => t.Name.Equals("component", StringComparison.OrdinalIgnoreCase)),
                    });
            }
            catch
            {
                edpTask = Task.FromResult<ArticlePreview?>(null);
            }

            try
            {
                finderTask = ArticleFinderService.GetArticleAsync(partNumber, types)
                    .ContinueWith(t => t.Result == null || !t.Result.IsValid ? null : t.Result.Value);
            }
            catch
            {
                finderTask = Task.FromResult<ArticlePreview?>(null);
            }

            var edpPreview = await edpTask;

            if (edpPreview != null)
                return edpPreview;
            
            return await finderTask;
        }


        public static async Task<List<ArticleSuggestion>> SuggestAsync(string search, int resultCount = 0, bool excludeArticlesFromDataBase = true)
        {
            Task<List<ArticleSuggestion>> manufacturerTask;

            try
            {
                manufacturerTask = ArticleFinderService.SuggestAsync(search, resultCount);
            }
            catch
            {
                manufacturerTask = Task.FromResult<List<ArticleSuggestion>>([]);
            }

            Task<List<ArticleSuggestion>> dataPortalTask;

            try
            {
                dataPortalTask = EplanDataPortal.SuggestArticlesAsync(search, 200)
                    .ContinueWith(t => t.Result?.Select(n => new ArticleSuggestion() { PartNumber = n.PartNumber, ImageUrl = n.PictureUrl }).ToList() ?? []);
            }
            catch
            {
                dataPortalTask = Task.FromResult<List<ArticleSuggestion>>([]);
            }

            Task<HashSet<string>>? dbTask = null;

            if (excludeArticlesFromDataBase)
            {
                var recMan = new RecordManager(DbContext.Current, ignoreSecurity: true, executeHooks: false);

                dbTask = Task.Run(() =>
                {
                    try
                    {
                        return new ArticleRepository(recMan).FindAll("part_number")
                            .Select(a => a.PartNumber)
                            .ToHashSet();

                    }
                    catch
                    {
                        return [];
                    }
                });
            }

            var dataPortalSuggestions = await dataPortalTask;
            var manufacturerSuggestions = await manufacturerTask;
            var dbArticles = dbTask != null ? await dbTask : [];

            var dpSuggLookup = dataPortalSuggestions.ToDictionary(sugg => sugg.PartNumber);

            foreach (var suggestion in manufacturerSuggestions)
            {
                if (dpSuggLookup.TryGetValue(suggestion.PartNumber, out var dpSugg) && !string.IsNullOrWhiteSpace(dpSugg.ImageUrl))
                    suggestion.ImageUrl = dpSugg.ImageUrl;
            }

            manufacturerSuggestions.AddRange(dataPortalSuggestions.Where(dpSugg => !manufacturerSuggestions.Exists(mSugg => mSugg.PartNumber == dpSugg.PartNumber)));

            if (excludeArticlesFromDataBase && dbArticles.Count > 0 && manufacturerSuggestions.Count > 0)
            {
                for (var i = manufacturerSuggestions.Count; i >= 0; i--)
                {
                    if (dbArticles.Contains(manufacturerSuggestions[i].PartNumber))
                        manufacturerSuggestions.RemoveAt(i);
                }
            }

            if (manufacturerSuggestions.Count > resultCount && resultCount >= 1)
                manufacturerSuggestions = [.. manufacturerSuggestions.Take(resultCount)];

            return manufacturerSuggestions;
        }
    }
}
