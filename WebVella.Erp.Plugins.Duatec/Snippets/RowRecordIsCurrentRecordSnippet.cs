using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
internal class RowRecordIsCurrentRecordSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
        var rowRec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");

        return rec != null
            && rowRec != null
            && (rec == rowRec || rec["id"] != null && rec["id"] == rowRec["id"]);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

