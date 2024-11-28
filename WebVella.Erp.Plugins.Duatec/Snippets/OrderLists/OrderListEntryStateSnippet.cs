using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists
{
    [Snippet]
    internal class OrderListEntryStateSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = GetRecord(pageModel);
            if (rec == null) 
                return null;

            var demand = (decimal)rec[OrderListEntry.Amount];
            if (demand <= 0)
                return null;

            var listId = (Guid)rec[OrderListEntry.OrderList];
            var project = (Guid)Project.Find((Guid)OrderList.Find(listId)![OrderList.Project])!["id"];
            var article = (Guid)rec[OrderListEntry.Article];
            var type = ArticleType.FromArticle(article);
            var isInt = (bool)type![ArticleType.IsInteger];
            var unit = type![ArticleType.Unit] as string;

            var orderedAmount = OrderEntry.FindManyByProject(project)
                .Aggregate(0m, (sum, r) => sum += Math.Max(0, (decimal)r[OrderEntry.Amount]));

            if (orderedAmount == 0)
                return "not ordered";

            // TODO replace with googs income
            var receivedAmount = 0m;

            return $"ordered: {FormatAmount(orderedAmount, isInt, unit)}<br/>" +
                $"received: {FormatAmount(receivedAmount, isInt, unit)}";
        }

        private static string FormatAmount(decimal amount, bool isInt, string? unit)
        {
            return isInt ? $"{amount:0} {unit}"
                : $"{amount:0.00} {unit}";
        }

        private static EntityRecord? GetRecord(BaseErpPageModel pageModel)
        {
            if (string.IsNullOrEmpty(pageModel.CurrentUrl))
                return null;
            Try.Get(() => pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord"), out var rec);
            if (rec == null)
                Try.Get(() => pageModel.TryGetDataSourceProperty<EntityRecord>("Record"), out rec);
            return rec;
        }
    }
}
