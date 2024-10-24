using System;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable IDE0005
using System;
#pragma warning restore IDE0005
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class RowRecordIsNotCurrentRecordSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
        var rowRec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");

        return rec != null
            && rowRec != null
            && rowRec["id"] is Guid rowRecId && (rec["id"] is not Guid recId || recId != rowRecId);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
