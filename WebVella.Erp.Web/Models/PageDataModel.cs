using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Utilities;
using WebVella.Erp.Web.Service;
using WebVella.Erp.Web.Services;

namespace WebVella.Erp.Web.Models
{
	public class PageDataModel
	{
		internal bool SafeCodeDataVariable { get; set; } = false;

		private readonly DataSourceManager dsMan = new();
		private readonly RecordManager recMan = new();
		private readonly EntityRelationManager relMan = new();
		private readonly EntityManager entMan = new();
		private readonly BaseErpPageModel erpPageModel = null;
		private readonly Dictionary<string, MPW> properties = [];
		// improvement to not load same values multiple times, since it can't be stored within record
		private readonly Dictionary<string, (List<EntityRecord> Result, Entity Entity)> alreadyResolvedRecordProperties = [];

		internal PageDataModel(BaseErpPageModel erpPageModel)
		{
			this.erpPageModel = erpPageModel ?? throw new NullReferenceException(nameof(erpPageModel));
			InitContextRelatedData(erpPageModel);
			if (erpPageModel.ErpRequestContext != null && erpPageModel.ErpRequestContext.Page != null)
				InitDataSources(erpPageModel.ErpRequestContext.Page);
		}

		private void InitContextRelatedData(BaseErpPageModel erpPageModel)
		{
			if (erpPageModel != null)
			{
				//if page request context is set, it is used, otherwise, the requestContext is used
				ErpRequestContext reqCtx = erpPageModel.ErpRequestContext;

				properties.Add("$exists", new MPW(MPT.Function, new ExistsFunction(this)));
				properties.Add("$not", new MPW(MPT.Function, new NotFunction(this)));
				properties.Add("$orderBy", new MPW(MPT.Function, new OrderByFunction(this)));
				properties.Add("$include", new MPW(MPT.Function, new IncludeFunction(this)));
				properties.Add("$coalesce", new MPW(MPT.Function, new CoalesceFunction(this)));
				properties.Add("$when", new MPW(MPT.Function, new WhenFunction(this)));

				var currentUserMPW = new MPW(MPT.Object, erpPageModel.CurrentUser);
				properties.Add("CurrentUser", currentUserMPW);
				if (erpPageModel.CurrentUser != null)
				{
					currentUserMPW.Properties.Add("CreatedOn", new MPW(MPT.Object, erpPageModel.CurrentUser.CreatedOn));
					currentUserMPW.Properties.Add("Email", new MPW(MPT.Object, erpPageModel.CurrentUser.Email));
					currentUserMPW.Properties.Add("FirstName", new MPW(MPT.Object, erpPageModel.CurrentUser.FirstName));
					currentUserMPW.Properties.Add("Id", new MPW(MPT.Object, erpPageModel.CurrentUser.Id));
					currentUserMPW.Properties.Add("Image", new MPW(MPT.Object, erpPageModel.CurrentUser.Image));
					currentUserMPW.Properties.Add("LastName", new MPW(MPT.Object, erpPageModel.CurrentUser.LastName));
					currentUserMPW.Properties.Add("Username", new MPW(MPT.Object, erpPageModel.CurrentUser.Username));

					var rolesMPW = new MPW(MPT.Object, erpPageModel.CurrentUser.Roles);
					currentUserMPW.Properties.Add("Roles", rolesMPW);
					if (erpPageModel.CurrentUser.Roles != null)
					{
						for (int i = 0; i < erpPageModel.CurrentUser.Roles.Count; i++)
						{
							var roleMPW = new MPW(MPT.Object, erpPageModel.CurrentUser.Roles[i]);
							rolesMPW.Properties.Add($"[{i}]", roleMPW);
							roleMPW.Properties.Add($"Id", new MPW(MPT.Object, erpPageModel.CurrentUser.Roles[i].Id));
							roleMPW.Properties.Add($"Name", new MPW(MPT.Object, erpPageModel.CurrentUser.Roles[i].Name));
						}
					}
				}

				properties.Add("ReturnUrl", new MPW(MPT.Object, erpPageModel.ReturnUrl));

				//this is the case of with related/parent entity and related/parent record id set
				if (erpPageModel.RecordId != null && erpPageModel.ParentRecordId != null && erpPageModel.RelationId != null &&
					reqCtx != null && reqCtx.Entity != null && reqCtx.ParentEntity != null)
				{
					EntityQuery eq = new EntityQuery(reqCtx.ParentEntity.Name, "*", EntityQuery.QueryEQ("id", erpPageModel.ParentRecordId.Value));
					var response = recMan.Find(eq);
					if (!response.Success)
						throw new Exception(response.Message);
					else if (response.Object.Data.Count > 0)
						properties.Add("ParentRecord", new MPW(MPT.EntityRecord, response.Object.Data[0]));
					else
						properties.Add("ParentRecord", new MPW(MPT.EntityRecord, null));

					eq = new EntityQuery(reqCtx.Entity.Name, "*", EntityQuery.QueryEQ("id", erpPageModel.RecordId.Value));
					response = recMan.Find(eq);
					if (!response.Success)
						throw new Exception(response.Message);
					else if (response.Object.Data.Count > 0)
						properties.Add("Record", new MPW(MPT.EntityRecord, response.Object.Data[0]));
					else
						properties.Add("Record", new MPW(MPT.EntityRecord, null));
				}

				//this is the case of Create and List page with related/parent entity amd with no related/parent record set
				else if (erpPageModel.RecordId == null && erpPageModel.ParentRecordId != null && erpPageModel.RelationId != null &&
					reqCtx != null && reqCtx.Entity != null && reqCtx.ParentEntity != null)
				{
					EntityQuery eq = new EntityQuery(reqCtx.ParentEntity.Name, "*", EntityQuery.QueryEQ("id", erpPageModel.ParentRecordId));
					var response = recMan.Find(eq);
					if (!response.Success)
						throw new Exception(response.Message);
					else if (response.Object.Data.Count > 0)
						properties.Add("ParentRecord", new MPW(MPT.EntityRecord, response.Object.Data[0]));
					else
						properties.Add("ParentRecord", new MPW(MPT.EntityRecord, null));

					properties.Add("Record", new MPW(MPT.EntityRecord, null));
				}

				//this is the case with no parent (relations/parents cases are checked above)
				else if (erpPageModel.RecordId != null && reqCtx != null && reqCtx.Entity != null)
				{
					EntityQuery eq = new EntityQuery(reqCtx.Entity.Name, "*", EntityQuery.QueryEQ("id", reqCtx.RecordId));
					var response = recMan.Find(eq);
					if (!response.Success)
						throw new Exception(response.Message);
					else if (response.Object.Data.Count > 0)
						properties.Add("Record", new MPW(MPT.EntityRecord, response.Object.Data[0]));
					else
						properties.Add("Record", new MPW(MPT.EntityRecord, null));

					properties.Add("ParentRecord", new MPW(MPT.EntityRecord, null));
				}

				//this is the case with no entity page
				else
				{
					properties.Add("Record", new MPW(MPT.EntityRecord, null));
					properties.Add("ParentRecord", new MPW(MPT.EntityRecord, null));
				}

				var validationMPW = new MPW(MPT.Object, erpPageModel.Validation);
				if (erpPageModel.Validation != null)
				{
					validationMPW.Properties.Add("Message", new MPW(MPT.Object, erpPageModel.Validation.Message));
					var errorsMPW = new MPW(MPT.Object, erpPageModel.Validation.Errors);
					if (erpPageModel.Validation.Errors != null)
					{
						for (int i = 0; i < erpPageModel.Validation.Errors.Count; i++)
						{
							var errorMPW = new MPW(MPT.Object, erpPageModel.Validation.Errors[i]);
							errorsMPW.Properties.Add($"[{i}]", errorMPW);
							errorMPW.Properties.Add($"Index", new MPW(MPT.Object, erpPageModel.Validation.Errors[i].Index));
							errorMPW.Properties.Add($"IsSystem", new MPW(MPT.Object, erpPageModel.Validation.Errors[i].IsSystem));
							errorMPW.Properties.Add($"Message", new MPW(MPT.Object, erpPageModel.Validation.Errors[i].Message));
							errorMPW.Properties.Add($"PropertyName", new MPW(MPT.Object, erpPageModel.Validation.Errors[i].PropertyName));
						}
					}
					validationMPW.Properties.Add("Errors", errorsMPW);

				}
				properties.Add("Validation", validationMPW);


				if (reqCtx != null)
				{
					properties.Add("RecordId", new MPW(MPT.Object, reqCtx.RecordId));
					properties.Add("ParentRecordId", new MPW(MPT.Object, reqCtx.ParentRecordId));
					properties.Add("RelationId", new MPW(MPT.Object, reqCtx.RelationId));
					properties.Add("PageContext", new MPW(MPT.Object, reqCtx.PageContext));

					var pageMPW = new MPW(MPT.Object, reqCtx.Page);
					if (reqCtx.Page != null)
					{
						pageMPW.Properties.Add("AppId", new MPW(MPT.Object, reqCtx.Page.AppId));
						pageMPW.Properties.Add("AreaId", new MPW(MPT.Object, reqCtx.Page.AreaId));
						pageMPW.Properties.Add("EntityId", new MPW(MPT.Object, reqCtx.Page.EntityId));
						pageMPW.Properties.Add("IconClass", new MPW(MPT.Object, reqCtx.Page.IconClass));
						pageMPW.Properties.Add("Id", new MPW(MPT.Object, reqCtx.Page.Id));
						pageMPW.Properties.Add("IsRazorBody", new MPW(MPT.Object, reqCtx.Page.IsRazorBody));
						pageMPW.Properties.Add("Label", new MPW(MPT.Object, reqCtx.Page.Label));
						pageMPW.Properties.Add("Name", new MPW(MPT.Object, reqCtx.Page.Name));
						pageMPW.Properties.Add("NodeId", new MPW(MPT.Object, reqCtx.Page.NodeId));
						pageMPW.Properties.Add("System", new MPW(MPT.Object, reqCtx.Page.System));
						pageMPW.Properties.Add("Type", new MPW(MPT.Object, reqCtx.Page.Type));
						pageMPW.Properties.Add("Weight", new MPW(MPT.Object, reqCtx.Page.Weight));
					}
					properties.Add("Page", pageMPW);

					var parentPageMPW = new MPW(MPT.Object, reqCtx.ParentPage);
					if (reqCtx.ParentPage != null)
					{
						parentPageMPW.Properties.Add("AppId", new MPW(MPT.Object, reqCtx.ParentPage.AppId));
						parentPageMPW.Properties.Add("AreaId", new MPW(MPT.Object, reqCtx.ParentPage.AreaId));
						parentPageMPW.Properties.Add("EntityId", new MPW(MPT.Object, reqCtx.ParentPage.EntityId));
						parentPageMPW.Properties.Add("IconClass", new MPW(MPT.Object, reqCtx.ParentPage.IconClass));
						parentPageMPW.Properties.Add("Id", new MPW(MPT.Object, reqCtx.ParentPage.Id));
						parentPageMPW.Properties.Add("IsRazorBody", new MPW(MPT.Object, reqCtx.ParentPage.IsRazorBody));
						parentPageMPW.Properties.Add("Label", new MPW(MPT.Object, reqCtx.ParentPage.Label));
						parentPageMPW.Properties.Add("Name", new MPW(MPT.Object, reqCtx.ParentPage.Name));
						parentPageMPW.Properties.Add("NodeId", new MPW(MPT.Object, reqCtx.ParentPage.NodeId));
						parentPageMPW.Properties.Add("System", new MPW(MPT.Object, reqCtx.ParentPage.System));
						parentPageMPW.Properties.Add("Type", new MPW(MPT.Object, reqCtx.ParentPage.Type));
						parentPageMPW.Properties.Add("Weight", new MPW(MPT.Object, reqCtx.ParentPage.Weight));
					}
					properties.Add("ParentPage", parentPageMPW);

					var entityMPW = new MPW(MPT.Object, reqCtx.Entity);
					if (reqCtx.Entity != null)
					{
						entityMPW.Properties.Add("Color", new MPW(MPT.Object, reqCtx.Entity.Color));
						entityMPW.Properties.Add("Fields", new MPW(MPT.Object, reqCtx.Entity.Fields));
						entityMPW.Properties.Add("IconName", new MPW(MPT.Object, reqCtx.Entity.IconName));
						entityMPW.Properties.Add("Id", new MPW(MPT.Object, reqCtx.Entity.Id));
						entityMPW.Properties.Add("Label", new MPW(MPT.Object, reqCtx.Entity.Label));
						entityMPW.Properties.Add("LabelPlural", new MPW(MPT.Object, reqCtx.Entity.LabelPlural));
						entityMPW.Properties.Add("Name", new MPW(MPT.Object, reqCtx.Entity.Name));
						entityMPW.Properties.Add("RecordScreenIdField", new MPW(MPT.Object, reqCtx.Entity.RecordScreenIdField));
						entityMPW.Properties.Add("System", new MPW(MPT.Object, reqCtx.Entity.System));
					}
					properties.Add("Entity", entityMPW);

					var parentEntityMPW = new MPW(MPT.Object, reqCtx.ParentEntity);
					if (reqCtx.ParentEntity != null)
					{
						parentEntityMPW.Properties.Add("Color", new MPW(MPT.Object, reqCtx.ParentEntity.Color));
						parentEntityMPW.Properties.Add("Fields", new MPW(MPT.Object, reqCtx.ParentEntity.Fields));
						parentEntityMPW.Properties.Add("IconName", new MPW(MPT.Object, reqCtx.ParentEntity.IconName));
						parentEntityMPW.Properties.Add("Id", new MPW(MPT.Object, reqCtx.ParentEntity.Id));
						parentEntityMPW.Properties.Add("Label", new MPW(MPT.Object, reqCtx.ParentEntity.Label));
						parentEntityMPW.Properties.Add("LabelPlural", new MPW(MPT.Object, reqCtx.ParentEntity.LabelPlural));
						parentEntityMPW.Properties.Add("Name", new MPW(MPT.Object, reqCtx.ParentEntity.Name));
						parentEntityMPW.Properties.Add("RecordScreenIdField", new MPW(MPT.Object, reqCtx.ParentEntity.RecordScreenIdField));
						parentEntityMPW.Properties.Add("System", new MPW(MPT.Object, reqCtx.ParentEntity.System));
					}
					properties.Add("ParentEntity", parentEntityMPW);

					var detectionMPW = new MPW(MPT.Object, reqCtx.Detection);
					if (reqCtx.Detection != null)
					{
						var deviceMPW = new MPW(MPT.Object, reqCtx.Detection.Device);
						if (reqCtx.Detection.Device != null)
						{
							deviceMPW.Properties.Add("Crawler", new MPW(MPT.Object, reqCtx.Detection.Crawler.IsCrawler));
							deviceMPW.Properties.Add("Type", new MPW(MPT.Object, reqCtx.Detection.Device.Type));
						}
						detectionMPW.Properties.Add("Device", deviceMPW);
					}
					properties.Add("Detection", detectionMPW);

					var appMPW = new MPW(MPT.Object, reqCtx.App);
					if (reqCtx.App != null)
					{
						appMPW.Properties.Add("Author", new MPW(MPT.Object, reqCtx.App.Author));
						appMPW.Properties.Add("Color", new MPW(MPT.Object, reqCtx.App.Color));
						appMPW.Properties.Add("Description", new MPW(MPT.Object, reqCtx.App.Description));
						appMPW.Properties.Add("IconClass", new MPW(MPT.Object, reqCtx.App.IconClass));
						appMPW.Properties.Add("Id", new MPW(MPT.Object, reqCtx.App.Id));
						appMPW.Properties.Add("Label", new MPW(MPT.Object, reqCtx.App.Label));
						appMPW.Properties.Add("Name", new MPW(MPT.Object, reqCtx.App.Name));
						var sitemapMPW = new MPW(MPT.Object, reqCtx.App.Sitemap);
						if (reqCtx.App.Sitemap != null)
						{
							var areasMPW = new MPW(MPT.Object, reqCtx.App.Sitemap.Areas);
							sitemapMPW.Properties.Add("Areas", sitemapMPW);
							for (int i = 0; i < reqCtx.App.Sitemap.Areas.Count; i++)
							{
								var area = reqCtx.App.Sitemap.Areas[i];
								var areaMPW = new MPW(MPT.Object, area);
								areaMPW.Properties.Add($"Access", new MPW(MPT.Object, area.Access));
								areaMPW.Properties.Add($"Color", new MPW(MPT.Object, area.Color));
								areaMPW.Properties.Add($"Description", new MPW(MPT.Object, area.Description));
								areaMPW.Properties.Add($"IconClass", new MPW(MPT.Object, area.IconClass));
								areaMPW.Properties.Add($"Id", new MPW(MPT.Object, area.Id));
								areaMPW.Properties.Add($"Label", new MPW(MPT.Object, area.Label));
								areaMPW.Properties.Add($"Name", new MPW(MPT.Object, area.Name));

								var areaNodesMPW = new MPW(MPT.Object, area.Nodes);
								for (int j = 0; j < area.Nodes.Count; j++)
								{
									var node = area.Nodes[j];
									var nodeMPW = new MPW(MPT.Object, area);
									nodeMPW.Properties.Add($"Access", new MPW(MPT.Object, node.Access));
									nodeMPW.Properties.Add($"EntityId", new MPW(MPT.Object, node.EntityId));
									nodeMPW.Properties.Add($"GroupName", new MPW(MPT.Object, node.GroupName));
									nodeMPW.Properties.Add($"IconClass", new MPW(MPT.Object, node.IconClass));
									nodeMPW.Properties.Add($"Id", new MPW(MPT.Object, node.Id));
									nodeMPW.Properties.Add($"Label", new MPW(MPT.Object, node.Label));
									nodeMPW.Properties.Add($"Name", new MPW(MPT.Object, node.Name));
									nodeMPW.Properties.Add($"Type", new MPW(MPT.Object, node.Type));
									nodeMPW.Properties.Add($"Url", new MPW(MPT.Object, node.Url));
									nodeMPW.Properties.Add($"Weight", new MPW(MPT.Object, node.Weight));
									areaNodesMPW.Properties.Add($"[{j}]", nodeMPW);
								}
								areaMPW.Properties.Add($"Nodes", areaNodesMPW);
								areasMPW.Properties.Add($"[{i}]", areaMPW);
							}
						}
						appMPW.Properties.Add("Sitemap", sitemapMPW);
					}
					properties.Add("App", appMPW);

					var sitemapNodeMPW = new MPW(MPT.Object, reqCtx.SitemapNode);
					if (reqCtx.SitemapNode != null)
					{
						sitemapNodeMPW.Properties.Add($"Access", new MPW(MPT.Object, reqCtx.SitemapNode.Access));
						sitemapNodeMPW.Properties.Add($"EntityId", new MPW(MPT.Object, reqCtx.SitemapNode.EntityId));
						sitemapNodeMPW.Properties.Add($"GroupName", new MPW(MPT.Object, reqCtx.SitemapNode.GroupName));
						sitemapNodeMPW.Properties.Add($"IconClass", new MPW(MPT.Object, reqCtx.SitemapNode.IconClass));
						sitemapNodeMPW.Properties.Add($"Id", new MPW(MPT.Object, reqCtx.SitemapNode.Id));
						sitemapNodeMPW.Properties.Add($"Label", new MPW(MPT.Object, reqCtx.SitemapNode.Label));
						sitemapNodeMPW.Properties.Add($"Name", new MPW(MPT.Object, reqCtx.SitemapNode.Name));
						sitemapNodeMPW.Properties.Add($"Type", new MPW(MPT.Object, reqCtx.SitemapNode.Type));
						sitemapNodeMPW.Properties.Add($"Url", new MPW(MPT.Object, reqCtx.SitemapNode.Url));
						sitemapNodeMPW.Properties.Add($"Weight", new MPW(MPT.Object, reqCtx.SitemapNode.Weight));
					}
					properties.Add("SitemapNode", sitemapNodeMPW);

					var sitemapAreaMPW = new MPW(MPT.Object, reqCtx.SitemapArea);
					if (reqCtx.SitemapArea != null)
					{
						var area = reqCtx.SitemapArea;
						sitemapAreaMPW.Properties.Add($"Access", new MPW(MPT.Object, area.Access));
						sitemapAreaMPW.Properties.Add($"Color", new MPW(MPT.Object, area.Color));
						sitemapAreaMPW.Properties.Add($"Description", new MPW(MPT.Object, area.Description));
						sitemapAreaMPW.Properties.Add($"IconClass", new MPW(MPT.Object, area.IconClass));
						sitemapAreaMPW.Properties.Add($"Id", new MPW(MPT.Object, area.Id));
						sitemapAreaMPW.Properties.Add($"Label", new MPW(MPT.Object, area.Label));
						sitemapAreaMPW.Properties.Add($"Name", new MPW(MPT.Object, area.Name));

						var areaNodesMPW = new MPW(MPT.Object, area.Nodes);
						for (int j = 0; j < area.Nodes.Count; j++)
						{
							var node = area.Nodes[j];
							var nodeMPW = new MPW(MPT.Object, area);
							nodeMPW.Properties.Add($"Access", new MPW(MPT.Object, node.Access));
							nodeMPW.Properties.Add($"EntityId", new MPW(MPT.Object, node.EntityId));
							nodeMPW.Properties.Add($"GroupName", new MPW(MPT.Object, node.GroupName));
							nodeMPW.Properties.Add($"IconClass", new MPW(MPT.Object, node.IconClass));
							nodeMPW.Properties.Add($"Id", new MPW(MPT.Object, node.Id));
							nodeMPW.Properties.Add($"Label", new MPW(MPT.Object, node.Label));
							nodeMPW.Properties.Add($"Name", new MPW(MPT.Object, node.Name));
							nodeMPW.Properties.Add($"Type", new MPW(MPT.Object, node.Type));
							nodeMPW.Properties.Add($"Url", new MPW(MPT.Object, node.Url));
							nodeMPW.Properties.Add($"Weight", new MPW(MPT.Object, node.Weight));
							areaNodesMPW.Properties.Add($"[{j}]", nodeMPW);
						}
						sitemapAreaMPW.Properties.Add($"Nodes", areaNodesMPW);
					}
					properties.Add("SitemapArea", sitemapAreaMPW);
				}

				EntityRecord queryRecord = new EntityRecord();
				if (reqCtx != null && reqCtx.PageContext != null && reqCtx.PageContext.HttpContext != null)
				{
					var httpCtx = reqCtx.PageContext.HttpContext;
					if (httpCtx.Request != null && httpCtx.Request.Query != null)
					{
						foreach (var key in httpCtx.Request.Query.Keys)
							queryRecord[key] = ((string)httpCtx.Request.Query[key]) ?? string.Empty;
					}
				}
				properties.Add("RequestQuery", new MPW(MPT.EntityRecord, queryRecord));
			}
			else
			{
				properties.Add("CurrentUser", new MPW(MPT.Object, null));
				properties.Add("RecordId", new MPW(MPT.Object, null));
				properties.Add("ParentRecordId", new MPW(MPT.Object, null));
				properties.Add("Record", new MPW(MPT.EntityRecord, null));
				properties.Add("ParentRecord", new MPW(MPT.EntityRecord, null));
				properties.Add("ReturnUrl", new MPW(MPT.Object, null));
			}

			properties.Add("RowRecord", new MPW(MPT.EntityRecord, null));
			
		}

