using System.Text.RegularExpressions;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerListImportSnippet : SnippetBase
{
    const string hookValue = "hookKey=manufacturer_eplan_import&hEplanId=";

#pragma warning disable SYSLIB1045 // Is compiled at Runtime
    private static readonly Regex s_reg = new ($"{hookValue}[^&]*", RegexOptions.Compiled);
#pragma warning restore SYSLIB1045 // Is compiled at Runtime

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
