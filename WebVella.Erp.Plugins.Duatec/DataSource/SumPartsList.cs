using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class SumPartsList : CodeDataSource
    {
        public SumPartsList() : base()
        {
            Id = new Guid("02011d86-63ab-4323-9142-0f6a219f546d");
            Name = nameof(SumPartsList);
            Description = "Sum parts list";
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new DataSourceParameter() { Name = "id", Type = "guid", Value = "null" });
            Parameters.Add(new DataSourceParameter { Name = "page", Type = "int", Value = "1" });
            Parameters.Add(new DataSourceParameter { Name = "pageSize", Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            var result = new EntityRecordList();
            if(!arguments.TryGetValue("id", out var objId) || objId is not Guid id)
                return result;

            var page = (int)arguments["page"];
            var pageSize = (int)arguments["pageSize"];

            var all = PartListEntry.FindMany(id, $"*, ${PartListEntry.Relations.Article}.*")
                .GroupBy(r => (Guid)r[PartListEntry.Article])
                .Select(CreateRecord)
                .ToArray();

            var displayed = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            foreach (var entry in displayed)
                result.Add(entry);

            result.TotalCount = all.Length;

            return result;
        }

        private static EntityRecord CreateRecord(IGrouping<Guid, EntityRecord> group)
        {
            var rec = new EntityRecord();
            rec[PartListEntry.Article] = group.Key;
            rec[PartListEntry.DeviceTag] = ListAggDeviceTags(group);
            rec[$"${PartListEntry.Relations.Article}"] = group.First()[$"${PartListEntry.Relations.Article}"];
            rec["count"] = group.Count();
            return rec;
        }

        private static string ListAggDeviceTags(IEnumerable<EntityRecord> grouping)
        {
            var deviceTags = grouping
                .Select(r => ((string)r[PartListEntry.DeviceTag]).Trim())
                .Distinct()
                .Order();

            return string.Join(Environment.NewLine, deviceTags);
        }
    }
}
