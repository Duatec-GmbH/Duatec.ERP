using System.Text.RegularExpressions;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using static WebVella.Erp.Plugins.Duatec.DataModel.EntityInfo;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerListImportSnippet : SnippetBase
{
    const string hookValue = "hookKey=manufacturer_eplan_import&hEplanId=";

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    private static readonly Regex s_reg = new ($"{hookValue}[^&]*", RegexOptions.Compiled);
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.

    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var id = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[Manufacturer.EplanId]?.ToString();
        var url = pageModel.CurrentUrl;

        if(s_reg.IsMatch(url))
            return s_reg.Replace(url, $"{hookValue}{id}");
        if (url.Contains('?'))
            return url + $"&{hookValue}{id}";
        return url + $"?{hookValue}{id}";
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
