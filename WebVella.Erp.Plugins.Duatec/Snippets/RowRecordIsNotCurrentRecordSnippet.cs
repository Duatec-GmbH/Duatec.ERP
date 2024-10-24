using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class RowRecordIsNotCurrentRecordSnippet : SnippetBase
    {
        protected override object GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            var rowRec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");

            return rowRec != null && rowRec["id"] is Guid rowRecId && rowRecId != Guid.Empty
                && (rec?["id"] == null
                    || rec["id"] is Guid recId && rowRecId != recId
                );
        }
    }
}