﻿using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManufacturerListImportSnippet : ParameterizedHookFromListSnippetBase
{
    protected override string HookKey => HookKeys.Manufacturer.EplanImport;

    protected override (string HookParameter, string RecordParameter)[] ParameterInfos =>
        [("hEplanId", Manufacturer.EplanId)];
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
