using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types
{
    [Snippet]
    internal class ArticleTypeListNumberKindSnippet : BoolSnippetBase
    {
        protected override object? TrueValue => "Integer";

        protected override object? FalseValue => "Real";

        protected override string DataSourceProperty => "RowRecord";

        protected override string RecordProperty => ArticleType.IsInteger;
    }
}
