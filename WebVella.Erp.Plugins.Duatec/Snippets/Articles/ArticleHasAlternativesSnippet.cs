using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleHasAlternativesSnippet : SnippetBase
{
    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        if (!pageModel.RecordId.HasValue)
            return false;
        return Article.HasAlternatives(pageModel.RecordId.Value);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
