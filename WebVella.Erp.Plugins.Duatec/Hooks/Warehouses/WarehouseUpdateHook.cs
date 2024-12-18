﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Warehouses
{
    [HookAttachment(key: HookKeys.Warehouse.Update)]
    internal class WarehouseUpdateHook : UpdateOnListHookBase<EntityRecord>
    {
        private static readonly WareHouseValidator _validator = new();

        protected override IRecordValidator<EntityRecord> Validator => _validator;

        protected override string Entity => Warehouse.Entity;

        protected override string LabelProperty => Warehouse.Designation;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var designation = pageModel.GetFormValue(Warehouse.Designation) ?? string.Empty;

            var rec = new EntityRecord();
            rec[Warehouse.Designation] = designation;

            return rec;
        }
    }
}
