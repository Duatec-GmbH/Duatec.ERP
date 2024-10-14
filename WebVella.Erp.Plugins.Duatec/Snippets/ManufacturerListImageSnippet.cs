using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerListImageSnippet : ImageSnippetBase
{
    protected override int? Height => 50;

    protected override string Property => EntityInfo.Manufacturer.LogoUrl;
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
