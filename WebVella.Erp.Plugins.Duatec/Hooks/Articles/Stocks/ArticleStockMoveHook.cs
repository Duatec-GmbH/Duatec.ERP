using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Pages.Application;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Stocks
{
    [HookAttachment(key: HookKeys.Article.Stock.Move)]
    internal class ArticleStockMoveHook : IRecordManagePageHook
    {
        private static readonly ArticleStockValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var id = (Guid)record["id"];
            var unchanged = ArticleStock.Find(id)!;

            if (OriginAndTargetAreSame(record, unchanged))
                validationErrors.Add(new ValidationError(string.Empty, "Can not move article without changes at project and/or location"));

            record[ArticleStock.Article] = unchanged[ArticleStock.Article];
            validationErrors.AddRange(_validator.ValidateOnCreate(record));

            if (record[ArticleStock.Amount] == null)
                record[ArticleStock.Amount] = 0m;

            ArticleStockRecord.RoundAmount(record);
            var max = (decimal)unchanged[ArticleStock.Amount];
            var amount = (decimal)record[ArticleStock.Amount];

            if (amount > max + 0.001m)
            {
                var type = ArticleType.FromArticle((Guid)unchanged[ArticleStock.Article])!;
                var isInt = (bool)type[ArticleType.IsInteger];
                var maxVal = isInt ? $"{max:0}" : $"{max:0.00}";
                validationErrors.Add(new ValidationError(ArticleStock.Amount, $"Amount must not be greater than {maxVal} {type[ArticleType.Unit]}"));
            }

            if (validationErrors.Count > 0)
                return null;

            var result = amount > max - 0.001m
                ? CompleteMove(record, pageModel, validationErrors)
                : PartialMove(record, pageModel, validationErrors);

            if(result != null)
                pageModel.PutMessage(ScreenMessageType.Success, "Successfully moved articles");
            return result;
        }

        private static bool OriginAndTargetAreSame(EntityRecord a, EntityRecord b)
        {
            var projA = a[ArticleStock.Project] as Guid?;
            var projB = b[ArticleStock.Project] as Guid?;

            return (Guid)a[ArticleStock.WarehouseLocation] == (Guid)b[ArticleStock.WarehouseLocation]
                && !(projA.HasValue ^ projB.HasValue) 
                && projA.HasValue && projA.Value == projB!.Value;
        }

        private static IActionResult? CompleteMove(EntityRecord record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            if (!ArticleStock.Delete((Guid)record["id"]))
            {
                validationErrors.Add(new ValidationError(string.Empty, "Could not delete article stock entry"));
                return null;
            }
            record["id"] = null;
            return ArticleStockRecordHooks.Create(record, pageModel, validationErrors);
        }

        private static IActionResult? PartialMove(EntityRecord record, BaseErpPageModel pageModel, List<ValidationError> validationErrors)
        {
            var id = (Guid)record["id"];
            var unchanged = ArticleStock.Find(id)!;

            unchanged[ArticleStock.Amount] = (decimal)unchanged[ArticleStock.Amount] - (decimal)record[ArticleStock.Amount];
            ArticleStockRecord.RoundAmount(unchanged);

            if (!new RecordManager().UpdateRecord(ArticleStock.Entity, unchanged).Success)
            {
                validationErrors.Add(new ValidationError(string.Empty, "Could not update article stock entry"));
                return null;
            }
            record["id"] = null;
            var result = ArticleStockRecordHooks.Create(record, pageModel, validationErrors);
            if (result != null)
                return pageModel.LocalRedirect(PageUrl.EntityManage(pageModel, id, "move"));
            
            return null;
        }
    }
}
