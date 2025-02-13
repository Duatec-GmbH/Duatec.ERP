using System.Collections.Generic;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	[Hook("Provide hook for point in code before entity records are created.")]
	internal interface IErpPreCreateManyRecordsHook
	{
		void OnPreCreateRecords(string entityName, IEnumerable<EntityRecord> record, List<ErrorModel> errors);
	}
}
