using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleListImageSnippet : ImageSnippetBase
{
    protected override int? Height => 50;

    protected override int? Width => 50;

    protected override string Property => Article.Image;

    protected override string RecordProperty => "RowRecord";
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime
