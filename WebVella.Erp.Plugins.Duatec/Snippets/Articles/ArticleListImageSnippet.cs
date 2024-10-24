using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles
{
    [Snippet]
    public class ArticleListImageSnippet : ImageSnippetBase
    {
        protected override int? Height => 50;

        protected override int? Width => 50;

        protected override string Property => Article.Image;

        protected override string RecordProperty => "RowRecord";
    }
}