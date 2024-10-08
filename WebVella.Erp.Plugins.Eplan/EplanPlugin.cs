using Newtonsoft.Json;
using WebVella.Erp.Api;

namespace WebVella.Erp.Plugins.Eplan
{
    public class EplanPlugin : ErpPlugin
    {
        [JsonProperty(PropertyName = "name")]
        public override string Name { get; protected set; } = "Eplan";

        public override void Initialize(IServiceProvider ServiceProvider)
        {
            // ProcessPatches();
        }

        private void ProcessPatches()
        {
            using (SecurityContext.OpenSystemScope())
            {
                var entMan = new EntityManager();
                var relMan = new EntityRelationManager();
                var recMan = new RecordManager();

                // insert difference code here
                {
                }
            }
        }
    }
}
