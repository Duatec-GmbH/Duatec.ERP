using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ShelfCreateSnippet : ListCreateSnippetBase
{
    protected override string HookKey => HookKeys.Shelf.Create;
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

