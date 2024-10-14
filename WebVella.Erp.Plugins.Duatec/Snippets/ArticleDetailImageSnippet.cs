using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleDetailImageSnippet : ImageSnippetBase
{
    protected override int? Height => 200;

    protected override int? Width => 200;

    protected override string Property => EntityInfo.Article.Image;
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

