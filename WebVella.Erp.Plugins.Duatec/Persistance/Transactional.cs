using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Persistance
{
    internal static class Transactional
    {
        public static LocalRedirectResult Delete(BaseErpPageModel pageModel, Func<QueryResponse> deleteAction, string? returnUrl = null)
        {
            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            connection.BeginTransaction();

            try
            {
                var result = deleteAction();

                if (!result.Success)
                    return DeleteFailure(connection, pageModel, result.GetMessage());
                else
                {
                    connection.CommitTransaction();
                    if(string.IsNullOrEmpty(returnUrl))
                        return pageModel.LocalRedirect(PageUrl.EntityList(pageModel));
                    return pageModel.LocalRedirect(returnUrl);
                }
            }
            catch(Exception ex)
            {
                return DeleteFailure(connection, pageModel, ex.Message);
            }
        }

        public static bool TryExecute(BaseErpPageModel pageModel, Action action)
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
                pageModel.PutMessage(ScreenMessageType.Error, ex.Message);
                return false;
            }
        }

        private static LocalRedirectResult DeleteFailure(DbConnection connection, BaseErpPageModel pageModel, string message)
        {
            connection.RollbackTransaction();
            pageModel.PutMessage(ScreenMessageType.Error, message);
            return pageModel.LocalRedirect(Url.RemoveParameters(pageModel.CurrentUrl));
        }
    }
}
