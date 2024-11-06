using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    internal abstract class BoolSnippetBase : SnippetBase
    {
        protected abstract string DataSourceProperty { get; }

        protected abstract string RecordProperty { get; }

        protected abstract object? TrueValue { get; }

        protected abstract object? FalseValue { get; }

        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var val = pageModel.TryGetDataSourceProperty<EntityRecord>(DataSourceProperty)?[RecordProperty] as bool?;
            if (!val.HasValue)
                return null;
            return val.Value ? TrueValue : FalseValue;
        }
    }
}
