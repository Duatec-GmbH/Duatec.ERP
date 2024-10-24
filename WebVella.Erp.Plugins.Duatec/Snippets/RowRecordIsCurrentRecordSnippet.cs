﻿#pragma warning disable IDE0005
using System;
#pragma warning restore IDE0005
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class RowRecordIsCurrentRecordSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
        var rowRec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");

        return rec != null
            && rowRec != null
            && (rec == rowRec || rec["id"] is Guid recId && recId != Guid.Empty && rowRec["id"] is Guid rowRecId && recId == rowRecId);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

