using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	[Hook("Provide hook for point in code after entity record is created.")]
	public interface IErpPostCreateRecordHook
	{
		bool ExecuteOnPostCreateMany { get; }

		void OnPostCreateRecord(string entityName, EntityRecord record);
	}
}
