using DbPatcher.Scripts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebVella.Erp;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Api.Models.AutoMapper;
using WebVella.Erp.Database;
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
            Inventory.ExportAmountsForProjects("C:\\Users\\florian.reischl.DUATEC\\Desktop\\Temp\\export-20051.txt", recMan, new Guid("cac0bf8c-2525-40ed-bcf7-912bba825572"));
            Inventory.ExportAmountsForProjects("C:\\Users\\florian.reischl.DUATEC\\Desktop\\Temp\\export-23701.txt", recMan, new Guid("a20f5036-1481-4512-b829-b326089519ee"));
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