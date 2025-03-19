using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Companies
{
    [HookAttachment(key: HookKeys.Company.EplanImport)]
    internal class EplanManufacturerImportHook : IPageHook
    {
        private const string EplanIdArg = "hEplanId";

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue(EplanIdArg, out var id) || !long.TryParse(id, out var eplanId))
                PutInvalidArg(pageModel);
            else
            {
                var repo = new CompanyRepository();

                var manufacturer = EplanDataPortal.GetManufacturers()
                    .SingleOrDefault(m => m.EplanId == eplanId);

                if (manufacturer == null)
                    PutInvalidArg(pageModel);
                else if (!repo.CanBeImported(manufacturer))
                    pageModel.PutMessage(ScreenMessageType.Error, $"Can not import manufacturer '{manufacturer}' due to unique constraints.");
                else Import(repo, pageModel, manufacturer);
            }

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, EplanIdArg);

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            return null;
        }

        private static void Import(CompanyRepository repo, BaseErpPageModel pageModel, DataPortalManufacturerDto manufacturer)
        {
            void TransactionalAction()
            {
                if (repo.Insert(manufacturer) == null)
                    throw new DbException($"Could not import manufacturer '{manufacturer.Name}'");
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported manufacturer '{manufacturer.Name}'");
        }

        private static void PutInvalidArg(BaseErpPageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Error, $"Invalid argument '{EplanIdArg}'");
        }
    }
}
