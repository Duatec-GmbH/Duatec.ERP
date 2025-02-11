using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api.ChangeTracking
{
    [HookAttachment(key: Article.Entity)]
    internal class ArticleChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: ArticleType.Entity)]
    internal class ArticleTypeChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: Company.Entity)]
    internal class CompanyChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: GoodsReceiving.Entity)]
    internal class GoodsReceivingChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: GoodsReceivingEntry.Entity)]
    internal class GoodsReceivingEntryChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: InventoryEntry.Entity)]
    internal class InventoryEntryChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: Order.Entity)]
    internal class OrderChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: OrderEntry.Entity)]
    internal class OrderEntryChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: PartList.Entity)]
    internal class PartListChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: PartListEntry.Entity)]
    internal class PartListEntryChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: Project.Entity)]
    internal class ProjectChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: Warehouse.Entity)]
    internal class WarehouseChangeTracker : ChangeTrackingHook { }

    [HookAttachment(key: WarehouseLocation.Entity)]
    internal class WarehouseLocationChangeTracker : ChangeTrackingHook { }
}
