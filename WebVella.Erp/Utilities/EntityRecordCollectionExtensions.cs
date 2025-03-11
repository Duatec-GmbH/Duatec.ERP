using System;
using System.Collections.Generic;
using System.Linq;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Utilities
{
#nullable enable

	public static class EntityRecordCollectionExtensions
	{
		public static IEnumerable<T> Select<T>(this IEnumerable<T> records, string entityName, string relationName, RecordManager? recMan = null)
			where T : EntityRecord
		{
			if (!Enumerable.Any(records))
				return records;

			recMan ??= new();
			var relations = recMan.RelationManager.Read().Object;

			IEnumerable<EntityRecord> currentRecords = records;

			var path = relationName.Split('.', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

			int i = 0;
			foreach (var access in path)
			{
				if (!access.StartsWith('$'))
					throw new ArgumentException($"argument '{relationName}' must only contain realations");

				var relName = access[1..];
				var relation = relations.FirstOrDefault(r => r.Name == relName)
					?? throw new InvalidOperationException($"relation '{relName}' does not exist");

				if (relation.RelationType == EntityRelationType.OneToOne)
					currentRecords = JoinSingle(currentRecords, relation, recMan, ref entityName);
				else if (relation.RelationType == EntityRelationType.OneToMany)
				{
					if (relation.TargetEntityName == entityName)
						currentRecords = JoinSingle(currentRecords, relation, recMan, ref entityName);
					else
					{
						if (i < path.Length - 1)
							throw new InvalidOperationException($"can not join many records, this is only supported on last relation path element");

						JoinMultiple(currentRecords, relation, recMan, entityName);
						break;
					}
				}
				else throw new InvalidOperationException($"relation '{relName}' has an invalid relation type only one to one and one to many are supported");

				i++;
			}

			return records;
		}

		private static IEnumerable<EntityRecord> JoinSingle(IEnumerable<EntityRecord> currentRecords, EntityRelation relation, RecordManager recMan, ref string entityName)
		{
			var (recordProperty, nextIdProperty, nextEntityName) = GetJoinInfo(relation, entityName);
			var ids = GetIds(currentRecords, recordProperty);
			var result = FindMany(recMan, nextEntityName, nextIdProperty, "*", ids);

			foreach (var r in currentRecords)
			{
				if (r.Properties.TryGetValue($"${relation.Name}", out var l) && l is List<EntityRecord>)
					continue;

				if (r[recordProperty] is not Guid id || !result.TryGetValue(id, out var rec) || rec == null)
					r[$"${relation.Name}"] = new List<EntityRecord>();
				else
					r[$"${relation.Name}"] = new List<EntityRecord>() { rec };
			}

			entityName = nextEntityName;
			return Enumerable.Where(currentRecords, v => v != null)!.ToArray();
		}


		private static void JoinMultiple(IEnumerable<EntityRecord> currentRecords, EntityRelation relation, RecordManager recMan, string entityName)
		{
			var (recordProperty, nextIdProperty, nextEntityName) = GetJoinInfo(relation, entityName);

			var subQueries = Enumerable.Select(GetIds(currentRecords, recordProperty),
				id => new QueryObject()
				{
					FieldName = nextIdProperty,
					FieldValue = id,
					QueryType = QueryType.EQ
				})
				.ToList();

			if (subQueries.Count == 0)
				return;

			var query = subQueries.Count == 1 ? subQueries[0] : new QueryObject()
			{
				QueryType = QueryType.OR,
				SubQueries = subQueries
			};

			var result = FindManyByQuery(recMan, nextEntityName, query)
				.GroupBy(r => (Guid)r[nextIdProperty])
				.ToDictionary(g => g.Key, g => g.ToList());

			foreach (var r in currentRecords)
			{
				if (r.Properties.TryGetValue($"${relation.Name}", out var l) && l is List<EntityRecord>)
					continue;

				if (r[recordProperty] is Guid id && result.TryGetValue(id, out var records))
					r[$"${relation.Name}"] = records;
				else
					r[$"${relation.Name}"] = new List<EntityRecord>();
			}
		}

		private static Guid[] GetIds(IEnumerable<EntityRecord> records, string property)
		{
			return records.Select(r => r[property] as Guid?)
				.Where(id => id.HasValue)
				.Select(id => id!.Value)
				.Distinct()
				.ToArray();
		}

		private static (string RecordProperty, string NextIdProperty, string NextEntityName) GetJoinInfo(EntityRelation relation, string entityName)
		{
			string recordProperty;
			string nextIdProperty;
			string nextEntityName;

			if (relation.OriginEntityName == entityName)
			{
				recordProperty = relation.OriginFieldName;
				nextIdProperty = relation.TargetFieldName;
				nextEntityName = relation.TargetEntityName;
			}
			else
			{
				recordProperty = relation.TargetEntityName;
				nextIdProperty = relation.OriginFieldName;
				nextEntityName = relation.OriginEntityName;
			}

			return (recordProperty, nextIdProperty, nextEntityName);
		}

		private static List<EntityRecord> FindManyByQuery(RecordManager recMan, string entity, QueryObject query, string select = "*")
		{
			var response = recMan.Find(new EntityQuery(entity, select, query));

			return response.Object?.Data ?? [];
		}

		private static Dictionary<Guid, EntityRecord?> FindMany(RecordManager recMan, string entity, string fieldName, string select = "*", params Guid[] args)
		{
			if (args.Length == 0)
				return [];


			var subQuery = Enumerable.Select(args, id => new QueryObject() { QueryType = QueryType.EQ, FieldName = fieldName, FieldValue = id })
				.ToList();

			var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
			{
				QueryType = QueryType.OR,
				SubQueries = subQuery
			};

			var queryResponse = recMan.Find(new EntityQuery(entity, select, query));

			var result = new Dictionary<Guid, EntityRecord?>(args.Length);
			foreach (var key in args)
				result[key] = null;

			if (queryResponse.Object?.Data != null)
			{
				foreach (var obj in queryResponse.Object.Data.Where(r => r.Properties.ContainsKey(fieldName)))
					result[(Guid)obj[fieldName]] = obj;
			}

			return result;
		}
	}
#nullable restore
}
