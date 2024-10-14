using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class SnippetBase : ICodeVariable
    {
        public object? Evaluate(BaseErpPageModel pageModel)
        {
            try
            {
                return GetValue(pageModel);
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        protected abstract object? GetValue(BaseErpPageModel pageModel);
    }
}
