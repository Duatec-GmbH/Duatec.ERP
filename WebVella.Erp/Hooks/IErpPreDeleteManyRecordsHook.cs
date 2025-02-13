using System.Collections.Generic;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	[Hook("Provide hook for point in code before entity records are deleted.")]
	internal interface IErpPreDeleteManyRecordsHook
	{
		void OnPreDeleteRecords(string entityName, IEnumerable<EntityRecord> records, List<ErrorModel> errors);
	}
}
