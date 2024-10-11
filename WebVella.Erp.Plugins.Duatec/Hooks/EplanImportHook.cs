using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Database;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "eplan_import")]
    public class EplanImportHook : IPageHook
    {
        public IActionResult OnPost(BaseErpPageModel pageModel)
        {
            var id = GetId(pageModel);
            var type = GetType(pageModel);
            Import(pageModel, id, type);
            return null!;
        }

        private static string GetId(BaseErpPageModel pageModel)
            => GetFormField(pageModel, "eplan_identifier");

        private static string GetType(BaseErpPageModel pageModel)
            => GetFormField(pageModel, "article_type");

        private static string GetFormField(BaseErpPageModel pageModel, string id)
        {
            var form = pageModel.Request.Form;
            if (form.ContainsKey(id) && !string.IsNullOrWhiteSpace(form[id]))
                return form[id]!;
            return string.Empty;
        }

        private static string? FindNode(IEnumerable<PageBodyNode> nodes, string name)
        {
            foreach(var node in nodes)
            {
                if (node.ComponentName == name)
                    return "";

                var s = FindNode(node.Nodes, name);
                if(s != null) 
                    return s;
            }
            return null;
        }

        public IActionResult OnGet(BaseErpPageModel pageModel)
        {
            return null!;
        }

        public static void Import(BaseErpPageModel pageModel, string partNumber, string type)
        {
            if (string.IsNullOrEmpty(partNumber))
            {
                PutMessage(pageModel, ScreenMessageType.Error, $"Please enter the article part number.");
                return;
            }

            if (string.IsNullOrEmpty(type))
            {
                PutMessage(pageModel, ScreenMessageType.Error, $"Please select a type.");
                return;
            }

            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            using var scope = SecurityContext.OpenSystemScope();

            try
            {
                if (!TryGetArticle(pageModel, partNumber, out var article))
                    return;

                connection.BeginTransaction();

                var manufacturer = Db.GetManufacturerIdByShortName(article.Manufacturer.ShortName)
                    ?? Db.InsertManufacturer(article.Manufacturer);

                if (manufacturer == null)
                {
                    connection.RollbackTransaction();
                    PutMessage(pageModel, ScreenMessageType.Error, $"Could not create manufacturer '{article.Manufacturer.Name}'.");
                    return;
                }

                if (!CreateArticle(pageModel, article, manufacturer.Value, type))
                {
                    connection.RollbackTransaction();
                    PutMessage(pageModel, ScreenMessageType.Error, $"Could not create article '{article.PartNumber}'.");
                    return;
                }

                PutMessage(pageModel, ScreenMessageType.Success, $"Successfully imported article '{article.PartNumber}'.");
                connection.CommitTransaction();
            }
            catch
            {
                connection.RollbackTransaction();
                throw;
            }
        }

        private static bool CreateArticle(BaseErpPageModel pageModel, ArticleDto article, Guid manufacturer, string type)
        {
            if (Db.InsertArticle(article, manufacturer, type) != null)
                return true;

            PutMessage(pageModel, ScreenMessageType.Error, $"Could not create article '{article.PartNumber}'.");
            return false;
        }

        private static bool TryGetArticle(BaseErpPageModel pageModel, string partNumber, [NotNullWhen(true)] out ArticleDto? article)
        {
            article = EplanDataPortal.GetArticleByPartNumber(partNumber);

            if (article == null)
                PutMessage(pageModel, ScreenMessageType.Error, $"Article '{partNumber}' does not exist.");
            else if (EplanIdExists(article))
                PutMessage(pageModel, ScreenMessageType.Error, $"An article with the same EPLAN id already exists.");
            else if (PartNumberExists(article))
                PutMessage(pageModel, ScreenMessageType.Error, $"Article '{partNumber}' already exists.");
            else return true;

            article = null;
            return false;
        }

        private static bool EplanIdExists(ArticleDto article)
            => Db.GetArticleIdByEplanId(article.EplanId.ToString()) != null;
        

        private static bool PartNumberExists(ArticleDto article)
            => Db.GetArticleIdByPartNumber(article.PartNumber) != null;

        private static void PutMessage(BaseErpPageModel pageModel, ScreenMessageType type, string message)
        {
            pageModel.TempData.Put("ScreenMessage", new ScreenMessage() 
            { 
                Message = message, 
                Type = type, 
                Title = type.ToString() 
            });
        }
    }
}
