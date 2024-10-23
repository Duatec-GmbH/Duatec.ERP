using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleTypeManageSnippet : ParameterizedHookFromListSnippetBase
{
    protected override string HookKey => HookKeys.ArticleType.Manage;

    protected override (string HookParameter, string RecordParameter)[] ParameterInfos
        => [("hId", "id")];
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
