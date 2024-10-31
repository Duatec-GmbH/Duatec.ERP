
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Warehouse
    {
        public const string Entity = "warehouse";
        public const string Designation = "designation";

        public static EntityRecord? Find(Guid id)
            => Record.Find(Entity, id);
    }
}
