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
        {
            #region << ***Create page body node*** Page name: create, Page label: Create Part List, id: 86d2ea57-0027-46bc-bf7a-a11d5adda75a >>
            {
                var id = new Guid("86d2ea57-0027-46bc-bf7a-a11d5adda75a");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("0f7eab0e-262f-41eb-9960-9945dbd260e9");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 5;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: manage, Page label: Manage Part List, id: d59dcd3d-4a8f-419d-8e91-6c39f409d45b >>
            {
                var id = new Guid("d59dcd3d-4a8f-419d-8e91-6c39f409d45b");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("4ceba53a-d8b8-4fc0-a72b-7bcfbfae6ad6");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 7;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: create, Page label: Create Manufacturer, id: cda2b20e-0ee7-4aee-8619-fbf7537e1308 >>
            {
                var id = new Guid("cda2b20e-0ee7-4aee-8619-fbf7537e1308");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 4;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: create, Page label: Create Article, id: f82bd665-ff30-4cea-9e87-3e9d7a10c327 >>
            {
                var id = new Guid("f82bd665-ff30-4cea-9e87-3e9d7a10c327");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 4;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: manage, Page label: Manage Article, id: 19809f33-939a-4c46-b1ba-411873db247c >>
            {
                var id = new Guid("19809f33-939a-4c46-b1ba-411873db247c");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 4;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: manage, Page label: Manage Manufacturer, id: ce26f295-dc3f-41e0-948c-5ce1b28d5839 >>
            {
                var id = new Guid("ce26f295-dc3f-41e0-948c-5ce1b28d5839");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 4;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: book-goods, Page label: Book Goods, id: 46bd0abb-9972-4b60-84d3-50281a498058 >>
            {
                var id = new Guid("46bd0abb-9972-4b60-84d3-50281a498058");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("9468eb13-46ed-43f1-b9f0-9a95726b523c");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 3;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: store-goods, Page label: Store Goods, id: b4c5113f-4420-4abc-9504-06bbda877e73 >>
            {
                var id = new Guid("b4c5113f-4420-4abc-9504-06bbda877e73");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("7513eda8-abc0-4b0a-8470-0509f7d3d2b7");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 4;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: manage, Page label: Manage Order, id: ae0eb674-1dc1-4cfa-bc3c-a8d707d98986 >>
            {
                var id = new Guid("ae0eb674-1dc1-4cfa-bc3c-a8d707d98986");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("ed15d836-6b7f-4418-b0f0-8853a4dece74");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 9;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: create, Page label: Create Order, id: e22b9c20-23bf-47d8-adb1-43a6b057a7b6 >>
            {
                var id = new Guid("e22b9c20-23bf-47d8-adb1-43a6b057a7b6");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("c273c168-547e-4ad8-81a3-990afd8a9117");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 5;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: create, Page label: Upload Image, id: f48bce5d-1cba-416a-ae43-cf5d0395e537 >>
            {
                var id = new Guid("f48bce5d-1cba-416a-ae43-cf5d0395e537");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("0ba749e3-0659-4bac-b101-5c9ccec3f72d");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 3;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion

            #region << ***Create page body node*** Page name: create, Page label: Add to Inventory, id: b70df1ef-cdb8-48af-aa12-da55f4bfab47 >>
            {
                var id = new Guid("b70df1ef-cdb8-48af-aa12-da55f4bfab47");
                Guid? parentId = null;
                Guid? nodeId = null;
                var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                var componentName = "WebVella.Erp.Web.Components.PcJavaScriptSource";
                var containerId = "";
                var options = @"{
  ""is_visible"": """",
  ""source"": ""/api/v3.0/f/files/javascript?file=Manage.keep-on-page-dialog.js""
}";
                var weight = 7;

                new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
            }
            #endregion


        }
    }
    catch
    {
        connection.RollbackTransaction();
        throw;
    }

    Console.WriteLine("Successfully patched db");
    connection.CommitTransaction();
}