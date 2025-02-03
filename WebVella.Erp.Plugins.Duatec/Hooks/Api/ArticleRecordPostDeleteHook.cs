using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Api
{
    [HookAttachment(key: Article.Entity)]
    internal class ArticleRecordPostDeleteHook : IErpPostDeleteRecordHook
    {
        public void OnPostDeleteRecord(string entityName, EntityRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
