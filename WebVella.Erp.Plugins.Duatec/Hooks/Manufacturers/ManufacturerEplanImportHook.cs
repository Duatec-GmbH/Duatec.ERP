using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Plugins.Duatec.Eplan.DataModel;
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
                var manufacturer = EplanDataPortal.GetManufacturers()
                    .SingleOrDefault(m => m.EplanId == eplanId);

                if (manufacturer == null)
                    PutInvalidArg(pageModel);
                else if (!Manufacturer.CanBeImported(manufacturer))
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

        private static void Import(BaseErpPageModel pageModel, ManufacturerDto manufacturer)
        {
            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();

            connection.BeginTransaction();

            try
            {
                if (Manufacturer.Insert(manufacturer) == null)
                    pageModel.PutMessage(ScreenMessageType.Error, $"Failed to import manufacturer '{manufacturer.Name}'");
                else
                {
                    connection.CommitTransaction();
                    pageModel.PutMessage(ScreenMessageType.Success, $"Successfully imported manufacturer '{manufacturer.Name}'");
                }
            }
            catch (Exception ex)
            {
                connection.RollbackTransaction();
                pageModel.PutMessage(ScreenMessageType.Error, $"Failed to import manufacturer '{manufacturer.Name}': {ex.Message}");
            }
        }

        private static void PutInvalidArg(BaseErpPageModel pageModel)
        {
            pageModel.PutMessage(ScreenMessageType.Error, $"invalid argument '{EplanIdArg}'");
        }
    }
}
