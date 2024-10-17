using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.TagHelpers.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class FieldAccessByRecordNullabilitySnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        if (pageModel.TryGetDataSourceProperty<EntityRecord>("Record") != null)
            return WvFieldAccess.Full;
        return WvFieldAccess.ReadOnly;
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

