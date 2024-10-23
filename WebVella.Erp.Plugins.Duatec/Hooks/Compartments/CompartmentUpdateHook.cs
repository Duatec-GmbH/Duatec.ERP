﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Compartments
{
    [HookAttachment(key: HookKeys.Compartment.Update)]
    internal class CompartmentUpdateHook : UpdateOnListHookBase
    {
        private static readonly CompartmentValidator _validator = new();

        protected override IRecordValidator Validator => _validator;

        protected override string Entity => Compartment.Entity;

        protected override string LabelProperty => Compartment.Designation;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var designation = pageModel.GetFormValue(Compartment.Designation) ?? string.Empty;
            var shelfId = GetId(pageModel, Compartment.Shelf);

            var rec = new EntityRecord();
            rec[Compartment.Designation] = designation;
            rec[Compartment.Shelf] = shelfId;

            return rec;
        }

        private static Guid? GetId(BaseErpPageModel pageModel, string formField)
        {
            return Guid.TryParse(pageModel.GetFormValue(formField), out var id)
                ? id : null;
        }
    }
}
