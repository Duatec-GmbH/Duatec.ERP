using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebVella.Erp;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Api.Models.AutoMapper;
using WebVella.Erp.Database;
using WebVella.Erp.Plugins.Duatec;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Web;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Models.AutoMapper;


var location = System.Reflection.Assembly.GetEntryAssembly()!.Location;
var path = location[..location.LastIndexOf('\\')];
var config = JObject.Parse(File.ReadAllText(path + "\\Config.json"));
var connectionString = ((JObject)config["Settings"])["ConnectionString"]!.ToString();
var context = DbContext.CreateContext(connectionString);

ErpSettings.Initialize(new ConfigurationBuilder().AddJsonFile(path + "\\Config.json").Build());
ErpAutoMapperConfiguration.Configure(ErpAutoMapperConfiguration.MappingExpressions);
ErpWebAutoMapperConfiguration.Configure(ErpAutoMapperConfiguration.MappingExpressions);
ErpAutoMapper.Initialize(ErpAutoMapperConfiguration.MappingExpressions);
ErpAppContext.Init();

using (SecurityContext.OpenSystemScope())
{
    using var connection = context.CreateConnection();
    connection.BeginTransaction();

    var entMan = new EntityManager(context);
    var relMan = new EntityRelationManager(context);
    var recMan = new RecordManager(context, true, false);

    try
    {
        // insert code between braces here

        #region Datamodel
        {

            #region << ***Create field***  Entity: order Field Name: type_id >>
            {
                InputGuidField guidField = new InputGuidField();
                guidField.Id = new Guid("cd2c4d4a-40fd-418a-844c-10a22d34468c");
                guidField.Name = "type_id";
                guidField.Label = "Type";
                guidField.PlaceholderText = null;
                guidField.Description = null;
                guidField.HelpText = null;
                guidField.Required = false;
                guidField.Unique = false;
                guidField.Searchable = true;
                guidField.Auditable = false;
                guidField.System = false;
                guidField.DefaultValue = null;
                guidField.GenerateNewId = false;
                guidField.EnableSecurity = false;
                guidField.Permissions = new FieldPermissions();
                guidField.Permissions.CanRead = new List<Guid>();
                guidField.Permissions.CanUpdate = new List<Guid>();
                //READ
                //UPDATE
                {
                    var response = entMan.CreateField(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559"), guidField, false);
                    if (!response.Success)
                        throw new Exception("System error 10060. Entity: order Field: type_id Message:" + response.Message);
                }
            }
            #endregion

            #region << ***Create entity*** Entity name: order_type >>
            {
                #region << entity >>
                {
                    var entity = new InputEntity();
                    var systemFieldIdDictionary = new Dictionary<string, Guid>();
                    systemFieldIdDictionary["id"] = new Guid("a61350f5-b38e-4daa-aca0-e5b7c343ee65");
                    entity.Id = new Guid("5846074f-9e41-4582-9c4f-f99101dfb2ad");
                    entity.Name = "order_type";
                    entity.Label = "Order Type";
                    entity.LabelPlural = "Order Types";
                    entity.System = false;
                    entity.IconName = "fas fa-clipboard-list";
                    entity.Color = "";
                    entity.RecordScreenIdField = null;
                    entity.RecordPermissions = new RecordPermissions();
                    entity.RecordPermissions.CanCreate = new List<Guid>();
                    entity.RecordPermissions.CanRead = new List<Guid>();
                    entity.RecordPermissions.CanUpdate = new List<Guid>();
                    entity.RecordPermissions.CanDelete = new List<Guid>();
                    //Create
                    entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                    entity.RecordPermissions.CanCreate.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                    //READ
                    entity.RecordPermissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                    entity.RecordPermissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                    entity.RecordPermissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                    entity.RecordPermissions.CanRead.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                    entity.RecordPermissions.CanRead.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                    entity.RecordPermissions.CanRead.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                    entity.RecordPermissions.CanRead.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                    entity.RecordPermissions.CanRead.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                    entity.RecordPermissions.CanRead.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                    //UPDATE
                    entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                    entity.RecordPermissions.CanUpdate.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                    //DELETE
                    entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                    entity.RecordPermissions.CanDelete.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                    {
                        var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                        if (!response.Success)
                            throw new Exception("System error 10050. Entity: order_type creation Message: " + response.Message);
                    }
                }
                #endregion
            }
            #endregion

            #region << ***Create field***  Entity: order_type Field Name: name >>
            {
                InputTextField textboxField = new InputTextField();
                textboxField.Id = new Guid("ea62b5f5-cb89-4d02-89bd-0852e796a0e5");
                textboxField.Name = "name";
                textboxField.Label = "Name";
                textboxField.PlaceholderText = null;
                textboxField.Description = null;
                textboxField.HelpText = null;
                textboxField.Required = true;
                textboxField.Unique = true;
                textboxField.Searchable = true;
                textboxField.Auditable = false;
                textboxField.System = false;
                textboxField.DefaultValue = "";
                textboxField.MaxLength = null;
                textboxField.EnableSecurity = false;
                textboxField.Permissions = new FieldPermissions();
                textboxField.Permissions.CanRead = new List<Guid>();
                textboxField.Permissions.CanUpdate = new List<Guid>();
                //READ
                //UPDATE
                {
                    var response = entMan.CreateField(new Guid("5846074f-9e41-4582-9c4f-f99101dfb2ad"), textboxField, false);
                    if (!response.Success)
                        throw new Exception("System error 10060. Entity: order_type Field: name Message:" + response.Message);
                }
            }
            #endregion

            #region << ***Create relation*** Relation name: order_type >>
            {
                var relation = new EntityRelation();
                var originEntity = entMan.ReadEntity(new Guid("5846074f-9e41-4582-9c4f-f99101dfb2ad")).Object;
                var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                var targetEntity = entMan.ReadEntity(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559")).Object;
                var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "type_id");
                relation.Id = new Guid("27ea366c-fa31-4884-b8e0-b9548a15267f");
                relation.Name = "order_type";
                relation.Label = "order_type";
                relation.Description = "";
                relation.System = false;
                relation.RelationType = EntityRelationType.OneToMany;
                relation.OriginEntityId = originEntity.Id;
                relation.OriginEntityName = originEntity.Name;
                relation.OriginFieldId = originField.Id;
                relation.OriginFieldName = originField.Name;
                relation.TargetEntityId = targetEntity.Id;
                relation.TargetEntityName = targetEntity.Name;
                relation.TargetFieldId = targetField.Id;
                relation.TargetFieldName = targetField.Name;
                {
                    var response = relMan.Create(relation);
                    if (!response.Success)
                        throw new Exception("System error 10060. Relation: order_type Create. Message:" + response.Message);
                }
            }
            #endregion

            #region << ***Create record*** Id: af1d9492-65bc-41e5-ad7f-da15ecb38994 (order_type) >>
            {
                var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""af1d9492-65bc-41e5-ad7f-da15ecb38994"",
  ""name"": ""Installation""
}";
                EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
                var result = recMan.CreateRecord("order_type", rec);
                if (!result.Success) throw new Exception(result.Message);
            }
            #endregion

            #region << ***Create record*** Id: 10c96a72-10f9-4025-a699-6b386eabfd9d (order_type) >>
            {
                var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""10c96a72-10f9-4025-a699-6b386eabfd9d"",
  ""name"": ""Schaltschrank""
}";
                EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
                var result = recMan.CreateRecord("order_type", rec);
                if (!result.Success) throw new Exception(result.Message);
            }
            #endregion

            #region << ***Create data source*** Name: AllOrderTypes >>
            {
                var id = new Guid("1ab4d2cd-54ba-48e8-8cfe-b2c0a16148c7");
                var name = @"AllOrderTypes";
                var description = @"All Order Types";
                var eqlText = @"SELECT *
FROM order_type
ORDER BY name";
                var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_order_type.""id"" AS ""id"",
	 rec_order_type.""name"" AS ""name"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_order_type
ORDER BY rec_order_type.""name"" ASC
) X
";
                var parametersJson = @"[]";
                var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                var weight = 10;
                var returnTotal = true;
                var entityName = @"order_type";

                new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
            }
            #endregion

            #region << ***Update data source*** Name: AllOrders >>
            {
                var id = new Guid("8bf1e682-1980-4168-a7fb-23be211dbe87");
                var name = @"AllOrders";
                var description = @"All Orders";
                var eqlText = @"SELECT *, $order_project.*, $order_type.*
FROM order
WHERE (@projectId = null OR project_id = @projectId)
    AND (@project = null OR $order_project.number ~* @project OR $order_project.name ~* @project)
    AND (@orderNumber = null OR order_number ~* @orderNumber)
    AND (@type = null OR $order_type.name ~* @type)
ORDER BY $order_project.number DESC, $order_project.name, order_number
PAGE @page
PAGESIZE @pageSize";
                var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_order.""id"" AS ""id"",
	 rec_order.""order"" AS ""order"",
	 rec_order.""offer"" AS ""offer"",
	 rec_order.""project_id"" AS ""project_id"",
	 rec_order.""order_number"" AS ""order_number"",
	 rec_order.""type_id"" AS ""type_id"",
	 rec_order.""total"" AS ""total"",
	 COUNT(*) OVER() AS ___total_count___,
	------->: $order_project
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 order_project.""id"" AS ""id"",
		 order_project.""name"" AS ""name"",
		 order_project.""number"" AS ""number"",
		 order_project.""requires_part_list"" AS ""requires_part_list"",
		 order_project.""inventory_project"" AS ""inventory_project"",
		 order_project.""reserve_stored_articles"" AS ""reserve_stored_articles""
	 FROM rec_project order_project
	 WHERE order_project.id = rec_order.project_id ) d )::jsonb AS ""$order_project"",
	-------< $order_project
	------->: $order_type
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 order_type.""id"" AS ""id"",
		 order_type.""name"" AS ""name""
	 FROM rec_order_type order_type
	 WHERE order_type.id = rec_order.type_id ) d )::jsonb AS ""$order_type""	
	-------< $order_type

