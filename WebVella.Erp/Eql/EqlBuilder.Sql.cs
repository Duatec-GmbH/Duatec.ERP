using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Fts;

namespace WebVella.Erp.Eql
{
	public partial class EqlBuilder
	{
		private EntityManager entMan;
		private EntityRelationManager relMan ;

		private Entity fromEntity = null;

		#region <--- constants --->
		const string RECORD_COLLECTION_PREFIX = "rec_";
		const string BEGIN_OUTER_SELECT = @"SELECT row_to_json( X ) FROM (";
		const string BEGIN_SELECT = @"SELECT ";
		const string REGULAR_FIELD_SELECT = @" {1}.""{0}"" AS ""{0}"",";
		const string GEOGRAPHY_FIELD_SELECT = @" ST_As{2}({1}.""{0}"") AS ""{0}"",";
		const string END_SELECT = @"";
		const string BEGIN_SELECT_DISTINCT = @"SELECT DISTINCT ";
		const string END_OUTER_SELECT = @") X";
		const string FROM = @"FROM {0}";

		const string OTM_RELATION_TEMPLATE =
@"$$$TABS$$$(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
$$$TABS$$$ SELECT {1}
$$$TABS$$$ FROM {2} {3}
$$$TABS$$$ WHERE {3}.{4} = {5}.{6} ) d )::jsonb AS ""{0}"",";

		const string MTM_RELATION_TEMPLATE =
@"$$$TABS$$$(SELECT  COALESCE(  array_to_json(array_agg( row_to_json(d))), '[]') FROM (
$$$TABS$$$ SELECT {1}
$$$TABS$$$ FROM {2} {3}
$$$TABS$$$ LEFT JOIN  {4} {5} ON {6}.{7} = {8}.{9}
$$$TABS$$$ WHERE {10}.{11} = {12}.{13} )d  )::jsonb AS ""{0}"",";

		const string FILTER_JOIN = @"
