using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Update)]
    internal class WarehouseLocationUpdateHook : UpdateOnListHookBase<WarehouseLocation>
    {
        private static readonly WarehouseLocationValidator _validator = new();

        protected override IRecordValidator<WarehouseLocation> Validator => _validator;

        protected override string Entity => WarehouseLocation.Entity;

        protected override string LabelProperty => WarehouseLocation.Fields.Designation;

        protected override WarehouseLocation CreateRecord(BaseErpPageModel pageModel)
        {
            return new WarehouseLocation()
            {
                Designation = pageModel.GetFormValue(WarehouseLocation.Fields.Designation) ?? string.Empty,
                Warehouse = Guid.TryParse(pageModel.GetFormValue(WarehouseLocation.Fields.Warehouse), out var id)
                    ? id : Guid.Empty
            };
        }
    }
}
