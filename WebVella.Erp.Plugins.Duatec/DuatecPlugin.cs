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
                        #region << ***Create entity*** Entity name: goods_receiving_entry >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("d8de40d4-03ac-4d2b-bb63-bb56fdc4b20b");
                                entity.Id = new Guid("c509a389-aabd-4945-aab8-fbfceafb1da5");
                                entity.Name = "goods_receiving_entry";
                                entity.Label = "Goods Receiving Entry";
                                entity.LabelPlural = "Goods Receiving Entries";
                                entity.System = false;
                                entity.IconName = "fas fa-truck-loading";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: goods_receiving_entry creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving_entry Field Name: article_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("933741f6-c6de-4827-96ac-00fd25f9664f");
                            guidField.Name = "article_id";
                            guidField.Label = "Article ID";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = false;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = null;
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            guidField.Permissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            guidField.Permissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            guidField.Permissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            guidField.Permissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            {
                                var response = entMan.CreateField(new Guid("c509a389-aabd-4945-aab8-fbfceafb1da5"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving_entry Field: article_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving_entry Field Name: goods_receiving_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("00055f32-0e20-45eb-b5a7-e150ba436dad");
                            guidField.Name = "goods_receiving_id";
                            guidField.Label = "Good Receiving ID";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = false;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = null;
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            guidField.Permissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            guidField.Permissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            guidField.Permissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            guidField.Permissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            {
                                var response = entMan.CreateField(new Guid("c509a389-aabd-4945-aab8-fbfceafb1da5"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving_entry Field: goods_receiving_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving_entry Field Name: amount >>
                        {
                            InputNumberField numberField = new InputNumberField();
                            numberField.Id = new Guid("7081624d-c2a1-4402-88aa-ec42fb13ed0b");
                            numberField.Name = "amount";
                            numberField.Label = "Amount";
                            numberField.PlaceholderText = null;
                            numberField.Description = null;
                            numberField.HelpText = null;
                            numberField.Required = false;
                            numberField.Unique = false;
                            numberField.Searchable = false;
                            numberField.Auditable = false;
                            numberField.System = false;
                            numberField.DefaultValue = null;
                            numberField.MinValue = Decimal.Parse("0,0");
                            numberField.MaxValue = null;
                            numberField.DecimalPlaces = byte.Parse("0");
                            numberField.EnableSecurity = false;
                            numberField.Permissions = new FieldPermissions();
                            numberField.Permissions.CanRead = new List<Guid>();
                            numberField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            numberField.Permissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            numberField.Permissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            numberField.Permissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            numberField.Permissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            {
                                var response = entMan.CreateField(new Guid("c509a389-aabd-4945-aab8-fbfceafb1da5"), numberField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving_entry Field: amount Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: article_equivalent >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("fb1327ca-2647-4ecf-99fc-62eb06dc7321");
                                entity.Id = new Guid("daa997aa-b427-40ab-8ec7-94bbd532c6bc");
                                entity.Name = "article_equivalent";
                                entity.Label = "Article Equivalent";
                                entity.LabelPlural = "Article Equivalents";
                                entity.System = false;
                                entity.IconName = "fa fa-database";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: article_equivalent creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: article_equivalent Field Name: target >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("214ef11b-eb4a-4e36-a03c-4f64042347f6");
                            guidField.Name = "target";
                            guidField.Label = "Target";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            guidField.Permissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("daa997aa-b427-40ab-8ec7-94bbd532c6bc"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article_equivalent Field: target Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article_equivalent Field Name: source >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("f54426f9-74af-486a-b253-55a3bb7d70bd");
                            guidField.Name = "source";
                            guidField.Label = "Source";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("daa997aa-b427-40ab-8ec7-94bbd532c6bc"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article_equivalent Field: source Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: warehouse_location >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("0b689ed4-484a-41f7-a0a3-ca3f187f367d");
                                entity.Id = new Guid("c0594745-9b28-40a1-9e57-a756734dca88");
                                entity.Name = "warehouse_location";
                                entity.Label = "Warehouse Location";
                                entity.LabelPlural = "Warehouse Location";
                                entity.System = false;
                                entity.IconName = "fas fa-warehouse";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: warehouse_location creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: warehouse_location Field Name: designation >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("ed4a0878-b27a-4b05-b9ad-ebb308b86e5a");
                            textboxField.Name = "designation";
                            textboxField.Label = "Designation";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
                            textboxField.Searchable = false;
                            textboxField.Auditable = false;
                            textboxField.System = false;
                            textboxField.DefaultValue = "";
                            textboxField.MaxLength = Int32.Parse("64");
                            textboxField.EnableSecurity = false;
                            textboxField.Permissions = new FieldPermissions();
                            textboxField.Permissions.CanRead = new List<Guid>();
                            textboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("c0594745-9b28-40a1-9e57-a756734dca88"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: warehouse_location Field: designation Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: warehouse_location Field Name: warehouse_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("7789e0a2-d099-40b6-b522-36222efeee1f");
                            guidField.Name = "warehouse_id";
                            guidField.Label = "Warehouse";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("c0594745-9b28-40a1-9e57-a756734dca88"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: warehouse_location Field: warehouse_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: article_type >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("914e3876-3412-4143-bc54-be7f936fa1a0");
                                entity.Id = new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37");
                                entity.Name = "article_type";
                                entity.Label = "Article Type";
                                entity.LabelPlural = "Article Types";
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
                                entity.RecordPermissions.CanCreate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: article_type creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: article_type Field Name: unit >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("56fce0ce-2c79-450e-9e71-e9da8eca5611");
                            textboxField.Name = "unit";
                            textboxField.Label = "Unit";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article_type Field: unit Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article_type Field Name: label >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("1cf6e725-e339-403e-8c40-50b245d0ab80");
                            textboxField.Name = "label";
                            textboxField.Label = "Label";
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
                                var response = entMan.CreateField(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article_type Field: label Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article_type Field Name: is_integer >>
                        {
                            InputCheckboxField checkboxField = new InputCheckboxField();
                            checkboxField.Id = new Guid("b87f788c-0dc0-45d2-8087-50c4231203c0");
                            checkboxField.Name = "is_integer";
                            checkboxField.Label = "Is Integer";
                            checkboxField.PlaceholderText = null;
                            checkboxField.Description = null;
                            checkboxField.HelpText = null;
                            checkboxField.Required = false;
                            checkboxField.Unique = false;
                            checkboxField.Searchable = false;
                            checkboxField.Auditable = false;
                            checkboxField.System = false;
                            checkboxField.DefaultValue = false;
                            checkboxField.EnableSecurity = false;
                            checkboxField.Permissions = new FieldPermissions();
                            checkboxField.Permissions.CanRead = new List<Guid>();
                            checkboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37"), checkboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article_type Field: is_integer Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: article >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("e65ea6eb-9384-4e76-b26e-f707d71fdcf4");
                                entity.Id = new Guid("14640617-3a63-4065-b96a-8ae586e5b68b");
                                entity.Name = "article";
                                entity.Label = "Article";
                                entity.LabelPlural = "Articles";
                                entity.System = false;
                                entity.IconName = "fas fa-glass-martini";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: article creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: manufacturer_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("0577a1a4-4a8d-42fc-8727-be8fe01b5367");
                            guidField.Name = "manufacturer_id";
                            guidField.Label = "Manufacturer Id";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: manufacturer_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: preview >>
                        {
                            InputUrlField urlField = new InputUrlField();
                            urlField.Id = new Guid("091a93eb-17d9-4dec-a25c-e6082841c38b");
                            urlField.Name = "preview";
                            urlField.Label = "Preview";
                            urlField.PlaceholderText = null;
                            urlField.Description = null;
                            urlField.HelpText = null;
                            urlField.Required = false;
                            urlField.Unique = false;
                            urlField.Searchable = false;
                            urlField.Auditable = false;
                            urlField.System = false;
                            urlField.DefaultValue = "";
                            urlField.MaxLength = null;
                            urlField.OpenTargetInNewWindow = false;
                            urlField.EnableSecurity = false;
                            urlField.Permissions = new FieldPermissions();
                            urlField.Permissions.CanRead = new List<Guid>();
                            urlField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), urlField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: preview Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: part_number >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("c31195a1-5bfd-4367-97c1-e14119d0019b");
                            textboxField.Name = "part_number";
                            textboxField.Label = "Part Number";
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
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: part_number Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: eplan_id >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("5159fc7d-d0d0-42b8-9e07-5bdeb7f5e54a");
                            textboxField.Name = "eplan_id";
                            textboxField.Label = "Eplan ID";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
                            textboxField.Searchable = false;
                            textboxField.Auditable = false;
                            textboxField.System = false;
                            textboxField.DefaultValue = "";
                            textboxField.MaxLength = Int32.Parse("20");
                            textboxField.EnableSecurity = false;
                            textboxField.Permissions = new FieldPermissions();
                            textboxField.Permissions.CanRead = new List<Guid>();
                            textboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: eplan_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: designation >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("6db05b58-d0c3-4c1a-9906-e31d4943b57c");
                            textboxField.Name = "designation";
                            textboxField.Label = "Designation";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
                            textboxField.Searchable = false;
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
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: designation Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: is_blocked >>
                        {
                            InputCheckboxField checkboxField = new InputCheckboxField();
                            checkboxField.Id = new Guid("7237719a-2c9d-4243-a9ae-d1c6103ab6c5");
                            checkboxField.Name = "is_blocked";
                            checkboxField.Label = "Is Blocked";
                            checkboxField.PlaceholderText = null;
                            checkboxField.Description = null;
                            checkboxField.HelpText = null;
                            checkboxField.Required = false;
                            checkboxField.Unique = false;
                            checkboxField.Searchable = false;
                            checkboxField.Auditable = false;
                            checkboxField.System = false;
                            checkboxField.DefaultValue = false;
                            checkboxField.EnableSecurity = false;
                            checkboxField.Permissions = new FieldPermissions();
                            checkboxField.Permissions.CanRead = new List<Guid>();
                            checkboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), checkboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: is_blocked Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: article_type >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("eb4c3734-fe1d-4ad4-9e95-3b590501b255");
                            guidField.Name = "article_type";
                            guidField.Label = "Type";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("14a2d274-c18e-46f8-a920-2814ea5faa2d");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: article_type Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: type_number >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("53106753-3d13-411b-9b38-c5cb3d561d0e");
                            textboxField.Name = "type_number";
                            textboxField.Label = "Type Number";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: type_number Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: article Field Name: order_number >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("dd60df0f-6522-402c-8367-6b10c9b8781c");
                            textboxField.Name = "order_number";
                            textboxField.Label = "Order Number";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: article Field: order_number Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: order_confirmation >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("23de26ac-6a9c-4697-8745-004d9e16c703");
                                entity.Id = new Guid("4551265e-959d-439c-8e18-eaf3d253e883");
                                entity.Name = "order_confirmation";
                                entity.Label = "Order Confirmation";
                                entity.LabelPlural = "Order Confirmations";
                                entity.System = false;
                                entity.IconName = "fa fa-database";
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
                                        throw new Exception("System error 10050. Entity: order_confirmation creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_confirmation Field Name: file >>
                        {
                            InputFileField fileField = new InputFileField();
                            fileField.Id = new Guid("8a14fa5d-720d-4634-8ecf-96aa55aa4d5e");
                            fileField.Name = "file";
                            fileField.Label = "File";
                            fileField.PlaceholderText = null;
                            fileField.Description = null;
                            fileField.HelpText = null;
                            fileField.Required = true;
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
                                var response = entMan.CreateField(new Guid("4551265e-959d-439c-8e18-eaf3d253e883"), fileField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_confirmation Field: file Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_confirmation Field Name: order_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("d9c68a5f-54e8-49b3-8296-9fdc33ed20c7");
                            guidField.Name = "order_id";
                            guidField.Label = "Order";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = true;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("4551265e-959d-439c-8e18-eaf3d253e883"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_confirmation Field: order_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: project >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("ee2d1968-0a88-40eb-8c7a-0678b9db87e7");
                                entity.Id = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
                                entity.Name = "project";
                                entity.Label = "Project";
                                entity.LabelPlural = "Projects";
                                entity.System = false;
                                entity.IconName = "fab fa-black-tie";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: project creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: project Field Name: name >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("bfc16814-e5b3-4098-9461-b9db2ea91b57");
                            textboxField.Name = "name";
                            textboxField.Label = "Name";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
                            textboxField.Searchable = true;
                            textboxField.Auditable = false;
                            textboxField.System = false;
                            textboxField.DefaultValue = "Project";
                            textboxField.MaxLength = null;
                            textboxField.EnableSecurity = false;
                            textboxField.Permissions = new FieldPermissions();
                            textboxField.Permissions.CanRead = new List<Guid>();
                            textboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: project Field: name Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: project Field Name: number >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("677eada7-f0fb-467e-b3a9-d3f236bf050d");
                            textboxField.Name = "number";
                            textboxField.Label = "Number";
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
                                var response = entMan.CreateField(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: project Field: number Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: project Field Name: requires_part_list >>
                        {
                            InputCheckboxField checkboxField = new InputCheckboxField();
                            checkboxField.Id = new Guid("cd7b501e-5108-4bc9-bd8f-341ec528c848");
                            checkboxField.Name = "requires_part_list";
                            checkboxField.Label = "Requires Part List";
                            checkboxField.PlaceholderText = null;
                            checkboxField.Description = null;
                            checkboxField.HelpText = null;
                            checkboxField.Required = false;
                            checkboxField.Unique = false;
                            checkboxField.Searchable = true;
                            checkboxField.Auditable = false;
                            checkboxField.System = false;
                            checkboxField.DefaultValue = true;
                            checkboxField.EnableSecurity = false;
                            checkboxField.Permissions = new FieldPermissions();
                            checkboxField.Permissions.CanRead = new List<Guid>();
                            checkboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12"), checkboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: project Field: requires_part_list Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: project Field Name: inventory_project >>
                        {
                            InputCheckboxField checkboxField = new InputCheckboxField();
                            checkboxField.Id = new Guid("ef7f5155-662d-499b-8c5a-dff3bfd8f617");
                            checkboxField.Name = "inventory_project";
                            checkboxField.Label = "Inventory Project";
                            checkboxField.PlaceholderText = null;
                            checkboxField.Description = null;
                            checkboxField.HelpText = null;
                            checkboxField.Required = false;
                            checkboxField.Unique = false;
                            checkboxField.Searchable = true;
                            checkboxField.Auditable = false;
                            checkboxField.System = false;
                            checkboxField.DefaultValue = false;
                            checkboxField.EnableSecurity = false;
                            checkboxField.Permissions = new FieldPermissions();
                            checkboxField.Permissions.CanRead = new List<Guid>();
                            checkboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12"), checkboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: project Field: inventory_project Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: part_list_entry >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("4fbfa58d-e73c-4584-a2f4-57a3cb5b808a");
                                entity.Id = new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9");
                                entity.Name = "part_list_entry";
                                entity.Label = "Part List Entry";
                                entity.LabelPlural = "Part List Entries";
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
                                entity.RecordPermissions.CanCreate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: part_list_entry creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list_entry Field Name: part_list_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("59e5dcaa-f3b4-43ce-9423-fb3f360bd3d3");
                            guidField.Name = "part_list_id";
                            guidField.Label = "Part List";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list_entry Field: part_list_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list_entry Field Name: article_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("a6d3635c-070d-4205-9eaa-4480b7d5ad7b");
                            guidField.Name = "article_id";
                            guidField.Label = "Article";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list_entry Field: article_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list_entry Field Name: amount >>
                        {
                            InputNumberField numberField = new InputNumberField();
                            numberField.Id = new Guid("626e6868-fe3f-4da8-b81c-31f506ad8c51");
                            numberField.Name = "amount";
                            numberField.Label = "Amount";
                            numberField.PlaceholderText = null;
                            numberField.Description = null;
                            numberField.HelpText = null;
                            numberField.Required = true;
                            numberField.Unique = false;
                            numberField.Searchable = false;
                            numberField.Auditable = false;
                            numberField.System = false;
                            numberField.DefaultValue = Decimal.Parse("0,0");
                            numberField.MinValue = Decimal.Parse("0,0");
                            numberField.MaxValue = Decimal.Parse("21474836470000,0");
                            numberField.DecimalPlaces = byte.Parse("2");
                            numberField.EnableSecurity = false;
                            numberField.Permissions = new FieldPermissions();
                            numberField.Permissions.CanRead = new List<Guid>();
                            numberField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9"), numberField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list_entry Field: amount Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list_entry Field Name: device_tag >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("a7fe2b88-90c6-417d-b00d-70c0a6a4e777");
                            textboxField.Name = "device_tag";
                            textboxField.Label = "Device Tag";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
                            textboxField.Searchable = false;
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
                                var response = entMan.CreateField(new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list_entry Field: device_tag Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: manufacturer >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("87e1f2bd-39fd-43d4-8ac5-36051a1d53bc");
                                entity.Id = new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e");
                                entity.Name = "manufacturer";
                                entity.Label = "Manufacturer";
                                entity.LabelPlural = "Manufacturers";
                                entity.System = false;
                                entity.IconName = "far fa-address-card";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: manufacturer creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: manufacturer Field Name: logo >>
                        {
                            InputUrlField urlField = new InputUrlField();
                            urlField.Id = new Guid("9e9cf5e1-94e7-4668-9fbc-1bfcc116b48b");
                            urlField.Name = "logo";
                            urlField.Label = "Logo";
                            urlField.PlaceholderText = "e.g. https://www.duatec.at/files/nav/logo-ikon-w.svg";
                            urlField.Description = null;
                            urlField.HelpText = null;
                            urlField.Required = false;
                            urlField.Unique = false;
                            urlField.Searchable = false;
                            urlField.Auditable = false;
                            urlField.System = false;
                            urlField.DefaultValue = "";
                            urlField.MaxLength = null;
                            urlField.OpenTargetInNewWindow = false;
                            urlField.EnableSecurity = false;
                            urlField.Permissions = new FieldPermissions();
                            urlField.Permissions.CanRead = new List<Guid>();
                            urlField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e"), urlField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: manufacturer Field: logo Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: manufacturer Field Name: website >>
                        {
                            InputUrlField urlField = new InputUrlField();
                            urlField.Id = new Guid("c536e13d-e049-4cd0-a401-31811d051153");
                            urlField.Name = "website";
                            urlField.Label = "Website";
                            urlField.PlaceholderText = "e.g. https://www.duatec.at/";
                            urlField.Description = null;
                            urlField.HelpText = null;
                            urlField.Required = false;
                            urlField.Unique = false;
                            urlField.Searchable = false;
                            urlField.Auditable = false;
                            urlField.System = false;
                            urlField.DefaultValue = "";
                            urlField.MaxLength = null;
                            urlField.OpenTargetInNewWindow = true;
                            urlField.EnableSecurity = false;
                            urlField.Permissions = new FieldPermissions();
                            urlField.Permissions.CanRead = new List<Guid>();
                            urlField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e"), urlField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: manufacturer Field: website Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: manufacturer Field Name: eplan_id >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("8ee4563d-8301-4197-af2f-d2f66b181465");
                            textboxField.Name = "eplan_id";
                            textboxField.Label = "Eplan ID";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
                            textboxField.Searchable = false;
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
                                var response = entMan.CreateField(new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: manufacturer Field: eplan_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: manufacturer Field Name: short_name >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("9dfdb174-33a6-4ac8-a455-9bf5ac59a777");
                            textboxField.Name = "short_name";
                            textboxField.Label = "Short Name";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = true;
                            textboxField.Searchable = true;
                            textboxField.Auditable = false;
                            textboxField.System = false;
                            textboxField.DefaultValue = "";
                            textboxField.MaxLength = Int32.Parse("3");
                            textboxField.EnableSecurity = false;
                            textboxField.Permissions = new FieldPermissions();
                            textboxField.Permissions.CanRead = new List<Guid>();
                            textboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: manufacturer Field: short_name Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: manufacturer Field Name: name >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("34e72c65-38bd-4c9d-8ae2-86b2dfad3488");
                            textboxField.Name = "name";
                            textboxField.Label = "Name";
                            textboxField.PlaceholderText = "e.g. Duatec";
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
                                var response = entMan.CreateField(new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: manufacturer Field: name Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: warehouse >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("0a14dd61-6ed0-4936-8d52-b9a387f7a1c3");
                                entity.Id = new Guid("2b05eb55-dead-4099-8a6b-5c2527104389");
                                entity.Name = "warehouse";
                                entity.Label = "Warehouse";
                                entity.LabelPlural = "Warehouses";
                                entity.System = false;
                                entity.IconName = "fas fa-warehouse";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: warehouse creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: warehouse Field Name: designation >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("4a7302d0-194d-4a0d-8cfc-45303b075606");
                            textboxField.Name = "designation";
                            textboxField.Label = "Designation";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = true;
                            textboxField.Searchable = true;
                            textboxField.Auditable = false;
                            textboxField.System = false;
                            textboxField.DefaultValue = "Warehouse";
                            textboxField.MaxLength = null;
                            textboxField.EnableSecurity = false;
                            textboxField.Permissions = new FieldPermissions();
                            textboxField.Permissions.CanRead = new List<Guid>();
                            textboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("2b05eb55-dead-4099-8a6b-5c2527104389"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: warehouse Field: designation Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: change_tracking_entry >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("d571c25b-dc43-42f8-b853-0b47b96d0ba7");
                                entity.Id = new Guid("6b67fba9-38ff-4255-8693-5369e18c3303");
                                entity.Name = "change_tracking_entry";
                                entity.Label = "Change Tracking";
                                entity.LabelPlural = "Change Tracking";
                                entity.System = false;
                                entity.IconName = "fa fa-database";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
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
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: change_tracking_entry creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: change_tracking_entry Field Name: entity_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("4a169605-dedb-404c-9d5d-0bd5df5769c6");
                            guidField.Name = "entity_id";
                            guidField.Label = "Entity";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("6b67fba9-38ff-4255-8693-5369e18c3303"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: change_tracking_entry Field: entity_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: change_tracking_entry Field Name: action >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("94c05d1f-4f3d-4e98-a5f2-b3ee458baf62");
                            textboxField.Name = "action";
                            textboxField.Label = "Action";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("6b67fba9-38ff-4255-8693-5369e18c3303"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: change_tracking_entry Field: action Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: change_tracking_entry Field Name: object >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("e7f9dfc5-a6aa-4575-b1d4-5b10b89d4dd1");
                            textboxField.Name = "object";
                            textboxField.Label = "Object";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("6b67fba9-38ff-4255-8693-5369e18c3303"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: change_tracking_entry Field: object Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: change_tracking_entry Field Name: timestamp >>
                        {
                            InputDateTimeField datetimeField = new InputDateTimeField();
                            datetimeField.Id = new Guid("0ffc907f-b1a9-4467-829e-5ae354efd554");
                            datetimeField.Name = "timestamp";
                            datetimeField.Label = "Timestamp";
                            datetimeField.PlaceholderText = null;
                            datetimeField.Description = null;
                            datetimeField.HelpText = null;
                            datetimeField.Required = true;
                            datetimeField.Unique = false;
                            datetimeField.Searchable = true;
                            datetimeField.Auditable = false;
                            datetimeField.System = false;
                            try { datetimeField.DefaultValue = DateTime.Parse("31.12.2024 23:00:00"); } catch { datetimeField.DefaultValue = DateTime.Parse("31.12.2024 23:00:00", new CultureInfo("de-AT")); }
                            datetimeField.Format = "yyyy-MMM-dd HH:mm";
                            datetimeField.UseCurrentTimeAsDefaultValue = false;
                            datetimeField.EnableSecurity = false;
                            datetimeField.Permissions = new FieldPermissions();
                            datetimeField.Permissions.CanRead = new List<Guid>();
                            datetimeField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("6b67fba9-38ff-4255-8693-5369e18c3303"), datetimeField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: change_tracking_entry Field: timestamp Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: change_tracking_entry Field Name: user_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("ac6de83d-f00e-4377-9483-d36e06a59f04");
                            guidField.Name = "user_id";
                            guidField.Label = "User";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = true;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("6b67fba9-38ff-4255-8693-5369e18c3303"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: change_tracking_entry Field: user_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: part_list >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("7ff986b0-9d17-4b65-ad62-1a1a261c2c71");
                                entity.Id = new Guid("77349d70-b965-4ec1-a9ca-4724e440f095");
                                entity.Name = "part_list";
                                entity.Label = "Part List";
                                entity.LabelPlural = "Part Lists";
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
                                entity.RecordPermissions.CanCreate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: part_list creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list Field Name: project_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("64a60f2f-ef51-4447-8cfe-b22e0ab7ceea");
                            guidField.Name = "project_id";
                            guidField.Label = "Project";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = true;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("77349d70-b965-4ec1-a9ca-4724e440f095"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list Field: project_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list Field Name: name >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("9b652eeb-73aa-4cc3-80ff-39737fd3aadb");
                            textboxField.Name = "name";
                            textboxField.Label = "Name";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("77349d70-b965-4ec1-a9ca-4724e440f095"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list Field: name Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: part_list Field Name: is_active >>
                        {
                            InputCheckboxField checkboxField = new InputCheckboxField();
                            checkboxField.Id = new Guid("69db6be1-6068-4615-af4b-c4b936976b5e");
                            checkboxField.Name = "is_active";
                            checkboxField.Label = "Is Active";
                            checkboxField.PlaceholderText = null;
                            checkboxField.Description = null;
                            checkboxField.HelpText = null;
                            checkboxField.Required = false;
                            checkboxField.Unique = false;
                            checkboxField.Searchable = true;
                            checkboxField.Auditable = false;
                            checkboxField.System = false;
                            checkboxField.DefaultValue = false;
                            checkboxField.EnableSecurity = false;
                            checkboxField.Permissions = new FieldPermissions();
                            checkboxField.Permissions.CanRead = new List<Guid>();
                            checkboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("77349d70-b965-4ec1-a9ca-4724e440f095"), checkboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: part_list Field: is_active Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: inventory_entry >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("9d239e96-711a-4257-a017-2b7936de6cda");
                                entity.Id = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                                entity.Name = "inventory_entry";
                                entity.Label = "Inventory";
                                entity.LabelPlural = "Inventory";
                                entity.System = false;
                                entity.IconName = "fas fa-warehouse";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: inventory_entry creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_entry Field Name: article_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("56abf9d6-6f8e-42bc-b023-d52598ab06ba");
                            guidField.Name = "article_id";
                            guidField.Label = "Article ID";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_entry Field: article_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_entry Field Name: warehouse_location_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("db8cdcd7-afaa-4422-8a1d-9b50cb215ff7");
                            guidField.Name = "warehouse_location_id";
                            guidField.Label = "Warehouse Location ID";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_entry Field: warehouse_location_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_entry Field Name: project_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("c5096d50-55ac-476f-8f22-de75724316d0");
                            guidField.Name = "project_id";
                            guidField.Label = "Project ID";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = false;
                            guidField.Unique = false;
                            guidField.Searchable = false;
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
                                var response = entMan.CreateField(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_entry Field: project_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_entry Field Name: amount >>
                        {
                            InputNumberField numberField = new InputNumberField();
                            numberField.Id = new Guid("2d252aea-ec2e-486f-b175-2d716642698e");
                            numberField.Name = "amount";
                            numberField.Label = "Amount";
                            numberField.PlaceholderText = null;
                            numberField.Description = null;
                            numberField.HelpText = null;
                            numberField.Required = true;
                            numberField.Unique = false;
                            numberField.Searchable = false;
                            numberField.Auditable = false;
                            numberField.System = false;
                            numberField.DefaultValue = Decimal.Parse("0,0");
                            numberField.MinValue = null;
                            numberField.MaxValue = null;
                            numberField.DecimalPlaces = byte.Parse("2");
                            numberField.EnableSecurity = false;
                            numberField.Permissions = new FieldPermissions();
                            numberField.Permissions.CanRead = new List<Guid>();
                            numberField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9"), numberField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_entry Field: amount Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: order_entry >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("e244b4e1-cf1c-4622-8db3-194e4889c871");
                                entity.Id = new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc");
                                entity.Name = "order_entry";
                                entity.Label = "Order Entry";
                                entity.LabelPlural = "Order Entries";
                                entity.System = false;
                                entity.IconName = "far fa-file-alt";
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
                                        throw new Exception("System error 10050. Entity: order_entry creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_entry Field Name: order_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("32e667d3-2b8a-4fc5-b3d3-d45f6f1cf92c");
                            guidField.Name = "order_id";
                            guidField.Label = "Order";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_entry Field: order_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_entry Field Name: article_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("2b70cf47-28f4-4174-9b00-9f281a75a868");
                            guidField.Name = "article_id";
                            guidField.Label = "Article";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_entry Field: article_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_entry Field Name: amount >>
                        {
                            InputNumberField numberField = new InputNumberField();
                            numberField.Id = new Guid("4c28dd57-1b27-46bc-b46e-a48118a32dda");
                            numberField.Name = "amount";
                            numberField.Label = "Amount";
                            numberField.PlaceholderText = null;
                            numberField.Description = null;
                            numberField.HelpText = null;
                            numberField.Required = true;
                            numberField.Unique = false;
                            numberField.Searchable = false;
                            numberField.Auditable = false;
                            numberField.System = false;
                            numberField.DefaultValue = Decimal.Parse("0,0");
                            numberField.MinValue = null;
                            numberField.MaxValue = null;
                            numberField.DecimalPlaces = byte.Parse("2");
                            numberField.EnableSecurity = false;
                            numberField.Permissions = new FieldPermissions();
                            numberField.Permissions.CanRead = new List<Guid>();
                            numberField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc"), numberField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_entry Field: amount Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_entry Field Name: expected_arrival >>
                        {
                            InputDateField dateField = new InputDateField();
                            dateField.Id = new Guid("1dcf51e6-6042-4c49-a7cf-fdf514cf656f");
                            dateField.Name = "expected_arrival";
                            dateField.Label = "Expected Arrival";
                            dateField.PlaceholderText = null;
                            dateField.Description = null;
                            dateField.HelpText = null;
                            dateField.Required = false;
                            dateField.Unique = false;
                            dateField.Searchable = false;
                            dateField.Auditable = false;
                            dateField.System = false;
                            dateField.DefaultValue = null;
                            dateField.Format = "YYYY-MM-DD";
                            dateField.UseCurrentTimeAsDefaultValue = false;
                            dateField.EnableSecurity = false;
                            dateField.Permissions = new FieldPermissions();
                            dateField.Permissions.CanRead = new List<Guid>();
                            dateField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc"), dateField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_entry Field: expected_arrival Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: goods_receiving >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("28dbd8d0-0138-418f-8723-1144b08df6b2");
                                entity.Id = new Guid("9abf8125-f174-4b03-9402-beb20892c5f9");
                                entity.Name = "goods_receiving";
                                entity.Label = "Goods Receiving";
                                entity.LabelPlural = "Goods Receiving";
                                entity.System = false;
                                entity.IconName = "fas fa-truck-loading";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: goods_receiving creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving Field Name: time_stamp >>
                        {
                            InputDateTimeField datetimeField = new InputDateTimeField();
                            datetimeField.Id = new Guid("877c7e8c-3f05-4b24-9cc7-88ebe7475bb0");
                            datetimeField.Name = "time_stamp";
                            datetimeField.Label = "Timestamp";
                            datetimeField.PlaceholderText = null;
                            datetimeField.Description = null;
                            datetimeField.HelpText = null;
                            datetimeField.Required = false;
                            datetimeField.Unique = false;
                            datetimeField.Searchable = false;
                            datetimeField.Auditable = false;
                            datetimeField.System = false;
                            datetimeField.DefaultValue = null;
                            datetimeField.Format = "yyyy-MMM-dd HH:mm";
                            datetimeField.UseCurrentTimeAsDefaultValue = false;
                            datetimeField.EnableSecurity = false;
                            datetimeField.Permissions = new FieldPermissions();
                            datetimeField.Permissions.CanRead = new List<Guid>();
                            datetimeField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            datetimeField.Permissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            datetimeField.Permissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            datetimeField.Permissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            datetimeField.Permissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            {
                                var response = entMan.CreateField(new Guid("9abf8125-f174-4b03-9402-beb20892c5f9"), datetimeField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving Field: time_stamp Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving Field Name: order_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("bcb903c1-850c-4ccf-8df1-934e17465864");
                            guidField.Name = "order_id";
                            guidField.Label = "Order ID";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = null;
                            guidField.GenerateNewId = true;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            guidField.Permissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            guidField.Permissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            guidField.Permissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            guidField.Permissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            {
                                var response = entMan.CreateField(new Guid("9abf8125-f174-4b03-9402-beb20892c5f9"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving Field: order_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving Field Name: delivery_note >>
                        {
                            InputFileField fileField = new InputFileField();
                            fileField.Id = new Guid("7320f950-ab2d-4219-af2c-65f8f6bf3c89");
                            fileField.Name = "delivery_note";
                            fileField.Label = "Delivery Note";
                            fileField.PlaceholderText = null;
                            fileField.Description = null;
                            fileField.HelpText = null;
                            fileField.Required = false;
                            fileField.Unique = false;
                            fileField.Searchable = false;
                            fileField.Auditable = false;
                            fileField.System = false;
                            fileField.DefaultValue = null;
                            fileField.EnableSecurity = false;
                            fileField.Permissions = new FieldPermissions();
                            fileField.Permissions.CanRead = new List<Guid>();
                            fileField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("9abf8125-f174-4b03-9402-beb20892c5f9"), fileField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving Field: delivery_note Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: goods_receiving Field Name: has_been_stored >>
                        {
                            InputCheckboxField checkboxField = new InputCheckboxField();
                            checkboxField.Id = new Guid("7b10f0fb-22cc-4166-80fe-eb083c352eec");
                            checkboxField.Name = "has_been_stored";
                            checkboxField.Label = "Has been Stored";
                            checkboxField.PlaceholderText = null;
                            checkboxField.Description = null;
                            checkboxField.HelpText = null;
                            checkboxField.Required = false;
                            checkboxField.Unique = false;
                            checkboxField.Searchable = false;
                            checkboxField.Auditable = false;
                            checkboxField.System = false;
                            checkboxField.DefaultValue = false;
                            checkboxField.EnableSecurity = false;
                            checkboxField.Permissions = new FieldPermissions();
                            checkboxField.Permissions.CanRead = new List<Guid>();
                            checkboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("9abf8125-f174-4b03-9402-beb20892c5f9"), checkboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: goods_receiving Field: has_been_stored Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: order >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("48431afc-77d5-49e4-ba1c-01ee1db68625");
                                entity.Id = new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559");
                                entity.Name = "order";
                                entity.Label = "Order";
                                entity.LabelPlural = "Orders";
                                entity.System = false;
                                entity.IconName = "far fa-file-alt";
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
                                        throw new Exception("System error 10050. Entity: order creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: order Field Name: order >>
                        {
                            InputFileField fileField = new InputFileField();
                            fileField.Id = new Guid("5e413b08-efc8-48e2-a71b-03a561c8e428");
                            fileField.Name = "order";
                            fileField.Label = "Order";
                            fileField.PlaceholderText = null;
                            fileField.Description = null;
                            fileField.HelpText = null;
                            fileField.Required = false;
                            fileField.Unique = false;
                            fileField.Searchable = false;
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
                                    throw new Exception("System error 10060. Entity: order Field: order Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order Field Name: offer >>
                        {
                            InputFileField fileField = new InputFileField();
                            fileField.Id = new Guid("11e186e0-adec-4bcb-a558-ced3531c5f16");
                            fileField.Name = "offer";
                            fileField.Label = "Offer";
                            fileField.PlaceholderText = null;
                            fileField.Description = null;
                            fileField.HelpText = null;
                            fileField.Required = false;
                            fileField.Unique = false;
                            fileField.Searchable = false;
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
                                    throw new Exception("System error 10060. Entity: order Field: offer Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order Field Name: project_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("08c6283e-ce28-4385-8942-3f5202fb760a");
                            guidField.Name = "project_id";
                            guidField.Label = "Project";
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
                                    throw new Exception("System error 10060. Entity: order Field: project_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order Field Name: order_number >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("568e54c4-9069-494c-80e1-a69e3484320b");
                            textboxField.Name = "order_number";
                            textboxField.Label = "Order Number";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order Field: order_number Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: image >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("eebfd6be-6101-4586-a35a-2e547b02cf03");
                                entity.Id = new Guid("6c865b13-e370-4f10-a696-8354b4d3ad23");
                                entity.Name = "image";
                                entity.Label = "Image";
                                entity.LabelPlural = "Images";
                                entity.System = false;
                                entity.IconName = "fas fa-images";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: image creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: image Field Name: image >>
                        {
                            InputImageField imageField = new InputImageField();
                            imageField.Id = new Guid("c431f0f9-89d5-4a4a-abfc-12ced7cc6029");
                            imageField.Name = "image";
                            imageField.Label = "Image";
                            imageField.PlaceholderText = null;
                            imageField.Description = null;
                            imageField.HelpText = null;
                            imageField.Required = true;
                            imageField.Unique = false;
                            imageField.Searchable = false;
                            imageField.Auditable = false;
                            imageField.System = false;
                            imageField.DefaultValue = "";
                            imageField.EnableSecurity = false;
                            imageField.Permissions = new FieldPermissions();
                            imageField.Permissions.CanRead = new List<Guid>();
                            imageField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("6c865b13-e370-4f10-a696-8354b4d3ad23"), imageField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: image Field: image Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: image Field Name: name >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("85a31616-2706-41e7-9e59-29b6093a6bf3");
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
                                var response = entMan.CreateField(new Guid("6c865b13-e370-4f10-a696-8354b4d3ad23"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: image Field: name Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: inventory_booking >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("a71653b5-cd75-40d1-a997-24b993efc616");
                                entity.Id = new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b");
                                entity.Name = "inventory_booking";
                                entity.Label = "Inventory Booking";
                                entity.LabelPlural = "Inventory Bookings";
                                entity.System = false;
                                entity.IconName = "fa fa-database";
                                entity.Color = "";
                                entity.RecordScreenIdField = null;
                                entity.RecordPermissions = new RecordPermissions();
                                entity.RecordPermissions.CanCreate = new List<Guid>();
                                entity.RecordPermissions.CanRead = new List<Guid>();
                                entity.RecordPermissions.CanUpdate = new List<Guid>();
                                entity.RecordPermissions.CanDelete = new List<Guid>();
                                //Create
                                entity.RecordPermissions.CanCreate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                entity.RecordPermissions.CanCreate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
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
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                entity.RecordPermissions.CanUpdate.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                                //DELETE
                                entity.RecordPermissions.CanDelete.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("f71835a8-8a30-42e5-9742-d3c12972f731"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960"));
                                entity.RecordPermissions.CanDelete.Add(new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a"));
                                {
                                    var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                    if (!response.Success)
                                        throw new Exception("System error 10050. Entity: inventory_booking creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: article_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("8c794634-580b-4194-8f08-9bb610cbbae9");
                            guidField.Name = "article_id";
                            guidField.Label = "Article";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
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
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: article_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: user_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("f2c44b90-14dd-4a9e-9a96-93ff44c0f727");
                            guidField.Name = "user_id";
                            guidField.Label = "User";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = false;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
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
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: user_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: timestamp >>
                        {
                            InputDateTimeField datetimeField = new InputDateTimeField();
                            datetimeField.Id = new Guid("878beffe-e7e4-470d-92fa-b6dc3403805b");
                            datetimeField.Name = "timestamp";
                            datetimeField.Label = "Timestamp";
                            datetimeField.PlaceholderText = null;
                            datetimeField.Description = null;
                            datetimeField.HelpText = null;
                            datetimeField.Required = true;
                            datetimeField.Unique = false;
                            datetimeField.Searchable = false;
                            datetimeField.Auditable = false;
                            datetimeField.System = false;
                            try { datetimeField.DefaultValue = DateTime.Parse("31.12.2024 23:00:00"); } catch { datetimeField.DefaultValue = DateTime.Parse("31.12.2024 23:00:00", new CultureInfo("de-AT")); }
                            datetimeField.Format = "yyyy-mm-dd HH:mm";
                            datetimeField.UseCurrentTimeAsDefaultValue = false;
                            datetimeField.EnableSecurity = false;
                            datetimeField.Permissions = new FieldPermissions();
                            datetimeField.Permissions.CanRead = new List<Guid>();
                            datetimeField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b"), datetimeField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: timestamp Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: amount >>
                        {
                            InputNumberField numberField = new InputNumberField();
                            numberField.Id = new Guid("9c806f5a-00bf-4e89-a67b-4d6f98dce7aa");
                            numberField.Name = "amount";
                            numberField.Label = "Amount";
                            numberField.PlaceholderText = null;
                            numberField.Description = null;
                            numberField.HelpText = null;
                            numberField.Required = true;
                            numberField.Unique = false;
                            numberField.Searchable = false;
                            numberField.Auditable = false;
                            numberField.System = false;
                            numberField.DefaultValue = Decimal.Parse("0,0");
                            numberField.MinValue = Decimal.Parse("2147483648000,0");
                            numberField.MaxValue = Decimal.Parse("2147483647000,0");
                            numberField.DecimalPlaces = byte.Parse("2");
                            numberField.EnableSecurity = false;
                            numberField.Permissions = new FieldPermissions();
                            numberField.Permissions.CanRead = new List<Guid>();
                            numberField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b"), numberField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: amount Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: project_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("d347ec63-d5f8-49b6-a453-d6e249ede127");
                            guidField.Name = "project_id";
                            guidField.Label = "Project";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = false;
                            guidField.Unique = false;
                            guidField.Searchable = false;
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
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: project_id Message:" + response.Message);
                            }
                        }
                        #endregion

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

                        #region << ***Create field***  Entity: inventory_booking Field Name: kind >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("92794b54-cbc9-414b-82be-75513341c0de");
                            textboxField.Name = "kind";
                            textboxField.Label = "Kind";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = true;
                            textboxField.Unique = false;
                            textboxField.Searchable = true;
                            textboxField.Auditable = false;
                            textboxField.System = false;
                            textboxField.DefaultValue = "Undefined";
                            textboxField.MaxLength = Int32.Parse("32");
                            textboxField.EnableSecurity = false;
                            textboxField.Permissions = new FieldPermissions();
                            textboxField.Permissions.CanRead = new List<Guid>();
                            textboxField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: kind Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: project_source_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("f20b9e5f-1658-4b2c-845a-1b5aaa16c884");
                            guidField.Name = "project_source_id";
                            guidField.Label = "Project Source Id";
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
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: project_source_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: warehouse_location_source_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("fd62ab21-4129-4d21-bff2-6acfdbe28b67");
                            guidField.Name = "warehouse_location_source_id";
                            guidField.Label = "Source Warehouse Location";
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
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: warehouse_location_source_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: inventory_booking Field Name: comment >>
                        {
                            InputTextField textboxField = new InputTextField();
                            textboxField.Id = new Guid("38381720-12d4-41dd-8bf0-f7c26e5b2ce9");
                            textboxField.Name = "comment";
                            textboxField.Label = "Comment";
                            textboxField.PlaceholderText = null;
                            textboxField.Description = null;
                            textboxField.HelpText = null;
                            textboxField.Required = false;
                            textboxField.Unique = false;
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
                                var response = entMan.CreateField(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b"), textboxField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: inventory_booking Field: comment Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create entity*** Entity name: order_bill >>
                        {
                            #region << entity >>
                            {
                                var entity = new InputEntity();
                                var systemFieldIdDictionary = new Dictionary<string, Guid>();
                                systemFieldIdDictionary["id"] = new Guid("86cb9419-b019-4a64-b1b0-2a96307afb9e");
                                entity.Id = new Guid("341d69f2-336f-4e61-a340-7be20ab56d40");
                                entity.Name = "order_bill";
                                entity.Label = "Order Bill";
                                entity.LabelPlural = "Order Bills";
                                entity.System = false;
                                entity.IconName = "far fa-money-bill-alt";
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
                                        throw new Exception("System error 10050. Entity: order_bill creation Message: " + response.Message);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_bill Field Name: file >>
                        {
                            InputFileField fileField = new InputFileField();
                            fileField.Id = new Guid("b04460c4-97d5-4beb-982b-4e00b1ca0b19");
                            fileField.Name = "file";
                            fileField.Label = "File";
                            fileField.PlaceholderText = null;
                            fileField.Description = null;
                            fileField.HelpText = null;
                            fileField.Required = true;
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
                                var response = entMan.CreateField(new Guid("341d69f2-336f-4e61-a340-7be20ab56d40"), fileField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_bill Field: file Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create field***  Entity: order_bill Field Name: order_id >>
                        {
                            InputGuidField guidField = new InputGuidField();
                            guidField.Id = new Guid("d8b07a6d-84cd-40bb-b57d-edc3398185cb");
                            guidField.Name = "order_id";
                            guidField.Label = "Order";
                            guidField.PlaceholderText = null;
                            guidField.Description = null;
                            guidField.HelpText = null;
                            guidField.Required = true;
                            guidField.Unique = false;
                            guidField.Searchable = true;
                            guidField.Auditable = false;
                            guidField.System = false;
                            guidField.DefaultValue = Guid.Parse("00000000-0000-0000-0000-000000000000");
                            guidField.GenerateNewId = false;
                            guidField.EnableSecurity = false;
                            guidField.Permissions = new FieldPermissions();
                            guidField.Permissions.CanRead = new List<Guid>();
                            guidField.Permissions.CanUpdate = new List<Guid>();
                            //READ
                            //UPDATE
                            {
                                var response = entMan.CreateField(new Guid("341d69f2-336f-4e61-a340-7be20ab56d40"), guidField, false);
                                if (!response.Success)
                                    throw new Exception("System error 10060. Entity: order_bill Field: order_id Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: article_manufacturer >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "manufacturer_id");
                            relation.Id = new Guid("b698e824-e23e-425a-bf4b-cfcb43e8c51f");
                            relation.Name = "article_manufacturer";
                            relation.Label = "article_manufacturer";
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
                                    throw new Exception("System error 10060. Relation: article_manufacturer Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: article_article_type >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "article_type");
                            relation.Id = new Guid("58503672-a459-4446-a25e-1e3ffeaf15a9");
                            relation.Name = "article_article_type";
                            relation.Label = "article_article_type";
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
                                    throw new Exception("System error 10060. Relation: article_article_type Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: warehouse >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("2b05eb55-dead-4099-8a6b-5c2527104389")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("c0594745-9b28-40a1-9e57-a756734dca88")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "warehouse_id");
                            relation.Id = new Guid("62128ba4-84f8-4251-8670-d218f0646f69");
                            relation.Name = "warehouse";
                            relation.Label = "warehouse";
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
                                    throw new Exception("System error 10060. Relation: warehouse Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: article >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "article_id");
                            relation.Id = new Guid("76023644-3181-4a67-9a8a-17e628183913");
                            relation.Name = "article";
                            relation.Label = "article";
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
                                    throw new Exception("System error 10060. Relation: article Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: warehouse_location >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("c0594745-9b28-40a1-9e57-a756734dca88")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "warehouse_location_id");
                            relation.Id = new Guid("be229d09-374e-4b99-a61e-57134a96a661");
                            relation.Name = "warehouse_location";
                            relation.Label = "warehouse_location";
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
                                    throw new Exception("System error 10060. Relation: warehouse_location Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: project >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("ab790595-caed-4773-a57f-b022d23a4fc9")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "project_id");
                            relation.Id = new Guid("141cfd96-6b51-45ee-b41a-9a7817d2aac8");
                            relation.Name = "project";
                            relation.Label = "project";
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
                                    throw new Exception("System error 10060. Relation: project Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: part_list_project >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("77349d70-b965-4ec1-a9ca-4724e440f095")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "project_id");
                            relation.Id = new Guid("6a3589d2-806e-4a03-b33f-005615433eb8");
                            relation.Name = "part_list_project";
                            relation.Label = "part_list_project";
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
                                    throw new Exception("System error 10060. Relation: part_list_project Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: part_list_entry_part_list >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("77349d70-b965-4ec1-a9ca-4724e440f095")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "part_list_id");
                            relation.Id = new Guid("aa778111-be59-4316-a8e2-0177d8da8eb8");
                            relation.Name = "part_list_entry_part_list";
                            relation.Label = "part_list_entry_part_list";
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
                                    throw new Exception("System error 10060. Relation: part_list_entry_part_list Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: part_list_entry_article >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("5229b3a8-0eac-4929-9115-79df46e4acf9")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "article_id");
                            relation.Id = new Guid("e5e010bf-d9c8-4dcf-bb9e-b0691e7ee3a2");
                            relation.Name = "part_list_entry_article";
                            relation.Label = "part_list_entry_article";
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
                                    throw new Exception("System error 10060. Relation: part_list_entry_article Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: order_entry_order >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "order_id");
                            relation.Id = new Guid("a28b9568-b0fa-4c16-8b49-11ecb97fb0ee");
                            relation.Name = "order_entry_order";
                            relation.Label = "order_entry_order";
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
                                    throw new Exception("System error 10060. Relation: order_entry_order Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: order_entry_article >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("654c4f17-5c0b-45ff-bf43-3339ed83dbcc")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "article_id");
                            relation.Id = new Guid("670e711c-c15d-4047-8e33-3d9e6db9bf6a");
                            relation.Name = "order_entry_article";
                            relation.Label = "order_entry_article";
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
                                    throw new Exception("System error 10060. Relation: order_entry_article Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: goods_receiving_order >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("9abf8125-f174-4b03-9402-beb20892c5f9")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "order_id");
                            relation.Id = new Guid("887c2b78-ffdc-456c-9ea3-ab342f9f19c6");
                            relation.Name = "goods_receiving_order";
                            relation.Label = "goods_receiving_order";
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
                                    throw new Exception("System error 10060. Relation: goods_receiving_order Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: goods_receiving_entry_article >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("c509a389-aabd-4945-aab8-fbfceafb1da5")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "article_id");
                            relation.Id = new Guid("54d681bc-3b84-4b11-89d2-1d0672b31644");
                            relation.Name = "goods_receiving_entry_article";
                            relation.Label = "goods_receiving_entry_article";
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
                                    throw new Exception("System error 10060. Relation: goods_receiving_entry_article Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: goods_receiving_entry_goods_receiving >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("9abf8125-f174-4b03-9402-beb20892c5f9")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("c509a389-aabd-4945-aab8-fbfceafb1da5")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "goods_receiving_id");
                            relation.Id = new Guid("9f6592c3-f9ce-4407-bc21-0461363e4f65");
                            relation.Name = "goods_receiving_entry_goods_receiving";
                            relation.Label = "goods_receiving_entry_goods_receiving";
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
                                    throw new Exception("System error 10060. Relation: goods_receiving_entry_goods_receiving Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: inventory_booking_project >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "project_id");
                            relation.Id = new Guid("bb92c69e-25b5-4b00-899f-fe6da37eb50f");
                            relation.Name = "inventory_booking_project";
                            relation.Label = "inventory_booking_project";
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
                                    throw new Exception("System error 10060. Relation: inventory_booking_project Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: inventory_booking_article >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "article_id");
                            relation.Id = new Guid("b51b456d-e9d8-4d0e-bb82-d119ac93c2b4");
                            relation.Name = "inventory_booking_article";
                            relation.Label = "inventory_booking_article";
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
                                    throw new Exception("System error 10060. Relation: inventory_booking_article Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: inventory_booking_user >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("b9cebc3b-6443-452a-8e34-b311a73dcc8b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "user_id");
                            relation.Id = new Guid("c1913c87-a627-4051-aef0-c0ab8e4594a9");
                            relation.Name = "inventory_booking_user";
                            relation.Label = "inventory_booking_user";
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
                                    throw new Exception("System error 10060. Relation: inventory_booking_user Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: change_tracking_entry_user >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("b9cebc3b-6443-452a-8e34-b311a73dcc8b")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("6b67fba9-38ff-4255-8693-5369e18c3303")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "user_id");
                            relation.Id = new Guid("f2fa5edd-4077-447a-8876-aa2e8a94951a");
                            relation.Name = "change_tracking_entry_user";
                            relation.Label = "change_tracking_entry_user";
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
                                    throw new Exception("System error 10060. Relation: change_tracking_entry_user Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: order_confirmation_order >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("4551265e-959d-439c-8e18-eaf3d253e883")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "order_id");
                            relation.Id = new Guid("e4320450-ec78-47d8-b0dc-5f9141df6c36");
                            relation.Name = "order_confirmation_order";
                            relation.Label = "order_confirmation_order";
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
                                    throw new Exception("System error 10060. Relation: order_confirmation_order Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: order_project >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "project_id");
                            relation.Id = new Guid("4fe25df2-4e67-4786-adcc-bd4e0550d313");
                            relation.Name = "order_project";
                            relation.Label = "order_project";
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
                                    throw new Exception("System error 10060. Relation: order_project Create. Message:" + response.Message);
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

                        #region << ***Create relation*** Relation name: inventory_booking_source_project >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "project_source_id");
                            relation.Id = new Guid("3ed2112d-0e46-4843-aefa-95e6b89c399a");
                            relation.Name = "inventory_booking_source_project";
                            relation.Label = "inventory_booking_source_project";
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
                                    throw new Exception("System error 10060. Relation: inventory_booking_source_project Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: inventory_booking_source_warehouse_location >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("c0594745-9b28-40a1-9e57-a756734dca88")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("0e10f5d0-8573-426a-b11e-eab1523dd34b")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "warehouse_location_source_id");
                            relation.Id = new Guid("10280156-6fb6-4dc3-8a5e-30b4c7858bbc");
                            relation.Name = "inventory_booking_source_warehouse_location";
                            relation.Label = "inventory_booking_source_warehouse_location";
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
                                    throw new Exception("System error 10060. Relation: inventory_booking_source_warehouse_location Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create relation*** Relation name: order_bill_order >>
                        {
                            var relation = new EntityRelation();
                            var originEntity = entMan.ReadEntity(new Guid("b5bda9cf-3df0-496e-82dc-68015f94a559")).Object;
                            var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                            var targetEntity = entMan.ReadEntity(new Guid("341d69f2-336f-4e61-a340-7be20ab56d40")).Object;
                            var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "order_id");
                            relation.Id = new Guid("4fa40f64-4461-4868-ba84-e72ca610abbf");
                            relation.Name = "order_bill_order";
                            relation.Label = "order_bill_order";
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
                                    throw new Exception("System error 10060. Relation: order_bill_order Create. Message:" + response.Message);
                            }
                        }
                        #endregion

                        #region << ***Create role*** Role name: warehouse-admin >>
                        {
                            var role = new EntityRecord();
                            role["id"] = new Guid("6cd475d2-0ac3-4ef1-bb69-3d6db5175b9a");
                            role["name"] = "warehouse-admin";
                            role["description"] = "Has permission to administrate warehouses and locations";
                            var createRoleResult = recMan.CreateRecord("role", role);
                            if (!createRoleResult.Success)
                            {
                                throw new Exception("System error 10060. Role create with name : warehouse-admin. Message:" + createRoleResult.Message);
                            }
                        }
                        #endregion

                        #region << ***Create role*** Role name: article-admin >>
                        {
                            var role = new EntityRecord();
                            role["id"] = new Guid("f71835a8-8a30-42e5-9742-d3c12972f731");
                            role["name"] = "article-admin";
                            role["description"] = "Has permission to set up article types and can add/modify and delete articles";
                            var createRoleResult = recMan.CreateRecord("role", role);
                            if (!createRoleResult.Success)
                            {
                                throw new Exception("System error 10060. Role create with name : article-admin. Message:" + createRoleResult.Message);
                            }
                        }
                        #endregion

                        #region << ***Create role*** Role name: project-manager >>
                        {
                            var role = new EntityRecord();
                            role["id"] = new Guid("21e35fcd-d1f6-4a94-9863-f1f61c159960");
                            role["name"] = "project-manager";
                            role["description"] = "Has permission to manage projects and related pages";
                            var createRoleResult = recMan.CreateRecord("role", role);
                            if (!createRoleResult.Success)
                            {
                                throw new Exception("System error 10060. Role create with name : project-manager. Message:" + createRoleResult.Message);
                            }
                        }
                        #endregion

                        #region << ***Create role*** Role name: inventory-admin >>
                        {
                            var role = new EntityRecord();
                            role["id"] = new Guid("df38b4cc-42cb-4c4d-b1ab-31e426d48177");
                            role["name"] = "inventory-admin";
                            role["description"] = "Has full permission to administrate inventory";
                            var createRoleResult = recMan.CreateRecord("role", role);
                            if (!createRoleResult.Success)
                            {
                                throw new Exception("System error 10060. Role create with name : inventory-admin. Message:" + createRoleResult.Message);
                            }
                        }
                        #endregion

                        #region << ***Create role*** Role name: order-admin >>
                        {
                            var role = new EntityRecord();
                            role["id"] = new Guid("15b5964b-b4c9-4857-b454-c9d4662ee7cd");
                            role["name"] = "order-admin";
                            role["description"] = "Has permission to administrate everything within order management";
                            var createRoleResult = recMan.CreateRecord("role", role);
                            if (!createRoleResult.Success)
                            {
                                throw new Exception("System error 10060. Role create with name : order-admin. Message:" + createRoleResult.Message);
                            }
                        }
                        #endregion

                        #region << ***Create role*** Role name: goods-receiving-admin >>
                        {
                            var role = new EntityRecord();
                            role["id"] = new Guid("1c609c71-d73f-431b-97e8-1a4576f7e831");
                            role["name"] = "goods-receiving-admin";
                            role["description"] = "Has all permissions within app 'Goods Receiving'";
                            var createRoleResult = recMan.CreateRecord("role", role);
                            if (!createRoleResult.Success)
                            {
                                throw new Exception("System error 10060. Role create with name : goods-receiving-admin. Message:" + createRoleResult.Message);
                            }
                        }
                        #endregion

                        #region << ***Create record*** Id: 14a2d274-c18e-46f8-a920-2814ea5faa2d (article_type) >>
                        {
                            var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
  ""unit"": ""pc."",
  ""label"": ""Component"",
  ""is_integer"": true
}";
                            EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
                            var result = recMan.CreateRecord("article_type", rec);
                            if (!result.Success) throw new Exception(result.Message);
                        }
                        #endregion

                        #region << ***Create record*** Id: e9048d0a-7f86-4e3b-8839-bf9ce64169e9 (article_type) >>
                        {
                            var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""e9048d0a-7f86-4e3b-8839-bf9ce64169e9"",
  ""unit"": ""m"",
  ""label"": ""Cable"",
  ""is_integer"": true
}";
                            EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
                            var result = recMan.CreateRecord("article_type", rec);
                            if (!result.Success) throw new Exception(result.Message);
                        }
                        #endregion


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