		public void SetRowRecord(EntityRecord rowRecord)
		{
			properties["RowRecord"] = new MPW(MPT.EntityRecord, rowRecord);
		}

		public void SetRecord(EntityRecord record)
		{
			alreadyResolvedRecordProperties.Clear();
			properties["Record"] = new MPW(MPT.EntityRecord, record);
		}

		public void SetEntity(Entity entity)
		{
			alreadyResolvedRecordProperties.Clear();
			properties["Entity"] = new MPW(MPT.Object, entity);
		}

		private void InitDataSources(ErpPage page)
		{
			var pageDataSources = new PageService().GetPageDataSources(page.Id);
			var allDatasources = new DataSourceManager().GetAll();
			foreach (var pageDS in pageDataSources)
			{
				var ds = allDatasources.SingleOrDefault(x => x.Id == pageDS.DataSourceId);
				//if data source was deleted (and system validation for usage failed)
				//we hide this page data source
				if (ds == null)
					continue;

				properties[pageDS.Name] = new MPW(MPT.DataSource, new DSW { DataSource = ds, PageDataSource = pageDS });
			}

		}

		public object GetPropertyValueByDataSource(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				return text;

			if (text.Trim().StartsWith('{'))
			{
				DataSourceVariable variable;
				try
				{
					variable = JsonConvert.DeserializeObject<DataSourceVariable>(text, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error });
				}
				catch
				{
					return text;
				}

				if (variable != null)
					return GetPropertyValueByDataSource(variable);
			}

