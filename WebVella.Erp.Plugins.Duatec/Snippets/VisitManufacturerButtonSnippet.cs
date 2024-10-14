using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using static WebVella.Erp.Plugins.Duatec.DataModel.EntityInfo;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class VisitManufacturerButtonSnippet : ListLinkButtonSnippetBase
{
    protected override string Text => "Visit Website";

    protected override string Property => Manufacturer.WebsiteUrl;

    protected override string? Icon => "fab fa-internet-explorer";
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

