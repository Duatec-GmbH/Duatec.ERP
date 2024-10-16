using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleDetailImageSnippet : ImageSnippetBase
{
    protected override int? Height => 200;

    protected override int? Width => 200;

    protected override string Property => Article.Image;

    protected override string RecordProperty => "Record";
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