FROM rec_order

LEFT OUTER JOIN  rec_project order_project_tar_org ON order_project_tar_org.id = rec_order.project_id
LEFT OUTER JOIN  rec_order_type order_type_tar_org ON order_type_tar_org.id = rec_order.type_id
WHERE  (  (  (  (  ( @projectId IS NULL )  OR  ( rec_order.""project_id"" IS NULL )  )  AND  (  (  ( @project IS NULL )  OR  ( order_project_tar_org.""number"" ~* @project )  )  OR  ( order_project_tar_org.""name"" ~* @project )  )  )  AND  (  ( @orderNumber IS NULL )  OR  ( rec_order.""order_number"" ~* @orderNumber )  )  )  AND  (  ( @type IS NULL )  OR  ( order_type_tar_org.""name"" ~* @type )  )  ) 
ORDER BY order_project_tar_org.""number"" DESC , order_project_tar_org.""name"" ASC , rec_order.""order_number"" ASC
LIMIT 20
OFFSET 0
) X
";
                var parametersJson = @"[{""name"":""projectId"",""type"":""guid"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""project"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""type"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""20"",""ignore_parse_errors"":false}]";
                var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order"",""type"":7,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""offer"",""type"":7,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""project_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""type_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""total"",""type"":12,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$order_project"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""requires_part_list"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""inventory_project"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""reserve_stored_articles"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]}]},{""name"":""$order_type"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]";
                var weight = 10;
                var returnTotal = true;
                var entityName = @"order";

                new WebVella.Erp.Database.DbDataSourceRepository().Update(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
            }
            #endregion

            #region << ***Update page data source*** Name: AllOrders >>
            {
                var id = new Guid("477dde1f-7805-4061-a986-345de2635d1f");
                var pageId = new Guid("16125e41-93a3-4735-a650-e78164aaf840");
                var dataSourceId = new Guid("8bf1e682-1980-4168-a7fb-23be211dbe87");
                var name = @"AllOrders";
                var parameters = @"[{""name"":""projectId"",""type"":""guid"",""value"":""{{RequestQuery.q_project_id_v}}"",""ignore_parse_errors"":false},{""name"":""project"",""type"":""text"",""value"":""{{RequestQuery.q_project_v}}"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""{{RequestQuery.q_order_number_v}}"",""ignore_parse_errors"":false},{""name"":""type"",""type"":""text"",""value"":""{{RequestQuery.q_type_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""{{RequestQuery.page_size}}"",""ignore_parse_errors"":false}]";

                new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).UpdatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page data source*** Name: AllOrderTypes >>
            {
                var id = new Guid("80725981-73c3-427a-bc2b-ab29f5f5ec1a");
                var pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
                var dataSourceId = new Guid("1ab4d2cd-54ba-48e8-8cfe-b2c0a16148c7");
                var name = @"AllOrderTypes";
                var parameters = @"[]";

                new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page data source*** Name: OrderTypeSelectOptions >>
            {
                var id = new Guid("d075e830-a5c9-4ea0-aa0c-93c3ea836c55");
                var pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
                var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                var name = @"OrderTypeSelectOptions";
                var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllOrderTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""name"",""ignore_parse_errors"":false}]";

                new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page data source*** Name: AllOrderTypes >>
            {
                var id = new Guid("78620de3-427f-4f9e-89bd-c328abcc9c80");
                var pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
                var dataSourceId = new Guid("1ab4d2cd-54ba-48e8-8cfe-b2c0a16148c7");
                var name = @"AllOrderTypes";
                var parameters = @"[]";

                new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page data source*** Name: OrderTypeSelectOptions >>
            {
                var id = new Guid("486cf266-20c0-4034-8d9d-d1dc7c2ea188");
                var pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
                var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                var name = @"OrderTypeSelectOptions";
                var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllOrderTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""name"",""ignore_parse_errors"":false}]";

                new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page data source*** Name: ProjectOrderTotal >>
            {
                var id = new Guid("3ba892dc-1cfa-46ff-b865-6e8dc6817e14");
                var pageId = new Guid("16125e41-93a3-4735-a650-e78164aaf840");
                var dataSourceId = new Guid("429506b4-f25d-4f2b-b4bd-d06241e5841a");
                var name = @"ProjectOrderTotal";
                var parameters = @"[{""name"":""project"",""type"":""Guid"",""value"":""{{RequestQuery.q_project_id_v}}"",""ignore_parse_errors"":false}]";

                new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

        }
        #endregion
    }
    catch
    {
        connection.RollbackTransaction();
        throw;
    }

    Console.WriteLine("Successfully patched db");
    connection.CommitTransaction();
}