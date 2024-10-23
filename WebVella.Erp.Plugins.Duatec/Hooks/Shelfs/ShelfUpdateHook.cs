using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Shelfs
{
    [HookAttachment(key: HookKeys.Shelf.Update)]
    internal class ShelfUpdateHook : UpdateOnListHookBase
    {
        private static readonly ShelfValidator _validator = new();

        protected override IRecordValidator Validator => _validator;

        protected override string Entity => Shelf.Entity;

        protected override string LabelProperty => Shelf.Designation;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var designation = pageModel.GetFormValue(Shelf.Designation) ?? string.Empty;
            var warehouseId = GetId(pageModel, Shelf.Warehouse);

            var rec = new EntityRecord();
            rec[Shelf.Designation] = designation;
            rec[Shelf.Warehouse] = warehouseId;

            return rec;
        }

        private static Guid? GetId(BaseErpPageModel pageModel, string formField)
        {
            return Guid.TryParse(pageModel.GetFormValue(formField), out var id)
                ? id : null;
        }
    }
}
