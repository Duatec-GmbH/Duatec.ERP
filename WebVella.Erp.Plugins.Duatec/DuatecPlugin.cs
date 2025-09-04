using Newtonsoft.Json;
using System.Globalization;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Database;

namespace WebVella.Erp.Plugins.Duatec
{
    public class DuatecPlugin : ErpPlugin
    {
        [JsonProperty(PropertyName = "name")]
        public override string Name { get; protected set; } = "Duatec";


        class PluginSettings
        {
            [JsonProperty(PropertyName = "version")]
            public int Version { get; set; }
        }


        public override void Initialize(IServiceProvider ServiceProvider)
        {
            ProcessPatches();
        }

        public void ProcessPatches()
        {
            var currentPluginSettings = new PluginSettings() { Version = 0 };
            string jsonData = GetPluginData();
            if (!string.IsNullOrWhiteSpace(jsonData))
                currentPluginSettings = JsonConvert.DeserializeObject<PluginSettings>(jsonData);

            if (currentPluginSettings!.Version > 0)
                return;

            using (SecurityContext.OpenSystemScope())
            {
                var entMan = new EntityManager();
                var relMan = new EntityRelationManager();
                var recMan = new RecordManager();

                using var connection = DbContext.Current.CreateConnection();
                connection.BeginTransaction();

#pragma warning disable
                try
                {
                    // insert difference code within braces here here
                    // don't forget to include records of entity "article_type".

                    {

                    }

                    // necessary stuff from webvella (DO NOT DELETE)

                    currentPluginSettings.Version = 1;
                    SavePluginData(JsonConvert.SerializeObject(currentPluginSettings));

                    connection.CommitTransaction();
                }

                catch
                {
                    connection.RollbackTransaction();
                    throw;
                }
#pragma warning restore
            }
        }
    }
}
