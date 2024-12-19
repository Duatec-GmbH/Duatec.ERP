using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Persistance
{
    internal class Repository
    {
        public static ArticleRepository Article { get; } = new();

        public static CompanyRepository Company { get; } = new();

        public static InventoryRepository Inventory { get; } = new();

        public static OrderRepository Order { get; } = new();

        public static PartListRepository PartList { get; } = new();

        public static ProjectRepository Project { get; } = new();

        public static WarehouseRepository Warehouse { get; } = new();
    }
}
