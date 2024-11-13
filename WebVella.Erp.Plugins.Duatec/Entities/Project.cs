using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Project
    {
        public const string Entity = "project";
        public const string Number = "number";
        public const string Name = "name";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);

        public static bool Exists(Guid id)
            => Record.Exists(Entity, "id", id);
    }
}
