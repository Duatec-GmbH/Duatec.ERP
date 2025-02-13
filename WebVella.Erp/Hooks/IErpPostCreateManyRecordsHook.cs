using System.Collections.Generic;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	[Hook("Provide hook for point in code after entity records are created.")]
	public interface IErpPostCreateManyRecordsHook
	{
		void OnPostCreateRecords(string entityName, IEnumerable<EntityRecord> records);
	}
}
