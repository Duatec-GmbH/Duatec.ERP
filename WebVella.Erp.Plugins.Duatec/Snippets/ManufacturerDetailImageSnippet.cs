using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerDetailImageSnippet : ImageSnippetBase
{
    protected override int? Height => 200;

    protected override string Property => EntityInfo.Manufacturer.LogoUrl;
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
