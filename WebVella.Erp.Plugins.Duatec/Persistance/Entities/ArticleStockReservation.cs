using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal class ArticleStockReservation
    {
        public static class Relations
        {
            public const string Project = "article_stock_reservation_project";
        }

        public const string Entity = "article_stock_reservation";
        public const string Project = "project_id";

        public static List<EntityRecord> FindMany(Guid projectId, string select = "*")
            => Record.FindManyBy(Entity, Project, projectId, select);

        internal static EntityRecord? FindByProject(Guid projectId)
            => Record.FindBy(Entity, Project, projectId);
    }
}
