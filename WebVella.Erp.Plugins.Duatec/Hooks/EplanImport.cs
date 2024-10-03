using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using WebVella.Erp.Eql;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec.Eplan;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "eplan_import")]
    public class EplanImport : IPageHook
    {
        public IActionResult OnPost(BaseErpPageModel pageModel)
        {
            var id = GetId(pageModel);

            return Import(id);
        }

        private static string GetId(BaseErpPageModel pageModel) 
        {
            return FindNode(pageModel.ErpRequestContext.Page.Body, "eplanIdField")
                ?? string.Empty;
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

        public static IActionResult Import(string eplanIdentifier)
        {
            using var dbCtx = DbContext.CreateContext(ErpSettings.ConnectionString);
            using var connection = dbCtx.CreateConnection();
            using var scope = SecurityContext.OpenSystemScope();

            try
            {
                connection.BeginTransaction();

                var article = long.TryParse(eplanIdentifier, out var id)
                    ? DataPortal.GetArticleById(id)
                    : DataPortal.GetArticleByPartNumber(eplanIdentifier);

                if (article == null)
                    return new NotFoundResult();

                var eql = new EqlCommand("select id from article where eplan_id = @id or part_number = @pn",
                    new EqlParameter("id", article.Id.ToString()),
                    new EqlParameter("pn", article.PartNumber));

                var result = eql.Execute();
                if (result != null && result.Count > 0)
                    return new BadRequestResult();

                var recMan = new RecordManager();

                var articleType = GetArticleType(article.PartType);
                if (articleType == null)
                    return new BadRequestResult();

                var manufacturer = GetManufacturer(article.Manufacturer)
                    ?? InsertManufacturer(recMan, article.Manufacturer);

                if (manufacturer == null)
                {
                    connection.RollbackTransaction();
                    return new BadRequestResult();
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

                if (response.Success)
                {
                    connection.CommitTransaction();
                    return new OkResult();
                }

                connection.RollbackTransaction();
                return new BadRequestResult();
            }
            catch
            {
                connection.RollbackTransaction();
                throw;
            }
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
