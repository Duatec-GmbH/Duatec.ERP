using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses.Locations
{
    [HookAttachment(key: HookKeys.Warehouse.Location.Update)]
    internal class WarehouseLocationUpdateHook : UpdateOnListHookBase
    {
        private static readonly WarehouseLocationValidator _validator = new();

        protected override string IdProperty => "wlId";

        protected override IRecordValidator Validator => _validator;

        protected override string Entity => WarehouseLocation.Entity;

        protected override string LabelProperty => WarehouseLocation.Designation;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var designation = pageModel.GetFormValue(WarehouseLocation.Designation) ?? string.Empty;
            var warehouseId = GetId(pageModel, WarehouseLocation.Warehouse);

            var rec = new EntityRecord();
            rec[WarehouseLocation.Designation] = designation;
            rec[WarehouseLocation.Warehouse] = warehouseId;

            return rec;
        }

        private static Guid? GetId(BaseErpPageModel pageModel, string formField)
        {
            return Guid.TryParse(pageModel.GetFormValue(formField), out var id)
                ? id : null;
        }
    }
}
