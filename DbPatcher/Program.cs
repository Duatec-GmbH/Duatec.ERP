using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using Newtonsoft.Json.Linq;
using WebVella.Erp.Api.Models.AutoMapper;
using WebVella.Erp;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web;
using WebVella.Erp.Web.Models.AutoMapper;


var location = System.Reflection.Assembly.GetEntryAssembly()!.Location;
var path = location[..location.LastIndexOf('\\')];
var config = JObject.Parse(File.ReadAllText(path + "\\Config.json"));
var connectionString = ((JObject)config["Settings"])["ConnectionString"]!.ToString();
var context = DbContext.CreateContext(connectionString);

ErpAutoMapperConfiguration.Configure(ErpAutoMapperConfiguration.MappingExpressions);
ErpWebAutoMapperConfiguration.Configure(ErpAutoMapperConfiguration.MappingExpressions);
ErpAutoMapper.Initialize(ErpAutoMapperConfiguration.MappingExpressions);
ErpAppContext.Init();

using (SecurityContext.OpenSystemScope())
{
    using var connection = context.CreateConnection();
    connection.BeginTransaction();

    var entMan = new EntityManager(context);
    var recMan = new RecordManager(context, true, false);

    #region << ***Create field***  Entity: order Field Name: bill >>
    {
        InputFileField fileField = new InputFileField();
        fileField.Id = new Guid("6697a525-bc91-4c8a-9a10-8515b093a827");
        fileField.Name = "bill";
        fileField.Label = "Bill";
        fileField.PlaceholderText = null;
        fileField.Description = null;
        fileField.HelpText = null;
        fileField.Required = false;
        fileField.Unique = false;
        fileField.Searchable = true;
        fileField.Auditable = false;
        fileField.System = false;
        fileField.DefaultValue = "";
        fileField.EnableSecurity = false;
        fileField.Permissions = new FieldPermissions();
        fileField.Permissions.CanRead = new List<Guid>();
        fileField.Permissions.CanUpdate = new List<Guid>();
        //READ
        //UPDATE
        {
            var response = entMan.CreateField(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559"), fileField, false);
            if (!response.Success)
                throw new Exception("System error 10060. Entity: order Field: bill Message:" + response.Message);
        }
    }
    #endregion

    #region << ***Delete field*** Entity: order Field Name: confirmation >>
    {
        {
            var response = entMan.DeleteField(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559"), new Guid("8505c9bc-9613-4d8f-92f5-3562271dea28"));
            if (!response.Success)
                throw new Exception("System error 10060. Delete field failed for Field: confirmation Entity: order. Message:" + response.Message);
        }
    }
    #endregion

    //#region << ***Update page*** Page name: order-list >>
    //{
    //    var id = new Guid("9681dc5e-b096-4e85-88d8-c082e35554a9");
    //    var name = @"order-list";
    //    var label = "Overall Overview";
    //    string iconClass = null;
    //    var system = false;
    //    var layout = @"";
    //    var weight = 1001;
    //    var type = (PageType)((int)5);
    //    var isRazorBody = false;
    //    var appId = new Guid("136096a5-ca6e-4efa-8489-e239e37c5a58");
    //    var entityId = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
    //    Guid? nodeId = null;
    //    Guid? areaId = null;
    //    string razorBody = null;
    //    var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

    //    new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, context.Transaction);
    //}
    //#endregion

    #region << ***Update page body node*** Page: detail ID: a5bfd1b6-12f6-4fcb-8473-7f7beff38b47 >>
    {
        var id = new Guid("a5bfd1b6-12f6-4fcb-8473-7f7beff38b47");
        Guid? parentId = new Guid("7e6d9d23-37d6-40b6-93a1-ecbd40640ecf");
        Guid? nodeId = null;
        Guid pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/manage?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 11fc6e9d-69b5-4e91-a1eb-63a1201c7bf7 >>
    {
        var id = new Guid("11fc6e9d-69b5-4e91-a1eb-63a1201c7bf7");
        Guid? parentId = new Guid("6d627825-0b6c-4226-a0e3-038fa603ae50");
        Guid? nodeId = null;
        Guid pageId = new Guid("4ceba53a-d8b8-4fc0-a72b-7bcfbfae6ad6");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: ad87173b-cb99-43d3-8133-e7da9b92d565 >>
    {
        var id = new Guid("ad87173b-cb99-43d3-8133-e7da9b92d565");
        Guid? parentId = new Guid("7ff53105-c1b7-4ee0-a20f-9cbf559d73bf");
        Guid? nodeId = null;
        Guid pageId = new Guid("4ceba53a-d8b8-4fc0-a72b-7bcfbfae6ad6");
        var componentName = "WebVella.Erp.Web.Components.PcEditableGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 2,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""Record.$part_list_entry_part_list\"",\""default\"":\""\""}"",
  ""has-add-button"": ""true"",
  ""has-delete-buttons"": ""true"",
  ""allow-copy"": ""true"",
  ""allow-paste"": ""true"",
  ""allow-add"": ""true"",
  ""allow-delete"": ""true"",
  ""compatibility"": ""article-amount"",
  ""name"": """",
  ""class"": ""mt-3"",
  ""striped"": ""true"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""has_thead"": ""true"",
  ""container1_label"": ""Article"",
  ""container1_width"": """",
  ""container1_name"": ""article"",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Amount"",
  ""container2_width"": """",
  ""container2_name"": ""amount"",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Device Tag(s)"",
  ""container3_width"": """",
  ""container3_name"": ""device-tag"",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": """",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""1"",
  ""container4_horizontal_align"": ""1"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""1"",
  ""container5_horizontal_align"": ""1"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: ad79c4e8-131c-4c83-af81-403a25cddbf7 >>
    {
        var id = new Guid("ad79c4e8-131c-4c83-af81-403a25cddbf7");
        Guid? parentId = new Guid("7f099bda-7323-4eb7-a604-b50bb577ede1");
        Guid? nodeId = null;
        Guid pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1 text-nowrap"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/c/create?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: cbdca093-e870-4a1a-88b9-b95667c0084a >>
    {
        var id = new Guid("cbdca093-e870-4a1a-88b9-b95667c0084a");
        Guid? parentId = new Guid("76b2f980-6884-4e86-bf9f-b37604cb06e2");
        Guid? nodeId = null;
        Guid pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: b1c302a9-faaa-479f-b038-b4e14225910b >>
    {
        var id = new Guid("b1c302a9-faaa-479f-b038-b4e14225910b");
        Guid? parentId = new Guid("091f3a12-dafd-4627-b158-6a075d427824");
        Guid? nodeId = null;
        Guid pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/manage?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: file-import ID: 140c0846-0a18-4023-a935-46c3859a7ecf >>
    {
        var id = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
        Guid? parentId = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
        Guid? nodeId = null;
        Guid pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 7,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""Record.articles\"",\""default\"":\""\""}"",
  ""page_size"": 0,
  ""name"": """",
  ""prefix"": """",
  ""class"": ""mb-5 mt-5"",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""false"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": """",
  ""container1_label"": ""Part Number"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Type Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Order Number"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Designation"",
  ""container4_width"": ""500px"",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""State"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": ""Type"",
  ""container6_width"": ""250px"",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""3"",
  ""container6_horizontal_align"": ""2"",
  ""container7_label"": ""Action"",
  ""container7_width"": ""250px"",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: file-import ID: 687e6751-1f12-4f1c-b9c0-dfd81c47e2a8 >>
    {
        var id = new Guid("687e6751-1f12-4f1c-b9c0-dfd81c47e2a8");
        Guid? parentId = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
        Guid? nodeId = null;
        Guid pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
        var componentName = "WebVella.Erp.Web.Components.PcRow";
        var containerId = "body";
        var options = @"{
  ""visible_columns"": 1,
  ""class"": ""mb-5"",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 0,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 6,
  ""container1_offset_md"": 7,
  ""container1_offset_lg"": 8,
  ""container1_offset_xl"": 9,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 0,
  ""container2_span_md"": 0,
  ""container2_span_lg"": 0,
  ""container2_span_xl"": 0,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 0,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""1"",
  ""container2_flex_order"": 0,
  ""container3_span"": 0,
  ""container3_span_sm"": 0,
  ""container3_span_md"": 0,
  ""container3_span_lg"": 0,
  ""container3_span_xl"": 0,
  ""container3_offset"": 0,
  ""container3_offset_sm"": 0,
  ""container3_offset_md"": 0,
  ""container3_offset_lg"": 0,
  ""container3_offset_xl"": 0,
  ""container3_flex_self_align"": ""1"",
  ""container3_flex_order"": 0,
  ""container4_span"": 0,
  ""container4_span_sm"": 0,
  ""container4_span_md"": 0,
  ""container4_span_lg"": 0,
  ""container4_span_xl"": 0,
  ""container4_offset"": 0,
  ""container4_offset_sm"": 0,
  ""container4_offset_md"": 0,
  ""container4_offset_lg"": 0,
  ""container4_offset_xl"": 0,
  ""container4_flex_self_align"": ""1"",
  ""container4_flex_order"": 0,
  ""container5_span"": 0,
  ""container5_span_sm"": 0,
  ""container5_span_md"": 0,
  ""container5_span_lg"": 0,
  ""container5_span_xl"": 0,
  ""container5_offset"": 0,
  ""container5_offset_sm"": 0,
  ""container5_offset_md"": 0,
  ""container5_offset_lg"": 0,
  ""container5_offset_xl"": 0,
  ""container5_flex_self_align"": ""1"",
  ""container5_flex_order"": 0,
  ""container6_span"": 0,
  ""container6_span_sm"": 0,
  ""container6_span_md"": 0,
  ""container6_span_lg"": 0,
  ""container6_span_xl"": 0,
  ""container6_offset"": 0,
  ""container6_offset_sm"": 0,
  ""container6_offset_md"": 0,
  ""container6_offset_lg"": 0,
  ""container6_offset_xl"": 0,
  ""container6_flex_self_align"": ""1"",
  ""container6_flex_order"": 0,
  ""container7_span"": 0,
  ""container7_span_sm"": 0,
  ""container7_span_md"": 0,
  ""container7_span_lg"": 0,
  ""container7_span_xl"": 0,
  ""container7_offset"": 0,
  ""container7_offset_sm"": 0,
  ""container7_offset_md"": 0,
  ""container7_offset_lg"": 0,
  ""container7_offset_xl"": 0,
  ""container7_flex_self_align"": ""1"",
  ""container7_flex_order"": 0,
  ""container8_span"": 0,
  ""container8_span_sm"": 0,
  ""container8_span_md"": 0,
  ""container8_span_lg"": 0,
  ""container8_span_xl"": 0,
  ""container8_offset"": 0,
  ""container8_offset_sm"": 0,
  ""container8_offset_md"": 0,
  ""container8_offset_lg"": 0,
  ""container8_offset_xl"": 0,
  ""container8_flex_self_align"": ""1"",
  ""container8_flex_order"": 0,
  ""container9_span"": 0,
  ""container9_span_sm"": 0,
  ""container9_span_md"": 0,
  ""container9_span_lg"": 0,
  ""container9_span_xl"": 0,
  ""container9_offset"": 0,
  ""container9_offset_sm"": 0,
  ""container9_offset_md"": 0,
  ""container9_offset_lg"": 0,
  ""container9_offset_xl"": 0,
  ""container9_flex_self_align"": ""1"",
  ""container9_flex_order"": 0,
  ""container10_span"": 0,
  ""container10_span_sm"": 0,
  ""container10_span_md"": 0,
  ""container10_span_lg"": 0,
  ""container10_span_xl"": 0,
  ""container10_offset"": 0,
  ""container10_offset_sm"": 0,
  ""container10_offset_md"": 0,
  ""container10_offset_lg"": 0,
  ""container10_offset_xl"": 0,
  ""container10_flex_self_align"": ""1"",
  ""container10_flex_order"": 0,
  ""container11_span"": 0,
  ""container11_span_sm"": 0,
  ""container11_span_md"": 0,
  ""container11_span_lg"": 0,
  ""container11_span_xl"": 0,
  ""container11_offset"": 0,
  ""container11_offset_sm"": 0,
  ""container11_offset_md"": 0,
  ""container11_offset_lg"": 0,
  ""container11_offset_xl"": 0,
  ""container11_flex_self_align"": ""1"",
  ""container11_flex_order"": 0,
  ""container12_span"": 0,
  ""container12_span_sm"": 0,
  ""container12_span_md"": 0,
  ""container12_span_lg"": 0,
  ""container12_span_xl"": 0,
  ""container12_offset"": 0,
  ""container12_offset_sm"": 0,
  ""container12_offset_md"": 0,
  ""container12_offset_lg"": 0,
  ""container12_offset_xl"": 0,
  ""container12_flex_self_align"": ""1"",
  ""container12_flex_order"": 0
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: file-import ID: 9618a6d1-9253-421d-bb00-25663ecdc0c1 >>
    {
        var id = new Guid("9618a6d1-9253-421d-bb00-25663ecdc0c1");
        Guid? parentId = new Guid("b6d462f3-2746-4e27-b717-7ffa9547cd32");
        Guid? nodeId = null;
        Guid pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""1"",
  ""text"": ""Import"",
  ""color"": ""1"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": ""fa fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-e507a721-a1b4-4de0-89a0-02c692592854""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: file-import ID: 70cda21e-0fbc-489e-a1cd-1c1378c38ae3 >>
    {
        var id = new Guid("70cda21e-0fbc-489e-a1cd-1c1378c38ae3");
        Guid? parentId = new Guid("b6d462f3-2746-4e27-b717-7ffa9547cd32");
        Guid? nodeId = null;
        Guid pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: file-import  id: ff3e7f21-86f6-491f-822f-1cb3d04b8818 >>
    {
        var id = new Guid("ff3e7f21-86f6-491f-822f-1cb3d04b8818");
        Guid? parentId = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
        Guid? nodeId = null;
        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Found {{Record.count}} articles\"",\""default\"":\""\""}"",
  ""name"": """",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: manage  id: 2db3a6ce-3bef-44a1-9ab8-cb5b43ab955b >>
    {
        var id = new Guid("2db3a6ce-3bef-44a1-9ab8-cb5b43ab955b");
        Guid? parentId = new Guid("98718fb4-c136-4256-9ddc-6c2f507ab57e");
        Guid? nodeId = null;
        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""administrator\\\"")\"",\""default\"":\""\""}"",
  ""label_mode"": ""0"",
  ""label_text"": ""Part Number"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.part_number\"",\""default\"":\""\""}"",
  ""name"": ""part_number"",
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
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 69a347d2-3838-482a-95ae-9c6ee4f364ca >>
    {
        var id = new Guid("69a347d2-3838-482a-95ae-9c6ee4f364ca");
        Guid? parentId = new Guid("f866d84c-f399-4a94-92af-3089723d5666");
        Guid? nodeId = null;
        Guid pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: manage  id: 31516424-e081-4a0b-88ad-44da1050a064 >>
    {
        var id = new Guid("31516424-e081-4a0b-88ad-44da1050a064");
        Guid? parentId = new Guid("56e3c8a2-2ead-40b4-924a-87cdfa7d00a1");
        Guid? nodeId = null;
        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""administrator\\\"")\"",\""default\"":\""\""}"",
  ""label_mode"": ""0"",
  ""label_text"": ""Order Number"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.order_number\"",\""default\"":\""\""}"",
  ""name"": ""order_number"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: manage  id: fbcfb838-6547-4332-b6b5-76f8424dde02 >>
    {
        var id = new Guid("fbcfb838-6547-4332-b6b5-76f8424dde02");
        Guid? parentId = new Guid("56e3c8a2-2ead-40b4-924a-87cdfa7d00a1");
        Guid? nodeId = null;
        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column1";
        var options = @"{
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""administrator\\\"")\"",\""default\"":\""\""}"",
  ""label_mode"": ""0"",
  ""label_text"": ""Type Number"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.type_number\"",\""default\"":\""\""}"",
  ""name"": ""type_number"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: manage  id: c213bc73-f919-48e8-bd24-a35ff0225e59 >>
    {
        var id = new Guid("c213bc73-f919-48e8-bd24-a35ff0225e59");
        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
        Guid? nodeId = null;
        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""administrator\\\"")\"",\""default\"":\""\""}"",
  ""label_mode"": ""0"",
  ""label_text"": ""Image (Url)"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.preview\"",\""default\"":\""\""}"",
  ""name"": ""preview"",
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
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 95043bf9-0115-4b0f-b09e-a427850a1a76 >>
    {
        var id = new Guid("95043bf9-0115-4b0f-b09e-a427850a1a76");
        Guid? parentId = new Guid("096b895e-69db-47be-8478-9cad4e66fefa");
        Guid? nodeId = null;
        Guid pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 8ee03dfb-3827-4de9-81a5-6377aabf269f >>
    {
        var id = new Guid("8ee03dfb-3827-4de9-81a5-6377aabf269f");
        Guid? parentId = new Guid("a138aa3e-232a-474f-a6e1-b948d0918ea9");
        Guid? nodeId = null;
        Guid pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.project_id\"",\""default\"":\""\""}"",
  ""name"": ""project_id"",
  ""class"": ""w-100"",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ProjectSelectOptions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""ajax_datasource_api"": """",
  ""description"": """",
  ""label_help_text"": """",
  ""select_match_type"": ""0""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: a6362264-2e27-4970-8954-0b45077c9d5d >>
    {
        var id = new Guid("a6362264-2e27-4970-8954-0b45077c9d5d");
        Guid? parentId = new Guid("24509132-94c9-49ef-8c09-074511b8b9f5");
        Guid? nodeId = null;
        Guid pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
        var containerId = "column1";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_id\"",\""default\"":\""\""}"",
  ""name"": ""article_id"",
  ""class"": ""mr-3 article-select"",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ArticleSelectOptions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""ajax_datasource_api"": """",
  ""description"": """",
  ""label_help_text"": """",
  ""select_match_type"": ""0""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 130fde69-3a33-4687-b5b8-083651829b6e >>
    {
        var id = new Guid("130fde69-3a33-4687-b5b8-083651829b6e");
        Guid? parentId = new Guid("dcb95051-8699-4584-b9fd-2cdd01a350a1");
        Guid? nodeId = null;
        Guid pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
        var componentName = "WebVella.Erp.Web.Components.PcRow";
        var containerId = "body";
        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 12,
  ""container1_span_md"": 6,
  ""container1_span_lg"": 0,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 12,
  ""container2_span_sm"": 0,
  ""container2_span_md"": 6,
  ""container2_span_lg"": 0,
  ""container2_span_xl"": 0,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 0,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""1"",
  ""container2_flex_order"": 0,
  ""container3_span"": 0,
  ""container3_span_sm"": 0,
  ""container3_span_md"": 0,
  ""container3_span_lg"": 0,
  ""container3_span_xl"": 0,
  ""container3_offset"": 0,
  ""container3_offset_sm"": 0,
  ""container3_offset_md"": 0,
  ""container3_offset_lg"": 0,
  ""container3_offset_xl"": 0,
  ""container3_flex_self_align"": ""1"",
  ""container3_flex_order"": 0,
  ""container4_span"": 0,
  ""container4_span_sm"": 0,
  ""container4_span_md"": 0,
  ""container4_span_lg"": 0,
  ""container4_span_xl"": 0,
  ""container4_offset"": 0,
  ""container4_offset_sm"": 0,
  ""container4_offset_md"": 0,
  ""container4_offset_lg"": 0,
  ""container4_offset_xl"": 0,
  ""container4_flex_self_align"": ""1"",
  ""container4_flex_order"": 0,
  ""container5_span"": 0,
  ""container5_span_sm"": 0,
  ""container5_span_md"": 0,
  ""container5_span_lg"": 0,
  ""container5_span_xl"": 0,
  ""container5_offset"": 0,
  ""container5_offset_sm"": 0,
  ""container5_offset_md"": 0,
  ""container5_offset_lg"": 0,
  ""container5_offset_xl"": 0,
  ""container5_flex_self_align"": ""1"",
  ""container5_flex_order"": 0,
  ""container6_span"": 0,
  ""container6_span_sm"": 0,
  ""container6_span_md"": 0,
  ""container6_span_lg"": 0,
  ""container6_span_xl"": 0,
  ""container6_offset"": 0,
  ""container6_offset_sm"": 0,
  ""container6_offset_md"": 0,
  ""container6_offset_lg"": 0,
  ""container6_offset_xl"": 0,
  ""container6_flex_self_align"": ""1"",
  ""container6_flex_order"": 0,
  ""container7_span"": 0,
  ""container7_span_sm"": 0,
  ""container7_span_md"": 0,
  ""container7_span_lg"": 0,
  ""container7_span_xl"": 0,
  ""container7_offset"": 0,
  ""container7_offset_sm"": 0,
  ""container7_offset_md"": 0,
  ""container7_offset_lg"": 0,
  ""container7_offset_xl"": 0,
  ""container7_flex_self_align"": ""1"",
  ""container7_flex_order"": 0,
  ""container8_span"": 0,
  ""container8_span_sm"": 0,
  ""container8_span_md"": 0,
  ""container8_span_lg"": 0,
  ""container8_span_xl"": 0,
  ""container8_offset"": 0,
  ""container8_offset_sm"": 0,
  ""container8_offset_md"": 0,
  ""container8_offset_lg"": 0,
  ""container8_offset_xl"": 0,
  ""container8_flex_self_align"": ""1"",
  ""container8_flex_order"": 0,
  ""container9_span"": 0,
  ""container9_span_sm"": 0,
  ""container9_span_md"": 0,
  ""container9_span_lg"": 0,
  ""container9_span_xl"": 0,
  ""container9_offset"": 0,
  ""container9_offset_sm"": 0,
  ""container9_offset_md"": 0,
  ""container9_offset_lg"": 0,
  ""container9_offset_xl"": 0,
  ""container9_flex_self_align"": ""1"",
  ""container9_flex_order"": 0,
  ""container10_span"": 0,
  ""container10_span_sm"": 0,
  ""container10_span_md"": 0,
  ""container10_span_lg"": 0,
  ""container10_span_xl"": 0,
  ""container10_offset"": 0,
  ""container10_offset_sm"": 0,
  ""container10_offset_md"": 0,
  ""container10_offset_lg"": 0,
  ""container10_offset_xl"": 0,
  ""container10_flex_self_align"": ""1"",
  ""container10_flex_order"": 0,
  ""container11_span"": 0,
  ""container11_span_sm"": 0,
  ""container11_span_md"": 0,
  ""container11_span_lg"": 0,
  ""container11_span_xl"": 0,
  ""container11_offset"": 0,
  ""container11_offset_sm"": 0,
  ""container11_offset_md"": 0,
  ""container11_offset_lg"": 0,
  ""container11_offset_xl"": 0,
  ""container11_flex_self_align"": ""1"",
  ""container11_flex_order"": 0,
  ""container12_span"": 0,
  ""container12_span_sm"": 0,
  ""container12_span_md"": 0,
  ""container12_span_lg"": 0,
  ""container12_span_xl"": 0,
  ""container12_offset"": 0,
  ""container12_offset_sm"": 0,
  ""container12_offset_md"": 0,
  ""container12_offset_lg"": 0,
  ""container12_offset_xl"": 0,
  ""container12_flex_self_align"": ""1"",
  ""container12_flex_order"": 0
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: create  id: b31f8c1d-5fe5-4252-a88c-9413261b0e5f >>
    {
        var id = new Guid("b31f8c1d-5fe5-4252-a88c-9413261b0e5f");
        Guid? parentId = new Guid("130fde69-3a33-4687-b5b8-083651829b6e");
        Guid? nodeId = null;
        var pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
        var componentName = "WebVella.Erp.Web.Components.PcFieldFile";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Bill"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.bill\"",\""default\"":\""\""}"",
  ""name"": ""bill"",
  ""class"": """",
  ""accept"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: a8218fd1-4dad-4508-b2e1-f0fbb262532e >>
    {
        var id = new Guid("a8218fd1-4dad-4508-b2e1-f0fbb262532e");
        Guid? parentId = new Guid("b24f4d05-a318-4b04-8582-44427e8a7767");
        Guid? nodeId = null;
        Guid pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "body";
        var options = @"{
  ""type"": ""1"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-search"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee""
}";
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 303aac7d-7690-4956-993c-575ca052135d >>
    {
        var id = new Guid("303aac7d-7690-4956-993c-575ca052135d");
        Guid? parentId = new Guid("b24f4d05-a318-4b04-8582-44427e8a7767");
        Guid? nodeId = null;
        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Page Size"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RequestQuery.page_size\"",\""default\"":\""\""}"",
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
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b >>
    {
        var id = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
        Guid? parentId = new Guid("5a6b92f3-20a3-4ee0-b851-dcce0443ce5b");
        Guid? nodeId = null;
        Guid pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var componentName = "WebVella.Erp.Web.Components.PcRow";
        var containerId = "body";
        var options = @"{
  ""visible_columns"": 2,
  ""class"": ""flex-row-reverse"",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 12,
  ""container1_span_md"": 6,
  ""container1_span_lg"": 5,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 12,
  ""container2_span_sm"": 12,
  ""container2_span_md"": 6,
  ""container2_span_lg"": 6,
  ""container2_span_xl"": 0,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 0,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""1"",
  ""container2_flex_order"": 0,
  ""container3_span"": 0,
  ""container3_span_sm"": 0,
  ""container3_span_md"": 0,
  ""container3_span_lg"": 0,
  ""container3_span_xl"": 0,
  ""container3_offset"": 0,
  ""container3_offset_sm"": 0,
  ""container3_offset_md"": 0,
  ""container3_offset_lg"": 0,
  ""container3_offset_xl"": 0,
  ""container3_flex_self_align"": ""1"",
  ""container3_flex_order"": 0,
  ""container4_span"": 0,
  ""container4_span_sm"": 0,
  ""container4_span_md"": 0,
  ""container4_span_lg"": 0,
  ""container4_span_xl"": 0,
  ""container4_offset"": 0,
  ""container4_offset_sm"": 0,
  ""container4_offset_md"": 0,
  ""container4_offset_lg"": 0,
  ""container4_offset_xl"": 0,
  ""container4_flex_self_align"": ""1"",
  ""container4_flex_order"": 0,
  ""container5_span"": 0,
  ""container5_span_sm"": 0,
  ""container5_span_md"": 0,
  ""container5_span_lg"": 0,
  ""container5_span_xl"": 0,
  ""container5_offset"": 0,
  ""container5_offset_sm"": 0,
  ""container5_offset_md"": 0,
  ""container5_offset_lg"": 0,
  ""container5_offset_xl"": 0,
  ""container5_flex_self_align"": ""1"",
  ""container5_flex_order"": 0,
  ""container6_span"": 0,
  ""container6_span_sm"": 0,
  ""container6_span_md"": 0,
  ""container6_span_lg"": 0,
  ""container6_span_xl"": 0,
  ""container6_offset"": 0,
  ""container6_offset_sm"": 0,
  ""container6_offset_md"": 0,
  ""container6_offset_lg"": 0,
  ""container6_offset_xl"": 0,
  ""container6_flex_self_align"": ""1"",
  ""container6_flex_order"": 0,
  ""container7_span"": 0,
  ""container7_span_sm"": 0,
  ""container7_span_md"": 0,
  ""container7_span_lg"": 0,
  ""container7_span_xl"": 0,
  ""container7_offset"": 0,
  ""container7_offset_sm"": 0,
  ""container7_offset_md"": 0,
  ""container7_offset_lg"": 0,
  ""container7_offset_xl"": 0,
  ""container7_flex_self_align"": ""1"",
  ""container7_flex_order"": 0,
  ""container8_span"": 0,
  ""container8_span_sm"": 0,
  ""container8_span_md"": 0,
  ""container8_span_lg"": 0,
  ""container8_span_xl"": 0,
  ""container8_offset"": 0,
  ""container8_offset_sm"": 0,
  ""container8_offset_md"": 0,
  ""container8_offset_lg"": 0,
  ""container8_offset_xl"": 0,
  ""container8_flex_self_align"": ""1"",
  ""container8_flex_order"": 0,
  ""container9_span"": 0,
  ""container9_span_sm"": 0,
  ""container9_span_md"": 0,
  ""container9_span_lg"": 0,
  ""container9_span_xl"": 0,
  ""container9_offset"": 0,
  ""container9_offset_sm"": 0,
  ""container9_offset_md"": 0,
  ""container9_offset_lg"": 0,
  ""container9_offset_xl"": 0,
  ""container9_flex_self_align"": ""1"",
  ""container9_flex_order"": 0,
  ""container10_span"": 0,
  ""container10_span_sm"": 0,
  ""container10_span_md"": 0,
  ""container10_span_lg"": 0,
  ""container10_span_xl"": 0,
  ""container10_offset"": 0,
  ""container10_offset_sm"": 0,
  ""container10_offset_md"": 0,
  ""container10_offset_lg"": 0,
  ""container10_offset_xl"": 0,
  ""container10_flex_self_align"": ""1"",
  ""container10_flex_order"": 0,
  ""container11_span"": 0,
  ""container11_span_sm"": 0,
  ""container11_span_md"": 0,
  ""container11_span_lg"": 0,
  ""container11_span_xl"": 0,
  ""container11_offset"": 0,
  ""container11_offset_sm"": 0,
  ""container11_offset_md"": 0,
  ""container11_offset_lg"": 0,
  ""container11_offset_xl"": 0,
  ""container11_flex_self_align"": ""1"",
  ""container11_flex_order"": 0,
  ""container12_span"": 0,
  ""container12_span_sm"": 0,
  ""container12_span_md"": 0,
  ""container12_span_lg"": 0,
  ""container12_span_xl"": 0,
  ""container12_offset"": 0,
  ""container12_offset_sm"": 0,
  ""container12_offset_md"": 0,
  ""container12_offset_lg"": 0,
  ""container12_offset_xl"": 0,
  ""container12_flex_self_align"": ""1"",
  ""container12_flex_order"": 0
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 0583e6a8-324c-4119-aa92-9c09dba5f796 >>
    {
        var id = new Guid("0583e6a8-324c-4119-aa92-9c09dba5f796");
        Guid? parentId = new Guid("dc0722d1-2b3f-4978-a532-fb73aa419363");
        Guid? nodeId = null;
        Guid pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""float-right"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/l/all?page_size={{RequestQuery.page_size}}&page={{RequestQuery.page}}&q_warehouse_v={{RequestQuery.q_warehouse_v}}&q_designation_v={{RequestQuery.q_designation_v}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 3cc56313-2cb3-4d31-98e2-85fb465105b0 >>
    {
        var id = new Guid("3cc56313-2cb3-4d31-98e2-85fb465105b0");
        Guid? parentId = new Guid("0f6acb1a-be9a-4ebe-b8a3-e43d9011a703");
        Guid? nodeId = null;
        Guid pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "actions";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Add"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/l/all?hookKey=warehouse_location_create&page_size={{RequestQuery.page_size}}&page={{RequestQuery.page}}&q_warehouse_v={{RequestQuery.q_warehouse_v}}&q_designation_v={{RequestQuery.q_designation_v}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 4338f485-b97b-4882-8f3d-432801ca059d >>
    {
        var id = new Guid("4338f485-b97b-4882-8f3d-432801ca059d");
        Guid? parentId = new Guid("0e2fa274-aab8-473d-a039-f98f57037a3b");
        Guid? nodeId = null;
        Guid pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "column1";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 2,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllWarehouseLocations\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": ""mb-5"",
  ""striped"": ""true"",
  ""small"": ""true"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No warehouse locations"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/l/all?hookKey=warehouse_location_manage&hId={{RowRecord.id}}&page_size={{RequestQuery.page_size}}&page={{RequestQuery.page}}&q_warehouse_v={{RequestQuery.q_warehouse_v}}&q_designation_v={{RequestQuery.q_designation_v}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Warehouse"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""true"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Location"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""true"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": """",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""4"",
  ""container4_label"": ""Designation"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""true"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Blocked"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""true"",
  ""container5_sortable"": ""true"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 6c22d47e-8b18-4eb8-9671-7dbddbeba234 >>
    {
        var id = new Guid("6c22d47e-8b18-4eb8-9671-7dbddbeba234");
        Guid? parentId = new Guid("78db2536-416a-440f-b767-19c764347a12");
        Guid? nodeId = null;
        Guid pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: free ID: 78b69008-f3ac-4c0f-a11a-c0a0587a08a7 >>
    {
        var id = new Guid("78b69008-f3ac-4c0f-a11a-c0a0587a08a7");
        Guid? parentId = new Guid("2a27f670-8172-4f0e-a2f7-5c4330b878af");
        Guid? nodeId = null;
        Guid pageId = new Guid("c2058e80-bbd7-4296-bef3-ff39670b2bd8");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/projects/r/{{RecordId}}/detail?{{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 40fe4624-95df-4eab-bc15-b9e16da932b3 >>
    {
        var id = new Guid("40fe4624-95df-4eab-bc15-b9e16da932b3");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcForm";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-5c293457-0357-45cd-bf31-9bbf3b8ad13b"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 74791346-00cd-40f8-923e-ab3d8fbe2e5a >>
    {
        var id = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? parentId = new Guid("40fe4624-95df-4eab-bc15-b9e16da932b3");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcDrawer";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""title"": ""Search Entries"",
  ""width"": ""550px"",
  ""class"": """",
  ""body_class"": """",
  ""title_action_html"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 1bb66586-a7ea-40e5-8cf0-85a68db9f7c6 >>
    {
        var id = new Guid("1bb66586-a7ea-40e5-8cf0-85a68db9f7c6");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Part Number"",
  ""name"": ""part_number"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 93e2aae9-3c8a-487f-8779-61b23660b4f4 >>
    {
        var id = new Guid("93e2aae9-3c8a-487f-8779-61b23660b4f4");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Designation"",
  ""name"": ""designation"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 5;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: fa855f2c-79ef-4cda-a7d4-7b4ec6cfeef3 >>
    {
        var id = new Guid("fa855f2c-79ef-4cda-a7d4-7b4ec6cfeef3");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Manufacturer"",
  ""name"": ""manufacturer"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 6ee9f177-f97b-4f67-a9ba-8608c6cffdd0 >>
    {
        var id = new Guid("6ee9f177-f97b-4f67-a9ba-8608c6cffdd0");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Order Number"",
  ""name"": ""order_number"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: f7884f0c-d086-46ef-ad01-a47280fba2ba >>
    {
        var id = new Guid("f7884f0c-d086-46ef-ad01-a47280fba2ba");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Type Number"",
  ""name"": ""type_number"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 67797464-0d64-42b7-9877-50fc30acce7a >>
    {
        var id = new Guid("67797464-0d64-42b7-9877-50fc30acce7a");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""State"",
  ""name"": ""state"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""17"",
  ""query_type"": ""3"",
  ""query_options"": [
    ""3""
  ],
  ""prefix"": """",
  ""data_type"": ""WebVella.Erp.Plugins.Duatec.OrderEntryState""
}";
        var weight = 6;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: bda32240-436e-4009-8a8e-3590a83d410b >>
    {
        var id = new Guid("bda32240-436e-4009-8a8e-3590a83d410b");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "body";
        var options = @"{
  ""type"": ""1"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-search"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-5c293457-0357-45cd-bf31-9bbf3b8ad13b""
}";
        var weight = 8;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: detail  id: c1cec9c7-9e55-482d-ad60-02656ad62ce6 >>
    {
        var id = new Guid("c1cec9c7-9e55-482d-ad60-02656ad62ce6");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        var pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
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
        var weight = 7;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: detail  id: e35692d1-2f49-4042-ad9d-200cfcf5c724 >>
    {
        var id = new Guid("e35692d1-2f49-4042-ad9d-200cfcf5c724");
        Guid? parentId = new Guid("74791346-00cd-40f8-923e-ab3d8fbe2e5a");
        Guid? nodeId = null;
        var pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""name"": ""returnUrl"",
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
        var weight = 9;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 5ac32502-8a29-4f5f-973e-b03466849062 >>
    {
        var id = new Guid("5ac32502-8a29-4f5f-973e-b03466849062");
        Guid? parentId = new Guid("40fe4624-95df-4eab-bc15-b9e16da932b3");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""true"",
  ""visible_columns"": 9,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""ExtendedOrderEntries4Order\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": ""mt-3"",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No Entries"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": """",
  ""compatibility"": ""article-amount"",
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
  ""container2_name"": ""article"",
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
  ""container7_label"": ""Ordered"",
  ""container7_width"": """",
  ""container7_name"": ""amount"",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": ""Received"",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""3"",
  ""container8_horizontal_align"": ""2"",
  ""container9_label"": ""State"",
  ""container9_width"": """",
  ""container9_name"": """",
  ""container9_nowrap"": ""false"",
  ""container9_sortable"": ""false"",
  ""container9_class"": """",
  ""container9_vertical_align"": ""3"",
  ""container9_horizontal_align"": ""2"",
  ""container10_label"": ""State"",
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
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 4f89da40-7976-4079-9d61-c52fd63494a7 >>
    {
        var id = new Guid("4f89da40-7976-4079-9d61-c52fd63494a7");
        Guid? parentId = new Guid("5ac32502-8a29-4f5f-973e-b03466849062");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
        var containerId = "column7";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.amount\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
  ""class"": ""d-none"",
  ""decimal_digits"": 2,
  ""min"": 0,
  ""max"": 0,
  ""step"": 0,
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 37bdfeb7-12d8-4532-bc83-0afc1cc70321 >>
    {
        var id = new Guid("37bdfeb7-12d8-4532-bc83-0afc1cc70321");
        Guid? parentId = new Guid("5ac32502-8a29-4f5f-973e-b03466849062");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_id\"",\""default\"":\""\""}"",
  ""name"": ""article_id"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 09fa615e-3710-4dda-9c97-4ec56e24eb53 >>
    {
        var id = new Guid("09fa615e-3710-4dda-9c97-4ec56e24eb53");
        Guid? parentId = new Guid("b3916ebd-158b-4ff9-b6e5-b41489e94040");
        Guid? nodeId = null;
        Guid pageId = new Guid("0f7eab0e-262f-41eb-9960-9945dbd260e9");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 16a20f9c-5bed-48e6-8747-4fbd115a4478 >>
    {
        var id = new Guid("16a20f9c-5bed-48e6-8747-4fbd115a4478");
        Guid? parentId = new Guid("6ba34a78-849f-455e-94bc-c274b663ad0c");
        Guid? nodeId = null;
        Guid pageId = new Guid("0f7eab0e-262f-41eb-9960-9945dbd260e9");
        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
        var containerId = "column1";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_id\"",\""default\"":\""\""}"",
  ""name"": ""article_id"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ArticleSelectOptions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""ajax_datasource_api"": """",
  ""description"": """",
  ""label_help_text"": """",
  ""select_match_type"": ""0""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: c97380b4-e96c-4198-8010-f1bc5ab0f54b >>
    {
        var id = new Guid("c97380b4-e96c-4198-8010-f1bc5ab0f54b");
        Guid? parentId = new Guid("66913be0-f98e-4851-9d98-272b13df6729");
        Guid? nodeId = null;
        Guid pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Add"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/c/create?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 919f19ba-19c1-43e7-b71f-9f3b99962000 >>
    {
        var id = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? parentId = new Guid("5e31f430-5a41-45f2-98a3-c432f00a795d");
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcRow";
        var containerId = "actions";
        var options = @"{
  ""visible_columns"": 3,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 12,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 0,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 12,
  ""container2_span_sm"": 0,
  ""container2_span_md"": 4,
  ""container2_span_lg"": 0,
  ""container2_span_xl"": 0,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 0,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""1"",
  ""container2_flex_order"": 0,
  ""container3_span"": 12,
  ""container3_span_sm"": 0,
  ""container3_span_md"": 4,
  ""container3_span_lg"": 0,
  ""container3_span_xl"": 0,
  ""container3_offset"": 0,
  ""container3_offset_sm"": 0,
  ""container3_offset_md"": 0,
  ""container3_offset_lg"": 0,
  ""container3_offset_xl"": 0,
  ""container3_flex_self_align"": ""1"",
  ""container3_flex_order"": 0,
  ""container4_span"": 0,
  ""container4_span_sm"": 0,
  ""container4_span_md"": 0,
  ""container4_span_lg"": 0,
  ""container4_span_xl"": 0,
  ""container4_offset"": 0,
  ""container4_offset_sm"": 0,
  ""container4_offset_md"": 0,
  ""container4_offset_lg"": 0,
  ""container4_offset_xl"": 0,
  ""container4_flex_self_align"": ""1"",
  ""container4_flex_order"": 0,
  ""container5_span"": 0,
  ""container5_span_sm"": 0,
  ""container5_span_md"": 0,
  ""container5_span_lg"": 0,
  ""container5_span_xl"": 0,
  ""container5_offset"": 0,
  ""container5_offset_sm"": 0,
  ""container5_offset_md"": 0,
  ""container5_offset_lg"": 0,
  ""container5_offset_xl"": 0,
  ""container5_flex_self_align"": ""1"",
  ""container5_flex_order"": 0,
  ""container6_span"": 0,
  ""container6_span_sm"": 0,
  ""container6_span_md"": 0,
  ""container6_span_lg"": 0,
  ""container6_span_xl"": 0,
  ""container6_offset"": 0,
  ""container6_offset_sm"": 0,
  ""container6_offset_md"": 0,
  ""container6_offset_lg"": 0,
  ""container6_offset_xl"": 0,
  ""container6_flex_self_align"": ""1"",
  ""container6_flex_order"": 0,
  ""container7_span"": 0,
  ""container7_span_sm"": 0,
  ""container7_span_md"": 0,
  ""container7_span_lg"": 0,
  ""container7_span_xl"": 0,
  ""container7_offset"": 0,
  ""container7_offset_sm"": 0,
  ""container7_offset_md"": 0,
  ""container7_offset_lg"": 0,
  ""container7_offset_xl"": 0,
  ""container7_flex_self_align"": ""1"",
  ""container7_flex_order"": 0,
  ""container8_span"": 0,
  ""container8_span_sm"": 0,
  ""container8_span_md"": 0,
  ""container8_span_lg"": 0,
  ""container8_span_xl"": 0,
  ""container8_offset"": 0,
  ""container8_offset_sm"": 0,
  ""container8_offset_md"": 0,
  ""container8_offset_lg"": 0,
  ""container8_offset_xl"": 0,
  ""container8_flex_self_align"": ""1"",
  ""container8_flex_order"": 0,
  ""container9_span"": 0,
  ""container9_span_sm"": 0,
  ""container9_span_md"": 0,
  ""container9_span_lg"": 0,
  ""container9_span_xl"": 0,
  ""container9_offset"": 0,
  ""container9_offset_sm"": 0,
  ""container9_offset_md"": 0,
  ""container9_offset_lg"": 0,
  ""container9_offset_xl"": 0,
  ""container9_flex_self_align"": ""1"",
  ""container9_flex_order"": 0,
  ""container10_span"": 0,
  ""container10_span_sm"": 0,
  ""container10_span_md"": 0,
  ""container10_span_lg"": 0,
  ""container10_span_xl"": 0,
  ""container10_offset"": 0,
  ""container10_offset_sm"": 0,
  ""container10_offset_md"": 0,
  ""container10_offset_lg"": 0,
  ""container10_offset_xl"": 0,
  ""container10_flex_self_align"": ""1"",
  ""container10_flex_order"": 0,
  ""container11_span"": 0,
  ""container11_span_sm"": 0,
  ""container11_span_md"": 0,
  ""container11_span_lg"": 0,
  ""container11_span_xl"": 0,
  ""container11_offset"": 0,
  ""container11_offset_sm"": 0,
  ""container11_offset_md"": 0,
  ""container11_offset_lg"": 0,
  ""container11_offset_xl"": 0,
  ""container11_flex_self_align"": ""1"",
  ""container11_flex_order"": 0,
  ""container12_span"": 0,
  ""container12_span_sm"": 0,
  ""container12_span_md"": 0,
  ""container12_span_lg"": 0,
  ""container12_span_xl"": 0,
  ""container12_offset"": 0,
  ""container12_offset_sm"": 0,
  ""container12_offset_md"": 0,
  ""container12_offset_lg"": 0,
  ""container12_offset_xl"": 0,
  ""container12_flex_self_align"": ""1"",
  ""container12_flex_order"": 0
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 145173af-972b-4f83-9aae-31becdb272f0 >>
    {
        var id = new Guid("145173af-972b-4f83-9aae-31becdb272f0");
        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Orders"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 ml-0 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$exists(Record.$order_project)\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/order-management/orders/orders/l/all?q_project_number_v={{Record.number}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: f5855407-9347-4604-a6a4-2fc75fe9b192 >>
    {
        var id = new Guid("f5855407-9347-4604-a6a4-2fc75fe9b192");
        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Add Part List"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 mb-1 mt-1 text-nowrap"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/part-lists/part-lists/c/create?pId={{RecordId}}&returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 0200f561-6f16-4e7b-a598-318241180421 >>
    {
        var id = new Guid("0200f561-6f16-4e7b-a598-318241180421");
        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Free Inventory"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 ml-0 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-boxes"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Projects.ProjectHasInventoryEntriesToReleaseSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/inventory-mass-reservation/m/{{RecordId}}/free?hookKey=inventory_reservation_mass_release&returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: eaed20ab-2905-427c-bde1-ca39904044f3 >>
    {
        var id = new Guid("eaed20ab-2905-427c-bde1-ca39904044f3");
        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/manage?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: detail  id: 20dd5a5f-3512-4993-afe7-9ffa2bfff3e6 >>
    {
        var id = new Guid("20dd5a5f-3512-4993-afe7-9ffa2bfff3e6");
        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? nodeId = null;
        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Overall Overview"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 text-nowrap mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-clipboard-list"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RecordId}}/order-list?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 9f83935b-6454-493d-801a-43fd1968c7ea >>
    {
        var id = new Guid("9f83935b-6454-493d-801a-43fd1968c7ea");
        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Reservation"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 ml-0 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-boxes"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Projects.ProjectHasAvailableInventoryEntriesSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/inventory-mass-reservation/m/{{RecordId}}/reserve?hookKey=inventory_reservation_mass_reservation&returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: aeaa99f9-51ec-48e3-bd75-2ab734bf2e94 >>
    {
        var id = new Guid("aeaa99f9-51ec-48e3-bd75-2ab734bf2e94");
        Guid? parentId = new Guid("b4d4e918-6963-4053-a27e-cd964963e369");
        Guid? nodeId = null;
        Guid pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Move"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-long-arrow-alt-up"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/move?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 5eec93bc-ff67-486f-aaea-966478bc3218 >>
    {
        var id = new Guid("5eec93bc-ff67-486f-aaea-966478bc3218");
        Guid? parentId = new Guid("b4d4e918-6963-4053-a27e-cd964963e369");
        Guid? nodeId = null;
        Guid pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Take Out"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 ml-0 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-hand-holding"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/take-out?returnUrl={{ReturnUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 60f7995e-a747-41fb-b38b-4a4de2438869 >>
    {
        var id = new Guid("60f7995e-a747-41fb-b38b-4a4de2438869");
        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
        Guid? nodeId = null;
        Guid pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/c/create?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 0d9592c3-b250-4fd7-b9ea-ec53ba251e96 >>
    {
        var id = new Guid("0d9592c3-b250-4fd7-b9ea-ec53ba251e96");
        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
        Guid? nodeId = null;
        Guid pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Data Portal"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 text-nowrap mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/articles/a/import?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 8e8c1555-e3fa-4e9c-bc6d-36109f9b8027 >>
    {
        var id = new Guid("8e8c1555-e3fa-4e9c-bc6d-36109f9b8027");
        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
        Guid? nodeId = null;
        Guid pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""File Import"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-file-code"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/articles/a/file-import?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 18e9f7c3-b430-4bee-abbd-d4760a3b6735 >>
    {
        var id = new Guid("18e9f7c3-b430-4bee-abbd-d4760a3b6735");
        Guid? parentId = new Guid("54d2bd4c-ae7e-4349-ac86-9334580d672c");
        Guid? nodeId = null;
        Guid pageId = new Guid("4ceba53a-d8b8-4fc0-a72b-7bcfbfae6ad6");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 245b85bd-13d9-4a6a-b4d7-ed752f697147 >>
    {
        var id = new Guid("245b85bd-13d9-4a6a-b4d7-ed752f697147");
        Guid? parentId = new Guid("8a3de454-1ab5-4c27-a5fb-54aaf022811e");
        Guid? nodeId = null;
        Guid pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Data Portal"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/articles/a/import-manufacturers?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: f92a7378-b9be-43ef-9a67-92285ed21c24 >>
    {
        var id = new Guid("f92a7378-b9be-43ef-9a67-92285ed21c24");
        Guid? parentId = new Guid("8a3de454-1ab5-4c27-a5fb-54aaf022811e");
        Guid? nodeId = null;
        Guid pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""0\"",\""string\"":\""$hasRole(\\\""article-admin\\\"")\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/c/create?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: f5f2afb1-4bc0-43c1-b196-ace7fe949f3f >>
    {
        var id = new Guid("f5f2afb1-4bc0-43c1-b196-ace7fe949f3f");
        Guid? parentId = new Guid("9a2721d4-3ab3-43a6-9512-7dc90a18569b");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Compare"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-clipboard-list"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/project-management/a/diff?part_list1={{RecordId}}&part_list2={{RecordId}}&returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 52105ccd-a79d-49cc-855c-edee2b702dd2 >>
    {
        var id = new Guid("52105ccd-a79d-49cc-855c-edee2b702dd2");
        Guid? parentId = new Guid("9a2721d4-3ab3-43a6-9512-7dc90a18569b");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""File Import"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""ml-0 text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-file-code"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/a/part-list-import?plId={{RecordId}}&returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 5a313bf9-9b0c-44ef-a974-126af3af4a43 >>
    {
        var id = new Guid("5a313bf9-9b0c-44ef-a974-126af3af4a43");
        Guid? parentId = new Guid("9a2721d4-3ab3-43a6-9512-7dc90a18569b");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/manage?hookKey=part_list_update&returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: reserve ID: 1b6be8ca-40bd-4376-b6f5-73bccb6af2a2 >>
    {
        var id = new Guid("1b6be8ca-40bd-4376-b6f5-73bccb6af2a2");
        Guid? parentId = new Guid("96d0d4d9-236d-44fc-9128-2667a2f3ffe7");
        Guid? nodeId = null;
        Guid pageId = new Guid("ee952f02-57f0-4967-ac79-f6093d70d16a");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/projects/r/{{RecordId}}/detail?{{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: db985185-4c22-4c34-8559-91da6dcc184c >>
    {
        var id = new Guid("db985185-4c22-4c34-8559-91da6dcc184c");
        Guid? parentId = new Guid("2167f13c-9120-4385-8aa0-f4bcdfebb445");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "actions";
        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 text-nowrap mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fa fa-search"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 1ffbb181-ca96-4166-95e8-3a1e764d9b8b >>
    {
        var id = new Guid("1ffbb181-ca96-4166-95e8-3a1e764d9b8b");
        Guid? parentId = new Guid("b0b0e6db-06ce-4bec-accf-046b163dd649");
        Guid? nodeId = null;
        Guid pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.project_id\"",\""default\"":\""\""}"",
  ""name"": ""project_id"",
  ""class"": ""w-100"",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ProjectSelectOptions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""ajax_datasource_api"": """",
  ""description"": """",
  ""label_help_text"": """",
  ""select_match_type"": ""0""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 2d71e710-83df-45b8-947c-b85e47538e42 >>
    {
        var id = new Guid("2d71e710-83df-45b8-947c-b85e47538e42");
        Guid? parentId = new Guid("37a478f9-7e69-4b8e-bb66-76e1e4dbc589");
        Guid? nodeId = null;
        Guid pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcEditableGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 3,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""$orderBy($include(Record.$order_entry_order, \\\""$order_entry_article\\\""), \\\""$order_entry_article.part_number\\\"")\"",\""default\"":\""\""}"",
  ""has-add-button"": ""true"",
  ""has-delete-buttons"": ""true"",
  ""allow-copy"": ""true"",
  ""allow-paste"": ""true"",
  ""allow-add"": ""true"",
  ""allow-delete"": ""true"",
  ""compatibility"": ""article-amount"",
  ""name"": """",
  ""class"": ""mt-0"",
  ""striped"": ""true"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""has_thead"": ""true"",
  ""container1_label"": ""Article"",
  ""container1_width"": ""20%"",
  ""container1_name"": ""article"",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Amount"",
  ""container2_width"": ""30%"",
  ""container2_name"": ""amount"",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Expected Arrival"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": """",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""1"",
  ""container4_horizontal_align"": ""1"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""1"",
  ""container5_horizontal_align"": ""1"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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
        var weight = 5;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 0cf4bfa0-e6ba-4be1-ba02-11256aab0824 >>
    {
        var id = new Guid("0cf4bfa0-e6ba-4be1-ba02-11256aab0824");
        Guid? parentId = new Guid("2d71e710-83df-45b8-947c-b85e47538e42");
        Guid? nodeId = null;
        Guid pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
        var containerId = "column1";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_id\"",\""default\"":\""\""}"",
  ""name"": ""article_id"",
  ""class"": ""mr-3 article-select"",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ArticleSelectOptions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""ajax_datasource_api"": """",
  ""description"": """",
  ""label_help_text"": """",
  ""select_match_type"": ""0""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 90dc6058-6012-4a67-9454-2eb7b0993cdd >>
    {
        var id = new Guid("90dc6058-6012-4a67-9454-2eb7b0993cdd");
        Guid? parentId = new Guid("37a478f9-7e69-4b8e-bb66-76e1e4dbc589");
        Guid? nodeId = null;
        Guid pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcRow";
        var containerId = "body";
        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 6,
  ""container1_span_lg"": 0,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 12,
  ""container2_span_sm"": 0,
  ""container2_span_md"": 6,
  ""container2_span_lg"": 0,
  ""container2_span_xl"": 0,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 0,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""1"",
  ""container2_flex_order"": 0,
  ""container3_span"": 0,
  ""container3_span_sm"": 0,
  ""container3_span_md"": 0,
  ""container3_span_lg"": 0,
  ""container3_span_xl"": 0,
  ""container3_offset"": 0,
  ""container3_offset_sm"": 0,
  ""container3_offset_md"": 0,
  ""container3_offset_lg"": 0,
  ""container3_offset_xl"": 0,
  ""container3_flex_self_align"": ""1"",
  ""container3_flex_order"": 0,
  ""container4_span"": 0,
  ""container4_span_sm"": 0,
  ""container4_span_md"": 0,
  ""container4_span_lg"": 0,
  ""container4_span_xl"": 0,
  ""container4_offset"": 0,
  ""container4_offset_sm"": 0,
  ""container4_offset_md"": 0,
  ""container4_offset_lg"": 0,
  ""container4_offset_xl"": 0,
  ""container4_flex_self_align"": ""1"",
  ""container4_flex_order"": 0,
  ""container5_span"": 0,
  ""container5_span_sm"": 0,
  ""container5_span_md"": 0,
  ""container5_span_lg"": 0,
  ""container5_span_xl"": 0,
  ""container5_offset"": 0,
  ""container5_offset_sm"": 0,
  ""container5_offset_md"": 0,
  ""container5_offset_lg"": 0,
  ""container5_offset_xl"": 0,
  ""container5_flex_self_align"": ""1"",
  ""container5_flex_order"": 0,
  ""container6_span"": 0,
  ""container6_span_sm"": 0,
  ""container6_span_md"": 0,
  ""container6_span_lg"": 0,
  ""container6_span_xl"": 0,
  ""container6_offset"": 0,
  ""container6_offset_sm"": 0,
  ""container6_offset_md"": 0,
  ""container6_offset_lg"": 0,
  ""container6_offset_xl"": 0,
  ""container6_flex_self_align"": ""1"",
  ""container6_flex_order"": 0,
  ""container7_span"": 0,
  ""container7_span_sm"": 0,
  ""container7_span_md"": 0,
  ""container7_span_lg"": 0,
  ""container7_span_xl"": 0,
  ""container7_offset"": 0,
  ""container7_offset_sm"": 0,
  ""container7_offset_md"": 0,
  ""container7_offset_lg"": 0,
  ""container7_offset_xl"": 0,
  ""container7_flex_self_align"": ""1"",
  ""container7_flex_order"": 0,
  ""container8_span"": 0,
  ""container8_span_sm"": 0,
  ""container8_span_md"": 0,
  ""container8_span_lg"": 0,
  ""container8_span_xl"": 0,
  ""container8_offset"": 0,
  ""container8_offset_sm"": 0,
  ""container8_offset_md"": 0,
  ""container8_offset_lg"": 0,
  ""container8_offset_xl"": 0,
  ""container8_flex_self_align"": ""1"",
  ""container8_flex_order"": 0,
  ""container9_span"": 0,
  ""container9_span_sm"": 0,
  ""container9_span_md"": 0,
  ""container9_span_lg"": 0,
  ""container9_span_xl"": 0,
  ""container9_offset"": 0,
  ""container9_offset_sm"": 0,
  ""container9_offset_md"": 0,
  ""container9_offset_lg"": 0,
  ""container9_offset_xl"": 0,
  ""container9_flex_self_align"": ""1"",
  ""container9_flex_order"": 0,
  ""container10_span"": 0,
  ""container10_span_sm"": 0,
  ""container10_span_md"": 0,
  ""container10_span_lg"": 0,
  ""container10_span_xl"": 0,
  ""container10_offset"": 0,
  ""container10_offset_sm"": 0,
  ""container10_offset_md"": 0,
  ""container10_offset_lg"": 0,
  ""container10_offset_xl"": 0,
  ""container10_flex_self_align"": ""1"",
  ""container10_flex_order"": 0,
  ""container11_span"": 0,
  ""container11_span_sm"": 0,
  ""container11_span_md"": 0,
  ""container11_span_lg"": 0,
  ""container11_span_xl"": 0,
  ""container11_offset"": 0,
  ""container11_offset_sm"": 0,
  ""container11_offset_md"": 0,
  ""container11_offset_lg"": 0,
  ""container11_offset_xl"": 0,
  ""container11_flex_self_align"": ""1"",
  ""container11_flex_order"": 0,
  ""container12_span"": 0,
  ""container12_span_sm"": 0,
  ""container12_span_md"": 0,
  ""container12_span_lg"": 0,
  ""container12_span_xl"": 0,
  ""container12_offset"": 0,
  ""container12_offset_sm"": 0,
  ""container12_offset_md"": 0,
  ""container12_offset_lg"": 0,
  ""container12_offset_xl"": 0,
  ""container12_flex_self_align"": ""1"",
  ""container12_flex_order"": 0
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: manage  id: e5ff9443-071f-442e-a909-59a1ad43d7e6 >>
    {
        var id = new Guid("e5ff9443-071f-442e-a909-59a1ad43d7e6");
        Guid? parentId = new Guid("90dc6058-6012-4a67-9454-2eb7b0993cdd");
        Guid? nodeId = null;
        var pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcFieldFile";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Bill"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.bill\"",\""default\"":\""\""}"",
  ""name"": ""bill"",
  ""class"": """",
  ""accept"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 9e9abab2-2a4c-4d5a-b14e-f853277416d6 >>
    {
        var id = new Guid("9e9abab2-2a4c-4d5a-b14e-f853277416d6");
        Guid? parentId = new Guid("c73c3a1e-2519-43bd-a7d4-9eeaca3e6d7e");
        Guid? nodeId = null;
        Guid pageId = new Guid("16125e41-93a3-4735-a650-e78164aaf840");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/c/create?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: fc910475-59a3-4857-92a4-ca2927be989f >>
    {
        var id = new Guid("fc910475-59a3-4857-92a4-ca2927be989f");
        Guid? parentId = new Guid("4e62c27c-4f9e-4ec4-8445-a8dd0a810932");
        Guid? nodeId = null;
        Guid pageId = new Guid("cd9a4454-d22f-47e8-a430-83a91e955ed6");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/manage?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: part-list-import ID: 99d1c91a-cb14-4b2d-a50a-c6b7cf462718 >>
    {
        var id = new Guid("99d1c91a-cb14-4b2d-a50a-c6b7cf462718");
        Guid? parentId = new Guid("2b9ddbd6-d747-4549-91e8-8726020777b6");
        Guid? nodeId = null;
        Guid pageId = new Guid("71c6300b-5568-446b-9043-4c8b435d047f");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 7,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""Record.articles\"",\""default\"":\""\""}"",
  ""page_size"": 0,
  ""name"": """",
  ""prefix"": """",
  ""class"": ""mb-5 mt-5"",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""false"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": """",
  ""container1_label"": ""Part Number"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Type Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Order Number"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Designation"",
  ""container4_width"": ""500px"",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""State"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": ""Amount"",
  ""container6_width"": ""250px"",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""3"",
  ""container6_horizontal_align"": ""2"",
  ""container7_label"": ""Action"",
  ""container7_width"": ""250px"",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: part-list-import ID: ed9ca49b-0678-426e-a7cf-78e092816a64 >>
    {
        var id = new Guid("ed9ca49b-0678-426e-a7cf-78e092816a64");
        Guid? parentId = new Guid("2b9ddbd6-d747-4549-91e8-8726020777b6");
        Guid? nodeId = null;
        Guid pageId = new Guid("71c6300b-5568-446b-9043-4c8b435d047f");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "body";
        var options = @"{
  ""type"": ""1"",
  ""text"": ""Import"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""text-nowrap float-right mb-5"",
  ""id"": """",
  ""icon_class"": ""fa fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-2b9ddbd6-d747-4549-91e8-8726020777b6""
}";
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: part-list-import  id: b4efe7e2-2a2f-4263-9afa-4a5a0b6cdaf2 >>
    {
        var id = new Guid("b4efe7e2-2a2f-4263-9afa-4a5a0b6cdaf2");
        Guid? parentId = new Guid("2b9ddbd6-d747-4549-91e8-8726020777b6");
        Guid? nodeId = null;
        var pageId = new Guid("71c6300b-5568-446b-9043-4c8b435d047f");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Found {{Record.count}} articles\"",\""default\"":\""\""}"",
  ""name"": """",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: part-list-import ID: db3075c8-b9e2-4376-ac63-99f688960b1f >>
    {
        var id = new Guid("db3075c8-b9e2-4376-ac63-99f688960b1f");
        Guid? parentId = new Guid("2b9ddbd6-d747-4549-91e8-8726020777b6");
        Guid? nodeId = null;
        Guid pageId = new Guid("71c6300b-5568-446b-9043-4c8b435d047f");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "body";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""text-nowrap float-right mb-5"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 9d5e91b5-e01e-4d6b-9139-362b1a8f03a1 >>
    {
        var id = new Guid("9d5e91b5-e01e-4d6b-9139-362b1a8f03a1");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcForm";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-9d5e91b5-e01e-4d6b-9139-362b1a8f03a1"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 58dfe58c-44b0-4b65-960b-135a5273b3fe >>
    {
        var id = new Guid("58dfe58c-44b0-4b65-960b-135a5273b3fe");
        Guid? parentId = new Guid("9d5e91b5-e01e-4d6b-9139-362b1a8f03a1");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""true"",
  ""visible_columns"": 7,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllPartListEntries4PartList\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No Entries"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""true"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapNode.Name}}/part-list-entries/m/{{RowRecord.id}}/manage\"",\""default\"":\""\""}"",
  ""compatibility"": ""article-amount"",
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
  ""container2_name"": ""article"",
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
  ""container7_label"": ""Amount"",
  ""container7_width"": """",
  ""container7_name"": ""amount"",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": ""Device Tag(s)"",
  ""container8_width"": ""250px"",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""3"",
  ""container8_horizontal_align"": ""2"",
  ""container9_label"": ""Provided"",
  ""container9_width"": """",
  ""container9_name"": """",
  ""container9_nowrap"": ""false"",
  ""container9_sortable"": ""false"",
  ""container9_class"": """",
  ""container9_vertical_align"": ""3"",
  ""container9_horizontal_align"": ""2"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: f3f286bd-0b82-4f46-acad-7a0e9815e86f >>
    {
        var id = new Guid("f3f286bd-0b82-4f46-acad-7a0e9815e86f");
        Guid? parentId = new Guid("58dfe58c-44b0-4b65-960b-135a5273b3fe");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_id\"",\""default\"":\""\""}"",
  ""name"": ""article_id"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 86f2a6a6-81c1-4bf5-8b8f-71f5b0068fe1 >>
    {
        var id = new Guid("86f2a6a6-81c1-4bf5-8b8f-71f5b0068fe1");
        Guid? parentId = new Guid("58dfe58c-44b0-4b65-960b-135a5273b3fe");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
        var containerId = "column7";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.amount\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
  ""class"": ""d-none"",
  ""decimal_digits"": 2,
  ""min"": 0,
  ""max"": 0,
  ""step"": 0,
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: e7c28190-cb0d-479d-9dd2-42a8a91466b7 >>
    {
        var id = new Guid("e7c28190-cb0d-479d-9dd2-42a8a91466b7");
        Guid? parentId = new Guid("9d5e91b5-e01e-4d6b-9139-362b1a8f03a1");
        Guid? nodeId = null;
        Guid pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcDrawer";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""title"": ""Search Entries"",
  ""width"": ""550px"",
  ""class"": """",
  ""body_class"": """",
  ""title_action_html"": """"
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: detail  id: 134ae513-b510-4520-a9bb-ca443be5a0b2 >>
    {
        var id = new Guid("134ae513-b510-4520-a9bb-ca443be5a0b2");
        Guid? parentId = new Guid("9d5e91b5-e01e-4d6b-9139-362b1a8f03a1");
        Guid? nodeId = null;
        var pageId = new Guid("b48bb75a-c8b5-43fc-9f7e-97b10dc38129");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""name"": ""returnUrl"",
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
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: 42868ecd-d128-43da-90ae-be1856837da9 >>
    {
        var id = new Guid("42868ecd-d128-43da-90ae-be1856837da9");
        Guid? parentId = new Guid("5cdd4740-1c11-41e6-bb00-192b2d1f8654");
        Guid? nodeId = null;
        Guid pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column3";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: c38d0b46-a4c6-4194-a48c-a507b2990f6e >>
    {
        var id = new Guid("c38d0b46-a4c6-4194-a48c-a507b2990f6e");
        Guid? parentId = new Guid("9fcb841b-bebe-46c0-bf39-511e6ce83006");
        Guid? nodeId = null;
        Guid pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column1";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Book Goods"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": ""fas fa-clipboard"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/m/{{RecordId}}/book-goods?hookKey=goods_receiving_book&returnUrl={{ReturnUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: detail  id: e293fa42-63cd-4f4a-9483-5a34c2534003 >>
    {
        var id = new Guid("e293fa42-63cd-4f4a-9483-5a34c2534003");
        Guid? parentId = new Guid("e62db865-b9b0-4a9a-bc74-f343bd213357");
        Guid? nodeId = null;
        var pageId = new Guid("cd9a4454-d22f-47e8-a430-83a91e955ed6");
        var componentName = "WebVella.Erp.Web.Components.PcFieldFile";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Bill"",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.bill\"",\""default\"":\""\""}"",
  ""name"": ""bill"",
  ""class"": """",
  ""accept"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: diff ID: b74b6341-ab24-4d93-949b-21c7164dfa70 >>
    {
        var id = new Guid("b74b6341-ab24-4d93-949b-21c7164dfa70");
        Guid? parentId = new Guid("06bd8d6b-5738-4527-a81a-dbe4dc195f9b");
        Guid? nodeId = null;
        Guid pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
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
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: diff ID: 603c0460-91da-4bab-a294-1737ea55428a >>
    {
        var id = new Guid("603c0460-91da-4bab-a294-1737ea55428a");
        Guid? parentId = new Guid("b74b6341-ab24-4d93-949b-21c7164dfa70");
        Guid? nodeId = null;
        Guid pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
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
  ""form"": ""wv-06bd8d6b-5738-4527-a81a-dbe4dc195f9b""
}";
        var weight = 8;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: diff  id: 1141a71d-1e77-4958-94f9-d587a6453819 >>
    {
        var id = new Guid("1141a71d-1e77-4958-94f9-d587a6453819");
        Guid? parentId = new Guid("b74b6341-ab24-4d93-949b-21c7164dfa70");
        Guid? nodeId = null;
        var pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
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
        var weight = 7;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: diff ID: 7be12e36-a25e-44d0-9e3a-3ca5d8ad10dd >>
    {
        var id = new Guid("7be12e36-a25e-44d0-9e3a-3ca5d8ad10dd");
        Guid? parentId = new Guid("06bd8d6b-5738-4527-a81a-dbe4dc195f9b");
        Guid? nodeId = null;
        Guid pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""true"",
  ""visible_columns"": 10,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""PartListDiff\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No Entries"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": """",
  ""compatibility"": ""article-amount"",
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
  ""container2_name"": ""article"",
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
  ""container7_label"": ""Part List 1 Amount"",
  ""container7_width"": """",
  ""container7_name"": ""amount"",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""3"",
  ""container7_horizontal_align"": ""2"",
  ""container8_label"": ""Part List 2 Amount"",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""3"",
  ""container8_horizontal_align"": ""2"",
  ""container9_label"": ""Equal"",
  ""container9_width"": """",
  ""container9_name"": """",
  ""container9_nowrap"": ""false"",
  ""container9_sortable"": ""false"",
  ""container9_class"": """",
  ""container9_vertical_align"": ""3"",
  ""container9_horizontal_align"": ""2"",
  ""container10_label"": ""Diff"",
  ""container10_width"": """",
  ""container10_name"": ""amount"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: diff ID: 6ede3223-2045-472c-90cd-ac72c03e2c33 >>
    {
        var id = new Guid("6ede3223-2045-472c-90cd-ac72c03e2c33");
        Guid? parentId = new Guid("7be12e36-a25e-44d0-9e3a-3ca5d8ad10dd");
        Guid? nodeId = null;
        Guid pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
        var containerId = "column10";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.diff\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
  ""class"": ""d-none"",
  ""decimal_digits"": 2,
  ""min"": 0,
  ""max"": 0,
  ""step"": 0,
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: diff ID: ca14cd01-f677-43cd-8a7d-d8a1aef60aef >>
    {
        var id = new Guid("ca14cd01-f677-43cd-8a7d-d8a1aef60aef");
        Guid? parentId = new Guid("7be12e36-a25e-44d0-9e3a-3ca5d8ad10dd");
        Guid? nodeId = null;
        Guid pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_id\"",\""default\"":\""\""}"",
  ""name"": ""article_id"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: diff  id: 858cc410-51d1-40fe-abe3-7348dc7d690b >>
    {
        var id = new Guid("858cc410-51d1-40fe-abe3-7348dc7d690b");
        Guid? parentId = new Guid("06bd8d6b-5738-4527-a81a-dbe4dc195f9b");
        Guid? nodeId = null;
        var pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""name"": ""returnUrl"",
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
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: c52ce884-40d4-4908-9e2e-11ecbde73399 >>
    {
        var id = new Guid("c52ce884-40d4-4908-9e2e-11ecbde73399");
        Guid? parentId = new Guid("0cb50cde-1150-408f-9cbf-58aea1c08fbd");
        Guid? nodeId = null;
        Guid pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: b96c33e0-379e-4c91-9b74-abb7a3691b6f >>
    {
        var id = new Guid("b96c33e0-379e-4c91-9b74-abb7a3691b6f");
        Guid? parentId = new Guid("8e438719-124f-4806-8f38-ab73127a0f49");
        Guid? nodeId = null;
        Guid pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 596c3352-ce69-4335-9fa4-bf027c0f200a >>
    {
        var id = new Guid("596c3352-ce69-4335-9fa4-bf027c0f200a");
        Guid? parentId = new Guid("bf842818-8e7c-409f-8069-2af8c6df674c");
        Guid? nodeId = null;
        Guid pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-2 mb-2"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: create ID: 3358d79a-8a5a-4d9f-ac66-abb2696fefe5 >>
    {
        var id = new Guid("3358d79a-8a5a-4d9f-ac66-abb2696fefe5");
        Guid? parentId = new Guid("da14d155-afd3-4d3a-b3d1-b189fba8769d");
        Guid? nodeId = null;
        Guid pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: move ID: e8ca48ef-2fd0-41ff-bbda-525804bed67b >>
    {
        var id = new Guid("e8ca48ef-2fd0-41ff-bbda-525804bed67b");
        Guid? parentId = new Guid("719f176c-b85d-40e1-88e1-64de8ce07e6d");
        Guid? nodeId = null;
        Guid pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: take-out ID: 434d8473-9939-45e0-b4c8-93c93645b112 >>
    {
        var id = new Guid("434d8473-9939-45e0-b4c8-93c93645b112");
        Guid? parentId = new Guid("e8ce8366-d0ae-4c66-87df-d3ba7a97d89a");
        Guid? nodeId = null;
        Guid pageId = new Guid("fbd5bfd7-eba7-451f-b58f-4195106ec236");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-1 mb-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: manage ID: afbf7444-80af-4b8c-9eb0-2a6fc00b55cc >>
    {
        var id = new Guid("afbf7444-80af-4b8c-9eb0-2a6fc00b55cc");
        Guid? parentId = new Guid("eff7fae3-86c8-4efd-9fae-f1ba079a3cf7");
        Guid? nodeId = null;
        Guid pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column2";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-1 mt-1"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""ReturnUrl\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: orders ID: 986376da-691f-46b1-b939-685d23af516f >>
    {
        var id = new Guid("986376da-691f-46b1-b939-685d23af516f");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("ee2e83d3-7abb-4064-93d4-0c9f2afe3ca4");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 3,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""OpenOrders\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No open Orders"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""true"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Order Number"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Project Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Project Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": """",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""1"",
  ""container4_horizontal_align"": ""1"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""1"",
  ""container5_horizontal_align"": ""1"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7 >>
    {
        var id = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcForm";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: 7975a266-44cf-4616-9842-bfff0446c3b5 >>
    {
        var id = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
        Guid? parentId = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
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
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: 4053e3e4-0497-487c-b07f-af5c253312a7 >>
    {
        var id = new Guid("4053e3e4-0497-487c-b07f-af5c253312a7");
        Guid? parentId = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Short Name"",
  ""name"": ""short_name"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: b58a7cb6-d698-4def-9f45-91bd22d3544b >>
    {
        var id = new Guid("b58a7cb6-d698-4def-9f45-91bd22d3544b");
        Guid? parentId = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
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
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: d51d2ef9-d8d4-4976-8810-4a3c44431811 >>
    {
        var id = new Guid("d51d2ef9-d8d4-4976-8810-4a3c44431811");
        Guid? parentId = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Name"",
  ""name"": ""name"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: 58ae5214-c935-45fb-9b12-6c0da4b1f712 >>
    {
        var id = new Guid("58ae5214-c935-45fb-9b12-6c0da4b1f712");
        Guid? parentId = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "body";
        var options = @"{
  ""type"": ""1"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-search"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7""
}";
        var weight = 4;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: 0095678f-0baf-400f-9b67-188d739879f0 >>
    {
        var id = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
        Guid? parentId = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 5,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""EplanManufacturers\"",\""default\"":\""\""}"",
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
  ""empty_text"": ""No records"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""false"",
  ""detail_path"": """",
  ""container1_label"": ""Logo"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Short Name"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""true"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Website"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Import"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: import-manufacturers ID: cafb51d6-2ccd-42bc-bdab-9204ed1eba2c >>
    {
        var id = new Guid("cafb51d6-2ccd-42bc-bdab-9204ed1eba2c");
        Guid? parentId = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
        Guid? nodeId = null;
        Guid pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "column5";
        var options = @"{
  ""type"": ""2"",
  ""text"": ""Import"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImportButtonVisibilitySnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/a/import-manufacturers?hookKey=manufacturer_eplan_import&hEplanId={{RowRecord.eplan_id}}&page={{RequestQuery.page}}&page_size={{RequestQuery.page_size}}&q_short_name_v={{RequestQuery.q_short_name_v}}&q_name_v={{RequestQuery.q_name}}&returnUrl={{ReturnUrl}}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: import-manufacturers  id: 1227da91-2c2d-4251-b3aa-bc60038235f4 >>
    {
        var id = new Guid("1227da91-2c2d-4251-b3aa-bc60038235f4");
        Guid? parentId = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
        Guid? nodeId = null;
        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RequestQuery.returnUrl\"",\""default\"":\""\""}"",
  ""name"": ""returnUrl"",
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
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: detail ID: 63d4ff5f-e10a-4c03-9f1b-cba2b718979a >>
    {
        var id = new Guid("63d4ff5f-e10a-4c03-9f1b-cba2b718979a");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 2,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllPartLists\"",\""default\"":\""\""}"",
  ""page_size"": 0,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""true"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No part lists"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/part-lists/part-lists/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Part List"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""State"",
  ""container2_width"": ""70%"",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": """",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""1"",
  ""container3_horizontal_align"": ""1"",
  ""container4_label"": """",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""1"",
  ""container4_horizontal_align"": ""1"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""1"",
  ""container5_horizontal_align"": ""1"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
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
  ""no_total"": ""true"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 38b062ef-c587-422d-a52e-a4d4c1355c97 >>
    {
        var id = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 6,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllInventoryEntries\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No Inventory Entries"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Preview"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""true"",
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
  ""container3_label"": ""Warehouse"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Location"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Project"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""true"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": ""Inventory"",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""true"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""3"",
  ""container6_horizontal_align"": ""2"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 7cf13c63-eb64-4ccd-8245-af42dec8de3a >>
    {
        var id = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 4,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllManufacturers\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": ""article_grid"",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No manufacturers"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""true"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Logo"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Short Name"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""true"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Data Portal"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""true"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""true"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: c3eaea33-9d92-4aa3-916e-5e1dbb74c4d8 >>
    {
        var id = new Guid("c3eaea33-9d92-4aa3-916e-5e1dbb74c4d8");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 2,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllProjects\"",\""default\"":\""\""}"",
  ""page_size"": 20,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No projects"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""true"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Number"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""true"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Name"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""true"",
  ""container2_sortable"": ""true"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Manufacturer"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""1"",
  ""container3_horizontal_align"": ""1"",
  ""container4_label"": ""Designation"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""true"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Blocked"",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""true"",
  ""container5_sortable"": ""true"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""3"",
  ""container5_horizontal_align"": ""2"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 8b4ef44c-5257-42f6-864e-cfef4e0b85eb >>
    {
        var id = new Guid("8b4ef44c-5257-42f6-864e-cfef4e0b85eb");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("16125e41-93a3-4735-a650-e78164aaf840");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 3,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllOrders\"",\""default\"":\""\""}"",
  ""page_size"": 20,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No orders"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail?returnUrl={{CurrentUrl}}\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Order Number"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Project Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Project Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Supplier"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""1"",
  ""container5_horizontal_align"": ""1"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: order-list ID: 3c69ec47-4e4c-41b1-8812-b003452be3e9 >>
    {
        var id = new Guid("3c69ec47-4e4c-41b1-8812-b003452be3e9");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("9681dc5e-b096-4e85-88d8-c082e35554a9");
        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""{{Record.number}} - Overall Overview\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/projects/r/{{RecordId}}\"",\""default\"":\""\""}""
}";
        var weight = 1;

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 2a35c384-d01b-4477-9ed2-bf02bad36163 >>
    {
        var id = new Guid("2a35c384-d01b-4477-9ed2-bf02bad36163");
        Guid? parentId = null;
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcForm";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-2a35c384-d01b-4477-9ed2-bf02bad36163"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
}";
        var weight = 3;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 00901a6a-50fa-4f58-83b9-6974c78e8272 >>
    {
        var id = new Guid("00901a6a-50fa-4f58-83b9-6974c78e8272");
        Guid? parentId = new Guid("2a35c384-d01b-4477-9ed2-bf02bad36163");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: d9ef45db-8348-4c2c-b8f2-2845496682ef >>
    {
        var id = new Guid("d9ef45db-8348-4c2c-b8f2-2845496682ef");
        Guid? parentId = new Guid("00901a6a-50fa-4f58-83b9-6974c78e8272");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcButton";
        var containerId = "body";
        var options = @"{
  ""type"": ""1"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-search"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": """"
}";
        var weight = 6;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 4bd893af-5a70-4efe-9e84-946720a2d42e >>
    {
        var id = new Guid("4bd893af-5a70-4efe-9e84-946720a2d42e");
        Guid? parentId = new Guid("00901a6a-50fa-4f58-83b9-6974c78e8272");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Order Number"",
  ""name"": ""order_number"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 567ac62a-97a9-4eec-b4b4-0bcfaea444b2 >>
    {
        var id = new Guid("567ac62a-97a9-4eec-b4b4-0bcfaea444b2");
        Guid? parentId = new Guid("00901a6a-50fa-4f58-83b9-6974c78e8272");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Page Size"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RequestQuery.page_size\"",\""default\"":\""20\""}"",
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
        var weight = 5;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 75822762-a914-44e1-99b9-3e18c2467a36 >>
    {
        var id = new Guid("75822762-a914-44e1-99b9-3e18c2467a36");
        Guid? parentId = new Guid("00901a6a-50fa-4f58-83b9-6974c78e8272");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Project Number"",
  ""name"": ""project_number"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""1"",
  ""query_options"": [
    ""1""
  ],
  ""prefix"": """",
  ""data_type"": """"
}";
        var weight = 2;

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 83108ca0-82e0-4203-bf36-82e98c7ac749 >>
    {
        var id = new Guid("83108ca0-82e0-4203-bf36-82e98c7ac749");
        Guid? parentId = new Guid("00901a6a-50fa-4f58-83b9-6974c78e8272");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
        var containerId = "body";
        var options = @"{
  ""is_visible"": """",
  ""label"": ""Project Name"",
  ""name"": ""project_name"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 7cc721ee-2873-489a-a197-3e43fd3090e7 >>
    {
        var id = new Guid("7cc721ee-2873-489a-a197-3e43fd3090e7");
        Guid? parentId = null;
        Guid? nodeId = null;
        Guid pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcGrid";
        var containerId = "";
        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""allow-copy"": ""false"",
  ""visible_columns"": 4,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllGoodsReceiving\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No Goods Receivings"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""{\""type\"":\""0\"",\""string\"":\""/{{App.Name}}/{{SitemapArea.Name}}/{{SitemapNode.Name}}/r/{{RowRecord.id}}/detail\"",\""default\"":\""\""}"",
  ""compatibility"": """",
  ""container1_label"": ""Order"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Project Number"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Project Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Timestamp"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": """",
  ""container5_width"": """",
  ""container5_name"": """",
  ""container5_nowrap"": ""false"",
  ""container5_sortable"": ""false"",
  ""container5_class"": """",
  ""container5_vertical_align"": ""1"",
  ""container5_horizontal_align"": ""1"",
  ""container6_label"": """",
  ""container6_width"": """",
  ""container6_name"": """",
  ""container6_nowrap"": ""false"",
  ""container6_sortable"": ""false"",
  ""container6_class"": """",
  ""container6_vertical_align"": ""1"",
  ""container6_horizontal_align"": ""1"",
  ""container7_label"": """",
  ""container7_width"": """",
  ""container7_name"": """",
  ""container7_nowrap"": ""false"",
  ""container7_sortable"": ""false"",
  ""container7_class"": """",
  ""container7_vertical_align"": ""1"",
  ""container7_horizontal_align"": ""1"",
  ""container8_label"": """",
  ""container8_width"": """",
  ""container8_name"": """",
  ""container8_nowrap"": ""false"",
  ""container8_sortable"": ""false"",
  ""container8_class"": """",
  ""container8_vertical_align"": ""1"",
  ""container8_horizontal_align"": ""1"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update page body node*** Page: all ID: 7e906f19-41ba-466a-b654-3d245dd7ce04 >>
    {
        var id = new Guid("7e906f19-41ba-466a-b654-3d245dd7ce04");
        Guid? parentId = new Guid("7cc721ee-2873-489a-a197-3e43fd3090e7");
        Guid? nodeId = null;
        Guid pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column4";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.time_stamp\"",\""default\"":\""\""}"",
  ""name"": ""time_stamp"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 13d973c5-c3f9-4d55-871f-60f090882735 >>
    {
        var id = new Guid("13d973c5-c3f9-4d55-871f-60f090882735");
        Guid? parentId = new Guid("7cc721ee-2873-489a-a197-3e43fd3090e7");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column2";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$goods_receiving_order.$order_project.number\"",\""default\"":\""\""}"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Create page body node*** Page name: all  id: 42dbc065-0c19-419e-aca3-fb233bfdad82 >>
    {
        var id = new Guid("42dbc065-0c19-419e-aca3-fb233bfdad82");
        Guid? parentId = new Guid("7cc721ee-2873-489a-a197-3e43fd3090e7");
        Guid? nodeId = null;
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
        var containerId = "column3";
        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$goods_receiving_order.$order_project.name\"",\""default\"":\""\""}"",
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

        new WebVella.Erp.Web.Services.PageService(connectionString).CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, context.Transaction);
    }
    #endregion

    #region << ***Update data source*** Name: AllGoodsReceiving >>
    {
        var id = new Guid("716dea1d-43bd-465b-a1ef-0253599f7f9a");
        var name = @"AllGoodsReceiving";
        var description = @"";
        var eqlText = @"SELECT *, $goods_receiving_order.order_number, $goods_receiving_order.$order_project.number, $goods_receiving_order.$order_project.name
FROM goods_receiving
WHERE (@orderNumber = null OR $goods_receiving_order.order_number ~* @orderNumber)
    AND (@projectNumber = null OR $goods_receiving_order.$order_project.number STARTSWITH @projectNumber)
    AND (@projectName = null OR $goods_receiving_order.$order_project.name ~* @projectName)
ORDER BY time_stamp DESC
PAGE @page
PAGESIZE @pageSize";
        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_goods_receiving.""id"" AS ""id"",
	 rec_goods_receiving.""time_stamp"" AS ""time_stamp"",
	 rec_goods_receiving.""order_id"" AS ""order_id"",
	 rec_goods_receiving.""delivery_note"" AS ""delivery_note"",
	 COUNT(*) OVER() AS ___total_count___,
	------->: $goods_receiving_order
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 goods_receiving_order.""id"" AS ""id"",
		 goods_receiving_order.""order_number"" AS ""order_number"",
		------->: $order_project
		(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
		 SELECT 
			 order_project.""id"" AS ""id"",
			 order_project.""number"" AS ""number"",
			 order_project.""name"" AS ""name""
		 FROM rec_project order_project
		 WHERE order_project.id = goods_receiving_order.project_id ) d )::jsonb AS ""$order_project""		
		-------< $order_project

	 FROM rec_order goods_receiving_order
	 WHERE goods_receiving_order.id = rec_goods_receiving.order_id ) d )::jsonb AS ""$goods_receiving_order""	
	-------< $goods_receiving_order

FROM rec_goods_receiving

LEFT OUTER JOIN  rec_order goods_receiving_order_tar_org ON goods_receiving_order_tar_org.id = rec_goods_receiving.order_id
LEFT OUTER JOIN  rec_project order_project_tar_org ON order_project_tar_org.id = goods_receiving_order_tar_org.project_id
WHERE  (  (  (  ( @orderNumber IS NULL )  OR  ( goods_receiving_order_tar_org.""order_number"" ~* @orderNumber )  )  AND  (  ( @projectNumber IS NULL )  OR  ( order_project_tar_org.""number""  ILIKE CONCAT ( @projectNumber,'%'  ) )  )  )  AND  (  ( @projectName IS NULL )  OR  ( order_project_tar_org.""name"" ~* @projectName )  )  ) 
ORDER BY rec_goods_receiving.""time_stamp"" DESC
LIMIT 20
OFFSET 0
) X
";
        var parametersJson = @"[{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""20"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""projectNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""projectName"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false}]";
        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""time_stamp"",""type"":5,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""delivery_note"",""type"":7,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$goods_receiving_order"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$order_project"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]}]";
        var weight = 10;
        var returnTotal = true;
        var entityName = @"goods_receiving";

        new WebVella.Erp.Database.DbDataSourceRepository().Update(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
    }
    #endregion

    #region << ***Update page data source*** Name: PartListDiff >>
    {
        var id = new Guid("a2d5813e-40dc-4cee-944d-2c8fa18dc431");
        var pageId = new Guid("79b37b9a-ae3f-4d96-a754-5bc4bc305f39");
        var dataSourceId = new Guid("52b4b242-c82a-44dc-8b5c-4fd585eaa55b");
        var name = @"PartListDiff";
        var parameters = @"[{""name"":""partList1"",""type"":""guid"",""value"":""{{RequestQuery.part_list1}}"",""ignore_parse_errors"":false},{""name"":""partList2"",""type"":""guid"",""value"":""{{RequestQuery.part_list2}}"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""{{RequestQuery.q_part_number_v}}"",""ignore_parse_errors"":false},{""name"":""typeNumber"",""type"":""text"",""value"":""{{RequestQuery.q_type_number_v}}"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""{{RequestQuery.q_order_number_v}}"",""ignore_parse_errors"":false},{""name"":""manufacturer"",""type"":""text"",""value"":""{{RequestQuery.q_manufacturer_v}}"",""ignore_parse_errors"":false},{""name"":""designation"",""type"":""text"",""value"":""{{RequestQuery.q_designation_v}}"",""ignore_parse_errors"":false},{""name"":""isEqual"",""type"":""bool"",""value"":""{{RequestQuery.q_is_equal_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""{{RequestQuery.page_size}}"",""ignore_parse_errors"":false}]";

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageDataSource(id, pageId, dataSourceId, name, parameters, context.Transaction);
    }
    #endregion

    #region << ***Update page data source*** Name: AllWarehouseLocations >>
    {
        var id = new Guid("1bc089b9-f312-4e0b-b027-c9de213ab454");
        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
        var dataSourceId = new Guid("4b711d44-cdd4-4d63-abaa-72add6710c73");
        var name = @"AllWarehouseLocations";
        var parameters = @"[{""name"":""warehouse"",""type"":""text"",""value"":""{{RequestQuery.q_warehouse_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""{{RequestQuery.page_size}}"",""ignore_parse_errors"":false}]";

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageDataSource(id, pageId, dataSourceId, name, parameters, context.Transaction);
    }
    #endregion

    #region << ***Update page data source*** Name: ExtendedOrderEntries4Order >>
    {
        var id = new Guid("db2875a1-715c-4c51-afc8-5bb473405b83");
        var pageId = new Guid("42674e70-ae43-4e05-8ac1-df8dec1aa94d");
        var dataSourceId = new Guid("98fe56ae-6fba-4182-99fd-d07a511708a8");
        var name = @"ExtendedOrderEntries4Order";
        var parameters = @"[{""name"":""order"",""type"":""Guid"",""value"":""{{RecordId}}"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""{{RequestQuery.q_part_number_v}}"",""ignore_parse_errors"":false},{""name"":""typeNumber"",""type"":""text"",""value"":""{{RequestQuery.q_type_number_v}}"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""{{RequestQuery.q_order_number_v}}"",""ignore_parse_errors"":false},{""name"":""manufacturer"",""type"":""text"",""value"":""{{RequestQuery.q_manufacturer_v}}"",""ignore_parse_errors"":false},{""name"":""designation"",""type"":""text"",""value"":""{{RequestQuery.q_designation_v}}"",""ignore_parse_errors"":false},{""name"":""state"",""type"":""WebVella.Erp.Plugins.Duatec.OrderEntryState"",""value"":""{{RequestQuery.q_state_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""{{RequestQuery.page_size}}"",""ignore_parse_errors"":false}]";

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageDataSource(id, pageId, dataSourceId, name, parameters, context.Transaction);
    }
    #endregion

    #region << ***Update page data source*** Name: AllGoodsReceiving >>
    {
        var id = new Guid("f1cd5cb9-489f-426b-8868-7bb81279b793");
        var pageId = new Guid("afc55d66-ed4a-4638-8329-fbdc9402001b");
        var dataSourceId = new Guid("716dea1d-43bd-465b-a1ef-0253599f7f9a");
        var name = @"AllGoodsReceiving";
        var parameters = @"[{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""{{RequestQuery.page_size}}"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""{{RequestQuery.q_order_number_v}}"",""ignore_parse_errors"":false},{""name"":""projectNumber"",""type"":""text"",""value"":""{{RequestQuery.q_project_number_v}}"",""ignore_parse_errors"":false},{""name"":""projectName"",""type"":""text"",""value"":""{{RequestQuery.q_project_name_v}}"",""ignore_parse_errors"":false}]";

        new WebVella.Erp.Web.Services.PageService(connectionString).UpdatePageDataSource(id, pageId, dataSourceId, name, parameters, context.Transaction);
    }
    #endregion

    #region << ***Delete page body node*** Page name: detail ID: d5924a40-23bb-47f5-a606-f22bc220761b >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("d5924a40-23bb-47f5-a606-f22bc220761b"), context.Transaction, cascade: false);
    }
    #endregion

    #region << ***Delete page body node*** Page name: manage ID: e563ff2b-098b-499c-9519-40cf64d5626e >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("e563ff2b-098b-499c-9519-40cf64d5626e"), context.Transaction, cascade: false);
    }
    #endregion

    #region << ***Delete page body node*** Page name: manage ID: 5f66eea4-c2b2-46b8-b740-e09bc6fe7f7e >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("5f66eea4-c2b2-46b8-b740-e09bc6fe7f7e"), context.Transaction, cascade: false);
    }
    #endregion

    #region << ***Delete page body node*** Page name: manage ID: 1c0120a6-ff5c-4403-84cf-42109c47d740 >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("1c0120a6-ff5c-4403-84cf-42109c47d740"), context.Transaction, cascade: false);
    }
    #endregion

    #region << ***Delete page body node*** Page name: detail ID: 2a45b596-6230-49a2-89a6-e03bc70f8dbd >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("2a45b596-6230-49a2-89a6-e03bc70f8dbd"), context.Transaction, cascade: false);
    }
    #endregion

    #region << ***Delete page body node*** Page name: manage ID: 2a845db5-39bb-4109-b6e3-8f61099c8133 >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("2a845db5-39bb-4109-b6e3-8f61099c8133"), context.Transaction, cascade: false);
    }
    #endregion

    #region << ***Delete page body node*** Page name: detail ID: 780a94fd-a287-40eb-b4de-514c222fca14 >>
    {

        new WebVella.Erp.Web.Services.PageService(connectionString).DeletePageBodyNode(new Guid("780a94fd-a287-40eb-b4de-514c222fca14"), context.Transaction, cascade: false);
    }
    #endregion

    connection.CommitTransaction();
}