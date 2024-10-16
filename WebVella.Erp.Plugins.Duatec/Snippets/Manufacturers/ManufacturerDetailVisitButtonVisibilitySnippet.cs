using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerDetailVisitButtonVisibilitySnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var url = $"{pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[Manufacturer.WebsiteUrl]}";
        return !string.IsNullOrEmpty(url);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

