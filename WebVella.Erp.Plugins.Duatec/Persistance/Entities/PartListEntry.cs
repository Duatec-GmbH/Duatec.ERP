using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    internal static class PartListEntry
    {
        public static class Relations
        {
            public const string PartsList = "part_list_entry_part_list";
            public const string Article = "part_list_entry_article";
        }

        public const string Entity = "part_list_entry";
        public const string PartList = "part_list_id";
        public const string Article = "article_id";
        public const string DeviceTag = "device_tag";
        public const string Amount = "amount";

        public static List<EntityRecord> FindMany(Guid partList, string select = "*")
            => Record.FindManyBy(Entity, PartList, partList, select);

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static bool Exists(Guid partList, Guid article, Guid? excluded = null)
        {
            var subQueries = new List<QueryObject>()
            {
                new() { FieldName = PartList, FieldValue = partList, QueryType = QueryType.EQ },
                new() { FieldName = Article, FieldValue = article, QueryType = QueryType.EQ }
            };
            if (excluded.HasValue)
            {
                subQueries.Add(new()
                {
                    QueryType = QueryType.NOT,
                    SubQueries = [new() { FieldName = "id", FieldValue = excluded.Value, QueryType = QueryType.EQ }]
                });
            }

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "id",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object > 0;
        }

        public static bool Exists(Guid partList)
        {
            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "id",
                new QueryObject() { QueryType = QueryType.EQ, FieldName = PartList, FieldValue = partList }));

            return response.Object > 0;
        }

        public static List<EntityRecord> FindManyByProject(Guid projectId, bool? isActive = null, string select = "*")
        {
            var subQuery = GetPartListsQuery(projectId, isActive);

            if (subQuery.Count == 0)
                return [];

            var recMan = new RecordManager();
            var result = recMan.Find(new EntityQuery(Entity, select,
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            return result?.Object?.Data ?? [];
        }

        public static List<EntityRecord> FindManyByProjectAndArticle(Guid projectId, Guid articleId, bool? isActive = null, string select = "*")
        {
            var listsSubQuery = GetPartListsQuery(projectId, isActive);
            if (listsSubQuery.Count == 0)
                return [];

            var listsQuery = new QueryObject() { QueryType = QueryType.OR, SubQueries = listsSubQuery };
            var articleQuery = new QueryObject() { QueryType = QueryType.EQ, FieldName = Article, FieldValue = articleId };


            var recMan = new RecordManager();
            var result = recMan.Find(new EntityQuery(Entity, select,
                new QueryObject() { QueryType = QueryType.AND, SubQueries = [articleQuery, listsQuery] }));

            return result?.Object?.Data ?? [];
        }

        private static List<QueryObject> GetPartListsQuery(Guid projectId, bool? isActive)
        {
            IEnumerable<EntityRecord> partLists = Entities.PartList.FindMany(projectId);
            if (isActive.HasValue)
                partLists = partLists.Where(r => isActive.Value == (bool)r[Entities.PartList.IsActive]);

            var partListIds = partLists.ToIdArray();
            if (partListIds.Length == 0)
                return [];

            return partListIds
                .Select(id => new QueryObject() { FieldName = PartList, FieldValue = id, QueryType = QueryType.EQ })
                .ToList();
        }
    }
}
