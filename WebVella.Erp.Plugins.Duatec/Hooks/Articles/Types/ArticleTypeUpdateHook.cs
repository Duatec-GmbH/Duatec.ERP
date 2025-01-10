using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;
using WebVella.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Update)]
    internal class ArticleTypeUpdateHook : UpdateOnListHookBase<ArticleType>
    {
        private static readonly ArticleTypeValidator _validator = new();

        protected override IRecordValidator<ArticleType> Validator => _validator;

        protected override string Entity => ArticleType.Entity;

        protected override string LabelProperty => ArticleType.Fields.Label;

        protected override ArticleType CreateRecord(BaseErpPageModel pageModel)
        {
            var label = pageModel.GetFormValue(ArticleType.Fields.Label) ?? string.Empty;
            var unit = pageModel.GetFormValue(ArticleType.Fields.Unit) ?? string.Empty;
            var isInteger = bool.TryParse(pageModel.GetFormValue(ArticleType.Fields.IsInteger), out var b) && b;

            return new ArticleType
            {
                Label = label,
                Unit = unit,
                IsInteger = isInteger
            };
        }
    }
}
