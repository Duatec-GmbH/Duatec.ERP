using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
using WebVella.Erp.Plugins.Duatec.Persistance;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Manufacturers
{
    [HookAttachment(key: HookKeys.Manufacturer.EplanImport)]
    internal class ManufacturerEplanImportHook : IParameterizedPageHook
    {
        private const string EplanIdArg = "hEplanId";

        public string[] Parameters => [EplanIdArg];

        public IActionResult? OnGet(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            if (!args.TryGetValue(EplanIdArg, out var id) || !long.TryParse(id, out var eplanId))
                PutInvalidArg(pageModel);
            else
            {
                var manufacturer = DataPortal.GetManufacturers()
                    .SingleOrDefault(m => m.EplanId == eplanId);

                if (manufacturer == null)
                    PutInvalidArg(pageModel);
                else if (!Repository.Company.CanBeImported(manufacturer))
                    pageModel.PutMessage(ScreenMessageType.Error, $"Can not import manufacturer '{manufacturer}' due to unique constraints.");
                else Import(pageModel, manufacturer);
            }

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, EplanIdArg);

            return pageModel.LocalRedirect(url);
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel, Dictionary<string, string?> args)
        {
            return null;
        }

        private static void Import(BaseErpPageModel pageModel, DataPortalManufacturer manufacturer)
        {
            void TransactionalAction()
            {
                if (Repository.Company.Insert(manufacturer) == null)
                    throw new DbException($"Failed to import manufacturer '{manufacturer.Name}'");
            }

            if (Transactional.TryExecute(pageModel, TransactionalAction))
                pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported manufacturer '{manufacturer.Name}'");
        }

        private static void PutInvalidArg(BaseErpPageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Error, $"invalid argument '{EplanIdArg}'");
        }
    }
}
