using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

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
        public const string Count = "count";

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

    }
}
