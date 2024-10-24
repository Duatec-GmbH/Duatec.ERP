using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleDetailImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 200;

        protected override int? Width => 200;

        protected override string Property => Article.Image;

        protected override string RecordProperty => "Record";
    }
}