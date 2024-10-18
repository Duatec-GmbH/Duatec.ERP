using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerListImageSnippet : ImageSnippetBase
{
    protected override int? Height => 45;

    protected override string Property => Manufacturer.LogoUrl;

    protected override string RecordProperty => "RowRecord";
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
