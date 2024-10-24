#pragma warning disable IDE0005
using System;
#pragma warning restore IDE0005
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class RecordIsNotNullAndHasNoIdSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
        return rec != null 
            && (rec["id"] == null || Guid.Empty.Equals(rec["id"]));
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
