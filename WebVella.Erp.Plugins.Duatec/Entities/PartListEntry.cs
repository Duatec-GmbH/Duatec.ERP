using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Util;

namespace WebVella.Erp.Plugins.Duatec.Entities
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
        public const string ProvidedAmount = "provided_amount";

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
                subQueries.Add(new() { QueryType = QueryType.NOT, 
                    SubQueries = [new() { FieldName = "id", FieldValue = excluded.Value, QueryType = QueryType.EQ }] });
            }

            var recMan = new RecordManager();
            var response = recMan.Count(new EntityQuery(Entity, "id",
                new QueryObject() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object > 0;
        }

        public static bool ExistsByProject(Guid project, Guid article, Guid? excluded = null)
        {
            var partListQuery = Entities.PartList.FindMany(project)
                .Select(r => new QueryObject() { FieldName = PartList, FieldValue = (Guid)r["id"], QueryType = QueryType.EQ })
                .ToList();

            if (partListQuery.Count == 0)
                return false;

            var subQueries = new List<QueryObject>()
            {
                new() { QueryType = QueryType.OR, SubQueries = partListQuery },
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

        public static List<EntityRecord> FindManyByProject(Guid projectId, string select = "*")
        {
            var subQuery = GetPartListsQuery(projectId);

            if (subQuery.Count == 0)
                return [];

            var recMan = new RecordManager();
            var result = recMan.Find(new EntityQuery(Entity, select,
                new QueryObject() { QueryType = QueryType.OR, SubQueries = subQuery }));

            return result?.Object?.Data ?? [];
        }

        public static List<EntityRecord> FindManyByProjectAndArticle(Guid projectId, Guid articleId, string select = "*")
        {
            var listsSubQuery = GetPartListsQuery(projectId);
            if (listsSubQuery.Count == 0)
                return [];

            var listsQuery = new QueryObject() { QueryType = QueryType.OR, SubQueries = listsSubQuery };
            var articleQuery = new QueryObject() { QueryType = QueryType.EQ, FieldName = Article, FieldValue = articleId };


            var recMan = new RecordManager();
            var result = recMan.Find(new EntityQuery(Entity, select,
                new QueryObject() { QueryType = QueryType.AND, SubQueries = [ articleQuery, listsQuery ] }));

            return result?.Object?.Data ?? [];
        }

        private static List<QueryObject> GetPartListsQuery(Guid projectId)
        {
            var partListIds = Entities.PartList.FindMany(projectId)
                .ToIdArray();

            if (partListIds.Length == 0)
                return [];

            return partListIds
                .Select(id => new QueryObject() { FieldName = PartList, FieldValue = id, QueryType = QueryType.EQ })
                .ToList();
        }
    }
}
