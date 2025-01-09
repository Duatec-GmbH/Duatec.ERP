using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance
{
    internal static class Transactional
    {
        public static bool TryExecute(BaseErpPageModel? pageModel, Action action)
        {
            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            connection.BeginTransaction();

            try
            {
                action();
                connection.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                connection.RollbackTransaction();
                pageModel?.PutMessage(ScreenMessageType.Error, ex.Message);
                return false;
            }
        }

        public static bool TryExecute(Action action)
            => TryExecute(null, action);
    }
}