			return text;
		}

		public object GetPropertyValueByDataSource(DataSourceVariable variable)
		{
			if (variable == null)
				throw new NullReferenceException(nameof(variable));

			try
			{
				object result = null;
				switch (variable.Type)
				{
					case DataSourceVariableType.DATASOURCE:
						result = GetProperty(variable.String);
						break;
					case DataSourceVariableType.CODE:
						if (SafeCodeDataVariable)
						{
							try { result = CodeEvalService.Evaluate(variable.String, erpPageModel); } catch { result = null; }
						}
						else
						{
							result = CodeEvalService.Evaluate(variable.String, erpPageModel);
						}
						break;
					case DataSourceVariableType.HTML:
						result = variable.String;
						break;
					case DataSourceVariableType.SNIPPET:
						if (SnippetService.GetSnippet(variable.String) is ICodeVariable code)
							result = code.Evaluate(erpPageModel);
						else result = $"Snippet '{variable.String}' is not found.";
						break;
					default:
						throw new NotSupportedException(variable.Type.ToString());
				}
				if (result is string)
				{
					if (string.IsNullOrWhiteSpace(result as string))
						return variable.Default;
				}
				else
				{
					if (result is null)
						return variable.Default;
				}

				return result;
			}
			catch (PropertyDoesNotExistException)
			{
				return variable.Default;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private static (Guid EntityId, string FieldName, string SourceField) OtherSideOfRelation(EntityRelation rel, Entity entity)
		{
			if (rel.TargetEntityId == entity.Id)
				return (rel.OriginEntityId, rel.OriginFieldName, rel.TargetFieldName);
			if (rel.OriginEntityId == entity.Id)
				return (rel.TargetEntityId, rel.TargetFieldName, rel.OriginFieldName);

			throw new PropertyDoesNotExistException($"Relation '{rel.Name}' does not touch entity '{entity.Name}'");
		}

		public object GetProperty(string propName)
		{
			if (string.IsNullOrWhiteSpace(propName))
				throw new ArgumentException($"Argument '{nameof(propName)}' must not be null or whitespace");

			if (!propName.Contains("{{"))
				return ResolveProperty(propName);

			var sb = new StringBuilder();

			var idx = 0;

			while(idx < propName.Length)
			{
				if (!(idx < propName.Length - 1 && propName[idx] == '{' && propName[idx + 1] == '{'))
				{
					if (propName[idx] == '{' || propName[idx] == '}')
						throw new PropertyDoesNotExistException("Could not interpret property value");
					sb.Append(propName[idx++]);
				}
				else
				{
					idx += 2;
					var end = propName.IndexOf("}}", idx);
					if (end <= idx)
						throw new PropertyDoesNotExistException("Could not interpret property value");

					var prop = propName[idx..end];
					var value = ResolveProperty(prop);
					sb.Append($"{value}");
					idx = end + 2;
				}
			}
			return sb.ToString();
		}

		private object ResolveProperty(string propName)
		{
			//replace keyword $index with 0
			propName = propName.Trim();
			var name = propName.Replace("$index", "0");

			if(propName.StartsWith('"') && propName.EndsWith('"'))
				return propName[1..(propName.Length - 1)];

			if (decimal.TryParse(propName, out var dec))
				return dec;

			if(bool.TryParse(propName, out var b))
				return b;

			if(Guid.TryParse(propName, out var id))
				return id;

			if (propName.StartsWith('$') && propName.EndsWith(')'))
				return ExecFunction(propName);

			var tmpPropChain = name.Split(".", StringSplitOptions.RemoveEmptyEntries);
			var completePropChain = new List<string>();

			foreach (var pName in tmpPropChain)
			{
				var indexerIdx = pName.IndexOf('[');
				if (indexerIdx != -1)
				{
					var n = pName[..indexerIdx];
					var i = pName[indexerIdx..];
					completePropChain.Add(n);
					completePropChain.Add(i);
				}
				else
					completePropChain.Add(pName);
			}

			MPW mpw = null;
			var currentPropDict = properties;
			var currentPropertyNamePath = string.Empty;
			string parentPropName = string.Empty;

			int idx = 0;
			foreach (var ppName in completePropChain)
			{

				var pName = ppName.Trim();
				if (string.IsNullOrWhiteSpace(currentPropertyNamePath))
					currentPropertyNamePath = pName;
				else if (pName.StartsWith('['))
					currentPropertyNamePath += pName;
				else
					currentPropertyNamePath += $".{pName}";

				//try to get property with full key (after http post object are entered with no . split
				if (parentPropName == "Record" && idx == 1)
				{
					if (pName.StartsWith('$'))
					{
						var entity = properties["Entity"].Value as Entity;
						var result = properties["Record"].Value;

						for(var i = 1; i < completePropChain.Count; i++)
						{
							var accessor = completePropChain[i];

							if (accessor.StartsWith('$'))
							{
								// makes indexing optional between relations
								if (result is List<EntityRecord> l && l.Count == 1)
									result = l[0];

								if (result is not EntityRecord rec)
									throw new PropertyDoesNotExistException($"Property not found");

								var path = completePropChain[1..(i + 1)]
									.Select(p => p.Replace(" ", string.Empty).Trim())
									.Where(p => p != "[0]");
								var currentPath = string.Join('.', path);

								if (alreadyResolvedRecordProperties.TryGetValue(currentPath, out var tuple))
								{
									result = tuple.Result;
									entity = tuple.Entity;
									continue;
								}

								var relName = accessor[1..];
								var relResponse = relMan.Read(relName);

								if (!relResponse.Success || relResponse.Object == null)
									throw new PropertyDoesNotExistException($"Relation '{relName}' not found");

								var (entityId, nextIdName, sourceIdName) = OtherSideOfRelation(relResponse.Object, entity);
								var resultEntity = entMan.ReadEntity(entityId)?.Object
									?? throw new PropertyDoesNotExistException($"Invalid relation '{relName}'");

								List<EntityRecord> resultList;
								if (rec.Properties.TryGetValue(accessor, out var obj) && obj is List<EntityRecord> recList)
									resultList = recList;
								else
								{
									// automatically load values
									var nextIdValue = rec[sourceIdName];
									var queryObject = new QueryObject()
									{
										FieldName = nextIdName,
										FieldValue = nextIdValue,
										QueryType = QueryType.EQ
									};

									var response = new RecordManager()
										.Find(new EntityQuery(resultEntity.Name, "*", queryObject));

									if (!response.Success || response.Object.Data == null)
										throw new PropertyDoesNotExistException(response.Message);

									resultList = response.Object.Data;
								}

								alreadyResolvedRecordProperties[currentPath] = (resultList, resultEntity);
								entity = resultEntity;
								result = resultList;
							}
							else if (accessor.StartsWith('[') && accessor.EndsWith(']'))
							{
								if (result is not List<EntityRecord> records)
									throw new PropertyDoesNotExistException("Property not found");

								var index = int.Parse(accessor[1..(accessor.Length - 1)].Trim());
								if (index >= records.Count)
									return null;
								result = records[index];
							}
							else if(result is EntityRecord rec)
							{
								if (i < completePropChain.Count - 1)
									throw new PropertyDoesNotExistException("Property not found");

								result = rec[accessor];										
							}
							else if(result is List<EntityRecord> recList)
							{
								if (i < completePropChain.Count - 1)
									throw new PropertyDoesNotExistException("Property not found");

								if (recList.Count == 0)
									return null;

								var first = recList[0];
								if (recList.Count == 1)
									return first?[accessor];

								return recList.Select(r => r?[accessor])
									.ToList();
							}
							else throw new PropertyDoesNotExistException($"Property not found");
						}
						return result;
					}
				}

				if (parentPropName == "RowRecord" && idx == 1)
				{
					if (pName.StartsWith('$'))
					{
						var result = properties["RowRecord"].Value;

						for (var i = 1; i < completePropChain.Count; i++)
						{
							var accessor = completePropChain[i];

							if (accessor.StartsWith('$'))
							{
								// makes indexing optional between relations
								if (result is List<EntityRecord> l && l.Count == 1)
									result = l[0];

								if (result is not EntityRecord rec || !rec.Properties.TryGetValue(accessor, out var obj))
									throw new PropertyDoesNotExistException($"Property not found");

								result = obj;
							}
							else if (accessor.StartsWith('[') && accessor.EndsWith(']'))
							{
								if (result is not List<EntityRecord> records)
									throw new PropertyDoesNotExistException("Property not found");

								var index = int.Parse(accessor[1..(accessor.Length - 1)].Trim());
								if (index >= records.Count)
									return null;
								result = records[index];
							}
							else if (result is EntityRecord rec)
							{
								if (i < completePropChain.Count - 1)
									throw new PropertyDoesNotExistException("Property not found");

								result = rec[accessor];
							}
							else if (result is List<EntityRecord> recList)
							{
								if(i < completePropChain.Count - 1)
									throw new PropertyDoesNotExistException("Property not found");

								if (recList.Count == 0)
									return null;

								var first = recList[0];
								if (recList.Count == 1)
									return first?[accessor];

								return recList.Select(r => r?[accessor])
									.ToList();
							}
							else throw new PropertyDoesNotExistException($"Property not found");
						}
						return result;
					}
				}

				//try to get property with full key (after http post object are entered with no . split
				if (parentPropName == "RelatedRecord")
				{
					var testName = propName.Trim()[14..]; //cut the RelatedRecord. in front
					if (pName != testName && currentPropDict.TryGetValue(testName, out var result))
						return result.Value;
				}

				if (!currentPropDict.ContainsKey(pName))
				{
					if (!currentPropertyNamePath.EndsWith(']'))
						throw new PropertyDoesNotExistException($"Property name '{currentPropertyNamePath}' not found.");
					else
						throw new PropertyDoesNotExistException($"Property name is found, but list index is out of bounds.");
				}

				mpw = currentPropDict[pName];
				if (mpw != null)
				{
					if (mpw.Type == MPT.DataSource && mpw.Value is DSW dsw)
					{
						var result = ExecDataSource(dsw);
						if (result is List<EntityRecord> || result is EntityRecordList)
						{
							mpw = new MPW(MPT.ListEntityRecords, result);
							currentPropDict[pName] = mpw;
						}
						else if (result is EntityRecord)
						{
							mpw = new MPW(MPT.EntityRecord, result);
							currentPropDict[pName] = mpw;
						}
						else
						{
							mpw = new MPW(MPT.Object, result);
							currentPropDict[pName] = mpw;
						}
					}
				}

				idx++;
				currentPropDict = mpw.Properties;
				parentPropName = pName;
			}

			return mpw.Value;
		}

		private object ExecFunction(string propName)
		{
			var leftPars = propName.Count(c => c == '(');
			var rightPars = propName.Count(c => c == ')');

			if (leftPars != rightPars)
				throw new PropertyDoesNotExistException($"function call is malformed");

			var openParIdx = propName.IndexOf('(');
			var funName = propName[..openParIdx].Trim();

			if (!properties.TryGetValue(funName, out var mpv) || mpv.Value is not QueryFunction fun)
				throw new PropertyDoesNotExistException($"function '{funName}' does not exist in given context");

			var closeParIdx = propName.LastIndexOf(')');
			var paramsString = propName[(openParIdx + 1)..closeParIdx].Trim();

			return fun.Execute(paramsString);
		}

		private object ExecDataSource(DSW dsWrapper)
		{
			if (dsWrapper.DataSource.Type == DataSourceType.CODE)
			{
				var arguments = new Dictionary<string, object>();
				if (dsWrapper.DataSource.Parameters != null)
				{
					foreach (var par in dsWrapper.DataSource.Parameters)
					{
						var pageDSParam = dsWrapper.PageDataSource.Parameters.SingleOrDefault(x => x.Name == par.Name);
						string value = par.Value;
						if (pageDSParam != null)
						{
							value = ProcessParameterValue(pageDSParam.Value);
							if (string.IsNullOrWhiteSpace(value))
							{
								value = ProcessParameterValue(par.Value);
								value = CheckProcessDefaultValue(value);
								var ds = dsMan.Get(dsWrapper.PageDataSource.DataSourceId);
								var dsParam = ds.Parameters.SingleOrDefault(x => x.Name == par.Name);
								if (dsParam != null)
									arguments[dsParam.Name] = dsMan.GetDataSourceParameterValue(new DataSourceParameter { Name = dsParam.Name, Type = dsParam.Type, Value = value });
								else
									arguments[par.Name] = value;
							}
							else
							{
								value = CheckProcessDefaultValue(value);
								arguments[pageDSParam.Name] = dsMan.GetDataSourceParameterValue(new DataSourceParameter { Name = pageDSParam.Name, Type = pageDSParam.Type, Value = value });
							}
						}
						else
						{
							value = ProcessParameterValue(value);
							value = CheckProcessDefaultValue(value);
							var ds = dsMan.Get(dsWrapper.PageDataSource.DataSourceId);
							var dsParam = ds.Parameters.SingleOrDefault(x => x.Name == par.Name);
							if (dsParam != null)
								arguments[dsParam.Name] = dsMan.GetDataSourceParameterValue(new DataSourceParameter { Name = dsParam.Name, Type = dsParam.Type, Value = value });
							else
								arguments[par.Name] = value;
						}
					}
				}

				arguments["PageModel"] = this;
				var codeDS = (CodeDataSource)dsWrapper.DataSource;
				if (SafeCodeDataVariable)
					try { return codeDS.Execute(arguments); } catch { return null; }
				else
					return codeDS.Execute(arguments);
			}
			else if (dsWrapper.DataSource.Type == DataSourceType.DATABASE)
			{
				var eqlParameters = new List<EqlParameter>();
				if (dsWrapper.DataSource.Parameters != null)
				{

					foreach (var par in dsWrapper.DataSource.Parameters)
					{
						var pageDSParam = dsWrapper.PageDataSource.Parameters.SingleOrDefault(x => x.Name == par.Name);
						string value = par.Value;
						if (pageDSParam != null)
						{
							value = ProcessParameterValue(pageDSParam.Value);
							if (string.IsNullOrWhiteSpace(value))
							{
								value = ProcessParameterValue(par.Value);
								value = CheckProcessDefaultValue(value);
								var ds = dsMan.Get(dsWrapper.PageDataSource.DataSourceId);
								var dsParam = ds.Parameters.SingleOrDefault(x => x.Name == par.Name);
								if (dsParam != null)
									eqlParameters.Add(dsMan.ConvertDataSourceParameterToEqlParameter(new DataSourceParameter { Name = dsParam.Name, Type = dsParam.Type, Value = value }));
								else
									eqlParameters.Add(new EqlParameter(par.Name, value));
							}
							else
							{
								value = CheckProcessDefaultValue(value);
								eqlParameters.Add(dsMan.ConvertDataSourceParameterToEqlParameter(new DataSourceParameter { Name = pageDSParam.Name, Type = pageDSParam.Type, Value = value }));
							}
						}
						else
						{
							value = ProcessParameterValue(value);
							value = CheckProcessDefaultValue(value);
							var ds = dsMan.Get(dsWrapper.PageDataSource.DataSourceId);
							var dsParam = ds.Parameters.SingleOrDefault(x => x.Name == par.Name);
							if (dsParam != null)
								eqlParameters.Add(dsMan.ConvertDataSourceParameterToEqlParameter(new DataSourceParameter { Name = dsParam.Name, Type = dsParam.Type, Value = value }));
							else
								eqlParameters.Add(new EqlParameter(par.Name, value));
						}
					}
				}

				DatabaseDataSource dbDs = (DatabaseDataSource)dsWrapper.DataSource;
				return dsMan.Execute(dbDs.Id, eqlParameters);
			}
			else
				throw new Exception("Not supported data source type.");
		}

		private static string CheckProcessDefaultValue(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				switch (value.ToLowerInvariant())
				{
					case "string.empty":
						return string.Empty;
					case "guid.empty":
						return Guid.Empty.ToString();
				}
			}
			return value;
		}

