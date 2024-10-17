using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleTypeCreateSnippet : ParameterizedHookFromListSnippetBase
{
    protected override string HookKey => "article_type_create";

    protected override (string HookParameter, string RecordParameter)[] ParameterInfos 
        => [];
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

