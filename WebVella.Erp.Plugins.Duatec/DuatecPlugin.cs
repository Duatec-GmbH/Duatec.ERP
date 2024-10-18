using Newtonsoft.Json;
using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec
{
    public class DuatecPlugin : ErpPlugin
    {
        [JsonProperty(PropertyName = "name")]
        public override string Name { get; protected set; } = "Duatec";

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

                // insert difference code within braces here here
                {
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
                            //READ
                            entity.RecordPermissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            entity.RecordPermissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            entity.RecordPermissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //DELETE
                            entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
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
                            //READ
                            entity.RecordPermissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            entity.RecordPermissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            entity.RecordPermissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //UPDATE
                            entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //DELETE
                            entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
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
                        guidField.DefaultValue = Guid.Parse("6e4b019b-9665-43d8-a71e-a211d1ab3e85");
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
                            //READ
                            entity.RecordPermissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            entity.RecordPermissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            entity.RecordPermissions.CanRead.Add(new Guid("987148b1-afa8-4b33-8616-55861e5fd065"));
                            //UPDATE
                            entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //DELETE
                            entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
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

                    #region << ***Create app*** App name: master-data >>
                    {
                        var id = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "master-data";
                        var label = "Master Data";
                        var description = "Duatec Lagerverwaltung";
                        var iconClass = "fas fa-database";
                        var author = "Duatec";
                        var color = "#2196f3";
                        var weight = 10;
                        var access = new List<Guid>();
                        access.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));

                        new WebVella.Erp.Web.Services.AppService().CreateApplication(id, name, label, description, iconClass, author, color, weight, access, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create sitemap area*** Sitemap area name: articles >>
                    {
                        var id = new Guid("544fdb00-d71c-439f-9e14-52bdad7d478f");
                        var appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "articles";
                        var label = "Articles";
                        var description = @"";
                        var iconClass = "fas fa-glass-martini";
                        var color = "";
                        var weight = 1;
                        var showGroupNames = false;
                        var access = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();
                        var descriptionTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateArea(id, appId, name, label, labelTranslations, description, descriptionTranslations, iconClass, color, weight, showGroupNames, access, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create sitemap area*** Sitemap area name: manufacturers >>
                    {
                        var id = new Guid("7760578f-7610-4f60-9416-745daf5867ce");
                        var appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "manufacturers";
                        var label = "Manufacturers";
                        var description = @"";
                        var iconClass = "fas fa-building";
                        var color = "";
                        var weight = 2;
                        var showGroupNames = false;
                        var access = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();
                        var descriptionTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateArea(id, appId, name, label, labelTranslations, description, descriptionTranslations, iconClass, color, weight, showGroupNames, access, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create sitemap area*** Sitemap area name: article-type >>
                    {
                        var id = new Guid("54c0a565-c684-4005-b126-436402519474");
                        var appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "article-type";
                        var label = "Article Types";
                        var description = @"";
                        var iconClass = "fas fa-barcode";
                        var color = "";
                        var weight = 3;
                        var showGroupNames = false;
                        var access = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();
                        var descriptionTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateArea(id, appId, name, label, labelTranslations, description, descriptionTranslations, iconClass, color, weight, showGroupNames, access, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create sitemap node*** Sitemap node name: articles >>
                    {
                        var id = new Guid("9221b72b-6aee-424f-b80d-da089c56eb69");
                        Guid? parentId = null;
                        var areaId = new Guid("544fdb00-d71c-439f-9e14-52bdad7d478f");
                        Guid? entityId = new Guid("14640617-3a63-4065-b96a-8ae586e5b68b");
                        var name = "articles";
                        var label = "Articles";
                        var url = "";
                        var iconClass = "fas fa-glass-martini";
                        var weight = 1;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        var entityCreatePages = new List<Guid>();
                        var entityDetailsPages = new List<Guid>();
                        var entityManagePages = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
                    }
                    #endregion

                    #region << ***Create sitemap node*** Sitemap node name: manufacturers >>
                    {
                        var id = new Guid("95715c1c-12c6-4901-8f7c-cb33ad660580");
                        Guid? parentId = null;
                        var areaId = new Guid("7760578f-7610-4f60-9416-745daf5867ce");
                        Guid? entityId = new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e");
                        var name = "manufacturers";
                        var label = "Manufacturers";
                        var url = "";
                        var iconClass = "fas fa-building";
                        var weight = 1;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        var entityCreatePages = new List<Guid>();
                        var entityDetailsPages = new List<Guid>();
                        var entityManagePages = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
                    }
                    #endregion

                    #region << ***Create sitemap node*** Sitemap node name: article-types >>
                    {
                        var id = new Guid("88cdf8a4-c926-429a-9222-3a7cd7850169");
                        Guid? parentId = null;
                        var areaId = new Guid("54c0a565-c684-4005-b126-436402519474");
                        Guid? entityId = new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37");
                        var name = "article-types";
                        var label = "Article Types";
                        var url = "";
                        var iconClass = "fas fa-barcode";
                        var weight = 1;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        entityListPages.Add(new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398"));
                        var entityCreatePages = new List<Guid>();
                        var entityDetailsPages = new List<Guid>();
                        var entityManagePages = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
                    }
                    #endregion

                    #region << ***Create page*** Page name: create >>
                    {
                        var id = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var name = @"create";
                        var label = "Create Manufacturer";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)4);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: create >>
                    {
                        var id = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var name = @"create";
                        var label = "Create Article";
                        var iconClass = "";
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)4);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("14640617-3a63-4065-b96a-8ae586e5b68b");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: detail >>
                    {
                        var id = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var name = @"detail";
                        var label = "Article Detail";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)5);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("14640617-3a63-4065-b96a-8ae586e5b68b");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var name = @"all";
                        var label = "Manufacturers";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var name = @"all";
                        var label = "Articles";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("14640617-3a63-4065-b96a-8ae586e5b68b");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: manage >>
                    {
                        var id = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var name = @"manage";
                        var label = "Manage Article";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)6);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("14640617-3a63-4065-b96a-8ae586e5b68b");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: detail >>
                    {
                        var id = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var name = @"detail";
                        var label = "Manufacturer Detail";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)5);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: manage >>
                    {
                        var id = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var name = @"manage";
                        var label = "Manage Manufacturer";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)6);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95a2ecf6-5763-47b7-947c-28bd6554370e");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var name = @"all";
                        var label = "Article Types";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: import >>
                    {
                        var id = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var name = @"import";
                        var label = "Eplan import";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 1001;
                        var type = (PageType)((int)2);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = null;
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: import-manufacturers >>
                    {
                        var id = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var name = @"import-manufacturers";
                        var label = "Eplan Manufacturers Import";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 1001;
                        var type = (PageType)((int)2);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = null;
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 8f1f5a25-e94d-4977-af9e-0437beea8154 >>
                    {
                        var id = new Guid("8f1f5a25-e94d-4977-af9e-0437beea8154");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 8a3de454-1ab5-4c27-a5fb-54aaf022811e >>
                    {
                        var id = new Guid("8a3de454-1ab5-4c27-a5fb-54aaf022811e");
                        Guid? parentId = new Guid("8f1f5a25-e94d-4977-af9e-0437beea8154");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 245b85bd-13d9-4a6a-b4d7-ed752f697147 >>
                    {
                        var id = new Guid("245b85bd-13d9-4a6a-b4d7-ed752f697147");
                        Guid? parentId = new Guid("8a3de454-1ab5-4c27-a5fb-54aaf022811e");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Eplan Import"",
  ""color"": ""0"",
  ""size"": ""0"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""/master-data/a/import-manufacturers"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: f2ca084c-f924-4672-9ad8-fb05fd1b7006 >>
                    {
                        var id = new Guid("f2ca084c-f924-4672-9ad8-fb05fd1b7006");
                        Guid? parentId = new Guid("8a3de454-1ab5-4c27-a5fb-54aaf022811e");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 ml-0"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: f92a7378-b9be-43ef-9a67-92285ed21c24 >>
                    {
                        var id = new Guid("f92a7378-b9be-43ef-9a67-92285ed21c24");
                        Guid? parentId = new Guid("8a3de454-1ab5-4c27-a5fb-54aaf022811e");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""0"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""/master-data/manufacturers/manufacturers/c/create"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 402bcdea-cbdb-44d3-9730-85329a8e723d >>
                    {
                        var id = new Guid("402bcdea-cbdb-44d3-9730-85329a8e723d");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 091f3a12-dafd-4627-b158-6a075d427824 >>
                    {
                        var id = new Guid("091f3a12-dafd-4627-b158-6a075d427824");
                        Guid? parentId = new Guid("402bcdea-cbdb-44d3-9730-85329a8e723d");
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: b1c302a9-faaa-479f-b038-b4e14225910b >>
                    {
                        var id = new Guid("b1c302a9-faaa-479f-b038-b4e14225910b");
                        Guid? parentId = new Guid("091f3a12-dafd-4627-b158-6a075d427824");
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ManageUrlSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 372180b9-3d4c-4b5d-8804-c3ab9d952bcd >>
                    {
                        var id = new Guid("372180b9-3d4c-4b5d-8804-c3ab9d952bcd");
                        Guid? parentId = new Guid("091f3a12-dafd-4627-b158-6a075d427824");
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""10"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": ""far fa-trash-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-419583e8-7069-4b33-b8b7-56b88199e74f""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 89bd1283-aae3-4c47-b4f5-484f20bbd641 >>
                    {
                        var id = new Guid("89bd1283-aae3-4c47-b4f5-484f20bbd641");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 76b2f980-6884-4e86-bf9f-b37604cb06e2 >>
                    {
                        var id = new Guid("76b2f980-6884-4e86-bf9f-b37604cb06e2");
                        Guid? parentId = new Guid("89bd1283-aae3-4c47-b4f5-484f20bbd641");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: cbdca093-e870-4a1a-88b9-b95667c0084a >>
                    {
                        var id = new Guid("cbdca093-e870-4a1a-88b9-b95667c0084a");
                        Guid? parentId = new Guid("76b2f980-6884-4e86-bf9f-b37604cb06e2");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 9325a9b9-0c4c-4c32-8ba5-69174736b3b6 >>
                    {
                        var id = new Guid("9325a9b9-0c4c-4c32-8ba5-69174736b3b6");
                        Guid? parentId = new Guid("76b2f980-6884-4e86-bf9f-b37604cb06e2");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-3464bb03-9bf0-4ef8-be4d-18adf7217160""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 1461f5a7-21a6-4569-a62a-c891351007d5 >>
                    {
                        var id = new Guid("1461f5a7-21a6-4569-a62a-c891351007d5");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-1461f5a7-21a6-4569-a62a-c891351007d5"",
  ""name"": ""CreateRecord"",
  ""hook_key"": ""article_create"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: c9468e8f-cc72-43ab-af66-edcb60ec2abe >>
                    {
                        var id = new Guid("c9468e8f-cc72-43ab-af66-edcb60ec2abe");
                        Guid? parentId = new Guid("1461f5a7-21a6-4569-a62a-c891351007d5");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldUrl";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Image (URL)"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.preview\"",\""default\"":\""\""}"",
  ""name"": ""preview"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: f50d7c5e-7591-48a8-912c-5c0ec80b2dbd >>
                    {
                        var id = new Guid("f50d7c5e-7591-48a8-912c-5c0ec80b2dbd");
                        Guid? parentId = new Guid("1461f5a7-21a6-4569-a62a-c891351007d5");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldTextarea";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Designation"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.designation\"",\""default\"":\""\""}"",
  ""name"": ""designation"",
  ""class"": """",
  ""height"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 89053056-17e9-41c0-8dfb-193b2a1e30e2 >>
                    {
                        var id = new Guid("89053056-17e9-41c0-8dfb-193b2a1e30e2");
                        Guid? parentId = new Guid("1461f5a7-21a6-4569-a62a-c891351007d5");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: ea486308-08bf-43e4-8cec-5d78724638a3 >>
                    {
                        var id = new Guid("ea486308-08bf-43e4-8cec-5d78724638a3");
                        Guid? parentId = new Guid("89053056-17e9-41c0-8dfb-193b2a1e30e2");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 024fc77e-0ed2-4826-be33-5c5bab761ca3 >>
                    {
                        var id = new Guid("024fc77e-0ed2-4826-be33-5c5bab761ca3");
                        Guid? parentId = new Guid("89053056-17e9-41c0-8dfb-193b2a1e30e2");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Type"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.article_type\"",\""default\"":\""\""}"",
  ""name"": ""article_type"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""TypeSelectOptions\"",\""default\"":\""\""}"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 4769b380-61c0-4cb3-9083-8b1537ee0bfe >>
                    {
                        var id = new Guid("4769b380-61c0-4cb3-9083-8b1537ee0bfe");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: f866d84c-f399-4a94-92af-3089723d5666 >>
                    {
                        var id = new Guid("f866d84c-f399-4a94-92af-3089723d5666");
                        Guid? parentId = new Guid("4769b380-61c0-4cb3-9083-8b1537ee0bfe");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 69a347d2-3838-482a-95ae-9c6ee4f364ca >>
                    {
                        var id = new Guid("69a347d2-3838-482a-95ae-9c6ee4f364ca");
                        Guid? parentId = new Guid("f866d84c-f399-4a94-92af-3089723d5666");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: ea797841-86a8-4baf-aa70-12686a1810b5 >>
                    {
                        var id = new Guid("ea797841-86a8-4baf-aa70-12686a1810b5");
                        Guid? parentId = new Guid("f866d84c-f399-4a94-92af-3089723d5666");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-52a93358-247f-4613-9034-366d1d1c7399""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 3b2d1016-545d-4853-8164-92622b90bac6 >>
                    {
                        var id = new Guid("3b2d1016-545d-4853-8164-92622b90bac6");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 7e6d9d23-37d6-40b6-93a1-ecbd40640ecf >>
                    {
                        var id = new Guid("7e6d9d23-37d6-40b6-93a1-ecbd40640ecf");
                        Guid? parentId = new Guid("3b2d1016-545d-4853-8164-92622b90bac6");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: a5bfd1b6-12f6-4fcb-8473-7f7beff38b47 >>
                    {
                        var id = new Guid("a5bfd1b6-12f6-4fcb-8473-7f7beff38b47");
                        Guid? parentId = new Guid("7e6d9d23-37d6-40b6-93a1-ecbd40640ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-edit"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ManageUrlSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: e8331cf3-9caa-4d08-ae84-ce5d7fde55e5 >>
                    {
                        var id = new Guid("e8331cf3-9caa-4d08-ae84-ce5d7fde55e5");
                        Guid? parentId = new Guid("7e6d9d23-37d6-40b6-93a1-ecbd40640ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""10"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100"",
  ""id"": """",
  ""icon_class"": ""far fa-trash-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-419583e8-7069-4b33-b8b7-56b88199e74f""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 52a93358-247f-4613-9034-366d1d1c7399 >>
                    {
                        var id = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 05d589e2-56b6-4802-a332-6a18d7edd96b >>
                    {
                        var id = new Guid("05d589e2-56b6-4802-a332-6a18d7edd96b");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldCheckbox";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Article Blocked"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.is_blocked\"",\""default\"":\""\""}"",
  ""name"": ""is_blocked"",
  ""class"": """",
  ""text_true"": ""is blocked"",
  ""text_false"": ""is blocked"",
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

                    #region << ***Create page body node*** Page name: manage  id: a322e922-41ca-4670-b244-0ceeb004b4d5 >>
                    {
                        var id = new Guid("a322e922-41ca-4670-b244-0ceeb004b4d5");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldTextarea";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Designation"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.designation\"",\""default\"":\""\""}"",
  ""name"": ""designation"",
  ""class"": """",
  ""height"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 1a67d26c-e71b-4edd-9a9c-ca12c4736a6e >>
                    {
                        var id = new Guid("1a67d26c-e71b-4edd-9a9c-ca12c4736a6e");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldUrl";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Image (Url)"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.preview\"",\""default\"":\""\""}"",
  ""name"": ""preview"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 98718fb4-c136-4256-9ddc-6c2f507ab57e >>
                    {
                        var id = new Guid("98718fb4-c136-4256-9ddc-6c2f507ab57e");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: c927cb03-f8fb-4caa-92ea-fb2f837fc5de >>
                    {
                        var id = new Guid("c927cb03-f8fb-4caa-92ea-fb2f837fc5de");
                        Guid? parentId = new Guid("98718fb4-c136-4256-9ddc-6c2f507ab57e");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Type"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.article_type\"",\""default\"":\""\""}"",
  ""name"": ""article_type"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""TypeSelectOptions\"",\""default\"":\""\""}"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 43a0d0bf-e410-4216-92de-7e3933bc7aa9 >>
                    {
                        var id = new Guid("43a0d0bf-e410-4216-92de-7e3933bc7aa9");
                        Guid? parentId = new Guid("98718fb4-c136-4256-9ddc-6c2f507ab57e");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Part Number"",
  ""link"": """",
  ""mode"": ""2"",
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: b77a5f62-838b-4133-8480-fd89b0388fee >>
                    {
                        var id = new Guid("b77a5f62-838b-4133-8480-fd89b0388fee");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee"",
  ""name"": ""update"",
  ""hook_key"": ""article_type_update"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: d7360326-6ceb-4eb9-8acf-88bf9c8bfccd >>
                    {
                        var id = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? parentId = new Guid("b77a5f62-838b-4133-8480-fd89b0388fee");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": ""mt-5"",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 12,
  ""container1_span_md"": 6,
  ""container1_span_lg"": 4,
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
  ""container2_span_lg"": 4,
  ""container2_span_xl"": 0,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 0,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 1,
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 68ca00da-2a4c-47f2-9591-5ba6c1f8d756 >>
                    {
                        var id = new Guid("68ca00da-2a4c-47f2-9591-5ba6c1f8d756");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": """",
  ""area_sublabel"": """",
  ""title"": ""Types"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""fas fa-list-ul"",
  ""return_url"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 8e8e108d-5ec2-4041-948a-2ba6b104bb7d >>
                    {
                        var id = new Guid("8e8e108d-5ec2-4041-948a-2ba6b104bb7d");
                        Guid? parentId = new Guid("68ca00da-2a4c-47f2-9591-5ba6c1f8d756");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Add"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ArticleTypes.ArticleTypeCreateSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 851fc680-aba6-4bc2-a16b-bdb4891b2f1f >>
                    {
                        var id = new Guid("851fc680-aba6-4bc2-a16b-bdb4891b2f1f");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": """",
  ""area_sublabel"": """",
  ""title"": ""Manage"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""fa fa-pencil-alt"",
  ""return_url"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 9e6b6616-aaca-40f3-9ac6-18d2ba21e02a >>
                    {
                        var id = new Guid("9e6b6616-aaca-40f3-9ac6-18d2ba21e02a");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet.cs\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""/master-data/article-type/article-types/l/all"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 5;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7c00b7ca-ae9f-4b31-8898-c7140f763811 >>
                    {
                        var id = new Guid("7c00b7ca-ae9f-4b31-8898-c7140f763811");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Unit"",
  ""link"": """",
  ""mode"": ""1"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.unit\"",\""default\"":\""\""}"",
  ""name"": ""unit"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet.cs\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 2d245e7e-e507-4224-9d87-ab67d1d9f902 >>
                    {
                        var id = new Guid("2d245e7e-e507-4224-9d87-ab67d1d9f902");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Label"",
  ""link"": """",
  ""mode"": ""1"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.label\"",\""default\"":\""\""}"",
  ""name"": ""label"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet.cs\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 6b49da0f-a044-4bd6-9952-eb0d1992ed78 >>
                    {
                        var id = new Guid("6b49da0f-a044-4bd6-9952-eb0d1992ed78");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet.cs\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee""
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: b8291348-6f93-4dcd-b1bc-1f71ef213259 >>
                    {
                        var id = new Guid("b8291348-6f93-4dcd-b1bc-1f71ef213259");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 3,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllArticleTypes\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": ""article_grid"",
  ""prefix"": """",
  ""class"": ""mb-5"",
  ""striped"": ""true"",
  ""small"": ""true"",
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
  ""container1_label"": ""Label"",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""true"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Unit"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 56346cee-93d7-4644-8f59-4139b3405318 >>
                    {
                        var id = new Guid("56346cee-93d7-4644-8f59-4139b3405318");
                        Guid? parentId = new Guid("b8291348-6f93-4dcd-b1bc-1f71ef213259");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.label\"",\""default\"":\""\""}"",
  ""name"": ""label"",
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

                    #region << ***Create page body node*** Page name: all  id: 32ed69fc-f4e1-4ad8-a45e-b8783d5398f3 >>
                    {
                        var id = new Guid("32ed69fc-f4e1-4ad8-a45e-b8783d5398f3");
                        Guid? parentId = new Guid("b8291348-6f93-4dcd-b1bc-1f71ef213259");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column3";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-pencil-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ArticleTypes.ArticleTypeManageSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: b9c5c9b6-3ff7-4da0-8ed1-b2c27a1de478 >>
                    {
                        var id = new Guid("b9c5c9b6-3ff7-4da0-8ed1-b2c27a1de478");
                        Guid? parentId = new Guid("b8291348-6f93-4dcd-b1bc-1f71ef213259");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column3";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Delete"",
  ""color"": ""6"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""far fa-trash-alt icon"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ArticleTypes.ArticleTypeDeleteSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 4f7ab6b9-613b-4a04-9107-d88b7367315b >>
                    {
                        var id = new Guid("4f7ab6b9-613b-4a04-9107-d88b7367315b");
                        Guid? parentId = new Guid("b8291348-6f93-4dcd-b1bc-1f71ef213259");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.unit\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: b105f123-1e66-4c16-820e-fcdf99d2b8fd >>
                    {
                        var id = new Guid("b105f123-1e66-4c16-820e-fcdf99d2b8fd");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldTextarea";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.designation\"",\""default\"":\""\""}"",
  ""name"": ""designation"",
  ""class"": """",
  ""height"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 5;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: c7d59ef4-6033-40d4-ac17-f9e0b44be529 >>
                    {
                        var id = new Guid("c7d59ef4-6033-40d4-ac17-f9e0b44be529");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 950794a4-35cc-4fd5-9ec6-62d6550d22a8 >>
                    {
                        var id = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
                        Guid? parentId = new Guid("c7d59ef4-6033-40d4-ac17-f9e0b44be529");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 245895a9-83f4-420d-91fb-bdb032bc0de9 >>
                    {
                        var id = new Guid("245895a9-83f4-420d-91fb-bdb032bc0de9");
                        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""0"",
  ""class"": ""w-100 ml-0"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 0d9592c3-b250-4fd7-b9ea-ec53ba251e96 >>
                    {
                        var id = new Guid("0d9592c3-b250-4fd7-b9ea-ec53ba251e96");
                        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Eplan Import"",
  ""color"": ""0"",
  ""size"": ""0"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""/master-data/a/import"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 60f7995e-a747-41fb-b38b-4a4de2438869 >>
                    {
                        var id = new Guid("60f7995e-a747-41fb-b38b-4a4de2438869");
                        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""0"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fa fa-plus go-green"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""/master-data/articles/articles/c/create"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7cf13c63-eb64-4ccd-8245-af42dec8de3a >>
                    {
                        var id = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
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
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""/master-data/manufacturers/manufacturers/r/"",
  ""container1_label"": ""Preview"",
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
  ""container2_sortable"": ""true"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""true"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: bd23d447-86ac-4aa0-80ad-5e7608b71e43 >>
                    {
                        var id = new Guid("bd23d447-86ac-4aa0-80ad-5e7608b71e43");
                        Guid? parentId = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.short_name\"",\""default\"":\""\""}"",
  ""name"": ""short_name"",
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

                    #region << ***Create page body node*** Page name: all  id: 874b53b0-6573-499a-88f2-86e1adf5841b >>
                    {
                        var id = new Guid("874b53b0-6573-499a-88f2-86e1adf5841b");
                        Guid? parentId = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.name\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 1e6b8cfe-8c41-492f-9c1b-dda68100833c >>
                    {
                        var id = new Guid("1e6b8cfe-8c41-492f-9c1b-dda68100833c");
                        Guid? parentId = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column4";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Visit Website"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListVisitButtonVisibilitySnippet.cs\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.website\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 75c962af-19a3-428c-9572-a5679c710feb >>
                    {
                        var id = new Guid("75c962af-19a3-428c-9572-a5679c710feb");
                        Guid? parentId = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImageSnippet.cs\"",\""default\"":\""no icon\""}"",
  ""name"": ""preview"",
  ""class"": """",
  ""upload_mode"": ""1"",
  ""toolbar_mode"": ""1"",
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

                    #region << ***Create page body node*** Page name: all  id: 9569b249-9a35-44b2-9d71-1e8c0d60b662 >>
                    {
                        var id = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 5,
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
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""/master-data/articles/articles/r/"",
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
  ""container2_sortable"": ""true"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Manufacturer"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""true"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: d3d79404-799b-4afa-8271-21205ecbead1 >>
                    {
                        var id = new Guid("d3d79404-799b-4afa-8271-21205ecbead1");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldCheckbox";
                        var containerId = "column5";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.is_blocked\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""text_true"": ""blocked"",
  ""text_false"": ""not blocked"",
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

                    #region << ***Create page body node*** Page name: all  id: 81b3194d-137e-45ad-bf33-171808ca7d68 >>
                    {
                        var id = new Guid("81b3194d-137e-45ad-bf33-171808ca7d68");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.part_number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: d1cd7593-6f32-4deb-bfd4-c2c8b3bdd97c >>
                    {
                        var id = new Guid("d1cd7593-6f32-4deb-bfd4-c2c8b3bdd97c");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleListImageSnippet.cs\"",\""default\"":\""no icon\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""upload_mode"": ""1"",
  ""toolbar_mode"": ""1"",
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

                    #region << ***Create page body node*** Page name: all  id: 442fa321-20be-4a58-b69c-d7b35bf01636 >>
                    {
                        var id = new Guid("442fa321-20be-4a58-b69c-d7b35bf01636");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column4";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.designation\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 778f3b63-0da5-482b-a241-a3c63ce268e3 >>
                    {
                        var id = new Guid("778f3b63-0da5-482b-a241-a3c63ce268e3");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$article_manufacturer[0].name\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: import-manufacturers  id: ba2d22c5-09ee-448d-a4ec-c04a7eea6a73 >>
                    {
                        var id = new Guid("ba2d22c5-09ee-448d-a4ec-c04a7eea6a73");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": """",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""fas fa-building"",
  ""return_url"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 0f18f1e4-c03e-4938-ad40-4d4111cf40b1 >>
                    {
                        var id = new Guid("0f18f1e4-c03e-4938-ad40-4d4111cf40b1");
                        Guid? parentId = new Guid("ba2d22c5-09ee-448d-a4ec-c04a7eea6a73");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""w-100"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: e32f6215-2680-4604-bb35-49ae0edb1e43 >>
                    {
                        var id = new Guid("e32f6215-2680-4604-bb35-49ae0edb1e43");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 5dd80315-d1b4-4a24-bb25-45081f3edfd1 >>
                    {
                        var id = new Guid("5dd80315-d1b4-4a24-bb25-45081f3edfd1");
                        Guid? parentId = new Guid("e32f6215-2680-4604-bb35-49ae0edb1e43");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Type"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.article_type\"",\""default\"":\""\""}"",
  ""name"": ""article_type"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""TypeSelectOptions\"",\""default\"":\""\""}"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 5ce61001-e594-4be9-ae70-031863d4cae4 >>
                    {
                        var id = new Guid("5ce61001-e594-4be9-ae70-031863d4cae4");
                        Guid? parentId = new Guid("e32f6215-2680-4604-bb35-49ae0edb1e43");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Part Number"",
  ""link"": """",
  ""mode"": ""2"",
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 69832972-4c41-47ef-862c-5ba50f541570 >>
                    {
                        var id = new Guid("69832972-4c41-47ef-862c-5ba50f541570");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: b99ed6b1-4b3c-44a7-accd-41cb14c13d16 >>
                    {
                        var id = new Guid("b99ed6b1-4b3c-44a7-accd-41cb14c13d16");
                        Guid? parentId = new Guid("69832972-4c41-47ef-862c-5ba50f541570");
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Name"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.name\"",\""default\"":\""\""}"",
  ""name"": ""name"",
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

                    #region << ***Create page body node*** Page name: detail  id: db59a161-8459-44bb-b501-ce0baeadcbb6 >>
                    {
                        var id = new Guid("db59a161-8459-44bb-b501-ce0baeadcbb6");
                        Guid? parentId = new Guid("69832972-4c41-47ef-862c-5ba50f541570");
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Short Name"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.short_name\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: 4ebf4f07-45e8-48ce-b44a-3c849120576c >>
                    {
                        var id = new Guid("4ebf4f07-45e8-48ce-b44a-3c849120576c");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleDetailImageSnippet.cs\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""upload_mode"": ""1"",
  ""toolbar_mode"": ""1"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": """",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 419583e8-7069-4b33-b8b7-56b88199e74f >>
                    {
                        var id = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-419583e8-7069-4b33-b8b7-56b88199e74f"",
  ""name"": ""delete form"",
  ""hook_key"": ""delete"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 6;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 97b4b2d8-f7ce-4014-ae66-f1ce58b2f6f8 >>
                    {
                        var id = new Guid("97b4b2d8-f7ce-4014-ae66-f1ce58b2f6f8");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcDrawer";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""title"": ""Search Manufacturers"",
  ""width"": ""550px"",
  ""class"": """",
  ""body_class"": """",
  ""title_action_html"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 59cb9594-5748-4737-b7fb-25fa2f3fdd8f >>
                    {
                        var id = new Guid("59cb9594-5748-4737-b7fb-25fa2f3fdd8f");
                        Guid? parentId = new Guid("97b4b2d8-f7ce-4014-ae66-f1ce58b2f6f8");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-767cc292-29de-43b1-bada-5d9ca4d6ac72"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: cfe7cb8e-d347-41b1-86e0-dc78dc29de3b >>
                    {
                        var id = new Guid("cfe7cb8e-d347-41b1-86e0-dc78dc29de3b");
                        Guid? parentId = new Guid("59cb9594-5748-4737-b7fb-25fa2f3fdd8f");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Short Name"",
  ""name"": ""short_name"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""18"",
  ""query_type"": ""3"",
  ""query_options"": [
    ""3""
  ],
  ""prefix"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 00bc191a-ad77-41e7-8cb0-b31db60c7aa9 >>
                    {
                        var id = new Guid("00bc191a-ad77-41e7-8cb0-b31db60c7aa9");
                        Guid? parentId = new Guid("59cb9594-5748-4737-b7fb-25fa2f3fdd8f");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Name"",
  ""name"": ""name"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""18"",
  ""query_type"": ""1"",
  ""query_options"": [
    ""1""
  ],
  ""prefix"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: e44517bb-b155-46db-bd36-30106cfaf12c >>
                    {
                        var id = new Guid("e44517bb-b155-46db-bd36-30106cfaf12c");
                        Guid? parentId = new Guid("59cb9594-5748-4737-b7fb-25fa2f3fdd8f");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
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
  ""form"": ""wv-767cc292-29de-43b1-bada-5d9ca4d6ac72""
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: d62de715-ebad-4800-aea9-0fee52debd88 >>
                    {
                        var id = new Guid("d62de715-ebad-4800-aea9-0fee52debd88");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcDrawer";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""title"": ""Search"",
  ""width"": ""550px"",
  ""class"": """",
  ""body_class"": """",
  ""title_action_html"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 767cc292-29de-43b1-bada-5d9ca4d6ac72 >>
                    {
                        var id = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? parentId = new Guid("d62de715-ebad-4800-aea9-0fee52debd88");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-767cc292-29de-43b1-bada-5d9ca4d6ac72"",
  ""name"": ""form"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 82c0b0a1-0f98-4f3d-95ea-bf6af4897b6d >>
                    {
                        var id = new Guid("82c0b0a1-0f98-4f3d-95ea-bf6af4897b6d");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Designation"",
  ""name"": ""designation"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 45883bf8-a5fa-4303-8ab5-012e7c758a95 >>
                    {
                        var id = new Guid("45883bf8-a5fa-4303-8ab5-012e7c758a95");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Manufacturer"",
  ""name"": ""manufacturer"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""18"",
  ""query_type"": ""3"",
  ""query_options"": [
    ""3""
  ],
  ""prefix"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: b6da2c84-92d5-4ce4-bf09-cfc34798f0a9 >>
                    {
                        var id = new Guid("b6da2c84-92d5-4ce4-bf09-cfc34798f0a9");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
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
  ""form"": ""wv-767cc292-29de-43b1-bada-5d9ca4d6ac72""
}";
                        var weight = 5;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 93b6057d-e538-4f90-a52f-2a553d0c38c8 >>
                    {
                        var id = new Guid("93b6057d-e538-4f90-a52f-2a553d0c38c8");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Blocked"",
  ""name"": ""is_blocked"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""2"",
  ""query_type"": ""3"",
  ""query_options"": [
    ""3""
  ],
  ""prefix"": """"
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 620f4a68-5bdd-4f29-9866-86832846867e >>
                    {
                        var id = new Guid("620f4a68-5bdd-4f29-9866-86832846867e");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Part Number"",
  ""name"": ""part_number"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""18"",
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: f6b749b1-2360-4a11-8690-e45e799ee1e7 >>
                    {
                        var id = new Guid("f6b749b1-2360-4a11-8690-e45e799ee1e7");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Visit Website"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt icon"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerDetailVisitButtonVisibilitySnippet.cs\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""Record.website\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: b7c12ebd-b11f-4d3b-abba-8e964688ec78 >>
                    {
                        var id = new Guid("b7c12ebd-b11f-4d3b-abba-8e964688ec78");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-419583e8-7069-4b33-b8b7-56b88199e74f"",
  ""name"": ""delete form"",
  ""hook_key"": ""delete"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 5;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 166d90cd-8fd6-4ca6-b019-cc4d58eea720 >>
                    {
                        var id = new Guid("166d90cd-8fd6-4ca6-b019-cc4d58eea720");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerDetailImageSnippet.cs\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": """",
  ""upload_mode"": ""1"",
  ""toolbar_mode"": ""1"",
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

                    #region << ***Create page body node*** Page name: manage  id: 3464bb03-9bf0-4ef8-be4d-18adf7217160 >>
                    {
                        var id = new Guid("3464bb03-9bf0-4ef8-be4d-18adf7217160");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 025c0359-bdb7-4952-9ea8-d332e9e075f6 >>
                    {
                        var id = new Guid("025c0359-bdb7-4952-9ea8-d332e9e075f6");
                        Guid? parentId = new Guid("3464bb03-9bf0-4ef8-be4d-18adf7217160");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 239fabe3-3658-4dd8-ba5a-e27f4a4ff19f >>
                    {
                        var id = new Guid("239fabe3-3658-4dd8-ba5a-e27f4a4ff19f");
                        Guid? parentId = new Guid("025c0359-bdb7-4952-9ea8-d332e9e075f6");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Short Name"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.short_name\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: manage  id: 353e3f76-47e5-4422-a8f1-eeec81b169a3 >>
                    {
                        var id = new Guid("353e3f76-47e5-4422-a8f1-eeec81b169a3");
                        Guid? parentId = new Guid("025c0359-bdb7-4952-9ea8-d332e9e075f6");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Name"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.name\"",\""default\"":\""\""}"",
  ""name"": ""name"",
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

                    #region << ***Create page body node*** Page name: manage  id: 7cd7ab94-e09c-4dc3-916a-726f065dda37 >>
                    {
                        var id = new Guid("7cd7ab94-e09c-4dc3-916a-726f065dda37");
                        Guid? parentId = new Guid("3464bb03-9bf0-4ef8-be4d-18adf7217160");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldUrl";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Website"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.website\"",\""default\"":\""\""}"",
  ""name"": ""website"",
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: d3699d38-8365-4709-9118-cc4f5296e12a >>
                    {
                        var id = new Guid("d3699d38-8365-4709-9118-cc4f5296e12a");
                        Guid? parentId = new Guid("3464bb03-9bf0-4ef8-be4d-18adf7217160");
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldUrl";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Image (Url)"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.logo\"",\""default\"":\""\""}"",
  ""name"": ""logo"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 7975a266-44cf-4616-9842-bfff0446c3b5 >>
                    {
                        var id = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcDrawer";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""title"": ""Search"",
  ""width"": ""550px"",
  ""class"": """",
  ""body_class"": """",
  ""title_action_html"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7 >>
                    {
                        var id = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
                        Guid? parentId = new Guid("7975a266-44cf-4616-9842-bfff0446c3b5");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "body";
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: d51d2ef9-d8d4-4976-8810-4a3c44431811 >>
                    {
                        var id = new Guid("d51d2ef9-d8d4-4976-8810-4a3c44431811");
                        Guid? parentId = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Name"",
  ""name"": ""name"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""1"",
  ""query_options"": [
    ""1""
  ],
  ""prefix"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 4053e3e4-0497-487c-b07f-af5c253312a7 >>
                    {
                        var id = new Guid("4053e3e4-0497-487c-b07f-af5c253312a7");
                        Guid? parentId = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Short Name"",
  ""name"": ""short_name"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""3"",
  ""query_options"": [
    ""3""
  ],
  ""prefix"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 58ae5214-c935-45fb-9b12-6c0da4b1f712 >>
                    {
                        var id = new Guid("58ae5214-c935-45fb-9b12-6c0da4b1f712");
                        Guid? parentId = new Guid("f8ef0e8d-b3ec-435d-9616-6b9fbeecd4f7");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import  id: de518724-815f-4aff-ada7-b62f5832edb4 >>
                    {
                        var id = new Guid("de518724-815f-4aff-ada7-b62f5832edb4");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 0095678f-0baf-400f-9b67-188d739879f0 >>
                    {
                        var id = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "";
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
  ""container1_label"": ""Preview"",
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
  ""container2_sortable"": ""true"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""true"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: bb826b80-f6e4-4b53-9320-b0c3e0238ce7 >>
                    {
                        var id = new Guid("bb826b80-f6e4-4b53-9320-b0c3e0238ce7");
                        Guid? parentId = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImageSnippet.cs\"",\""default\"":\""\""}"",
  ""name"": ""preview"",
  ""class"": """",
  ""upload_mode"": ""1"",
  ""toolbar_mode"": ""1"",
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

                    #region << ***Create page body node*** Page name: import-manufacturers  id: e7741935-c339-4118-a19d-47735d31628f >>
                    {
                        var id = new Guid("e7741935-c339-4118-a19d-47735d31628f");
                        Guid? parentId = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.short_name\"",\""default\"":\""\""}"",
  ""name"": ""short_name"",
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

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 836e2513-08f5-49fe-a8d8-9f92add948da >>
                    {
                        var id = new Guid("836e2513-08f5-49fe-a8d8-9f92add948da");
                        Guid? parentId = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.name\"",\""default\"":\""\""}"",
  ""name"": ""name"",
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

                    #region << ***Create page body node*** Page name: import-manufacturers  id: cafb51d6-2ccd-42bc-bdab-9204ed1eba2c >>
                    {
                        var id = new Guid("cafb51d6-2ccd-42bc-bdab-9204ed1eba2c");
                        Guid? parentId = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column5";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Import"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImportButtonVisibilitySnippet.cs\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImportSnippet.cs\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: f9b1142b-7aff-4907-b129-59ec8f1c981f >>
                    {
                        var id = new Guid("f9b1142b-7aff-4907-b129-59ec8f1c981f");
                        Guid? parentId = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column4";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Visit Website"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListVisitButtonVisibilitySnippet.cs\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.website\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import  id: 73c0e370-0564-443a-9055-d015f401b7ef >>
                    {
                        var id = new Guid("73c0e370-0564-443a-9055-d015f401b7ef");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-73c0e370-0564-443a-9055-d015f401b7ef"",
  ""name"": ""importEplanArticleForm"",
  ""hook_key"": ""article_eplan_import"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import  id: dd83f0b6-1a89-4f1c-8ea7-78912c67129b >>
                    {
                        var id = new Guid("dd83f0b6-1a89-4f1c-8ea7-78912c67129b");
                        Guid? parentId = new Guid("73c0e370-0564-443a-9055-d015f401b7ef");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import  id: 4f6af4b6-f951-4c42-b5f7-6d3cab84f64b >>
                    {
                        var id = new Guid("4f6af4b6-f951-4c42-b5f7-6d3cab84f64b");
                        Guid? parentId = new Guid("dd83f0b6-1a89-4f1c-8ea7-78912c67129b");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Type"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.article_type\"",\""default\"":\""6e4b019b-9665-43d8-a71e-a211d1ab3e85\""}"",
  ""name"": ""article_type"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""TypeSelectOptions\"",\""default\"":\""\""}"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import  id: c3b53b06-cae2-4f65-ac46-73e92891a015 >>
                    {
                        var id = new Guid("c3b53b06-cae2-4f65-ac46-73e92891a015");
                        Guid? parentId = new Guid("dd83f0b6-1a89-4f1c-8ea7-78912c67129b");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Eplan Identifier"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": """",
  ""name"": ""eplan_identifier"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": ""e.g. RIT.123456"",
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

                    #region << ***Create page body node*** Page name: import  id: e47f8836-2033-46cc-afbe-87d550a6a0c9 >>
                    {
                        var id = new Guid("e47f8836-2033-46cc-afbe-87d550a6a0c9");
                        Guid? parentId = new Guid("73c0e370-0564-443a-9055-d015f401b7ef");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "body";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Import Article"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-cloud-download-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-73c0e370-0564-443a-9055-d015f401b7ef""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: e28df5ae-a3f0-4565-af53-86a60aaf6a81 >>
                    {
                        var id = new Guid("e28df5ae-a3f0-4565-af53-86a60aaf6a81");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: bf842818-8e7c-409f-8069-2af8c6df674c >>
                    {
                        var id = new Guid("bf842818-8e7c-409f-8069-2af8c6df674c");
                        Guid? parentId = new Guid("e28df5ae-a3f0-4565-af53-86a60aaf6a81");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 9c67c004-39cb-4cc8-8831-dbe3fc166950 >>
                    {
                        var id = new Guid("9c67c004-39cb-4cc8-8831-dbe3fc166950");
                        Guid? parentId = new Guid("bf842818-8e7c-409f-8069-2af8c6df674c");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Create"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 mb-2"",
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
  ""form"": ""wv-1461f5a7-21a6-4569-a62a-c891351007d5""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 596c3352-ce69-4335-9fa4-bf027c0f200a >>
                    {
                        var id = new Guid("596c3352-ce69-4335-9fa4-bf027c0f200a");
                        Guid? parentId = new Guid("bf842818-8e7c-409f-8069-2af8c6df674c");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: cfcec2e5-b324-4752-9c9e-4f29020ea671 >>
                    {
                        var id = new Guid("cfcec2e5-b324-4752-9c9e-4f29020ea671");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 8e438719-124f-4806-8f38-ab73127a0f49 >>
                    {
                        var id = new Guid("8e438719-124f-4806-8f38-ab73127a0f49");
                        Guid? parentId = new Guid("cfcec2e5-b324-4752-9c9e-4f29020ea671");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 6,
  ""container1_span_md"": 0,
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
  ""container2_span_sm"": 6,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: b96c33e0-379e-4c91-9b74-abb7a3691b6f >>
                    {
                        var id = new Guid("b96c33e0-379e-4c91-9b74-abb7a3691b6f");
                        Guid? parentId = new Guid("8e438719-124f-4806-8f38-ab73127a0f49");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 89657983-9e48-4a3a-8f9b-222cf9d5af15 >>
                    {
                        var id = new Guid("89657983-9e48-4a3a-8f9b-222cf9d5af15");
                        Guid? parentId = new Guid("8e438719-124f-4806-8f38-ab73127a0f49");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Create"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""text-nowrap w-100 mb-2"",
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
  ""form"": ""wv-1461f5a7-21a6-4569-a62a-c891351007d5""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 3065922e-17e0-42d2-9a9e-8fafdb4ec249 >>
                    {
                        var id = new Guid("3065922e-17e0-42d2-9a9e-8fafdb4ec249");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-1461f5a7-21a6-4569-a62a-c891351007d5"",
  ""name"": ""CreateRecord"",
  ""hook_key"": ""manufacturer_create"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: df1d1376-630b-4499-9ee4-8a4af36c91ce >>
                    {
                        var id = new Guid("df1d1376-630b-4499-9ee4-8a4af36c91ce");
                        Guid? parentId = new Guid("3065922e-17e0-42d2-9a9e-8fafdb4ec249");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 5,
  ""container1_span_md"": 4,
  ""container1_span_lg"": 3,
  ""container1_span_xl"": 2,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""2"",
  ""container1_flex_order"": 0,
  ""container2_span"": 0,
  ""container2_span_sm"": 6,
  ""container2_span_md"": 7,
  ""container2_span_lg"": 8,
  ""container2_span_xl"": 9,
  ""container2_offset"": 0,
  ""container2_offset_sm"": 1,
  ""container2_offset_md"": 0,
  ""container2_offset_lg"": 0,
  ""container2_offset_xl"": 0,
  ""container2_flex_self_align"": ""2"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 7bc1b17c-85ce-4c50-a885-0be32e428092 >>
                    {
                        var id = new Guid("7bc1b17c-85ce-4c50-a885-0be32e428092");
                        Guid? parentId = new Guid("df1d1376-630b-4499-9ee4-8a4af36c91ce");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.short_name\"",\""default\"":\""\""}"",
  ""name"": ""short_name"",
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

                    #region << ***Create page body node*** Page name: create  id: f8e7e8e3-c436-445b-b410-13fc794569da >>
                    {
                        var id = new Guid("f8e7e8e3-c436-445b-b410-13fc794569da");
                        Guid? parentId = new Guid("df1d1376-630b-4499-9ee4-8a4af36c91ce");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Name"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.name\"",\""default\"":\""\""}"",
  ""name"": ""name"",
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

                    #region << ***Create page body node*** Page name: create  id: 32870f8b-f7e3-4ed7-b70d-995a2a4f4d73 >>
                    {
                        var id = new Guid("32870f8b-f7e3-4ed7-b70d-995a2a4f4d73");
                        Guid? parentId = new Guid("3065922e-17e0-42d2-9a9e-8fafdb4ec249");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldUrl";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Logo (URL)"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.logo\"",\""default\"":\""\""}"",
  ""name"": ""logo"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 6bbf3744-afa0-4273-976f-356e23d963bb >>
                    {
                        var id = new Guid("6bbf3744-afa0-4273-976f-356e23d963bb");
                        Guid? parentId = new Guid("3065922e-17e0-42d2-9a9e-8fafdb4ec249");
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldUrl";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Website"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.website\"",\""default\"":\""\""}"",
  ""name"": ""website"",
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: a1ea239d-f3ed-434d-92cb-c3d65174c53c >>
                    {
                        var id = new Guid("a1ea239d-f3ed-434d-92cb-c3d65174c53c");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllManufacturers >>
                    {
                        var id = new Guid("4c537e23-2fe0-4da4-b14f-bb74327f744b");
                        var name = @"AllManufacturers";
                        var description = @"records of all manufacturers";
                        var eqlText = @"SELECT *
FROM manufacturer
WHERE (@name = null OR name STARTSWITH @name)
    AND(@shortName = null OR short_name = @shortName)
ORDER BY @sortBy @sortOrder
PAGE @page
PAGESIZE @pageSize";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_manufacturer.""id"" AS ""id"",
	 rec_manufacturer.""logo"" AS ""logo"",
	 rec_manufacturer.""website"" AS ""website"",
	 rec_manufacturer.""eplan_id"" AS ""eplan_id"",
	 rec_manufacturer.""short_name"" AS ""short_name"",
	 rec_manufacturer.""name"" AS ""name"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_manufacturer
WHERE  (  (  ( @name IS NULL )  OR  ( rec_manufacturer.""name""  ILIKE CONCAT ( @name,'%'  ) )  )  AND  (  ( @shortName IS NULL )  OR  ( rec_manufacturer.""short_name"" IS NULL )  )  ) 
ORDER BY rec_manufacturer.""name"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""name"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""shortName"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""name"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""logo"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""website"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""short_name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"manufacturer";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var description = @"All Article Types";
                        var eqlText = @"SELECT *
FROM article_type
WHERE (@label = null OR label STARTSWITH @label)
    AND(@unit = null OR unit STARTSWITH @unit)
ORDER BY @sortBy @sortOrder
PAGE @page
PAGESIZE @pageSize";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article_type.""id"" AS ""id"",
	 rec_article_type.""unit"" AS ""unit"",
	 rec_article_type.""label"" AS ""label"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_article_type
WHERE  (  (  ( @label IS NULL )  OR  ( rec_article_type.""label""  ILIKE CONCAT ( @label,'%'  ) )  )  AND  (  ( @unit IS NULL )  OR  ( rec_article_type.""unit""  ILIKE CONCAT ( @unit,'%'  ) )  )  ) 
ORDER BY rec_article_type.""label"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""label"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""unit"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""unit"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""label"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"article_type";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllArticles >>
                    {
                        var id = new Guid("28b0a525-e227-4fe2-a073-bcd8300a1b37");
                        var name = @"AllArticles";
                        var description = @"records of all articles";
                        var eqlText = @"SELECT *, $article_manufacturer.name
FROM article
WHERE (@isBlocked = null OR is_blocked = @isBlocked)
    AND(@partNumber = null OR part_number CONTAINS @partNumber)
    AND(@manufacturer = null OR $article_manufacturer.name = @manufacturer)
    AND(@designation = null OR designation CONTAINS @designation)
ORDER BY @sortBy @sortOrder
PAGE @page
PAGESIZE @pageSize";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article.""id"" AS ""id"",
	 rec_article.""manufacturer_id"" AS ""manufacturer_id"",
	 rec_article.""preview"" AS ""preview"",
	 rec_article.""part_number"" AS ""part_number"",
	 rec_article.""eplan_id"" AS ""eplan_id"",
	 rec_article.""article_type"" AS ""article_type"",
	 rec_article.""designation"" AS ""designation"",
	 rec_article.""is_blocked"" AS ""is_blocked"",
	 COUNT(*) OVER() AS ___total_count___,
	------->: $article_manufacturer
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 article_manufacturer.""id"" AS ""id"",
		 article_manufacturer.""name"" AS ""name""
	 FROM rec_manufacturer article_manufacturer
	 WHERE article_manufacturer.id = rec_article.manufacturer_id ) d )::jsonb AS ""$article_manufacturer""	
	-------< $article_manufacturer

FROM rec_article

LEFT OUTER JOIN  rec_manufacturer article_manufacturer_tar_org ON article_manufacturer_tar_org.id = rec_article.manufacturer_id
WHERE  (  (  (  (  ( @isBlocked IS NULL )  OR  ( rec_article.""is_blocked"" IS NULL )  )  AND  (  ( @partNumber IS NULL )  OR  ( rec_article.""part_number""  ILIKE  CONCAT ( '%' , @partNumber , '%' ) ) )  )  AND  (  ( @manufacturer IS NULL )  OR  ( article_manufacturer_tar_org.""name"" IS NULL )  )  )  AND  (  ( @designation IS NULL )  OR  ( rec_article.""designation""  ILIKE  CONCAT ( '%' , @designation , '%' ) ) )  ) 
ORDER BY rec_article.""part_number"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""isBlocked"",""type"":""bool"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""manufacturer"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""designation"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""part_number"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""manufacturer_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""preview"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""part_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""article_type"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""is_blocked"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$article_manufacturer"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"article";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("929280d3-e3dd-4535-a6a4-875d099cacd8");
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("3652b249-73a6-4df3-93c8-5ceeb4fa0991");
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("029ae52b-f2af-4da6-8548-3cffe2588cab");
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("92db3e50-338f-45ca-a2f2-274407b541a3");
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("2678eb65-f542-4d2d-a704-7da3f5dbe8be");
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("93e9108f-267e-482d-b2b0-96be1a9c34b2");
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("419b1546-cf9a-4418-85f5-02130e95ba38");
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("004c5d65-10cb-4302-9028-1d631a2fb7a1");
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("2a62e9ed-f8b4-4ebf-b84b-20bdbad223f3");
                        var pageId = new Guid("f60066b5-7c38-4fd3-8beb-688e73deb52b");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: EplanManufacturers >>
                    {
                        var id = new Guid("60d06119-2fce-4d63-bc74-1d1cbf5bd704");
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var dataSourceId = new Guid("0fdba4a2-6779-49eb-b299-41e394d86df3");
                        var name = @"EplanManufacturers";
                        var parameters = @"[{""name"":""shortName"",""type"":""text"",""value"":""{{RequestQuery.q_short_name_v}}"",""ignore_parse_errors"":false},{""name"":""name"",""type"":""text"",""value"":""{{RequestQuery.q_name_v}}"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""{{RequestQuery.sortBy}}"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""{{RequestQuery.sortOrder}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticles >>
                    {
                        var id = new Guid("12726284-3106-47ab-adb0-36b496d59a1f");
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var dataSourceId = new Guid("28b0a525-e227-4fe2-a073-bcd8300a1b37");
                        var name = @"AllArticles";
                        var parameters = @"[{""name"":""isBlocked"",""type"":""bool"",""value"":""{{RequestQuery.q_is_blocked_v}}"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""{{RequestQuery.q_part_number_v}}"",""ignore_parse_errors"":false},{""name"":""manufacturer"",""type"":""text"",""value"":""{{RequestQuery.q_manufacturer_v}}"",""ignore_parse_errors"":false},{""name"":""designation"",""type"":""text"",""value"":""{{RequestQuery.q_designation_v}}"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""{{RequestQuery.sortBy}}"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""{{RequestQuery.sortOrder}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllManufacturers >>
                    {
                        var id = new Guid("9ef23f0f-a996-4bcb-ab71-701d945ed201");
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var dataSourceId = new Guid("4c537e23-2fe0-4da4-b14f-bb74327f744b");
                        var name = @"AllManufacturers";
                        var parameters = @"[{""name"":""name"",""type"":""text"",""value"":""{{RequestQuery.q_name_v}}"",""ignore_parse_errors"":false},{""name"":""shortName"",""type"":""text"",""value"":""{{RequestQuery.q_short_name_v}}"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""{{RequestQuery.sortBy}}"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""{{RequestQuery.sortOrder}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("56b00754-b812-4b7d-9145-31be38ad8520");
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("d39c3ab7-1533-4352-bc3e-72fc87911fa5");
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("6e9e9841-5bf1-4d31-a2c0-9b8eb735626c");
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("8c429772-45e6-4120-a493-1d4816787222");
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("3dd94c07-38c8-40ba-8213-89242ab9b3bb");
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""{{RequestQuery.sortBy}}"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""{{RequestQuery.sortOrder}}"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion


                }
            }
        }
    }
}
