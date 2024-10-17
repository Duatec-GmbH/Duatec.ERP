using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class RecordIsNotNullSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        return pageModel.TryGetDataSourceProperty<EntityRecord>("Record") != null;
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
