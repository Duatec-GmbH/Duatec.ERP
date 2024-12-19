using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataSource;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base
{
    internal abstract class OrderListEntryAmountSnippetBase : ArticleAmountSnippetBase
    {
        protected override Article? GetArticle(BaseErpPageModel pageModel)
            => Article.Create(GetDataSourcePropertyFromRecord(pageModel, $"${OrderListEntries4Project.Record.Relations.Article}[0]") as EntityRecord);

        protected override ArticleType? GetArticleType(BaseErpPageModel pageModel)
            => ArticleType.Create(GetDataSourcePropertyFromRecord(pageModel, $"${OrderListEntries4Project.Record.Relations.Article}[0].${Article.Relations.Type}[0]") as EntityRecord);
    }
}
