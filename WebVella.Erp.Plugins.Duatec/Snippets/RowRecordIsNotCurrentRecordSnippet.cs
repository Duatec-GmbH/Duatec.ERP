using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class RowRecordIsNotCurrentRecordSnippet : SnippetBase
    {
        protected virtual string IdParameter => "hId";

        protected override object GetValue(BaseErpPageModel pageModel)
        {
            var rowRec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rowRec?["id"] is not Guid id || id == Guid.Empty)
                return false;

            return !Guid.TryParse(pageModel.Request.Query[IdParameter], out var reqId)
                || id != reqId;
        }
    }
}