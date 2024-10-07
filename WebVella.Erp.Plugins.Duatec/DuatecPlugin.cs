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

                // insert difference code here
                {
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

                    #region << ***Create field***  Entity: article_type Field Name: unit_kind >>
                    {
                        InputGuidField guidField = new InputGuidField();
                        guidField.Id = new Guid("bb9a8ecb-5021-4b28-ab11-c49d24f3482d");
                        guidField.Name = "unit_kind";
                        guidField.Label = "Unit Kind";
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
                            var response = entMan.CreateField(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37"), guidField, false);
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: article_type Field: unit_kind Message:" + response.Message);
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
                            var response = entMan.CreateField(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37"), textboxField, false);
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: article_type Field: label Message:" + response.Message);
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
                                throw new Exception("System error 10060. Entity: manufacturer Field: name Message:" + response.Message);
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
                        textboxField.Unique = false;
                        textboxField.Searchable = false;
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

                    #region << ***Create entity*** Entity name: unit >>
                    {
                        #region << entity >>
                        {
                            var entity = new InputEntity();
                            var systemFieldIdDictionary = new Dictionary<string, Guid>();
                            systemFieldIdDictionary["id"] = new Guid("9f0b67ef-6749-4f7b-ab6a-08a45228eca7");
                            entity.Id = new Guid("49156190-2465-4d96-8e69-b6d994ae5bc6");
                            entity.Name = "unit";
                            entity.Label = "Unit Kind";
                            entity.LabelPlural = "Unit Kinds";
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
                                    throw new Exception("System error 10050. Entity: unit creation Message: " + response.Message);
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region << ***Create field***  Entity: unit Field Name: value >>
                    {
                        InputTextField textboxField = new InputTextField();
                        textboxField.Id = new Guid("8b6f7085-6dab-49a2-aeba-cfb745d4ea30");
                        textboxField.Name = "value";
                        textboxField.Label = "value";
                        textboxField.PlaceholderText = null;
                        textboxField.Description = null;
                        textboxField.HelpText = null;
                        textboxField.Required = false;
                        textboxField.Unique = false;
                        textboxField.Searchable = false;
                        textboxField.Auditable = false;
                        textboxField.System = false;
                        textboxField.DefaultValue = "";
                        textboxField.MaxLength = Int32.Parse("16");
                        textboxField.EnableSecurity = false;
                        textboxField.Permissions = new FieldPermissions();
                        textboxField.Permissions.CanRead = new List<Guid>();
                        textboxField.Permissions.CanUpdate = new List<Guid>();
                        //READ
                        //UPDATE
                        {
                            var response = entMan.CreateField(new Guid("49156190-2465-4d96-8e69-b6d994ae5bc6"), textboxField, false);
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: unit Field: value Message:" + response.Message);
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

                    #region << ***Create field***  Entity: article Field Name: article_type >>
                    {
                        InputGuidField guidField = new InputGuidField();
                        guidField.Id = new Guid("5554f239-c024-4391-a9a6-8cea0e483867");
                        guidField.Name = "article_type";
                        guidField.Label = "Article Type";
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
                                throw new Exception("System error 10060. Entity: article Field: article_type Message:" + response.Message);
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

                    #region << ***Create field***  Entity: article Field Name: description >>
                    {
                        InputMultiLineTextField textareaField = new InputMultiLineTextField();
                        textareaField.Id = new Guid("186509fa-a2c0-4e10-ae42-ef4a67bdc36a");
                        textareaField.Name = "description";
                        textareaField.Label = "Description";
                        textareaField.PlaceholderText = null;
                        textareaField.Description = null;
                        textareaField.HelpText = null;
                        textareaField.Required = false;
                        textareaField.Unique = false;
                        textareaField.Searchable = false;
                        textareaField.Auditable = false;
                        textareaField.System = false;
                        textareaField.DefaultValue = "";
                        textareaField.MaxLength = null;
                        textareaField.VisibleLineNumber = null;
                        textareaField.EnableSecurity = false;
                        textareaField.Permissions = new FieldPermissions();
                        textareaField.Permissions.CanRead = new List<Guid>();
                        textareaField.Permissions.CanUpdate = new List<Guid>();
                        //READ
                        //UPDATE
                        {
                            var response = entMan.CreateField(new Guid("14640617-3a63-4065-b96a-8ae586e5b68b"), textareaField, false);
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: article Field: description Message:" + response.Message);
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

                    #region << ***Create field***  Entity: language Field Name: key >>
                    {
                        InputMultiLineTextField textareaField = new InputMultiLineTextField();
                        textareaField.Id = new Guid("5f21b531-559a-4119-ae75-2ed06e0c3429");
                        textareaField.Name = "key";
                        textareaField.Label = "Key";
                        textareaField.PlaceholderText = "e.g. en_US";
                        textareaField.Description = null;
                        textareaField.HelpText = null;
                        textareaField.Required = false;
                        textareaField.Unique = false;
                        textareaField.Searchable = false;
                        textareaField.Auditable = false;
                        textareaField.System = false;
                        textareaField.DefaultValue = "";
                        textareaField.MaxLength = null;
                        textareaField.VisibleLineNumber = null;
                        textareaField.EnableSecurity = false;
                        textareaField.Permissions = new FieldPermissions();
                        textareaField.Permissions.CanRead = new List<Guid>();
                        textareaField.Permissions.CanUpdate = new List<Guid>();
                        //READ
                        //UPDATE
                        {
                            var response = entMan.CreateField(new Guid("f22c806a-6495-4f12-be79-ce2105466baf"), textareaField, false);
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: language Field: key Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Create relation*** Relation name: article_unit_kind >>
                    {
                        var relation = new EntityRelation();
                        var originEntity = entMan.ReadEntity(new Guid("49156190-2465-4d96-8e69-b6d994ae5bc6")).Object;
                        var originField = originEntity.Fields.SingleOrDefault(x => x.Name == "id");
                        var targetEntity = entMan.ReadEntity(new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37")).Object;
                        var targetField = targetEntity.Fields.SingleOrDefault(x => x.Name == "unit_kind");
                        relation.Id = new Guid("e92c6eaa-4cbd-44e7-8ba2-89329440eafe");
                        relation.Name = "article_unit_kind";
                        relation.Label = "article_unit_kind";
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
                                throw new Exception("System error 10060. Relation: article_unit_kind Create. Message:" + response.Message);
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
                        relation.Id = new Guid("d9a986a6-f022-41df-90f6-00ec8fc3d582");
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

                    #region << ***Create page*** Page name: eplan-dataportal-import >>
                    {
                        var id = new Guid("d1635d81-b92f-4f93-a2b5-01cb05d79ca7");
                        var name = @"eplan-dataportal-import";
                        var label = "Eplan Data Portal Import";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)1);
                        var isRazorBody = false;
                        Guid? appId = null;
                        Guid? entityId = null;
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
                        var label = "All Articles";
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

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var name = @"all";
                        var label = "All Manufacturers";
                        var iconClass = "";
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

                    #region << ***Create page body node*** Page name: all  id: 0d9592c3-b250-4fd7-b9ea-ec53ba251e96 >>
                    {
                        var id = new Guid("0d9592c3-b250-4fd7-b9ea-ec53ba251e96");
                        Guid? parentId = new Guid("c7d59ef4-6033-40d4-ac17-f9e0b44be529");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Eplan Article Import"",
  ""color"": ""0"",
  ""size"": ""0"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""/s/eplan-dataportal-import"",
  ""new_tab"": ""false"",
  ""form"": """"
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
  ""hover"": ""false"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""container1_label"": """",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Preview"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Part Number"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Manufacturer"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Description"",
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

                    #region << ***Create page body node*** Page name: all  id: 81b3194d-137e-45ad-bf33-171808ca7d68 >>
                    {
                        var id = new Guid("81b3194d-137e-45ad-bf33-171808ca7d68");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
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

                    #region << ***Create page body node*** Page name: all  id: 442fa321-20be-4a58-b69c-d7b35bf01636 >>
                    {
                        var id = new Guid("442fa321-20be-4a58-b69c-d7b35bf01636");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column5";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.description\"",\""default\"":\""\""}"",
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
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""1\"",\""string\"":\""using System;\\nusing System.Collections.Generic;\\nusing WebVella.Erp.Web.Models;\\nusing WebVella.Erp.Api.Models;\\nusing Newtonsoft.Json;\\n\\npublic class GetDatasourceValueCodeVariable : ICodeVariable\\n{\\n\\tpublic object Evaluate(BaseErpPageModel pageModel)\\n\\t{\\n        try\\n        {\\n    \\t\\tvar url = pageModel.TryGetDataSourceProperty<EntityRecord>(\\\""RowRecord\\\"")?[\\\""preview\\\""];\\n    \\t\\treturn $\\\""<img src=\\\\\\\""{url}\\\\\\\"" widht=\\\\\\\""50\\\\\\\"" height=\\\\\\\""50\\\\\\\""/>\\\"";\\n        }\\n        catch (Exception ex)\\n        {\\n            return \\\""Error: \\\"" + ex.Message;\\n        }\\n\\t}\\n}\\n\"",\""default\"":\""no icon\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 778f3b63-0da5-482b-a241-a3c63ce268e3 >>
                    {
                        var id = new Guid("778f3b63-0da5-482b-a241-a3c63ce268e3");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column4";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""1\"",\""string\"":\""using System;\\nusing System.Collections.Generic;\\nusing WebVella.Erp.Web.Models;\\nusing WebVella.Erp.Api.Models;\\nusing Newtonsoft.Json;\\nusing System.Linq;\\n\\npublic class GetDatasourceValueCodeVariable : ICodeVariable\\n{\\n\\tpublic object Evaluate(BaseErpPageModel pageModel)\\n\\t{\\n\\t\\ttry{\\n\\t\\t\\tvar id = pageModel.TryGetDataSourceProperty<EntityRecord>(\\\""RowRecord\\\"")?[\\\""manufacturer_id\\\""];\\n\\t\\t\\tif(id == null)\\n\\t\\t\\t    return null;\\n\\t\\t\\t\\n\\t\\t\\treturn pageModel.TryGetDataSourceProperty<EntityRecordList>(\\\""AllManufacturers\\\"")\\n\\t\\t\\t    .FirstOrDefault(m => m[\\\""id\\\""].Equals(id))?[\\\""name\\\""];\\n\\t\\t}\\n\\t\\tcatch(Exception ex){\\n\\t\\t\\treturn \\\""Error: \\\"" + ex.Message;\\n\\t\\t}\\n\\t}\\n}\\n\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 2568a2a0-d330-4b01-934e-3bebab8c5f06 >>
                    {
                        var id = new Guid("2568a2a0-d330-4b01-934e-3bebab8c5f06");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": """",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-eye"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""1\"",\""string\"":\""using System;\\nusing System.Collections.Generic;\\nusing WebVella.Erp.Web.Models;\\nusing WebVella.Erp.Api.Models;\\nusing Newtonsoft.Json;\\n\\npublic class ViewDetailCodeVariable : ICodeVariable\\n{\\n\\tpublic object Evaluate(BaseErpPageModel pageModel)\\n\\t{\\n\\t    var datasource = pageModel?.TryGetDataSourceProperty<Guid>(\\\""RowRecord.id\\\"");\\n\\t    if(datasource == null)\\n\\t        return null;\\n\\t    return $\\\""/master-data/articles/articles/{datasource}\\\"";\\n\\t}\\n}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-dataportal-import  id: cdd4ccad-f658-4f11-97b9-691962d9be41 >>
                    {
                        var id = new Guid("cdd4ccad-f658-4f11-97b9-691962d9be41");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("d1635d81-b92f-4f93-a2b5-01cb05d79ca7");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""importEplanArticleForm"",
  ""name"": ""importEplanArticleForm"",
  ""hook_key"": ""eplan_import"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-dataportal-import  id: d8f95f49-0019-4be5-9534-5665f581b370 >>
                    {
                        var id = new Guid("d8f95f49-0019-4be5-9534-5665f581b370");
                        Guid? parentId = new Guid("cdd4ccad-f658-4f11-97b9-691962d9be41");
                        Guid? nodeId = null;
                        var pageId = new Guid("d1635d81-b92f-4f93-a2b5-01cb05d79ca7");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "body";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-dataportal-import  id: 9e1b09a4-f779-4be7-b0d8-2ab9285fa03e >>
                    {
                        var id = new Guid("9e1b09a4-f779-4be7-b0d8-2ab9285fa03e");
                        Guid? parentId = new Guid("cdd4ccad-f658-4f11-97b9-691962d9be41");
                        Guid? nodeId = null;
                        var pageId = new Guid("d1635d81-b92f-4f93-a2b5-01cb05d79ca7");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-dataportal-import  id: 912111f3-009f-4cc2-8d9f-5f56b1122d46 >>
                    {
                        var id = new Guid("912111f3-009f-4cc2-8d9f-5f56b1122d46");
                        Guid? parentId = new Guid("cdd4ccad-f658-4f11-97b9-691962d9be41");
                        Guid? nodeId = null;
                        var pageId = new Guid("d1635d81-b92f-4f93-a2b5-01cb05d79ca7");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "body";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Import Article"",
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
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""importEplanArticleForm""
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: c88bd56a-371e-4715-8fcc-9a6b3eb0ca03 >>
                    {
                        var id = new Guid("c88bd56a-371e-4715-8fcc-9a6b3eb0ca03");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: eff05faa-c99e-4d84-98c8-420b76cbee43 >>
                    {
                        var id = new Guid("eff05faa-c99e-4d84-98c8-420b76cbee43");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 5,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllManufacturers\"",\""default\"":\""\""}"",
  ""page_size"": 10,
  ""name"": ""manufacturer_grid"",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""true"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""false"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No manufacturers"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""container1_label"": """",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""false"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": ""Preview"",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Short Name"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Name"",
  ""container4_width"": """",
  ""container4_name"": """",
  ""container4_nowrap"": ""false"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Website"",
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

                    #region << ***Create page body node*** Page name: all  id: 6a4a3f3b-6c5c-4687-b812-4e254b01beba >>
                    {
                        var id = new Guid("6a4a3f3b-6c5c-4687-b812-4e254b01beba");
                        Guid? parentId = new Guid("eff05faa-c99e-4d84-98c8-420b76cbee43");
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.short_name\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 69ef702c-bef0-465f-a2e0-16e9eca92ebe >>
                    {
                        var id = new Guid("69ef702c-bef0-465f-a2e0-16e9eca92ebe");
                        Guid? parentId = new Guid("eff05faa-c99e-4d84-98c8-420b76cbee43");
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column4";
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

                    #region << ***Create page body node*** Page name: all  id: 8ba33810-b505-40da-8c40-35c9a6ad84ad >>
                    {
                        var id = new Guid("8ba33810-b505-40da-8c40-35c9a6ad84ad");
                        Guid? parentId = new Guid("eff05faa-c99e-4d84-98c8-420b76cbee43");
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": """",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fa fa-eye"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""1\"",\""string\"":\""using System;\\nusing System.Collections.Generic;\\nusing WebVella.Erp.Web.Models;\\nusing WebVella.Erp.Api.Models;\\nusing Newtonsoft.Json;\\n\\npublic class ViewDetailCodeVariable : ICodeVariable\\n{\\n\\tpublic object Evaluate(BaseErpPageModel pageModel)\\n\\t{\\n\\t    var datasource = pageModel?.TryGetDataSourceProperty<Guid>(\\\""RowRecord.id\\\"");\\n\\t    if(datasource == null)\\n\\t        return null;\\n\\t    return $\\\""/master-data/articles/articles/{datasource}\\\"";\\n\\t}\\n}\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 9322934a-91ab-4624-8362-b3d1b948b442 >>
                    {
                        var id = new Guid("9322934a-91ab-4624-8362-b3d1b948b442");
                        Guid? parentId = new Guid("eff05faa-c99e-4d84-98c8-420b76cbee43");
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""1\"",\""string\"":\""using System;\\nusing System.Collections.Generic;\\nusing WebVella.Erp.Web.Models;\\nusing WebVella.Erp.Api.Models;\\nusing Newtonsoft.Json;\\n\\npublic class GetDatasourceValueCodeVariable : ICodeVariable\\n{\\n\\tpublic object Evaluate(BaseErpPageModel pageModel)\\n\\t{\\n        try\\n        {\\n    \\t\\tvar url = pageModel.TryGetDataSourceProperty<EntityRecord>(\\\""RowRecord\\\"")?[\\\""logo\\\""];\\n    \\t\\treturn $\\\""<img src=\\\\\\\""{url}\\\\\\\"" height=\\\\\\\""50\\\\\\\""/>\\\"";\\n        }\\n        catch (Exception ex)\\n        {\\n            return \\\""Error: \\\"" + ex.Message;\\n        }\\n\\t}\\n}\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 01b9d859-24d1-4819-84eb-0264f8257528 >>
                    {
                        var id = new Guid("01b9d859-24d1-4819-84eb-0264f8257528");
                        Guid? parentId = new Guid("eff05faa-c99e-4d84-98c8-420b76cbee43");
                        Guid? nodeId = null;
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column5";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""1\"",\""string\"":\""using System;\\nusing System.Collections.Generic;\\nusing WebVella.Erp.Web.Models;\\nusing WebVella.Erp.Api.Models;\\nusing Newtonsoft.Json;\\n\\npublic class WebsiteCodeVariable : ICodeVariable\\n{\\n\\tpublic object Evaluate(BaseErpPageModel pageModel)\\n\\t{\\n        try\\n        {\\n    \\t\\tvar url = pageModel.TryGetDataSourceProperty<EntityRecord>(\\\""RowRecord\\\"")?[\\\""website\\\""]?.ToString();\\n    \\t\\tif(string.IsNullOrWhiteSpace(url))\\n    \\t\\t    return null;\\n    \\t\\treturn $\\\""<a href=\\\\\\\""{url}\\\\\\\"">{url}</a>\\\"";\\n        }\\n        catch (Exception ex)\\n        {\\n            return \\\""Error: \\\"" + ex.Message;\\n        }\\n\\t}\\n}\"",\""default\"":\""not set\""}"",
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

                    #region << ***Create data source*** Name: AllArticles >>
                    {
                        var id = new Guid("28b0a525-e227-4fe2-a073-bcd8300a1b37");
                        var name = @"AllArticles";
                        var description = @"records of all articles";
                        var eqlText = @"SELECT *
FROM article
";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article.""id"" AS ""id"",
	 rec_article.""manufacturer_id"" AS ""manufacturer_id"",
	 rec_article.""order_number"" AS ""order_number"",
	 rec_article.""eplan_id"" AS ""eplan_id"",
	 rec_article.""article_type"" AS ""article_type"",
	 rec_article.""preview"" AS ""preview"",
	 rec_article.""price"" AS ""price"",
	 rec_article.""description"" AS ""description"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_article
) X
";
                        var parametersJson = @"[{""name"":""sortBy"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""manufacturer_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":12,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""article_type"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""preview"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""price"",""type"":3,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""description"",""type"":10,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"article";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllManufacturers >>
                    {
                        var id = new Guid("4c537e23-2fe0-4da4-b14f-bb74327f744b");
                        var name = @"AllManufacturers";
                        var description = @"records of all manufacturers";
                        var eqlText = @"SELECT *
FROM manufacturer
";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_manufacturer.""id"" AS ""id"",
	 rec_manufacturer.""eplan_id"" AS ""eplan_id"",
	 rec_manufacturer.""logo"" AS ""logo"",
	 rec_manufacturer.""name"" AS ""name"",
	 rec_manufacturer.""short_name"" AS ""short_name"",
	 rec_manufacturer.""website"" AS ""website"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_manufacturer
) X
";
                        var parametersJson = @"[{""name"":""sortBy"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":12,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""logo"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""short_name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""website"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"manufacturer";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticles >>
                    {
                        var id = new Guid("12726284-3106-47ab-adb0-36b496d59a1f");
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var dataSourceId = new Guid("28b0a525-e227-4fe2-a073-bcd8300a1b37");
                        var name = @"AllArticles";
                        var parameters = @"[]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllManufacturers >>
                    {
                        var id = new Guid("76362b70-69a5-49f2-839d-1ad4dafc8ebf");
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var dataSourceId = new Guid("4c537e23-2fe0-4da4-b14f-bb74327f744b");
                        var name = @"AllManufacturers";
                        var parameters = @"[]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllManufacturers >>
                    {
                        var id = new Guid("5ca611ee-c7e9-4e9c-86bb-d7ae06f6abe4");
                        var pageId = new Guid("bcb677c3-6fcd-4242-80ef-e73adf39422c");
                        var dataSourceId = new Guid("4c537e23-2fe0-4da4-b14f-bb74327f744b");
                        var name = @"AllManufacturers";
                        var parameters = @"[]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion


                }
            }
        }
    }
}
