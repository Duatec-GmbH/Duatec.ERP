using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    internal class PartList
    {
        public static class Relations
        {
            public const string Entries = PartListEntry.Relations.PartsList;
            public const string Project = "part_list_project";
        }

        public const string Entity = "part_list";
        public const string Project = "project_id";
        public const string Name = "name";
        public const string IsActive = "is_active";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static bool Exists(Guid id)
            => Record.Exists(Entity, "id", id);

        public static bool Exists(Guid projectId, string name, Guid? excludedId = null)
        {
            var subQueries = new List<QueryObject>()
            {
                new() { QueryType = QueryType.EQ, FieldName = Project, FieldValue = projectId },
                new() { QueryType = QueryType.EQ, FieldName = Name, FieldValue = name },
            };
            if (excludedId.HasValue)
            {
                subQueries.Add(new() { QueryType = QueryType.NOT, SubQueries = 
                    [ new() { QueryType = QueryType.EQ, FieldName = "id", FieldValue = excludedId.Value }] });
            }

            var recMan = new RecordManager();
            var response = recMan.Count(new(Entity, "*", new() { QueryType = QueryType.AND, SubQueries = subQueries }));

            return response.Object > 0;
        }

        public static List<EntityRecord> FindMany(Guid projectId)
            => Record.FindManyBy(Entity, Project, projectId);
    }
}
