using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using Newtonsoft.Json.Linq;
using WebVella.Erp.Api.Models.AutoMapper;
using WebVella.Erp;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web;
using WebVella.Erp.Web.Models.AutoMapper;
using Microsoft.Extensions.Configuration;


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

    // insert code between braces here
    {
        #region << ***Create field***  Entity: inventory_booking Field Name: warehouse_location_id >>
        {
            InputGuidField guidField = new InputGuidField();
            guidField.Id = new Guid("a0e8ac5b-fdc3-4fd2-81ff-e2b5e9ed4581");
            guidField.Name = "warehouse_location_id";
            guidField.Label = "Warehouse Location";
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
                var response = entMan.CreateField(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b"), guidField, false);
                if (!response.Success)
                    throw new Exception("System error 10060. Entity: inventory_booking Field: warehouse_location_id Message:" + response.Message);
            }
        }
        #endregion

        #region << ***Create relation*** Relation name: inventory_booking_warehouse_location >>
        {
            var relation = new EntityRelation();
            var originEntity = entMan.ReadEntity(new Guid("c0594745-9b28-40a1-9e57-a756734dca88")).Object;
            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
            var targetEntity = entMan.ReadEntity(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b")).Object;
            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "warehouse_location_id");
            relation.Id = new Guid("29ab09b4-1ddf-45ed-bba9-889b2df1dd2d");
            relation.Name = "inventory_booking_warehouse_location";
            relation.Label = "inventory_booking_warehouse_location";
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
                    throw new Exception("System error 10060. Relation: inventory_booking_warehouse_location Create. Message:" + response.Message);
            }
        }
        #endregion

        #region << ***Create sitemap area*** Sitemap area name: history >>
        {
            var id = new Guid("e28e95eb-d426-4a52-8a89-f67fb5cb4581");
            var appId = new Guid("c131f33e-4a80-4513-ac90-c04bb0e7c65f");
            var name = "history";
            var label = "History";
            var description = @"";
            var iconClass = "fas fa-list";
            var color = "";
            var weight = 2;
            var showGroupNames = false;
            var access = new List<Guid>();
            var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();
            var descriptionTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

            new WebVella.Erp.Web.Services.AppService().CreateArea(id, appId, name, label, labelTranslations, description, descriptionTranslations, iconClass, color, weight, showGroupNames, access, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create sitemap node*** Sitemap node name: history >>
        {
            var id = new Guid("fd70e09c-3049-4e7f-be92-153aae3bcbda");
            Guid? parentId = null;
            var areaId = new Guid("e28e95eb-d426-4a52-8a89-f67fb5cb4581");
            Guid? entityId = new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b");
            var name = "history";
            var label = "History";
            var url = "";
            var iconClass = "fas fa-list-ul";
            var weight = 1;
            var type = ((int)1);
            var access = new List<Guid>();
            var entityListPages = new List<Guid>();
            entityListPages.Add(new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123"));
            var entityCreatePages = new List<Guid>();
            var entityDetailsPages = new List<Guid>();
            var entityManagePages = new List<Guid>();
            var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

            new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
        }
        #endregion

        #region << ***Create page*** Page name: history >>
        {
            var id = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var name = @"history";
            var label = "History";
            var iconClass = "";
            var system = false;
            var layout = @"";
            var weight = 10;
            var type = (PageType)((int)3);
            var isRazorBody = false;
            Guid? appId = new Guid("c131f33e-4a80-4513-ac90-c04bb0e7c65f");
            Guid? entityId = new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b");
            Guid? nodeId = null;
            Guid? areaId = null;
            string razorBody = null;
            var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

            new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Update page body node*** Page: all ID: 9569b249-9a35-44b2-9d71-1e8c0d60b662 >>
        {
            var id = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
            Guid? parentId = null;
            Guid? nodeId = null;
            Guid pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
            var componentName = "WebVella.Erp.Web.Components.PcGrid";
            var containerId = "";
            var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 8,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllArticles\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": ""article_grid"",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""3"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Preview"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Part Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""true"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Type Number"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Order Number"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Manufacturer"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": ""Designation"",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""3"",
  ""container6_horizontal_align"": ""2"",
  ""container7_label"": ""Blocked"",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": ""Data Portal"",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""true"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""3"",
  ""container8_horizontal_align"": ""2"",
  ""container9_label"": """",
  ""container9_width"": """",
  ""container9_name"": """",
  ""container9_nowrap"": ""false"",
  ""container9_sortable"": ""false"",
  ""container9_class"": """",
  ""container9_vertical_align"": ""1"",
  ""container9_horizontal_align"": ""1"",
  ""container10_label"": """",
  ""container10_width"": """",
  ""container10_name"": """",
  ""container10_nowrap"": ""false"",
  ""container10_sortable"": ""false"",
  ""container10_class"": """",
  ""container10_vertical_align"": ""1"",
  ""container10_horizontal_align"": ""1"",
  ""container11_label"": """",
  ""container11_width"": """",
  ""container11_name"": """",
  ""container11_nowrap"": ""false"",
  ""container11_sortable"": ""false"",
  ""container11_class"": """",
  ""container11_vertical_align"": ""1"",
  ""container11_horizontal_align"": ""1"",
  ""container12_label"": """",
  ""container12_width"": """",
  ""container12_name"": """",
  ""container12_nowrap"": ""false"",
  ""container12_sortable"": ""false"",
  ""container12_class"": """",
  ""container12_vertical_align"": ""1"",
  ""container12_horizontal_align"": ""1""
}";
            var weight = 2;

            new WebVella.Erp.Web.Services.PageService().UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: f7d278ce-19c6-4c1a-8a37-7114f2acbdfe >>
        {
            var id = new Guid("f7d278ce-19c6-4c1a-8a37-7114f2acbdfe");
            Guid? parentId = null;
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
            var containerId = "";
            var options = @"{}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 5e862a51-606c-481d-b69a-1788d361ca09 >>
        {
            var id = new Guid("5e862a51-606c-481d-b69a-1788d361ca09");
            Guid? parentId = new Guid("f7d278ce-19c6-4c1a-8a37-7114f2acbdfe");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcButton";
            var containerId = "actions";
            var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 text-nowrap mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-search"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": ""ErpEvent.DISPATCH('WebVella.Erp.Web.Components.PcDrawer','open')"",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 8e1e08ae-ae89-4a8d-8692-8c2a9116ce9d >>
        {
            var id = new Guid("8e1e08ae-ae89-4a8d-8692-8c2a9116ce9d");
            Guid? parentId = null;
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcForm";
            var containerId = "";
            var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-8e1e08ae-ae89-4a8d-8692-8c2a9116ce9d"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
            var weight = 3;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: dc10c0c5-1e79-491c-9a8d-802d0b4a57a6 >>
        {
            var id = new Guid("dc10c0c5-1e79-491c-9a8d-802d0b4a57a6");
            Guid? parentId = new Guid("8e1e08ae-ae89-4a8d-8692-8c2a9116ce9d");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcDrawer";
            var containerId = "body";
            var options = @"{
  ""is_visible"": """",
  ""title"": ""Search"",
  ""width"": ""550px"",
  ""class"": """",
  ""body_class"": """",
  ""title_action_html"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 4e8d91cf-0f70-428e-9fd9-22bdbc1d8c74 >>
        {
            var id = new Guid("4e8d91cf-0f70-428e-9fd9-22bdbc1d8c74");
            Guid? parentId = new Guid("dc10c0c5-1e79-491c-9a8d-802d0b4a57a6");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
            var containerId = "body";
            var options = @"{
  ""is_visible"": """",
  ""label"": ""User Name"",
  ""name"": ""user_name"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """",
  ""data_type"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 71b8938d-a63a-4a55-87d8-5c244fc1e942 >>
        {
            var id = new Guid("71b8938d-a63a-4a55-87d8-5c244fc1e942");
            Guid? parentId = new Guid("dc10c0c5-1e79-491c-9a8d-802d0b4a57a6");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
            var containerId = "body";
            var options = @"{
  ""is_visible"": """",
  ""label"": ""Warehouse"",
  ""name"": ""warehouse"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """",
  ""data_type"": """"
}";
            var weight = 2;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: b9cfb4c6-8bd3-4a3b-9011-9f6d43f7504b >>
        {
            var id = new Guid("b9cfb4c6-8bd3-4a3b-9011-9f6d43f7504b");
            Guid? parentId = new Guid("dc10c0c5-1e79-491c-9a8d-802d0b4a57a6");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
            var containerId = "body";
            var options = @"{
  ""is_visible"": """",
  ""label"": ""Warehouse Location"",
  ""name"": ""warehouse_location"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """",
  ""data_type"": """"
}";
            var weight = 3;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: ab0b8c45-f3a6-4f6a-a57f-9ce9d0065d49 >>
        {
            var id = new Guid("ab0b8c45-f3a6-4f6a-a57f-9ce9d0065d49");
            Guid? parentId = new Guid("dc10c0c5-1e79-491c-9a8d-802d0b4a57a6");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
            var containerId = "body";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Page Size"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RequestQuery.page_size\"",\""default\"":\""10\""}"",
  ""name"": ""page_size"",
  ""class"": """",
  ""decimal_digits"": 0,
  ""min"": 0,
  ""max"": 2147483647,
  ""step"": 1,
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 4;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 197c12e2-4e7a-4651-b11e-133ad06eaa2a >>
        {
            var id = new Guid("197c12e2-4e7a-4651-b11e-133ad06eaa2a");
            Guid? parentId = new Guid("dc10c0c5-1e79-491c-9a8d-802d0b4a57a6");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcButton";
            var containerId = "body";
            var options = @"{
  ""type"": ""1"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-search"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-8e1e08ae-ae89-4a8d-8692-8c2a9116ce9d""
}";
            var weight = 5;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 123c7f94-0949-468a-b5b3-9114448859ec >>
        {
            var id = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? parentId = null;
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcGrid";
            var containerId = "";
            var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 11,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllInventoryBookings\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""false"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No bookings"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""true"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": """",
  ""compatibility"": """",
  ""container1_label"": """",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Part Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Type Number"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Order Number"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Designation"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": ""Warehouse Location"",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""3"",
  ""container6_horizontal_align"": ""2"",
  ""container7_label"": ""User"",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": ""Project"",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""3"",
  ""container8_horizontal_align"": ""2"",
  ""container9_label"": ""Timestamp"",
  ""container9_width"": """",
  ""container9_name"": """",
  ""container9_nowrap"": ""false"",
  ""container9_sortable"": ""false"",
  ""container9_class"": """",
  ""container9_vertical_align"": ""3"",
  ""container9_horizontal_align"": ""2"",
  ""container10_label"": ""Amount"",
  ""container10_width"": """",
  ""container10_name"": """",
  ""container10_nowrap"": ""false"",
  ""container10_sortable"": ""false"",
  ""container10_class"": """",
  ""container10_vertical_align"": ""3"",
  ""container10_horizontal_align"": ""2"",
  ""container11_label"": """",
  ""container11_width"": """",
  ""container11_name"": """",
  ""container11_nowrap"": ""false"",
  ""container11_sortable"": ""false"",
  ""container11_class"": """",
  ""container11_vertical_align"": ""3"",
  ""container11_horizontal_align"": ""2"",
  ""container12_label"": """",
  ""container12_width"": """",
  ""container12_name"": """",
  ""container12_nowrap"": ""false"",
  ""container12_sortable"": ""false"",
  ""container12_class"": """",
  ""container12_vertical_align"": ""1"",
  ""container12_horizontal_align"": ""1""
}";
            var weight = 2;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 6ce9ae43-5ec9-4645-8af8-4f577b35a7d1 >>
        {
            var id = new Guid("6ce9ae43-5ec9-4645-8af8-4f577b35a7d1");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcImage";
            var containerId = "column1";
            var options = @"{
  ""is_visible"": """",
  ""source"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_article.preview\"",\""default\"":\""\""}"",
  ""width"": ""50"",
  ""height"": ""50"",
  ""class"": """",
  ""id"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: b974cfd1-3dad-4145-bbe0-eb147d8b6bab >>
        {
            var id = new Guid("b974cfd1-3dad-4145-bbe0-eb147d8b6bab");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column6";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""{{RowRecord.$inventory_booking_warehouse_location.$warehouse.designation}}-{{RowRecord.$inventory_booking_warehouse_location.designation}}\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 6c7d110a-c720-4ffb-b551-13a1d389421d >>
        {
            var id = new Guid("6c7d110a-c720-4ffb-b551-13a1d389421d");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column2";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_article.part_number\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 8cfaaece-a78f-4b5e-b72a-33bc35b9ad7f >>
        {
            var id = new Guid("8cfaaece-a78f-4b5e-b72a-33bc35b9ad7f");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column3";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_article.type_number\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 3bbf9861-616c-4595-a464-57f1a212413e >>
        {
            var id = new Guid("3bbf9861-616c-4595-a464-57f1a212413e");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column4";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_article.order_number\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 1ad572b3-e811-40bb-bdd2-90621dd8268e >>
        {
            var id = new Guid("1ad572b3-e811-40bb-bdd2-90621dd8268e");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column5";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_article.designation\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 379a2559-ce68-4c5d-b8f9-e5ae50863615 >>
        {
            var id = new Guid("379a2559-ce68-4c5d-b8f9-e5ae50863615");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column7";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_user.username\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: ec901424-a3b1-444d-b2f9-a2575711c8e1 >>
        {
            var id = new Guid("ec901424-a3b1-444d-b2f9-a2575711c8e1");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column10";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""{{RowRecord.amount}} {{RowRecord.$inventory_booking_article.$article_article_type.unit}}\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 68456a6f-e46a-471b-a0b3-1dd4f722ad32 >>
        {
            var id = new Guid("68456a6f-e46a-471b-a0b3-1dd4f722ad32");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcForm";
            var containerId = "column11";
            var options = @"{
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$and($or($hasRole('inventory-admin'), $areEqual(CurrentUser.id, RowRecord.user_id)), $exists(RowRecord.$inventory_booking_warehouse_location.designation))\"",\""default\"":\""\""}"",
  ""id"": ""wv-68456a6f-e46a-471b-a0b3-1dd4f722ad32"",
  ""name"": ""form"",
  ""hook_key"": ""inventory_booking_undo"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": ""float-right"",
  ""show_validation"": ""false""
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: abf0facc-3c65-4669-bc7f-7feb027472f1 >>
        {
            var id = new Guid("abf0facc-3c65-4669-bc7f-7feb027472f1");
            Guid? parentId = new Guid("68456a6f-e46a-471b-a0b3-1dd4f722ad32");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcButton";
            var containerId = "body";
            var options = @"{
  ""type"": ""1"",
  ""text"": ""Undo"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-undo"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-68456a6f-e46a-471b-a0b3-1dd4f722ad32""
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: de15b5c4-d9bf-4fe7-baad-09c424202544 >>
        {
            var id = new Guid("de15b5c4-d9bf-4fe7-baad-09c424202544");
            Guid? parentId = new Guid("68456a6f-e46a-471b-a0b3-1dd4f722ad32");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "body";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.id\"",\""default\"":\""\""}"",
  ""name"": ""id"",
  ""class"": ""d-none"",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 2;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: f6a4f2a9-5976-43c6-8761-47cd4b4fa3bf >>
        {
            var id = new Guid("f6a4f2a9-5976-43c6-8761-47cd4b4fa3bf");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldDateTime";
            var containerId = "column9";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.timestamp\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create page body node*** Page name: history  id: 3ff9f8a6-a182-467a-a299-ac5a59fda094 >>
        {
            var id = new Guid("3ff9f8a6-a182-467a-a299-ac5a59fda094");
            Guid? parentId = new Guid("123c7f94-0949-468a-b5b3-9114448859ec");
            Guid? nodeId = null;
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var componentName = "WebVella.Erp.Web.Components.PcFieldText";
            var containerId = "column8";
            var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$inventory_booking_project.number\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
            var weight = 1;

            new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion

        #region << ***Create data source*** Name: AllInventoryBookings >>
        {
            var id = new Guid("42b3eb4e-edd8-462b-b562-30bbc32149ae");
            var name = @"AllInventoryBookings";
            var description = @"Inventory Booking History";
            var eqlText = @"SELECT *, $inventory_booking_article.*, $inventory_booking_article.$article_article_type.*, $inventory_booking_warehouse_location.*, $inventory_booking_user.*, $inventory_booking_project.*, $inventory_booking_warehouse_location.$warehouse.*
FROM inventory_booking
WHERE (@warehouseLocation = null OR $inventory_booking_warehouse_location.designation ~* @warehouseLocation)
    AND (@userName = null OR $inventory_booking_user.username ~* @userName)
    AND (@warehouse = null OR $inventory_booking_warehouse_location.$warehouse.designation ~* @warehouse)
ORDER BY timestamp DESC
PAGE @page
PAGESIZE @pageSize";
            var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_inventory_booking.""id"" AS ""id"",
	 rec_inventory_booking.""article_id"" AS ""article_id"",
	 rec_inventory_booking.""user_id"" AS ""user_id"",
	 rec_inventory_booking.""timestamp"" AS ""timestamp"",
	 rec_inventory_booking.""amount"" AS ""amount"",
	 rec_inventory_booking.""project_id"" AS ""project_id"",
	 rec_inventory_booking.""warehouse_location_id"" AS ""warehouse_location_id"",
	 COUNT(*) OVER() AS ___total_count___,
	------->: $inventory_booking_article
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 inventory_booking_article.""id"" AS ""id"",
		 inventory_booking_article.""manufacturer_id"" AS ""manufacturer_id"",
		 inventory_booking_article.""preview"" AS ""preview"",
		 inventory_booking_article.""part_number"" AS ""part_number"",
		 inventory_booking_article.""eplan_id"" AS ""eplan_id"",
		 inventory_booking_article.""designation"" AS ""designation"",
		 inventory_booking_article.""is_blocked"" AS ""is_blocked"",
		 inventory_booking_article.""article_type"" AS ""article_type"",
		 inventory_booking_article.""type_number"" AS ""type_number"",
		 inventory_booking_article.""order_number"" AS ""order_number"",
		------->: $article_article_type
		(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
		 SELECT 
			 article_article_type.""id"" AS ""id"",
			 article_article_type.""unit"" AS ""unit"",
			 article_article_type.""label"" AS ""label"",
			 article_article_type.""is_integer"" AS ""is_integer""
		 FROM rec_article_type article_article_type
		 WHERE article_article_type.id = inventory_booking_article.article_type ) d )::jsonb AS ""$article_article_type""		
		-------< $article_article_type

	 FROM rec_article inventory_booking_article
	 WHERE inventory_booking_article.id = rec_inventory_booking.article_id ) d )::jsonb AS ""$inventory_booking_article"",
	-------< $inventory_booking_article
	------->: $inventory_booking_warehouse_location
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 inventory_booking_warehouse_location.""id"" AS ""id"",
		 inventory_booking_warehouse_location.""designation"" AS ""designation"",
		 inventory_booking_warehouse_location.""warehouse_id"" AS ""warehouse_id"",
		------->: $warehouse
		(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
		 SELECT 
			 warehouse.""id"" AS ""id"",
			 warehouse.""designation"" AS ""designation""
		 FROM rec_warehouse warehouse
		 WHERE warehouse.id = inventory_booking_warehouse_location.warehouse_id ) d )::jsonb AS ""$warehouse""		
		-------< $warehouse

	 FROM rec_warehouse_location inventory_booking_warehouse_location
	 WHERE inventory_booking_warehouse_location.id = rec_inventory_booking.warehouse_location_id ) d )::jsonb AS ""$inventory_booking_warehouse_location"",
	-------< $inventory_booking_warehouse_location
	------->: $inventory_booking_user
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 inventory_booking_user.""id"" AS ""id"",
		 inventory_booking_user.""created_on"" AS ""created_on"",
		 inventory_booking_user.""first_name"" AS ""first_name"",
		 inventory_booking_user.""last_name"" AS ""last_name"",
		 inventory_booking_user.""username"" AS ""username"",
		 inventory_booking_user.""email"" AS ""email"",
		 inventory_booking_user.""password"" AS ""password"",
		 inventory_booking_user.""last_logged_in"" AS ""last_logged_in"",
		 inventory_booking_user.""enabled"" AS ""enabled"",
		 inventory_booking_user.""verified"" AS ""verified"",
		 inventory_booking_user.""preferences"" AS ""preferences"",
		 inventory_booking_user.""image"" AS ""image""
	 FROM rec_user inventory_booking_user
	 WHERE inventory_booking_user.id = rec_inventory_booking.user_id ) d )::jsonb AS ""$inventory_booking_user"",
	-------< $inventory_booking_user
	------->: $inventory_booking_project
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 inventory_booking_project.""id"" AS ""id"",
		 inventory_booking_project.""name"" AS ""name"",
		 inventory_booking_project.""number"" AS ""number"",
		 inventory_booking_project.""requires_part_list"" AS ""requires_part_list"",
		 inventory_booking_project.""inventory_project"" AS ""inventory_project""
	 FROM rec_project inventory_booking_project
	 WHERE inventory_booking_project.id = rec_inventory_booking.project_id ) d )::jsonb AS ""$inventory_booking_project""	
	-------< $inventory_booking_project

FROM rec_inventory_booking

LEFT OUTER JOIN  rec_warehouse_location inventory_booking_warehouse_location_tar_org ON inventory_booking_warehouse_location_tar_org.id = rec_inventory_booking.warehouse_location_id
LEFT OUTER JOIN  rec_user inventory_booking_user_tar_org ON inventory_booking_user_tar_org.id = rec_inventory_booking.user_id
LEFT OUTER JOIN  rec_warehouse warehouse_tar_org ON warehouse_tar_org.id = inventory_booking_warehouse_location_tar_org.warehouse_id
WHERE  (  (  (  ( @warehouseLocation IS NULL )  OR  ( inventory_booking_warehouse_location_tar_org.""designation"" ~* @warehouseLocation )  )  AND  (  ( @userName IS NULL )  OR  ( inventory_booking_user_tar_org.""username"" ~* @userName )  )  )  AND  (  ( @warehouse IS NULL )  OR  ( warehouse_tar_org.""designation"" ~* @warehouse )  )  ) 
ORDER BY rec_inventory_booking.""timestamp"" DESC
LIMIT 10
OFFSET 0
) X
";
            var parametersJson = @"[{""name"":""warehouse"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""warehouseLocation"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""userName"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
            var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""article_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""user_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""timestamp"",""type"":5,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""amount"",""type"":12,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""project_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""warehouse_location_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$inventory_booking_article"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""manufacturer_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""preview"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""part_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""is_blocked"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""article_type"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""type_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$article_article_type"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""unit"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""label"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""is_integer"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]},{""name"":""$inventory_booking_warehouse_location"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""warehouse_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$warehouse"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]},{""name"":""$inventory_booking_user"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""created_on"",""type"":5,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""first_name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""last_name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""username"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""email"",""type"":6,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""password"",""type"":13,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""last_logged_in"",""type"":5,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""enabled"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""verified"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""preferences"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""image"",""type"":9,""entity_name"":"""",""relation_name"":null,""children"":[]}]},{""name"":""$inventory_booking_project"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""requires_part_list"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""inventory_project"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]";
            var weight = 10;
            var returnTotal = true;
            var entityName = @"inventory_booking";

            new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
        }
        #endregion

        #region << ***Create page data source*** Name: AllInventoryBookings >>
        {
            var id = new Guid("e6fb788b-1321-4d5e-a564-4ffb2067921a");
            var pageId = new Guid("a5d28ae4-8d59-4f08-89a3-d61bca26f123");
            var dataSourceId = new Guid("42b3eb4e-edd8-462b-b562-30bbc32149ae");
            var name = @"AllInventoryBookings";
            var parameters = @"[{""name"":""warehouse"",""type"":""text"",""value"":""{{RequestQuery.q_warehouse_v}}"",""ignore_parse_errors"":false},{""name"":""warehouseLocation"",""type"":""text"",""value"":""{{RequestQuery.q_warehouse_location_v}}"",""ignore_parse_errors"":false},{""name"":""userName"",""type"":""text"",""value"":""{{RequestQuery.q_user_name_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""{{RequestQuery.page_size}}"",""ignore_parse_errors"":false}]";

            new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
        }
        #endregion


    }

    connection.CommitTransaction();
}