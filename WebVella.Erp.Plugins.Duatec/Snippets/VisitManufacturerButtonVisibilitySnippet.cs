using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using static WebVella.Erp.Plugins.Duatec.DataModel.EntityInfo;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class VisitManufacturerButtonSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var url = $"{pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Manufacturer.WebsiteUrl]}";
        return !string.IsNullOrEmpty(url);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

