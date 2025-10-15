using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Wangkanai.Extensions;
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
			this.erpPageModel = erpPageModel ?? throw new ArgumentException(nameof(erpPageModel));
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
				properties.Add("Host", new MPW(MPT.Object, erpPageModel.HttpContext?.Request?.Host.Value));

				properties.Add("IsDesktop", new MPW(MPT.Object, !reqCtx.IsNonDesktopDevice));

				properties.Add("$not", new MPW(MPT.Function, new NotFunction(this)));
				properties.Add("$and", new MPW(MPT.Function, new AndFunction(this)));
				properties.Add("$or", new MPW(MPT.Function, new OrFunction(this)));
				properties.Add("$gt", new MPW(MPT.Function, new GreaterThanFunction(this)));
				properties.Add("$ge", new MPW(MPT.Function, new GreaterThanOrEqualFunction(this)));
				properties.Add("$lt", new MPW(MPT.Function, new LessThanFunction(this)));
				properties.Add("$le", new MPW(MPT.Function, new LessThanOrEqualFunction(this)));

				properties.Add("$exists", new MPW(MPT.Function, new ExistsFunction(this)));
				properties.Add("$concat", new MPW(MPT.Function, new ConcatFunction(this)));
				properties.Add("$coalesce", new MPW(MPT.Function, new CoalesceFunction(this)));
				properties.Add("$when", new MPW(MPT.Function, new WhenFunction(this)));
				properties.Add("$hasRole", new MPW(MPT.Function, new HasRoleFunction(this)));
				properties.Add("$areEqual", new MPW(MPT.Function, new AreEqualFunction(this)));
				properties.Add("$encodeUrl", new MPW(MPT.Function, new EncodeUrlFunction(this)));

				properties.Add("$filter", new MPW(MPT.Function, new FilterFunction(this)));
				properties.Add("$count", new MPW(MPT.Function, new CountFunction(this)));
				properties.Add("$sum", new MPW(MPT.Function, new SumFunction(this)));
				properties.Add("$any", new MPW(MPT.Function, new AnyFunction(this)));
				properties.Add("$all", new MPW(MPT.Function, new AllFunction(this)));
				properties.Add("$orderBy", new MPW(MPT.Function, new OrderByFunction(this)));
				properties.Add("$thenOrderBy", new MPW(MPT.Function, new ThenOrderByFunction(this)));
				properties.Add("$orderByDescending", new MPW(MPT.Function, new OrderByDescendingFunction(this)));
				properties.Add("$thenOrderByDescending", new MPW(MPT.Function, new ThenOrderByDescendingFunction(this)));
				properties.Add("$include", new MPW(MPT.Function, new IncludeFunction(this)));

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

				properties.Add("CurrentUrl", new MPW(MPT.Object, erpPageModel.CurrentUrl));
				properties.Add("CurrentUrlEncoded", new MPW(MPT.Object, HttpUtility.UrlEncode(erpPageModel.CurrentUrl)));
				properties.Add("ReturnUrl", new MPW(MPT.Object, erpPageModel.ReturnUrl));
				properties.Add("ReturnUrlEncoded", new MPW(MPT.Object, HttpUtility.UrlEncode(erpPageModel.ReturnUrl)));

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
						if (string.IsNullOrWhiteSpace(variable.String))
							return null;
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


		private static bool HasTopLevelInterpolation(string propName)
		{
			var isWithinString = false;
			var index = 0;

			while(index < propName.Length)
			{
				if (propName[index] == '{' && index + 1 < propName.Length && propName[index + 1] == '{')
				{
					if (!isWithinString)
						return true;
					index = IndexOfNextCloseDoubleCurley(propName, index + 2);
					if (index < 0)
						return false;
					index += 2;
				}
				else if (propName[index] == '"')
				{
					isWithinString = !isWithinString;
					index++;
				}
				else index++;
			}
			return false;
		}

		private static int IndexOfNextCloseDoubleCurley(string propName, int index)
		{
			var depth = 0;
			while(index < propName.Length)
			{
				if (propName[index] == '}' && index + 1 < propName.Length && propName[index + 1] == '}')
				{
					if (depth == 0)
						return index;
					depth--;
					index += 2;
				}
				else if (propName[index] == '{' && index + 1 < propName.Length && propName[index + 1] == '{')
				{
					depth++;
					index += 2;
				}
				else index++;
			}
			return -1;
		}

		public object GetProperty(string propName)
		{
			if (string.IsNullOrWhiteSpace(propName))
				throw new ArgumentException($"Argument '{nameof(propName)}' must not be null or whitespace");

			if (!HasTopLevelInterpolation(propName))
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
					var depth = 0;
					var end = idx;
					while(end < propName.Length - 1 && !(propName[end] == '}' && propName[end + 1] == '}' && depth <= 0) )
					{
						if(end < propName.Length - 1)
						{
							if (propName[end] == '{' && propName[end + 1] == '{')
								depth++;
							else if (propName[end] == '}' && propName[end + 1] == '}')
								depth--;
						}
						end++;
					}

					if (end <= idx || end >= propName.Length - 1 || propName[end] != '}' || propName[end + 1] != '}' )
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

			if(propName.StartsWith('"') && propName.EndsWith('"') || propName.StartsWith('\'') && propName.EndsWith('\''))
			{
				var stringVal = propName[1..(propName.Length - 1)];
				if (!stringVal.Contains("{{"))
					return stringVal;
				return GetProperty(stringVal);
			}

			if (decimal.TryParse(propName, out var dec))
				return dec;

			if(bool.TryParse(propName, out var b))
				return b;

			if(Guid.TryParse(propName, out var id))
				return id;

			if (propName.StartsWith('$'))
			{
				if (properties.TryGetValue(propName, out var mpv) && mpv.Value is Function fun)
					return fun;

				if (propName.EndsWith(')'))
					return ExecFunction(propName);
			}

			if (propName.Contains("=>"))
			{
				var arrowIdx = propName.IndexOf("=>");
				var ident = propName[..arrowIdx].TrimEnd();
				var body = propName[(arrowIdx + 2)..].TrimStart();
				return new Lambda(this, ident, body);
			}

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

			if(completePropChain.Count == 2 && completePropChain[0] == "RequestQuery")
			{
				var rec = properties["RequestQuery"]?.Value as EntityRecord;
				if (rec != null && rec.Properties.TryGetValue(completePropChain[1], out var val))
					return val;
				return null;
			}

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
									return null;

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
								{
									if (i == completePropChain.Count - 1 && rec.Properties.TryGetValue(accessor, out var value))
										return value;
									return null;
								}

								var (entityId, nextIdName, sourceIdName) = OtherSideOfRelation(relResponse.Object, entity);
								var resultEntity = entMan.ReadEntity(entityId)?.Object;

								if (resultEntity == null)
									return null;

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
										return null;

									resultList = response.Object.Data;
								}

								alreadyResolvedRecordProperties[currentPath] = (resultList, resultEntity);
								entity = resultEntity;
								result = resultList;
							}
							else if (accessor.StartsWith('[') && accessor.EndsWith(']'))
							{
								if (result is not List<EntityRecord> records)
									return null;

								var index = int.Parse(accessor[1..(accessor.Length - 1)].Trim());
								if (index >= records.Count)
									return null;
								result = records[index];
							}
							else if (result is EntityRecord rec)
							{
								if (i < completePropChain.Count - 1)
									return null;

								result = rec[accessor];
							}
							else if (result is List<EntityRecord> recList)
							{
								if (i < completePropChain.Count - 1)
									return null;

								if (recList.Count == 0)
									return null;

								var first = recList[0];
								if (recList.Count == 1)
									return first?[accessor];

								return recList.Select(r => r?[accessor])
									.ToList();
							}
							else return null;
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
									return null;

								result = obj;
							}
							else if (accessor.StartsWith('[') && accessor.EndsWith(']'))
							{
								if (result is not List<EntityRecord> records)
									return null;

								var index = int.Parse(accessor[1..(accessor.Length - 1)].Trim());
								if (index >= records.Count)
									return null;
								result = records[index];
							}
							else if (result is EntityRecord rec)
							{
								if (i < completePropChain.Count - 1)
									return null;

								result = rec[accessor];
							}
							else if (result is List<EntityRecord> recList)
							{
								if(i < completePropChain.Count - 1)
									return null;

								if (recList.Count == 0)
									return null;

								var first = recList[0];
								if (recList.Count == 1)
									return first?[accessor];

								return recList.Select(r => r?[accessor])
									.ToList();
							}
							else return null;
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
					return null;
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
			var openParIdx = propName.IndexOf('(');
			var funName = propName[..openParIdx].Trim();

			if (!properties.TryGetValue(funName, out var mpv) || mpv.Value is not Function fun)
				throw new PropertyDoesNotExistException($"function '{funName}' does not exist in given context");

			var closeParIdx = propName.LastIndexOf(')');
			var paramsString = propName[(openParIdx + 1)..closeParIdx].Trim();

			return fun.Execute(paramsString);
		}

		private object ExecDataSource(DSW dsWrapper)
		{
			if (dsWrapper.Result != null)
				return dsWrapper.Result;

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
					try { dsWrapper.Result = codeDS.Execute(arguments); } catch { return null; }
				else
					dsWrapper.Result = codeDS.Execute(arguments);

				return dsWrapper.Result;
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
				dsWrapper.Result = dsMan.Execute(dbDs.Id, eqlParameters);
				return dsWrapper.Result;
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
			Lambda
		}

		//DataSourceWrapper
		private class DSW
		{
			public DataSourceBase DataSource { get; set; }

			public PageDataSource PageDataSource { get; set; }

			public object Result { get; set; }
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

		public sealed class LazyObject
		{
			private bool _executed = false;
			private object _value;
			private readonly Func<object> _evalFun;

			public LazyObject(Func<object> func)
			{
				_evalFun = func;
			}

			public object Value
			{
				get
				{
					if (!_executed)
					{
						_value = _evalFun();
						_executed = true;
					}
					return _value;
				}
			}
		}

		private class Lambda(PageDataModel dataModel, string ident, string body)
		{
			public object Execute(object instanceObject)
			{
				var old = dataModel.properties.TryGetValueSafe(ident, out var mpv) ? mpv : null;
				dataModel.properties.Remove(ident);

				if (instanceObject is EntityRecord)
					dataModel.properties.Add(ident, new MPW(MPT.EntityRecord, instanceObject));
				else
					dataModel.properties.Add(ident, new MPW(MPT.Object, instanceObject));
				var result = dataModel.ResolveProperty(body);

				dataModel.properties.Remove(ident);

				if (old != null)
					dataModel.properties.Add(ident, old);

				return result;
			}
		}


		//Function classes
		private abstract class Function
		{

			protected Function(PageDataModel dataModel)
			{
				DataModel = dataModel;
			}

			protected PageDataModel DataModel { get; }

			public abstract int MinParameters { get; }

			public abstract int MaxParameters { get; }

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

					if(c == '\'' || c == '"')
					{
						var closeIdx = IndexOfStringClosing(paramsString, idx);
						if (closeIdx <= idx)
							throw new PropertyDoesNotExistException("Could not interpret property value");
						idx = closeIdx;
					}
					else
					{
						if (c == '(')
							parDepth++;
						else if (c == ')')
							parDepth--;
						else if (c == ',' && parDepth == 0)
						{
							result.Add(paramsString[start..idx].Trim());
							start = idx + 1;
						}
					}
					idx++;
				}

				if (parDepth == 0)
					result.Add(paramsString[start..idx].Trim());

				return result;
			}

			private static int IndexOfStringClosing(string paramsString, int stringOpenIndex)
			{
				var i = stringOpenIndex + 1;

				while(i < paramsString.Length)
				{
					if (i < paramsString.Length - 1 && paramsString[i] == '{' && paramsString[i + 1] == '{')
					{
						i += 2;
						var depth = 0;
						var end = i;
						while (end < paramsString.Length - 1 && !(paramsString[end] == '}' && paramsString[end + 1] == '}' && depth <= 0))
						{
							if (end < paramsString.Length - 1)
							{
								if (paramsString[end] == '{' && paramsString[end + 1] == '{')
									depth++;
								else if (paramsString[end] == '}' && paramsString[end + 1] == '}')
									depth--;
							}
							end++;
						}

						if (end <= i || end >= paramsString.Length - 1 || paramsString[end] != '}' || paramsString[end + 1] != '}')
							return -1;
					}
					else if (paramsString[i] == '\'' || paramsString[i] == '"')
						return i;

					i++;
				}
				return -1;
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

				var args = parameters.Select(p => new LazyObject(() => DataModel.GetProperty(p)))
					.ToArray();

				return Execute(args);
			}

			public abstract object Execute(LazyObject[] parameters);
		}

		private sealed class EncodeUrlFunction : Function
		{
			public EncodeUrlFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 1;

			public override int MaxParameters => 1;

			public override string Name => "encodeUrl";

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not string s)
					throw new PropertyDoesNotExistException($"function {Name} requires string");

				return HttpUtility.UrlEncode(s);
			}
		}

		private sealed class ExistsFunction : Function
		{
			public ExistsFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "exists";

			public override int MinParameters => 1;

			public override int MaxParameters => MinParameters;

			public override object Execute(LazyObject[] parameters)
			{
				var para = parameters[0].Value;
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

		private sealed class NotFunction : Function
		{
			public NotFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "not";

			public override int MinParameters => 1;

			public override int MaxParameters => MinParameters;

			public override object Execute(LazyObject[] parameters)
			{
				return parameters[0].Value is bool b ? !b
					: throw new PropertyDoesNotExistException($"function {Name} requires boolean");
			}
		}

		private sealed class OrderByFunction : Function
		{
			public OrderByFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "orderBy";

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function {Name} requires any collection as first argument");

				if (parameters[1].Value is string orderString)
				{
					if (en is not List<EntityRecord> l)
						throw new PropertyDoesNotExistException($"function {Name} requires List<EntityRecord> as first argument when second argument is string");

					if (string.IsNullOrWhiteSpace(orderString))
						throw new PropertyDoesNotExistException($"function {Name} second argument (string) must not be empty");
					
					if (l.Count == 0)
						return l;

					IOrderedEnumerable<EntityRecord> query = null;
					var orderArgs = orderString.Split(',', StringSplitOptions.TrimEntries);

					for(var i = 0; i < orderArgs.Length; i++)
					{
						var propName = orderArgs[i];

						var isDesc = IsDesc(propName);
						propName = RemoveDirection(propName);

						if (i == 0)
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
					}

					return query.ToList();
				}

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function {Name} second argument requires lambda or string");

				if (en is List<EntityRecord> lR)
					return Enumerable.OrderBy(lR, lambda.Execute);

				if (en is IEnumerable<EntityRecord> enR)
					return Enumerable.OrderBy(enR, lambda.Execute);

				return en.OrderBy(lambda.Execute);
			}

			private static bool IsDesc(string s)
				=> s.EndsWith(" DESC", StringComparison.OrdinalIgnoreCase);

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

					foreach (var segment in pathSegments)
					{
						if (result is List<EntityRecord> l)
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

		private sealed class OrderByDescendingFunction : Function
		{ 
			public OrderByDescendingFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "orderByDescending";

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function {Name} requires any collection as first argument");

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function {Name} second argument requires lambda");

				if (en is List<EntityRecord> l)
					return Enumerable.OrderByDescending(l, lambda.Execute);

				if (en is IEnumerable<EntityRecord> enR)
					return Enumerable.OrderByDescending(enR, lambda.Execute);

				return en.OrderByDescending(lambda.Execute);
			}
		}

		private sealed class ThenOrderByDescendingFunction : Function
		{
			public ThenOrderByDescendingFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "thenOrderByDescending";

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not IOrderedEnumerable<object> en)
					throw new PropertyDoesNotExistException($"function {Name} requires any ordered collection as first argument");

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function {Name} second argument requires lambda");

				if (en is IOrderedEnumerable<EntityRecord> enR)
					return Enumerable.ThenByDescending(enR, lambda.Execute);

				return en.ThenByDescending(lambda.Execute);
			}
		}

		private sealed class ThenOrderByFunction : Function
		{
			public ThenOrderByFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "thenOrderBy";

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not IOrderedEnumerable<object> en)
					throw new PropertyDoesNotExistException($"function {Name} requires any ordered collection as first argument");

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function {Name} second argument requires lambda");

				if (en is IOrderedEnumerable<EntityRecord> enR)
					return Enumerable.ThenBy(enR, lambda.Execute);

				return en.ThenBy(lambda.Execute);
			}
		}

		private sealed class CoalesceFunction : Function
		{
			public CoalesceFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "coalesce";

			public override int MinParameters => 2;

			public override int MaxParameters => -1;

			public override object Execute(LazyObject[] parameters)
				=> parameters.Select(p => p.Value).FirstOrDefault(v => v != null);
		}

		private sealed class IncludeFunction : Function
		{
			public IncludeFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "include";

			public override int MinParameters => 2;

			public override int MaxParameters => MinParameters;

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not List<EntityRecord> l)
					throw new PropertyDoesNotExistException($"function {Name} requires List<EntityRecord> as first argument");

				if (parameters[1].Value is not string relationPaths)
					throw new PropertyDoesNotExistException($"function {Name} requires string as second argument");

				return l.Include(relationPaths);
			}
		}

		private sealed class WhenFunction : Function
		{
			public WhenFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "when";

			public override int MinParameters => 2;

			public override int MaxParameters => 3;

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value is not bool contidion)
					throw new PropertyDoesNotExistException($"function '{Name}' requires a boolean value at first argument");

				return contidion ? parameters[1].Value : parameters[2].Value;
			}
		}

		private sealed class HasRoleFunction : Function
		{
			public HasRoleFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "hasRole";

			public override int MinParameters => 1;

			public override int MaxParameters => 1;

			public override object Execute(LazyObject[] parameters)
			{
				if (DataModel.GetProperty("CurrentUser") is not ErpUser user) 
					return false;

				if (parameters[0].Value is not string role || string.IsNullOrEmpty(role))
					throw new PropertyDoesNotExistException($"function '{Name}' requires string as argument");

				return user.Roles.Exists(r => r.Name == "administrator" || r.Name == role);
			}
		}

		private sealed class AreEqualFunction : Function
		{
			public AreEqualFunction(PageDataModel dataModel)
				: base(dataModel) 
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override string Name => "areEqual";

			public override object Execute(LazyObject[] parameters)
			{
				var a = parameters[0].Value;
				var b = parameters[1].Value;

				if (a == null ^ b == null)
					return false;

				if (a == null)
					return true;

				a = CastToDecimalIfIsNumber(a);
				b = CastToDecimalIfIsNumber(b);

				return a is IEnumerable enA && b is IEnumerable enB && enA.SequenceEquals(enB)
					|| a.Equals(b);
			}
		}

		private static object? CastToDecimalIfIsNumber(object obj)
		{
			return obj switch
			{
				sbyte sb => (decimal)sb,
				byte b => (decimal)b,
				short s => (decimal)s,
				ushort us => (decimal)us,
				int i => (decimal)i,
				uint ui => (decimal)ui,
				long l => (decimal)l,
				ulong ul => (decimal)ul,
				_ => obj,
			};
		}

		private abstract class CompareFunction : Function
		{
			protected CompareFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			protected abstract bool InterpretResult(int compareResult);

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value != null && parameters[0].Value is not IComparable)
					throw new PropertyDoesNotExistException($"function {Name} argument 1 requires comparable type");

				if (parameters[1].Value != null && parameters[1].Value is not IComparable)
					throw new PropertyDoesNotExistException($"function {Name} argument 2 requires comparable type");

				var a = CastToDecimalIfIsNumber(parameters[0].Value) as IComparable;
				var b = CastToDecimalIfIsNumber(parameters[1].Value) as IComparable;

				if (a == null && b == null)
					return InterpretResult(0);

				if(a == null)
					return InterpretResult(-b.CompareTo(a));

				return InterpretResult(a.CompareTo(b));
			}
		}

		private sealed class GreaterThanFunction : CompareFunction
		{
			public GreaterThanFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "gt";

			protected override bool InterpretResult(int compareResult) 
				=> compareResult > 0;
		}

		private sealed class LessThanFunction : CompareFunction
		{
			public LessThanFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "lt";

			protected override bool InterpretResult(int compareResult)
				=> compareResult < 0;
		}

		private sealed class GreaterThanOrEqualFunction : CompareFunction
		{
			public GreaterThanOrEqualFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "ge";

			protected override bool InterpretResult(int compareResult)
				=> compareResult >= 0;
		}

		private sealed class LessThanOrEqualFunction : CompareFunction
		{
			public LessThanOrEqualFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override string Name => "le";

			protected override bool InterpretResult(int compareResult)
				=> compareResult <= 0;
		}

		private sealed class AndFunction : Function
		{
			public AndFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => -1;

			public override string Name => "and";

			public override object Execute(LazyObject[] parameters)
				=> Array.TrueForAll(parameters, param => param.Value is bool b && b);
		}

		private sealed class ConcatFunction : Function
		{
			public ConcatFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => -1;

			public override string Name => "concat";

			public override object Execute(LazyObject[] parameters)
			{
				var param = parameters.FirstOrDefault(p => p.Value != null);

				if(param.Value is List<EntityRecord>)
				{
					IEnumerable<EntityRecord> result = [];
					foreach (var l in parameters.Select(p => p.Value as List<EntityRecord>).Where(v => v != null))
						result = result.Concat(l);
					return result.ToList();
				}

				return string.Concat(parameters.Select(p => p.Value?.ToString() ?? string.Empty));
			}
		}

		private sealed class OrFunction : Function
		{
			public OrFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => -1;

			public override string Name => "or";

			public override object Execute(LazyObject[] parameters)
				=> Array.Exists(parameters, param => param.Value is bool b && b);
		}

		private sealed class SumFunction: Function
		{
			public SumFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 1;

			public override int MaxParameters => 2;

			public override string Name => "sum";

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value == null)
					return null;

				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function '{Name}' requires any collection as first argument");

				if (parameters.Length == 1)
				{
					if (parameters[0].Value is IEnumerable<decimal> decs)
						return decs.Sum();

					if (parameters[0].Value is IEnumerable<int> ints)
						return ints.Sum();

					if (parameters[0].Value is IEnumerable<double> doubles)
						return (decimal)doubles.Sum();

					if (parameters[0].Value is IEnumerable<float> floats)
						return (decimal)floats.Sum();

					if (parameters[0].Value is IEnumerable<long> longs)
						return (decimal)longs.Sum();

					if (parameters[0].Value is IEnumerable<ulong> ulongs)
						return ulongs.Sum(ul => (decimal)ul);

					if (parameters[0].Value is IEnumerable<uint> uints)
						return uints.Sum(ui => (decimal)ui);

					if (parameters[0].Value is IEnumerable<byte> bytes)
						return bytes.Sum(by => (decimal)by);

					if (parameters[0].Value is IEnumerable<sbyte> sbytes)
						return sbytes.Sum(sby => (decimal)sby);


					if (parameters[0].Value is IEnumerable<EntityRecord> recs)
					{
						var result = 0m;

						foreach(var r in recs)
						{
							if (r.Properties.Count != 1)
								throw new PropertyDoesNotExistException($"Use a selector function on records which have more than one property");

							var prop = r.Properties.First();

							if(prop.Value != null)
							{
								if (prop.Value is decimal d) result += d;
								else if (prop.Value is double lr) result += (decimal)lr;
								else if (prop.Value is float f) result += (decimal)f;
								else if (prop.Value is long l) result += l;
								else if (prop.Value is ulong ul) result += ul;
								else if (prop.Value is int i) result += i;
								else if (prop.Value is uint ui) result += ui;
								else if (prop.Value is short sh) result += sh;
								else if (prop.Value is ushort ush) result += ush;
								else if (prop.Value is byte by) result += by;
								else if (prop.Value is sbyte sby) result += sby;

								else
									throw new PropertyDoesNotExistException($"Properties must be a integral type to be summed up");
							}
						}

						return result;
					}

					return null;
				}

				if(parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function '{Name}' requires lambda as second argument");

				if (parameters[0].Value is not IEnumerable<EntityRecord> records)
					throw new PropertyDoesNotExistException($"function '{Name}' requires collection of entity record as first argument when selector is used");

				return records.Sum(obj =>
				{
					var result = lambda.Execute(obj);

					if (result is decimal d) return d;
					if (result is double lr) return (decimal)lr;
					if (result is float f) return (decimal)f;
					if (result is long l) return l;
					if (result is ulong ul) return ul;
					if (result is int i) return i;
					if (result is uint ui) return ui;
					if (result is short sh) return sh;
					if (result is ushort ush) return ush;
					if (result is byte by) return by;
					if (result is sbyte sby) return sby;

					return 0m;
				});
			}
		}

		private sealed class AllFunction: Function
		{
			public AllFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override string Name => "all";

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value == null)
					return null;

				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function '{Name}' requires any collection as first argument");

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function '{Name}' requires lambda as second argument");

				if (!en.Any())
					return false;

				foreach(var obj in en)
				{
					var result = lambda.Execute(obj);
					if (result is not true)
						return false;
				}

				return true;
			}
		}


		private sealed class CountFunction: Function
		{
			public CountFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 1;

			public override int MaxParameters => 2;

			public override string Name => "count";

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value == null)
					return null;

				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function '{Name}' requires any collection as first argument");

				if (parameters.Length == 1)
				{
					if (en is IList l)
						return l.Count;

					return en.Count();
				}

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function '{Name}' requires lambda as second argument");

				return en.Count(obj =>
				{
					var result = lambda.Execute(obj);
					if (result == null) return false;
					if (result is not bool b)
						throw new PropertyDoesNotExistException($"boolean result expected within lambda expression at function '{Name}'");
					return b;
				});
			}
		}

		private sealed class FilterFunction : Function
		{
			public FilterFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 2;

			public override int MaxParameters => 2;

			public override string Name => "filter";

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value == null)
					return null;

				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function '{Name}' requires any collection as first argument");

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function '{Name}' requires lambda as second argument");

				var result = en.Where(rec =>
				{
					var result = lambda.Execute(rec);
					if (result == null) return false;
					if (result is not bool b)
						throw new PropertyDoesNotExistException($"boolean result expected within lambda expression at function '{Name}'");
					return b;
				});

				if (en is not List<EntityRecord>)
					return result;

				return result.Select(o => o as EntityRecord).ToList();
			}
		}

		private sealed class AnyFunction : Function
		{
			public AnyFunction(PageDataModel dataModel)
				: base(dataModel)
			{ }

			public override int MinParameters => 1;

			public override int MaxParameters => 2;

			public override string Name => "any";

			public override object Execute(LazyObject[] parameters)
			{
				if (parameters[0].Value == null)
					return null;

				if (parameters[0].Value is not IEnumerable en)
					throw new PropertyDoesNotExistException($"function '{Name}' requires any collection as first argument");

				if (parameters.Length == 1)
					return en.Any();

				if (parameters[1].Value is not Lambda lambda)
					throw new PropertyDoesNotExistException($"function '{Name}' requires lambda as second argument");

				return en.Any(rec =>
				{
					var result = lambda.Execute(rec);
					if (result == null) return false;
					if (result is not bool b)
						throw new PropertyDoesNotExistException($"boolean result expected within lambda expression at function '{Name}'");
					return b;

				});
			}
		}

		#endregion
	}


	public class PropertyDoesNotExistException : Exception
	{
		public PropertyDoesNotExistException(string message) : base(message) { }
	}
}
