using CSScripting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Emit;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validations;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    [HookAttachment(key: "article_type_update")]
    internal class ArticleTypeUpdateHook : IPageHook
    {
        const string labelField = "label";
        const string unitField = "unit";

        public IActionResult? OnGet(BaseErpPageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPost(BaseErpPageModel pageModel)
        {
            if (!pageModel.Request.Query.TryGetValue("hId", out var idVal) || !Guid.TryParse(idVal, out var id))
                return null;

            var rec = CreateRecord(pageModel, id);
            if(Validate(pageModel, rec))
                Update(pageModel, rec);

            if (pageModel.Validation.Errors.Count > 0)
            {
                pageModel.DataModel.SetRecord(rec);
                return null;
            }

            var url = Url.RemoveParameter(pageModel.CurrentUrl, "hookKey");
            url = Url.RemoveParameter(url, "hId");

            return pageModel.LocalRedirect(url);
        }

        private static EntityRecord CreateRecord(BaseErpPageModel pageModel, Guid id)
        {
            var label = pageModel.GetFormValue(labelField) ?? string.Empty;
            var unit = pageModel.GetFormValue(unitField) ?? string.Empty;

            var rec = new EntityRecord();
            rec["id"] = id;
            rec[ArticleType.Label] = label;
            rec[ArticleType.Unit] = unit;

            return rec;
        }

        private static bool Validate(BaseErpPageModel pageModel, EntityRecord rec)
        {
            var id = (Guid)rec["id"];
            var label = (string)rec[ArticleType.Label];
            var unit = (string)rec[ArticleType.Unit];

            pageModel.Validation.Errors ??= [];
            CommonValidations.NameIsValid(label, labelField, pageModel.Validation.Errors, "Article type label");
            ArticleTypeValidations.UnitIsValid(unit, unitField, pageModel.Validation.Errors);

            var types = Db.GetAllArticleTypes();
            if (types.Exists(t => (Guid)t["id"] != id
                && t[ArticleType.Label]?.ToString()?.Equals(label, StringComparison.OrdinalIgnoreCase) is true))
            {
                pageModel.Validation.Errors.Add(new ValidationError(labelField, $"Article with label '{label}' already exists"));
            }
            return pageModel.Validation.Errors.Count == 0;
        }

        private static void Update(BaseErpPageModel pageModel, EntityRecord rec)
        {
            var response = new RecordManager().UpdateRecord(ArticleType.Entity, rec);
            if (!response.Success)
                pageModel.Validation.Errors.AddRange(response.Errors.Select(e => new ValidationError("", e.Message)));
        }
    }
}
