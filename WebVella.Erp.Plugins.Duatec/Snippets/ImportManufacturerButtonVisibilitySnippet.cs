#pragma warning disable IDE0005
using System;
#pragma warning restore IDE0005
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec;
using WebVella.Erp.Plugins.Duatec.Entities;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ImportManufacturerButtonVisibilitySnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
        if (rec == null)
            return false;

        var id = $"{rec[Manufacturer.EplanId]}";
        var shortName = $"{rec[Manufacturer.ShortName]}";
        var name = $"{rec[Manufacturer.Name]}";

        if (!long.TryParse(id, out var eplanId) || string.IsNullOrEmpty(shortName) || string.IsNullOrEmpty(name))
            return false;

        var dto = new ManufacturerDto(eplanId, shortName, name, null, null);

        return Db.CanImportManufacturer(dto);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime