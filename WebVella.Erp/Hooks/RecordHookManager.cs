using System;
using System.Collections.Generic;
using System.Linq;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Hooks
{
	internal static class RecordHookManager
	{
		public static bool ContainsAnyHooksForEntity(string entityName)
		{
			return
				HookManager.GetHookedInstances<IErpPreCreateRecordHook>(entityName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPreUpdateRecordHook>(entityName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPreDeleteRecordHook>(entityName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPostCreateRecordHook>(entityName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPostUpdateRecordHook>(entityName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPostDeleteRecordHook>(entityName).Count > 0;
		}

		public static bool HasRegisteredDeleteHooks(string entityName, bool isDeleteMany)
		{
			IEnumerable<IErpPreDeleteRecordHook> preDeleteHooks = HookManager.GetHookedInstances<IErpPreDeleteRecordHook>(entityName);
			if (isDeleteMany)
				preDeleteHooks = preDeleteHooks.Where(inst => inst.ExecuteOnPreDeleteMany);

			if (preDeleteHooks.Any())
				return true;

			IEnumerable<IErpPostDeleteRecordHook> postDeleteHooks = HookManager.GetHookedInstances<IErpPostDeleteRecordHook>(entityName);
			if (isDeleteMany)
				postDeleteHooks = postDeleteHooks.Where(inst => inst.ExecuteOnPostDeleteMany);

			return postDeleteHooks.Any() || isDeleteMany && (
					HookManager.GetHookedInstances<IErpPreDeleteManyRecordsHook>(entityName).Count > 0
					|| HookManager.GetHookedInstances<IErpPostDeleteManyRecordsHook>(entityName).Count > 0
				);
		}

		public static bool HasRegisteredCreateHooks(string entityName, bool isCreateMany)
		{
			IEnumerable<IErpPreCreateRecordHook> preCreateHooks = HookManager.GetHookedInstances<IErpPreCreateRecordHook>(entityName);
			if (isCreateMany)
				preCreateHooks = preCreateHooks.Where(inst => inst.ExecuteOnPreCreateMany);

			if (preCreateHooks.Any())
				return true;

			IEnumerable<IErpPostCreateRecordHook> postCreateHooks = HookManager.GetHookedInstances<IErpPostCreateRecordHook>(entityName);
			if (isCreateMany)
				postCreateHooks = postCreateHooks.Where(inst => inst.ExecuteOnPostCreateMany);

			return postCreateHooks.Any() || isCreateMany && (
					HookManager.GetHookedInstances<IErpPreCreateManyRecordsHook>(entityName).Count > 0
					|| HookManager.GetHookedInstances<IErpPostCreateManyRecordsHook>(entityName).Count > 0
				);
		}

		

		public static bool ContainsAnyHooksForRelation(string relationName)
		{
			return
				HookManager.GetHookedInstances<IErpPreCreateManyToManyRelationHook>(relationName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPostCreateManyToManyRelationHook>(relationName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPreDeleteManyToManyRelationHook>(relationName).Count > 0 ||
				HookManager.GetHookedInstances<IErpPostDeleteManyToManyRelationHook>(relationName).Count > 0;
		}

		internal static void ExecutePreCreateManyRecordsHooks(string entityName, IEnumerable<EntityRecord> records, List<ErrorModel> errors)
		{
			foreach (var inst in HookManager.GetHookedInstances<IErpPreCreateManyRecordsHook>(entityName))
				inst.OnPreCreateRecords(entityName, records, errors);
		}

		internal static void ExecutePreDeleteManyRecordsHooks(string entityname, IEnumerable<EntityRecord> records, List<ErrorModel> errors)
		{
			foreach (var inst in HookManager.GetHookedInstances<IErpPreDeleteManyRecordsHook>(entityname))
				inst.OnPreDeleteRecords(entityname, records, errors);
		}

		internal static void ExecutePostCreateManyRecordsHooks(string entityName, IEnumerable<EntityRecord> records)
		{
			foreach (var inst in HookManager.GetHookedInstances<IErpPostCreateManyRecordsHook>(entityName))
				inst.OnPostCreateRecords(entityName, records);
		}

		internal static void ExecutePostDeleteManyRecordsHooks(string entityName, IEnumerable<EntityRecord> records)
		{
			foreach (var inst in HookManager.GetHookedInstances<IErpPostDeleteManyRecordsHook>(entityName))
				inst.OnPostDeleteRecords(entityName, records);
		}

		internal static void ExecutePreCreateRecordHooks(string entityName, EntityRecord record, List<ErrorModel> errors, bool isCreateMany)
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentException("entityName");

			if (errors == null)
				throw new ArgumentNullException("errors");

			IEnumerable<IErpPreCreateRecordHook> hookedInstances = HookManager.GetHookedInstances<IErpPreCreateRecordHook>(entityName);
			if (isCreateMany)
				hookedInstances = hookedInstances.Where(inst => inst.ExecuteOnPreCreateMany);

			foreach (var inst in hookedInstances)
				inst.OnPreCreateRecord(entityName, record, errors);
		}

		internal static void ExecutePostCreateRecordHooks(string entityName, EntityRecord record, bool isCreateMany)
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentException("entityName");

			IEnumerable<IErpPostCreateRecordHook> hookedInstances = HookManager.GetHookedInstances<IErpPostCreateRecordHook>(entityName);
			if (isCreateMany)
				hookedInstances = hookedInstances.Where(inst => inst.ExecuteOnPostCreateMany);

			foreach (var inst in hookedInstances)
				inst.OnPostCreateRecord(entityName, record);
		}

		internal static void ExecutePreUpdateRecordHooks(string entityName, EntityRecord record, List<ErrorModel> errors)
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentException("entityName");

			if (errors == null)
				throw new ArgumentNullException("errors");

			List<IErpPreUpdateRecordHook> hookedInstances = HookManager.GetHookedInstances<IErpPreUpdateRecordHook>(entityName);
			foreach (var inst in hookedInstances)
				inst.OnPreUpdateRecord(entityName, record, errors);
		}

		internal static void ExecutePostUpdateRecordHooks(string entityName, EntityRecord record)
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentException("entityName");

			List<IErpPostUpdateRecordHook> hookedInstances = HookManager.GetHookedInstances<IErpPostUpdateRecordHook>(entityName);
			foreach (var inst in hookedInstances)
				inst.OnPostUpdateRecord(entityName, record);
		}

		internal static void ExecutePreDeleteRecordHooks(string entityName, EntityRecord record, List<ErrorModel> errors, bool isDeleteMany)
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentException("entityName");

			if (errors == null)
				throw new ArgumentNullException("errors");

			IEnumerable<IErpPreDeleteRecordHook> hookedInstances = HookManager.GetHookedInstances<IErpPreDeleteRecordHook>(entityName);
			if (isDeleteMany)
				hookedInstances = hookedInstances.Where(inst => inst.ExecuteOnPreDeleteMany);

			foreach (var inst in hookedInstances)
				inst.OnPreDeleteRecord(entityName, record, errors);
		}

		internal static void ExecutePostDeleteRecordHooks(string entityName, EntityRecord record, bool isDeleteMany)
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentException("entityName");

			IEnumerable<IErpPostDeleteRecordHook> hookedInstances = HookManager.GetHookedInstances<IErpPostDeleteRecordHook>(entityName);
			if (isDeleteMany)
				hookedInstances = hookedInstances.Where(inst => inst.ExecuteOnPostDeleteMany);
			
			foreach (var inst in hookedInstances)
				inst.OnPostDeleteRecord(entityName, record);
		}

		internal static void ExecutePreCreateManyToManyRelationHook(string relationName, Guid originId, Guid targetId, List<ErrorModel> errors)
		{
			if (string.IsNullOrWhiteSpace(relationName))
				throw new ArgumentException("relationName");

			if (errors == null)
				throw new ArgumentNullException("errors");

			List<IErpPreCreateManyToManyRelationHook> hookedInstances = HookManager.GetHookedInstances<IErpPreCreateManyToManyRelationHook>(relationName);
			foreach (var inst in hookedInstances)
				inst.OnPreCreate(relationName, originId, targetId, errors);
		}

		internal static void ExecutePostCreateManyToManyRelationHook(string relationName, Guid originId, Guid targetId )
		{
			if (string.IsNullOrWhiteSpace(relationName))
				throw new ArgumentException("relationName");

			List<IErpPostCreateManyToManyRelationHook> hookedInstances = HookManager.GetHookedInstances<IErpPostCreateManyToManyRelationHook>(relationName);
			foreach (var inst in hookedInstances)
				inst.OnPostCreate(relationName, originId, targetId);
		}

		internal static void ExecutePreDeleteManyToManyRelationHook(string relationName, Guid? originId, Guid? targetId, List<ErrorModel> errors)
		{
			if (string.IsNullOrWhiteSpace(relationName))
				throw new ArgumentException("relationName");

			if (errors == null)
				throw new ArgumentNullException("errors");

			List<IErpPreDeleteManyToManyRelationHook> hookedInstances = HookManager.GetHookedInstances<IErpPreDeleteManyToManyRelationHook>(relationName);
			foreach (var inst in hookedInstances)
				inst.OnPreDelete(relationName, originId, targetId, errors);
		}

		internal static void ExecutePostDeleteManyToManyRelationHook(string relationName, Guid? originId, Guid? targetId)
		{
			if (string.IsNullOrWhiteSpace(relationName))
				throw new ArgumentException("relationName");

			List<IErpPostDeleteManyToManyRelationHook> hookedInstances = HookManager.GetHookedInstances<IErpPostDeleteManyToManyRelationHook>(relationName);
			foreach (var inst in hookedInstances)
				inst.OnPostDelete(relationName, originId, targetId);
		}
	}
}
