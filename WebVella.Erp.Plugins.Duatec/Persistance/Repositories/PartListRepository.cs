using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories.Base;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class PartListRepository : ListRepositoryBase<PartList, PartListEntry>
    {
        public override string Entity => PartList.Entity;

        protected override string EntryEntity => PartListEntry.Entity;

        protected override string EntryParentIdPath => PartListEntry.Fields.PartList;

        protected override PartList? MapToTypedRecord(EntityRecord? record)
            => PartList.Create(record);

        protected override PartListEntry? MapEntryToTypedRecord(EntityRecord? record)
            => PartListEntry.Create(record);

        public List<PartList> FindManyByProject(Guid projectId)
            => FindManyBy(PartList.Fields.Project, projectId);

        public bool ExistsWithinProject(Guid projectId, string name, Guid? excludedId = null)
        {
            var subQueries = new List<QueryObject>()
            {
                new()
                {
                    QueryType = QueryType.EQ,
                    FieldName = PartList.Fields.Project,
                    FieldValue = projectId
                },
                new()
                {
                    QueryType = QueryType.EQ,
                    FieldName = PartList.Fields.Name,
                    FieldValue = name
                }
            };

            if (excludedId.HasValue)
                subQueries.Add(ExcludeIdQuery(excludedId.Value));

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries = subQueries
            };

            return ExistsByQuery(query);
        }

        public List<PartListEntry> FindManyEntriesByPartList(Guid partList, string select = "*")
            => FindManyEntriesBy(PartListEntry.Fields.PartList, partList, select);

        public bool EntryExistsWithinList(Guid partListId, Guid articleId, Guid? excludedId = null)
        {
            var subQueries = new List<QueryObject>()
            {
                new() 
                { 
                    FieldName = PartListEntry.Fields.PartList, 
                    FieldValue = partListId, 
                    QueryType = QueryType.EQ 
                },
                new() 
                { 
                    FieldName = PartListEntry.Fields.Article, 
                    FieldValue = articleId,
                    QueryType = QueryType.EQ 
                }
            };
            if (excludedId.HasValue)
                subQueries.Add(ExcludeIdQuery(excludedId.Value));

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries = subQueries
            };

            return EntryExistsByQuery(query);
        }

        public bool EntryExistsWithinList(Guid partListId)
        {
            var query = new QueryObject()
            {
                QueryType = QueryType.EQ,
                FieldName = PartListEntry.Fields.PartList,
                FieldValue = partListId
            };
            return EntryExistsByQuery(query);
        }

        public List<PartListEntry> FindManyEntriesByProject(Guid projectId, bool? isActive, string select = "*")
        {
            var subQueries = PartListsByProjectQuery(projectId, isActive);
            if (subQueries.Count == 0)
                return [];

            var query = new QueryObject()
            {
                QueryType = QueryType.OR,
                SubQueries = subQueries
            };

            return FindManyEntriesByQuery(query, select);
        }


        public List<PartListEntry> FindManyEntriesByProjectAndArticle(
            Guid projectId, Guid articleId, bool? isActive, string select = "*")
        {
            var subQueries = PartListsByProjectQuery(projectId, isActive);
            if (subQueries.Count == 0)
                return [];

            var query = new QueryObject()
            {
                QueryType = QueryType.AND,
                SubQueries =
                [
                    new()
                    {
                        QueryType = QueryType.EQ,
                        FieldName = PartListEntry.Fields.Article,
                        FieldValue = articleId
                    },
                    new()
                    {
                        QueryType = QueryType.OR,
                        SubQueries = subQueries
                    }
                ]
            };
            return FindManyEntriesByQuery(query, select);
        }

        private List<QueryObject> PartListsByProjectQuery(Guid projectId, bool? isActive)
        {
            IEnumerable<PartList> partLists = FindManyByProject(projectId);
            if (isActive.HasValue)
                partLists = partLists.Where(r => isActive.Value == r.IsActive);

            var partListIds = partLists.ToIdArray();
            if (partListIds.Length == 0)
                return [];

            return partListIds
                .Select(id => new QueryObject() 
                { 
                    FieldName = PartListEntry.Fields.PartList,
                    FieldValue = id,
                    QueryType = QueryType.EQ 
                })
                .ToList();
        }
    }
}
