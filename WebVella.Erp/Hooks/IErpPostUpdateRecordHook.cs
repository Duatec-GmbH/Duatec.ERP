﻿using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	[Hook("Provide hook for point in code after entity record is updated.")]
	public interface IErpPostUpdateRecordHook
	{
		bool ExecuteOnPostUpdateMany { get; }

		void OnPostUpdateRecord(string entityName, EntityRecord record); 
	}
}
