using System.Text.Json.Nodes;
using WebVella.Erp.TypedRecords;
using WebVella.Erp.TypedRecords.Attributes;

namespace WebVella.Erp.Plugins.Duatec.Persistance.Entities
{
    [TypedEntity(Entity)]
    internal class FinderConfig : TypedEntityRecordWrapper
    {
        public const string Entity = "finder_config";
        public static class Fields
        {
            public const string ShortName = "short_name";
            public const string Config = "config";
        }

        public override string EntityName => Entity;

        public string ShortName
        {
            get => Get(Fields.ShortName, string.Empty);
            set => Properties[Fields.ShortName] = value;
        }

        public JsonNode? Config
        {
            get => JsonNode.Parse(Get(Fields.Config, string.Empty));
            set => Properties[Fields.Config] = value?.ToJsonString() ?? string.Empty;
        }
    }
}
