using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Services
{
    internal static class RepositoryService
    {
        public static ArticleRepository ArticleRepository => new();

        public static CompanyRepository CompanyRepository => new();

        public static InventoryRepository InventoryRepository => new();

        public static OrderRepository OrderRepository => new();

        public static PartListRepository PartListRepository => new();

        public static ProjectRepository ProjectRepository => new();

        public static WarehouseRepository WarehouseRepository => new();

        public static GoodsReceivingRepository GoodsReceivingRepository => new();
    }
}
