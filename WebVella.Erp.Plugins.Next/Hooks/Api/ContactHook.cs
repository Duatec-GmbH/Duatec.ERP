﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Next.Services;

namespace WebVella.Erp.Plugins.Next.Hooks.Api
{
	[HookAttachment("contact",int.MinValue)]
	public class ContactHook : IErpPostCreateRecordHook, IErpPostUpdateRecordHook
	{
        public bool ExecuteOnPostCreateMany => true;

        public bool ExecuteOnPostUpdateMany => true;

        public void OnPostCreateRecord(string entityName, EntityRecord record)
		{
			new SearchService().RegenSearchField(entityName,record, Configuration.ContactSearchIndexFields);
		}

		public void OnPostUpdateRecord(string entityName, EntityRecord record)
		{
			new SearchService().RegenSearchField(entityName,record, Configuration.ContactSearchIndexFields);
		}
	}
}
