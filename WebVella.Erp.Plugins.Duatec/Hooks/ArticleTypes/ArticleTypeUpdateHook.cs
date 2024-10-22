using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Hooks.ArticleTypes
{
    [HookAttachment(key: HookKeys.ArticleType.Update)]
    internal class ArticleTypeUpdateHook : UpdateOnListHookBase
    {
        const string labelField = "label";
        const string unitField = "unit";

        private static readonly ArticleTypeValidator _validator = new();

        protected override IValidator Validator => _validator;

        protected override string Entity => ArticleType.Entity;

        protected override string LabelProperty => ArticleType.Label;

        protected override EntityRecord CreateRecord(BaseErpPageModel pageModel)
        {
            var label = pageModel.GetFormValue(labelField) ?? string.Empty;
            var unit = pageModel.GetFormValue(unitField) ?? string.Empty;

            var rec = new EntityRecord();
            rec[ArticleType.Label] = label;
            rec[ArticleType.Unit] = unit;

            return rec;
        }
    }
}
