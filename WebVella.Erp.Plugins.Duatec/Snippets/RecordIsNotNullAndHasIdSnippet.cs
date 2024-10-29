using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class RecordIsNotNullAndHasIdSnippet : ICodeVariable
    {
        protected virtual string IdParameter => "hId";

        public object Evaluate(BaseErpPageModel pageModel)
        {
            try
            {
                var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("Record");
                return rec?["id"] is Guid id
                    && id != Guid.Empty;
            }
            catch
            {
                return false;
            }
        }
    }
}
