using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords.Hooks.Page;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Inventory
{
    [HookAttachment(key: HookKeys.Inventory.Create)]
    internal class InventoryEntryCreateHook : TypedValidatedCreateHook<InventoryEntry>
    {
        protected override IActionResult? OnValidationSuccess(InventoryEntry record, RecordCreatePageModel pageModel)
        {
            var userId = pageModel.TryGetDataSourceProperty<ErpUser>("CurrentUser")!.Id;

            var id = Guid.NewGuid();
            record.Id = id;

            void TransactionalAction()
            {
                var repo = new InventoryRepository();
                if (repo.Insert(record) == null)
                    throw new DbException("Could not create inventory entry record");
            }

            if (!Transactional.TryExecute(TransactionalAction))
            {
                pageModel.PutMessage(ScreenMessageType.Error, "Could not create inventory entry");
                return pageModel.LocalRedirect(Url.RemoveParameter(pageModel.CurrentUrl, "hookKey"));
            }

            pageModel.PutMessage(ScreenMessageType.Success, SuccessMessage(record.EntityName));
            if (!string.IsNullOrEmpty(pageModel.ReturnUrl))
                return pageModel.LocalRedirect(pageModel.ReturnUrl);

            return pageModel.LocalRedirect(pageModel.EntityListUrl());
        }
    }
}
