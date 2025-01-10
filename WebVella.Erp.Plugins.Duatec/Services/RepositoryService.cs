using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal class RepositoryService
    {
        public static ArticleRepository Article => new();

        public static CompanyRepository Company => new();

        public static InventoryRepository Inventory => new();

        public static OrderRepository Order => new();

        public static PartListRepository PartList => new();

        public static ProjectRepository Project => new();

        public static WarehouseRepository Warehouse => new();

        public static GoodsReceivingRepository GoodsReceiving => new();
    }
}