		private string ProcessParameterValue(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				return value;


			var replacementDict = new Dictionary<string, string>();

			var foundTags = Regex.Matches(value, @"(?<=\{\{)[^}]*(?=\}\})").Cast<Match>().Select(match => match.Value).Distinct().ToList();
			foreach (var tag in foundTags)
			{
				var processedTag = tag.Replace("{{", "").Replace("}}", "").Trim();
				var defaultValue = "";
				if (processedTag.Contains("??"))
				{
					//this is a tag with a default value
					int questionMarksLocation = processedTag.IndexOf("??");
					var tagValue = processedTag[..questionMarksLocation].Trim();
					var tagDefault = processedTag[(questionMarksLocation + 2)..].Trim().Replace("\"", "").Replace("'", "");
					processedTag = tagValue;
					defaultValue = tagDefault;
				}

				try
				{
					var propValue = GetProperty(processedTag);
					replacementDict["{{" + tag + "}}"] = (propValue ?? defaultValue).ToString();
				}
				catch (PropertyDoesNotExistException)
				{
					replacementDict["{{" + tag + "}}"] = defaultValue;
				}
			}

			string result = value;
			foreach (var key in replacementDict.Keys)
				result = result.Replace(key, replacementDict[key]);


			return result;
		}

		public object this[string key]
		{
			get { return GetProperty(key); }
		}

