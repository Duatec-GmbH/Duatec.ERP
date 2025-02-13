using System.Collections.Generic;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	[Hook("Provide hook for point in code after entity records are deleted.")]
	public interface IErpPostDeleteManyRecordsHook
	{
		void OnPostDeleteRecords(string entityName, IEnumerable<EntityRecord> records);
	}
}
