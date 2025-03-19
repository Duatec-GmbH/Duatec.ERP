using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.TypedRecords.Persistance;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Repositories
{
    internal class ImageRepository : TypedRepositoryBase<Image>
    {
        public ImageRepository(RecordManager? recordManager = null)
            : base(recordManager) { }

        public List<Image> FindManyByPath(string path, string select = "*")
            => FindManyBy(Image.Fields.Path, path, select);
    }
}
