using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    public class AllOrderTypesWithNone : CodeDataSource
    {
        public AllOrderTypesWithNone()
        {
            Id = new Guid("269dd0f2-f185-41b7-aa5a-10e30e9e2867");
            Name = nameof(AllOrderTypesWithNone);
            Description = "All order types including 'Not defined'";
            ResultModel = nameof(EntityRecordList);
        }


        public override object Execute(Dictionary<string, object> arguments)
        {
            var result = new EntityRecordList();
            result.AddRange(Execute());
            result.TotalCount = result.Count;

            return result;
        }

        public static IEnumerable<OrderType> Execute()
        {
            return RepositoryHelper.FindMany(new(), OrderType.Entity)
                .OrderBy(r => r[OrderType.Fields.Name] as string)
                .Select(TypedEntityRecordWrapper.Wrap<OrderType>)
                .Prepend(new OrderType() { Id = Guid.Empty, Name = "Not defined" });
        }
    }
}
