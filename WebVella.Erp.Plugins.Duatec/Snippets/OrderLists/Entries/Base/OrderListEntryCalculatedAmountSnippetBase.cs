using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base
{
    internal abstract class OrderListEntryCalculatedAmountSnippetBase : OrderListEntryAmountSnippetBase
    {
        protected abstract IEnumerable<decimal> GetAmounts(Guid project, Guid article);

        protected override decimal? GetAmount(BaseErpPageModel pageModel)
        {
            var target = TargetRecord(pageModel);
            var project = pageModel.TryGetDataSourceProperty<Guid?>(
                $"{target}.${OrderListEntry.Relations.OrderList}[0].{OrderList.Project}");
            if (!project.HasValue)
                return null;

            var article = pageModel.TryGetDataSourceProperty<Guid>($"{target}.{OrderListEntry.Article}");

            return GetAmounts(project.Value, article)
                .Aggregate(0m, (sum, d) => sum += Math.Max(0, d));
        }
    }
}
