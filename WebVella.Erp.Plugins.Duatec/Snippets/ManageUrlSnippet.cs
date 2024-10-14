using WebVella.Erp.Web.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Common;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ManageUrlSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        return Url.ReplacePageKind(pageModel, 'm');
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
