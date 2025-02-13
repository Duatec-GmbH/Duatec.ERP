using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Next.Services;

namespace WebVella.Erp.Plugins.Next.Hooks.Api
{
	[HookAttachment("task",int.MinValue)]
	public class TaskHook : IErpPostCreateRecordHook, IErpPostUpdateRecordHook
	{
        public bool ExecuteOnPostCreateMany => true;

        public bool ExecuteOnPostUpdateMany => true;

        public void OnPostCreateRecord(string entityName, EntityRecord record)
		{
			new SearchService().RegenSearchField(entityName,record, Configuration.TaskSearchIndexFields);
		}

		public void OnPostUpdateRecord(string entityName, EntityRecord record)
		{
			new SearchService().RegenSearchField(entityName,record, Configuration.TaskSearchIndexFields);
		}
	}
}
