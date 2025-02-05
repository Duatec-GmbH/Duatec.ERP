using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Projects
{
    [Snippet]
    internal class ProjectHasInventoryEntriesToReleaseSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var recMan = new RecordManager();
            var inventoryRepo = new InventoryRepository(recMan);
            var partListRepo = new PartListRepository(recMan);

            var reserved = inventoryRepo.FindManyByProject(pageModel.RecordId!.Value)
                .GroupBy(ie => ie.Article)
                .ToDictionary(g => g.Key, g => g.Sum(ie => ie.Amount));

            var demands = partListRepo.FindManyEntriesByProject(pageModel.RecordId.Value, true)
                .GroupBy(ple => ple.ArticleId)
                .ToDictionary(g => g.Key, g => g.Sum(ple => ple.Amount));

            return reserved.Count > demands.Count 
                || reserved.Any(kp => !demands.TryGetValue(kp.Key, out var demand) || demand < kp.Value);
        }
    }
}
