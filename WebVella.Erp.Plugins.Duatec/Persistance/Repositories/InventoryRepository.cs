using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class InventoryRepository : RepositoryBase<InventoryEntry>
    {
        public override string Entity => InventoryEntry.Entity;

        protected override InventoryEntry? CreateResult(EntityRecord? record)
            => record == null ? null : new InventoryEntry(record);

        public List<InventoryEntry> FindManyByArticle(Guid articleId)
            => FindManyBy(InventoryEntry.Fields.Article, articleId);

        public List<InventoryEntry> FindManyByProject(Guid? projectId)
            => FindManyBy(InventoryEntry.Fields.Project, projectId);

        public List<InventoryEntry> FindManyByArticleAndProject(Guid articleId, Guid? projectId, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries = 
                [
                    new() 
                    { 
                        FieldName = InventoryEntry.Fields.Article, 
                        FieldValue = articleId, 
                        QueryType = QueryType.EQ 
                    },
                    new() 
                    { 
                        FieldName = InventoryEntry.Fields.Project, 
                        FieldValue = projectId, 
                        QueryType = QueryType.EQ 
                    },
                ]
            };
            return FindManyByQuery(query, select);
        }

        public InventoryEntry? Find(Guid articleId, Guid locationId, Guid? projectId, string select = "*")
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    {
                        FieldName = InventoryEntry.Fields.Article, 
                        FieldValue = articleId, 
                        QueryType = QueryType.EQ
                    },
                    new()
                    {
                        FieldName = InventoryEntry.Fields.WarehouseLocation, 
                        FieldValue = locationId, 
                        QueryType = QueryType.EQ
                    },
                    new() 
                    { 
                        FieldName = InventoryEntry.Fields.Project, 
                        FieldValue = projectId, 
                        QueryType = QueryType.EQ 
                    },
                ]
            };
            return FindByQuery(query, select);
        }
    }
}