		#region <--- Private types --->

		//ModelPropertyType
		private enum MPT
		{
			Object,
			DataSource,
			EntityRecord,
			ListEntityRecords,
			Function,
		}

		//DataSourceWrapper
		private class DSW
		{
			public DataSourceBase DataSource { get; set; }

			public PageDataSource PageDataSource { get; set; }
		}

		//ModelPropertyWrapper
		private class MPW
		{
			public MPT Type { get; set; }

			public object Value { get; set; }

			public Dictionary<string, MPW> Properties { get; private set; } = [];

			public MPW(MPT type, object value)
			{
				Type = type;
				Value = value;

				if (Type == MPT.ListEntityRecords)
				{
					if (Value is List<EntityRecord> records)
					{
						for (int i = 0; i < records.Count; i++)
						{
							var recMPW = new MPW(MPT.EntityRecord, records[i]);
							Properties[$"[{i}]"] = recMPW;
						}
					}
				}
				else if (Type == MPT.EntityRecord)
				{
					if (Value is EntityRecord record)
					{
						foreach (var propName in record.Properties.Keys)
						{
							var propValue = record[propName.Trim()];
							//the case when set record from page post
							if (propName.StartsWith('$') && propName.Contains('.') && propValue is List<Guid> l)
							{
								string[] split = propName.Split('.');
								var records = new List<EntityRecord>();
								foreach (Guid id in l)
								{
									EntityRecord rec = new EntityRecord();
									rec["id"] = id;
									records.Add(rec);
								}
								Properties[split[0]] = new MPW(MPT.ListEntityRecords, records);
							}
							else
							{
								if (propValue is List<EntityRecord>)
									Properties[propName] = new MPW(MPT.ListEntityRecords, propValue);
								else if (propValue is EntityRecord)
									Properties[propName] = new MPW(MPT.EntityRecord, propValue);
								else
									Properties[propName] = new MPW(MPT.Object, propValue);
							}
						}
					}
				}
			}
		}