LEFT OUTER JOIN  {0} {1} ON {2}.{3} = {4}.{5}";

		#endregion

		private class SelectInfoWrapper
		{
			public Entity Entity { get; set; }

			public List<Field> Fields { get; private set; } = new List<Field>();

			public EntityRelation Relation { get; set; } = null;

			public EqlRelationInfo RelationInfo { get; set; } = null;

			public List<SelectInfoWrapper> Children { get; private set; } = new List<SelectInfoWrapper>();

			public SelectInfoWrapper Parent { get; set; } = null;
		}

		private void AddOrderRelations(Entity fromEntity, EqlOrderByNode orderByNode, List<EqlRelationFieldNode> relations)
		{
			var relationFields = orderByNode?.Fields
				.Where(f => f.FieldName.StartsWith('$'));

			if (relationFields == null || !relationFields.Any())
				return;

			var allRelations = relMan.Read().Object;
			var allEntities = entMan.ReadEntities().Object;

			foreach (var field in relationFields)
			{
				var value = field.FieldName;
				var idx = value.LastIndexOf('.');

				var identifier = value[(idx + 1)..];

				var relationNames = value[..idx].Split('.')
					.Select(s => s.TrimStart('$'));

				var entity = fromEntity;
				var relationNode = new EqlRelationFieldNode() { FieldName = identifier };

				foreach(var relationName in relationNames)
				{
					var relation = allRelations.FirstOrDefault(r => relationName == r.Name && r.TargetEntityId == entity.Id)
						?? throw new EqlException(new EqlError() { Message = $"Relation '{relationName}' does not exist or is invalid within ORDER clause" });

					relationNode.Relations.Add(new EqlRelationInfo() { Name = relationName, Direction = EqlRelationDirectionType.TargetOrigin });
					entity = allEntities.First(e => e.Id == relation.OriginEntityId);
				}

				relations.Add(relationNode);
			}
		}

		private string BuildSql(EqlAbstractTree tree, List<EqlError> errors, List<EqlFieldMeta> fieldsMeta, EqlSettings settings, out Entity fromEntity )
		{
			errors ??= [];

			var selectNode = (EqlSelectNode)tree.RootNode;
			var entities = entMan.ReadEntities().Object;
			fromEntity = entities.SingleOrDefault(x => x.Name == selectNode.From.EntityName);
			this.fromEntity = fromEntity;
			if (fromEntity == null)
			{
				errors.Add(new EqlError { Message = $"Entity '{selectNode.From.EntityName}' specified in FROM clause not found." });
				return string.Empty;
			}

			var rootInfo = ProcessEntity(fromEntity, selectNode.Fields);
			var sql = new StringBuilder();
			sql.AppendLine(BEGIN_OUTER_SELECT);
			if(settings.Distinct )
				sql.AppendLine(BEGIN_SELECT_DISTINCT);
			else
				sql.AppendLine(BEGIN_SELECT);
			var fieldsSql = BuildFieldsSql(rootInfo, 1, fieldsMeta);
			sql.Append(fieldsSql);
			sql.AppendLine(END_SELECT);
			sql.AppendLine(string.Format(FROM, $"{RECORD_COLLECTION_PREFIX}{rootInfo.Entity.Name}"));

			//WHERE
			var relations = new List<EqlRelationFieldNode>();
			var whereSql = string.Empty;

			AddOrderRelations(fromEntity, selectNode.OrderBy, relations);

			if (selectNode.Where != null && selectNode.Where.RootExpressionNode != null)
				whereSql = ProcessExpressionNode(selectNode.Where.RootExpressionNode, fromEntity.Name, relations);

			if (relations.Count > 0)
				sql.AppendLine(ProcessJoins(relations, fromEntity));

			if (!string.IsNullOrWhiteSpace(whereSql))
				sql.AppendLine("WHERE " + whereSql);


			//ORDER BY
			if (selectNode.OrderBy != null && selectNode.OrderBy.Fields.Count > 0)
			{
				sql.Append("ORDER BY ");
				foreach (var field in selectNode.OrderBy.Fields)
				{
					if (field.FieldName.StartsWith('$'))
					{
						var pointIdx = field.FieldName.LastIndexOf('.');

						var fieldName = field.FieldName[(pointIdx + 1)..];
						var relationNames = field.FieldName[..pointIdx].Split('.')
							.Select(s => s.TrimStart('$'))
							.ToArray();

						var orderEntity = fromEntity;
						foreach(var relName in relationNames)
						{
							var rel = relMan.Read(relName).Object
								?? throw new EqlException($"Relation '{relName}' not found.");

							orderEntity = entities.FirstOrDefault(ent => ent.Id == rel.OriginEntityId)
								?? throw new EqlException($"Origin entity of relation '{relName}' not found");
						}

						if (!orderEntity.Fields.Exists(f => f.Name == fieldName))
							throw new EqlException($"Entity '{orderEntity.Name}' has no field with name '{fieldName}'");

						sql.Append($"{relationNames[^1]}_tar_org.\"{fieldName}\" {field.Direction}");
					}
					else
					{
						if (!fromEntity.Fields.Any(x => x.Name == field.FieldName))
						{
							errors.Add(new EqlError { Message = $"Order field '{field.FieldName}' is not found in entity '{fromEntity.Name}'" });
							return string.Empty;
						}
						sql.Append(RECORD_COLLECTION_PREFIX + fromEntity.Name + ".\"" + field.FieldName + "\"" + " " + field.Direction);

					}
					if (selectNode.OrderBy.Fields.Last() != field)
						sql.Append(" , ");
				}
				sql.AppendLine();
			}

			//PAGING
			int? pageSize = (selectNode.PageSize != null && selectNode.PageSize.Number.HasValue) ? (int)selectNode.PageSize.Number : (int?)null;
			int? page = (selectNode.Page != null && selectNode.Page.Number.HasValue) ? (int)selectNode.Page.Number : (int?)null;
			if ((page != null && pageSize == null) || (page == null && pageSize != null))
			{
				errors.Add(new EqlError { Message = $"When PAGE or PAGESIZE commands are used, both of them should be used together." });
				return string.Empty;
			}
			else if (page != null && pageSize != null)
			{
				if (page.Value <= 0)
				{
					errors.Add(new EqlError { Message = $"PAGE should be positive number" });
					return string.Empty;
				}
				if (pageSize.Value <= 0)
				{
					errors.Add(new EqlError { Message = $"PAGESIZE should be positive number" });
					return string.Empty;
				}

				sql.AppendLine($"LIMIT {pageSize.Value}");
				sql.AppendLine($"OFFSET {(page.Value - 1) * pageSize.Value}");
			}

			sql.AppendLine(END_OUTER_SELECT);

			return sql.ToString();
		}

		private SelectInfoWrapper ProcessEntity(Entity entity, List<EqlFieldNode> fieldNodes)
		{
			SelectInfoWrapper info = new SelectInfoWrapper();
			info.Entity = entity;

			foreach (var fieldNode in fieldNodes)
			{
				switch (fieldNode.Type)
				{
					case EqlNodeType.Field:
						{
							var field = entity.Fields.SingleOrDefault(x => x.Name == fieldNode.FieldName);
							if (field == null)
								throw new EqlException($"Field '{fieldNode.FieldName}' not found.");

							if (!info.Fields.Any(f => f.Id == field.Id))
								info.Fields.Add(field);
						}
						break;
					case EqlNodeType.WildcardField:
						{
							foreach (var field in entity.Fields)
							{
								if (!info.Fields.Any(f => f.Id == field.Id))
									info.Fields.Add(field);
							}
						}
						break;
					case EqlNodeType.RelationField:
					case EqlNodeType.RelationWildcardField:
						ProcessRelationField(info, (EqlRelationFieldNode)fieldNode);
						break;
				}
			}

			return info;
		}

		private void ProcessRelationField(SelectInfoWrapper parent, EqlRelationFieldNode relationFieldNode)
		{
			var relations = relMan.Read().Object;
			var entities = entMan.ReadEntities().Object;
			SelectInfoWrapper parentInfo = parent;

			var relCount = relationFieldNode.Relations.Count;
			for (int i = 0; i < relCount; i++)
			{
				var relInfo = relationFieldNode.Relations[i];
				var relation = relations.SingleOrDefault(r => r.Name == relInfo.Name)
					?? throw new EqlException($"Relation '{relInfo.Name}' not found.");

				bool isLast = (i == (relCount - 1));
				if (isLast)
				{
					// if relation origin entity is parent entity
					// then we use target entity as next to go
					// else we use origin as next to go
					// direction doesn't matter here, it will be taken in consideration when sql is generated
					Entity currentEntity = null;
					if (relation.OriginEntityId == parentInfo.Entity.Id)
						currentEntity = entities.Single(x => x.Id == relation.TargetEntityId);
					else
						currentEntity = entities.Single(x => x.Id == relation.OriginEntityId);

					SelectInfoWrapper currentInfo = parentInfo.Children.SingleOrDefault(x => x.Relation.Id == relation.Id);
					//if the relation is not processed yet, we create and add new object,
					//otherwise we ignore, because the object exists and id field is already inside
					if (currentInfo == null)
					{
						currentInfo = new SelectInfoWrapper();
						currentInfo.Entity = currentEntity;
						currentInfo.Relation = relation;
						currentInfo.RelationInfo = relInfo;
						currentInfo.Fields.Add(currentEntity.Fields.Single(x => x.Name == "id"));
						currentInfo.Parent = parentInfo;
						parentInfo.Children.Add(currentInfo);
						parentInfo = currentInfo;
					}

					if (relationFieldNode.Type == EqlNodeType.RelationField)
					{
						var field = currentEntity.Fields.SingleOrDefault(x => x.Name == relationFieldNode.FieldName);
						if (field == null)
							throw new EqlException($"Field '{relationFieldNode.FieldName}' not found in entity '{currentEntity.Name}' for relation '{relInfo.Name}'.");

						if (!currentInfo.Fields.Any(x => x.Id == field.Id))
							currentInfo.Fields.Add(field);

						//always add id field if not in the list
						if (!currentInfo.Fields.Any(x => x.Name == "id"))
							currentInfo.Fields.Add(currentEntity.Fields.Single(x => x.Name == "id"));
					}
					else //wildcard field
					{
						//add all fields, not already added
						foreach (var field in currentEntity.Fields)
						{
							if (!currentInfo.Fields.Any(x => x.Id == field.Id))
								currentInfo.Fields.Add(field);
						}
					}
				}
				else
				{
					// if relation origin entity is parent entity
					// then we use target entity as next to go
					// else we use origin as next to go
					// direction doesn't matter here, it will be taken in consideration when sql is generated
					Entity currentEntity = null;
					if (relation.OriginEntityId == parentInfo.Entity.Id)
						currentEntity = entities.Single(x => x.Id == relation.TargetEntityId);
					else
						currentEntity = entities.Single(x => x.Id == relation.OriginEntityId);

					SelectInfoWrapper currentInfo = parentInfo.Children.SingleOrDefault(x => x.Relation.Id == relation.Id);
					//if the relation is not processed yet, we create and add new object,
					//otherwise we ignore, because the object exists and id field is already inside
					if (currentInfo == null)
					{
						currentInfo = new SelectInfoWrapper();
						currentInfo.Entity = currentEntity;
						currentInfo.Relation = relation;
						currentInfo.RelationInfo = relInfo;
						currentInfo.Fields.Add(currentEntity.Fields.Single(x => x.Name == "id"));
						currentInfo.Parent = parentInfo;
						parentInfo.Children.Add(currentInfo);
						parentInfo = currentInfo;
					}
					parentInfo = currentInfo;
				}
			}
		}

		private string BuildFieldsSql(SelectInfoWrapper rootInfo, int depth = 1, List<EqlFieldMeta> fieldsMeta = null)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var field in rootInfo.Fields)
			{
				if (fieldsMeta != null)
					fieldsMeta.Add(new EqlFieldMeta { Name = field.Name, Field = field });
				if (rootInfo.Relation != null)
					AppendToStringBuilder(sb, depth, true, string.Format(REGULAR_FIELD_SELECT, field.Name, rootInfo.Relation.Name));
				else if (field.GetFieldType() == FieldType.GeographyField)
				{
					// 628426 6 Sep 2020, Geography Support
					// returns either GeoJSON or Text
					// intended to generate ST_AsGeoJson(...) or ST_AsText(...)
					string format = (field as GeographyField).Format.ToString();

					AppendToStringBuilder(sb, depth, true, string.Format(GEOGRAPHY_FIELD_SELECT, field.Name, $"{RECORD_COLLECTION_PREFIX}{rootInfo.Entity.Name}", format));
				}
				else
					AppendToStringBuilder(sb, depth, true, string.Format(REGULAR_FIELD_SELECT, field.Name, $"{RECORD_COLLECTION_PREFIX}{rootInfo.Entity.Name}"));
			}

			//append total count column
			if (depth == 1)
			{
				if(Settings.IncludeTotal)
					AppendToStringBuilder(sb, depth, true, " COUNT(*) OVER() AS ___total_count___,");
			}

			bool trimed = false;
			if (rootInfo.Children.Count == 0)
			{
				trimed = true;
				sb.Remove(sb.Length - (Environment.NewLine.Length + 1), Environment.NewLine.Length + 1); //remove newline and comma;
			}

			foreach (var info in rootInfo.Children)
			{
				List<EqlFieldMeta> childFieldsMeta = null;
				if (fieldsMeta != null)
					childFieldsMeta = new List<EqlFieldMeta>();

				var fieldsSql = Environment.NewLine + BuildFieldsSql(info, depth + 1, childFieldsMeta);

				AppendToStringBuilder(sb, depth, true, $"------->: ${info.Relation.Name}");

				if (fieldsMeta != null)
				{
					var meta = new EqlFieldMeta { Name = $"${info.Relation.Name}", Relation = info.Relation };
					meta.Children.AddRange(childFieldsMeta);
					fieldsMeta.Add(meta);
				}

				if (info.Relation.RelationType == EntityRelationType.OneToOne)
				{
					if (info.Relation.OriginEntityId == info.Entity.Id)
					{
						string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}";
						if (info.Parent != null && info.Parent.Relation != null)
							alias = info.Parent.Relation.Name;


						AppendToStringBuilder(sb, depth, true, string.Format(OTM_RELATION_TEMPLATE,
							$"${info.Relation.Name}",
							fieldsSql.ToString(),
							$"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}",
							info.Relation.Name,
							info.Relation.TargetFieldName,
							alias,
							info.Relation.OriginFieldName));
					}
					else //when the relation is target -> origin, we have to query origin entity
					{
						string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}";
						if (info.Parent != null && info.Parent.Relation != null)
							alias = info.Parent.Relation.Name;

						AppendToStringBuilder(sb, depth, true, string.Format(OTM_RELATION_TEMPLATE,
								$"${info.Relation.Name}",
								fieldsSql.ToString(),
								$"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}",
								info.Relation.Name,
								info.Relation.OriginFieldName,
								alias,
								info.Relation.TargetFieldName));
					}
				}
				else if (info.Relation.RelationType == EntityRelationType.OneToMany)
				{
					if (info.Relation.OriginEntityId != info.Relation.TargetEntityId)
					{
						if (info.Relation.OriginEntityId != info.Entity.Id)
						{
							string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}";
							if (info.Parent != null && info.Parent.Relation != null)
								alias = info.Parent.Relation.Name;

							AppendToStringBuilder(sb, depth, true, string.Format(OTM_RELATION_TEMPLATE,
								$"${info.Relation.Name}",
								fieldsSql.ToString(),
								$"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}",
								info.Relation.Name,
								info.Relation.TargetFieldName,
								alias,
								info.Relation.OriginFieldName));
						}
						else //when the relation is target -> origin, we have to query origin entity
						{
							string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}";
							if (info.Parent != null && info.Parent.Relation != null)
								alias = info.Parent.Relation.Name;

							AppendToStringBuilder(sb, depth, true, string.Format(OTM_RELATION_TEMPLATE,
									$"${info.Relation.Name}",
									fieldsSql.ToString(),
									$"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}",
									info.Relation.Name,
									info.Relation.OriginFieldName,
									alias,
									info.Relation.TargetFieldName));
						}
					}
					else
					{
						if (info.RelationInfo.Direction == EqlRelationDirectionType.OriginTarget)
						{
							string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}";
							if (info.Parent != null && info.Parent.Relation != null)
								alias = info.Parent.Relation.Name;

							AppendToStringBuilder(sb, depth, true, string.Format(OTM_RELATION_TEMPLATE,
									$"${info.Relation.Name}",
									fieldsSql.ToString(),
									$"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}",
									info.Relation.Name,
									info.Relation.TargetFieldName,
									alias,
									info.Relation.OriginFieldName));
						}
						else
						{
							string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}";
							if (info.Parent != null && info.Parent.Relation != null)
								alias = info.Parent.Relation.Name;

							AppendToStringBuilder(sb, depth, true, string.Format(OTM_RELATION_TEMPLATE,
										$"${info.Relation.Name}",
										fieldsSql.ToString(),
										$"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}",
										info.Relation.Name,
										info.Relation.OriginFieldName,
										alias,
										info.Relation.TargetFieldName));
						}
					}
				}
				else if (info.Relation.RelationType == EntityRelationType.ManyToMany)
				{
					string relationTable = "rel_" + info.Relation.Name;
					string targetJoinAlias = info.Relation.Name + "_target";
					string originJoinAlias = info.Relation.Name + "_origin";

					var direction = info.RelationInfo.Direction;
					if(info.Relation.OriginEntityId != info.Relation.TargetEntityId && info.Parent != null && info.Parent.Entity != null)
					{
						if (info.Parent.Entity.Id == info.Relation.OriginEntityId)
							direction = EqlRelationDirectionType.OriginTarget;
						else
							direction = EqlRelationDirectionType.TargetOrigin;
					}

					if (direction == EqlRelationDirectionType.TargetOrigin)
					{
						string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}";
						if (info.Parent != null && info.Parent.Relation != null)
							alias = info.Parent.Relation.Name;

						AppendToStringBuilder(sb, depth, true, string.Format(MTM_RELATION_TEMPLATE,
									$"${info.Relation.Name}",
									fieldsSql.ToString(),
									$"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}",
									info.Relation.Name,
									relationTable,
									targetJoinAlias,
									targetJoinAlias,
									"target_id",
									alias,
									info.Relation.TargetFieldName,
									info.Relation.Name,
									info.Relation.OriginFieldName,
									targetJoinAlias,
									"origin_id"));
					}
					else
					{
						string alias = $"{RECORD_COLLECTION_PREFIX}{info.Relation.OriginEntityName}";
						if (info.Parent != null && info.Parent.Relation != null)
							alias = info.Parent.Relation.Name;

						AppendToStringBuilder(sb, depth, true, string.Format(MTM_RELATION_TEMPLATE,
									$"${info.Relation.Name}",
									fieldsSql.ToString(),
									$"{RECORD_COLLECTION_PREFIX}{info.Relation.TargetEntityName}",
									info.Relation.Name,
									relationTable,
									originJoinAlias,
									originJoinAlias,
									"origin_id",
									alias,
									info.Relation.OriginFieldName,
									info.Relation.Name,
									info.Relation.TargetFieldName,
									originJoinAlias,
									"target_id"));
					}
				}

				if (info == rootInfo.Children.Last())
				{
					if (!trimed)
						sb.Remove(sb.Length - (Environment.NewLine.Length + 1), Environment.NewLine.Length + 1); //remove newline and comma;
				}


				if(!sb.ToString().EndsWith(Environment.NewLine))
					AppendToStringBuilder(sb, depth, true, "");

				AppendToStringBuilder(sb, depth, true, $"-------< ${info.Relation.Name}");
			}


			return sb.ToString();
		}

		private void AppendToStringBuilder(StringBuilder sb, int depth, bool line, string text)
		{
			var tabs = "";
			for (int i = 0; i < depth; i++)
				tabs = tabs + "\t";

			if (text.Contains("$$$TABS$$$"))
			{
				var processedText = text.Replace("$$$TABS$$$", tabs);
				if (line)
					sb.AppendLine(processedText);
				else
					sb.Append(processedText);

			}
			else
			{
				sb.Append(tabs);
				if (line)
					sb.AppendLine(text);
				else
					sb.Append(text);
			}
		}

		private string ProcessExpressionOperandNode(EqlNode operandNode, string entityName, List<EqlRelationFieldNode> relationsUsedInWhere, out Field field)
		{
			field = null;
			string operandString = string.Empty;
			switch (operandNode.Type)
			{
				case EqlNodeType.Field:
					{
						var entities = entMan.ReadEntities().Object;
						var fieldName = ((EqlFieldNode)operandNode).FieldName;

						Entity entity = entities.Single(x => x.Name == entityName);
						field = entity.Fields.SingleOrDefault(x => x.Name == ((EqlFieldNode)operandNode).FieldName);
						if (field == null)
							throw new EqlException($"WHERE CLAUSE: Field '{fieldName}' not found in entity {entityName}");

						operandString = RECORD_COLLECTION_PREFIX + entityName + ".\"" + fieldName + "\"";
					}
					break;
				case EqlNodeType.BinaryExpression:
					operandString = ProcessExpressionNode((EqlBinaryExpressionNode)operandNode, entityName, relationsUsedInWhere);
					break;
				case EqlNodeType.ArgumentValue:
					operandString = $"@{((EqlArgumentValueNode)operandNode).ArgumentName}";
					if (!ExpectedParameters.Contains(operandString))
						ExpectedParameters.Add(operandString);
					break;
				case EqlNodeType.NumberValue:
					operandString = $"'{((EqlNumberValueNode)operandNode).Number.ToString()}'";
					break;
				case EqlNodeType.TextValue:
					operandString = $"'{((EqlTextValueNode)operandNode).Text}'";
					break;
				case EqlNodeType.Keyword:
					if (((EqlKeywordNode)operandNode).Keyword == "null")
						operandString = $"NULL";
					else if (((EqlKeywordNode)operandNode).Keyword == "true")
						operandString = $"TRUE";
					else if (((EqlKeywordNode)operandNode).Keyword == "false")
						operandString = $"FALSE";
					else
						throw new EqlException($"WHERE CLAUSE: Unknown term '{((EqlKeywordNode)operandNode).Keyword}' used as keyword.");
					break;
				case EqlNodeType.RelationField:
					{
						var relON = (EqlRelationFieldNode)operandNode;
						var entities = entMan.ReadEntities().Object;
						var relations = relMan.Read().Object;

						var suffix = string.Empty;
						var entity = fromEntity;

						for (int i = 0; i < relON.Relations.Count; i++)
						{
							if (i > 0 && suffix != "_tar_org")
								throw new EqlException($"WHERE CLAUSE: Invalid nested relation '{string.Join('.', relON.Relations.Select(r => '$' + r.Name))}'");

							var rel = relON.Relations[i];

							if (!relationsUsedInWhere.Any(x => x.Relations.Any(y => y.Name == rel.Name)))
								relationsUsedInWhere.Add(relON);

							var relation = relations.SingleOrDefault(x => x.Name == rel.Name)
								?? throw new EqlException($"WHERE CLAUSE: Relation '{rel.Name}' not found.");

							var originEntity = entities.Single(x => x.Id == relation.OriginEntityId);
							var targetEntity = entities.Single(x => x.Id == relation.TargetEntityId);
							var relatedEntity = targetEntity;
							suffix = "_org_tar";

							if (relatedEntity.Id != originEntity.Id)
							{
								suffix = "_tar_org";
								relatedEntity = originEntity;
							}

							if(i == relON.Relations.Count - 1)
							{
								field = relatedEntity.Fields.SingleOrDefault(x => x.Name == relON.FieldName);
								if (field == null)
									throw new EqlException($"WHERE CLAUSE: Field '{relON.FieldName}' not found in entity '{relatedEntity.Name}' from '{relON.Relations[0].Name}'.");
								operandString = rel.Name + suffix + ".\"" + relON.FieldName + "\"";
							}

							entity = relatedEntity;
						}

					}
					break;
			}
			return operandString;
		}

		private string ProcessExpressionNode(EqlBinaryExpressionNode expNode, string entityName, List<EqlRelationFieldNode> relationsUsedInWhere)
		{
			if (expNode == null)
				return null;

			Field firstOperandField, secondOperandField;
			string firstOperandString = ProcessExpressionOperandNode(expNode.FirstOperand, entityName, relationsUsedInWhere, out firstOperandField);
			string secondOperandString = ProcessExpressionOperandNode(expNode.SecondOperand, entityName, relationsUsedInWhere, out secondOperandField);

			if (!( firstOperandString.StartsWith(" (") || firstOperandString.StartsWith(" to_tsvector") || firstOperandString.StartsWith("@") ) && firstOperandField == null)
				throw new EqlException($"WHERE: First operand in where expressions should always be an entity field name . '{firstOperandString}' is not a field name.");

			if ((firstOperandString == "NULL" || secondOperandString == "NULL") && (expNode.Operator != "=" && expNode.Operator != "<>" && expNode.Operator != "!="))
				throw new EqlException($"WHERE: NULL can be used only with '=' and '<>' comparison.");

			switch (expNode.Operator)
			{
				case "=":
					if (firstOperandString == "NULL") //keyword NULL
						return $" ( {secondOperandString} IS NULL ) ";
					if (secondOperandString == "NULL") //keyword NULL
						return $" ( {firstOperandString} IS NULL ) ";

					if (firstOperandString.StartsWith("@")) //parameter
					{
						string paramName = firstOperandString;
						var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
						if (param == null)
							throw new EqlException($"WHERE: Parameter '{paramName}' not found.");

						if (param.Value == null || param.Value == DBNull.Value)
							return $" ( {secondOperandString} IS NULL ) ";
					}
					if (secondOperandString.StartsWith("@")) //parameter
					{
						string paramName = secondOperandString;
						var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
						if (param == null)
							throw new EqlException($"WHERE: Parameter '{paramName}' not found.");

						if (param.Value == null || param.Value == DBNull.Value)
							return $" ( {firstOperandString} IS NULL ) ";
					}
					return $" ( {firstOperandString} {expNode.Operator} {secondOperandString} ) ";
				case "!=":
				case "<>":
					if (secondOperandString == "NULL") //keyword NULL
						return $" ( {firstOperandString} IS NOT NULL ) ";
					if (secondOperandString.StartsWith("@")) //parameter
					{
						string paramName = secondOperandString;
						var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
						if (param == null)
							throw new EqlException($"WHERE: Parameter '{paramName}' not found.");

						if (param.Value == null || param.Value == DBNull.Value)
							return $" ( {firstOperandString} IS NOT NULL ) ";
					}
					return $" ( {firstOperandString} {expNode.Operator} {secondOperandString} ) ";
				case ">":
				case "<":
				case ">=":
				case "<=":
				case "AND":
				case "OR":
				case "~":
				case "~*":
				case "!~":
				case "!~*":
					return $" ( {firstOperandString} {expNode.Operator} {secondOperandString} ) ";
				case "CONTAINS":
					if (firstOperandField != null)
					{
						if (firstOperandField.GetFieldType() == FieldType.MultiSelectField)
						{
							var result =  $" ( {firstOperandString}  @>  {secondOperandString} ) ";
							string paramName = secondOperandString;
							var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
							if (param != null && param.Value != null )
							{
								//if parameter is not array or enumerable, we create new parameter 
								//with array type
								if (!typeof(IEnumerable).IsAssignableFrom(param.Value.GetType()) || param.Value.GetType() == typeof(string))
								{
									string newParamName = $"{secondOperandString}_converted_to_array";
									var newParamValue = new List<string> { param.Value.ToString() };
									Parameters.Add(new EqlParameter(newParamName, newParamValue));
									result = $" ( {firstOperandString}  @>  {newParamName} ) ";
								}
							}
							return result;
						}
						else
						{
							string paramName = secondOperandString;
							var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
							if (param == null) throw new EqlException($"WHERE: Parameter '{paramName}' not found.");
							//param.Value = "%" + param.Value + "%";

							return $" ( {firstOperandString}  ILIKE  CONCAT ( '%' , {secondOperandString} , '%' ) )";
						}
					}
					else
						throw new EqlException($"WHERE: CONTAINS first operand should be a field name.");
				case "STARTSWITH":
					if (firstOperandField != null)
					{
						string paramName = secondOperandString;
						var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
						if (param == null) throw new EqlException($"WHERE: Parameter '{paramName}' not found.");
						//param.Value = param.Value + "%";

						return $" ( {firstOperandString}  ILIKE CONCAT ( {secondOperandString},'%'  ) ) ";
					}
					else
						throw new EqlException($"WHERE: STARTSWITH first operand should be a field name.");

				case "@@":
					if (firstOperandField != null)
					{
						FtsAnalyzer ftsAnalyzer = new FtsAnalyzer();

						if (secondOperandString.StartsWith("@")) //parameter
						{
							string paramName = secondOperandString;
							var param = Parameters.SingleOrDefault(x => x.ParameterName == paramName);
							if (param == null)
								throw new EqlException($"WHERE: Parameter '{paramName}' not found.");

							string text = (string)param.Value;

							bool singleWord = true;
							if (!string.IsNullOrWhiteSpace(text))
							{
								string analizedText = ftsAnalyzer.ProcessText(text);
								param.Value = analizedText;
								singleWord = analizedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() == 1;
							}
							else
								singleWord = false; //in case of empty string, we use plainto_tsquery

							//coalesce(string_agg(tag.name, ' '))
							if (singleWord)
							{
								param.Value = param.Value + ":*"; //search for all lexemes starting with this word
								return $" to_tsvector( 'simple', {firstOperandString} ) @@ to_tsquery( 'simple', {paramName} ) ";
							}
							else
								return $" to_tsvector( 'simple', {firstOperandString} ) @@ plainto_tsquery( 'simple', COALESCE( {paramName}, ' ') ) ";

						}
						else if (secondOperandString.StartsWith("'")) //text
						{
							var text = secondOperandString.Substring(1);
							text = text.Substring(0, text.Length - 1);

							bool singleWord = true;
							if (!string.IsNullOrWhiteSpace(text))
							{
								text = ftsAnalyzer.ProcessText(text);
								singleWord = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() == 1;
							}
							else
								singleWord = false; //in case of empty string, we use plainto_tsquery

							if (singleWord)
							{
								text = text + ":*"; //search for all lexemes starting with this word
								return $" to_tsvector( 'simple', {firstOperandString} ) @@ to_tsquery( 'simple', '{text}') ";
							}
							else
								return $" to_tsvector( 'simple', {firstOperandString} ) @@ plainto_tsquery( 'simple', '{text}') ";
						}
					}
					else
						throw new EqlException($"WHERE: @@ operator first operand should be a field name.");
					break;
				default:
					throw new EqlException($"WHERE: '{expNode.Operator}' unknown operator");
			}

			return string.Empty;
		}

		private string ProcessJoins(List<EqlRelationFieldNode> relationsUsedInWhere, Entity fromEntity)
		{
			string relationJoinSql = string.Empty;
			List<string> aliases = new List<string>();
			var allRelations = relMan.Read().Object;
			var allEntities = entMan.ReadEntities().Object;

			foreach (var relNode in relationsUsedInWhere)
			{
				var suffix = string.Empty;
				var lastAlias = string.Empty;

				for(var i = 0; i < relNode.Relations.Count; i++)
				{
					if (i > 0 && suffix != "_tar_org")
						throw new EqlException(new EqlError { Message = "Invalid nested relation" });

					var relationInfo = relNode.Relations[i];
					var relation = allRelations.SingleOrDefault(x => x.Name == relationInfo.Name)
						?? throw new EqlException($"WHERE: Relation with name '{relationInfo.Name}' is not found.");

					suffix = "_org_tar";
					//if (relNode.Relations[0].Direction == EqlRelationDirectionType.TargetOrigin)
					if (relation.OriginEntityId != fromEntity.Id)
						suffix = "_tar_org";

					var relationAlias = relation.Name + suffix;

					if (aliases.Contains(relationAlias))
					{
						lastAlias = relationAlias;
						continue;
					}

					aliases.Add(relationAlias);

					if (relation.RelationType == EntityRelationType.OneToOne)
					{
						//when the relation is origin -> target entity
						if (relation.OriginEntityId == fromEntity.Id)
						{
							relationJoinSql += string.Format(FILTER_JOIN,
								$"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}",
								relationAlias,
								relationAlias,
								relation.TargetFieldName,
								$"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
								relation.OriginFieldName);
						}
						else //when the relation is target -> origin, we have to query origin entity
						{
							if (i > 0)
							{
								relationJoinSql += string.Format(FILTER_JOIN,
								   $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
								   relationAlias,
								   relationAlias,
								   relation.OriginFieldName,
								   $"{relation.TargetEntityName}_tar_org",
								   relation.TargetFieldName);
							}
							else
							{
								relationJoinSql += string.Format(FILTER_JOIN,
								   $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
								   relationAlias,
								   relationAlias,
								   relation.OriginFieldName,
								   $"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}",
								   relation.TargetFieldName);
							}
						}
					}
					else if (relation.RelationType == EntityRelationType.OneToMany)
					{
						//when origin and target entity are different, then direction don't matter
						if (relation.OriginEntityId != relation.TargetEntityId)
						{
							//when the relation is origin -> target entity
							if (relation.OriginEntityId == fromEntity.Id)
							{
								relationJoinSql += string.Format(FILTER_JOIN,
									$"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}",
									relationAlias,
									relationAlias,
									relation.TargetFieldName,
									 $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
									relation.OriginFieldName);
							}
							else //when the relation is target -> origin, we have to query origin entity
							{
								if(i > 0)
								{
									relationJoinSql += string.Format(FILTER_JOIN,
										 $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
										relationAlias,
										relationAlias,
										relation.OriginFieldName,
										lastAlias,
										relation.TargetFieldName);
								}
								else
								{
									relationJoinSql += string.Format(FILTER_JOIN,
										 $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
										relationAlias,
										relationAlias,
										relation.OriginFieldName,
										$"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}",
										relation.TargetFieldName);
								}
							}
						}
						else //when the origin entity is same as target entity direction matters
						{
							if (relationInfo.Direction == EqlRelationDirectionType.TargetOrigin)
							{
								relationJoinSql = string.Format(FILTER_JOIN,
									$"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
								   relationAlias,
								   relationAlias,
								   relation.OriginFieldName,
								   $"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}",
								   relation.TargetFieldName);
							}
							else
							{
								relationJoinSql += string.Format(FILTER_JOIN,
									$"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}",
									relationAlias,
									relationAlias,
									relation.TargetFieldName,
									 $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}",
									relation.OriginFieldName);
							}
						}
					}
					else if (relation.RelationType == EntityRelationType.ManyToMany)
					{
						if (i < relNode.Relations.Count - 1)
							throw new EqlException(new EqlError { Message = "Accessing many to many relation with relation is not supported now" });

						string relationTable = "rel_" + relation.Name;

						string targetJoinTable = $"{RECORD_COLLECTION_PREFIX}{relation.TargetEntityName}";
						string originJoinTable = $"{RECORD_COLLECTION_PREFIX}{relation.OriginEntityName}";

						//if target is entity we query
						if (fromEntity.Id == relation.TargetEntityId)
						{
							string targetJoinAlias = relation.Name + "_target";
							string originJoinAlias = relationAlias;

							relationJoinSql += string.Format(FILTER_JOIN,
									 /*LEFT OUTER JOIN*/ relationTable, /* */ targetJoinAlias /*ON*/,
									 targetJoinAlias, /*.*/ "target_id", /* =  */
									 targetJoinTable, /*.*/ relation.TargetFieldName);

							relationJoinSql += Environment.NewLine + string.Format(FILTER_JOIN,
									/*LEFT OUTER JOIN*/ originJoinTable, /* */ originJoinAlias /*ON*/,
									targetJoinAlias, /*.*/ "origin_id", /* =  */
									originJoinAlias, /*.*/ relation.OriginFieldName);
						}
						else // if origin is entity we query
						{
							string targetJoinAlias = relationAlias;
							string originJoinAlias = relation.Name + "_origin";

							relationJoinSql += string.Format(FILTER_JOIN,
									/*LEFT OUTER JOIN*/ relationTable, /* */ originJoinAlias /*ON*/,
									originJoinAlias, /*.*/ "origin_id", /* =  */
									originJoinTable, /*.*/ relation.OriginFieldName);

							relationJoinSql += Environment.NewLine + string.Format(FILTER_JOIN,
									  /*LEFT OUTER JOIN*/ targetJoinTable, /* */ targetJoinAlias /*ON*/,
									originJoinAlias, /*.*/ "target_id", /* =  */
									targetJoinAlias, /*.*/ relation.TargetFieldName);
						}
					}

					lastAlias = relationAlias;
				}
			}
			return relationJoinSql;

		}
	}
}
