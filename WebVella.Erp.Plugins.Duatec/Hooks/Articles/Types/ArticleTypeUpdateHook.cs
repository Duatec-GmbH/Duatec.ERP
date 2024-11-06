using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Articles.Types
{
    [HookAttachment(key: HookKeys.Article.Type.Update)]
    internal class ArticleTypeUpdateHook : UpdateOnListHookBase
    {
        private static readonly ArticleTypeValidator _validator = new();

        protected override IRecordValidator Validator => _validator;

        protected override string Entity => ArticleType.Entity;

        protected override string LabelProperty => ArticleType.Label;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var label = pageModel.GetFormValue(ArticleType.Label) ?? string.Empty;
            var unit = pageModel.GetFormValue(ArticleType.Unit) ?? string.Empty;
            var isInteger = bool.TryParse(pageModel.GetFormValue(ArticleType.IsInteger), out var b) && b;

            var rec = new EntityRecord();
            rec[ArticleType.Label] = label;
            rec[ArticleType.Unit] = unit;
            rec[ArticleType.IsInteger] = isInteger;

            return rec;
        }
    }
}
