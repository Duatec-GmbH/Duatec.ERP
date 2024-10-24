using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class RowRecordIsCurrentRecordSnippet : SnippetBase
    {
        protected override object GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
            var rowRec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");

            return rec?["id"] is Guid recId 
                && rowRec?["id"] is Guid rowRecId 
                && recId != Guid.Empty 
                && recId == rowRecId;
        }
    }
}