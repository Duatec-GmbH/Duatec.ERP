using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class FinderConfigRepository : TypedRepositoryBase<FinderConfig>
    {
        public FinderConfigRepository(RecordManager? record) : base(record)
        { }

        public FinderConfig? Find(string shortName, string select = "*")
            => TypedEntityRecordWrapper.WrapElseDefault<FinderConfig>(RepositoryHelper.FindBy(RecordManager, Entity, FinderConfig.Fields.ShortName, shortName, select));
    }
}
