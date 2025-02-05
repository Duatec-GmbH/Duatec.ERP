using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.GoodsReceivings
{
    [HookAttachment(key: HookKeys.GoodsReceiving.Delete)]
    internal class GoodsReceivingDeleteHook : TypedValidatedDeleteHook<GoodsReceiving>
    {
        protected override IActionResult? OnValidationSuccess(GoodsReceiving record, Entity entity, BaseErpPageModel pageModel)
        {
            void TransactionalAction()
            {
                if (new GoodsReceivingRepository().Delete(record.Id!.Value) == null)
                    throw new DbException("Could not delete goods receiving record");
            }

            if(!Transactional.TryExecute(pageModel, TransactionalAction))
            {
                pageModel.BeforeRender();
                return pageModel.Page();
            }

            base.OnPostModification(record, entity, pageModel);
            return pageModel.LocalRedirect(pageModel.EntityListUrl());
        }
    }
}
