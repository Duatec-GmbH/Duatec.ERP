using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal class ArticleStockReservationEntry
    {
        public static class Relations
        {
            public const string ArticleStockReservation = "article_stock_reservation_entry_article_stock_reservation";
            public const string Article = "article_stock_reservation_entry_article";
        }

        public const string Entity = "article_stock_reservation_entry";
        public const string ArticleStockReservation = "article_stock_reservation_id";
        public const string Article = "article_id";
        public const string Amount = "amount";

        public static bool Exists(Guid articleStockReservationId)
            => Record.Exists(Entity, ArticleStockReservation, articleStockReservationId);

        public static List<EntityRecord> FindManyByProject(Guid projectId, string select = "*")
        {
            var listIds = Entities.ArticleStockReservation.FindMany(projectId)
                .ToIdArray();

            return Record.FindManyByUniqueArgs(Entity, ArticleStockReservation, select, listIds).Values
                .Where(v => v != null)
                .ToList()!;
        }
    }
}
