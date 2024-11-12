﻿using Newtonsoft.Json;
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
            //ProcessPatches();
        }

        private void ProcessPatches()
        {
            using (SecurityContext.OpenSystemScope())
            {
                var entMan = new EntityManager();
                var relMan = new EntityRelationManager();
                var recMan = new RecordManager();

#pragma warning disable
                // insert difference code within braces here here
                // don't forget to include entity "article_type"
                {
                    #region << ***Delete relation*** Relation name: task_type_1n_task >>
                    {
                        {
                            var response = relMan.Delete(new Guid("2925c7ea-72fe-4c12-a1f6-9baa9281141e"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: task_type_1n_task Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: task_status_1n_task >>
                    {
                        {
                            var response = relMan.Delete(new Guid("dcc6eb09-627b-4525-839f-d26dd57a0608"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: task_status_1n_task Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: milestone_nn_task >>
                    {
                        {
                            var response = relMan.Delete(new Guid("b070a627-01ce-4534-ab45-5c6f1a3867a4"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: milestone_nn_task Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: project_nn_task >>
                    {
                        {
                            var response = relMan.Delete(new Guid("b1db4466-7423-44e9-b6b9-3063222c9e15"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: project_nn_task Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: project_nn_milestone >>
                    {
                        {
                            var response = relMan.Delete(new Guid("55c8d6e2-f26d-4689-9d1b-a8c1b9de1672"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: project_nn_milestone Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: comment_nn_attachment >>
                    {
                        {
                            var response = relMan.Delete(new Guid("4b80a487-83ed-42e6-9be7-0ddf91afee15"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: comment_nn_attachment Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_1n_project_owner >>
                    {
                        {
                            var response = relMan.Delete(new Guid("2f0ff495-54a0-4343-a4e5-67f5ca552519"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_1n_project_owner Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_1n_task >>
                    {
                        {
                            var response = relMan.Delete(new Guid("a28ceeb8-10a8-4652-bf44-8dc2ad4350b7"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_1n_task Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_1n_task_creator >>
                    {
                        {
                            var response = relMan.Delete(new Guid("871bd069-8351-4e14-a064-96081ea3d811"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_1n_task_creator Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_1n_comment >>
                    {
                        {
                            var response = relMan.Delete(new Guid("6cd28549-5e99-4e05-9d12-c7b2ee104d02"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_1n_comment Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_1n_feed_item >>
                    {
                        {
                            var response = relMan.Delete(new Guid("df720595-dd35-484b-8b64-d21c2b57a687"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_1n_feed_item Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_1n_timelog >>
                    {
                        {
                            var response = relMan.Delete(new Guid("c4cb9a51-483b-4798-93b0-d73568c1bfc7"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_1n_timelog Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: user_nn_task_watchers >>
                    {
                        {
                            var response = relMan.Delete(new Guid("879b49cc-6af6-4b34-a554-761ec992534d"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: user_nn_task_watchers Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: account_nn_contact >>
                    {
                        {
                            var response = relMan.Delete(new Guid("dd211c99-5415-4195-923a-cb5a56e5d544"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: account_nn_contact Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: case_status_1n_case >>
                    {
                        {
                            var response = relMan.Delete(new Guid("4713f0fc-0154-4ce0-b804-0e92ed50bdec"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: case_status_1n_case Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: currency_1n_account >>
                    {
                        {
                            var response = relMan.Delete(new Guid("5e5c17df-2f50-4f88-82f1-d76cb7cd6156"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: currency_1n_account Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: case_type_1n_case >>
                    {
                        {
                            var response = relMan.Delete(new Guid("fbd6df76-345e-427a-a4af-fae553bc02c0"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: case_type_1n_case Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: account_nn_case >>
                    {
                        {
                            var response = relMan.Delete(new Guid("3690c12e-40e1-4e8f-a0a8-27221c686b43"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: account_nn_case Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: address_nn_account >>
                    {
                        {
                            var response = relMan.Delete(new Guid("dcf76eb5-16cf-466d-b760-c0d8ae57da94"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: address_nn_account Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: country_1n_address >>
                    {
                        {
                            var response = relMan.Delete(new Guid("f04f74bc-5525-4685-a72a-5b49e4b0f273"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: country_1n_address Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: country_1n_account >>
                    {
                        {
                            var response = relMan.Delete(new Guid("66661380-49f8-4a50-b0d9-4d2a8d2f0990"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: country_1n_account Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: language_1n_account >>
                    {
                        {
                            var response = relMan.Delete(new Guid("6e7f99d8-712c-451d-80fc-3a5fba4580f4"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: language_1n_account Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: country_1n_contact >>
                    {
                        {
                            var response = relMan.Delete(new Guid("dc4ece26-fff7-440a-9e19-76189507b5b9"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: country_1n_contact Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: salutation_1n_account >>
                    {
                        {
                            var response = relMan.Delete(new Guid("99e1a18b-05c2-4fca-986e-37ecebd62168"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: salutation_1n_account Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete relation*** Relation name: salutation_1n_contact >>
                    {
                        {
                            var response = relMan.Delete(new Guid("77ca10ff-18c9-44d6-a7ae-ddb0baa6a3a9"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Relation: salutation_1n_contact Delete. Message:" + response.Message);
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

                    #region << ***Create entity*** Entity name: article_stock >>
                    {
                        #region << entity >>
                        {
                            var entity = new InputEntity();
                            var systemFieldIdDictionary = new Dictionary<string, Guid>();
                            systemFieldIdDictionary["id"] = new Guid("9d239e96-711a-4257-a017-2b7936de6cda");
                            entity.Id = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                            entity.Name = "article_stock";
                            entity.Label = "Article Stock";
                            entity.LabelPlural = "Article Stocks";
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
                            entity.RecordPermissions.CanRead.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            entity.RecordPermissions.CanRead.Add(new Guid("f16ec6db-626d-4c27-8de0-3e7ce542c55f"));
                            //UPDATE
                            entity.RecordPermissions.CanUpdate.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            //DELETE
                            entity.RecordPermissions.CanDelete.Add(new Guid("bdc56420-caf0-4030-8a0e-d264938e0cda"));
                            {
                                var response = entMan.CreateEntity(entity, systemFieldIdDictionary);
                                if (!response.Success)
                                    throw new Exception("System error 10050. Entity: article_stock creation Message: " + response.Message);
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region << ***Create field***  Entity: article_stock Field Name: article_id >>
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
                                throw new Exception("System error 10060. Entity: article_stock Field: article_id Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Create field***  Entity: article_stock Field Name: warehouse_location_id >>
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
                                throw new Exception("System error 10060. Entity: article_stock Field: warehouse_location_id Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Create field***  Entity: article_stock Field Name: project_id >>
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
                                throw new Exception("System error 10060. Entity: article_stock Field: project_id Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Create field***  Entity: article_stock Field Name: amount >>
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
                        numberField.DefaultValue = Decimal.Parse("0.0");
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
                                throw new Exception("System error 10060. Entity: article_stock Field: amount Message:" + response.Message);
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

                    #region << ***Delete entity*** Entity Name: user_file >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("5c666c54-9e76-4327-ac7a-55851037810c"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: user_file Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: task >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("9386226e-381e-4522-b27b-fb5514d77902"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: task Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: address >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("34a126ba-1dee-4099-a1c1-a24e70eb10f0"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: address Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: account >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("2e22b50f-e444-4b62-a171-076e51246939"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: account Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: attachment >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("4b56686e-971e-4b8e-8356-642a8f341bff"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: attachment Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: currency >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("4d049df9-10eb-48a3-91b8-ee4106df9721"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: currency Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: timelog >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("750153c5-1df9-408f-b856-727078a525bc"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: timelog Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: comment >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("b1d218d5-68c2-41a5-bea5-1b4a78cbf91d"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: comment Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: contact >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("39e1dd9b-827f-464d-95ea-507ade81cbd0"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: contact Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: feed_item >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("db83b9b0-448c-4675-be71-640aca2e2a3a"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: feed_item Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: salutation >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("690dc799-e732-4d17-80d8-0f761bc33def"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: salutation Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: task_type >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("35999e55-821c-4798-8e8f-29d8c672c9b9"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: task_type Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: case >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("0ebb3981-7443-45c8-ab38-db0709daf58c"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: case Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: case_status >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("960afdc1-cd78-41ab-8135-816f7f7b8a27"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: case_status Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: milestone >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("c15f030a-9d94-4767-89aa-c55a09f8b83e"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: milestone Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: task_status >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("9221f095-f749-4b88-94e5-9fa485527ef7"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: task_status Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: case_type >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("0dfeba58-40bb-4205-a539-c16d5c0885ad"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: case_type Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: industry >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("2c60e662-367e-475d-9fcb-3ead55178a56"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: industry Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: project >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("2d9b2d1d-e32b-45e1-a013-91d92a9ce792"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: project Delete. Message:" + response.Message);
                        }
                    }
                    #endregion

                    #region << ***Delete entity*** Entity Name: country >>
                    {
                        {
                            var response = entMan.DeleteEntity(new Guid("54cfe9e9-5e0e-44d2-a1f9-5c3bbb9822c8"));
                            if (!response.Success)
                                throw new Exception("System error 10060. Entity: country Delete. Message:" + response.Message);
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

                    #region << ***Create sitemap area*** Sitemap area name: warehouses >>
                    {
                        var id = new Guid("3ee7e1d2-145c-4c92-ad9b-43f20e85e33a");
                        var appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "warehouses";
                        var label = "Warehouses";
                        var description = @"";
                        var iconClass = "fas fa-warehouse";
                        var color = "";
                        var weight = 3;
                        var showGroupNames = false;
                        var access = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();
                        var descriptionTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateArea(id, appId, name, label, labelTranslations, description, descriptionTranslations, iconClass, color, weight, showGroupNames, access, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create sitemap area*** Sitemap area name: projects >>
                    {
                        var id = new Guid("46e44503-2b2b-4389-929c-6f876cac2889");
                        var appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "projects";
                        var label = "Projects";
                        var description = @"";
                        var iconClass = "fab fa-product-hunt";
                        var color = "";
                        var weight = 4;
                        var showGroupNames = false;
                        var access = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();
                        var descriptionTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateArea(id, appId, name, label, labelTranslations, description, descriptionTranslations, iconClass, color, weight, showGroupNames, access, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create sitemap area*** Sitemap area name: stock >>
                    {
                        var id = new Guid("28ac10d4-efd5-48b6-9715-e91b20b7abe9");
                        var appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        var name = "stock";
                        var label = "Stock";
                        var description = @"";
                        var iconClass = "fas fa-boxes";
                        var color = "";
                        var weight = 5;
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

                    #region << ***Create sitemap node*** Sitemap node name: types >>
                    {
                        var id = new Guid("5251456d-5241-405d-9cea-be1bebcc83fa");
                        Guid? parentId = null;
                        var areaId = new Guid("544fdb00-d71c-439f-9e14-52bdad7d478f");
                        Guid? entityId = new Guid("2a705a5c-901f-4530-b991-4c9b7ca32a37");
                        var name = "types";
                        var label = "Types";
                        var url = "";
                        var iconClass = "fas fa-barcode";
                        var weight = 2;
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

                    #region << ***Create sitemap node*** Sitemap node name: warehouses >>
                    {
                        var id = new Guid("900ba280-d1cd-41ce-90a5-3c862004f677");
                        Guid? parentId = null;
                        var areaId = new Guid("3ee7e1d2-145c-4c92-ad9b-43f20e85e33a");
                        Guid? entityId = new Guid("2b05eb55-dead-4099-8a6b-5c2527104389");
                        var name = "warehouses";
                        var label = "Warehouses";
                        var url = "";
                        var iconClass = "fas fa-warehouse";
                        var weight = 1;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        entityListPages.Add(new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7"));
                        var entityCreatePages = new List<Guid>();
                        var entityDetailsPages = new List<Guid>();
                        var entityManagePages = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
                    }
                    #endregion

                    #region << ***Create sitemap node*** Sitemap node name: locations >>
                    {
                        var id = new Guid("1d51a717-c38a-4a26-b80a-4f0569224952");
                        Guid? parentId = null;
                        var areaId = new Guid("3ee7e1d2-145c-4c92-ad9b-43f20e85e33a");
                        Guid? entityId = new Guid("c0594745-9b28-40a1-9e57-a756734dca88");
                        var name = "locations";
                        var label = "Locations";
                        var url = "";
                        var iconClass = "fas fa-location-arrow";
                        var weight = 2;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        entityListPages.Add(new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32"));
                        var entityCreatePages = new List<Guid>();
                        var entityDetailsPages = new List<Guid>();
                        var entityManagePages = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
                    }
                    #endregion

                    #region << ***Create sitemap node*** Sitemap node name: projects >>
                    {
                        var id = new Guid("a3a7f957-3091-4232-8118-4e9a8d7e7010");
                        Guid? parentId = null;
                        var areaId = new Guid("46e44503-2b2b-4389-929c-6f876cac2889");
                        Guid? entityId = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
                        var name = "projects";
                        var label = "Projects";
                        var url = "";
                        var iconClass = "fab fa-product-hunt";
                        var weight = 1;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        entityListPages.Add(new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a"));
                        var entityCreatePages = new List<Guid>();
                        var entityDetailsPages = new List<Guid>();
                        var entityManagePages = new List<Guid>();
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.AppService().CreateAreaNode(id, areaId, name, label, labelTranslations, iconClass, url, type, entityId, weight, access, entityListPages, entityCreatePages, entityDetailsPages, entityManagePages, WebVella.Erp.Database.DbContext.Current.Transaction, parentId);
                    }
                    #endregion

                    #region << ***Create sitemap node*** Sitemap node name: stock >>
                    {
                        var id = new Guid("d61480af-1b5a-4ddb-af96-8fb457ed7f16");
                        Guid? parentId = null;
                        var areaId = new Guid("28ac10d4-efd5-48b6-9715-e91b20b7abe9");
                        Guid? entityId = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                        var name = "stock";
                        var label = "Stock";
                        var url = "";
                        var iconClass = "fas fa-boxes";
                        var weight = 1;
                        var type = ((int)1);
                        var access = new List<Guid>();
                        var entityListPages = new List<Guid>();
                        entityListPages.Add(new Guid("49939f02-8cd3-4165-bf64-290ab31d965a"));
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

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var name = @"all";
                        var label = "Warehouses";
                        var iconClass = "fas fa-warehouse";
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("2b05eb55-dead-4099-8a6b-5c2527104389");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var name = @"all";
                        var label = "Warehouse Locations";
                        var iconClass = "fas fa-location-arrow";
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("c0594745-9b28-40a1-9e57-a756734dca88");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var name = @"all";
                        var label = "Projects";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: create >>
                    {
                        var id = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
                        var name = @"create";
                        var label = "Create Project";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)4);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: manage >>
                    {
                        var id = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var name = @"manage";
                        var label = "Manage Project";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)6);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: detail >>
                    {
                        var id = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
                        var name = @"detail";
                        var label = "Project Detail";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)5);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("95eab1ff-a6a8-4634-bc82-62535d5c5f12");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: create >>
                    {
                        var id = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var name = @"create";
                        var label = "Place into Stock";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)4);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: all >>
                    {
                        var id = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var name = @"all";
                        var label = "Stock";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)3);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: detail >>
                    {
                        var id = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var name = @"detail";
                        var label = "Article Stock Detail";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)5);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: manage >>
                    {
                        var id = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var name = @"manage";
                        var label = "Manage Stock";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 10;
                        var type = (PageType)((int)6);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
                        Guid? nodeId = null;
                        Guid? areaId = null;
                        string razorBody = null;
                        var labelTranslations = new List<WebVella.Erp.Web.Models.TranslationResource>();

                        new WebVella.Erp.Web.Services.PageService().CreatePage(id, name, label, labelTranslations, iconClass, system, weight, type, appId, entityId, nodeId, areaId, isRazorBody, razorBody, layout, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page*** Page name: move >>
                    {
                        var id = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var name = @"move";
                        var label = "Move Article";
                        string iconClass = null;
                        var system = false;
                        var layout = @"";
                        var weight = 1001;
                        var type = (PageType)((int)6);
                        var isRazorBody = false;
                        Guid? appId = new Guid("5b6e48a9-edc6-4fd2-8037-46293e6ddeec");
                        Guid? entityId = new Guid("ab790595-caed-4773-a57f-b022d23a4fc9");
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
                        var label = "Data Portal Import";
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

                    #region << ***Create page*** Page name: import >>
                    {
                        var id = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var name = @"import";
                        var label = "Data Portal Import";
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

                    #region << ***Create page*** Page name: eplan-import >>
                    {
                        var id = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var name = @"eplan-import";
                        var label = "Eplan import";
                        var iconClass = "fas fa-glass-martini";
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
  ""container3_span"": 12,
  ""container3_span_sm"": 4,
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
  ""text"": ""Data Portal"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 mb-2"",
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
  ""size"": ""1"",
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
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.CreateUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
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
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 5;

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
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 8a64933a-43c5-4093-9cf6-c0f643b7cbc9 >>
                    {
                        var id = new Guid("8a64933a-43c5-4093-9cf6-c0f643b7cbc9");
                        Guid? parentId = new Guid("1461f5a7-21a6-4569-a62a-c891351007d5");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Order Number"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.order_number\"",\""default\"":\""\""}"",
  ""name"": ""order number"",
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 08eb3aad-d355-4081-80be-20ec5b0313ff >>
                    {
                        var id = new Guid("08eb3aad-d355-4081-80be-20ec5b0313ff");
                        Guid? parentId = new Guid("1461f5a7-21a6-4569-a62a-c891351007d5");
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: cb9684c7-0ad7-492d-803d-f384e60dab94 >>
                    {
                        var id = new Guid("cb9684c7-0ad7-492d-803d-f384e60dab94");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 6aedcb5e-bba0-4cd1-9fcb-66423756cf26 >>
                    {
                        var id = new Guid("6aedcb5e-bba0-4cd1-9fcb-66423756cf26");
                        Guid? parentId = new Guid("cb9684c7-0ad7-492d-803d-f384e60dab94");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
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

                    #region << ***Create page body node*** Page name: detail  id: 3b2d1016-545d-4853-8164-92622b90bac6 >>
                    {
                        var id = new Guid("3b2d1016-545d-4853-8164-92622b90bac6");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 7cd5d793-ccf3-48ed-ba9a-910715a48500 >>
                    {
                        var id = new Guid("7cd5d793-ccf3-48ed-ba9a-910715a48500");
                        Guid? parentId = new Guid("3b2d1016-545d-4853-8164-92622b90bac6");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 0,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 7e6d9d23-37d6-40b6-93a1-ecbd40640ecf >>
                    {
                        var id = new Guid("7e6d9d23-37d6-40b6-93a1-ecbd40640ecf");
                        Guid? parentId = new Guid("7cd5d793-ccf3-48ed-ba9a-910715a48500");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column1";
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
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ManageUrlSnippet\"",\""default\"":\""\""}"",
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
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: detail  id: 9651e0e3-9b70-4051-bea6-523678a5b1fa >>
                    {
                        var id = new Guid("9651e0e3-9b70-4051-bea6-523678a5b1fa");
                        Guid? parentId = new Guid("7e6d9d23-37d6-40b6-93a1-ecbd40640ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Data Portal"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""ml-0 w-100 mt-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt icon"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.TrueIfHasEplanIdSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleEplanDetailUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
                        var weight = 2;

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
  ""visible_columns"": 3,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 4,
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
  ""container2_span_md"": 0,
  ""container2_span_lg"": 4,
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
  ""container3_span_lg"": 4,
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
                        var containerId = "column3";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""1"",
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
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Data Portal"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 mb-2 text-nowrap"",
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

                    #region << ***Create page body node*** Page name: all  id: 8e8c1555-e3fa-4e9c-bc6d-36109f9b8027 >>
                    {
                        var id = new Guid("8e8c1555-e3fa-4e9c-bc6d-36109f9b8027");
                        Guid? parentId = new Guid("950794a4-35cc-4fd5-9ec6-62d6550d22a8");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Eplan"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-file-code"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""/master-data/a/eplan-import"",
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
                        var containerId = "column3";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.CreateUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: a97501be-853d-4ac1-811d-a80135705e9c >>
                    {
                        var id = new Guid("a97501be-853d-4ac1-811d-a80135705e9c");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 0b8f05ea-602a-47d4-80c4-70621c622332 >>
                    {
                        var id = new Guid("0b8f05ea-602a-47d4-80c4-70621c622332");
                        Guid? parentId = new Guid("a97501be-853d-4ac1-811d-a80135705e9c");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
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

                    #region << ***Create page body node*** Page name: manage  id: 8c654990-a479-4b24-afcb-b39ff9917510 >>
                    {
                        var id = new Guid("8c654990-a479-4b24-afcb-b39ff9917510");
                        Guid? parentId = new Guid("0b8f05ea-602a-47d4-80c4-70621c622332");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 3b0a581d-9049-40d6-aa07-f5068ddcec5f >>
                    {
                        var id = new Guid("3b0a581d-9049-40d6-aa07-f5068ddcec5f");
                        Guid? parentId = new Guid("0b8f05ea-602a-47d4-80c4-70621c622332");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""1"",
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 0d5a36a4-20c7-46f9-b6b8-cd497043c252 >>
                    {
                        var id = new Guid("0d5a36a4-20c7-46f9-b6b8-cd497043c252");
                        Guid? parentId = new Guid("b77a5f62-838b-4133-8480-fd89b0388fee");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: d7360326-6ceb-4eb9-8acf-88bf9c8bfccd >>
                    {
                        var id = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? parentId = new Guid("0d5a36a4-20c7-46f9-b6b8-cd497043c252");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column1";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": ""mt-5 flex-row-reverse"",
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
                        var containerId = "column1";
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

                    #region << ***Create page body node*** Page name: all  id: b9c5c9b6-3ff7-4da0-8ed1-b2c27a1de478 >>
                    {
                        var id = new Guid("b9c5c9b6-3ff7-4da0-8ed1-b2c27a1de478");
                        Guid? parentId = new Guid("851fc680-aba6-4bc2-a16b-bdb4891b2f1f");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""6"",
  ""size"": ""0"",
  ""class"": ""text-nowrap"",
  ""id"": """",
  ""icon_class"": ""far fa-trash-alt icon"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullAndHasIdSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-842ed44a-d921-416b-87bc-9d5a67796f77""
}";
                        var weight = 1;

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
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""float-right mb-5"",
  ""id"": """",
  ""icon_class"": ""fa fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee""
}";
                        var weight = 6;

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
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""float-right mb-5"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}"",
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
                        var containerId = "column1";
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
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

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
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 3,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllArticleTypes\"",\""default\"":\""\""}"",
  ""page_size"": 0,
  ""name"": ""article_grid"",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""true"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""/master-data/articles/types/l/all?hookKey=article_type_manage&hId="",
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
  ""container3_label"": ""Kind"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""true"",
  ""container3_sortable"": ""false"",
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

                    #region << ***Create page body node*** Page name: all  id: 7ef3b5ba-8252-471a-856f-26ba4ac2f9cc >>
                    {
                        var id = new Guid("7ef3b5ba-8252-471a-856f-26ba4ac2f9cc");
                        Guid? parentId = new Guid("b8291348-6f93-4dcd-b1bc-1f71ef213259");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types.ArticleTypeListNumberKindSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 68ca00da-2a4c-47f2-9591-5ba6c1f8d756 >>
                    {
                        var id = new Guid("68ca00da-2a4c-47f2-9591-5ba6c1f8d756");
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
  ""title"": ""List"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types.ArticleTypeCreateSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

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
                        var containerId = "column1";
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
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: bbf92c3b-9347-488c-aadc-f8f3a1d8a1d3 >>
                    {
                        var id = new Guid("bbf92c3b-9347-488c-aadc-f8f3a1d8a1d3");
                        Guid? parentId = new Guid("d7360326-6ceb-4eb9-8acf-88bf9c8bfccd");
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldCheckbox";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Types.ArticleTypeNumberKindVisibilitySnippet\"",\""default\"":\""\""}"",
  ""label_mode"": ""0"",
  ""label_text"": ""Is Integer"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.is_integer\"",\""default\"":\""\""}"",
  ""name"": ""is_integer"",
  ""class"": ""mb-5"",
  ""text_true"": ""Integer"",
  ""text_false"": ""Real"",
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

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 472f63be-a9b0-4ebf-8ac5-064fbb9a4fd0 >>
                    {
                        var id = new Guid("472f63be-a9b0-4ebf-8ac5-064fbb9a4fd0");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import-manufacturers  id: 0095678f-0baf-400f-9b67-188d739879f0 >>
                    {
                        var id = new Guid("0095678f-0baf-400f-9b67-188d739879f0");
                        Guid? parentId = new Guid("472f63be-a9b0-4ebf-8ac5-064fbb9a4fd0");
                        Guid? nodeId = null;
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column1";
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
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImageSnippet\"",\""default\"":\""\""}"",
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
  ""text"": ""Website"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListVisitButtonVisibilitySnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.website\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImportSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
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
  ""return_url"": ""/master-data/manufacturers/manufacturers/l/all""
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
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: all  id: 05dd3328-bfe8-4aa4-9fb7-1d68586e8401 >>
                    {
                        var id = new Guid("05dd3328-bfe8-4aa4-9fb7-1d68586e8401");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-05dd3328-bfe8-4aa4-9fb7-1d68586e8401"",
  ""name"": ""delete"",
  ""hook_key"": ""warehouse_location_delete"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 37c0bd72-cf77-47af-964e-70815fa339d9 >>
                    {
                        var id = new Guid("37c0bd72-cf77-47af-964e-70815fa339d9");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7f099bda-7323-4eb7-a604-b50bb577ede1 >>
                    {
                        var id = new Guid("7f099bda-7323-4eb7-a604-b50bb577ede1");
                        Guid? parentId = new Guid("37c0bd72-cf77-47af-964e-70815fa339d9");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 0,
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

                    #region << ***Create page body node*** Page name: all  id: 281c5bc0-8b8e-49c5-b267-989284b7c7d5 >>
                    {
                        var id = new Guid("281c5bc0-8b8e-49c5-b267-989284b7c7d5");
                        Guid? parentId = new Guid("7f099bda-7323-4eb7-a604-b50bb577ede1");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: all  id: ad79c4e8-131c-4c83-af81-403a25cddbf7 >>
                    {
                        var id = new Guid("ad79c4e8-131c-4c83-af81-403a25cddbf7");
                        Guid? parentId = new Guid("7f099bda-7323-4eb7-a604-b50bb577ede1");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Create"",
  ""color"": ""0"",
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.CreateUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

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
                        var weight = 2;

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

                    #region << ***Create page body node*** Page name: all  id: fca18019-44fa-4bfd-a0f7-ca9c060ac2fc >>
                    {
                        var id = new Guid("fca18019-44fa-4bfd-a0f7-ca9c060ac2fc");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
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
                        var weight = 6;

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
                        var weight = 5;

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
  ""query_type"": ""2"",
  ""query_options"": [
    ""2""
  ],
  ""prefix"": """"
}";
                        var weight = 4;

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
                        var weight = 7;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: d4e2cd6d-254b-4660-929c-a7115862bba4 >>
                    {
                        var id = new Guid("d4e2cd6d-254b-4660-929c-a7115862bba4");
                        Guid? parentId = new Guid("767cc292-29de-43b1-bada-5d9ca4d6ac72");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 842ed44a-d921-416b-87bc-9d5a67796f77 >>
                    {
                        var id = new Guid("842ed44a-d921-416b-87bc-9d5a67796f77");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f3d09045-f4a9-4492-a95a-b87d9483d398");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-842ed44a-d921-416b-87bc-9d5a67796f77"",
  ""name"": ""delete"",
  ""hook_key"": ""article_type_delete"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
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
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-3464bb03-9bf0-4ef8-be4d-18adf7217160"",
  ""name"": ""form"",
  ""hook_key"": ""manufacturer_update"",
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
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.short_name\"",\""default\"":\""\""}"",
  ""name"": ""short_name"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ReadOnlySnippet\"",\""default\"":\""\""}"",
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
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.name\"",\""default\"":\""\""}"",
  ""name"": ""name"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.FieldAccessByRecordIsFromEplanSnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 1;

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
  ""hook_key"": ""article_delete"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": ""mb-5"",
  ""show_validation"": ""true""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 21018045-e91c-4d85-b36b-97f9131e8c22 >>
                    {
                        var id = new Guid("21018045-e91c-4d85-b36b-97f9131e8c22");
                        Guid? parentId = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""<div class=\""mb-5\""/>"",
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

                    #region << ***Create page body node*** Page name: detail  id: e32f6215-2680-4604-bb35-49ae0edb1e43 >>
                    {
                        var id = new Guid("e32f6215-2680-4604-bb35-49ae0edb1e43");
                        Guid? parentId = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
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
                        var weight = 3;

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

                    #region << ***Create page body node*** Page name: detail  id: 4ebf4f07-45e8-48ce-b44a-3c849120576c >>
                    {
                        var id = new Guid("4ebf4f07-45e8-48ce-b44a-3c849120576c");
                        Guid? parentId = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleDetailImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: b105f123-1e66-4c16-820e-fcdf99d2b8fd >>
                    {
                        var id = new Guid("b105f123-1e66-4c16-820e-fcdf99d2b8fd");
                        Guid? parentId = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldTextarea";
                        var containerId = "body";
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
                        var weight = 6;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: aae5bee2-39cf-4f86-a323-2246290a227b >>
                    {
                        var id = new Guid("aae5bee2-39cf-4f86-a323-2246290a227b");
                        Guid? parentId = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Type Number"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.type_number\"",\""default\"":\""\""}"",
  ""name"": ""type_number"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 9012bcdd-d9f3-4f9b-a9c2-457b0cc7d7e2 >>
                    {
                        var id = new Guid("9012bcdd-d9f3-4f9b-a9c2-457b0cc7d7e2");
                        Guid? parentId = new Guid("419583e8-7069-4b33-b8b7-56b88199e74f");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Order Number"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.order_number\"",\""default\"":\""\""}"",
  ""name"": ""order_number"",
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
                        var weight = 5;

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

                    #region << ***Create page body node*** Page name: import  id: 45d2afc9-b7aa-41ee-9b9e-8fcdb508bd38 >>
                    {
                        var id = new Guid("45d2afc9-b7aa-41ee-9b9e-8fcdb508bd38");
                        Guid? parentId = new Guid("73c0e370-0564-443a-9055-d015f401b7ef");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": ""mt-5 mb-5"",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: import  id: dd83f0b6-1a89-4f1c-8ea7-78912c67129b >>
                    {
                        var id = new Guid("dd83f0b6-1a89-4f1c-8ea7-78912c67129b");
                        Guid? parentId = new Guid("45d2afc9-b7aa-41ee-9b9e-8fcdb508bd38");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column1";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
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
  ""container2_span"": 12,
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
  ""value"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
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
  ""label_text"": ""Part Number"",
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
                        Guid? parentId = new Guid("45d2afc9-b7aa-41ee-9b9e-8fcdb508bd38");
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Import Article"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""float-right"",
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
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerDetailVisitButtonVisibilitySnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""Record.website\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
                        var weight = 5;

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
                        var weight = 4;

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

                    #region << ***Create page body node*** Page name: create  id: e28df5ae-a3f0-4565-af53-86a60aaf6a81 >>
                    {
                        var id = new Guid("e28df5ae-a3f0-4565-af53-86a60aaf6a81");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("1147c601-2e63-40d7-8809-58c92080bf4c");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
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
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mt-2"",
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
                        var weight = 4;

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

                    #region << ***Create page body node*** Page name: manage  id: 4769b380-61c0-4cb3-9083-8b1537ee0bfe >>
                    {
                        var id = new Guid("4769b380-61c0-4cb3-9083-8b1537ee0bfe");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}""
}";
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
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

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
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerDetailImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: move  id: 02be62fa-3a42-4826-ab33-2b0558f4dfd9 >>
                    {
                        var id = new Guid("02be62fa-3a42-4826-ab33-2b0558f4dfd9");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: move  id: 719f176c-b85d-40e1-88e1-64de8ce07e6d >>
                    {
                        var id = new Guid("719f176c-b85d-40e1-88e1-64de8ce07e6d");
                        Guid? parentId = new Guid("02be62fa-3a42-4826-ab33-2b0558f4dfd9");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
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

                    #region << ***Create page body node*** Page name: move  id: e8ca48ef-2fd0-41ff-bbda-525804bed67b >>
                    {
                        var id = new Guid("e8ca48ef-2fd0-41ff-bbda-525804bed67b");
                        Guid? parentId = new Guid("719f176c-b85d-40e1-88e1-64de8ce07e6d");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: move  id: e122a73d-73a8-49ab-abfa-5a43df001e9a >>
                    {
                        var id = new Guid("e122a73d-73a8-49ab-abfa-5a43df001e9a");
                        Guid? parentId = new Guid("719f176c-b85d-40e1-88e1-64de8ce07e6d");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Move"",
  ""color"": ""1"",
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: create  id: cfcec2e5-b324-4752-9c9e-4f29020ea671 >>
                    {
                        var id = new Guid("cfcec2e5-b324-4752-9c9e-4f29020ea671");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("dc83fe78-7787-4156-9efa-741ee7f7ed1a");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 87ce7798-2036-4bc5-9b0f-2fa06ebdf3c4 >>
                    {
                        var id = new Guid("87ce7798-2036-4bc5-9b0f-2fa06ebdf3c4");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 6bb3c9fb-e8ad-49c6-a177-70a22b958d1c >>
                    {
                        var id = new Guid("6bb3c9fb-e8ad-49c6-a177-70a22b958d1c");
                        Guid? parentId = new Guid("87ce7798-2036-4bc5-9b0f-2fa06ebdf3c4");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleHasAlternativesSnippet\"",\""default\"":\""\""}"",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""2\"",\""string\"":\""<div class=\\\""form-group wv-field display wv-field-textarea\\\"">\\n    <label class=\\\""control-label label-stacked\\\"">Alternative Articles</label>\\n</div>\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: 4fa54222-54a7-4e62-adc6-0cf423b37ffe >>
                    {
                        var id = new Guid("4fa54222-54a7-4e62-adc6-0cf423b37ffe");
                        Guid? parentId = new Guid("87ce7798-2036-4bc5-9b0f-2fa06ebdf3c4");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleHasAlternativesSnippet\"",\""default\"":\""\""}"",
  ""id"": """",
  ""visible_columns"": 4,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""ArticleEquivalents\"",\""default\"":\""\""}"",
  ""page_size"": 0,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""false"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No Alternatives"",
  ""has_thead"": ""false"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""true"",
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
  ""container2_nowrap"": ""false"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""2"",
  ""container3_label"": ""Manufacturer"",
  ""container3_width"": """",
  ""container3_name"": """",
  ""container3_nowrap"": ""false"",
  ""container3_sortable"": ""false"",
  ""container3_class"": """",
  ""container3_vertical_align"": ""3"",
  ""container3_horizontal_align"": ""2"",
  ""container4_label"": ""Designation"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 5bfeaaeb-a28c-47e1-b1da-ed3b218a2bd3 >>
                    {
                        var id = new Guid("5bfeaaeb-a28c-47e1-b1da-ed3b218a2bd3");
                        Guid? parentId = new Guid("4fa54222-54a7-4e62-adc6-0cf423b37ffe");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
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

                    #region << ***Create page body node*** Page name: detail  id: 609b7306-4349-439d-8872-c746f24358c6 >>
                    {
                        var id = new Guid("609b7306-4349-439d-8872-c746f24358c6");
                        Guid? parentId = new Guid("4fa54222-54a7-4e62-adc6-0cf423b37ffe");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
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

                    #region << ***Create page body node*** Page name: detail  id: 29cdb932-0c42-4141-84e0-4c490c78a337 >>
                    {
                        var id = new Guid("29cdb932-0c42-4141-84e0-4c490c78a337");
                        Guid? parentId = new Guid("4fa54222-54a7-4e62-adc6-0cf423b37ffe");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column4";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
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

                    #region << ***Create page body node*** Page name: detail  id: 85572404-951f-4254-8766-d9330d8755c0 >>
                    {
                        var id = new Guid("85572404-951f-4254-8766-d9330d8755c0");
                        Guid? parentId = new Guid("4fa54222-54a7-4e62-adc6-0cf423b37ffe");
                        Guid? nodeId = null;
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleListImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: import  id: de518724-815f-4aff-ada7-b62f5832edb4 >>
                    {
                        var id = new Guid("de518724-815f-4aff-ada7-b62f5832edb4");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("948873bc-a2e5-40d7-9eca-dd089feabf8a");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""Articles"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""fas fa-glass-martini"",
  ""return_url"": ""/master-data/articles/articles/l/all""
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
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
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
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ManageUrlSnippet\"",\""default\"":\""\""}"",
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
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: manage  id: 89bd1283-aae3-4c47-b4f5-484f20bbd641 >>
                    {
                        var id = new Guid("89bd1283-aae3-4c47-b4f5-484f20bbd641");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f798ba25-e5b1-4f87-9eda-3d27c7f65900");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}""
}";
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}"",
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
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: manage  id: 52a93358-247f-4613-9034-366d1d1c7399 >>
                    {
                        var id = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-52a93358-247f-4613-9034-366d1d1c7399"",
  ""name"": ""form"",
  ""hook_key"": ""article_update"",
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
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.part_number\"",\""default\"":\""\""}"",
  ""name"": ""part_number"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ReadOnlySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
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
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 5;

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
                        var weight = 6;

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
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.FieldAccessByRecordIsFromEplanSnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: ea1611ca-d19f-4388-87c0-f896e3bdacf8 >>
                    {
                        var id = new Guid("ea1611ca-d19f-4388-87c0-f896e3bdacf8");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldMultiSelect";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Equivalent Articles"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""ArticleEquivalents\"",\""default\"":\""\""}"",
  ""name"": ""equivalents"",
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
                        var weight = 7;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 55e5f2dd-64e3-4ddb-a929-1ec9f26ad0ad >>
                    {
                        var id = new Guid("55e5f2dd-64e3-4ddb-a929-1ec9f26ad0ad");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
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
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.FieldAccessByRecordIsFromEplanSnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: c2045986-fbbc-4697-9a87-a6e366987ddc >>
                    {
                        var id = new Guid("c2045986-fbbc-4697-9a87-a6e366987ddc");
                        Guid? parentId = new Guid("52a93358-247f-4613-9034-366d1d1c7399");
                        Guid? nodeId = null;
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
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
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.FieldAccessByRecordIsFromEplanSnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": ""true"",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7b8329ac-32b2-4022-82d7-87803dd75d61 >>
                    {
                        var id = new Guid("7b8329ac-32b2-4022-82d7-87803dd75d61");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7cf13c63-eb64-4ccd-8245-af42dec8de3a >>
                    {
                        var id = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? parentId = new Guid("7b8329ac-32b2-4022-82d7-87803dd75d61");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 5,
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
  ""container4_nowrap"": ""true"",
  ""container4_sortable"": ""false"",
  ""container4_class"": """",
  ""container4_vertical_align"": ""3"",
  ""container4_horizontal_align"": ""2"",
  ""container5_label"": ""Data Portal"",
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
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListImageSnippet\"",\""default\"":\""no icon\""}"",
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
  ""text"": ""Website"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": """",
  ""id"": """",
  ""icon_class"": ""fas fa-external-link-alt"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Manufacturers.ManufacturerListVisitButtonVisibilitySnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.website\"",\""default\"":\""\""}"",
  ""new_tab"": ""true"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 6a6bff3a-f80a-40c7-951f-086e28be9982 >>
                    {
                        var id = new Guid("6a6bff3a-f80a-40c7-951f-086e28be9982");
                        Guid? parentId = new Guid("7cf13c63-eb64-4ccd-8245-af42dec8de3a");
                        Guid? nodeId = null;
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column5";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.ListCheckIfFromEplanSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: e507a721-a1b4-4de0-89a0-02c692592854 >>
                    {
                        var id = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""id"": ""wv-e507a721-a1b4-4de0-89a0-02c692592854"",
  ""name"": ""import"",
  ""hook_key"": ""article_file_import"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: 70cda21e-0fbc-489e-a1cd-1c1378c38ae3 >>
                    {
                        var id = new Guid("70cda21e-0fbc-489e-a1cd-1c1378c38ae3");
                        Guid? parentId = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RemoveParametersSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: 9618a6d1-9253-421d-bb00-25663ecdc0c1 >>
                    {
                        var id = new Guid("9618a6d1-9253-421d-bb00-25663ecdc0c1");
                        Guid? parentId = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "body";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Apply"",
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
  ""form"": ""wv-e507a721-a1b4-4de0-89a0-02c692592854""
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: 140c0846-0a18-4023-a935-46c3859a7ecf >>
                    {
                        var id = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? parentId = new Guid("e507a721-a1b4-4de0-89a0-02c692592854");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
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
  ""empty_text"": ""No records"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
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
  ""container4_width"": """",
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: c3775d3f-df22-4b52-8b46-464a3a8a4c94 >>
                    {
                        var id = new Guid("c3775d3f-df22-4b52-8b46-464a3a8a4c94");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column4";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.designation\"",\""default\"":\""\""}"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: d782a25e-8781-4514-8c3c-ea1a65089088 >>
                    {
                        var id = new Guid("d782a25e-8781-4514-8c3c-ea1a65089088");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.part_number\"",\""default\"":\""\""}"",
  ""name"": ""part_number"",
  ""class"": """",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ReadOnlySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: 3ffa8604-9160-4bd1-9da5-7a8923c66eb4 >>
                    {
                        var id = new Guid("3ffa8604-9160-4bd1-9da5-7a8923c66eb4");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column6";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.article_type\"",\""default\"":\""14a2d274-c18e-46f8-a920-2814ea5faa2d\""}"",
  ""name"": ""article_type"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""TypeSelectOptions\"",\""default\"":\""14a2d274-c18e-46f8-a920-2814ea5faa2d\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.ImportActionsFieldAccessibilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": ""true"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: 726c37fb-b438-4e36-bb80-f1bc9f465c66 >>
                    {
                        var id = new Guid("726c37fb-b438-4e36-bb80-f1bc9f465c66");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.type_number\"",\""default\"":\""\""}"",
  ""name"": ""type_number"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: 227736a5-a495-4316-a4f0-2daf270ad9e0 >>
                    {
                        var id = new Guid("227736a5-a495-4316-a4f0-2daf270ad9e0");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.order_number\"",\""default\"":\""\""}"",
  ""name"": ""order_number"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: 5eef8c68-e950-4f51-a90d-7b4d9ced7765 >>
                    {
                        var id = new Guid("5eef8c68-e950-4f51-a90d-7b4d9ced7765");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column5";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.ArticleImportStateSnippet\"",\""default\"":\""\""}"",
  ""name"": ""import_state"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: 35f26056-6bf1-471b-86ba-e46c704e7d24 >>
                    {
                        var id = new Guid("35f26056-6bf1-471b-86ba-e46c704e7d24");
                        Guid? parentId = new Guid("140c0846-0a18-4023-a935-46c3859a7ecf");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column7";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""3"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.action\"",\""default\"":\""\""}"",
  ""name"": ""action"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.available_actions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.ImportActionsFieldAccessibilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": ""true"",
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

                    #region << ***Create page body node*** Page name: manage  id: ac0a8c8f-e537-423f-af9f-e530e50136ce >>
                    {
                        var id = new Guid("ac0a8c8f-e537-423f-af9f-e530e50136ce");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockArticleImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 97cbaa15-e53e-44de-892e-56b0d16c199c >>
                    {
                        var id = new Guid("97cbaa15-e53e-44de-892e-56b0d16c199c");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: c3eaea33-9d92-4aa3-916e-5e1dbb74c4d8 >>
                    {
                        var id = new Guid("c3eaea33-9d92-4aa3-916e-5e1dbb74c4d8");
                        Guid? parentId = new Guid("97cbaa15-e53e-44de-892e-56b0d16c199c");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 2,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllProjects\"",\""default\"":\""\""}"",
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
  ""empty_text"": ""No projects"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""/master-data/projects/projects/r/"",
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: f5de14dd-6b31-481c-bdca-9f35676e3cbb >>
                    {
                        var id = new Guid("f5de14dd-6b31-481c-bdca-9f35676e3cbb");
                        Guid? parentId = new Guid("c3eaea33-9d92-4aa3-916e-5e1dbb74c4d8");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 339f7ce9-ad56-4145-b301-9cc8b77e01fb >>
                    {
                        var id = new Guid("339f7ce9-ad56-4145-b301-9cc8b77e01fb");
                        Guid? parentId = new Guid("c3eaea33-9d92-4aa3-916e-5e1dbb74c4d8");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
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

                    #region << ***Create page body node*** Page name: all  id: 7fd6e125-2f32-47a2-8738-cdc2cfbac6c8 >>
                    {
                        var id = new Guid("7fd6e125-2f32-47a2-8738-cdc2cfbac6c8");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
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

                    #region << ***Create page body node*** Page name: all  id: 8482f11d-49be-4579-8b6e-15ff674c5ef2 >>
                    {
                        var id = new Guid("8482f11d-49be-4579-8b6e-15ff674c5ef2");
                        Guid? parentId = new Guid("7fd6e125-2f32-47a2-8738-cdc2cfbac6c8");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
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

                    #region << ***Create page body node*** Page name: all  id: 39dd4bb3-8be1-475c-a68b-56e96899dba9 >>
                    {
                        var id = new Guid("39dd4bb3-8be1-475c-a68b-56e96899dba9");
                        Guid? parentId = new Guid("8482f11d-49be-4579-8b6e-15ff674c5ef2");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Name"",
  ""name"": ""name"",
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

                    #region << ***Create page body node*** Page name: all  id: fd2605eb-2cb8-4f95-9dcc-a2b03f57c8de >>
                    {
                        var id = new Guid("fd2605eb-2cb8-4f95-9dcc-a2b03f57c8de");
                        Guid? parentId = new Guid("8482f11d-49be-4579-8b6e-15ff674c5ef2");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Number"",
  ""name"": ""number"",
  ""try_connect_to_entity"": ""true"",
  ""field_type"": ""18"",
  ""query_type"": ""1"",
  ""query_options"": [
    ""1""
  ],
  ""prefix"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 9b97bcea-f2e3-4cc2-a313-95a094d90f47 >>
                    {
                        var id = new Guid("9b97bcea-f2e3-4cc2-a313-95a094d90f47");
                        Guid? parentId = new Guid("8482f11d-49be-4579-8b6e-15ff674c5ef2");
                        Guid? nodeId = null;
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
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

                    #region << ***Create page body node*** Page name: manage  id: 5b9a4ae6-30d1-4f95-b66f-358f2aaa224d >>
                    {
                        var id = new Guid("5b9a4ae6-30d1-4f95-b66f-358f2aaa224d");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.QueryDoesNotHaveAnyParametersSnippet\"",\""default\"":\""\""}"",
  ""id"": ""wv-52a93358-247f-4613-9034-366d1d1c7399"",
  ""name"": ""update_form"",
  ""hook_key"": ""article_stock_update"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 159d1987-aa2f-4fd8-8bf4-9fd70447e198 >>
                    {
                        var id = new Guid("159d1987-aa2f-4fd8-8bf4-9fd70447e198");
                        Guid? parentId = new Guid("5b9a4ae6-30d1-4f95-b66f-358f2aaa224d");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 23b85acb-844b-4710-8b6a-0882df11c628 >>
                    {
                        var id = new Guid("23b85acb-844b-4710-8b6a-0882df11c628");
                        Guid? parentId = new Guid("159d1987-aa2f-4fd8-8bf4-9fd70447e198");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column2";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 7,
  ""container1_span_sm"": 8,
  ""container1_span_md"": 9,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 5,
  ""container2_span_sm"": 4,
  ""container2_span_md"": 3,
  ""container2_span_lg"": 2,
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

                    #region << ***Create page body node*** Page name: manage  id: 297be011-84c0-4398-8c7b-5aebf4005b65 >>
                    {
                        var id = new Guid("297be011-84c0-4398-8c7b-5aebf4005b65");
                        Guid? parentId = new Guid("23b85acb-844b-4710-8b6a-0882df11c628");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Amount"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.amount\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
  ""class"": """",
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 19cd3c8e-7aa2-4559-ab42-e9991a47cb88 >>
                    {
                        var id = new Guid("19cd3c8e-7aa2-4559-ab42-e9991a47cb88");
                        Guid? parentId = new Guid("23b85acb-844b-4710-8b6a-0882df11c628");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": "" Unit"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailUnitSnippet\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": ""text-nowrap"",
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

                    #region << ***Create page body node*** Page name: manage  id: ebaaa89c-9c7d-4c06-971c-360d2beb28af >>
                    {
                        var id = new Guid("ebaaa89c-9c7d-4c06-971c-360d2beb28af");
                        Guid? parentId = new Guid("159d1987-aa2f-4fd8-8bf4-9fd70447e198");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Project"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailProjectSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: manage  id: 64cea742-8b57-45d0-b581-026d2c56c206 >>
                    {
                        var id = new Guid("64cea742-8b57-45d0-b581-026d2c56c206");
                        Guid? parentId = new Guid("5b9a4ae6-30d1-4f95-b66f-358f2aaa224d");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: bb900964-f2b7-40e6-9e68-9114b1b385db >>
                    {
                        var id = new Guid("bb900964-f2b7-40e6-9e68-9114b1b385db");
                        Guid? parentId = new Guid("64cea742-8b57-45d0-b581-026d2c56c206");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Article"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockArticleDesignationSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: manage  id: e706466f-b2d1-4eca-9e92-4498f9dd5bc8 >>
                    {
                        var id = new Guid("e706466f-b2d1-4eca-9e92-4498f9dd5bc8");
                        Guid? parentId = new Guid("64cea742-8b57-45d0-b581-026d2c56c206");
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Warehouse Location"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailLocationSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: manage  id: 5b3b6324-d438-4381-bb5d-cbbb8600477a >>
                    {
                        var id = new Guid("5b3b6324-d438-4381-bb5d-cbbb8600477a");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-5b3b6324-d438-4381-bb5d-cbbb8600477a"",
  ""name"": ""form"",
  ""hook_key"": ""project_update"",
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

                    #region << ***Create page body node*** Page name: manage  id: 200770da-5e53-4ebc-811e-086a06ba3a48 >>
                    {
                        var id = new Guid("200770da-5e53-4ebc-811e-086a06ba3a48");
                        Guid? parentId = new Guid("5b3b6324-d438-4381-bb5d-cbbb8600477a");
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
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

                    #region << ***Create page body node*** Page name: manage  id: 20931b25-7e83-478b-b1ec-344b2f69c26d >>
                    {
                        var id = new Guid("20931b25-7e83-478b-b1ec-344b2f69c26d");
                        Guid? parentId = new Guid("200770da-5e53-4ebc-811e-086a06ba3a48");
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
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

                    #region << ***Create page body node*** Page name: manage  id: c31f866c-1a03-4ff6-84e4-34d1084cdc58 >>
                    {
                        var id = new Guid("c31f866c-1a03-4ff6-84e4-34d1084cdc58");
                        Guid? parentId = new Guid("200770da-5e53-4ebc-811e-086a06ba3a48");
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Number"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.number\"",\""default\"":\""\""}"",
  ""name"": ""number"",
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

                    #region << ***Create page body node*** Page name: all  id: eb41ce14-610f-405e-a7c1-6fc7848331b6 >>
                    {
                        var id = new Guid("eb41ce14-610f-405e-a7c1-6fc7848331b6");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee"",
  ""name"": ""search"",
  ""hook_key"": """",
  ""method"": ""get"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: b24f4d05-a318-4b04-8582-44427e8a7767 >>
                    {
                        var id = new Guid("b24f4d05-a318-4b04-8582-44427e8a7767");
                        Guid? parentId = new Guid("eb41ce14-610f-405e-a7c1-6fc7848331b6");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
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

                    #region << ***Create page body node*** Page name: all  id: caf5b06b-ea78-4633-9dcc-dc535e6021cb >>
                    {
                        var id = new Guid("caf5b06b-ea78-4633-9dcc-dc535e6021cb");
                        Guid? parentId = new Guid("b24f4d05-a318-4b04-8582-44427e8a7767");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Warehouse"",
  ""name"": ""warehouse"",
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

                    #region << ***Create page body node*** Page name: all  id: a8218fd1-4dad-4508-b2e1-f0fbb262532e >>
                    {
                        var id = new Guid("a8218fd1-4dad-4508-b2e1-f0fbb262532e");
                        Guid? parentId = new Guid("b24f4d05-a318-4b04-8582-44427e8a7767");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 0c9751ca-d89a-4a36-999f-54bb7b5e364e >>
                    {
                        var id = new Guid("0c9751ca-d89a-4a36-999f-54bb7b5e364e");
                        Guid? parentId = new Guid("b24f4d05-a318-4b04-8582-44427e8a7767");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
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

                    #region << ***Create page body node*** Page name: create  id: 288ea378-3851-4559-8cd3-39b25cd15721 >>
                    {
                        var id = new Guid("288ea378-3851-4559-8cd3-39b25cd15721");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 78db2536-416a-440f-b767-19c764347a12 >>
                    {
                        var id = new Guid("78db2536-416a-440f-b767-19c764347a12");
                        Guid? parentId = new Guid("288ea378-3851-4559-8cd3-39b25cd15721");
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
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

                    #region << ***Create page body node*** Page name: create  id: 6c22d47e-8b18-4eb8-9671-7dbddbeba234 >>
                    {
                        var id = new Guid("6c22d47e-8b18-4eb8-9671-7dbddbeba234");
                        Guid? parentId = new Guid("78db2536-416a-440f-b767-19c764347a12");
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 51127472-b29e-430b-a9c9-7c6f8a192b59 >>
                    {
                        var id = new Guid("51127472-b29e-430b-a9c9-7c6f8a192b59");
                        Guid? parentId = new Guid("78db2536-416a-440f-b767-19c764347a12");
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
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

                    #region << ***Create page body node*** Page name: create  id: a7bfd1ef-9a3e-4aa8-98b6-54101aeb8870 >>
                    {
                        var id = new Guid("a7bfd1ef-9a3e-4aa8-98b6-54101aeb8870");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-1461f5a7-21a6-4569-a62a-c891351007d5"",
  ""name"": ""CreateRecord"",
  ""hook_key"": ""project_create"",
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

                    #region << ***Create page body node*** Page name: create  id: 3ca93284-14f0-4c44-8ab0-dc857ee512eb >>
                    {
                        var id = new Guid("3ca93284-14f0-4c44-8ab0-dc857ee512eb");
                        Guid? parentId = new Guid("a7bfd1ef-9a3e-4aa8-98b6-54101aeb8870");
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
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

                    #region << ***Create page body node*** Page name: create  id: 678c3555-d027-417b-b767-cc635019477f >>
                    {
                        var id = new Guid("678c3555-d027-417b-b767-cc635019477f");
                        Guid? parentId = new Guid("3ca93284-14f0-4c44-8ab0-dc857ee512eb");
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Number"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.number\"",\""default\"":\""\""}"",
  ""name"": ""number"",
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

                    #region << ***Create page body node*** Page name: create  id: 00b6c980-be6d-417b-a5fa-873723948b96 >>
                    {
                        var id = new Guid("00b6c980-be6d-417b-a5fa-873723948b96");
                        Guid? parentId = new Guid("3ca93284-14f0-4c44-8ab0-dc857ee512eb");
                        Guid? nodeId = null;
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
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

                    #region << ***Create page body node*** Page name: all  id: 2d962595-cb3a-4880-96a0-93067665158c >>
                    {
                        var id = new Guid("2d962595-cb3a-4880-96a0-93067665158c");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 5a6b92f3-20a3-4ee0-b851-dcce0443ce5b >>
                    {
                        var id = new Guid("5a6b92f3-20a3-4ee0-b851-dcce0443ce5b");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-5a6b92f3-20a3-4ee0-b851-dcce0443ce5b"",
  ""name"": ""udate"",
  ""hook_key"": ""warehouse_location_update"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: e3f894b7-fda6-42af-b3de-d09480b30f4d >>
                    {
                        var id = new Guid("e3f894b7-fda6-42af-b3de-d09480b30f4d");
                        Guid? parentId = new Guid("5a6b92f3-20a3-4ee0-b851-dcce0443ce5b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b >>
                    {
                        var id = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? parentId = new Guid("e3f894b7-fda6-42af-b3de-d09480b30f4d");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column1";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": ""mt-5 flex-row-reverse"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 0f6acb1a-be9a-4ebe-b8a3-e43d9011a703 >>
                    {
                        var id = new Guid("0f6acb1a-be9a-4ebe-b8a3-e43d9011a703");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": """",
  ""area_sublabel"": """",
  ""title"": ""List"",
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

                    #region << ***Create page body node*** Page name: all  id: 3cc56313-2cb3-4d31-98e2-85fb465105b0 >>
                    {
                        var id = new Guid("3cc56313-2cb3-4d31-98e2-85fb465105b0");
                        Guid? parentId = new Guid("0f6acb1a-be9a-4ebe-b8a3-e43d9011a703");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.Locations.WarehouseLocationCreateSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 4338f485-b97b-4882-8f3d-432801ca059d >>
                    {
                        var id = new Guid("4338f485-b97b-4882-8f3d-432801ca059d");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
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
  ""detail_path"": ""/master-data/warehouses/locations/l/all?hookKey=warehouse_location_manage&hId="",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 681891f1-6343-4169-b637-096b2f7e2113 >>
                    {
                        var id = new Guid("681891f1-6343-4169-b637-096b2f7e2113");
                        Guid? parentId = new Guid("4338f485-b97b-4882-8f3d-432801ca059d");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.designation\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 2991e500-7ffb-43c6-870f-178866e399cb >>
                    {
                        var id = new Guid("2991e500-7ffb-43c6-870f-178866e399cb");
                        Guid? parentId = new Guid("4338f485-b97b-4882-8f3d-432801ca059d");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$warehouse[0].designation\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 362d5de7-25d2-4f08-ae1e-4d62ca09d71d >>
                    {
                        var id = new Guid("362d5de7-25d2-4f08-ae1e-4d62ca09d71d");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "column1";
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

                    #region << ***Create page body node*** Page name: all  id: c1758536-75e2-4356-b506-ff7e3f3213a4 >>
                    {
                        var id = new Guid("c1758536-75e2-4356-b506-ff7e3f3213a4");
                        Guid? parentId = new Guid("362d5de7-25d2-4f08-ae1e-4d62ca09d71d");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""6"",
  ""size"": ""1"",
  ""class"": ""text-nowrap"",
  ""id"": """",
  ""icon_class"": ""far fa-trash-alt icon"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullAndHasIdSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-05dd3328-bfe8-4aa4-9fb7-1d68586e8401""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: cb4ec129-952e-4b8c-a738-04514980ff6d >>
                    {
                        var id = new Guid("cb4ec129-952e-4b8c-a738-04514980ff6d");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Designation"",
  ""link"": """",
  ""mode"": ""1"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.designation\"",\""default\"":\""\""}"",
  ""name"": ""designation"",
  ""class"": ""mb-5"",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 53822cb1-f8ba-4286-98b9-55a7995249bd >>
                    {
                        var id = new Guid("53822cb1-f8ba-4286-98b9-55a7995249bd");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""float-right mb-5"",
  ""id"": """",
  ""icon_class"": ""fa fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-5a6b92f3-20a3-4ee0-b851-dcce0443ce5b""
}";
                        var weight = 5;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 6328e6eb-e2cf-4e59-adc2-2b4457ee717e >>
                    {
                        var id = new Guid("6328e6eb-e2cf-4e59-adc2-2b4457ee717e");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""1"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.warehouse_id\"",\""default\"":\""\""}"",
  ""name"": ""warehouse_id"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""WarehouseSelectOptions\"",\""default\"":\""\""}"",
  ""connected_entity_id"": ""c0594745-9b28-40a1-9e57-a756734dca88"",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": ""false"",
  ""ajax_api_url_ds"": """",
  ""ajax_datasource_api"": """",
  ""description"": """",
  ""label_help_text"": """",
  ""select_match_type"": ""0""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 0583e6a8-324c-4119-aa92-9c09dba5f796 >>
                    {
                        var id = new Guid("0583e6a8-324c-4119-aa92-9c09dba5f796");
                        Guid? parentId = new Guid("1ff647bc-0c7d-4e77-8be7-9dc02e4ca92b");
                        Guid? nodeId = null;
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""float-right mb-5"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RemoveParametersSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 134ca0b5-2d9d-4990-af8f-65aca03e74e1 >>
                    {
                        var id = new Guid("134ca0b5-2d9d-4990-af8f-65aca03e74e1");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee"",
  ""name"": ""update"",
  ""hook_key"": ""warehouse_update"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""true""
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 5243131d-8e86-4379-8728-0b98f04d4940 >>
                    {
                        var id = new Guid("5243131d-8e86-4379-8728-0b98f04d4940");
                        Guid? parentId = new Guid("134ca0b5-2d9d-4990-af8f-65aca03e74e1");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 0,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 8,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 1,
  ""container1_offset_xl"": 2,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: ee0e6996-589d-44f4-af4b-d0a381515428 >>
                    {
                        var id = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? parentId = new Guid("5243131d-8e86-4379-8728-0b98f04d4940");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column1";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": ""mt-5 flex-row-reverse"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 6519d798-b41c-4456-b051-755133b51111 >>
                    {
                        var id = new Guid("6519d798-b41c-4456-b051-755133b51111");
                        Guid? parentId = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Cancel"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""float-right mb-5"",
  ""id"": """",
  ""icon_class"": """",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 5;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 4fc03764-9149-4460-8fce-3dcd3051797a >>
                    {
                        var id = new Guid("4fc03764-9149-4460-8fce-3dcd3051797a");
                        Guid? parentId = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 1,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllWarehouses\"",\""default\"":\""\""}"",
  ""page_size"": 0,
  ""name"": """",
  ""prefix"": """",
  ""class"": """",
  ""striped"": ""true"",
  ""small"": ""true"",
  ""bordered"": ""false"",
  ""borderless"": ""false"",
  ""hover"": ""true"",
  ""responsive_breakpoint"": ""0"",
  ""empty_text"": ""No articles"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""false"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""/master-data/warehouses/warehouses/l/all?hookKey=warehouse_manage&hId="",
  ""container1_label"": """",
  ""container1_width"": """",
  ""container1_name"": """",
  ""container1_nowrap"": ""true"",
  ""container1_sortable"": ""false"",
  ""container1_class"": """",
  ""container1_vertical_align"": ""3"",
  ""container1_horizontal_align"": ""2"",
  ""container2_label"": """",
  ""container2_width"": """",
  ""container2_name"": """",
  ""container2_nowrap"": ""true"",
  ""container2_sortable"": ""false"",
  ""container2_class"": """",
  ""container2_vertical_align"": ""3"",
  ""container2_horizontal_align"": ""4"",
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

                    #region << ***Create page body node*** Page name: all  id: 5aeae488-528b-4f2a-bed1-794d193998eb >>
                    {
                        var id = new Guid("5aeae488-528b-4f2a-bed1-794d193998eb");
                        Guid? parentId = new Guid("4fc03764-9149-4460-8fce-3dcd3051797a");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.designation\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 43bcb356-1ef8-4fa6-8efc-60506c784920 >>
                    {
                        var id = new Guid("43bcb356-1ef8-4fa6-8efc-60506c784920");
                        Guid? parentId = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": """",
  ""area_sublabel"": """",
  ""title"": ""List"",
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

                    #region << ***Create page body node*** Page name: all  id: a08cbced-12e5-478c-9d16-224ce18e5755 >>
                    {
                        var id = new Guid("a08cbced-12e5-478c-9d16-224ce18e5755");
                        Guid? parentId = new Guid("43bcb356-1ef8-4fa6-8efc-60506c784920");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.WarehouseCreateSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 3e25b2bb-6a37-4b2c-bc9e-bf35f62aa59b >>
                    {
                        var id = new Guid("3e25b2bb-6a37-4b2c-bc9e-bf35f62aa59b");
                        Guid? parentId = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "column1";
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

                    #region << ***Create page body node*** Page name: all  id: e21da775-ffc0-4a94-9a88-5770235f8207 >>
                    {
                        var id = new Guid("e21da775-ffc0-4a94-9a88-5770235f8207");
                        Guid? parentId = new Guid("3e25b2bb-6a37-4b2c-bc9e-bf35f62aa59b");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "actions";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""6"",
  ""size"": ""1"",
  ""class"": ""text-nowrap"",
  ""id"": """",
  ""icon_class"": ""far fa-trash-alt icon"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullAndHasIdSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-7ec33c70-4900-4a65-be67-c5eff5c40e1a""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: f84cb937-c2a6-4626-a4dc-ac6fb0ec5f62 >>
                    {
                        var id = new Guid("f84cb937-c2a6-4626-a4dc-ac6fb0ec5f62");
                        Guid? parentId = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Designation"",
  ""link"": """",
  ""mode"": ""1"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.designation\"",\""default\"":\""\""}"",
  ""name"": ""designation"",
  ""class"": ""mb-5"",
  ""maxlength"": 0,
  ""placeholder"": """",
  ""connected_entity_id"": """",
  ""connected_record_id_ds"": """",
  ""access_override_ds"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.FieldAccessByRecordNullabilitySnippet\"",\""default\"":\""\""}"",
  ""required_override_ds"": """",
  ""ajax_api_url_ds"": """",
  ""description"": """",
  ""label_help_text"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 17293e8e-b443-4b50-9999-6d13fd68d1e6 >>
                    {
                        var id = new Guid("17293e8e-b443-4b50-9999-6d13fd68d1e6");
                        Guid? parentId = new Guid("ee0e6996-589d-44f4-af4b-d0a381515428");
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""3"",
  ""class"": ""float-right mb-5"",
  ""id"": """",
  ""icon_class"": ""fa fa-save"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNotNullSnippet\"",\""default\"":\""\""}"",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-b77a5f62-838b-4133-8480-fd89b0388fee""
}";
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7ec33c70-4900-4a65-be67-c5eff5c40e1a >>
                    {
                        var id = new Guid("7ec33c70-4900-4a65-be67-c5eff5c40e1a");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-7ec33c70-4900-4a65-be67-c5eff5c40e1a"",
  ""name"": ""delete"",
  ""hook_key"": ""warehouse_delete"",
  ""method"": ""post"",
  ""label_mode"": ""1"",
  ""mode"": ""1"",
  ""class"": """",
  ""show_validation"": ""false""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: ab541bec-6357-49e8-a983-6cb422090076 >>
                    {
                        var id = new Guid("ab541bec-6357-49e8-a983-6cb422090076");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 0cb50cde-1150-408f-9cbf-58aea1c08fbd >>
                    {
                        var id = new Guid("0cb50cde-1150-408f-9cbf-58aea1c08fbd");
                        Guid? parentId = new Guid("ab541bec-6357-49e8-a983-6cb422090076");
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
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

                    #region << ***Create page body node*** Page name: manage  id: ffc1f166-ce61-4818-9071-f2545327fbbe >>
                    {
                        var id = new Guid("ffc1f166-ce61-4818-9071-f2545327fbbe");
                        Guid? parentId = new Guid("0cb50cde-1150-408f-9cbf-58aea1c08fbd");
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Save"",
  ""color"": ""1"",
  ""size"": ""1"",
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
  ""form"": ""wv-5b3b6324-d438-4381-bb5d-cbbb8600477a""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: c52ce884-40d4-4908-9e2e-11ecbde73399 >>
                    {
                        var id = new Guid("c52ce884-40d4-4908-9e2e-11ecbde73399");
                        Guid? parentId = new Guid("0cb50cde-1150-408f-9cbf-58aea1c08fbd");
                        Guid? nodeId = null;
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.DetailUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 5e31f430-5a41-45f2-98a3-c432f00a795d >>
                    {
                        var id = new Guid("5e31f430-5a41-45f2-98a3-c432f00a795d");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 919f19ba-19c1-43e7-b71f-9f3b99962000 >>
                    {
                        var id = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
                        Guid? parentId = new Guid("5e31f430-5a41-45f2-98a3-c432f00a795d");
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
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

                    #region << ***Create page body node*** Page name: detail  id: eaed20ab-2905-427c-bde1-ca39904044f3 >>
                    {
                        var id = new Guid("eaed20ab-2905-427c-bde1-ca39904044f3");
                        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ManageUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 888630c7-7b62-4b82-898d-78297751871e >>
                    {
                        var id = new Guid("888630c7-7b62-4b82-898d-78297751871e");
                        Guid? parentId = new Guid("919f19ba-19c1-43e7-b71f-9f3b99962000");
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""10"",
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: detail  id: 6000ea10-a46f-4864-bb40-8b48d875608e >>
                    {
                        var id = new Guid("6000ea10-a46f-4864-bb40-8b48d875608e");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: ff66bb5c-f7e8-430f-8695-8aca6d3de672 >>
                    {
                        var id = new Guid("ff66bb5c-f7e8-430f-8695-8aca6d3de672");
                        Guid? parentId = new Guid("6000ea10-a46f-4864-bb40-8b48d875608e");
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
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

                    #region << ***Create page body node*** Page name: detail  id: 2c394451-2eb7-4cff-bd93-d3517c1d8092 >>
                    {
                        var id = new Guid("2c394451-2eb7-4cff-bd93-d3517c1d8092");
                        Guid? parentId = new Guid("ff66bb5c-f7e8-430f-8695-8aca6d3de672");
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
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

                    #region << ***Create page body node*** Page name: detail  id: 7922218e-9780-4827-8a87-ffdbca2d1bb0 >>
                    {
                        var id = new Guid("7922218e-9780-4827-8a87-ffdbca2d1bb0");
                        Guid? parentId = new Guid("ff66bb5c-f7e8-430f-8695-8aca6d3de672");
                        Guid? nodeId = null;
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Number"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: move  id: 0dfcb0de-5be7-4036-9d77-4962e471334f >>
                    {
                        var id = new Guid("0dfcb0de-5be7-4036-9d77-4962e471334f");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.QueryDoesNotHaveAnyParametersSnippet\"",\""default\"":\""\""}"",
  ""id"": ""wv-52a93358-247f-4613-9034-366d1d1c7399"",
  ""name"": ""move_form"",
  ""hook_key"": ""article_stock_move"",
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

                    #region << ***Create page body node*** Page name: move  id: 81bedef2-2a9f-4f9a-b5da-8b69e1a35ee3 >>
                    {
                        var id = new Guid("81bedef2-2a9f-4f9a-b5da-8b69e1a35ee3");
                        Guid? parentId = new Guid("0dfcb0de-5be7-4036-9d77-4962e471334f");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockArticleImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: move  id: a2e10757-c984-4a9f-bc2d-4d8babf3b6c9 >>
                    {
                        var id = new Guid("a2e10757-c984-4a9f-bc2d-4d8babf3b6c9");
                        Guid? parentId = new Guid("0dfcb0de-5be7-4036-9d77-4962e471334f");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""<div class=\""mb-5\""/>"",
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

                    #region << ***Create page body node*** Page name: move  id: 46af2ee3-d8ba-4b88-a976-f24074d8ed80 >>
                    {
                        var id = new Guid("46af2ee3-d8ba-4b88-a976-f24074d8ed80");
                        Guid? parentId = new Guid("0dfcb0de-5be7-4036-9d77-4962e471334f");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: move  id: c295e060-2d90-4fa5-bdce-e097c8dae11b >>
                    {
                        var id = new Guid("c295e060-2d90-4fa5-bdce-e097c8dae11b");
                        Guid? parentId = new Guid("46af2ee3-d8ba-4b88-a976-f24074d8ed80");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Warehouse Location"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.warehouse_location_id\"",\""default\"":\""\""}"",
  ""name"": ""warehouse_location_id"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""WarehouseLocationSelectOptions\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: move  id: 0047e223-4819-4464-a049-98eaaa2d81e6 >>
                    {
                        var id = new Guid("0047e223-4819-4464-a049-98eaaa2d81e6");
                        Guid? parentId = new Guid("46af2ee3-d8ba-4b88-a976-f24074d8ed80");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Article"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockArticleDesignationSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: move  id: 94090178-5108-486e-b519-e97b0c33ecbb >>
                    {
                        var id = new Guid("94090178-5108-486e-b519-e97b0c33ecbb");
                        Guid? parentId = new Guid("0dfcb0de-5be7-4036-9d77-4962e471334f");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
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
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: move  id: b8f07a46-7d1c-4654-8efd-d5095ced0068 >>
                    {
                        var id = new Guid("b8f07a46-7d1c-4654-8efd-d5095ced0068");
                        Guid? parentId = new Guid("94090178-5108-486e-b519-e97b0c33ecbb");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Project"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.project_id\"",\""default\"":\""\""}"",
  ""name"": ""project_id"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ProjectSelectOptions\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: move  id: 21ebcaa5-2259-4b77-9ed5-f54303c073fc >>
                    {
                        var id = new Guid("21ebcaa5-2259-4b77-9ed5-f54303c073fc");
                        Guid? parentId = new Guid("94090178-5108-486e-b519-e97b0c33ecbb");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "column2";
                        var options = @"{
  ""visible_columns"": 2,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 7,
  ""container1_span_sm"": 8,
  ""container1_span_md"": 9,
  ""container1_span_lg"": 10,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 0,
  ""container1_offset_lg"": 0,
  ""container1_offset_xl"": 0,
  ""container1_flex_self_align"": ""1"",
  ""container1_flex_order"": 0,
  ""container2_span"": 5,
  ""container2_span_sm"": 4,
  ""container2_span_md"": 3,
  ""container2_span_lg"": 2,
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

                    #region << ***Create page body node*** Page name: move  id: 3ed4badd-cb45-4301-843f-42c99ea02c85 >>
                    {
                        var id = new Guid("3ed4badd-cb45-4301-843f-42c99ea02c85");
                        Guid? parentId = new Guid("21ebcaa5-2259-4b77-9ed5-f54303c073fc");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": "" Unit"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailUnitSnippet\"",\""default\"":\""\""}"",
  ""name"": ""field"",
  ""class"": ""text-nowrap"",
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

                    #region << ***Create page body node*** Page name: move  id: 50283af3-3acc-4c0e-ad44-d635385a8f7f >>
                    {
                        var id = new Guid("50283af3-3acc-4c0e-ad44-d635385a8f7f");
                        Guid? parentId = new Guid("21ebcaa5-2259-4b77-9ed5-f54303c073fc");
                        Guid? nodeId = null;
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Amount"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.amount\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
  ""class"": """",
  ""decimal_digits"": 2,
  ""min"": 0,
  ""max"": 0,
  ""step"": 1,
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

                    #region << ***Create page body node*** Page name: create  id: 130294b4-3555-43e9-82e1-556c4a59d805 >>
                    {
                        var id = new Guid("130294b4-3555-43e9-82e1-556c4a59d805");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: da14d155-afd3-4d3a-b3d1-b189fba8769d >>
                    {
                        var id = new Guid("da14d155-afd3-4d3a-b3d1-b189fba8769d");
                        Guid? parentId = new Guid("130294b4-3555-43e9-82e1-556c4a59d805");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
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

                    #region << ***Create page body node*** Page name: create  id: 910fed10-b358-43a9-b650-2f7ea3f57b2c >>
                    {
                        var id = new Guid("910fed10-b358-43a9-b650-2f7ea3f57b2c");
                        Guid? parentId = new Guid("da14d155-afd3-4d3a-b3d1-b189fba8769d");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
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

                    #region << ***Create page body node*** Page name: create  id: 3358d79a-8a5a-4d9f-ac66-abb2696fefe5 >>
                    {
                        var id = new Guid("3358d79a-8a5a-4d9f-ac66-abb2696fefe5");
                        Guid? parentId = new Guid("da14d155-afd3-4d3a-b3d1-b189fba8769d");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: e5959574-d7fb-4367-a3ea-84f93edf4425 >>
                    {
                        var id = new Guid("e5959574-d7fb-4367-a3ea-84f93edf4425");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 66913be0-f98e-4851-9d98-272b13df6729 >>
                    {
                        var id = new Guid("66913be0-f98e-4851-9d98-272b13df6729");
                        Guid? parentId = new Guid("e5959574-d7fb-4367-a3ea-84f93edf4425");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": """",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 0,
  ""container1_span_sm"": 0,
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

                    #region << ***Create page body node*** Page name: all  id: c97380b4-e96c-4198-8010-f1bc5ab0f54b >>
                    {
                        var id = new Guid("c97380b4-e96c-4198-8010-f1bc5ab0f54b");
                        Guid? parentId = new Guid("66913be0-f98e-4851-9d98-272b13df6729");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Add to Stock"",
  ""color"": ""0"",
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.CreateUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 2513894f-35bd-4434-9d86-53f235685547 >>
                    {
                        var id = new Guid("2513894f-35bd-4434-9d86-53f235685547");
                        Guid? parentId = new Guid("66913be0-f98e-4851-9d98-272b13df6729");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""0"",
  ""text"": ""Search"",
  ""color"": ""0"",
  ""size"": ""1"",
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

                    #region << ***Create page body node*** Page name: create  id: 6f0431d4-de68-4025-b7d6-4ddb593cdf8c >>
                    {
                        var id = new Guid("6f0431d4-de68-4025-b7d6-4ddb593cdf8c");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": ""wv-1461f5a7-21a6-4569-a62a-c891351007d5"",
  ""name"": ""CreateRecord"",
  ""hook_key"": ""article_stock_create"",
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

                    #region << ***Create page body node*** Page name: create  id: 258cd2d7-cb27-4f6b-b6ce-26902a615a2e >>
                    {
                        var id = new Guid("258cd2d7-cb27-4f6b-b6ce-26902a615a2e");
                        Guid? parentId = new Guid("6f0431d4-de68-4025-b7d6-4ddb593cdf8c");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Project"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.project_id\"",\""default\"":\""\""}"",
  ""name"": ""project_id"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""ProjectSelectOptions\"",\""default\"":\""\""}"",
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
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: a115874e-0e12-4928-8ff9-4d60df650792 >>
                    {
                        var id = new Guid("a115874e-0e12-4928-8ff9-4d60df650792");
                        Guid? parentId = new Guid("6f0431d4-de68-4025-b7d6-4ddb593cdf8c");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Article"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.article_id\"",\""default\"":\""\""}"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: 9a241050-ddaf-4778-85e7-066d582d71b5 >>
                    {
                        var id = new Guid("9a241050-ddaf-4778-85e7-066d582d71b5");
                        Guid? parentId = new Guid("6f0431d4-de68-4025-b7d6-4ddb593cdf8c");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldSelect";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Warehouse Location"",
  ""link"": """",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.warehouse_location_id\"",\""default\"":\""\""}"",
  ""name"": ""warehouse_location_id"",
  ""class"": """",
  ""show_icon"": ""false"",
  ""placeholder"": """",
  ""options"": ""{\""type\"":\""0\"",\""string\"":\""WarehouseLocationSelectOptions\"",\""default\"":\""\""}"",
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: create  id: cc249ed1-bdb4-4446-88fd-ce60d4215a7f >>
                    {
                        var id = new Guid("cc249ed1-bdb4-4446-88fd-ce60d4215a7f");
                        Guid? parentId = new Guid("6f0431d4-de68-4025-b7d6-4ddb593cdf8c");
                        Guid? nodeId = null;
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldNumber";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Amount"",
  ""mode"": ""0"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""Record.amount\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
  ""class"": """",
  ""decimal_digits"": 5,
  ""min"": 0,
  ""max"": 0,
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: manage  id: 0e3f9acb-1f18-41ae-ba1f-12df03abe77a >>
                    {
                        var id = new Guid("0e3f9acb-1f18-41ae-ba1f-12df03abe77a");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("17cf8661-3965-45ad-b490-512b23ed9dfd");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""<div class=\""mb-5\""/>"",
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

                    #region << ***Create page body node*** Page name: all  id: c1a16801-f061-4019-b756-ee65cd6b0f36 >>
                    {
                        var id = new Guid("c1a16801-f061-4019-b756-ee65cd6b0f36");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
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

                    #region << ***Create page body node*** Page name: all  id: fde852fa-7c59-4779-8ba5-a28fb3896c84 >>
                    {
                        var id = new Guid("fde852fa-7c59-4779-8ba5-a28fb3896c84");
                        Guid? parentId = new Guid("c1a16801-f061-4019-b756-ee65cd6b0f36");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
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

                    #region << ***Create page body node*** Page name: all  id: 528a83ca-d6d9-4091-9388-1064323c3d57 >>
                    {
                        var id = new Guid("528a83ca-d6d9-4091-9388-1064323c3d57");
                        Guid? parentId = new Guid("fde852fa-7c59-4779-8ba5-a28fb3896c84");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
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
  ""prefix"": """"
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 4aee729a-5faa-4edd-b3ef-3462319f3617 >>
                    {
                        var id = new Guid("4aee729a-5faa-4edd-b3ef-3462319f3617");
                        Guid? parentId = new Guid("fde852fa-7c59-4779-8ba5-a28fb3896c84");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
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
  ""prefix"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: b55a4a4a-0fd6-476c-bede-adcd56b03c9f >>
                    {
                        var id = new Guid("b55a4a4a-0fd6-476c-bede-adcd56b03c9f");
                        Guid? parentId = new Guid("fde852fa-7c59-4779-8ba5-a28fb3896c84");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcGridFilterField";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label"": ""Project"",
  ""name"": ""project"",
  ""try_connect_to_entity"": ""false"",
  ""field_type"": ""18"",
  ""query_type"": ""1"",
  ""query_options"": [
    ""1""
  ],
  ""prefix"": """"
}";
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: af96e259-8278-4bb3-b28e-d43289209261 >>
                    {
                        var id = new Guid("af96e259-8278-4bb3-b28e-d43289209261");
                        Guid? parentId = new Guid("fde852fa-7c59-4779-8ba5-a28fb3896c84");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
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
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: 7e734ce5-6411-408a-b484-2c8ba3dce4bd >>
                    {
                        var id = new Guid("7e734ce5-6411-408a-b484-2c8ba3dce4bd");
                        Guid? parentId = new Guid("fde852fa-7c59-4779-8ba5-a28fb3896c84");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
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

                    #region << ***Create page body node*** Page name: all  id: 38b062ef-c587-422d-a52e-a4d4c1355c97 >>
                    {
                        var id = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcGrid";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""id"": """",
  ""visible_columns"": 6,
  ""records"": ""{\""type\"":\""0\"",\""string\"":\""AllArticleStocks\"",\""default\"":\""\""}"",
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
  ""empty_text"": ""No Stocks"",
  ""has_thead"": ""true"",
  ""has_tfoot"": ""true"",
  ""no_total"": ""false"",
  ""reveals_details_on_click"": ""true"",
  ""detail_path"": ""/master-data/stock/stock/r/"",
  ""container1_label"": """",
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
  ""container6_label"": ""Stock"",
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: all  id: f5ba0527-41be-4eae-8adc-4e4062206e1d >>
                    {
                        var id = new Guid("f5ba0527-41be-4eae-8adc-4e4062206e1d");
                        Guid? parentId = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockListImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: d12c7162-f01b-453e-bdea-c260370b005f >>
                    {
                        var id = new Guid("d12c7162-f01b-453e-bdea-c260370b005f");
                        Guid? parentId = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$article[0].part_number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: c2897692-0be2-4b74-b243-a00274e609b4 >>
                    {
                        var id = new Guid("c2897692-0be2-4b74-b243-a00274e609b4");
                        Guid? parentId = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column4";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$warehouse_location[0].designation\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: c4aef52d-22db-4119-893d-0553249653fb >>
                    {
                        var id = new Guid("c4aef52d-22db-4119-893d-0553249653fb");
                        Guid? parentId = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column3";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$warehouse_location[0].$warehouse[0].designation\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 25f30d70-a360-46b4-84f4-cee331e01cc3 >>
                    {
                        var id = new Guid("25f30d70-a360-46b4-84f4-cee331e01cc3");
                        Guid? parentId = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column5";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.$project[0].number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 3b7660f8-807f-47af-88db-4d874bdfccca >>
                    {
                        var id = new Guid("3b7660f8-807f-47af-88db-4d874bdfccca");
                        Guid? parentId = new Guid("38b062ef-c587-422d-a52e-a4d4c1355c97");
                        Guid? nodeId = null;
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column6";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""link"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockAmountSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: 282a212d-15ed-47ee-a2b8-92f1678067f4 >>
                    {
                        var id = new Guid("282a212d-15ed-47ee-a2b8-92f1678067f4");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Entity.IconName\"",\""default\"":\""\""}"",
  ""return_url"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ListUrlSnippet\"",\""default\"":\""\""}""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: b4d4e918-6963-4053-a27e-cd964963e369 >>
                    {
                        var id = new Guid("b4d4e918-6963-4053-a27e-cd964963e369");
                        Guid? parentId = new Guid("282a212d-15ed-47ee-a2b8-92f1678067f4");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "actions";
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

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 2f75e4c0-1fc1-409e-a17b-d50697ece0cf >>
                    {
                        var id = new Guid("2f75e4c0-1fc1-409e-a17b-d50697ece0cf");
                        Guid? parentId = new Guid("b4d4e918-6963-4053-a27e-cd964963e369");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Manage"",
  ""color"": ""0"",
  ""size"": ""1"",
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
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.ManageUrlSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: ceef0ea3-8672-4ae7-8212-fd79ca9f49f8 >>
                    {
                        var id = new Guid("ceef0ea3-8672-4ae7-8212-fd79ca9f49f8");
                        Guid? parentId = new Guid("b4d4e918-6963-4053-a27e-cd964963e369");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column2";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Delete"",
  ""color"": ""10"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 ml-0"",
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: aeaa99f9-51ec-48e3-bd75-2ab734bf2e94 >>
                    {
                        var id = new Guid("aeaa99f9-51ec-48e3-bd75-2ab734bf2e94");
                        Guid? parentId = new Guid("b4d4e918-6963-4053-a27e-cd964963e369");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""2"",
  ""text"": ""Move"",
  ""color"": ""0"",
  ""size"": ""1"",
  ""class"": ""text-nowrap w-100 mb-2"",
  ""id"": """",
  ""icon_class"": ""fas fa-long-arrow-alt-up"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockMoveSnippet\"",\""default\"":\""\""}"",
  ""new_tab"": ""false"",
  ""form"": """"
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 016c49c2-b87c-4d9c-95bb-07a64cc5154a >>
                    {
                        var id = new Guid("016c49c2-b87c-4d9c-95bb-07a64cc5154a");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
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
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: b1fe15d5-cf69-4d2e-901c-cda886ce0a3f >>
                    {
                        var id = new Guid("b1fe15d5-cf69-4d2e-901c-cda886ce0a3f");
                        Guid? parentId = new Guid("016c49c2-b87c-4d9c-95bb-07a64cc5154a");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockArticleImageSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: a89b132c-32c2-4371-abdf-6cd6ed0ac6ff >>
                    {
                        var id = new Guid("a89b132c-32c2-4371-abdf-6cd6ed0ac6ff");
                        Guid? parentId = new Guid("016c49c2-b87c-4d9c-95bb-07a64cc5154a");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "body";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""<div class=\""mb-5\""/>"",
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

                    #region << ***Create page body node*** Page name: detail  id: 98e686ce-597f-4bd7-a8b2-e2b687fb1177 >>
                    {
                        var id = new Guid("98e686ce-597f-4bd7-a8b2-e2b687fb1177");
                        Guid? parentId = new Guid("016c49c2-b87c-4d9c-95bb-07a64cc5154a");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
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
  ""container1_span_md"": 0,
  ""container1_span_lg"": 6,
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
  ""container2_span_md"": 0,
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
                        var weight = 3;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: 95f25351-0469-4034-8428-a84a6efb94fd >>
                    {
                        var id = new Guid("95f25351-0469-4034-8428-a84a6efb94fd");
                        Guid? parentId = new Guid("98e686ce-597f-4bd7-a8b2-e2b687fb1177");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Article"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockArticleDesignationSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: d53ebb86-9f23-4527-963c-5f6f4a50ecdb >>
                    {
                        var id = new Guid("d53ebb86-9f23-4527-963c-5f6f4a50ecdb");
                        Guid? parentId = new Guid("98e686ce-597f-4bd7-a8b2-e2b687fb1177");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Warehouse Location"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailLocationSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: detail  id: 2ac13352-8e26-431f-88a5-daf703dbaf89 >>
                    {
                        var id = new Guid("2ac13352-8e26-431f-88a5-daf703dbaf89");
                        Guid? parentId = new Guid("016c49c2-b87c-4d9c-95bb-07a64cc5154a");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
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
  ""container1_span_md"": 0,
  ""container1_span_lg"": 6,
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
  ""container2_span_md"": 0,
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
                        var weight = 4;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: detail  id: f492d967-5d15-426f-ae7a-c28ceccddd3d >>
                    {
                        var id = new Guid("f492d967-5d15-426f-ae7a-c28ceccddd3d");
                        Guid? parentId = new Guid("2ac13352-8e26-431f-88a5-daf703dbaf89");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column2";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Amount"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailAmountSnippet\"",\""default\"":\""\""}"",
  ""name"": ""amount"",
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

                    #region << ***Create page body node*** Page name: detail  id: 51fb8e7f-cddf-43ed-a225-6b3a938824d9 >>
                    {
                        var id = new Guid("51fb8e7f-cddf-43ed-a225-6b3a938824d9");
                        Guid? parentId = new Guid("2ac13352-8e26-431f-88a5-daf703dbaf89");
                        Guid? nodeId = null;
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""Project"",
  ""link"": """",
  ""mode"": ""2"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.Stocks.ArticleStockDetailProjectSnippet\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: 168a56a8-8f3a-4e6b-bb25-df1e71ebef84 >>
                    {
                        var id = new Guid("168a56a8-8f3a-4e6b-bb25-df1e71ebef84");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcForm";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.RecordIsNullSnippet\"",\""default\"":\""\""}"",
  ""id"": ""wv-168a56a8-8f3a-4e6b-bb25-df1e71ebef84"",
  ""name"": ""update"",
  ""hook_key"": ""article_file_upload"",
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

                    #region << ***Create page body node*** Page name: eplan-import  id: 94cb0882-429b-452c-8550-146e7e3b6c91 >>
                    {
                        var id = new Guid("94cb0882-429b-452c-8550-146e7e3b6c91");
                        Guid? parentId = new Guid("168a56a8-8f3a-4e6b-bb25-df1e71ebef84");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcRow";
                        var containerId = "body";
                        var options = @"{
  ""visible_columns"": 1,
  ""class"": ""mb-5"",
  ""no_gutters"": ""false"",
  ""flex_vertical_alignment"": ""1"",
  ""flex_horizontal_alignment"": ""1"",
  ""container1_span"": 12,
  ""container1_span_sm"": 0,
  ""container1_span_md"": 10,
  ""container1_span_lg"": 8,
  ""container1_span_xl"": 0,
  ""container1_offset"": 0,
  ""container1_offset_sm"": 0,
  ""container1_offset_md"": 1,
  ""container1_offset_lg"": 2,
  ""container1_offset_xl"": 0,
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
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: 51205491-20c0-47ab-8240-e786016304c4 >>
                    {
                        var id = new Guid("51205491-20c0-47ab-8240-e786016304c4");
                        Guid? parentId = new Guid("94cb0882-429b-452c-8550-146e7e3b6c91");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcButton";
                        var containerId = "column1";
                        var options = @"{
  ""type"": ""1"",
  ""text"": ""Load Articles"",
  ""color"": ""0"",
  ""size"": ""3"",
  ""class"": ""text-nowrap float-right"",
  ""id"": """",
  ""icon_class"": ""fas fa-clipboard-list"",
  ""is_block"": ""false"",
  ""is_outline"": ""false"",
  ""icon_right"": ""false"",
  ""is_active"": ""false"",
  ""is_disabled"": ""false"",
  ""is_visible"": """",
  ""onclick"": """",
  ""href"": """",
  ""new_tab"": ""false"",
  ""form"": ""wv-168a56a8-8f3a-4e6b-bb25-df1e71ebef84""
}";
                        var weight = 2;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page body node*** Page name: eplan-import  id: f06a6224-802d-4896-89dd-9062a082bf1b >>
                    {
                        var id = new Guid("f06a6224-802d-4896-89dd-9062a082bf1b");
                        Guid? parentId = new Guid("94cb0882-429b-452c-8550-146e7e3b6c91");
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldFile";
                        var containerId = "column1";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": ""File"",
  ""mode"": ""0"",
  ""value"": """",
  ""name"": ""file"",
  ""class"": ""mb-5 mt-5"",
  ""accept"": "".xml"",
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
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Articles.ArticleListImageSnippet\"",\""default\"":\""no icon\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: a571362f-4900-44b4-a1a2-90cf4e09b98d >>
                    {
                        var id = new Guid("a571362f-4900-44b4-a1a2-90cf4e09b98d");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldHtml";
                        var containerId = "column8";
                        var options = @"{
  ""is_visible"": """",
  ""label_mode"": ""0"",
  ""label_text"": """",
  ""mode"": ""4"",
  ""value"": ""{\""type\"":\""3\"",\""string\"":\""WebVella.Erp.Plugins.Duatec.Snippets.Eplan.ListCheckIfFromEplanSnippet\"",\""default\"":\""\""}"",
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
                        var containerId = "column5";
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

                    #region << ***Create page body node*** Page name: all  id: d7e35ec3-d45f-45f9-9de1-710510bc5bbf >>
                    {
                        var id = new Guid("d7e35ec3-d45f-45f9-9de1-710510bc5bbf");
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
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.order_number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: 1be3299a-cf3a-4abd-9e8c-08beee853ffe >>
                    {
                        var id = new Guid("1be3299a-cf3a-4abd-9e8c-08beee853ffe");
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
  ""value"": ""{\""type\"":\""0\"",\""string\"":\""RowRecord.type_number\"",\""default\"":\""\""}"",
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

                    #region << ***Create page body node*** Page name: all  id: d3d79404-799b-4afa-8271-21205ecbead1 >>
                    {
                        var id = new Guid("d3d79404-799b-4afa-8271-21205ecbead1");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldCheckbox";
                        var containerId = "column7";
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

                    #region << ***Create page body node*** Page name: all  id: 442fa321-20be-4a58-b69c-d7b35bf01636 >>
                    {
                        var id = new Guid("442fa321-20be-4a58-b69c-d7b35bf01636");
                        Guid? parentId = new Guid("9569b249-9a35-44b2-9d71-1e8c0d60b662");
                        Guid? nodeId = null;
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var componentName = "WebVella.Erp.Web.Components.PcFieldText";
                        var containerId = "column6";
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

                    #region << ***Create page body node*** Page name: eplan-import  id: cbfd6dab-7a27-4a50-b1c5-056a2ea40d46 >>
                    {
                        var id = new Guid("cbfd6dab-7a27-4a50-b1c5-056a2ea40d46");
                        Guid? parentId = null;
                        Guid? nodeId = null;
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var componentName = "WebVella.Erp.Web.Components.PcPageHeader";
                        var containerId = "";
                        var options = @"{
  ""is_visible"": """",
  ""fix_on_scroll"": ""false"",
  ""area_label"": ""{\""type\"":\""0\"",\""string\"":\""Entity.LabelPlural\"",\""default\"":\""\""}"",
  ""area_sublabel"": """",
  ""title"": ""{\""type\"":\""0\"",\""string\"":\""Page.Label\"",\""default\"":\""\""}"",
  ""subtitle"": """",
  ""description"": """",
  ""show_page_switch"": ""false"",
  ""color"": ""{\""type\"":\""0\"",\""string\"":\""App.Color\"",\""default\"":\""\""}"",
  ""icon_color"": ""#fff"",
  ""icon_class"": ""{\""type\"":\""0\"",\""string\"":\""Page.IconClass\"",\""default\"":\""\""}"",
  ""return_url"": ""/master-data/articles/articles/l/all""
}";
                        var weight = 1;

                        new WebVella.Erp.Web.Services.PageService().CreatePageBodyNode(id, parentId, pageId, nodeId, weight, componentName, containerId, options, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var description = @"All Article Types";
                        var eqlText = @"SELECT *
FROM article_type
ORDER BY label
PAGE @page
PAGESIZE @pageSize";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article_type.""id"" AS ""id"",
	 rec_article_type.""unit"" AS ""unit"",
	 rec_article_type.""label"" AS ""label"",
	 rec_article_type.""is_integer"" AS ""is_integer"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_article_type
ORDER BY rec_article_type.""label"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""unit"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""label"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""is_integer"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"article_type";

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
WHERE (@name = null OR name ~* @name)
    AND(@shortName = null OR short_name ~* @shortName)
ORDER BY name ASC
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
WHERE  (  (  ( @name IS NULL )  OR  ( rec_manufacturer.""name"" ~* @name )  )  AND  (  ( @shortName IS NULL )  OR  ( rec_manufacturer.""short_name"" ~* @shortName )  )  ) 
ORDER BY rec_manufacturer.""name"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""name"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""shortName"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""logo"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""website"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""short_name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"manufacturer";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllWarehouses >>
                    {
                        var id = new Guid("17a5ad14-9bd4-434c-a913-5eb6b4d6de73");
                        var name = @"AllWarehouses";
                        var description = @"";
                        var eqlText = @"SELECT *
FROM warehouse
ORDER BY designation
PAGE @page
PAGESIZE @pageSize
";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_warehouse.""id"" AS ""id"",
	 rec_warehouse.""designation"" AS ""designation"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_warehouse
ORDER BY rec_warehouse.""designation"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"warehouse";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllWarehouseLocations >>
                    {
                        var id = new Guid("4b711d44-cdd4-4d63-abaa-72add6710c73");
                        var name = @"AllWarehouseLocations";
                        var description = @"All Warehouse Locations";
                        var eqlText = @"SELECT *, $warehouse.designation
FROM warehouse_location
WHERE (@warehouse = null OR $warehouse.designation ~* @warehouse)
    AND (@designation = null OR designation ~* @designation)
ORDER BY $warehouse.designation, designation
PAGE @page
PAGESIZE @pageSize
";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_warehouse_location.""id"" AS ""id"",
	 rec_warehouse_location.""designation"" AS ""designation"",
	 rec_warehouse_location.""warehouse_id"" AS ""warehouse_id"",
	 COUNT(*) OVER() AS ___total_count___,
	------->: $warehouse
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 warehouse.""id"" AS ""id"",
		 warehouse.""designation"" AS ""designation""
	 FROM rec_warehouse warehouse
	 WHERE warehouse.id = rec_warehouse_location.warehouse_id ) d )::jsonb AS ""$warehouse""	
	-------< $warehouse

FROM rec_warehouse_location

LEFT OUTER JOIN  rec_warehouse warehouse_tar_org ON warehouse_tar_org.id = rec_warehouse_location.warehouse_id
WHERE  (  (  ( @warehouse IS NULL )  OR  ( warehouse_tar_org.""designation"" ~* @warehouse )  )  AND  (  ( @designation IS NULL )  OR  ( rec_warehouse_location.""designation"" ~* @designation )  )  ) 
ORDER BY warehouse_tar_org.""designation"" ASC , rec_warehouse_location.""designation"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""designation"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""warehouse"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""warehouse_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$warehouse"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"warehouse_location";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllProjects >>
                    {
                        var id = new Guid("2571a1bc-9bb1-4794-b0d5-ef5b946fc4e2");
                        var name = @"AllProjects";
                        var description = @"All Projects";
                        var eqlText = @"SELECT *
FROM project
WHERE (@number = null OR number STARTSWITH @number)
    AND (@name = null OR name ~* @name)
ORDER BY number
PAGE @page
PAGESIZE @pageSize
";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_project.""id"" AS ""id"",
	 rec_project.""name"" AS ""name"",
	 rec_project.""number"" AS ""number"",
	 COUNT(*) OVER() AS ___total_count___
FROM rec_project
WHERE  (  (  ( @number IS NULL )  OR  ( rec_project.""number""  ILIKE CONCAT ( @number,'%'  ) )  )  AND  (  ( @name IS NULL )  OR  ( rec_project.""name"" ~* @name )  )  ) 
ORDER BY rec_project.""number"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""number"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""name"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""number"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"project";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllArticles4SelectOptions >>
                    {
                        var id = new Guid("146061c7-156f-4277-a00e-2fe4c6f51c91");
                        var name = @"AllArticles4SelectOptions";
                        var description = @"All Articles with id, part_number and designation";
                        var eqlText = @"SELECT id, part_number, designation
FROM article
WHERE (@excluded = null OR id != @excluded)
ORDER BY part_number";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article.""id"" AS ""id"",
	 rec_article.""part_number"" AS ""part_number"",
	 rec_article.""designation"" AS ""designation""
FROM rec_article
WHERE  (  ( @excluded IS NULL )  OR  ( rec_article.""id"" IS NOT NULL )  ) 
ORDER BY rec_article.""part_number"" ASC
) X
";
                        var parametersJson = @"[{""name"":""excluded"",""type"":""guid"",""value"":""null"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""part_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]";
                        var weight = 10;
                        var returnTotal = false;
                        var entityName = @"article";

                        new WebVella.Erp.Database.DbDataSourceRepository().Create(id, name, description, weight, eqlText, sqlText, parametersJson, fieldsJson, entityName, returnTotal);
                    }
                    #endregion

                    #region << ***Create data source*** Name: AllArticleStocks >>
                    {
                        var id = new Guid("c9b5a6bd-09bf-426f-bcbc-4b48f5972dab");
                        var name = @"AllArticleStocks";
                        var description = @"All Article Stocks";
                        var eqlText = @"SELECT *, $article.part_number, $article.preview, $article.$article_article_type.unit, $article.$article_article_type.is_integer, $warehouse_location.designation, $warehouse_location.$warehouse.designation, $project.number
FROM article_stock
WHERE (@warehouseLocation = null or $warehouse_location.designation ~* @warehouseLocation)
    AND (@warehouse = null or $warehouse_location.$warehouse.designation ~* @warehouse)
    AND (@partNumber = null or $article.part_number ~* @partNumber)
    AND (@project = null or $project.number STARTSWITH @project)
ORDER BY $article.part_number, $warehouse_location.$warehouse.designation, $warehouse_location.designation
PAGE @page
PAGESIZE @pageSize
";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article_stock.""id"" AS ""id"",
	 rec_article_stock.""article_id"" AS ""article_id"",
	 rec_article_stock.""warehouse_location_id"" AS ""warehouse_location_id"",
	 rec_article_stock.""project_id"" AS ""project_id"",
	 rec_article_stock.""amount"" AS ""amount"",
	 COUNT(*) OVER() AS ___total_count___,
	------->: $article
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 article.""id"" AS ""id"",
		 article.""part_number"" AS ""part_number"",
		 article.""preview"" AS ""preview"",
		------->: $article_article_type
		(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
		 SELECT 
			 article_article_type.""id"" AS ""id"",
			 article_article_type.""unit"" AS ""unit"",
			 article_article_type.""is_integer"" AS ""is_integer""
		 FROM rec_article_type article_article_type
		 WHERE article_article_type.id = article.article_type ) d )::jsonb AS ""$article_article_type""		
		-------< $article_article_type

	 FROM rec_article article
	 WHERE article.id = rec_article_stock.article_id ) d )::jsonb AS ""$article"",
	-------< $article
	------->: $warehouse_location
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 warehouse_location.""id"" AS ""id"",
		 warehouse_location.""designation"" AS ""designation"",
		------->: $warehouse
		(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
		 SELECT 
			 warehouse.""id"" AS ""id"",
			 warehouse.""designation"" AS ""designation""
		 FROM rec_warehouse warehouse
		 WHERE warehouse.id = warehouse_location.warehouse_id ) d )::jsonb AS ""$warehouse""		
		-------< $warehouse

	 FROM rec_warehouse_location warehouse_location
	 WHERE warehouse_location.id = rec_article_stock.warehouse_location_id ) d )::jsonb AS ""$warehouse_location"",
	-------< $warehouse_location
	------->: $project
	(SELECT  COALESCE( array_to_json( array_agg( row_to_json(d) )), '[]') FROM (
	 SELECT 
		 project.""id"" AS ""id"",
		 project.""number"" AS ""number""
	 FROM rec_project project
	 WHERE project.id = rec_article_stock.project_id ) d )::jsonb AS ""$project""	
	-------< $project

FROM rec_article_stock

LEFT OUTER JOIN  rec_article article_tar_org ON article_tar_org.id = rec_article_stock.article_id
LEFT OUTER JOIN  rec_warehouse_location warehouse_location_tar_org ON warehouse_location_tar_org.id = rec_article_stock.warehouse_location_id
LEFT OUTER JOIN  rec_warehouse warehouse_tar_org ON warehouse_tar_org.id = warehouse_location_tar_org.warehouse_id
LEFT OUTER JOIN  rec_project project_tar_org ON project_tar_org.id = rec_article_stock.project_id
WHERE  (  (  (  (  ( @warehouseLocation IS NULL )  OR  ( warehouse_location_tar_org.""designation"" ~* @warehouseLocation )  )  AND  (  ( @warehouse IS NULL )  OR  ( warehouse_tar_org.""designation"" ~* @warehouse )  )  )  AND  (  ( @partNumber IS NULL )  OR  ( article_tar_org.""part_number"" ~* @partNumber )  )  )  AND  (  ( @project IS NULL )  OR  ( project_tar_org.""number""  ILIKE CONCAT ( @project,'%'  ) )  )  ) 
ORDER BY article_tar_org.""part_number"" ASC , warehouse_tar_org.""designation"" ASC , warehouse_location_tar_org.""designation"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""warehouse"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""warehouseLocation"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""project"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""article_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""warehouse_location_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""project_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""amount"",""type"":12,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$article"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""part_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""preview"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$article_article_type"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""unit"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""is_integer"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]},{""name"":""$warehouse_location"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$warehouse"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]},{""name"":""$project"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]";
                        var weight = 10;
                        var returnTotal = true;
                        var entityName = @"article_stock";

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
    AND(@partNumber = null OR part_number ~* @partNumber)
    AND(@typeNumber = null OR type_number ~* @typeNumber)
    AND(@orderNumber = null OR order_number ~* @orderNumber)
    AND(@manufacturer = null OR $article_manufacturer.name ~* @manufacturer)
    AND(@designation = null OR designation ~* @designation)
ORDER BY part_number
PAGE @page
PAGESIZE @pageSize";
                        var sqlText = @"SELECT row_to_json( X ) FROM (
SELECT 
	 rec_article.""id"" AS ""id"",
	 rec_article.""manufacturer_id"" AS ""manufacturer_id"",
	 rec_article.""preview"" AS ""preview"",
	 rec_article.""part_number"" AS ""part_number"",
	 rec_article.""eplan_id"" AS ""eplan_id"",
	 rec_article.""designation"" AS ""designation"",
	 rec_article.""is_blocked"" AS ""is_blocked"",
	 rec_article.""article_type"" AS ""article_type"",
	 rec_article.""type_number"" AS ""type_number"",
	 rec_article.""order_number"" AS ""order_number"",
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
WHERE  (  (  (  (  (  (  ( @isBlocked IS NULL )  OR  ( rec_article.""is_blocked"" IS NULL )  )  AND  (  ( @partNumber IS NULL )  OR  ( rec_article.""part_number"" ~* @partNumber )  )  )  AND  (  ( @typeNumber IS NULL )  OR  ( rec_article.""type_number"" ~* @typeNumber )  )  )  AND  (  ( @orderNumber IS NULL )  OR  ( rec_article.""order_number"" ~* @orderNumber )  )  )  AND  (  ( @manufacturer IS NULL )  OR  ( article_manufacturer_tar_org.""name"" ~* @manufacturer )  )  )  AND  (  ( @designation IS NULL )  OR  ( rec_article.""designation"" ~* @designation )  )  ) 
ORDER BY rec_article.""part_number"" ASC
LIMIT 10
OFFSET 0
) X
";
                        var parametersJson = @"[{""name"":""isBlocked"",""type"":""bool"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""typeNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""manufacturer"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""designation"",""type"":""text"",""value"":""null"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""1"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""10"",""ignore_parse_errors"":false}]";
                        var fieldsJson = @"[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""manufacturer_id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""preview"",""type"":19,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""part_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""eplan_id"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""designation"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""is_blocked"",""type"":2,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""article_type"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""type_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""order_number"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""$article_manufacturer"",""type"":20,""entity_name"":"""",""relation_name"":null,""children"":[{""name"":""id"",""type"":16,""entity_name"":"""",""relation_name"":null,""children"":[]},{""name"":""name"",""type"":18,""entity_name"":"""",""relation_name"":null,""children"":[]}]}]";
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

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("419b1546-cf9a-4418-85f5-02130e95ba38");
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false},{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: ArticleEquivalents >>
                    {
                        var id = new Guid("59b95fc8-fe1b-4507-bdba-66d5db3f5e5f");
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var dataSourceId = new Guid("33a3f693-5f26-478e-8ded-64b8f8009798");
                        var name = @"ArticleEquivalents";
                        var parameters = @"[{""name"":""id"",""type"":""guid"",""value"":""{{Record.id}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: ArticleEquivalents >>
                    {
                        var id = new Guid("52abb9e3-6827-4499-902c-47539dc78963");
                        var pageId = new Guid("61598892-c98d-426a-87d0-67d41e9dabba");
                        var dataSourceId = new Guid("33a3f693-5f26-478e-8ded-64b8f8009798");
                        var name = @"ArticleEquivalents";
                        var parameters = @"[{""name"":""id"",""type"":""guid"",""value"":""{{Record.id}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllManufacturers >>
                    {
                        var id = new Guid("9ef23f0f-a996-4bcb-ab71-701d945ed201");
                        var pageId = new Guid("488b826b-1632-4f50-9d8f-5a0ff95bff93");
                        var dataSourceId = new Guid("4c537e23-2fe0-4da4-b14f-bb74327f744b");
                        var name = @"AllManufacturers";
                        var parameters = @"[{""name"":""name"",""type"":""text"",""value"":""{{RequestQuery.q_name_v}}"",""ignore_parse_errors"":false},{""name"":""shortName"",""type"":""text"",""value"":""{{RequestQuery.q_short_name_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: EplanManufacturers >>
                    {
                        var id = new Guid("60d06119-2fce-4d63-bc74-1d1cbf5bd704");
                        var pageId = new Guid("b86cba50-83da-4d02-9979-6b104a2b3509");
                        var dataSourceId = new Guid("0fdba4a2-6779-49eb-b299-41e394d86df3");
                        var name = @"EplanManufacturers";
                        var parameters = @"[{""name"":""shortName"",""type"":""text"",""value"":""{{RequestQuery.q_short_name_v}}"",""ignore_parse_errors"":false},{""name"":""name"",""type"":""text"",""value"":""{{RequestQuery.q_name_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: ArticleSelectOptions >>
                    {
                        var id = new Guid("0430bf83-3a81-4463-a745-c8f60949bf6c");
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"ArticleSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticles4SelectOptions"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""part_number"",""ignore_parse_errors"":false},{""name"":""Value1PropName"",""type"":""text"",""value"":""designation"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllWarehouses >>
                    {
                        var id = new Guid("87f79e39-05e2-4d11-9b71-19d822d3eb97");
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var dataSourceId = new Guid("17a5ad14-9bd4-434c-a913-5eb6b4d6de73");
                        var name = @"AllWarehouses";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: WarehouseSelectOptions >>
                    {
                        var id = new Guid("d4dfdb6f-f4b5-4de1-800b-7312ae37a2e7");
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"WarehouseSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllWarehouses"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""designation"",""ignore_parse_errors"":false},{""name"":""SortOrderPropName"",""type"":""text"",""value"":""designation"",""ignore_parse_errors"":false},{""name"":""SortTypePropName"",""type"":""text"",""value"":""asc"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllWarehouseLocations >>
                    {
                        var id = new Guid("1bc089b9-f312-4e0b-b027-c9de213ab454");
                        var pageId = new Guid("61140b3c-0646-4d31-ae5a-c52d22c22b32");
                        var dataSourceId = new Guid("4b711d44-cdd4-4d63-abaa-72add6710c73");
                        var name = @"AllWarehouseLocations";
                        var parameters = @"[{""name"":""designationQuery"",""type"":""text"",""value"":""{{RequestQuery.q_designation_v}}"",""ignore_parse_errors"":false},{""name"":""warehouse"",""type"":""text"",""value"":""{{RequestQuery.q_warehouse_v}}"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""{{RequestQuery.sortBy}}"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""{{RequestQuery.sortOrder}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllProjects >>
                    {
                        var id = new Guid("6a47c7ca-fcb7-4f65-8ef1-b8e730164d8e");
                        var pageId = new Guid("bd90eb30-4768-44f5-88c2-40a3fac8cf6a");
                        var dataSourceId = new Guid("2571a1bc-9bb1-4794-b0d5-ef5b946fc4e2");
                        var name = @"AllProjects";
                        var parameters = @"[{""name"":""number"",""type"":""text"",""value"":""{{RequestQuery.q_number_v}}"",""ignore_parse_errors"":false},{""name"":""name"",""type"":""text"",""value"":""{{RequestQuery.q_name_v}}"",""ignore_parse_errors"":false},{""name"":""sortBy"",""type"":""text"",""value"":""{{RequestQuery.sortBy}}"",""ignore_parse_errors"":false},{""name"":""sortOrder"",""type"":""text"",""value"":""{{RequestQuery.sortOrder}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("891b1bc9-5e92-4b4d-860c-21df79b7ae9e");
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("5d0238de-4950-4a0f-aed7-831bb673eab3");
                        var pageId = new Guid("d3d8c012-dfb6-4065-8059-0ba3b1286927");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("00f516d9-e756-4851-bea7-cc291ada8c9b");
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""sortBy"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllWarehouses >>
                    {
                        var id = new Guid("08ce1a7e-5748-4669-8e08-c67a82c07cab");
                        var pageId = new Guid("b2627c0d-d3bc-4627-9770-3f7c1e2cb4c7");
                        var dataSourceId = new Guid("17a5ad14-9bd4-434c-a913-5eb6b4d6de73");
                        var name = @"AllWarehouses";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("b3eb10bc-808d-4169-9796-07aa79217d66");
                        var pageId = new Guid("ba2cde89-1991-4028-8bfc-20dc721e91e6");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("a0033c44-437e-4f39-9191-adc3c3d6d96c");
                        var pageId = new Guid("f8c28fa8-e57f-4be6-95f3-c757141fd059");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: WarehouseLocationSelectOptions >>
                    {
                        var id = new Guid("9ed03612-cb51-4afb-abfe-b451ffa642b6");
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"WarehouseLocationSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllWarehouseLocations"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""$warehouse[0].designation"",""ignore_parse_errors"":false},{""name"":""Value1PropName"",""type"":""text"",""value"":""designation"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllWarehouseLocations >>
                    {
                        var id = new Guid("7ad69bac-790a-4c82-abe1-6e61d67d2fc1");
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var dataSourceId = new Guid("4b711d44-cdd4-4d63-abaa-72add6710c73");
                        var name = @"AllWarehouseLocations";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticles >>
                    {
                        var id = new Guid("12726284-3106-47ab-adb0-36b496d59a1f");
                        var pageId = new Guid("11320daa-2725-4fde-acc5-9ff81e549aad");
                        var dataSourceId = new Guid("28b0a525-e227-4fe2-a073-bcd8300a1b37");
                        var name = @"AllArticles";
                        var parameters = @"[{""name"":""isBlocked"",""type"":""bool"",""value"":""{{RequestQuery.q_is_blocked_v}}"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""{{RequestQuery.q_part_number_v}}"",""ignore_parse_errors"":false},{""name"":""typeNumber"",""type"":""text"",""value"":""{{RequestQuery.q_type_number_v}}"",""ignore_parse_errors"":false},{""name"":""orderNumber"",""type"":""text"",""value"":""{{RequestQuery.q_order_number_v}}"",""ignore_parse_errors"":false},{""name"":""manufacturer"",""type"":""text"",""value"":""{{RequestQuery.q_manufacturer_v}}"",""ignore_parse_errors"":false},{""name"":""designation"",""type"":""text"",""value"":""{{RequestQuery.q_designation_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllProjects >>
                    {
                        var id = new Guid("b3319d49-3643-4709-a131-98006a711769");
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var dataSourceId = new Guid("2571a1bc-9bb1-4794-b0d5-ef5b946fc4e2");
                        var name = @"AllProjects";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: ProjectSelectOptions >>
                    {
                        var id = new Guid("f1aaa6e3-b88d-4614-b0f0-524ab35bfca5");
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"ProjectSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllProjects"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""number"",""ignore_parse_errors"":false},{""name"":""Value1PropName"",""type"":""text"",""value"":""name"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleStocks >>
                    {
                        var id = new Guid("6d8e58b1-6e96-44e5-b752-be867eeb8d6e");
                        var pageId = new Guid("49939f02-8cd3-4165-bf64-290ab31d965a");
                        var dataSourceId = new Guid("c9b5a6bd-09bf-426f-bcbc-4b48f5972dab");
                        var name = @"AllArticleStocks";
                        var parameters = @"[{""name"":""warehouse"",""type"":""text"",""value"":""{{RequestQuery.q_warehouse_v}}"",""ignore_parse_errors"":false},{""name"":""warehouseLocation"",""type"":""text"",""value"":""{{RequestQuery.q_warehouse_location_v}}"",""ignore_parse_errors"":false},{""name"":""partNumber"",""type"":""text"",""value"":""{{RequestQuery.q_part_number_v}}"",""ignore_parse_errors"":false},{""name"":""project"",""type"":""text"",""value"":""{{RequestQuery.q_project_v}}"",""ignore_parse_errors"":false},{""name"":""page"",""type"":""int"",""value"":""{{RequestQuery.page}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("7a8cd439-6f39-44f1-aa0e-523caf322493");
                        var pageId = new Guid("af1a45fd-0f75-4412-827f-99e3627c39b0");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticles4SelectOptions >>
                    {
                        var id = new Guid("8f211373-6b05-4e5f-b02a-4e7318606f20");
                        var pageId = new Guid("75411570-3352-4c7a-ba14-f86326571a38");
                        var dataSourceId = new Guid("146061c7-156f-4277-a00e-2fe4c6f51c91");
                        var name = @"AllArticles4SelectOptions";
                        var parameters = @"[{""name"":""excluded"",""type"":""guid"",""value"":""{{Record.id}}"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticles4SelectOptions >>
                    {
                        var id = new Guid("a38a5a8b-1f83-457a-a1ed-8e140f5f0297");
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var dataSourceId = new Guid("146061c7-156f-4277-a00e-2fe4c6f51c91");
                        var name = @"AllArticles4SelectOptions";
                        var parameters = @"[]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: ArticleSelectOptions >>
                    {
                        var id = new Guid("45d0a508-4519-4b8c-b4a6-6136577c13f6");
                        var pageId = new Guid("c028c7ca-70c1-43a8-8b4a-2ed33d5b1e28");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"ArticleSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticles4SelectOptions"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""part_number"",""ignore_parse_errors"":false},{""name"":""Value1PropName"",""type"":""text"",""value"":""designation"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllProjects >>
                    {
                        var id = new Guid("80319e03-e766-4666-9316-c6ae2b8c97bc");
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var dataSourceId = new Guid("2571a1bc-9bb1-4794-b0d5-ef5b946fc4e2");
                        var name = @"AllProjects";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllWarehouseLocations >>
                    {
                        var id = new Guid("f1b54fe0-dfcd-4d50-b99d-5a618b887b73");
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var dataSourceId = new Guid("4b711d44-cdd4-4d63-abaa-72add6710c73");
                        var name = @"AllWarehouseLocations";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: ProjectSelectOptions >>
                    {
                        var id = new Guid("8a13b0d3-02de-4f74-b80b-d70e8f97b1b3");
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"ProjectSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllProjects"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""number"",""ignore_parse_errors"":false},{""name"":""Value1PropName"",""type"":""text"",""value"":""name"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: WarehouseLocationSelectOptions >>
                    {
                        var id = new Guid("578753d0-70ad-4ad7-8832-6ac23547d9fb");
                        var pageId = new Guid("ffe30827-f205-4c94-9dc6-fec0371ca01b");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"WarehouseLocationSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllWarehouseLocations"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""$warehouse[0].designation"",""ignore_parse_errors"":false},{""name"":""Value1PropName"",""type"":""text"",""value"":""designation"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: AllArticleTypes >>
                    {
                        var id = new Guid("e4a0ccf0-71d7-4364-a4f7-84a27cd401e4");
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var dataSourceId = new Guid("8cb020ec-5e9d-47b7-9246-d01ad6236cbd");
                        var name = @"AllArticleTypes";
                        var parameters = @"[{""name"":""pageSize"",""type"":""int"",""value"":""2147483647"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
                    }
                    #endregion

                    #region << ***Create page data source*** Name: TypeSelectOptions >>
                    {
                        var id = new Guid("4d958f6f-8e16-48e6-b5e0-e0561f26180f");
                        var pageId = new Guid("27788fb7-71b0-44fe-846e-1cadab2504d8");
                        var dataSourceId = new Guid("12dcdf08-af03-4347-8015-bd9bace17514");
                        var name = @"TypeSelectOptions";
                        var parameters = @"[{""name"":""DataSourceName"",""type"":""text"",""value"":""AllArticleTypes"",""ignore_parse_errors"":false},{""name"":""KeyPropName"",""type"":""text"",""value"":""id"",""ignore_parse_errors"":false},{""name"":""ValuePropName"",""type"":""text"",""value"":""label"",""ignore_parse_errors"":false}]";

                        new WebVella.Erp.Web.Services.PageService(ErpSettings.ConnectionString).CreatePageDataSource(id, pageId, dataSourceId, name, parameters, WebVella.Erp.Database.DbContext.Current.Transaction);
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


                }
#pragma warning restore
            }
        }
    }
}
