using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    internal static class ArticleStockRecord
    {
        public static void RoundAmount(EntityRecord record)
        {
            var amount = (decimal)record[ArticleStock.Amount];
            amount = Math.Round(amount, 2);
            record[ArticleStock.Amount] = amount;
        }
    }
}
