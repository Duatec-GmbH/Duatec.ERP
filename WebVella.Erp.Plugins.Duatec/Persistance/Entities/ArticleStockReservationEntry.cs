using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
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

        public static Dictionary<string, EntityRecord?> FindManyByProjectAndArticle(Guid projectId, params string[] partNumbers)
        {
            var partNumberLookup = partNumbers.ToHashSet();
            var entries = FindManyByProject(projectId, $"${Relations.Article}.{Entities.Article.Fields.PartNumber}")
                .Where(r => GetPartNumber(r) is string pn && partNumberLookup.Contains(pn));

            var result = partNumbers.ToDictionary(pn => pn, _ => default(EntityRecord));
            foreach (var entry in entries)
            {
                var pn = GetPartNumber(entry)!;
                if (result[pn] != null)
                    throw new DbException($"Inconsistent data at entity '{Entity}' part number '{pn}'");

                entry.Properties.Remove($"${Relations.Article}");
                result[pn] = entry;
            }
            return result;
        }

        private static string? GetPartNumber(EntityRecord rec)
            => (rec[$"${Relations.Article}"] as List<EntityRecord>)?.FirstOrDefault()?[Entities.Article.Fields.PartNumber] as string;
    }
}