		//FunctionWrapper
		private abstract class QueryFunction
		{
			protected QueryFunction(PageDataModel dataModel)
			{
				DataModel = dataModel;
			}

			protected PageDataModel DataModel { get; }

			protected abstract int MinParameters { get; }

			protected abstract int MaxParameters { get; }


			public abstract string Name { get; }

			protected static List<string> ParseParams(string paramsString)
			{
				if (string.IsNullOrWhiteSpace(paramsString))
					return [];

				var result = new List<string>();

				var start = 0;
				var idx = 0;
				var parDepth = 0;

				while(idx < paramsString.Length)
				{
					var c = paramsString[idx];
					if (c == '(')
						parDepth++;
					else if (c == ')')
						parDepth--;
					else if(c == ',' && parDepth == 0)
					{
						result.Add(paramsString[start..idx].Trim());
						start = idx + 1;
					}
					idx++;
				}

				if (parDepth == 0)
					result.Add(paramsString[start..idx].Trim());

				return result;
			}

			public object Execute(string paramsString)
			{
				var parameters = ParseParams(paramsString);
				if (parameters.Count < MinParameters || MaxParameters > -1 && parameters.Count > MaxParameters)
				{
					if(MinParameters == MaxParameters)
						throw new PropertyDoesNotExistException($"Function '{Name}' requires exactly {MinParameters} arguments");
					if(MaxParameters > MinParameters)
						throw new PropertyDoesNotExistException($"Function '{Name}' requires {MinParameters} - {MaxParameters} arguments");
					throw new PropertyDoesNotExistException($"Function '{Name}' requires at least {MinParameters}");
				}

