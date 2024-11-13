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

        public static List<EntityRecord> FindMany(Guid partList, string select = "*")
            => Record.FindManyBy(Entity, PartList, partList, select);
    }
}
