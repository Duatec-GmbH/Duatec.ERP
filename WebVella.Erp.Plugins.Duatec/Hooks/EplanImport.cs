using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Eql;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Utils;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "eplan_import")]
    public class EplanImport : IPageHook
    {
        public IActionResult OnPost(BaseErpPageModel pageModel)
        {
            Import(pageModel, GetId(pageModel));
            return null!;
        }

        private static string GetId(BaseErpPageModel pageModel) 
        {
            var form = pageModel.Request.Form;
            if (form.ContainsKey("eplan_identifier") && !string.IsNullOrWhiteSpace(form["eplan_identifier"]))
                return form["eplan_identifier"]!;
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

        public static void Import(BaseErpPageModel pageModel, string partNumber)
        {
            if (string.IsNullOrEmpty(partNumber))
            {
                PutMessage(pageModel, ScreenMessageType.Error, $"Please enter the article part number.");
                return;
            }

            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            using var scope = SecurityContext.OpenSystemScope();

            try
            {
                if (!TryGetArticle(pageModel, partNumber, out var article))
                    return;

                var articleType = GetArticleType(article.PartType);
                if (articleType == null)
                {
                    PutMessage(pageModel, ScreenMessageType.Error, $"Article type '{article.PartType}' is not defined.");
                    return;
                }

                connection.BeginTransaction();
                var recMan = new RecordManager();
                var manufacturer = GetManufacturer(article.Manufacturer)
                    ?? InsertManufacturer(recMan, article.Manufacturer);

                if (manufacturer == null)
                {
                    connection.RollbackTransaction();
                    PutMessage(pageModel, ScreenMessageType.Error, $"Could not create manufacturer '{article.Manufacturer.Name}'.");
                    return;
                }

                var rec = new EntityRecord();

                rec["id"] = Guid.NewGuid();
                rec["part_number"] = article.PartNumber;
                rec["eplan_id"] = article.Id.ToString();
                rec["description"] = article.Description;
                rec["article_type"] = articleType.Value;
                rec["manufacturer_id"] = manufacturer.Value;
                rec["description"] = article.Description;
                rec["preview"] = article.PictureUrl;

                var response = recMan.CreateRecord("article", rec);

                if (!response.Success)
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

        private static bool TryGetArticle(BaseErpPageModel pageModel, string partNumber, [NotNullWhen(true)] out ArticleDto? article)
        {
            article = DataPortal.GetArticleByPartNumber(partNumber);

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
        {
            var eql = new EqlCommand("select id from article where eplan_id = @id",
                new EqlParameter("id", article.Id.ToString()));

            var result = eql.Execute();

            return result != null && result.Count > 0;
        }

        private static bool PartNumberExists(ArticleDto article)
        {
            var eql = new EqlCommand("select id from article where part_number = @id",
                new EqlParameter("id", article.PartNumber));

            var result = eql.Execute();

            return result != null && result.Count > 0;
        }

        private static void PutMessage(BaseErpPageModel pageModel, ScreenMessageType type, string message)
        {
            pageModel.TempData.Put("ScreenMessage", new ScreenMessage() 
            { 
                Message = message, 
                Type = type, 
                Title = type.ToString() 
            });
        }

        private static Guid? GetArticleType(string articleType)
        {
            var eql = new EqlCommand("select id from article_type where label = @at",
                new EqlParameter("at", articleType));

            var result = eql.Execute();

            if (result.Count == 1)
                return (Guid)result[0]["id"];
            return null;
        }

        private static Guid? GetManufacturer(ManufacturerDto manufacturer)
        {
            var eql = new EqlCommand("select id from manufacturer where eplan_id = @id",
                new EqlParameter("id", manufacturer.Id.ToString()));

            var result = eql.Execute();

            if (result.Count == 1)
                return (Guid)result[0]["id"];
            return null;
        }

        private static Guid? InsertManufacturer(RecordManager recMan, ManufacturerDto manufacturer)
        {
            var rec = new EntityRecord();

            var id = Guid.NewGuid();

            rec["id"] = id;
            rec["eplan_id"] = manufacturer.Id.ToString();
            rec["logo"] = manufacturer.LogoUrl;
            rec["name"] = manufacturer.Name;
            rec["short_name"] = manufacturer.ShortName;
            rec["website"] = manufacturer.WebsiteUrl;

            var result = recMan.CreateRecord("manufacturer", rec);
            if (result.Success)
                return id;
            return null;
        }
    }
}