				var args = parameters.Select(DataModel.GetProperty)
					.ToArray();

				return Execute(args);
			}

			protected abstract object Execute(object[] parameters);
		}

		private sealed class ExistsFunction : QueryFunction
		{
			public ExistsFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "exists";

			protected override int MinParameters => 1;

			protected override int MaxParameters => MinParameters;

			protected override object Execute(object[] parameters)
			{
				var para = parameters[0];
				var result = para is EntityRecord
					|| para is string s && !string.IsNullOrWhiteSpace(s)
					|| para is IEnumerable en && en is not string && en.Any()
					|| para is Guid id && id != Guid.Empty
					|| para is decimal n && n != 0
					|| para is int i && i != 0
					|| para is bool b && b;
				return result;
			}
		}

		private sealed class NotFunction : QueryFunction
		{
			public NotFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "not";

			protected override int MinParameters => 1;

			protected override int MaxParameters => MinParameters;

			protected override object Execute(object[] parameters)
			{
				return parameters[0] is bool b ? !b
					: throw new PropertyDoesNotExistException($"function {Name} requires boolean");
			}
		}

		private sealed class OrderByFunction : QueryFunction
		{
			public OrderByFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "orderBy";

			protected override int MinParameters => 2;

			protected override int MaxParameters => -1;

