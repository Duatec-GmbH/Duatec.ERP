
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Warehouse
    {
        public const string Entity = "warehouse";
        public const string Designation = "designation";

        public static EntityRecord? Find(Guid id)
        {
            var cmd = new EqlCommand($"select * from {Entity} where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault();
        }
    }
}
