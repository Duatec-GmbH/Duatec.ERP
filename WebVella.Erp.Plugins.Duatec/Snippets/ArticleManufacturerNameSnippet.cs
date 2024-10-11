#pragma warning disable IDE0005
using System;
using System.Linq;
#pragma warning restore IDE0005
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleManufacturerNameSnippet : ICodeVariable
{
    public object Evaluate(BaseErpPageModel pageModel)
    {
        try
        {
            var id = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord")?[EntityInfo.Article.ManufacturerId];
            if (id == null)
                return null!;

            return pageModel.TryGetDataSourceProperty<EntityRecordList>("AllManufacturers")?
                .FirstOrDefault(m => m["id"].Equals(id))?[EntityInfo.Manufacturer.Name]!;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}
#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