			protected override object Execute(object[] parameters)
			{
				if (parameters[0] is not List<EntityRecord> l)
					throw new PropertyDoesNotExistException($"function {Name} requires List<EntityRecord> at first argument");

				if (l.Count == 0)
					return l;

				IOrderedEnumerable<EntityRecord> query = null;

				var idx = 1;
				while(idx < parameters.Length)
				{
					if (parameters[idx] is not string propName)
						throw new PropertyDoesNotExistException($"function {Name} requires string at argument '{idx}'");

					var isDesc = IsDesc(propName);
					propName = RemoveDirection(propName);

					if (idx == 1)
					{
						if (isDesc)
							query = l.OrderByDescending(QueryPath(propName));
						else
							query = l.OrderBy(QueryPath(propName));
					}
					else
					{
						if (isDesc)
							query = query.ThenByDescending(QueryPath(propName));
						else
							query = query.ThenBy(QueryPath(propName));
					}

					idx++;
				}

				return query.ToList();
			}

			private static bool IsDesc(object o)
			{
				return o is string s
					&& s.ToUpper().EndsWith(" DESC");
			}

			private static string RemoveDirection(string s)
			{
				var upper = s.ToUpper();
				if (upper.EndsWith(" DESC"))
					return s[..(s.Length - 5)].Trim();
				if (upper.EndsWith(" ASC"))
					return s[..(s.Length - 4)].Trim();

				return s;
			}

			private static Func<EntityRecord, object> QueryPath(string path)
			{
				var pathSegments = path.Replace(" ", string.Empty)
					.Replace("[0]", string.Empty)
					.Split('.');

				object GetProperty(EntityRecord rec)
				{
					object result = rec;

					foreach(var segment in pathSegments)
					{
						if(result is List<EntityRecord> l)
						{
							if (segment.Contains('['))
							{
								if (!int.TryParse(segment[(segment.IndexOf('[') + 1)..segment.LastIndexOf(']')], out var idx))
									return null;

								if (idx < 0 || idx >= l.Count)
									return null;

								result = l[idx];
								continue;
							}

							if (l.Count == 0) 
								return null;
							result = l[0];
						}

						if (result is not EntityRecord r)
							return null;

						if (!r.Properties.TryGetValue(segment, out result))
							return null;
					}

					return result;
				}

				return GetProperty;
			}
		}

		private sealed class CoalesceFunction : QueryFunction
		{
			public CoalesceFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "coalesce";

			protected override int MinParameters => 2;

			protected override int MaxParameters => -1;

			protected override object Execute(object[] parameters)
			{
				foreach(var val in parameters)
				{
					if (val != null && (val is not IEnumerable en || !en.Any()))
						return val;
				}
				return null;
			}
		}

		private sealed class IncludeFunction : QueryFunction
		{
			public IncludeFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "include";

			protected override int MinParameters => 2;

			protected override int MaxParameters => MinParameters;

			protected override object Execute(object[] parameters)
			{
				if (parameters[0] is not List<EntityRecord> l)
					throw new PropertyDoesNotExistException($"function {Name} requires List<EntityRecord> as first argument");

				if (parameters[1] is not string relationName)
					throw new PropertyDoesNotExistException($"function {Name} requires string as second argument");

				if (!relationName.StartsWith('$'))
					throw new PropertyDoesNotExistException($"function {Name} second argument requires a relation");

				if (l.Count == 0)
					return l;

				relationName = relationName.TrimStart('$');

				var relation = DataModel.relMan.Read().Object
					.Single(r => r.Name == relationName);

				var ids = l.Select(r => (Guid)r[relation.TargetFieldName])
					.Distinct()
					.ToArray();

				var subQuery = ids.Select(id =>
					new QueryObject()
					{
						QueryType = QueryType.EQ,
						FieldName = relation.OriginFieldName,
						FieldValue = id,
					}).ToList();

				var query = subQuery.Count == 1 ? subQuery[0] : new QueryObject()
				{
					QueryType = QueryType.OR,
					SubQueries = subQuery
				};

				var response = DataModel.recMan.Find(new EntityQuery(relation.OriginEntityName, "*", query));

				if(response.Success && response.Object?.Data != null)
				{
					var lookup = response.Object.Data
						.ToDictionary(r => (Guid)r[relation.OriginFieldName], r => r);

					foreach(var r in l)
					{
						var id = (Guid)r[relation.TargetFieldName];
						if (lookup.TryGetValue(id, out var relatedRec))
							r[$"${relationName}"] = relatedRec;

					}
				}

				return l;
			}
		}

		private sealed class WhenFunction : QueryFunction
		{
			public WhenFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "when";

			protected override int MinParameters => 2;

			protected override int MaxParameters => 3;

			protected override object Execute(object[] parameters)
			{
				if (parameters[0] is not bool contidion)
					throw new PropertyDoesNotExistException($"function '{Name}' requires a boolean value at first argument");

				return contidion ? parameters[1] : parameters[2];
			}
		}

		#endregion
	}


	public class PropertyDoesNotExistException : Exception
	{
		public PropertyDoesNotExistException(string message) : base(message) { }
	}
}
