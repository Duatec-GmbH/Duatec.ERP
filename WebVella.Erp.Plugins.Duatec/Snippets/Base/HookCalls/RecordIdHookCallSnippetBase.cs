using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base.HookCalls
{
    public abstract class RecordIdHookCallSnippetBase : ParameterizedHookCallSnippetBase
    {
        protected virtual string IdParameter => "hId";

        protected override IEnumerable<string> Parameters => [IdParameter];

        protected override object? GetParameterValue(string parameter, BaseErpPageModel pageModel)
        {
            if (parameter != IdParameter)
                return null;

            return pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[IdParameter];
        }
    }
}
