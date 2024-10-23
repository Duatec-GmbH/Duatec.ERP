using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Plugins.Duatec.Entities
{
    public static class Compartment
    {
        public const string Entity = "compartment";
        public const string Shelf = "shelf_id";
        public const string Designation = "designation";

        public static EntityRecord? Find(Guid id)
        {
            var cmd = new EqlCommand($"select *, $shelf.designation, $shelf.$warehouse.designation " +
                $"from {Entity} " +
                $"where id = @param",
                new EqlParameter("param", id));

            return cmd.Execute()?.SingleOrDefault();
        }

        public static bool Exists(Guid shelf, string designation, Guid? excludedId = null)
        {
            var cmd = new EqlCommand($"select * from {Entity} where " +
                $"{Shelf} = @shelf and {Designation} = @designation and id != @id",
                new EqlParameter("shelf", shelf),
                new EqlParameter("designation", designation),
                new EqlParameter("id", excludedId ?? Guid.Empty));

            return QueryResults.Exists(cmd.Execute());
        }
    }
}
