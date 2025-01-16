using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Update)]
    internal class WarehouseUpdateHook : UpdateOnListHookBase<Warehouse>
    {
        private static readonly WareHouseValidator _validator = new();

        protected override IRecordValidator<Warehouse> Validator => _validator;

        protected override string Entity => Warehouse.Entity;

        protected override string LabelProperty => Warehouse.Fields.Designation;

        protected override Warehouse CreateRecord(BaseErpPageModel pageModel)
        {
            return new Warehouse()
            {
                Designation = pageModel.GetFormValue(Warehouse.Fields.Designation) ?? string.Empty
            };
        }
    }
}
