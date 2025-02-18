using WebVella.Erp.Api;
using Newtonsoft.Json;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Database;
using Newtonsoft.Json.Linq;
using WebVella.Erp.Api.Models.AutoMapper;

var location = System.Reflection.Assembly.GetEntryAssembly()!.Location;
var path = location[..location.LastIndexOf('\\')];
var config = JObject.Parse(File.ReadAllText(path + "\\Config.json"));
var connectionString = ((JObject)config["Settings"])["ConnectionString"]!.ToString();
var context = DbContext.CreateContext(connectionString);

ErpAutoMapperConfiguration.Configure(ErpAutoMapperConfiguration.MappingExpressions);
ErpAutoMapper.Initialize(ErpAutoMapperConfiguration.MappingExpressions);

using (SecurityContext.OpenSystemScope())
{
    var recMan = new RecordManager(context, true, false);

    #region warehouses
    #region << ***Create record*** Id: 555c0178-9ba0-48ff-a251-344971a384fe (warehouse) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""555c0178-9ba0-48ff-a251-344971a384fe"",
  ""designation"": ""Werkstatt""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: ce9efb78-ac56-48fb-a5e2-5b6850f60ba9 (warehouse) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""ce9efb78-ac56-48fb-a5e2-5b6850f60ba9"",
  ""designation"": ""Steffni""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse", rec);
        
    }
    #endregion


    #endregion

    #region warehouse locations
    #region << ***Create record*** Id: 006837f4-e535-11ef-9edf-bb497c32447b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006837f4-e535-11ef-9edf-bb497c32447b"",
  ""designation"": "" Murr 1"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0068fba8-e535-11ef-9ee0-6384bb9cafe2 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0068fba8-e535-11ef-9ee0-6384bb9cafe2"",
  ""designation"": ""A-1"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00690eae-e535-11ef-9ee1-03f87aa95ac7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00690eae-e535-11ef-9ee1-03f87aa95ac7"",
  ""designation"": ""A-1-317"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00691d72-e535-11ef-9ee2-dfb969e673a8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00691d72-e535-11ef-9ee2-dfb969e673a8"",
  ""designation"": ""A-1-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00692eac-e535-11ef-9ee3-930fc6be5ab1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00692eac-e535-11ef-9ee3-930fc6be5ab1"",
  ""designation"": ""A-2"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00693d0c-e535-11ef-9ee4-c784a4ea603a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00693d0c-e535-11ef-9ee4-c784a4ea603a"",
  ""designation"": ""A-2-206"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00695300-e535-11ef-9ee5-1b91ba1059be (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00695300-e535-11ef-9ee5-1b91ba1059be"",
  ""designation"": ""A-2-207"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006967f0-e535-11ef-9ee6-4758aef67f2f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006967f0-e535-11ef-9ee6-4758aef67f2f"",
  ""designation"": ""A-2-208/209"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006979ca-e535-11ef-9ee7-ff53f919f7d9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006979ca-e535-11ef-9ee7-ff53f919f7d9"",
  ""designation"": ""A-2-209"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00698af0-e535-11ef-9ee8-5b6742c8a0d1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00698af0-e535-11ef-9ee8-5b6742c8a0d1"",
  ""designation"": ""A-2-210"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00699ba8-e535-11ef-9ee9-6bb574fe7750 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00699ba8-e535-11ef-9ee9-6bb574fe7750"",
  ""designation"": ""A-2-211"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0069ac1a-e535-11ef-9eea-6f3eb09a5d41 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0069ac1a-e535-11ef-9eea-6f3eb09a5d41"",
  ""designation"": ""A-2-212"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0069bc78-e535-11ef-9eeb-aff65ade364e (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0069bc78-e535-11ef-9eeb-aff65ade364e"",
  ""designation"": ""A-2-214"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0069ccae-e535-11ef-9eec-47cf55423ae2 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0069ccae-e535-11ef-9eec-47cf55423ae2"",
  ""designation"": ""A-2-251"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0069dcb2-e535-11ef-9eed-63ce1ecb94bb (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0069dcb2-e535-11ef-9eed-63ce1ecb94bb"",
  ""designation"": ""A-2-252"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0069ecc0-e535-11ef-9eee-a3148a8587f9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0069ecc0-e535-11ef-9eee-a3148a8587f9"",
  ""designation"": ""A-2-253"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0069fcd8-e535-11ef-9eef-233b1823e0a7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0069fcd8-e535-11ef-9eef-233b1823e0a7"",
  ""designation"": ""A-2-254"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a0cdc-e535-11ef-9ef0-77abd2a73897 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a0cdc-e535-11ef-9ef0-77abd2a73897"",
  ""designation"": ""A-2-255"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a1cea-e535-11ef-9ef1-4301883c3725 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a1cea-e535-11ef-9ef1-4301883c3725"",
  ""designation"": ""A-2-256"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a2cc6-e535-11ef-9ef2-9b69b3f7d196 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a2cc6-e535-11ef-9ef2-9b69b3f7d196"",
  ""designation"": ""A-2-257"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a3cac-e535-11ef-9ef3-a79aec151713 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a3cac-e535-11ef-9ef3-a79aec151713"",
  ""designation"": ""A-2-258"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a4ce2-e535-11ef-9ef4-3f396bebb721 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a4ce2-e535-11ef-9ef4-3f396bebb721"",
  ""designation"": ""A-2-259"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a5bec-e535-11ef-9ef5-ffddd7e1f5c9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a5bec-e535-11ef-9ef5-ffddd7e1f5c9"",
  ""designation"": ""A-2-260"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a697a-e535-11ef-9ef6-13a92232a316 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a697a-e535-11ef-9ef6-13a92232a316"",
  ""designation"": ""A-2-261"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a771c-e535-11ef-9ef7-67b7a4e042ff (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a771c-e535-11ef-9ef7-67b7a4e042ff"",
  ""designation"": ""A-2-262"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a84dc-e535-11ef-9ef8-b7b4a479d344 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a84dc-e535-11ef-9ef8-b7b4a479d344"",
  ""designation"": ""A-2-263"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006a95da-e535-11ef-9ef9-a7a188ffd798 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006a95da-e535-11ef-9ef9-a7a188ffd798"",
  ""designation"": ""A-2-264"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006aa53e-e535-11ef-9efa-c37181c7e462 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006aa53e-e535-11ef-9efa-c37181c7e462"",
  ""designation"": ""A-2-265"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ab560-e535-11ef-9efb-5fecd405c732 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ab560-e535-11ef-9efb-5fecd405c732"",
  ""designation"": ""A-2-266"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ac366-e535-11ef-9efc-4fa1598a94d6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ac366-e535-11ef-9efc-4fa1598a94d6"",
  ""designation"": ""A-2-267"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ad284-e535-11ef-9efd-87073934ead8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ad284-e535-11ef-9efd-87073934ead8"",
  ""designation"": ""A-2-268"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ae22e-e535-11ef-9efe-6bbb3cd5d6fd (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ae22e-e535-11ef-9efe-6bbb3cd5d6fd"",
  ""designation"": ""A-2-269"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006af55c-e535-11ef-9eff-13c84a0b64e5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006af55c-e535-11ef-9eff-13c84a0b64e5"",
  ""designation"": ""A-2-270"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b04b6-e535-11ef-9f00-97ab39804907 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b04b6-e535-11ef-9f00-97ab39804907"",
  ""designation"": ""A-2-271"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b1280-e535-11ef-9f01-17b9e34a1e3f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b1280-e535-11ef-9f01-17b9e34a1e3f"",
  ""designation"": ""A-2-272"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b2176-e535-11ef-9f02-eb5887aebc2b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b2176-e535-11ef-9f02-eb5887aebc2b"",
  ""designation"": ""A-2-273"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b2ffe-e535-11ef-9f03-87a0fab64b09 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b2ffe-e535-11ef-9f03-87a0fab64b09"",
  ""designation"": ""A-2-274"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b3df0-e535-11ef-9f04-b79249cb54e8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b3df0-e535-11ef-9f04-b79249cb54e8"",
  ""designation"": ""A-2-275"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b4d90-e535-11ef-9f05-3b92175f5444 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b4d90-e535-11ef-9f05-3b92175f5444"",
  ""designation"": ""A-2-276"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b5bb4-e535-11ef-9f06-5f78e0740cdd (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b5bb4-e535-11ef-9f06-5f78e0740cdd"",
  ""designation"": ""A-2-277"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b6910-e535-11ef-9f07-33755039ca41 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b6910-e535-11ef-9f07-33755039ca41"",
  ""designation"": ""A-2-278"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b76e4-e535-11ef-9f08-1320f4fb3535 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b76e4-e535-11ef-9f08-1320f4fb3535"",
  ""designation"": ""A-2-279"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b84a4-e535-11ef-9f09-8fe96038a403 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b84a4-e535-11ef-9f09-8fe96038a403"",
  ""designation"": ""A-2-280"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006b9106-e535-11ef-9f0a-43ac85b88804 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006b9106-e535-11ef-9f0a-43ac85b88804"",
  ""designation"": ""A-2-281"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ba1fa-e535-11ef-9f0b-47d4ddb3604c (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ba1fa-e535-11ef-9f0b-47d4ddb3604c"",
  ""designation"": ""A-2-282"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006bafba-e535-11ef-9f0c-e7c2e0e26390 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006bafba-e535-11ef-9f0c-e7c2e0e26390"",
  ""designation"": ""A-2-283"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006bbe6a-e535-11ef-9f0d-0bab64ed8922 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006bbe6a-e535-11ef-9f0d-0bab64ed8922"",
  ""designation"": ""A-2-284"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006bccc0-e535-11ef-9f0e-63544841f947 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006bccc0-e535-11ef-9f0e-63544841f947"",
  ""designation"": ""A-2-285"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006bda58-e535-11ef-9f0f-5fb6ab789cc7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006bda58-e535-11ef-9f0f-5fb6ab789cc7"",
  ""designation"": ""A-2-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006beaa2-e535-11ef-9f10-7393a9c86321 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006beaa2-e535-11ef-9f10-7393a9c86321"",
  ""designation"": ""A-3     A-5-305     Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006bf89e-e535-11ef-9f11-1fbef9f77662 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006bf89e-e535-11ef-9f11-1fbef9f77662"",
  ""designation"": ""A-3-301"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c0604-e535-11ef-9f12-3766d2e93c2f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c0604-e535-11ef-9f12-3766d2e93c2f"",
  ""designation"": ""A-3-302"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c1518-e535-11ef-9f13-f33734870f1f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c1518-e535-11ef-9f13-f33734870f1f"",
  ""designation"": ""A-3-303"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c2288-e535-11ef-9f14-0b44111e0044 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c2288-e535-11ef-9f14-0b44111e0044"",
  ""designation"": ""A-3-304"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c2ff8-e535-11ef-9f15-9b512e2aba1b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c2ff8-e535-11ef-9f15-9b512e2aba1b"",
  ""designation"": ""A-3-305/306/308"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c3fa2-e535-11ef-9f16-2f30299b007c (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c3fa2-e535-11ef-9f16-2f30299b007c"",
  ""designation"": ""A-3-307"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c4d26-e535-11ef-9f17-df2f435d83bb (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c4d26-e535-11ef-9f17-df2f435d83bb"",
  ""designation"": ""A-3-309"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c5c6c-e535-11ef-9f18-0b4cd4d8f474 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c5c6c-e535-11ef-9f18-0b4cd4d8f474"",
  ""designation"": ""A-3-310"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c6ed2-e535-11ef-9f19-cff654e9d828 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c6ed2-e535-11ef-9f19-cff654e9d828"",
  ""designation"": ""A-3-311"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c7cb0-e535-11ef-9f1a-1f4acdb37fb8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c7cb0-e535-11ef-9f1a-1f4acdb37fb8"",
  ""designation"": ""A-3-313"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c8cc8-e535-11ef-9f1b-2b78c8b4cebc (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c8cc8-e535-11ef-9f1b-2b78c8b4cebc"",
  ""designation"": ""A-3-314"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006c9a6a-e535-11ef-9f1c-b3d4fb2d3594 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006c9a6a-e535-11ef-9f1c-b3d4fb2d3594"",
  ""designation"": ""A-3-315"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ca956-e535-11ef-9f1d-ef9549f41dfb (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ca956-e535-11ef-9f1d-ef9549f41dfb"",
  ""designation"": ""A-3-316"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006cb752-e535-11ef-9f1e-fb506f2e8916 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006cb752-e535-11ef-9f1e-fb506f2e8916"",
  ""designation"": ""A-3-318"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006cc4b8-e535-11ef-9f1f-0bf7cc69dd42 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006cc4b8-e535-11ef-9f1f-0bf7cc69dd42"",
  ""designation"": ""A-3-319"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006cd796-e535-11ef-9f20-ffa407d6ec63 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006cd796-e535-11ef-9f20-ffa407d6ec63"",
  ""designation"": ""A-3-321"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ce4a2-e535-11ef-9f21-7778ec30ca4a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ce4a2-e535-11ef-9f21-7778ec30ca4a"",
  ""designation"": ""A-3-322"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006cf15e-e535-11ef-9f22-d3d68e6fd483 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006cf15e-e535-11ef-9f22-d3d68e6fd483"",
  ""designation"": ""A-3-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d0108-e535-11ef-9f23-978f0d587916 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d0108-e535-11ef-9f23-978f0d587916"",
  ""designation"": ""A-4"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d0ea0-e535-11ef-9f24-cf8b3b263139 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d0ea0-e535-11ef-9f24-cf8b3b263139"",
  ""designation"": ""A-4-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d1d46-e535-11ef-9f25-a7c6e3ddce4b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d1d46-e535-11ef-9f25-a7c6e3ddce4b"",
  ""designation"": ""A-5"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d2b1a-e535-11ef-9f26-2f37977b2f9f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d2b1a-e535-11ef-9f26-2f37977b2f9f"",
  ""designation"": ""A-5-501"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d389e-e535-11ef-9f27-f3e9a446e0b0 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d389e-e535-11ef-9f27-f3e9a446e0b0"",
  ""designation"": ""A-5-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d4a78-e535-11ef-9f28-afd299ae05a6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d4a78-e535-11ef-9f28-afd299ae05a6"",
  ""designation"": ""B-4"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d58b0-e535-11ef-9f29-ab70dbea6a1b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d58b0-e535-11ef-9f29-ab70dbea6a1b"",
  ""designation"": ""B-5-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d6648-e535-11ef-9f2a-ebba39debc56 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d6648-e535-11ef-9f2a-ebba39debc56"",
  ""designation"": ""C-1"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d755c-e535-11ef-9f2b-5fa175f60ad0 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d755c-e535-11ef-9f2b-5fa175f60ad0"",
  ""designation"": ""C-1-199"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d8254-e535-11ef-9f2c-bbdbf576a2b6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d8254-e535-11ef-9f2c-bbdbf576a2b6"",
  ""designation"": ""C-1-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d8f74-e535-11ef-9f2d-5fbd64f48d86 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d8f74-e535-11ef-9f2d-5fbd64f48d86"",
  ""designation"": ""C-2-201"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006d9f5a-e535-11ef-9f2e-731ae76edf6f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006d9f5a-e535-11ef-9f2e-731ae76edf6f"",
  ""designation"": ""C-2-202"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006dac16-e535-11ef-9f2f-677c9b5e7ab0 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006dac16-e535-11ef-9f2f-677c9b5e7ab0"",
  ""designation"": ""C-2-203"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006dba4e-e535-11ef-9f30-c32b9073a233 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006dba4e-e535-11ef-9f30-c32b9073a233"",
  ""designation"": ""C-2-204"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006dc796-e535-11ef-9f31-0356a0196490 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006dc796-e535-11ef-9f31-0356a0196490"",
  ""designation"": ""C-2-205"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006dd452-e535-11ef-9f32-2799f3fe76c9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006dd452-e535-11ef-9f32-2799f3fe76c9"",
  ""designation"": ""C-2-206"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006de352-e535-11ef-9f33-137306c98fe5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006de352-e535-11ef-9f33-137306c98fe5"",
  ""designation"": ""C-2-207"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006df1e4-e535-11ef-9f34-db4ec61c5eb7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006df1e4-e535-11ef-9f34-db4ec61c5eb7"",
  ""designation"": ""C-2-208"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006dff7c-e535-11ef-9f35-33f86bddc015 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006dff7c-e535-11ef-9f35-33f86bddc015"",
  ""designation"": ""C-2-209"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e0f8a-e535-11ef-9f36-3b37cde76191 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e0f8a-e535-11ef-9f36-3b37cde76191"",
  ""designation"": ""C-2-210"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e1d36-e535-11ef-9f37-3703f3550998 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e1d36-e535-11ef-9f37-3703f3550998"",
  ""designation"": ""C-2-211"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e2ac4-e535-11ef-9f38-ef4b05fd276d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e2ac4-e535-11ef-9f38-ef4b05fd276d"",
  ""designation"": ""C-2-212"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e3bf4-e535-11ef-9f39-abb831e47766 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e3bf4-e535-11ef-9f39-abb831e47766"",
  ""designation"": ""C-2-213"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e49aa-e535-11ef-9f3a-2bfbd1227886 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e49aa-e535-11ef-9f3a-2bfbd1227886"",
  ""designation"": ""C-2-214"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e5846-e535-11ef-9f3b-e70f3fda3600 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e5846-e535-11ef-9f3b-e70f3fda3600"",
  ""designation"": ""C-2-215"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e6606-e535-11ef-9f3c-6b21ea985eb3 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e6606-e535-11ef-9f3c-6b21ea985eb3"",
  ""designation"": ""C-2-216"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e734e-e535-11ef-9f3d-bfb47f80a1e1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e734e-e535-11ef-9f3d-bfb47f80a1e1"",
  ""designation"": ""C-2-217"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e82da-e535-11ef-9f3e-93b7422921f6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e82da-e535-11ef-9f3e-93b7422921f6"",
  ""designation"": ""C-2-218"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e907c-e535-11ef-9f3f-ab1e0781c95d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e907c-e535-11ef-9f3f-ab1e0781c95d"",
  ""designation"": ""C-2-219"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006e9de2-e535-11ef-9f40-5b9adda940e7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006e9de2-e535-11ef-9f40-5b9adda940e7"",
  ""designation"": ""C-2-220"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006eaf58-e535-11ef-9f41-d30690b072d7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006eaf58-e535-11ef-9f41-d30690b072d7"",
  ""designation"": ""C-2-221"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ebcdc-e535-11ef-9f42-931d08e84b68 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ebcdc-e535-11ef-9f42-931d08e84b68"",
  ""designation"": ""C-2-222"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ecc2c-e535-11ef-9f43-0766fee409e6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ecc2c-e535-11ef-9f43-0766fee409e6"",
  ""designation"": ""C-2-223"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006eda8c-e535-11ef-9f44-7731500a66e7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006eda8c-e535-11ef-9f44-7731500a66e7"",
  ""designation"": ""C-2-251"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ee806-e535-11ef-9f45-47987722496d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ee806-e535-11ef-9f45-47987722496d"",
  ""designation"": ""C-2-252"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006ef6c0-e535-11ef-9f46-1b55c4c56581 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006ef6c0-e535-11ef-9f46-1b55c4c56581"",
  ""designation"": ""C-2-253"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f0476-e535-11ef-9f47-1b6df2d28fa1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f0476-e535-11ef-9f47-1b6df2d28fa1"",
  ""designation"": ""C-2-254"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f1222-e535-11ef-9f48-0f97e65df9e5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f1222-e535-11ef-9f48-0f97e65df9e5"",
  ""designation"": ""C-2-255"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f215e-e535-11ef-9f49-c776d6a9db88 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f215e-e535-11ef-9f49-c776d6a9db88"",
  ""designation"": ""C-2-256"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f2ef6-e535-11ef-9f4a-3f87b7960aed (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f2ef6-e535-11ef-9f4a-3f87b7960aed"",
  ""designation"": ""C-2-257"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f3c5c-e535-11ef-9f4b-931ee866e836 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f3c5c-e535-11ef-9f4b-931ee866e836"",
  ""designation"": ""C-2-258"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f4c2e-e535-11ef-9f4c-d3d088a5735f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f4c2e-e535-11ef-9f4c-d3d088a5735f"",
  ""designation"": ""C-2-259"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f5994-e535-11ef-9f4d-ef3a659f00f3 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f5994-e535-11ef-9f4d-ef3a659f00f3"",
  ""designation"": ""C-2-260"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f66fa-e535-11ef-9f4e-cff7791a0430 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f66fa-e535-11ef-9f4e-cff7791a0430"",
  ""designation"": ""C-2-261"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f764a-e535-11ef-9f4f-97833ba7ad31 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f764a-e535-11ef-9f4f-97833ba7ad31"",
  ""designation"": ""C-2-262"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f887e-e535-11ef-9f50-870b216dc317 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f887e-e535-11ef-9f50-870b216dc317"",
  ""designation"": ""C-2-263"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006f96c0-e535-11ef-9f51-7b340f2b7b9b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006f96c0-e535-11ef-9f51-7b340f2b7b9b"",
  ""designation"": ""C-2-264"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006fa4da-e535-11ef-9f52-53d667280f1a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006fa4da-e535-11ef-9f52-53d667280f1a"",
  ""designation"": ""C-2-265"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006fb0c4-e535-11ef-9f53-2764b80ed7bd (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006fb0c4-e535-11ef-9f53-2764b80ed7bd"",
  ""designation"": ""C-2-266"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006fbc7c-e535-11ef-9f54-9b192de830f5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006fbc7c-e535-11ef-9f54-9b192de830f5"",
  ""designation"": ""C-2-267"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006fc848-e535-11ef-9f55-633d3b411ccf (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006fc848-e535-11ef-9f55-633d3b411ccf"",
  ""designation"": ""C-2-268"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006fef94-e535-11ef-9f56-2b0db8a98296 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006fef94-e535-11ef-9f56-2b0db8a98296"",
  ""designation"": ""C-2-269"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 006fffca-e535-11ef-9f57-2fd66c1dfce5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""006fffca-e535-11ef-9f57-2fd66c1dfce5"",
  ""designation"": ""C-2-270"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00700cb8-e535-11ef-9f58-d3f3956b1379 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00700cb8-e535-11ef-9f58-d3f3956b1379"",
  ""designation"": ""C-2-271"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070196a-e535-11ef-9f59-0f2116669c9d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070196a-e535-11ef-9f59-0f2116669c9d"",
  ""designation"": ""C-2-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007025cc-e535-11ef-9f5a-f3ff0fb1ef16 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007025cc-e535-11ef-9f5a-f3ff0fb1ef16"",
  ""designation"": ""C-3"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007031de-e535-11ef-9f5b-c777103bdfac (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007031de-e535-11ef-9f5b-c777103bdfac"",
  ""designation"": ""C-3-301"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00703e40-e535-11ef-9f5c-6761291ef83e (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00703e40-e535-11ef-9f5c-6761291ef83e"",
  ""designation"": ""C-3-302"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00704aa2-e535-11ef-9f5d-db506a609418 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00704aa2-e535-11ef-9f5d-db506a609418"",
  ""designation"": ""C-3-303"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070570e-e535-11ef-9f5e-5330acf2e19e (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070570e-e535-11ef-9f5e-5330acf2e19e"",
  ""designation"": ""C-3-304"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070633e-e535-11ef-9f5f-37cedd918a5f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070633e-e535-11ef-9f5f-37cedd918a5f"",
  ""designation"": ""C-3-305"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00706f96-e535-11ef-9f60-c3cc402e6370 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00706f96-e535-11ef-9f60-c3cc402e6370"",
  ""designation"": ""C-3-306"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00708f62-e535-11ef-9f61-ef690da97406 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00708f62-e535-11ef-9f61-ef690da97406"",
  ""designation"": ""C-3-307"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070a74a-e535-11ef-9f62-6f88250de358 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070a74a-e535-11ef-9f62-6f88250de358"",
  ""designation"": ""C-3-308"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070b87a-e535-11ef-9f63-6f52f78e4894 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070b87a-e535-11ef-9f63-6f52f78e4894"",
  ""designation"": ""C-3-309"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070cc48-e535-11ef-9f64-b72db0dfd9fc (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070cc48-e535-11ef-9f64-b72db0dfd9fc"",
  ""designation"": ""C-3-310"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070dd5a-e535-11ef-9f65-c7986b216a01 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070dd5a-e535-11ef-9f65-c7986b216a01"",
  ""designation"": ""C-3-311"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0070ef48-e535-11ef-9f66-bfb32f4fbc7d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0070ef48-e535-11ef-9f66-bfb32f4fbc7d"",
  ""designation"": ""C-3-312"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007102da-e535-11ef-9f67-e395031caf2b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007102da-e535-11ef-9f67-e395031caf2b"",
  ""designation"": ""C-3-313"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007113ec-e535-11ef-9f68-33311e675154 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007113ec-e535-11ef-9f68-33311e675154"",
  ""designation"": ""C-3-318"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00712422-e535-11ef-9f69-177ed445a8b8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00712422-e535-11ef-9f69-177ed445a8b8"",
  ""designation"": ""C-3-320"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00713462-e535-11ef-9f6a-670cce3e9aa3 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00713462-e535-11ef-9f6a-670cce3e9aa3"",
  ""designation"": ""C-3-351"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00714484-e535-11ef-9f6b-8f0e71537df8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00714484-e535-11ef-9f6b-8f0e71537df8"",
  ""designation"": ""C-3-352"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00715488-e535-11ef-9f6c-4fd59b79be99 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00715488-e535-11ef-9f6c-4fd59b79be99"",
  ""designation"": ""C-3-353"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071646e-e535-11ef-9f6d-8f142ededc87 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071646e-e535-11ef-9f6d-8f142ededc87"",
  ""designation"": ""C-3-354"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00717436-e535-11ef-9f6e-5fe18c2b181d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00717436-e535-11ef-9f6e-5fe18c2b181d"",
  ""designation"": ""C-3-355"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00718408-e535-11ef-9f6f-ebccd0efd447 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00718408-e535-11ef-9f6f-ebccd0efd447"",
  ""designation"": ""C-3-356"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007194c0-e535-11ef-9f70-0b7dd0d4a5d9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007194c0-e535-11ef-9f70-0b7dd0d4a5d9"",
  ""designation"": ""C-3-357"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071a5d2-e535-11ef-9f71-27e528939a5a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071a5d2-e535-11ef-9f71-27e528939a5a"",
  ""designation"": ""C-3-358"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071b6e4-e535-11ef-9f72-539ac4bf273c (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071b6e4-e535-11ef-9f72-539ac4bf273c"",
  ""designation"": ""C-3-359"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071c7f6-e535-11ef-9f73-b3b2c0dd8c45 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071c7f6-e535-11ef-9f73-b3b2c0dd8c45"",
  ""designation"": ""C-3-360"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071d8cc-e535-11ef-9f74-43104ac489c8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071d8cc-e535-11ef-9f74-43104ac489c8"",
  ""designation"": ""C-3-361"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071e998-e535-11ef-9f75-f3e8cecae114 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071e998-e535-11ef-9f75-f3e8cecae114"",
  ""designation"": ""C-3-362"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0071fab4-e535-11ef-9f76-9be2d4dd81b5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0071fab4-e535-11ef-9f76-9be2d4dd81b5"",
  ""designation"": ""C-3-363"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00720d10-e535-11ef-9f77-77b4ff6279ae (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00720d10-e535-11ef-9f77-77b4ff6279ae"",
  ""designation"": ""C-3-364"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00721af8-e535-11ef-9f78-a3e52870d377 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00721af8-e535-11ef-9f78-a3e52870d377"",
  ""designation"": ""C-3-365"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00722a3e-e535-11ef-9f79-a38e0b21bc7d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00722a3e-e535-11ef-9f79-a38e0b21bc7d"",
  ""designation"": ""C-3-366"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007237c2-e535-11ef-9f7a-7f71525ebbd1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007237c2-e535-11ef-9f7a-7f71525ebbd1"",
  ""designation"": ""C-3-367"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00724460-e535-11ef-9f7b-4fcb2f67b57b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00724460-e535-11ef-9f7b-4fcb2f67b57b"",
  ""designation"": ""C-3-368"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00725310-e535-11ef-9f7c-6f05d76afb11 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00725310-e535-11ef-9f7c-6f05d76afb11"",
  ""designation"": ""C-3-369"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00726026-e535-11ef-9f7d-db42df95cd18 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00726026-e535-11ef-9f7d-db42df95cd18"",
  ""designation"": ""C-3-370"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00726ca6-e535-11ef-9f7e-cb826637d674 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00726ca6-e535-11ef-9f7e-cb826637d674"",
  ""designation"": ""C-3-371"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00727aa2-e535-11ef-9f7f-739e1fb1898d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00727aa2-e535-11ef-9f7f-739e1fb1898d"",
  ""designation"": ""C-3-372"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00728a38-e535-11ef-9f80-4b4e759de665 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00728a38-e535-11ef-9f80-4b4e759de665"",
  ""designation"": ""C-3-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007297e4-e535-11ef-9f81-7b8d9e504a13 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007297e4-e535-11ef-9f81-7b8d9e504a13"",
  ""designation"": ""C-4"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0072a8ba-e535-11ef-9f82-23b80d889461 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0072a8ba-e535-11ef-9f82-23b80d889461"",
  ""designation"": ""C-4-401"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0072baf8-e535-11ef-9f83-8bcbfdca8229 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0072baf8-e535-11ef-9f83-8bcbfdca8229"",
  ""designation"": ""C-4-402"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0072cb10-e535-11ef-9f84-7bbaef65e055 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0072cb10-e535-11ef-9f84-7bbaef65e055"",
  ""designation"": ""C-4-403"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0072d984-e535-11ef-9f85-672bdd7dceb0 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0072d984-e535-11ef-9f85-672bdd7dceb0"",
  ""designation"": ""C-4-404"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0072e906-e535-11ef-9f86-07195b7df0c6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0072e906-e535-11ef-9f86-07195b7df0c6"",
  ""designation"": ""C-4-405"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0072f7fc-e535-11ef-9f87-dfb4114e410b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0072f7fc-e535-11ef-9f87-dfb4114e410b"",
  ""designation"": ""C-4-406"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073062a-e535-11ef-9f88-afd38b9778cf (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073062a-e535-11ef-9f88-afd38b9778cf"",
  ""designation"": ""C-4-407"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00731728-e535-11ef-9f89-d30e0b23e3b4 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00731728-e535-11ef-9f89-d30e0b23e3b4"",
  ""designation"": ""C-4-408"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007325d8-e535-11ef-9f8a-d30d1db6e86d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007325d8-e535-11ef-9f8a-d30d1db6e86d"",
  ""designation"": ""C-4-409"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00733442-e535-11ef-9f8b-9fdc54dc8f66 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00733442-e535-11ef-9f8b-9fdc54dc8f66"",
  ""designation"": ""C-4-410"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007343e2-e535-11ef-9f8c-c76d8a5a836a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007343e2-e535-11ef-9f8c-c76d8a5a836a"",
  ""designation"": ""C-4-411"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007351d4-e535-11ef-9f8d-ff6ecc225a60 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007351d4-e535-11ef-9f8d-ff6ecc225a60"",
  ""designation"": ""C-4-412"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00735f62-e535-11ef-9f8e-d74bfde18810 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00735f62-e535-11ef-9f8e-d74bfde18810"",
  ""designation"": ""C-4-413"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00736cc8-e535-11ef-9f8f-5b72a1f397a6 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00736cc8-e535-11ef-9f8f-5b72a1f397a6"",
  ""designation"": ""C-4-414"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007379e8-e535-11ef-9f90-9b3facd2f903 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007379e8-e535-11ef-9f90-9b3facd2f903"",
  ""designation"": ""C-4-415"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007389ba-e535-11ef-9f91-6fd8919979b7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007389ba-e535-11ef-9f91-6fd8919979b7"",
  ""designation"": ""C-4-416"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00739798-e535-11ef-9f92-b3e2a8aca9f9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00739798-e535-11ef-9f92-b3e2a8aca9f9"",
  ""designation"": ""C-4-417"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073a4fe-e535-11ef-9f93-6398eecae145 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073a4fe-e535-11ef-9f93-6398eecae145"",
  ""designation"": ""C-4-418"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073b4a8-e535-11ef-9f94-07d323cd444f (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073b4a8-e535-11ef-9f94-07d323cd444f"",
  ""designation"": ""C-4-419"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073c286-e535-11ef-9f95-9ffbcbb7a709 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073c286-e535-11ef-9f95-9ffbcbb7a709"",
  ""designation"": ""C-4-451"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073cfe2-e535-11ef-9f96-afd2e39cbb37 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073cfe2-e535-11ef-9f96-afd2e39cbb37"",
  ""designation"": ""C-4-452"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073dea6-e535-11ef-9f97-bba4a596b1ab (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073dea6-e535-11ef-9f97-bba4a596b1ab"",
  ""designation"": ""C-4-453"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073ec02-e535-11ef-9f98-3f83e9108949 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073ec02-e535-11ef-9f98-3f83e9108949"",
  ""designation"": ""C-4-454"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0073fb5c-e535-11ef-9f99-27717ee98dd5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0073fb5c-e535-11ef-9f99-27717ee98dd5"",
  ""designation"": ""C-4-455"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074094e-e535-11ef-9f9a-ab84ed7e494e (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074094e-e535-11ef-9f9a-ab84ed7e494e"",
  ""designation"": ""C-4-456"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007418c6-e535-11ef-9f9b-4fcc9deee4a1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007418c6-e535-11ef-9f9b-4fcc9deee4a1"",
  ""designation"": ""C-4-457"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007427c6-e535-11ef-9f9c-fb890c6a6a75 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007427c6-e535-11ef-9f9c-fb890c6a6a75"",
  ""designation"": ""C-4-458"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00743572-e535-11ef-9f9d-3fb843a64901 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00743572-e535-11ef-9f9d-3fb843a64901"",
  ""designation"": ""C-4-459"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007442e2-e535-11ef-9f9e-d794ca081bb9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007442e2-e535-11ef-9f9e-d794ca081bb9"",
  ""designation"": ""C-4-460"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00745278-e535-11ef-9f9f-afc7d69e9e23 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00745278-e535-11ef-9f9f-afc7d69e9e23"",
  ""designation"": ""C-4-461"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007460e2-e535-11ef-9fa0-277066289106 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007460e2-e535-11ef-9fa0-277066289106"",
  ""designation"": ""C-4-462"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007472a8-e535-11ef-9fa1-eb7747f899b7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007472a8-e535-11ef-9fa1-eb7747f899b7"",
  ""designation"": ""C-4-463"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074825c-e535-11ef-9fa2-87dab048d0eb (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074825c-e535-11ef-9fa2-87dab048d0eb"",
  ""designation"": ""C-4-464"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007490a8-e535-11ef-9fa3-43703b7087dc (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007490a8-e535-11ef-9fa3-43703b7087dc"",
  ""designation"": ""C-4-465"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074a426-e535-11ef-9fa4-1b6506a349c9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074a426-e535-11ef-9fa4-1b6506a349c9"",
  ""designation"": ""C-4-466"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074b2b8-e535-11ef-9fa5-971da69cba46 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074b2b8-e535-11ef-9fa5-971da69cba46"",
  ""designation"": ""C-4-467"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074c294-e535-11ef-9fa6-bbd3e951b713 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074c294-e535-11ef-9fa6-bbd3e951b713"",
  ""designation"": ""C-4-468"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074d112-e535-11ef-9fa7-6f77812eb7c1 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074d112-e535-11ef-9fa7-6f77812eb7c1"",
  ""designation"": ""C-4-469"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074df54-e535-11ef-9fa8-b33f3a63df77 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074df54-e535-11ef-9fa8-b33f3a63df77"",
  ""designation"": ""C-4-470"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074eee0-e535-11ef-9fa9-cbf8a1e28556 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074eee0-e535-11ef-9fa9-cbf8a1e28556"",
  ""designation"": ""C-4-471"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0074fd18-e535-11ef-9faa-9f600876c27a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0074fd18-e535-11ef-9faa-9f600876c27a"",
  ""designation"": ""C-4-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00750cea-e535-11ef-9fab-e703d2d611d5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00750cea-e535-11ef-9fab-e703d2d611d5"",
  ""designation"": ""C-5"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00751bf4-e535-11ef-9fac-1f9c275a2678 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00751bf4-e535-11ef-9fac-1f9c275a2678"",
  ""designation"": ""C-5-550"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00752a36-e535-11ef-9fad-330db3b4ef10 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00752a36-e535-11ef-9fad-330db3b4ef10"",
  ""designation"": ""C-5-551"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007539d6-e535-11ef-9fae-23dd6f2f1ea5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007539d6-e535-11ef-9fae-23dd6f2f1ea5"",
  ""designation"": ""C-5-552"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075485e-e535-11ef-9faf-83b5ccb23289 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075485e-e535-11ef-9faf-83b5ccb23289"",
  ""designation"": ""C-5-553"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075563c-e535-11ef-9fb0-f70e9c62c220 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075563c-e535-11ef-9fb0-f70e9c62c220"",
  ""designation"": ""C-5-554"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00756636-e535-11ef-9fb1-870137d4012d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00756636-e535-11ef-9fb1-870137d4012d"",
  ""designation"": ""C-5-555"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007573c4-e535-11ef-9fb2-230919414699 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007573c4-e535-11ef-9fb2-230919414699"",
  ""designation"": ""C-5-556"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00758274-e535-11ef-9fb3-6ff0ca7a0f44 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00758274-e535-11ef-9fb3-6ff0ca7a0f44"",
  ""designation"": ""C-5-557"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075908e-e535-11ef-9fb4-8bd6ee870981 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075908e-e535-11ef-9fb4-8bd6ee870981"",
  ""designation"": ""C-5-558"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075a236-e535-11ef-9fb5-13ffe62b1687 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075a236-e535-11ef-9fb5-13ffe62b1687"",
  ""designation"": ""C-5-559"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075b366-e535-11ef-9fb6-278b349656ad (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075b366-e535-11ef-9fb6-278b349656ad"",
  ""designation"": ""C-5-560"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075c1ee-e535-11ef-9fb7-3ff68b34f009 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075c1ee-e535-11ef-9fb7-3ff68b34f009"",
  ""designation"": ""C-5-561"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075d1ac-e535-11ef-9fb8-cb174e471766 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075d1ac-e535-11ef-9fb8-cb174e471766"",
  ""designation"": ""C-5-562"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075e066-e535-11ef-9fb9-af549fa3c4bc (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075e066-e535-11ef-9fb9-af549fa3c4bc"",
  ""designation"": ""C-5-563"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075ee6c-e535-11ef-9fba-bf3ca3135dd4 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075ee6c-e535-11ef-9fba-bf3ca3135dd4"",
  ""designation"": ""C-5-564"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0075fdbc-e535-11ef-9fbb-437c6f7e6bf7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0075fdbc-e535-11ef-9fbb-437c6f7e6bf7"",
  ""designation"": ""C-5-565"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00760b54-e535-11ef-9fbc-1b7eedeee94d (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00760b54-e535-11ef-9fbc-1b7eedeee94d"",
  ""designation"": ""C-5-566"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076189c-e535-11ef-9fbd-9fc3a5b0ba9c (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076189c-e535-11ef-9fbd-9fc3a5b0ba9c"",
  ""designation"": ""C-5-567"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076277e-e535-11ef-9fbe-cb41e96143e5 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076277e-e535-11ef-9fbe-cb41e96143e5"",
  ""designation"": ""C-5-568"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076352a-e535-11ef-9fbf-1f3093bb32bc (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076352a-e535-11ef-9fbf-1f3093bb32bc"",
  ""designation"": ""C-5-569"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007642fe-e535-11ef-9fc0-af809e16cc73 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007642fe-e535-11ef-9fc0-af809e16cc73"",
  ""designation"": ""C-5-570"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076523a-e535-11ef-9fc1-77657bf38b23 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076523a-e535-11ef-9fc1-77657bf38b23"",
  ""designation"": ""C-5-571"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00765fd2-e535-11ef-9fc2-63aabfb9683c (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00765fd2-e535-11ef-9fc2-63aabfb9683c"",
  ""designation"": ""D-1"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00766eaa-e535-11ef-9fc3-8ba82d6ae410 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00766eaa-e535-11ef-9fc3-8ba82d6ae410"",
  ""designation"": ""D-1-100"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00767cb0-e535-11ef-9fc4-17d32a2b252b (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00767cb0-e535-11ef-9fc4-17d32a2b252b"",
  ""designation"": ""D-1-101"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00768d72-e535-11ef-9fc5-9f0c158eb8fd (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00768d72-e535-11ef-9fc5-9f0c158eb8fd"",
  ""designation"": ""D-1-103"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00769ca4-e535-11ef-9fc6-5b92fcbe8f16 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00769ca4-e535-11ef-9fc6-5b92fcbe8f16"",
  ""designation"": ""D-1-104"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076aa78-e535-11ef-9fc7-7b8d12a410df (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076aa78-e535-11ef-9fc7-7b8d12a410df"",
  ""designation"": ""D-1-105"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076b8ec-e535-11ef-9fc8-33517c898bec (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076b8ec-e535-11ef-9fc8-33517c898bec"",
  ""designation"": ""D-1-106"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076c760-e535-11ef-9fc9-5f6b32f5e03e (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076c760-e535-11ef-9fc9-5f6b32f5e03e"",
  ""designation"": ""D-1-151"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076d4ee-e535-11ef-9fca-132856021886 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076d4ee-e535-11ef-9fca-132856021886"",
  ""designation"": ""D-1-152"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076e664-e535-11ef-9fcb-1bacf1e6f1d9 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076e664-e535-11ef-9fcb-1bacf1e6f1d9"",
  ""designation"": ""D-1-153"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0076f49c-e535-11ef-9fcc-a7e0870ef274 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0076f49c-e535-11ef-9fcc-a7e0870ef274"",
  ""designation"": ""D-4-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00770414-e535-11ef-9fcd-57423b3741c7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00770414-e535-11ef-9fcd-57423b3741c7"",
  ""designation"": ""D-4-Karton 2"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007713b4-e535-11ef-9fce-8bee8b4f9343 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007713b4-e535-11ef-9fce-8bee8b4f9343"",
  ""designation"": ""D-5"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00772066-e535-11ef-9fcf-e3220594c061 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00772066-e535-11ef-9fcf-e3220594c061"",
  ""designation"": ""D-5-501"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007732e0-e535-11ef-9fd0-dba5948ac0d8 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007732e0-e535-11ef-9fd0-dba5948ac0d8"",
  ""designation"": ""D-5-502"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 007741a4-e535-11ef-9fd1-bfa895e21505 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""007741a4-e535-11ef-9fd1-bfa895e21505"",
  ""designation"": ""D-5-504"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00774f5a-e535-11ef-9fd2-5f7240869819 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00774f5a-e535-11ef-9fd2-5f7240869819"",
  ""designation"": ""E-4-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00775f72-e535-11ef-9fd3-c75d051c5b4e (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00775f72-e535-11ef-9fd3-c75d051c5b4e"",
  ""designation"": ""Harting-Kiste 30"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00777908-e535-11ef-9fd5-13214007e0f3 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00777908-e535-11ef-9fd5-13214007e0f3"",
  ""designation"": ""Murr 1"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077892a-e535-11ef-9fd6-3f55ab6c1250 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077892a-e535-11ef-9fd6-3f55ab6c1250"",
  ""designation"": ""Murr 1-Kiste"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 00779690-e535-11ef-9fd7-cbc3d1770f53 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""00779690-e535-11ef-9fd7-cbc3d1770f53"",
  ""designation"": ""Murr 2-Karton"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077a612-e535-11ef-9fd8-dfb994a730da (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077a612-e535-11ef-9fd8-dfb994a730da"",
  ""designation"": ""Pilz-Kiste 40"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077b3e6-e535-11ef-9fd9-6f41facca821 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077b3e6-e535-11ef-9fd9-6f41facca821"",
  ""designation"": ""SIEM-10"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077c11a-e535-11ef-9fda-93a6d0de2ef7 (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077c11a-e535-11ef-9fda-93a6d0de2ef7"",
  ""designation"": ""Siemens-10"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077d074-e535-11ef-9fdb-0f66775ce51a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077d074-e535-11ef-9fdb-0f66775ce51a"",
  ""designation"": ""Siemens-Kiste 10"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077de0c-e535-11ef-9fdc-7bef658460dd (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077de0c-e535-11ef-9fdc-7bef658460dd"",
  ""designation"": ""Siemens-Kiste 11"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 0077eb68-e535-11ef-9fdd-3f41a423a96a (warehouse_location) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""0077eb68-e535-11ef-9fdd-3f41a423a96a"",
  ""designation"": ""Wagerl"",
  ""warehouse_id"": ""555c0178-9ba0-48ff-a251-344971a384fe""
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("warehouse_location", rec);
        
    }
    #endregion


    #endregion

    #region manufacturers

    #region << ***Create record*** Id: 8a0a55d6-0522-4f2f-82c6-f1fd6b946856 (manufacturer) >>

    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8a0a55d6-0522-4f2f-82c6-f1fd6b946856"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_ABB.png"",
      ""website"": ""http://new.abb.com;"",
      ""eplan_id"": ""3"",
      ""short_name"": ""ABB"",
      ""name"": ""ABB""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c888b246-aef2-4131-860c-8d07186495ed (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_BAL.png"",
      ""website"": ""https://www.balluff.com/"",
      ""eplan_id"": ""109"",
      ""short_name"": ""BAL"",
      ""name"": ""Balluff""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2e7aebe9-2eab-4116-b916-c4800c956e50 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2e7aebe9-2eab-4116-b916-c4800c956e50"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_ETN.png"",
      ""website"": ""www.eaton.com"",
      ""eplan_id"": ""197"",
      ""short_name"": ""ETN"",
      ""name"": ""Eaton""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 62267cd8-cbb0-4de6-a6b6-67fd82a06f44 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_FES.png"",
      ""website"": ""https://www.festo.com"",
      ""eplan_id"": ""17"",
      ""short_name"": ""FES"",
      ""name"": ""Festo""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_HAR.png"",
      ""website"": ""http://www.harting.com"",
      ""eplan_id"": ""22"",
      ""short_name"": ""HAR"",
      ""name"": ""HARTING Technology Group""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6d5ce8cf-750f-4bec-b52f-248416d670c3 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6d5ce8cf-750f-4bec-b52f-248416d670c3"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_HELU.png"",
      ""website"": ""http://www.helukabel.com"",
      ""eplan_id"": ""26"",
      ""short_name"": ""HELU"",
      ""name"": ""Helukabel""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5f0b2742-31ef-4339-99d7-47e59fc212fc (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5f0b2742-31ef-4339-99d7-47e59fc212fc"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_IFM.png"",
      ""website"": ""https://www.ifm.com/"",
      ""eplan_id"": ""28"",
      ""short_name"": ""IFM"",
      ""name"": ""ifm electronic""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7976e3b2-9e4a-4736-bbc3-83b009f88253 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_LAPP.png"",
      ""website"": ""http://www.lappkabel.com"",
      ""eplan_id"": ""35"",
      ""short_name"": ""LAPP"",
      ""name"": ""Lapp Group""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 50ee9a8a-2f60-4ac0-9e81-68007981bccd (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_MURR.png"",
      ""website"": ""https://www.murrelektronik.com"",
      ""eplan_id"": ""46"",
      ""short_name"": ""MURR"",
      ""name"": ""Murrelektronik""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1096e61d-a751-4d94-846c-56265f081581 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1096e61d-a751-4d94-846c-56265f081581"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_P%252BF.png"",
      ""website"": ""http://www.pepperl-fuchs.com/"",
      ""eplan_id"": ""51"",
      ""short_name"": ""P+F"",
      ""name"": ""Pepperl+Fuchs""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 87c181bf-9b04-4d16-9a65-9c38c719fac4 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""87c181bf-9b04-4d16-9a65-9c38c719fac4"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_PILZ.png"",
      ""website"": ""https://www.pilz.com/"",
      ""eplan_id"": ""53"",
      ""short_name"": ""PILZ"",
      ""name"": ""Pilz""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: aed8d379-e2b5-4ff4-8817-b03535f9c2b2 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_RIT.png"",
      ""website"": ""http://www.rittal.com"",
      ""eplan_id"": ""57"",
      ""short_name"": ""RIT"",
      ""name"": ""Rittal""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9f442816-d1be-43ef-a9d3-905447651081 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9f442816-d1be-43ef-a9d3-905447651081"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_SCHM.png"",
      ""website"": ""http://www.schmersal.com"",
      ""eplan_id"": ""118"",
      ""short_name"": ""SCHM"",
      ""name"": ""Schmersal""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 661a295d-65f4-41c9-9626-fa53bf0abb8c (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_SEW.png"",
      ""website"": ""http://www.sew-eurodrive.de"",
      ""eplan_id"": ""63"",
      ""short_name"": ""SEW"",
      ""name"": ""SEW-EURODRIVE""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 542e64c3-8fe0-47ec-adf7-a72163587c4a (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_SIE.png"",
      ""website"": ""http://www.siemens.de"",
      ""eplan_id"": ""65"",
      ""short_name"": ""SIE"",
      ""name"": ""Siemens""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_WAGO.png"",
      ""website"": """",
      ""eplan_id"": ""76"",
      ""short_name"": ""WAGO"",
      ""name"": ""WAGO""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 221cabde-2728-4004-9108-1b3f13d5ccbd (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_A-B.png"",
      ""website"": ""http://www.rockwellautomation.com/"",
      ""eplan_id"": ""1"",
      ""short_name"": ""A-B"",
      ""name"": ""Allen-Bradley""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 51b75e6d-306f-4f59-9815-56ef4ccdde15 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""51b75e6d-306f-4f59-9815-56ef4ccdde15"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_A-B_N.png"",
      ""website"": ""http://www.rockwellautomation.com/"",
      ""eplan_id"": ""2"",
      ""short_name"": ""A-B_N"",
      ""name"": ""Allen-Bradley (NFPA Data)""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: db90c72d-88f3-42b0-803c-403f4fccda13 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""db90c72d-88f3-42b0-803c-403f4fccda13"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_BUR.png"",
      ""website"": """",
      ""eplan_id"": ""9"",
      ""short_name"": ""BUR"",
      ""name"": ""B&R Industrial Automation""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cf9c2c01-8998-4779-b012-7969325189d5 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cf9c2c01-8998-4779-b012-7969325189d5"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_BACH.png"",
      ""website"": """",
      ""eplan_id"": ""5"",
      ""short_name"": ""BACH"",
      ""name"": ""bachmann Electronic""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5fae4026-3f29-4a28-9b1f-1a17e638b522 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5fae4026-3f29-4a28-9b1f-1a17e638b522"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_EUC.png"",
      ""website"": ""https://www.euchner.de"",
      ""eplan_id"": ""340"",
      ""short_name"": ""EUC"",
      ""name"": ""Euchner""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e58fb686-0627-4019-bf37-fa33d3b78d56 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e58fb686-0627-4019-bf37-fa33d3b78d56"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_EUC_N.png"",
      ""website"": """",
      ""eplan_id"": ""438"",
      ""short_name"": ""EUC_N"",
      ""name"": ""Euchner (NFPA Data)""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9c998708-8e74-4fd4-9cac-db6373d5eed1 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9c998708-8e74-4fd4-9cac-db6373d5eed1"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_FIN.png"",
      ""website"": """",
      ""eplan_id"": ""18"",
      ""short_name"": ""FIN"",
      ""name"": ""FINDER""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 911e7e02-cce8-4569-8dfb-7e2813676567 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""911e7e02-cce8-4569-8dfb-7e2813676567"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_HIR.png"",
      ""website"": ""http://www.beldensolutions.com"",
      ""eplan_id"": ""101"",
      ""short_name"": ""HIR"",
      ""name"": ""Hirschmann""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_ICO.png"",
      ""website"": ""http://www.icotek.com/"",
      ""eplan_id"": ""27"",
      ""short_name"": ""ICO"",
      ""name"": ""Icotek""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c7376656-14da-495b-b476-c7e28be2dfc9 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c7376656-14da-495b-b476-c7e28be2dfc9"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_IGUS.png"",
      ""website"": """",
      ""eplan_id"": ""29"",
      ""short_name"": ""IGUS"",
      ""name"": ""igus""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d3894e51-79a2-409a-bd2d-905f16454378 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_ILME.png"",
      ""website"": ""http://www.ilme.com"",
      ""eplan_id"": ""30"",
      ""short_name"": ""ILME"",
      ""name"": ""ILME""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fa3eb3f5-71b5-48fc-8193-c06f57e05248 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fa3eb3f5-71b5-48fc-8193-c06f57e05248"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_LUM.png"",
      ""website"": ""http://www.beldensolutions.com"",
      ""eplan_id"": ""102"",
      ""short_name"": ""LUM"",
      ""name"": ""Lumberg""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 788353c4-fa6e-45fe-84fd-03db3f6797f6 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""788353c4-fa6e-45fe-84fd-03db3f6797f6"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_OBO.png"",
      ""website"": """",
      ""eplan_id"": ""466"",
      ""short_name"": ""OBO"",
      ""name"": ""OBO BETTERMANN""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 85042b1c-f338-4da2-8cf7-0e242cf8bfb6 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_PXC.png"",
      ""website"": ""www.phoenixcontact.com"",
      ""eplan_id"": ""55"",
      ""short_name"": ""PXC"",
      ""name"": ""Phoenix Contact""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b2247a2f-33e0-4dda-ba68-fa07ee182cc1 (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_SE.png"",
      ""website"": """",
      ""eplan_id"": ""61"",
      ""short_name"": ""SE"",
      ""name"": ""Schneider Electric""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 842c631b-f669-424b-ab6c-110fbaa3cf3e (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""logo"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-mflogo/MF_WEI.png"",
      ""website"": ""https://www.weidmueller.de"",
      ""eplan_id"": ""77"",
      ""short_name"": ""WEI"",
      ""name"": ""Weidmueller""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 862e447f-1608-4d52-92c7-9a322f68974b (manufacturer) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""862e447f-1608-4d52-92c7-9a322f68974b"",
      ""logo"": ""https://www.duatec.at/files/nav/logo-ikon-w.svg"",
      ""website"": ""https://www.duatec.at"",
      ""eplan_id"": """",
      ""short_name"": ""Duatec"",
      ""name"": ""Dua""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("manufacturer", rec);
    
    }
    #endregion


    #endregion

    #region articles
    #region << ***Create record*** Id: f98383b4-8e6f-4ac6-8eef-6894284d9fd4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f98383b4-8e6f-4ac6-8eef-6894284d9fd4"",
      ""manufacturer_id"": ""8a0a55d6-0522-4f2f-82c6-f1fd6b946856"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ABB/512/ABB%255C9PAA00000086023_720x540.png.png"",
      ""part_number"": ""ABB.2CDS200912R0001"",
      ""eplan_id"": ""630859"",
      ""designation"": ""S2C-H6R Hilfskontakt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""S2C-H6R"",
      ""order_number"": ""2CDS200912R0001""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3702efa7-b3d5-45d9-8615-b760330d1148 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3702efa7-b3d5-45d9-8615-b760330d1148"",
      ""manufacturer_id"": ""8a0a55d6-0522-4f2f-82c6-f1fd6b946856"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ABB/512/ABB%255C2CDC021001S0013.jpg.png"",
      ""part_number"": ""ABB.2CDS252001R0467"",
      ""eplan_id"": ""66295"",
      ""designation"": ""Sicherungsautomat - S200 - 2P - K - 16 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""S202-K16"",
      ""order_number"": ""2CDS252001R0467""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 117e1e65-1b12-45cf-b3c9-c0911875b8a1 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""117e1e65-1b12-45cf-b3c9-c0911875b8a1"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBCC%255CBCC02H9.png.png"",
      ""part_number"": ""BAL.BCC02H9"",
      ""eplan_id"": ""1046243"",
      ""designation"": ""selbstkonfektionierbare Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BKS-S109-RT14"",
      ""order_number"": ""BCC02H9""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 311b43b9-f84a-4eee-9c3c-06bea227f08d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""311b43b9-f84a-4eee-9c3c-06bea227f08d"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BES0086_preview.png.png"",
      ""part_number"": ""BAL.BES0086"",
      ""eplan_id"": ""819398"",
      ""designation"": ""Induktiver Näherungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BES M18MI-PSC50B-S04G"",
      ""order_number"": ""BES0086""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 79a14ec8-1d1c-4822-b6b2-afcf8c886c70 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""79a14ec8-1d1c-4822-b6b2-afcf8c886c70"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BES00EY_preview.png.png"",
      ""part_number"": ""BAL.BES00EY"",
      ""eplan_id"": ""566327"",
      ""designation"": ""Induktiver Näherungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BES M18ME-PSC50B-S04G-003"",
      ""order_number"": ""BES00EY""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9f78cd09-9f13-48c5-92dc-fbee3fdf79bf (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9f78cd09-9f13-48c5-92dc-fbee3fdf79bf"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BES01H6_preview.png.png"",
      ""part_number"": ""BAL.BES01H6"",
      ""eplan_id"": ""566350"",
      ""designation"": ""Induktiver Näherungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BES 516-356-S4-C"",
      ""order_number"": ""BES01H6""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e88ced6d-9922-4c85-9c67-058163c6363c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e88ced6d-9922-4c85-9c67-058163c6363c"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BES03RM_preview.png.png"",
      ""part_number"": ""BAL.BES03RM"",
      ""eplan_id"": ""1681242"",
      ""designation"": ""Induktiver Näherungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BES M18MG-PSC16F-S04G"",
      ""order_number"": ""BES03RM""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fa5b836d-0cb4-46a4-bf37-85676935a097 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fa5b836d-0cb4-46a4-bf37-85676935a097"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BIP001H.jpg.png"",
      ""part_number"": ""BAL.BIP001H"",
      ""eplan_id"": ""873256"",
      ""designation"": ""Induktiver Sensor zum linearen Positionieren"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BIP LD2-T070-03-S75"",
      ""order_number"": ""BIP001H""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 762050cf-b224-4738-81bb-1bf0c20adfa2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""762050cf-b224-4738-81bb-1bf0c20adfa2"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255C42390_00_P_02_00_00_22.jpg.png"",
      ""part_number"": ""BAL.BOS008M"",
      ""eplan_id"": ""566708"",
      ""designation"": ""Reflexionslichtschranke"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BOS 26K-PA-1QE-S4-C"",
      ""order_number"": ""BOS008M""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9bc7b74d-f3fa-44a4-9af3-6b6d31259315 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9bc7b74d-f3fa-44a4-9af3-6b6d31259315"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BOS00WF_preview.png.png"",
      ""part_number"": ""BAL.BOS00WF"",
      ""eplan_id"": ""566731"",
      ""designation"": ""Einweg-Lichtschranke"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BOS 12M-PA-LE10-S4"",
      ""order_number"": ""BOS00WF""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f4b24db3-41c1-4381-bbc1-55d353f3b2eb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f4b24db3-41c1-4381-bbc1-55d353f3b2eb"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBOS%255CBOS00WL.png.png"",
      ""part_number"": ""BAL.BOS00WL"",
      ""eplan_id"": ""631040"",
      ""designation"": ""Einweg-Lichtschranke"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BOS 12M-XT-LS11-S4"",
      ""order_number"": ""BOS00WL""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1f723ee2-caf1-41d1-acf5-333edc53814c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1f723ee2-caf1-41d1-acf5-333edc53814c"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBOS%255CBOS017A.png.png"",
      ""part_number"": ""BAL.BOS017A"",
      ""eplan_id"": ""996168"",
      ""designation"": ""Optoelektronische Sensoren"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BOS 23K-GI-RH10-S4"",
      ""order_number"": ""BOS017A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 67da63f2-29ad-4a1b-a5d4-6575c2f3d599 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""67da63f2-29ad-4a1b-a5d4-6575c2f3d599"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255Cballuff_objekterkennung_SZ_square_22.jpg.png"",
      ""part_number"": ""BAL.BOS01FN"",
      ""eplan_id"": ""566778"",
      ""designation"": ""Reflexionslichtschranke"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BOS 23K-PA-RR10-S4"",
      ""order_number"": ""BOS01FN""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a07deae1-562e-42d1-b7e4-000631b157ed (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a07deae1-562e-42d1-b7e4-000631b157ed"",
      ""manufacturer_id"": ""2e7aebe9-2eab-4116-b916-c4800c956e50"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ETN/512/Eaton%255C1160PIC-1056.jpg.png"",
      ""part_number"": ""ETN.M22-CK20"",
      ""eplan_id"": ""822732"",
      ""designation"": ""Kontaktelement 2 Schließer, Frontbefestigung, Federzuganschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""M22-CK20"",
      ""order_number"": ""107898""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: de5055b8-6761-47bd-ab30-3476dee391e8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""de5055b8-6761-47bd-ab30-3476dee391e8"",
      ""manufacturer_id"": ""2e7aebe9-2eab-4116-b916-c4800c956e50"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ETN/512/Eaton%255C1160PIC-181.jpg.png"",
      ""part_number"": ""ETN.M22-IVS"",
      ""eplan_id"": ""997882"",
      ""designation"": ""Hutschienen-Adapter, IVS"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""M22-IVS"",
      ""order_number"": ""216400""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 91665ac2-653b-4d32-a3d5-34cdba9a5971 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""91665ac2-653b-4d32-a3d5-34cdba9a5971"",
      ""manufacturer_id"": ""2e7aebe9-2eab-4116-b916-c4800c956e50"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ETN/512/Eaton%255C1160PIC-127.jpg.png"",
      ""part_number"": ""ETN.M22-WRS3"",
      ""eplan_id"": ""823272"",
      ""designation"": ""Schlüsseltaste, 3 Stellungen, rastend"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""M22-WRS3"",
      ""order_number"": ""216900""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: adda7715-0107-4b27-8cd5-7b14a9699f9d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""adda7715-0107-4b27-8cd5-7b14a9699f9d"",
      ""manufacturer_id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FES/512/FESTO%255CD15000100125045_600x450.jpg.png"",
      ""part_number"": ""FES.151688"",
      ""eplan_id"": ""101019"",
      ""designation"": ""Steckdosenleitung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KMEB-1-24-2.5-LED"",
      ""order_number"": ""151688""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4091b8fe-06f9-4cb3-b8c2-4c733d87f2dc (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4091b8fe-06f9-4cb3-b8c2-4c733d87f2dc"",
      ""manufacturer_id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FES/512/FESTO%255C0764u.jpg.png"",
      ""part_number"": ""FES.192766"",
      ""eplan_id"": ""102104"",
      ""designation"": ""Drucksensor"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SDE1-..."",
      ""order_number"": ""192766""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ff445145-a5ca-4a80-9463-52833b471767 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ff445145-a5ca-4a80-9463-52833b471767"",
      ""manufacturer_id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FES/512/FESTO%255CD15000100132800_600x450.jpg.png"",
      ""part_number"": ""FES.531030"",
      ""eplan_id"": ""123585"",
      ""designation"": ""Wartungseinheit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MSB6"",
      ""order_number"": ""531030""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 628ee15b-91b6-4c3f-8d72-b74f4908190f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""628ee15b-91b6-4c3f-8d72-b74f4908190f"",
      ""manufacturer_id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FES/512/FESTO%255CD15000100118058_600x450.jpg.png"",
      ""part_number"": ""FES.8047679"",
      ""eplan_id"": ""644134"",
      ""designation"": ""Verbindungsleitung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""NEBV-Z4WA2L-R-E-2.5-N-LE2-S1"",
      ""order_number"": ""8047679""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cabb52f1-6ff3-4192-8c2d-2e4b126b64e5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cabb52f1-6ff3-4192-8c2d-2e4b126b64e5"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_010_2616_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330102616"",
      ""eplan_id"": ""602164"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 10 ES-M"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 010 2616"",
      ""order_number"": ""09330102616""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 36c11eed-d894-4f96-ade2-64d92eb71b1b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""36c11eed-d894-4f96-ade2-64d92eb71b1b"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_010_2716_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330102716"",
      ""eplan_id"": ""602165"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 10 ES-F"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 010 2716"",
      ""order_number"": ""09330102716""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9869f1c5-d03d-458c-a6d4-43d6a741c9a5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9869f1c5-d03d-458c-a6d4-43d6a741c9a5"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_024_2616_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330242616"",
      ""eplan_id"": ""602204"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 24 ES-M"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 024 2616"",
      ""order_number"": ""09330242616""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5ce99923-18a1-447f-8ef7-5d83bba0f02a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5ce99923-18a1-447f-8ef7-5d83bba0f02a"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_024_2716_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330242716"",
      ""eplan_id"": ""602206"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 24 ES-F"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 024 2716"",
      ""order_number"": ""09330242716""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6ef8f744-7a74-4716-872f-a3b5f46a9f84 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6ef8f744-7a74-4716-872f-a3b5f46a9f84"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_006_1540_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300061540"",
      ""eplan_id"": ""602935"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 6B-gs-M20"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 006 1540"",
      ""order_number"": ""19300061540""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 21f550d1-ec5d-4936-bb1b-a9861c329d3a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""21f550d1-ec5d-4936-bb1b-a9861c329d3a"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_016_1231_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300101230"",
      ""eplan_id"": ""603048"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 10B-asg1-QB-M20"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 010 1230"",
      ""order_number"": ""19300101230""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 67263e7d-142b-4c63-9f18-1b3116c212ad (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""67263e7d-142b-4c63-9f18-1b3116c212ad"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_010_1520_CMYK02.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300101520"",
      ""eplan_id"": ""603075"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 10B-gs-M20"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 010 1520"",
      ""order_number"": ""19300101520""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7893a59b-1a97-4980-8cb5-1c86dd10a3c3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7893a59b-1a97-4980-8cb5-1c86dd10a3c3"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_024_1231_CMYK02.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300241231"",
      ""eplan_id"": ""603433"",
      ""designation"": ""Gehäuse für Industriesteckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 024 1231"",
      ""order_number"": ""19300241231""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2037a8d7-f470-43b8-9084-358d2a369e55 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2037a8d7-f470-43b8-9084-358d2a369e55"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_024_1522_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300241521"",
      ""eplan_id"": ""603469"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 24B-gs-M25"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 024 1521"",
      ""order_number"": ""19300241521""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7f9dea6a-392d-4940-8861-fa52b64b7ce0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7f9dea6a-392d-4940-8861-fa52b64b7ce0"",
      ""manufacturer_id"": ""6d5ce8cf-750f-4bec-b52f-248416d670c3"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HELU/512/Helu%255C1PF_015001_f.jpg.png"",
      ""part_number"": ""HELU.15058"",
      ""eplan_id"": ""156290"",
      ""designation"": ""Schleppkettenleitungen JZ-HF 5 G 1.5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""JZ-HF"",
      ""order_number"": ""15058""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1c147a81-2b6a-4ad7-851e-98d220b0d835 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1c147a81-2b6a-4ad7-851e-98d220b0d835"",
      ""manufacturer_id"": ""5f0b2742-31ef-4339-99d7-47e59fc212fc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/IFM/512/ifm%255CP_F_E_W_500_0105_PN7094_01.jpg.png"",
      ""part_number"": ""IFM.PN7094"",
      ""eplan_id"": ""175858"",
      ""designation"": ""Drucksensor mit Display / Steckverbindung: 1 x M12; Kontakte: vergoldet"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PN-010-RER14-QFRKG/US/ /V"",
      ""order_number"": ""PN7094""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2cb0c947-b59c-4eb3-8200-cb6706ad1824 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2cb0c947-b59c-4eb3-8200-cb6706ad1824"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119003"",
      ""eplan_id"": ""186213"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 3G0,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119003""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e0bad0a7-a13f-41ac-8d11-1d8def593753 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e0bad0a7-a13f-41ac-8d11-1d8def593753"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119012"",
      ""eplan_id"": ""186218"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 12G0,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119012""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3536638b-4384-4d2a-ae52-39c272995c4e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3536638b-4384-4d2a-ae52-39c272995c4e"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119112"",
      ""eplan_id"": ""186237"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 12G0,75"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119112""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3cfd27da-0180-4583-b7c7-0187e2f6e98a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3cfd27da-0180-4583-b7c7-0187e2f6e98a"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119125"",
      ""eplan_id"": ""186243"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 25G0,75"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119125""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9466e0b0-670b-4053-b4d9-bbbdea599980 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9466e0b0-670b-4053-b4d9-bbbdea599980"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119207"",
      ""eplan_id"": ""186257"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 7G1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6e8a8fb4-210b-4b63-8c5e-5dba0bad3cb5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6e8a8fb4-210b-4b63-8c5e-5dba0bad3cb5"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119212"",
      ""eplan_id"": ""186261"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 12G1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119212""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 418cf5f3-6307-441d-baef-27d2f6ba76fb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""418cf5f3-6307-441d-baef-27d2f6ba76fb"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119218"",
      ""eplan_id"": ""186264"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 18G1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119218""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 716b1a45-7868-49b5-9c3c-d0c541df5fcb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""716b1a45-7868-49b5-9c3c-d0c541df5fcb"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119225"",
      ""eplan_id"": ""186266"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 25G1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119225""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: be638202-ab03-414d-b9f0-fc4da448cf62 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""be638202-ab03-414d-b9f0-fc4da448cf62"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119303"",
      ""eplan_id"": ""186277"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 3G1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119303""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 585df1ba-ef1c-4378-acd5-59007cc4bddc (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""585df1ba-ef1c-4378-acd5-59007cc4bddc"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119305"",
      ""eplan_id"": ""186279"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 5G1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119305""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: bd1a98ff-8a58-4fa9-8f1f-be0e87f42cbd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""bd1a98ff-8a58-4fa9-8f1f-be0e87f42cbd"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119403"",
      ""eplan_id"": ""186302"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 3G2,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e9120a2c-5cf2-4eba-a1a1-db6d36d78e17 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e9120a2c-5cf2-4eba-a1a1-db6d36d78e17"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119604"",
      ""eplan_id"": ""186319"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 4G6"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119604""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 47222c83-13d6-43ef-9984-6d28b0593e9a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""47222c83-13d6-43ef-9984-6d28b0593e9a"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119752"",
      ""eplan_id"": ""186379"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 2X0,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119752""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 16b36513-485d-44e9-8fb5-8440b0f226fe (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""16b36513-485d-44e9-8fb5-8440b0f226fe"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119802"",
      ""eplan_id"": ""186384"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 2X0,75"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119802""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f7aafd2d-45ac-4d98-ba0d-874d3c3b0aa5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f7aafd2d-45ac-4d98-ba0d-874d3c3b0aa5"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1119752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1119854"",
      ""eplan_id"": ""186392"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 4X1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110"",
      ""order_number"": ""1119854""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0f38973f-b28d-485b-89f0-007f37a3bc48 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0f38973f-b28d-485b-89f0-007f37a3bc48"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_1135752_Product_1.jpg.png"",
      ""part_number"": ""LAPP.1135902"",
      ""eplan_id"": ""186996"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 CY 2X1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110 CY"",
      ""order_number"": ""1135902""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ff0927b3-f908-4be1-a599-e27f4dbc30e2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ff0927b3-f908-4be1-a599-e27f4dbc30e2"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_4520001S_Product_1.jpg.png"",
      ""part_number"": ""LAPP.4520006"",
      ""eplan_id"": ""190843"",
      ""designation"": ""Anschluss- und Steuerleitungen / H07V-K 1X16 GNYE"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""H07V-K"",
      ""order_number"": ""4520006""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 897bcd2e-9ded-493f-820b-003c7687c373 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""897bcd2e-9ded-493f-820b-003c7687c373"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CMit-freiem-Leitungsende%255CSignal%255C7000-08041-630.jpg.png"",
      ""part_number"": ""MURR.7000-08041-6300500"",
      ""eplan_id"": ""1701246"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M8 Bu. 0° A-kod. freies Ltg-ende PUR 3x0.25 sw UL/CSA+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-08041-6300500"",
      ""order_number"": ""7000-08041-6300500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1d69a6de-2590-4947-b044-3fceda0d2a9e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1d69a6de-2590-4947-b044-3fceda0d2a9e"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-14521-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-14521-0000000"",
      ""eplan_id"": ""1934833"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 St. 0° D-kod. Schneidklemmanschluss, 4-pol., 0,14 - 0,34mm², 4,5 - 8,8mm, geschirmt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-14521-0000000"",
      ""order_number"": ""7000-14521-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3033f5c8-08fa-4bc4-852a-f680d152e32d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3033f5c8-08fa-4bc4-852a-f680d152e32d"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255C1020060_PRODUCT_1.jpg.png"",
      ""part_number"": ""LAPP.1020042"",
      ""eplan_id"": ""845907"",
      ""designation"": ""ÖLFLEX SERVO 719 CY 4G1,5+(2x0,5) 4G1,5+(2X0,5)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX SERVO 719 CY 4G1,5+(2x0,5)"",
      ""order_number"": ""1020042""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 97225d30-5efb-4229-a005-13ad17332dec (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""97225d30-5efb-4229-a005-13ad17332dec"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_0019700_Product_1.jpg.png"",
      ""part_number"": ""LAPP.0019711"",
      ""eplan_id"": ""181861"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 ORANGE 3G1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110 ORANGE"",
      ""order_number"": ""0019711""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a85636da-9883-4d2c-9cf3-7a1cc55e66ad (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a85636da-9883-4d2c-9cf3-7a1cc55e66ad"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_0026100_Product_1.jpg.png"",
      ""part_number"": ""LAPP.0026119"",
      ""eplan_id"": ""182355"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC FD 810 2X0,75"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC FD 810"",
      ""order_number"": ""0026119""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7f6a1f9d-3e5d-46fb-ac4b-31268357270d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7f6a1f9d-3e5d-46fb-ac4b-31268357270d"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CUNITRONIC_0034302_Product_1.jpg.png"",
      ""part_number"": ""LAPP.0034802"",
      ""eplan_id"": ""183688"",
      ""designation"": ""Datenübertragungssysteme / UNITRONIC LIYCY 2X1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""UNITRONIC® LiYCY"",
      ""order_number"": ""0034802""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b820a096-ff0e-4a39-bcef-1c581236888e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b820a096-ff0e-4a39-bcef-1c581236888e"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-14621-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-14621-0000000"",
      ""eplan_id"": ""1934834"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 Bu. 0° D-kod. Schneidklemmanschluss, 4-pol., 0,14 - 0,34mm², 4,5 - 8,8mm, geschirmt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-14621-0000000"",
      ""order_number"": ""7000-14621-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 982b6271-3c86-4750-81a5-f6956e99cc0a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""982b6271-3c86-4750-81a5-f6956e99cc0a"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-44511-796.jpg.png"",
      ""part_number"": ""MURR.7000-44511-7960250"",
      ""eplan_id"": ""1931565"",
      ""designation"": ""Konfektionierte Datenleitung / M12 St. 0° / M12 St. 0° D-kod. geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 2,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-44511-7960250"",
      ""order_number"": ""7000-44511-7960250""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cfe7373b-9924-4cce-832c-2e16be16f111 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cfe7373b-9924-4cce-832c-2e16be16f111"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-44511-796.jpg.png"",
      ""part_number"": ""MURR.7000-44511-7960500"",
      ""eplan_id"": ""1931579"",
      ""designation"": ""Konfektionierte Datenleitung / M12 St. 0° / M12 St. 0° D-kod. geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-44511-7960500"",
      ""order_number"": ""7000-44511-7960500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1d83e17f-29fc-4844-88c1-105ce9492821 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1d83e17f-29fc-4844-88c1-105ce9492821"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960050"",
      ""eplan_id"": ""1989501"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 0,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960050"",
      ""order_number"": ""7000-74301-7960050""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d58bae9e-2c5b-43e1-974a-c133979874ef (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d58bae9e-2c5b-43e1-974a-c133979874ef"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960100"",
      ""eplan_id"": ""1989508"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 1m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960100"",
      ""order_number"": ""7000-74301-7960100""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6a902802-6fe9-441a-8a6f-dfb54a73f025 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6a902802-6fe9-441a-8a6f-dfb54a73f025"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CAccessories%255C9000_41000_0000002.png.png"",
      ""part_number"": ""MURR.9000-41000-0000002"",
      ""eplan_id"": ""1179427"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Mico Pro Endlossteckbrücke 1x blau 1x rot (max. 40A, 500mm Länge)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41000-0000002"",
      ""order_number"": ""9000-41000-0000002""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: bf4f6ffd-cbb2-4c18-930e-b7b7148f35e3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""bf4f6ffd-cbb2-4c18-930e-b7b7148f35e3"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CModules%255C9000_41094_0101000.png.png"",
      ""part_number"": ""MURR.9000-41094-0101000"",
      ""eplan_id"": ""1179442"",
      ""designation"": ""Stromüberwachungsgerät / Mico Pro Lastkreisüberwachung, 4-kanalig (IN: 24 V DC OUT: 24 V DC / 1-2-3-4-5-6-7-8-9-10A)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41094-0101000"",
      ""order_number"": ""9000-41094-0101000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f0af3626-d2ca-483e-a36b-072142627871 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f0af3626-d2ca-483e-a36b-072142627871"",
      ""manufacturer_id"": ""1096e61d-a751-4d94-846c-56265f081581"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/P%2BF/512/P%252BF%255Cd404518a_int.jpg.png"",
      ""part_number"": ""P+F.NBN4-12GM50-E2-V1"",
      ""eplan_id"": ""930808"",
      ""designation"": ""Induktiver Sensor"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""NBN4-12GM50-E2-V1"",
      ""order_number"": ""NBN4-12GM50-E2-V1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1d73505d-029f-4b28-b012-f35020135446 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1d73505d-029f-4b28-b012-f35020135446"",
      ""manufacturer_id"": ""87c181bf-9b04-4d16-9a65-9c38c719fac4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PILZ/512/PILZ%255CF_PNOZ_s4_751104_F1_3c_800_v1.jpg.png"",
      ""part_number"": ""PILZ.751104"",
      ""eplan_id"": ""1091431"",
      ""designation"": ""Gerät zur Überwachung von sicherheitsgerichteten Stromkreisen / PNOZsigma Sicherheitsschaltgerät (standalone)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PNOZ s4 C 24VDC 3 n/o 1 n/c"",
      ""order_number"": ""751104""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 55103197-8971-4fc1-9b9a-d492176aa23c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""55103197-8971-4fc1-9b9a-d492176aa23c"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CAX%255Cfri181935395.jpg.png"",
      ""part_number"": ""RIT.1077000"",
      ""eplan_id"": ""995180"",
      ""designation"": ""Kompakt-Schaltschrank AX / AX Kompakt-Schaltschrank, BHT: 760x760x210 mm, Stahlblech, mit Montageplatte, eintürig, zwei Vorreiberverschlüsse"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AX.1077000"",
      ""order_number"": ""1077000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8af8665d-d048-4a30-b093-5d7005ce14e8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8af8665d-d048-4a30-b093-5d7005ce14e8"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSG%255Cfri190444695.jpg.png"",
      ""part_number"": ""RIT.2368001"",
      ""eplan_id"": ""1118503"",
      ""designation"": ""Anschluss-Element / SG Anschluss-Element, für Signalsäulen, modular, für Rohrmontage"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SG.2368001"",
      ""order_number"": ""2368001""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e32aecd8-8105-4645-9906-6a437c87a09a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e32aecd8-8105-4645-9906-6a437c87a09a"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSG%255Cfri190445095.jpg.png"",
      ""part_number"": ""RIT.2372001"",
      ""eplan_id"": ""1118517"",
      ""designation"": ""LED Dauerlichtelement / SG LED Dauerlichtelement, für Signalsäulen, modular, 24 V AC/DC, rot"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SG.2372001"",
      ""order_number"": ""2372001""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6c0d8eda-0ea5-4d96-835c-9e5ee3f50c86 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6c0d8eda-0ea5-4d96-835c-9e5ee3f50c86"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSG%255Cfri190444795.jpg.png"",
      ""part_number"": ""RIT.2372011"",
      ""eplan_id"": ""1118518"",
      ""designation"": ""LED Dauerlichtelement / SG LED Dauerlichtelement, für Signalsäulen, modular, 24 V AC/DC, grün"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SG.2372011"",
      ""order_number"": ""2372011""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f9ba83e2-d756-4d6c-be73-a6a709106c96 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f9ba83e2-d756-4d6c-be73-a6a709106c96"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSG%255Cfri190444895.jpg.png"",
      ""part_number"": ""RIT.2372021"",
      ""eplan_id"": ""1118519"",
      ""designation"": ""LED Dauerlichtelement / SG LED Dauerlichtelement, für Signalsäulen, modular, 24 V AC/DC, gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SG.2372021"",
      ""order_number"": ""2372021""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 20142b3c-b86c-4d0c-a91e-c9fe233317be (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""20142b3c-b86c-4d0c-a91e-c9fe233317be"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSG%255Cfri190445795.jpg.png"",
      ""part_number"": ""RIT.2374000"",
      ""eplan_id"": ""421153"",
      ""designation"": ""Montage-Element / SG Montage-Element für Rohrmontage, für Signalsäule, modular und LED-Kompakt, Fuß mit integriertem Rohr, Ø 25 mm, L: 110 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SG.2374000"",
      ""order_number"": ""2374000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7f9df4e4-607a-4687-b2d7-413a1b4f0723 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7f9df4e4-607a-4687-b2d7-413a1b4f0723"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSG%255Cfri100563995.jpg.png"",
      ""part_number"": ""RIT.2374050"",
      ""eplan_id"": ""421158"",
      ""designation"": ""Montage-Element / SG Montage-Element für Rohrmontage, für Signalsäule, modular und LED-Kompakt, Winkel für Rohrmontage"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SG.2374050"",
      ""order_number"": ""2374050""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7c36dd24-7c67-4b69-b6f4-7fc10d43e224 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7c36dd24-7c67-4b69-b6f4-7fc10d43e224"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSZ%255Cfri161328495.jpg.png"",
      ""part_number"": ""RIT.2500210"",
      ""eplan_id"": ""647715"",
      ""designation"": ""Systemleuchte LED / Systemleuchte LED, mit Steckdose, D, Schuko (Typ F, CEE 7/3), Länge: 437 mm, Eingangsspannung: 100 V - 240 V, 1~, 50 Hz/60 Hz, 900 lm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SZ.2500210"",
      ""order_number"": ""2500210""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 66240a8c-8a7f-4102-bc9e-43866f1ad45b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""66240a8c-8a7f-4102-bc9e-43866f1ad45b"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSZ%255Cfri161313495.jpg.png"",
      ""part_number"": ""RIT.2500460"",
      ""eplan_id"": ""647723"",
      ""designation"": ""Türpositionsschalter / SZ Türpositionsschalter, mit Anschlussleitung, L: 800 mm, schwarz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SZ.2500460"",
      ""order_number"": ""2500460""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 68b2b71e-f90e-459e-b9fd-71fd7448db02 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""68b2b71e-f90e-459e-b9fd-71fd7448db02"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSZ%255Cfri161312895.jpg.png"",
      ""part_number"": ""RIT.2500500"",
      ""eplan_id"": ""647725"",
      ""designation"": ""Anschlussleitung / SZ Anschlussleitung, für Einspeisung, 3-polig, 100-240 V, L: 3000 mm, UL"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SZ.2500500"",
      ""order_number"": ""2500500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a9ea21fb-3b2d-4c9c-96bd-54eede50179d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a9ea21fb-3b2d-4c9c-96bd-54eede50179d"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSK%255Cfri100501095.jpg.png"",
      ""part_number"": ""RIT.3110000"",
      ""eplan_id"": ""420910"",
      ""designation"": ""Thermostat / SK Thermostat, Schaltschrank-Innentemperaturregler, 24-230 V, 1~, 24-60 V (DC), Farbe RAL 7035, BHT: 71 x 71 x 33,5 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SK.3110000"",
      ""order_number"": ""3110000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5811c289-5d2e-4364-b1b3-7bc8e792982b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5811c289-5d2e-4364-b1b3-7bc8e792982b"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSK%255Cfri171626095.jpg.png"",
      ""part_number"": ""RIT.3245500"",
      ""eplan_id"": ""559072"",
      ""designation"": ""TopTherm Filterlüfter / SK Filterlüfter TopTherm, 900 m³/h, 200-240 V, 1~, 50/60 Hz, BHT: 323 x 323 x 25 mm, EC-Technologie"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SK.3245500"",
      ""order_number"": ""3245500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8a9ab9ea-3ee0-4928-9575-ccf68312eebb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8a9ab9ea-3ee0-4928-9575-ccf68312eebb"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri100575495.jpg.png"",
      ""part_number"": ""RIT.3451500"",
      ""eplan_id"": ""421593"",
      ""designation"": ""Leiteranschlussklemme / SV Leiteranschlussklemme, 2,5-16 mm², Klemmraum BH: 8x8 mm, für Schienenstärke 5 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.3451500"",
      ""order_number"": ""3451500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e1efd38d-43e2-44aa-a0b8-dab6bab7efee (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e1efd38d-43e2-44aa-a0b8-dab6bab7efee"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri171656795.jpg.png"",
      ""part_number"": ""RIT.3582000"",
      ""eplan_id"": ""421631"",
      ""designation"": ""Sammelschienen E-Cu / SV Sammelschiene E-Cu, BH: 20x5 mm, L: 2400 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.3582000"",
      ""order_number"": ""3582000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6ef630d4-d96b-4845-aebe-685f2471b038 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6ef630d4-d96b-4845-aebe-685f2471b038"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CPS%255Cfri171646995.jpg.png"",
      ""part_number"": ""RIT.4116000"",
      ""eplan_id"": ""421646"",
      ""designation"": ""Schaltplantasche aus Stahlblech / Schaltplantaschen, für TS, CM, SE, PC, TP Unterteil, Stahlblech, für Türbreite : 600 mm, T: 90 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PS.4116000"",
      ""order_number"": ""4116000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 82de9f86-b62a-41b6-a8f1-48aad46b1e58 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""82de9f86-b62a-41b6-a8f1-48aad46b1e58"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CVX%255Cfri181646095.jpg.png"",
      ""part_number"": ""RIT.8185245"",
      ""eplan_id"": ""933739"",
      ""designation"": ""Seitenwand, verschraubbar, Stahlblech / VX Seitenwand, verschraubbar, für HT: 1800x500 mm, Stahlblech"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""VX.8185245"",
      ""order_number"": ""8185245""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e14c9cd9-075c-4244-b5f9-fc566700aced (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e14c9cd9-075c-4244-b5f9-fc566700aced"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CVX%255Cfri181614695.jpg.png"",
      ""part_number"": ""RIT.8285000"",
      ""eplan_id"": ""933750"",
      ""designation"": ""Anreih-Schranksystem VX25 / VX Anreih-Schranksystem, BHT: 1200x1800x500 mm, Stahlblech, mit Montageplatte, doppeltürig an Frontseite. Das Produkt ist erhältlich in diesen Regionen/Ländern: EMEA, AMERICAS. Das Produkt ist nicht erhältlich in diesen Regionen/Ländern: NORTH AMERICA,APAC,OCEANIA,BR, MX"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""VX.8285000"",
      ""order_number"": ""8285000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 89759a5f-ad46-4f21-9acd-11f45574cd7e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""89759a5f-ad46-4f21-9acd-11f45574cd7e"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CVX%255Cfri170446695.jpg.png"",
      ""part_number"": ""RIT.8618200"",
      ""eplan_id"": ""933835"",
      ""designation"": ""Komfortgriff VX / VX Komfortgriff, für Verschluss-Einsätze, RAL 7035"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""VX.8618200"",
      ""order_number"": ""8618200""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2f4df2eb-3742-4c46-9023-dc32c74f4359 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2f4df2eb-3742-4c46-9023-dc32c74f4359"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CVX%255Cfri181652595.jpg.png"",
      ""part_number"": ""RIT.8618813"",
      ""eplan_id"": ""933868"",
      ""designation"": ""Profil zur Kabeleinführung, hinten / VX Profil zur Kabeleinführung, hinten, für B: 1200 mm, Hard PVC"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""VX.8618813"",
      ""order_number"": ""8618813""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c2f578c0-37a9-43b7-a804-4c36570fa8ee (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c2f578c0-37a9-43b7-a804-4c36570fa8ee"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri100573597.jpg.png"",
      ""part_number"": ""RIT.9340030"",
      ""eplan_id"": ""422383"",
      ""designation"": ""Sammelschienenhalter / SV Sammelschienenhalter, 1-polig, für Sammelschiene BH: 12x5-30x10 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9340030"",
      ""order_number"": ""9340030""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9e84c6f8-a82d-4863-8bce-1183392c7e90 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9e84c6f8-a82d-4863-8bce-1183392c7e90"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri170410295.jpg.png"",
      ""part_number"": ""RIT.9635010"",
      ""eplan_id"": ""852094"",
      ""designation"": ""Board / SV Board, 125 A, 690 V (AC). 600 V (DC), 3-polig, BHT: 405x160x45,1 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635010"",
      ""order_number"": ""9635010""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 89b7f037-4d88-4ef6-aa3c-456f28eb853d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""89b7f037-4d88-4ef6-aa3c-456f28eb853d"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri191308695.jpg.png"",
      ""part_number"": ""RIT.9635210"",
      ""eplan_id"": ""1004174"",
      ""designation"": ""Anschlussadapter / Anschlussadapter 125 A, 690 V (AC), 600 V (DC), 3-polig, Leitungsabgang oben/unten, Rundleiteranschluss 6-50 mm²"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635210"",
      ""order_number"": ""9635210""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: edcee799-cf72-476a-b6c5-1bfbf20dd529 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""edcee799-cf72-476a-b6c5-1bfbf20dd529"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri170409795.jpg.png"",
      ""part_number"": ""RIT.9635330"",
      ""eplan_id"": ""852098"",
      ""designation"": ""Geräteadapter / SV Geräteadapter (Comfort), 16 A, 690 V (AC), 600 V (DC), 3-polig, Anschlussleitung AWG 14 (L: 120 mm), BH: 45x160 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635330"",
      ""order_number"": ""9635330""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8841b6e6-ef00-44e1-860b-86cc1bb46986 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8841b6e6-ef00-44e1-860b-86cc1bb46986"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri170409995.jpg.png"",
      ""part_number"": ""RIT.9635350"",
      ""eplan_id"": ""852100"",
      ""designation"": ""Geräteadapter / SV Geräteadapter (Comfort), 32 A, 690 V (AC), 600 V (DC), 3-polig, Anschlussleitung AWG 10 (L: 100 mm), BH: 45x160 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635350"",
      ""order_number"": ""9635350""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 593e6add-daa9-4f96-bb5f-51c6c7258f8c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""593e6add-daa9-4f96-bb5f-51c6c7258f8c"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri191440695.jpg.png"",
      ""part_number"": ""RIT.9635371"",
      ""eplan_id"": ""1013221"",
      ""designation"": ""Geräteadapter / Geräteadapter 1-polig, Ausführung: L1, Bemessungsstrom: 16 A, AWG 14"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635371"",
      ""order_number"": ""9635371""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b26ea7b1-0ef7-4b5e-8197-304f29995294 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b26ea7b1-0ef7-4b5e-8197-304f29995294"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri191440795.jpg.png"",
      ""part_number"": ""RIT.9635372"",
      ""eplan_id"": ""1013222"",
      ""designation"": ""Geräteadapter / Geräteadapter 1-polig, Ausführung: L2, Bemessungsstrom: 16 A, AWG 14"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635372"",
      ""order_number"": ""9635372""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e6c0af75-5fda-4895-8b4c-8f4d5b8d1e3f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e6c0af75-5fda-4895-8b4c-8f4d5b8d1e3f"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri191440895.jpg.png"",
      ""part_number"": ""RIT.9635373"",
      ""eplan_id"": ""1013223"",
      ""designation"": ""Geräteadapter / Geräteadapter 1-polig, Ausführung: L3, Bemessungsstrom: 16 A, AWG 14"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635373"",
      ""order_number"": ""9635373""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7bc147cc-50ff-4019-8fdc-2393affe2c68 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7bc147cc-50ff-4019-8fdc-2393affe2c68"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri191441295.jpg.png"",
      ""part_number"": ""RIT.9635390"",
      ""eplan_id"": ""1013227"",
      ""designation"": ""Geräteträger / Geräteträger ohne Kontaktsystem, B x H: 18 x 160 mm, Polyamid"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635390"",
      ""order_number"": ""9635390""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4d9fade0-b675-492b-badc-6c78a05193b6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4d9fade0-b675-492b-badc-6c78a05193b6"",
      ""manufacturer_id"": ""9f442816-d1be-43ef-a9d3-905447651081"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SCHM/512/Schmersal%255CRSS%252036-ST.jpg.png"",
      ""part_number"": ""SCHM.101213954"",
      ""eplan_id"": ""572589"",
      ""designation"": ""Sicherheits-Sensor RSS 36"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""RSS 36-D-ST"",
      ""order_number"": ""101213954""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: abe1249a-52cf-493b-a31d-a9feb4e2f5f8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""abe1249a-52cf-493b-a31d-a9feb4e2f5f8"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CWiderst%25C3%25A4nde%255CFlachwiderstand.JPG.png"",
      ""part_number"": ""SEW.BW100-001"",
      ""eplan_id"": ""945923"",
      ""designation"": ""Bremswiderstand 100 Ω / 0,1 kW / IP65 / Sachnummer: 08281718"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BW100-001"",
      ""order_number"": ""BW100-001""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 381f5de4-4fa0-46cf-a4ae-25fbecf7e205 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""381f5de4-4fa0-46cf-a4ae-25fbecf7e205"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255COptionskarten.jpg.png"",
      ""part_number"": ""SEW.CFN21A"",
      ""eplan_id"": ""972386"",
      ""designation"": ""Profinetkarte / Sachnummer: 28231694"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CFN21A"",
      ""order_number"": ""CFN21A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 431e990e-05fd-4029-8537-621f329c180c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""431e990e-05fd-4029-8537-621f329c180c"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CSafety-Optionskarten.jpg.png"",
      ""part_number"": ""SEW.CSS21A"",
      ""eplan_id"": ""872481"",
      ""designation"": ""Sicherheitskarte MOVISAFE CSS21A / Sachnummer: 28233379"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSS21A"",
      ""order_number"": ""CSS21A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b978d47c-6a70-4973-b6fa-cc20c78acaf7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b978d47c-6a70-4973-b6fa-cc20c78acaf7"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CSafety-Optionskarten.jpg.png"",
      ""part_number"": ""SEW.CSS31A"",
      ""eplan_id"": ""872482"",
      ""designation"": ""Sicherheitskarte MOVISAFE CSS31A / Sachnummer: 28233395"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSS31A"",
      ""order_number"": ""CSS31A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 063b3b7e-a570-44be-8240-402ce16df33d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""063b3b7e-a570-44be-8240-402ce16df33d"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CMDX9xA_BG1.jpg.png"",
      ""part_number"": ""SEW.MDX91A-0020-5E3-4-T01"",
      ""eplan_id"": ""972432"",
      ""designation"": ""MOVIDRIVE® technology, Einachsumrichter / 2 A / 0,55 kW"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MDX91A-0020-5E3-4-T01"",
      ""order_number"": ""MDX91A-0020-5E3-4-T01""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7f351cec-60de-4e3a-9dd5-a3542ade9210 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7f351cec-60de-4e3a-9dd5-a3542ade9210"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CMDX9xA_BG1.jpg.png"",
      ""part_number"": ""SEW.MDX91A-0032-5E3-4-T01"",
      ""eplan_id"": ""972438"",
      ""designation"": ""MOVIDRIVE® technology, Einachsumrichter / 3,2 A / 1,1 kW"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MDX91A-0032-5E3-4-T01"",
      ""order_number"": ""MDX91A-0032-5E3-4-T01""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 51a0c9f0-f1c6-4893-8bc4-38ee926d21f5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""51a0c9f0-f1c6-4893-8bc4-38ee926d21f5"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CMDX9xA_BG2.jpg.png"",
      ""part_number"": ""SEW.MDX91A-0055-5E3-4-T01"",
      ""eplan_id"": ""972444"",
      ""designation"": ""MOVIDRIVE® technology, Einachsumrichter / 5,5 A / 2,2 kW"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MDX91A-0055-5E3-4-T01"",
      ""order_number"": ""MDX91A-0055-5E3-4-T01""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 724eafff-27c3-4711-96af-aac5d746ca52 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""724eafff-27c3-4711-96af-aac5d746ca52"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3LD%255Cproduct_picture_G_I202_XX_32877P.png.png"",
      ""part_number"": ""SIE.3LD2804-0TK51"",
      ""eplan_id"": ""573407"",
      ""designation"": ""HPTSCH 125A/690V 400V/45KW / SENTRON Haupt und NOT-AUS-Schalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD2804-0TK51"",
      ""order_number"": ""3LD2804-0TK51""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a55fe086-b0ff-4cd7-9b7f-415109be2953 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a55fe086-b0ff-4cd7-9b7f-415109be2953"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C1492%255C189_ar11.jpg.png"",
      ""part_number"": ""A-B.189-AR11"",
      ""eplan_id"": ""25275"",
      ""designation"": ""Auxiliary contact module 1 N.O. + 1 N.C. / 1 N.O. + 1 N.C."",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""189"",
      ""order_number"": ""189-AR11""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cfbd1a8a-8a74-4fdb-9ac0-37d1e3e0056a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cfbd1a8a-8a74-4fdb-9ac0-37d1e3e0056a"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RH2%255Cproduct_picture_G_NSA0_XX_01119P.png.png"",
      ""part_number"": ""SIE.3RH2131-2BB40"",
      ""eplan_id"": ""451410"",
      ""designation"": ""HILFSSCHUETZ,3S+1OE,DC24V / SIRIUS Hilfsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RH2131-2BB40"",
      ""order_number"": ""3RH2131-2BB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 53b0fb1f-f67f-4f3e-a4ab-84ba03c46f51 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""53b0fb1f-f67f-4f3e-a4ab-84ba03c46f51"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RH2%255Cproduct_picture_G_NSA0_XX_01155P.png.png"",
      ""part_number"": ""SIE.3RH2262-2BB40"",
      ""eplan_id"": ""703924"",
      ""designation"": ""HILFSSCHUETZ,6S+2OE,DC24V / SIRIUS Hilfsschütz / FUER SUVA APPLIKATIONEN"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RH2262-2BB40"",
      ""order_number"": ""3RH2262-2BB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1d395569-3833-4755-a74c-94da035a3d4a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1d395569-3833-4755-a74c-94da035a3d4a"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00852P.png.png"",
      ""part_number"": ""SIE.3RT2015-2BB41"",
      ""eplan_id"": ""451665"",
      ""designation"": ""SCHUETZ,AC3:3KW 1S DC24V / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2015-2BB41"",
      ""order_number"": ""3RT2015-2BB41""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 98be9d3b-a0b0-47bb-896c-b1ad48469337 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""98be9d3b-a0b0-47bb-896c-b1ad48469337"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00852P.png.png"",
      ""part_number"": ""SIE.3RT2017-2BB41"",
      ""eplan_id"": ""451850"",
      ""designation"": ""SCHUETZ,AC3:5,5KW 1S DC24V / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2017-2BB41"",
      ""order_number"": ""3RT2017-2BB41""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 075c3d7d-9fe6-4c83-8538-cdf8d94cde03 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""075c3d7d-9fe6-4c83-8538-cdf8d94cde03"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93065P.png.png"",
      ""part_number"": ""SIE.3RV2021-1BA10"",
      ""eplan_id"": ""462083"",
      ""designation"": ""LEISTUNGSSCHALTER SCHRAUBANSCHL. 2A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2021-1BA10"",
      ""order_number"": ""3RV2021-1BA10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: be7498fd-e6c5-4ae7-af01-c6723aa39f48 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""be7498fd-e6c5-4ae7-af01-c6723aa39f48"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93074P.png.png"",
      ""part_number"": ""SIE.3RV2021-4DA25"",
      ""eplan_id"": ""452861"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 25A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2021-4DA25"",
      ""order_number"": ""3RV2021-4DA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b1886b55-221a-4cd8-a735-a48661184a35 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b1886b55-221a-4cd8-a735-a48661184a35"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZVHSU%255Cproduct_picture_G_NSA0_XX_93113.jpg.png"",
      ""part_number"": ""SIE.3RV2901-1E"",
      ""eplan_id"": ""453081"",
      ""designation"": ""HILFSSCHALTER QUERLIEGEND, 1S+1OE, SCHRAUBANSCHLUSS / FUER LEISTUNGSSCHALTER,  BGR. S00/S0"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2901-1E"",
      ""order_number"": ""3RV2901-1E""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 06dcf007-4b5f-4a28-8585-b4f070c0f879 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""06dcf007-4b5f-4a28-8585-b4f070c0f879"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BD%255Cproduct_picture_G_IC03_XX_07897P.png.png"",
      ""part_number"": ""SIE.3SU1000-0AB20-0AA0"",
      ""eplan_id"": ""462700"",
      ""designation"": ""DRUCKTASTER, ROT / SIRIUS ACT Drucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1000-0AB20-0AA0"",
      ""order_number"": ""3SU1000-0AB20-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 946d9f95-e0cc-4d1d-8961-8ec4c1311ce8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""946d9f95-e0cc-4d1d-8961-8ec4c1311ce8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BD%255Cproduct_picture_G_IC03_XX_07904P.png.png"",
      ""part_number"": ""SIE.3SU1001-0AB40-0AA0"",
      ""eplan_id"": ""463084"",
      ""designation"": ""LEUCHTDRUCKTASTER, GRUEN / SIRIUS ACT Leuchtdrucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1001-0AB40-0AA0"",
      ""order_number"": ""3SU1001-0AB40-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 18a6b6d2-31d3-4e3d-b999-86159df4c996 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""18a6b6d2-31d3-4e3d-b999-86159df4c996"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BD%255Cproduct_picture_G_IC03_XX_07906P.png.png"",
      ""part_number"": ""SIE.3SU1001-0AB60-0AA0"",
      ""eplan_id"": ""463088"",
      ""designation"": ""LEUCHTDRUCKTASTER, WEISS / SIRIUS ACT Leuchtdrucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1001-0AB60-0AA0"",
      ""order_number"": ""3SU1001-0AB60-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d08e4aca-ff09-476b-8cf2-ce6e2f7ef8fd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d08e4aca-ff09-476b-8cf2-ce6e2f7ef8fd"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BNH%255Cproduct_picture_G_IC03_XX_07210P.png.png"",
      ""part_number"": ""SIE.3SU1050-1HB20-0AA0"",
      ""eplan_id"": ""463859"",
      ""designation"": ""NOT-HALT-PILZDRUCKTASTER, 40MM, ROT / SIRIUS ACT NOT-HALT-Pilzdrucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1050-1HB20-0AA0"",
      ""order_number"": ""3SU1050-1HB20-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5dc67fe4-beca-4f76-bdd6-b5ee7220fdce (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5dc67fe4-beca-4f76-bdd6-b5ee7220fdce"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BSS%255Cproduct_picture_G_IC03_XX_07233P.png.png"",
      ""part_number"": ""SIE.3SU1050-5BF11-0AA0"",
      ""eplan_id"": ""464024"",
      ""designation"": ""SCHLUESSELSCHALTER CES, O-I / SIRIUS ACT Schlüsselschalter / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1050-5BF11-0AA0"",
      ""order_number"": ""3SU1050-5BF11-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1c13f2bd-599f-4aff-9307-813f57b8750d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1c13f2bd-599f-4aff-9307-813f57b8750d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_06764P.png.png"",
      ""part_number"": ""SIE.3SU1400-1AA10-3BA0"",
      ""eplan_id"": ""521973"",
      ""designation"": ""KONTAKTMODUL 1S / SIRIUS ACT Kontaktmodul / Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1AA10-3BA0"",
      ""order_number"": ""3SU1400-1AA10-3BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 45d913b2-bbcc-401d-a334-c77cbb85cc85 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""45d913b2-bbcc-401d-a334-c77cbb85cc85"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_06950P.png.png"",
      ""part_number"": ""SIE.3SU1400-1AA10-3CA0"",
      ""eplan_id"": ""521975"",
      ""designation"": ""KONTAKTMODUL 1OE / SIRIUS ACT Kontaktmodul / Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1AA10-3CA0"",
      ""order_number"": ""3SU1400-1AA10-3CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 32fbf401-9402-4fc3-9d5a-69e36b81a174 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""32fbf401-9402-4fc3-9d5a-69e36b81a174"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MPN%255Cproduct_picture_G_IC03_XX_21204P.png.png"",
      ""part_number"": ""SIE.3SU1400-1LK10-1AA1"",
      ""eplan_id"": ""1093957"",
      ""designation"": ""PROFINET - Standard Interfacemodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1LK10-1AA1"",
      ""order_number"": ""3SU1400-1LK10-1AA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 40e4d238-9e15-46c1-87f9-7e0d16c7a049 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""40e4d238-9e15-46c1-87f9-7e0d16c7a049"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MPN%255Cproduct_picture_G_IC03_XX_21222P.png.png"",
      ""part_number"": ""SIE.3SU1400-1MA10-1BA1"",
      ""eplan_id"": ""1093961"",
      ""designation"": ""Terminalmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1MA10-1BA1"",
      ""order_number"": ""3SU1400-1MA10-1BA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6b233350-cec0-483e-8288-d19d17790290 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6b233350-cec0-483e-8288-d19d17790290"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MPN%255Cproduct_picture_G_IC03_XX_21237P.png.png"",
      ""part_number"": ""SIE.3SU1401-1MC40-1CA1"",
      ""eplan_id"": ""1093965"",
      ""designation"": ""Terminalmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-1MC40-1CA1"",
      ""order_number"": ""3SU1401-1MC40-1CA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 68ae3716-5d33-4ca9-bd01-5174a87086fb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""68ae3716-5d33-4ca9-bd01-5174a87086fb"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MPN%255Cproduct_picture_G_IC03_XX_21249P.png.png"",
      ""part_number"": ""SIE.3SU1401-1MC60-1CA1"",
      ""eplan_id"": ""1093967"",
      ""designation"": ""Terminalmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-1MC60-1CA1"",
      ""order_number"": ""3SU1401-1MC60-1CA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3db44633-5c73-4c73-b578-cbc56744ae1f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3db44633-5c73-4c73-b578-cbc56744ae1f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1HMO%255Cproduct_picture_G_IC03_XX_06953P.png.png"",
      ""part_number"": ""SIE.3SU1500-0AA10-0AA0"",
      ""eplan_id"": ""706725"",
      ""designation"": ""HALTER / SIRIUS ACT Halter / Halter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1500-0AA10-0AA0"",
      ""order_number"": ""3SU1500-0AA10-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3f03f7f9-27cf-4c5a-b924-7d60dacd252e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3f03f7f9-27cf-4c5a-b924-7d60dacd252e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1HMO%255Cproduct_picture_G_IC03_XX_06952I.jpg.png"",
      ""part_number"": ""SIE.3SU1550-0AA10-0AA0"",
      ""eplan_id"": ""706763"",
      ""designation"": ""HALTER / SIRIUS ACT Halter / Halter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1550-0AA10-0AA0"",
      ""order_number"": ""3SU1550-0AA10-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8f91c910-2786-4c59-aeb4-c25824c11ee8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8f91c910-2786-4c59-aeb4-c25824c11ee8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1ZSI%255Cproduct_picture_G_IC03_XX_07765P.png.png"",
      ""part_number"": ""SIE.3SU1900-0AS10-0AA0"",
      ""eplan_id"": ""522514"",
      ""designation"": ""SCHILDTRAEGER / SIRIUS ACT Schildträger / für Bezeichnungsschild 17,5 x 27 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1900-0AS10-0AA0"",
      ""order_number"": ""3SU1900-0AS10-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 050c022f-41c7-4619-9d99-cc6e13f97f1e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""050c022f-41c7-4619-9d99-cc6e13f97f1e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1ZSI%255Cproduct_picture_G_IC03_XX_06805P.png.png"",
      ""part_number"": ""SIE.3SU1900-0BC31-0NB0"",
      ""eplan_id"": ""522530"",
      ""designation"": ""NOT-HALT-UNTERLEGSCHILD, GELB / SIRIUS ACT NOT-HALT-Unterlegschild / NOT-HALT-Unterlegschild"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1900-0BC31-0NB0"",
      ""order_number"": ""3SU1900-0BC31-0NB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: aa22a0ff-3be2-4b52-a7c5-c90357de8603 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""aa22a0ff-3be2-4b52-a7c5-c90357de8603"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1ZSO%255Cproduct_picture_G_IC03_XX_21912P.png.png"",
      ""part_number"": ""SIE.3SU1900-0KQ80-0AA0"",
      ""eplan_id"": ""994203"",
      ""designation"": ""FLACHBANDKABEL / SIRIUS ACT Flachbandkabel / 7 Adern, Länge 5 m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1900-0KQ80-0AA0"",
      ""order_number"": ""3SU1900-0KQ80-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 088d4388-045a-45c2-ac76-1f5a70f40f5a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""088d4388-045a-45c2-ac76-1f5a70f40f5a"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001223%255Cproduct_picture_P_I201_XX_06097P.png.png"",
      ""part_number"": ""SIE.5ST3010"",
      ""eplan_id"": ""648875"",
      ""designation"": ""SENTRON Hilfsstromschalter anbaubar"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5ST3010"",
      ""order_number"": ""5ST3010""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f84f8958-01df-4cb7-b815-a5998af03617 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f84f8958-01df-4cb7-b815-a5998af03617"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SU%255Cproduct_picture_G_I202_XX_31949P.png.png"",
      ""part_number"": ""SIE.5SU1354-7KK06"",
      ""eplan_id"": ""455180"",
      ""designation"": ""FI/LS-Schalter / SENTRON FI/LS-Schalter / unverzögert"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SU1354-7KK06"",
      ""order_number"": ""5SU1354-7KK06""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4eefb9e9-ecc7-48d6-a371-d72a117b3842 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4eefb9e9-ecc7-48d6-a371-d72a117b3842"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4104-7"",
      ""eplan_id"": ""455305"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4104-7"",
      ""order_number"": ""5SY4104-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 89c496b3-9017-431c-9e22-3e03e44604bb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""89c496b3-9017-431c-9e22-3e03e44604bb"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4106-7"",
      ""eplan_id"": ""455315"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4106-7"",
      ""order_number"": ""5SY4106-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 39a07918-1ecb-4d58-8d89-d8a0e663e5e2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""39a07918-1ecb-4d58-8d89-d8a0e663e5e2"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4310-7"",
      ""eplan_id"": ""455524"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4310-7"",
      ""order_number"": ""5SY4310-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 00f421b2-010c-4abe-9251-fe0462238754 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""00f421b2-010c-4abe-9251-fe0462238754"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CMobile_Panel%255Cproduct_picture_P_ST80_XX_02761P.png.png"",
      ""part_number"": ""SIE.6AV2125-2AE23-0AX0"",
      ""eplan_id"": ""706965"",
      ""designation"": ""ANSCHLUSS-BOX ADVANCED"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2125-2AE23-0AX0"",
      ""order_number"": ""6AV2125-2AE23-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 78536c71-d174-4131-a98d-f10fc101fe3f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""78536c71-d174-4131-a98d-f10fc101fe3f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CMobile_Panel%255Cproduct_picture_P_ST70_XX_07205P.png.png"",
      ""part_number"": ""SIE.6AV2125-2JB23-0AX0"",
      ""eplan_id"": ""706969"",
      ""designation"": ""SIMATIC HMI KTP900F Mobile, 9.0\"" TFT-Display, 800x 480 Pixel, 16m Farben, Tasten-und Touchbedienung, 10 Funktionstasten, 1x PROFINET/Industrial Ethernet Schnittstelle, 1x Multimedia Karte, 1x USB, Schlüsselschalter, Zustimmtaster, Not-Halt/STOPP-Taster, projektierbar ab WinCC Comfort V13 SP1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2125-2JB23-0AX0"",
      ""order_number"": ""6AV2125-2JB23-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fa41f5a0-af16-4903-8500-297335e6537e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fa41f5a0-af16-4903-8500-297335e6537e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CHMI%255Cproduct_picture_P_ST80_XX_02786P.png.png"",
      ""part_number"": ""SIE.6AV2181-5AF10-0AX0"",
      ""eplan_id"": ""1094013"",
      ""designation"": ""Anschlusskabel 10 M KTP Mobile / SIMATIC, HMI / Anschlusskabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2181-5AF10-0AX0"",
      ""order_number"": ""6AV2181-5AF10-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9d8240f7-fdf3-4c6c-8ec3-fda78458f087 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9d8240f7-fdf3-4c6c-8ec3-fda78458f087"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CSIMATIC%255Cproduct_picture_P_ST80_XX_02785P.png.png"",
      ""part_number"": ""SIE.6AV2181-5AG80-0AX0"",
      ""eplan_id"": ""963789"",
      ""designation"": ""WANDHALTERUNG MOBILE PANELS, TYP 13 / SIMATIC HMI, SIMATIC / Zubehör"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2181-5AG80-0AX0"",
      ""order_number"": ""6AV2181-5AG80-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d9f21dd1-efe9-4fe7-adb9-37e74b85dd8d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d9f21dd1-efe9-4fe7-adb9-37e74b85dd8d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technology%255CPOWER%2520SUPPLIES%255C6EP33337SB000AX0.jpg.png"",
      ""part_number"": ""SIE.6EP3333-7SB00-0AX0"",
      ""eplan_id"": ""1006371"",
      ""designation"": ""SITOP PSU6200 1ph 24 V/5 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP3333-7SB00-0AX0"",
      ""order_number"": ""6EP3333-7SB00-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0cc4004a-c7b5-454e-b719-b7052683baa3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0cc4004a-c7b5-454e-b719-b7052683baa3"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technology%255CPOWER%2520SUPPLIES%255C6EP34377SB003AX0.jpg.png"",
      ""part_number"": ""SIE.6EP3437-7SB00-3AX0"",
      ""eplan_id"": ""1398562"",
      ""designation"": ""SITOP PSU6200 3ph 24 V/40 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP3437-7SB00-3AX0"",
      ""order_number"": ""6EP3437-7SB00-3AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d70c2110-6cd5-4049-a57e-45788a3370db (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d70c2110-6cd5-4049-a57e-45788a3370db"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_G_ST70_XX_02117P.png.png"",
      ""part_number"": ""SIE.6ES7131-6BF01-0BA0"",
      ""eplan_id"": ""977638"",
      ""designation"": ""SIMATIC ET 200SP DI 8x 24V DC ST, VPE 1 / Digitalmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7131-6BF01-0BA0"",
      ""order_number"": ""6ES7131-6BF01-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 77fe9174-873c-426a-a50e-004989782fca (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""77fe9174-873c-426a-a50e-004989782fca"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_G_ST70_XX_02081P.png.png"",
      ""part_number"": ""SIE.6ES7132-6BF01-0BA0"",
      ""eplan_id"": ""977641"",
      ""designation"": ""SIMATIC ET 200SP DQ 8x24VDC/0,5A ST / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7132-6BF01-0BA0"",
      ""order_number"": ""6ES7132-6BF01-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8f2fe0fd-abd7-42c7-92b3-ef3d6986193d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8f2fe0fd-abd7-42c7-92b3-ef3d6986193d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07162P.png.png"",
      ""part_number"": ""SIE.6ES7136-6BA01-0CA0"",
      ""eplan_id"": ""1556527"",
      ""designation"": ""SIMATIC ET 200SP F-DI 8x24VDC HF / Digitalmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7136-6BA01-0CA0"",
      ""order_number"": ""6ES7136-6BA01-0CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1516b06b-8bd7-4950-80b4-ebc0d2f35670 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1516b06b-8bd7-4950-80b4-ebc0d2f35670"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07164P.png.png"",
      ""part_number"": ""SIE.6ES7136-6DB00-0CA0"",
      ""eplan_id"": ""707293"",
      ""designation"": ""SIMATIC ET 200SP F-DQ 4x24 VDC/2A HF / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7136-6DB00-0CA0"",
      ""order_number"": ""6ES7136-6DB00-0CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ecf0266c-61f6-4751-a389-95f98ced96e6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ecf0266c-61f6-4751-a389-95f98ced96e6"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07672P.png.png"",
      ""part_number"": ""SIE.6ES7136-6DC00-0CA0"",
      ""eplan_id"": ""936595"",
      ""designation"": ""SIMATIC ET 200SP F-DQ 8x24 VDC/0,5 A PP HF / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7136-6DC00-0CA0"",
      ""order_number"": ""6ES7136-6DC00-0CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: dc77cd6d-b7e4-4bb7-978d-8406ce63bd5e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""dc77cd6d-b7e4-4bb7-978d-8406ce63bd5e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07168P.png.png"",
      ""part_number"": ""SIE.6ES7136-6RA00-0BF0"",
      ""eplan_id"": ""707300"",
      ""designation"": ""SIMATIC ET 200SP F-RQ 24 ... 48VDC/24 ... 230VAC/5A ST / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7136-6RA00-0BF0"",
      ""order_number"": ""6ES7136-6RA00-0BF0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 70cd0b72-523b-43e2-8729-d27e50832ac8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""70cd0b72-523b-43e2-8729-d27e50832ac8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_IC01_XX_00677P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP00-0BA0"",
      ""eplan_id"": ""458589"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ A0 BU15-P16+A0+2B / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP00-0BA0"",
      ""order_number"": ""6ES7193-6BP00-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 90e48d80-46bb-4e36-920d-2f4b63779720 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""90e48d80-46bb-4e36-920d-2f4b63779720"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05989P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP00-0DA0"",
      ""eplan_id"": ""458591"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ A0 BU15-P16+A0+2D / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP00-0DA0"",
      ""order_number"": ""6ES7193-6BP00-0DA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d98fbb0f-4ca0-4375-a573-5d7b5d7f448f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d98fbb0f-4ca0-4375-a573-5d7b5d7f448f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_G_ST70_XX_00925P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP20-0BF0"",
      ""eplan_id"": ""707430"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ F0 BU20-P8+A4+0B VPE 1 / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP20-0BF0"",
      ""order_number"": ""6ES7193-6BP20-0BF0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 46acd321-bd7f-4f57-9cb4-bfc5768051ca (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""46acd321-bd7f-4f57-9cb4-bfc5768051ca"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07156P.png.png"",
      ""part_number"": ""SIE.6ES7510-1SJ01-0AB0"",
      ""eplan_id"": ""707530"",
      ""designation"": ""CPU1510SP F-1 PN,150KB Prog./750KB Daten / SIMATIC ET 200SP Zentralbaugruppe"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7510-1SJ01-0AB0"",
      ""order_number"": ""6ES7510-1SJ01-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c1b87d98-556f-451c-871c-62e72003cf20 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c1b87d98-556f-451c-871c-62e72003cf20"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CS7-1500%255Cproduct_picture_P_ST70_XX_06330P.png.png"",
      ""part_number"": ""SIE.6ES7954-8LL03-0AA0"",
      ""eplan_id"": ""936610"",
      ""designation"": ""SIMATIC S7 MEMORY CARD, 256 MB / Speicherkarte"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7954-8LL03-0AA0"",
      ""order_number"": ""6ES7954-8LL03-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5e743e64-ab94-4ed9-b8a0-23c5a2fafc26 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5e743e64-ab94-4ed9-b8a0-23c5a2fafc26"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Communication%255CIE_FastConnect%255C6GK1901-1BB10-2AA0.jpg.png"",
      ""part_number"": ""SIE.6GK1901-1BB10-2AA0"",
      ""eplan_id"": ""1701386"",
      ""designation"": ""IE FC RJ45 Plug 180 2x2 (1 Stueck) / Verkabelungstechnik"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6GK1901-1BB10-2AA0"",
      ""order_number"": ""6GK1901-1BB10-2AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8f5b9ab3-a375-46f9-b177-59c3e78b2cb7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8f5b9ab3-a375-46f9-b177-59c3e78b2cb7"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Communication%255CSCALANCE_X100%255C6GK5116-0BA00-2AB2.jpg.png"",
      ""part_number"": ""SIE.6GK5116-0BA00-2AB2"",
      ""eplan_id"": ""1163638"",
      ""designation"": ""SCALANCE XB116 / SCALANCE XB-100"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6GK5116-0BA00-2AB2"",
      ""order_number"": ""6GK5116-0BA00-2AB2""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2c2dc5aa-37ea-48f9-867a-dec02d7286dd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2c2dc5aa-37ea-48f9-867a-dec02d7286dd"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Communication%255CSCALANCE_S600%255C6GK5615-0AA00-2AA2.jpg.png"",
      ""part_number"": ""SIE.6GK5615-0AA00-2AA2"",
      ""eplan_id"": ""707855"",
      ""designation"": ""SCALANCE S615 LAN-Router / Industrial Ethernet security"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6GK5615-0AA00-2AA2"",
      ""order_number"": ""6GK5615-0AA00-2AA2""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e53ac40f-4efe-4af4-ac4c-78fd7bf38b1c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e53ac40f-4efe-4af4-ac4c-78fd7bf38b1c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255C6XV1870-2B_P_IK10_XX_02393I.jpg.png"",
      ""part_number"": ""SIE.6XV1870-2B"",
      ""eplan_id"": ""1213198"",
      ""designation"": ""TP Flexibles Kabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6XV1870-2B"",
      ""order_number"": ""6XV1870-2B""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0f21a50a-a0c7-4bd1-b326-472b44f66ba0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0f21a50a-a0c7-4bd1-b326-472b44f66ba0"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2000%255C2000-2201.jpg.png"",
      ""part_number"": ""WAGO.2000-2201"",
      ""eplan_id"": ""657113"",
      ""designation"": ""Durchgangsreihenklemme / Doppelstockklemme, 1 mm², 13,5 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2000-2201"",
      ""order_number"": ""2000-2201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5627247b-374d-4b72-8bbd-9121627b64b3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5627247b-374d-4b72-8bbd-9121627b64b3"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2000%255C2000-2207.jpg.png"",
      ""part_number"": ""WAGO.2000-2207"",
      ""eplan_id"": ""657121"",
      ""designation"": ""Schutzleiter-Reihenklemme / Doppelstockklemme, 1 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2000-2207"",
      ""order_number"": ""2000-2207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7d901f7f-816d-4ec7-bd2b-5d1cd605f986 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7d901f7f-816d-4ec7-bd2b-5d1cd605f986"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1201.jpg.png"",
      ""part_number"": ""WAGO.2002-1201"",
      ""eplan_id"": ""489572"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 2,5 mm², 24 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1201"",
      ""order_number"": ""2002-1201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 47f3b461-f6f5-4ade-aa8e-e8c85c005e8e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""47f3b461-f6f5-4ade-aa8e-e8c85c005e8e"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1207.jpg.png"",
      ""part_number"": ""WAGO.2002-1207"",
      ""eplan_id"": ""489578"",
      ""designation"": ""Schutzleiter-Reihenklemme / 2-Leiter-Schutzleiterklemme, 2,5 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1207"",
      ""order_number"": ""2002-1207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2f3012d0-d5da-4027-a472-84ab86c613b4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2f3012d0-d5da-4027-a472-84ab86c613b4"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1401.jpg.png"",
      ""part_number"": ""WAGO.2002-1401"",
      ""eplan_id"": ""489602"",
      ""designation"": ""Durchgangsreihenklemme / 4-Leiter-Durchgangsklemme, 2,5 mm², 24 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1401"",
      ""order_number"": ""2002-1401""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 75077866-1d0e-469a-8768-8d3b51622e78 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""75077866-1d0e-469a-8768-8d3b51622e78"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1407.jpg.png"",
      ""part_number"": ""WAGO.2002-1407"",
      ""eplan_id"": ""489608"",
      ""designation"": ""Schutzleiter-Reihenklemme / 4-Leiter-Schutzleiterklemme, 2,5 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1407"",
      ""order_number"": ""2002-1407""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 618e7cc4-c0e0-4767-9c66-063e987aa620 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""618e7cc4-c0e0-4767-9c66-063e987aa620"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-1201.jpg.png"",
      ""part_number"": ""WAGO.2006-1201"",
      ""eplan_id"": ""489874"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 6 mm², 41 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-1201"",
      ""order_number"": ""2006-1201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 98fa2f50-53a9-439e-a84b-fd730ebe0631 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""98fa2f50-53a9-439e-a84b-fd730ebe0631"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-1207.jpg.png"",
      ""part_number"": ""WAGO.2006-1207"",
      ""eplan_id"": ""489877"",
      ""designation"": ""Schutzleiter-Reihenklemme / 2-Leiter-Schutzleiterklemme, 6 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-1207"",
      ""order_number"": ""2006-1207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e70b0f67-3c70-4af6-9bfc-e048423e7344 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e70b0f67-3c70-4af6-9bfc-e048423e7344"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-1201.jpg.png"",
      ""part_number"": ""WAGO.2010-1201"",
      ""eplan_id"": ""1222216"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 10 mm², 57 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-1201"",
      ""order_number"": ""2010-1201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: de19cab4-f595-4762-8669-fcf9c7f37d40 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""de19cab4-f595-4762-8669-fcf9c7f37d40"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-1207.jpg.png"",
      ""part_number"": ""WAGO.2016-1207"",
      ""eplan_id"": ""489952"",
      ""designation"": ""Schutzleiter-Reihenklemme / 2-Leiter-Schutzleiterklemme, 16 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-1207"",
      ""order_number"": ""2016-1207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4d51e0ef-a6c0-4d0d-9e3c-c40b429f4921 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4d51e0ef-a6c0-4d0d-9e3c-c40b429f4921"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C249%255C249-116.jpg.png"",
      ""part_number"": ""WAGO.249-116"",
      ""eplan_id"": ""1222681"",
      ""designation"": ""Endklammer/-halter für Reihenklemme / Schraubenlose Endklammer, 6 mm breit, für Tragschiene 35 x 15 und 35 x 7,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""249-116"",
      ""order_number"": ""249-116""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ae8b23f3-5d9f-45cf-a8bb-0ad81f4c242a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ae8b23f3-5d9f-45cf-a8bb-0ad81f4c242a"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C285%255C285-150.jpg.png"",
      ""part_number"": ""WAGO.285-150"",
      ""eplan_id"": ""496611"",
      ""designation"": ""Durchgangs-Reihenklemme / 2-Leiter-Durchgangsklemme; 50 mm²; 150 A; grau / seitliche Beschriftungsaufnahmen"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""285-150"",
      ""order_number"": ""285-150""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: eb074362-c685-415f-8359-0a926c06a035 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""eb074362-c685-415f-8359-0a926c06a035"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C285%255C285-447.jpg.png"",
      ""part_number"": ""WAGO.285-447"",
      ""eplan_id"": ""1222153"",
      ""designation"": ""Potentialabgriff / für Hochstromklemmen 50 mm² / Modulbreite 16 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""285-447"",
      ""order_number"": ""285-447""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b26ca957-5d4a-42a2-8b8c-c075b9e6b1af (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b26ca957-5d4a-42a2-8b8c-c075b9e6b1af"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C100-C%255CA-B.100-C_FS0.jpg.png"",
      ""part_number"": ""A-B.100-C09EJ01"",
      ""eplan_id"": ""14139"",
      ""designation"": ""IEC Contactor / Current: 9 A, Coil: 24V DC"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""100-C"",
      ""order_number"": ""100-C09EJ01""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2d56be88-e26e-4f99-baa0-0a6490648138 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2d56be88-e26e-4f99-baa0-0a6490648138"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C100-C%255CA-B.100-C_FS0.jpg.png"",
      ""part_number"": ""A-B.100-C23EJ10"",
      ""eplan_id"": ""14689"",
      ""designation"": ""IEC Contactor / Current: 23 A, Coil: 24V DC"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""100-C"",
      ""order_number"": ""100-C23EJ10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b89a31b7-9095-4275-955e-24f52a395cf3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b89a31b7-9095-4275-955e-24f52a395cf3"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C140G%255CA-B.140G-G-TC3H.jpg.png"",
      ""part_number"": ""A-B.140G-G-TC3H"",
      ""eplan_id"": ""27271"",
      ""designation"": ""Abdeckung / 3-Polig"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""140G"",
      ""order_number"": ""140G-G-TC3H""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 806f5a23-008b-4cb3-b981-11569dd7ad16 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""806f5a23-008b-4cb3-b981-11569dd7ad16"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C140M%255CA-B.140M-C.jpg.png"",
      ""part_number"": ""A-B.140M-C2E-B16"",
      ""eplan_id"": ""21025"",
      ""designation"": """",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""140M"",
      ""order_number"": ""140M-C2E-B16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b2c33e8c-4293-4b85-afc9-51ef48710626 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b2c33e8c-4293-4b85-afc9-51ef48710626"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C140M%255CA-B.140M-C.jpg.png"",
      ""part_number"": ""A-B.140M-C2E-C29"",
      ""eplan_id"": ""859835"",
      ""designation"": ""Sicherungsautomat / 3-Polig / Strom: 24 - 29 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""140M"",
      ""order_number"": ""140M-C2E-C29""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 658c51e3-ec18-4cad-aa5e-742d69735541 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""658c51e3-ec18-4cad-aa5e-742d69735541"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C140M%255CA-B.140M-C-AFA11.jpg.png"",
      ""part_number"": ""A-B.140M-C-AFA11"",
      ""eplan_id"": ""21036"",
      ""designation"": ""140M Zubehör / 1 N.O. / 1 N.C. Hilfskontakt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""140M"",
      ""order_number"": ""140M-C-AFA11""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 31674136-6eb4-4ef7-93bc-068136c3c60e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""31674136-6eb4-4ef7-93bc-068136c3c60e"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C140M%255CA-B.140M-C-AFA11.jpg.png"",
      ""part_number"": ""A-B.140M-RC-AFA11"",
      ""eplan_id"": ""860041"",
      ""designation"": ""140M Zubehör / 1 N.O. / 1 N.C. Hilfskontakt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""140M"",
      ""order_number"": ""140M-RC-AFA11""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3e91f612-0b8f-47b9-8a12-0483e537c287 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3e91f612-0b8f-47b9-8a12-0483e537c287"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C1492%255CA-B.1492-RCDA4.jpg.png"",
      ""part_number"": ""A-B.1492-RCDA4A25"",
      ""eplan_id"": ""25256"",
      ""designation"": ""Residual Current Device / 4-pole"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""1492"",
      ""order_number"": ""1492-RCDA4A25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5b39bd5b-c47a-490c-b4ac-bbd81f63a30b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5b39bd5b-c47a-490c-b4ac-bbd81f63a30b"",
      ""manufacturer_id"": ""221cabde-2728-4004-9108-1b3f13d5ccbd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/A-B/512/A-B%255C188%255CA-B.188-J1.jpg.png"",
      ""part_number"": ""A-B.188-J1C040"",
      ""eplan_id"": ""25821"",
      ""designation"": ""Miniature Circuit Breaker"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""188"",
      ""order_number"": ""188-J1C040""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b4eb0b9f-eb40-46b0-968a-88bdbcc93dff (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b4eb0b9f-eb40-46b0-968a-88bdbcc93dff"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBIS%255CBIS013U.png.png"",
      ""part_number"": ""BAL.BIS013U"",
      ""eplan_id"": ""631015"",
      ""designation"": ""Universal-Auswerteeinheiten (BIS V) / PROFINET IO: IRT fähiger 2-Port Switch, 172 mm x 50.00 mm x 62.00 mm, Werkstoff Gehäuse GD-Zn"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BIS V-6108-048-C002"",
      ""order_number"": ""BIS013U""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1b6fbe9a-c8eb-4b30-b699-e05732fc48f6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1b6fbe9a-c8eb-4b30-b699-e05732fc48f6"",
      ""manufacturer_id"": ""5fae4026-3f29-4a28-9b1f-1a17e638b522"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/EUC/512/Euchner%255Cast_663464_xl.png.png"",
      ""part_number"": ""EUC.100183"",
      ""eplan_id"": ""1885424"",
      ""designation"": ""Anschlussleitung mit geradem Steckverbinder M12, 5-polig, 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""C-M12F05-05X034PV05,0-MA-100183"",
      ""order_number"": ""100183""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a4135705-9bdb-46ca-99f3-32a242307a32 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a4135705-9bdb-46ca-99f3-32a242307a32"",
      ""manufacturer_id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FES/512/FESTO%255C13764k_1.jpg.png"",
      ""part_number"": ""FES.563059"",
      ""eplan_id"": ""104507"",
      ""designation"": ""Netzanschlussdose"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""NECU-M-PPG5-C1"",
      ""order_number"": ""563059""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d1463848-90c9-4c1d-92ec-207d0c5c451e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d1463848-90c9-4c1d-92ec-207d0c5c451e"",
      ""manufacturer_id"": ""62267cd8-cbb0-4de6-a6b6-67fd82a06f44"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FES2/512/Festo%255CD15000100114847_600x450.jpg.png"",
      ""part_number"": ""FES.571017"",
      ""eplan_id"": ""104845"",
      ""designation"": ""Stecker"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""FBS-SCRJ-PP-GS"",
      ""order_number"": ""571017""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c04a9040-69c7-44d2-ae4b-5353b0f5f530 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c04a9040-69c7-44d2-ae4b-5353b0f5f530"",
      ""manufacturer_id"": ""9c998708-8e74-4fd4-9cac-db6373d5eed1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/FIN/512/Finder%255C3851.jpg.png"",
      ""part_number"": ""FIN.38.51.0.024.0060"",
      ""eplan_id"": ""1105444"",
      ""designation"": ""Koppelrelais / Koppelrelais mit Schraubanschlüssen, 1 Wechsler 6 A, Spule 24 V AC/DC"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""38.51.0.024.0060"",
      ""order_number"": ""38.51.0.024.0060""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7f4f462d-a9e6-44f2-8d70-bf40c2670455 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7f4f462d-a9e6-44f2-8d70-bf40c2670455"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_024_4739_CMYK02.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330244739"",
      ""eplan_id"": ""602412"",
      ""designation"": ""Kontakteinsatz für Rechtecksteckverbinder / Han ES AV Pos. 24 Insert Term. Block rig"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09330244739"",
      ""order_number"": ""09330244739""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 41bb3fc6-6c73-44b5-9e2e-35a38f725b4e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""41bb3fc6-6c73-44b5-9e2e-35a38f725b4e"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_024_0232_CMYK02.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300240272"",
      ""eplan_id"": ""603428"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 24B-asg2-QB-M32"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 024 0272"",
      ""order_number"": ""19300240272""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8279a5ba-ec83-4bd1-913a-3ed52160d068 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8279a5ba-ec83-4bd1-913a-3ed52160d068"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_016_0527_CMYK02.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300160527"",
      ""eplan_id"": ""603264"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 16B-gs-M32"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 016 0527"",
      ""order_number"": ""19300160527""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ddbe3168-9b64-48eb-b9b4-7fb7d5f1658e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ddbe3168-9b64-48eb-b9b4-7fb7d5f1658e"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_024_0528_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300240527"",
      ""eplan_id"": ""603464"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 24B-gs-M32"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 024 0527"",
      ""order_number"": ""19300240527""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 27f3ceaa-dc79-4e0a-b689-c70dfa4c3394 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""27f3ceaa-dc79-4e0a-b689-c70dfa4c3394"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_30_024_0301_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09300240301"",
      ""eplan_id"": ""603479"",
      ""designation"": ""Gehäuse für Industriesteckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09300240301"",
      ""order_number"": ""09300240301""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 216ab06e-aafd-4ec3-aed3-c47c1113389e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""216ab06e-aafd-4ec3-aed3-c47c1113389e"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_000_9908_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330009908"",
      ""eplan_id"": ""605008"",
      ""designation"": ""Kodierelement für Industriesteckverbinder / Han Coding System Guide Pin"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 000 9908"",
      ""order_number"": ""09330009908""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a3f58ddf-eb4f-49ea-8fbb-6bb3b0df116a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a3f58ddf-eb4f-49ea-8fbb-6bb3b0df116a"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_000_9909_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330009909"",
      ""eplan_id"": ""605009"",
      ""designation"": ""Kodierelement für Industriesteckverbinder / Han Coding System Bushing"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 000 9909"",
      ""order_number"": ""09330009909""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4c0e2f3f-61be-4d2f-b55f-0567a378336f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4c0e2f3f-61be-4d2f-b55f-0567a378336f"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_010_2701_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330102701"",
      ""eplan_id"": ""602163"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 10E-bu-s"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 010 2701"",
      ""order_number"": ""09330102701""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c286b997-2e8d-43b2-afcc-6808a7dce1ae (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c286b997-2e8d-43b2-afcc-6808a7dce1ae"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_010_2601_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330102601"",
      ""eplan_id"": ""602162"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 10E-sti-s"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 010 2601"",
      ""order_number"": ""09330102601""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 19bde32a-797d-4c46-9447-d5152da109b7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""19bde32a-797d-4c46-9447-d5152da109b7"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_006_2716_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330062716"",
      ""eplan_id"": ""602151"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 6 ES-F"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 006 2716"",
      ""order_number"": ""09330062716""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d0725137-c850-43cf-ba2f-7d654d84a094 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d0725137-c850-43cf-ba2f-7d654d84a094"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_006_1250_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300061290"",
      ""eplan_id"": ""602924"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 6B-asg2-LB-M20"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 006 1290"",
      ""order_number"": ""19300061290""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3f8c907a-ad2d-4915-bfe4-a9484ac9ec99 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3f8c907a-ad2d-4915-bfe4-a9484ac9ec99"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_006_2616_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330062616"",
      ""eplan_id"": ""602150"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 6 ES-M"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 006 2616"",
      ""order_number"": ""09330062616""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 71cd95ae-f77a-4d75-a0b3-2743a5fc4f1a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""71cd95ae-f77a-4d75-a0b3-2743a5fc4f1a"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_016_2616_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330162616"",
      ""eplan_id"": ""602182"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 16 ES-M"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 016 2616"",
      ""order_number"": ""09330162616""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: edfa2f21-7f31-4576-90a8-c7f07c61dda2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""edfa2f21-7f31-4576-90a8-c7f07c61dda2"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_024_0528_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09300240801"",
      ""eplan_id"": ""603484"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 24B-g"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 30 024 0801"",
      ""order_number"": ""09300240801""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fefa5531-5100-48b6-8765-51b98e27061e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fefa5531-5100-48b6-8765-51b98e27061e"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_006_4729_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330064729"",
      ""eplan_id"": ""602375"",
      ""designation"": ""Kontakteinsatz für Rechtecksteckverbinder / Han ES AV Pos. 6 Insert Term. Block left"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09330064729"",
      ""order_number"": ""09330064729""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3139de70-3bcd-45df-8786-f13ad6b73922 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3139de70-3bcd-45df-8786-f13ad6b73922"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_016_1522_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300161522"",
      ""eplan_id"": ""603272"",
      ""designation"": ""Gehäuse für Industriesteckverbinder / Han 16B-gs-M32"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 016 1522"",
      ""order_number"": ""19300161522""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5e5281f8-d0af-4bdd-b6ca-97dc2fd2595f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5e5281f8-d0af-4bdd-b6ca-97dc2fd2595f"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C19_30_016_1231_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.19300161271"",
      ""eplan_id"": ""603237"",
      ""designation"": ""Gehäuse für Industriesteckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""19 30 016 1271"",
      ""order_number"": ""19300161271""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0088ed23-52d3-4c00-9b16-e762cf60b29a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0088ed23-52d3-4c00-9b16-e762cf60b29a"",
      ""manufacturer_id"": ""80f55f48-3a04-4fc1-b2e1-a4094a8f9cf4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/HAR/512/Harting%255C09_33_016_2716_CMYK01.TIF__WEB.jpg.png"",
      ""part_number"": ""HAR.09330162716"",
      ""eplan_id"": ""602184"",
      ""designation"": ""Kontakteinsatz für Industriesteckverbinder / Han 16 ES-F"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""09 33 016 2716"",
      ""order_number"": ""09330162716""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d13e2a60-5efd-4d06-898b-7f63c8e7ff51 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d13e2a60-5efd-4d06-898b-7f63c8e7ff51"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41302_preview.png.png"",
      ""part_number"": ""ICO.41302"",
      ""eplan_id"": ""174241"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 2 bk"",
      ""order_number"": ""41302""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 36e0f062-372a-4a23-a22c-7b0e7a1fc20e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""36e0f062-372a-4a23-a22c-7b0e7a1fc20e"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41305_preview.png.png"",
      ""part_number"": ""ICO.41305"",
      ""eplan_id"": ""174244"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 5 bk"",
      ""order_number"": ""41305""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ce6b4fdf-639a-4b18-a26f-ac694573c032 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ce6b4fdf-639a-4b18-a26f-ac694573c032"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41307_preview.png.png"",
      ""part_number"": ""ICO.41307"",
      ""eplan_id"": ""174246"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 7 bk"",
      ""order_number"": ""41307""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 04b3dbf8-1b28-4b01-9d00-38f244388344 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""04b3dbf8-1b28-4b01-9d00-38f244388344"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C58314_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1407465"",
      ""eplan_id"": ""401052"",
      ""designation"": ""Netzwerkkabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""NBC-MS/ 5,0-94B/FS SCO"",
      ""order_number"": ""1407465""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0ccd543d-8003-49f4-9c8e-18da2e45d58e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0ccd543d-8003-49f4-9c8e-18da2e45d58e"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41309_preview.png.png"",
      ""part_number"": ""ICO.41309"",
      ""eplan_id"": ""174248"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 9 bk"",
      ""order_number"": ""41309""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 54b965d8-fcf8-401a-bc34-17d6b7e2c74a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""54b965d8-fcf8-401a-bc34-17d6b7e2c74a"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41311_preview.png.png"",
      ""part_number"": ""ICO.41311"",
      ""eplan_id"": ""174250"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 11 bk"",
      ""order_number"": ""41311""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 37fdc766-00cf-4245-90ff-36e70e7a6320 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""37fdc766-00cf-4245-90ff-36e70e7a6320"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41313_preview.png.png"",
      ""part_number"": ""ICO.41313"",
      ""eplan_id"": ""174252"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 13 bk"",
      ""order_number"": ""41313""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 69dbfafb-ac0d-4ad5-9c40-de778f3b0f93 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""69dbfafb-ac0d-4ad5-9c40-de778f3b0f93"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41314_preview.png.png"",
      ""part_number"": ""ICO.41314"",
      ""eplan_id"": ""174253"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 14 bk"",
      ""order_number"": ""41314""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 11168448-a8fe-463b-a301-32adc41298c4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""11168448-a8fe-463b-a301-32adc41298c4"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41351_preview.png.png"",
      ""part_number"": ""ICO.41351"",
      ""eplan_id"": ""174272"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BTK bk"",
      ""order_number"": ""41351""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6c12969f-c691-403b-a0ea-e8d7912af3c8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6c12969f-c691-403b-a0ea-e8d7912af3c8"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41316_preview.png.png"",
      ""part_number"": ""ICO.41316"",
      ""eplan_id"": ""174255"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 16 bk"",
      ""order_number"": ""41316""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 36c1f3fc-37b2-4865-af4d-a5eb8e0f0b6f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""36c1f3fc-37b2-4865-af4d-a5eb8e0f0b6f"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41317_preview.png.png"",
      ""part_number"": ""ICO.41317"",
      ""eplan_id"": ""174256"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 17 bk"",
      ""order_number"": ""41317""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 96b0520d-4ea4-4ba5-bb4b-41f059198638 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""96b0520d-4ea4-4ba5-bb4b-41f059198638"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41321_preview.png.png"",
      ""part_number"": ""ICO.41321"",
      ""eplan_id"": ""174260"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 21 bk"",
      ""order_number"": ""41321""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cc29d23e-75ae-4651-9623-2273fb8f3d28 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cc29d23e-75ae-4651-9623-2273fb8f3d28"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41325_preview.png.png"",
      ""part_number"": ""ICO.41325"",
      ""eplan_id"": ""174264"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 25 bk"",
      ""order_number"": ""41325""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: afebba44-c755-465b-8543-bc9ed096bc52 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""afebba44-c755-465b-8543-bc9ed096bc52"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41327_preview.png.png"",
      ""part_number"": ""ICO.41327"",
      ""eplan_id"": ""174266"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KT 27 bk"",
      ""order_number"": ""41327""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 351f3992-2290-410e-adfc-5e7dd9be29cc (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""351f3992-2290-410e-adfc-5e7dd9be29cc"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.41352_preview.png.png"",
      ""part_number"": ""ICO.41352"",
      ""eplan_id"": ""174273"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BTG bk"",
      ""order_number"": ""41352""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d2a7a36a-37ef-4329-8d83-8bcddb693035 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d2a7a36a-37ef-4329-8d83-8bcddb693035"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.42241_preview.png.png"",
      ""part_number"": ""ICO.42241"",
      ""eplan_id"": ""174335"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KEL 24|10"",
      ""order_number"": ""42241""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 02023ee0-1d8b-406b-87ca-c1142e989d3e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""02023ee0-1d8b-406b-87ca-c1142e989d3e"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.54168_preview.png.png"",
      ""part_number"": ""ICO.54168"",
      ""eplan_id"": ""945191"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KEL-U 16|8"",
      ""order_number"": ""54168""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7db6acfd-b426-4260-9629-d7838927ef66 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7db6acfd-b426-4260-9629-d7838927ef66"",
      ""manufacturer_id"": ""9bdc9ea5-3d30-47e1-b04f-5c069b7f8cac"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ICO/512/Icotek%255CICO.54247_preview.png.png"",
      ""part_number"": ""ICO.54247"",
      ""eplan_id"": ""945205"",
      ""designation"": ""Einführungsflansch für Kleingehäuse/Schaltschrank"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KEL-U 24|7"",
      ""order_number"": ""54247""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6dab3421-bab9-4ca1-8bb7-d002ab83eb87 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6dab3421-bab9-4ca1-8bb7-d002ab83eb87"",
      ""manufacturer_id"": ""c7376656-14da-495b-b476-c7e28be2dfc9"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/IGUS/512/IGUS%255CCF_BUSPUR060.jpg.png"",
      ""part_number"": ""IGUS.CFBUS.PUR.060"",
      ""eplan_id"": ""176834"",
      ""designation"": ""Busleitung | PUR | chainflex® CFBUS.PUR (4x0,38)C / (4 x 0,38)C"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CFBUS.PUR"",
      ""order_number"": ""CFBUS.PUR.060""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6339ea7a-2c7c-4caa-83a5-51467bbafa3e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6339ea7a-2c7c-4caa-83a5-51467bbafa3e"",
      ""manufacturer_id"": ""c7376656-14da-495b-b476-c7e28be2dfc9"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/IGUS/512/IGUS%255CCF_CF113D-1.jpg.png"",
      ""part_number"": ""IGUS.CF113.028.D"",
      ""eplan_id"": ""176066"",
      ""designation"": ""Mess-Systemleitung | PUR | chainflex® CF113.D (2x(2x0,20)+(2x0,38))C / (2x(2x0,15)+(2x0,38))C"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CF113.D"",
      ""order_number"": ""CF113.028.D""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 76584393-ecef-45c6-b02e-e1197f9f0cb6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""76584393-ecef-45c6-b02e-e1197f9f0cb6"",
      ""manufacturer_id"": ""c7376656-14da-495b-b476-c7e28be2dfc9"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/IGUS/512/IGUS%255Cchainflex_CF210.UL.jpg.png"",
      ""part_number"": ""IGUS.CF270.UL.15.15.02.01.D"",
      ""eplan_id"": ""176385"",
      ""designation"": ""Servoleitung | PUR | chainflex® CF270.UL.D (4G1,5+(2x1,5)C)C"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CF270.UL.D"",
      ""order_number"": ""CF270.UL.15.15.02.01.D""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 73edce20-6993-4caf-b0e7-2886870ab2b2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""73edce20-6993-4caf-b0e7-2886870ab2b2"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSEF%252010.jpg.png"",
      ""part_number"": ""ILME.CSEF 10"",
      ""eplan_id"": ""1492040"",
      ""designation"": ""Buchseneinsatz, 10 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSEF 10"",
      ""order_number"": ""CSEF 10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c1f66193-affc-42a1-8e33-e2fd827a4b1a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c1f66193-affc-42a1-8e33-e2fd827a4b1a"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSEM%252010.jpg.png"",
      ""part_number"": ""ILME.CSEM 10"",
      ""eplan_id"": ""1492046"",
      ""designation"": ""Stifteinsatz, 10 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSEM 10"",
      ""order_number"": ""CSEM 10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6efe8d98-039d-4828-a472-fa349f995da4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6efe8d98-039d-4828-a472-fa349f995da4"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCNEM%252006%2520T.jpg.png"",
      ""part_number"": ""ILME.CNEM 06 T"",
      ""eplan_id"": ""1491891"",
      ""designation"": ""Stifteinsatz, 6 polig + PE, Schraubanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CNEM 06 T"",
      ""order_number"": ""CNEM 06 T""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 70a32210-3e65-4df8-a9c3-be442fdc795c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""70a32210-3e65-4df8-a9c3-be442fdc795c"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCTEF%252006%2520L_F.jpg.png"",
      ""part_number"": ""ILME.CTSEF 06 R"",
      ""eplan_id"": ""1492105"",
      ""designation"": ""Buchseneinsatz, 6 polig + PE / Anschlussverteiler Käfigzugfederanschluss / 16A max, 500 V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CTSEF 06 R"",
      ""order_number"": ""CTSEF 06 R""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3b4214aa-fcea-4997-97ad-346636a96cf8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3b4214aa-fcea-4997-97ad-346636a96cf8"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSEF%252016.jpg.png"",
      ""part_number"": ""ILME.CSEF 16"",
      ""eplan_id"": ""1492041"",
      ""designation"": ""Buchseneinsatz, 16 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSEF 16"",
      ""order_number"": ""CSEF 16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 357e49a1-8c42-402f-a58c-1be32573f241 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""357e49a1-8c42-402f-a58c-1be32573f241"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSEM%252016.jpg.png"",
      ""part_number"": ""ILME.CSEM 16"",
      ""eplan_id"": ""1492047"",
      ""designation"": ""Stifteinsatz, 16 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSEM 16"",
      ""order_number"": ""CSEM 16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b0e32e33-c6f6-4894-bef5-e12f112621df (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b0e32e33-c6f6-4894-bef5-e12f112621df"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSSF%252016_F.jpg.png"",
      ""part_number"": ""ILME.CSSF 16"",
      ""eplan_id"": ""1492069"",
      ""designation"": ""Buchseneinsatz, 16 polig + PE / Kontakteinsätze mit doppeltem Käfigzugfederanschluss / 16A max, 500 V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSSF 16"",
      ""order_number"": ""CSSF 16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: bb6a49aa-b2fa-455d-9ec1-03ba8a131968 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""bb6a49aa-b2fa-455d-9ec1-03ba8a131968"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSSM%252016_F.jpg.png"",
      ""part_number"": ""ILME.CSSM 16"",
      ""eplan_id"": ""1492075"",
      ""designation"": ""Stifteinsatz, 16 polig + PE / Kontakteinsätze mit doppeltem Käfigzugfederanschluss / 16A max, 500 V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSSM 16"",
      ""order_number"": ""CSSM 16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7a51f8e4-fc79-4446-859c-d8f90b3ee838 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7a51f8e4-fc79-4446-859c-d8f90b3ee838"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCOB%2520TSFS_F.jpg.png"",
      ""part_number"": ""ILME.COB TSFS"",
      ""eplan_id"": ""1491919"",
      ""designation"": ""Einsatzhalter für flexible Montage / Einsatzhalter für flexible Montage, für Kontakteinsätze mit Lochabstand an der Schmalseite = 27 mm,  für Zugentlastung mittels Kabelbindern od. geschraubter Zugentlastung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""COB TSFS"",
      ""order_number"": ""COB TSFS""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3e71d8b5-123e-4e0b-bcbc-844c22fe1c0f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3e71d8b5-123e-4e0b-bcbc-844c22fe1c0f"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSHF%252010.jpg.png"",
      ""part_number"": ""ILME.CSHF 10"",
      ""eplan_id"": ""1492052"",
      ""designation"": ""Buchseneinsatz, 10 polig + PE, SQUICH®"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSHF 10"",
      ""order_number"": ""CSHF 10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 818d8eed-8ed6-470a-ba17-270918adc0f8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""818d8eed-8ed6-470a-ba17-270918adc0f8"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSHM%252010.jpg.png"",
      ""part_number"": ""ILME.CSHM 10"",
      ""eplan_id"": ""1492060"",
      ""designation"": ""Stifteinsatz, 10 polig + PE, SQUICH®"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSHM 10"",
      ""order_number"": ""CSHM 10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4b1e5b9a-56e0-4a97-816e-c9d75d42b08d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4b1e5b9a-56e0-4a97-816e-c9d75d42b08d"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCDSF%252042.jpg.png"",
      ""part_number"": ""ILME.CDSF 42"",
      ""eplan_id"": ""1491309"",
      ""designation"": ""Buchseneinsatz, 42 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CDSF 42"",
      ""order_number"": ""CDSF 42""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9333b291-1580-499c-8aa4-bfe7a7e320a7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9333b291-1580-499c-8aa4-bfe7a7e320a7"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCDSM%252042.jpg.png"",
      ""part_number"": ""ILME.CDSM 42"",
      ""eplan_id"": ""1491315"",
      ""designation"": ""Stifteinsatz, 42 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CDSM 42"",
      ""order_number"": ""CDSM 42""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d55fd19b-f858-4ffe-8d12-d8b4bc3f347a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d55fd19b-f858-4ffe-8d12-d8b4bc3f347a"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCTSEF%252024%2520R%2520L_F.jpg.png"",
      ""part_number"": ""ILME.CTSEF 24 L"",
      ""eplan_id"": ""1492110"",
      ""designation"": ""Buchseneinsatz, 24 polig + PE / Anschlussverteiler Käfigzugfederanschluss / 16A max, 500 V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CTSEF 24 L"",
      ""order_number"": ""CTSEF 24 L""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: eca9ea1d-2012-4b5f-b948-21caaa3d3076 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""eca9ea1d-2012-4b5f-b948-21caaa3d3076"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCTSEF%252024%2520R%2520L_F.jpg.png"",
      ""part_number"": ""ILME.CTSEF 24 R"",
      ""eplan_id"": ""1492111"",
      ""designation"": ""Buchseneinsatz, 24 polig + PE / Anschlussverteiler Käfigzugfederanschluss / 16A max, 500 V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CTSEF 24 R"",
      ""order_number"": ""CTSEF 24 R""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d4dcaad5-32ed-4991-87be-2116aa48418d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d4dcaad5-32ed-4991-87be-2116aa48418d"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSEM%252024.jpg.png"",
      ""part_number"": ""ILME.CSEM 24"",
      ""eplan_id"": ""1492049"",
      ""designation"": ""Stifteinsatz, 24 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSEM 24"",
      ""order_number"": ""CSEM 24""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7ab945dc-5f57-4c04-b927-b4d00e53d8bd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7ab945dc-5f57-4c04-b927-b4d00e53d8bd"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCSEM%252006.jpg.png"",
      ""part_number"": ""ILME.CSEM 06"",
      ""eplan_id"": ""1492045"",
      ""designation"": ""Stifteinsatz, 6 polig + PE, Käfigzugfederanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CSEM 06"",
      ""order_number"": ""CSEM 06""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: acaefd3d-8c29-4889-bdee-bb6cda5a1e18 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""acaefd3d-8c29-4889-bdee-bb6cda5a1e18"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMHO%252024.32.jpg.png"",
      ""part_number"": ""ILME.MHO 24.32"",
      ""eplan_id"": ""1492913"",
      ""designation"": ""Tüllengehäuse, Gr.104.27"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHO 24.32"",
      ""order_number"": ""MHO 24.32""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 65569f6c-3ff4-477d-a389-9abb4f275413 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""65569f6c-3ff4-477d-a389-9abb4f275413"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMHO%252006%2520L20.jpg.png"",
      ""part_number"": ""ILME.MHO 06 L20"",
      ""eplan_id"": ""1492896"",
      ""designation"": ""Tüllengehäuse, Gr.44.27"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHO 06 L20"",
      ""order_number"": ""MHO 06 L20""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9f82e132-1331-488c-b14e-08e26306e745 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9f82e132-1331-488c-b14e-08e26306e745"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCHO%252010_F.jpg.png"",
      ""part_number"": ""ILME.MHO 10.25"",
      ""eplan_id"": ""1492901"",
      ""designation"": ""Kupplungsgehäuse Verschluss mit 4 Bolzen / Größe \""57.27\"", seitlicher Kabelausgang, M25 / Metall"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHO 10.25"",
      ""order_number"": ""MHO 10.25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7ef6ee6b-e9c2-4fae-89b2-792219c72b20 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7ef6ee6b-e9c2-4fae-89b2-792219c72b20"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCHO%252016_F.jpg.png"",
      ""part_number"": ""ILME.MHO 16.25"",
      ""eplan_id"": ""1492906"",
      ""designation"": ""Kupplungsgehäuse Verschluss mit 4 Bolzen / Größe \""77.27\"", seitlicher Kabelausgang, M25 / Metall"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHO 16.25"",
      ""order_number"": ""MHO 16.25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: be2c4e70-9914-4473-a462-3d770577ef4e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""be2c4e70-9914-4473-a462-3d770577ef4e"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCHO%252016_F.jpg.png"",
      ""part_number"": ""ILME.MAO 16.32"",
      ""eplan_id"": ""1492519"",
      ""designation"": ""Kupplungsgehäuse Verschluss mit 4 Bolzen / Größe \""77.27\"", seitlicher Kabelausgang, M32 / Metall"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MAO 16.32"",
      ""order_number"": ""MAO 16.32""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f72266e5-0b66-4e84-ae05-af3a544656be (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f72266e5-0b66-4e84-ae05-af3a544656be"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMAP%252010.232.jpg.png"",
      ""part_number"": ""ILME.MAP 10.232"",
      ""eplan_id"": ""1492568"",
      ""designation"": ""Sockelgehäuse, Größe \""57.27\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MAP 10.232"",
      ""order_number"": ""MAP 10.232""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 858ae8e2-ae46-4fda-b9be-ae814b79f08c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""858ae8e2-ae46-4fda-b9be-ae814b79f08c"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMAP%252024.232.jpg.png"",
      ""part_number"": ""ILME.MAP 24.232"",
      ""eplan_id"": ""1492610"",
      ""designation"": ""Sockelgehäuse, Größe \""104.27\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MAP 24.232"",
      ""order_number"": ""MAP 24.232""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8e815135-3216-4549-a051-e3775c91aca8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8e815135-3216-4549-a051-e3775c91aca8"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CJSHF%252006.jpg.png"",
      ""part_number"": ""ILME.JSHF 06"",
      ""eplan_id"": ""1492471"",
      ""designation"": ""Buchseneinsatz, 6 polig + PE, SQUICH®"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""JSHF 06"",
      ""order_number"": ""JSHF 06""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ba190208-ea65-4b81-9504-4ca1e8a748d8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ba190208-ea65-4b81-9504-4ca1e8a748d8"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CJSHF%252016.jpg.png"",
      ""part_number"": ""ILME.JSHF 16"",
      ""eplan_id"": ""1492473"",
      ""designation"": ""Buchseneinsatz, 16 polig + PE, SQUICH®"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""JSHF 16"",
      ""order_number"": ""JSHF 16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 125927ab-639b-4ca4-b392-0cba3724f9ad (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""125927ab-639b-4ca4-b392-0cba3724f9ad"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCPF%252006.jpg.png"",
      ""part_number"": ""ILME.CPF 06"",
      ""eplan_id"": ""1491920"",
      ""designation"": ""Buchseneinsatz, 6 polig + PE, Schraubanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CPF 06"",
      ""order_number"": ""CPF 06""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6d5ab4af-7d58-46b8-8c5e-aaaf9cbc99ad (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6d5ab4af-7d58-46b8-8c5e-aaaf9cbc99ad"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCPM%252006.jpg.png"",
      ""part_number"": ""ILME.CPM 06"",
      ""eplan_id"": ""1491923"",
      ""designation"": ""Stifteinsatz, 6 polig + PE, Schraubanschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CPM 06"",
      ""order_number"": ""CPM 06""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2a0be5cb-1303-43dc-833c-276f7b1029d7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2a0be5cb-1303-43dc-833c-276f7b1029d7"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CCHI%252016.jpg.png"",
      ""part_number"": ""ILME.CHI 16"",
      ""eplan_id"": ""1494750"",
      ""designation"": ""Anbaugehäuse, Größe \""77.27\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""CHI 16"",
      ""order_number"": ""CHI 16""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9dc631e0-c569-4ea5-8c65-35e04afba85a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9dc631e0-c569-4ea5-8c65-35e04afba85a"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMHP%252006%2520L20.jpg.png"",
      ""part_number"": ""ILME.MHP 06 L20"",
      ""eplan_id"": ""1492958"",
      ""designation"": ""Sockelgehäuse, Größe \""44.27\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHP 06 L20"",
      ""order_number"": ""MHP 06 L20""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f9ecd8a6-35ba-4677-94f7-3ca03b9a08aa (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f9ecd8a6-35ba-4677-94f7-3ca03b9a08aa"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMHP%252016.225.jpg.png"",
      ""part_number"": ""ILME.MHP 16.225"",
      ""eplan_id"": ""1492972"",
      ""designation"": ""Sockelgehäuse, Größe \""77.27\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHP 16.225"",
      ""order_number"": ""MHP 16.225""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 83e277c7-2a32-453f-86a2-9a5753972595 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""83e277c7-2a32-453f-86a2-9a5753972595"",
      ""manufacturer_id"": ""d3894e51-79a2-409a-bd2d-905f16454378"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/ILME/512/ILME%255CMHP%252024.25.jpg.png"",
      ""part_number"": ""ILME.MHP 24.25"",
      ""eplan_id"": ""1492983"",
      ""designation"": ""Sockelgehäuse, Größe \""104.27\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""MHP 24.25"",
      ""order_number"": ""MHP 24.25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 38f4511c-8a92-4c64-a79a-91002c8ba33a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""38f4511c-8a92-4c64-a79a-91002c8ba33a"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520MS-M.jpg.png"",
      ""part_number"": ""LAPP.53112650"",
      ""eplan_id"": ""1151430"",
      ""designation"": ""SKINTOP MS-SC M 32x1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® MS-SC-M"",
      ""order_number"": ""53112650""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 06fdea2a-6882-428f-b17b-95f94a1d9f96 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""06fdea2a-6882-428f-b17b-95f94a1d9f96"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINDICHT%2520SM-M.jpg.png"",
      ""part_number"": ""LAPP.52103010"",
      ""eplan_id"": ""1151185"",
      ""designation"": ""SKINDICHT SM-M 16x1,5 counter nut"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINDICHT® SM-M"",
      ""order_number"": ""52103010""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8dec2b53-1431-4683-a9fc-c04eadd88fb7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8dec2b53-1431-4683-a9fc-c04eadd88fb7"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520MS-M.jpg.png"",
      ""part_number"": ""LAPP.53112010"",
      ""eplan_id"": ""1151363"",
      ""designation"": ""SKINTOP MS-M 16x1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® MS-M"",
      ""order_number"": ""53112010""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 107001cc-ffde-4568-961f-740090a44f97 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""107001cc-ffde-4568-961f-740090a44f97"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINDICHT%2520SM-M.jpg.png"",
      ""part_number"": ""LAPP.52103020"",
      ""eplan_id"": ""1151186"",
      ""designation"": ""SKINDICHT SM-M 20x1,5 counter nut"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINDICHT® SM-M"",
      ""order_number"": ""52103020""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 78e26365-391c-43b2-85d8-90f9fed424c8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""78e26365-391c-43b2-85d8-90f9fed424c8"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520MS-M.jpg.png"",
      ""part_number"": ""LAPP.53112020"",
      ""eplan_id"": ""1151365"",
      ""designation"": ""SKINTOP MS-M 20x1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® MS-M"",
      ""order_number"": ""53112020""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3b045601-57de-4e83-943b-e7f4c3a374e2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3b045601-57de-4e83-943b-e7f4c3a374e2"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINDICHT%2520SM-M.jpg.png"",
      ""part_number"": ""LAPP.52103030"",
      ""eplan_id"": ""1151187"",
      ""designation"": ""SKINDICHT SM-M 25x1,5 counter nut"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINDICHT® SM-M"",
      ""order_number"": ""52103030""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 42b12b5f-a9a2-48e8-93b5-3dd0a6efd242 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""42b12b5f-a9a2-48e8-93b5-3dd0a6efd242"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520MS-M.jpg.png"",
      ""part_number"": ""LAPP.53112030"",
      ""eplan_id"": ""1151367"",
      ""designation"": ""SKINTOP MS-M 25x1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® MS-M"",
      ""order_number"": ""53112030""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2291fe16-6e44-4e11-a661-4a758c133c44 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2291fe16-6e44-4e11-a661-4a758c133c44"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINDICHT%2520SM-M.jpg.png"",
      ""part_number"": ""LAPP.52103040"",
      ""eplan_id"": ""1151188"",
      ""designation"": ""SKINDICHT SM-M 32x1,5 counter nut"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINDICHT® SM-M"",
      ""order_number"": ""52103040""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f0384014-f719-49f9-9dba-db49c3d08577 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f0384014-f719-49f9-9dba-db49c3d08577"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520MS-M.jpg.png"",
      ""part_number"": ""LAPP.53112040"",
      ""eplan_id"": ""1151369"",
      ""designation"": ""SKINTOP MS-M 32x1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® MS-M"",
      ""order_number"": ""53112040""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 13fb72df-ebcf-42a2-a184-3ad79d791fa8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""13fb72df-ebcf-42a2-a184-3ad79d791fa8"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520ST-M.jpg.png"",
      ""part_number"": ""LAPP.53111420"",
      ""eplan_id"": ""1151326"",
      ""designation"": ""SKINTOP ST-M 20x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® ST-M"",
      ""order_number"": ""53111420""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 68672713-1fc8-4451-8b4f-0e04e456e9ed (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""68672713-1fc8-4451-8b4f-0e04e456e9ed"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520GMP-GL-M.jpg.png"",
      ""part_number"": ""LAPP.53119023"",
      ""eplan_id"": ""1151526"",
      ""designation"": ""SKINTOP GMP-GL-M 20x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® GMP-GL-M"",
      ""order_number"": ""53119023""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ab977fc1-908b-4793-95b0-b4cda3183572 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ab977fc1-908b-4793-95b0-b4cda3183572"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520ST-M.jpg.png"",
      ""part_number"": ""LAPP.53111440"",
      ""eplan_id"": ""1151330"",
      ""designation"": ""SKINTOP ST-M 32x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® ST-M"",
      ""order_number"": ""53111440""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7b3bd060-161e-4175-94f0-8823569c5528 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7b3bd060-161e-4175-94f0-8823569c5528"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520GMP-GL-M.jpg.png"",
      ""part_number"": ""LAPP.53119043"",
      ""eplan_id"": ""1151530"",
      ""designation"": ""SKINTOP GMP-GL-M 32x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® GMP-GL-M"",
      ""order_number"": ""53119043""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0705f252-968c-43af-8775-3a32c9201810 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0705f252-968c-43af-8775-3a32c9201810"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520ST-M.jpg.png"",
      ""part_number"": ""LAPP.53111410"",
      ""eplan_id"": ""1151324"",
      ""designation"": ""SKINTOP ST-M 16x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® ST-M"",
      ""order_number"": ""53111410""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2896d96e-a6c6-4356-9b20-148a11fe3d82 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2896d96e-a6c6-4356-9b20-148a11fe3d82"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520GMP-GL-M.jpg.png"",
      ""part_number"": ""LAPP.53119013"",
      ""eplan_id"": ""1151524"",
      ""designation"": ""SKINTOP GMP-GL-M 16x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® GMP-GL-M"",
      ""order_number"": ""53119013""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 41bdf5cc-0772-46b1-91b0-8313ccdc85cf (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""41bdf5cc-0772-46b1-91b0-8313ccdc85cf"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520ST-M.jpg.png"",
      ""part_number"": ""LAPP.53111430"",
      ""eplan_id"": ""1151328"",
      ""designation"": ""SKINTOP ST-M 25x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® ST-M"",
      ""order_number"": ""53111430""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8451cdcc-2d9e-4fb2-8df1-7e1f059175b0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8451cdcc-2d9e-4fb2-8df1-7e1f059175b0"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520GMP-GL-M.jpg.png"",
      ""part_number"": ""LAPP.53119033"",
      ""eplan_id"": ""1151528"",
      ""designation"": ""SKINTOP GMP-GL-M 25x1,5 RAL 7035 LGY"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® GMP-GL-M"",
      ""order_number"": ""53119033""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7c88cfe3-a56b-49c3-87f4-bd4de6cae20e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7c88cfe3-a56b-49c3-87f4-bd4de6cae20e"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520DIX-DV.jpg.png"",
      ""part_number"": ""LAPP.53100005"",
      ""eplan_id"": ""1151272"",
      ""designation"": ""SKINTOP DIX-DV 5x11"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® DIX-DV"",
      ""order_number"": ""53100005""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9dbae2d1-cd2b-4a9e-b8f5-7b568c4bf51f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9dbae2d1-cd2b-4a9e-b8f5-7b568c4bf51f"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520DIX-M.jpg.png"",
      ""part_number"": ""LAPP.53332470"",
      ""eplan_id"": ""1151577"",
      ""designation"": ""SKINTOP DIX-M 32470"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® DIX-M"",
      ""order_number"": ""53332470""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 12860914-8fd2-4077-a53a-2badd98974c7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""12860914-8fd2-4077-a53a-2badd98974c7"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520DIX-M.jpg.png"",
      ""part_number"": ""LAPP.53332650"",
      ""eplan_id"": ""1151579"",
      ""designation"": ""SKINTOP DIX-M 32650"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® DIX-M"",
      ""order_number"": ""53332650""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 02b81e86-5f60-4c67-aed8-0f8a256a0924 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""02b81e86-5f60-4c67-aed8-0f8a256a0924"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520DIX-M%2520AUTOMATION%2520-%2520ASI%2520BUS%2520DUO.jpg.png"",
      ""part_number"": ""LAPP.53440980"",
      ""eplan_id"": ""1151603"",
      ""designation"": ""SKINTOP DIX-M 25 RJ45"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® DIX-M AUTOMATION"",
      ""order_number"": ""53440980""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f0754e0e-af39-4ca6-8f89-423337e54c16 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f0754e0e-af39-4ca6-8f89-423337e54c16"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255CSKINTOP%2520CUBE%2520FRAME.jpg.png"",
      ""part_number"": ""LAPP.52220001"",
      ""eplan_id"": ""1151231"",
      ""designation"": ""SKINTOP CUBE FRAME 24"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SKINTOP® CUBE"",
      ""order_number"": ""52220001""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c6bc808b-2e10-48f6-ab77-d8da4421705a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c6bc808b-2e10-48f6-ab77-d8da4421705a"",
      ""manufacturer_id"": ""fa3eb3f5-71b5-48fc-8193-c06f57e05248"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LUM/512/LUM%255CConnector%255CRSC50.jpg.png"",
      ""part_number"": ""LUM.11578"",
      ""eplan_id"": ""869645"",
      ""designation"": ""Steckverbinder, 7/8'' 3P, S, ger"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""RSC 30/11"",
      ""order_number"": ""11578""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 65a4a9db-4ab1-4856-b87c-f9a74c0af3e3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""65a4a9db-4ab1-4856-b87c-f9a74c0af3e3"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CConnection-Technology%255CT-coupler%255CSignal%255C7000_48151_0000000.png.png"",
      ""part_number"": ""MURR.7000-48151-0000000"",
      ""eplan_id"": ""1687783"",
      ""designation"": ""Sensor-Aktor-Adapter / T-Stück M12 St. / 2x M12 Bu. (8-pol.)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-48151-0000000"",
      ""order_number"": ""7000-48151-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8c0d88a9-3de9-45e5-bdca-42b263c91617 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8c0d88a9-3de9-45e5-bdca-42b263c91617"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-41211-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-41211-0000000"",
      ""eplan_id"": ""1687776"",
      ""designation"": ""Sensor-Aktor-Adapter / T-Stück SlimLine M12 St. / 2x M8 Bu. A-kod. 4-pol. / 2x 3-pol."",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-41211-0000000"",
      ""order_number"": ""7000-41211-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8dd881b8-2391-432c-8cf0-d5378ad3c21e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8dd881b8-2391-432c-8cf0-d5378ad3c21e"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12761-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12761-0000000"",
      ""eplan_id"": ""2300833"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 St. 0° A-kod. Schraubklemmanschluss 5-pol., max. 0,75mm² 6 - 8mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12761-0000000"",
      ""order_number"": ""7000-12761-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6a55cf66-6bbc-402a-a852-b25cd41b87f4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6a55cf66-6bbc-402a-a852-b25cd41b87f4"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12593-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12593-0000000"",
      ""eplan_id"": ""1934828"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 Bu. 0° A-kod. Schneidklemmanschluss, 5-pol., 0,34 - 0,5mm², 4,7 - 6mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12593-0000000"",
      ""order_number"": ""7000-12593-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3324f39f-86b2-4001-945e-249c8d02445b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3324f39f-86b2-4001-945e-249c8d02445b"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-08371-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-08371-0000000"",
      ""eplan_id"": ""2300822"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M8 Bu. 0° A-kod. Schneidklemmanschluss 3-pol., 0,14 - 0,34mm², 2,5 - 5,1mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-08371-0000000"",
      ""order_number"": ""7000-08371-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1c9246d0-8b80-444c-8b88-a6d022e791e6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1c9246d0-8b80-444c-8b88-a6d022e791e6"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12533-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12533-0000000"",
      ""eplan_id"": ""1934827"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 St. 0° A-kod. Schneidklemmanschluss, 5-pol., 0,34 - 0,5mm², 4,7 - 6mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12533-0000000"",
      ""order_number"": ""7000-12533-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 55b93e5e-0e9c-4181-855d-416c8a245632 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""55b93e5e-0e9c-4181-855d-416c8a245632"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-41121-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-41121-0000000"",
      ""eplan_id"": ""211534"",
      ""designation"": ""Sensor-Aktor-Adapter / T-Stück M12 St. / 2x M12 Bu. A-kod. 5-pol. / 2x 4-pol."",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-41121-0000000"",
      ""order_number"": ""7000-41121-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 06ca79cf-bb06-4833-8645-f1f2cda746f3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""06ca79cf-bb06-4833-8645-f1f2cda746f3"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-40021-634.jpg.png"",
      ""part_number"": ""MURR.7000-40021-6341000"",
      ""eplan_id"": ""1985115"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° / M12 Bu. 0° A-kod. PUR 4x0.34 sw UL/CSA+schleppk. 10m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-40021-6341000"",
      ""order_number"": ""7000-40021-6341000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: da0ef19d-4132-4565-b8a2-ecfbcfa9b045 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""da0ef19d-4132-4565-b8a2-ecfbcfa9b045"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-40561-650.jpg.png"",
      ""part_number"": ""MURR.7000-40561-6500500"",
      ""eplan_id"": ""1931127"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° / M8 Bu. 0° A-kod. PUR 3x0.25 sw UL/CSA+robot+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-40561-6500500"",
      ""order_number"": ""7000-40561-6500500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ef4225c1-baa0-4dc4-a51c-68725d3892f8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ef4225c1-baa0-4dc4-a51c-68725d3892f8"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-88001-630.jpg.png"",
      ""part_number"": ""MURR.7000-88001-6300500"",
      ""eplan_id"": ""1749166"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M8 St. 0° / M8 Bu. 0° A-kod. PUR 3x0.25 sw UL/CSA+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-88001-6300500"",
      ""order_number"": ""7000-88001-6300500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 88b6a876-f741-4b2e-ae18-4cc48238463d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""88b6a876-f741-4b2e-ae18-4cc48238463d"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CMit-freiem-Leitungsende%255CSignal%255C7000-12341-634.jpg.png"",
      ""part_number"": ""MURR.7000-12341-6341500"",
      ""eplan_id"": ""1797566"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 Bu. 90° A-kod. freies Ltg-ende PUR 4x0.34 sw UL/CSA+schleppk. 15m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12341-6341500"",
      ""order_number"": ""7000-12341-6341500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3981ba09-142f-4e36-9481-7138c7769791 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3981ba09-142f-4e36-9481-7138c7769791"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-659.jpg.png"",
      ""part_number"": ""MURR.7000-74301-6590150"",
      ""eplan_id"": ""1989275"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 1,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-6590150"",
      ""order_number"": ""7000-74301-6590150""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 28d61e7a-6059-4841-85c2-be2bb8e4dd20 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""28d61e7a-6059-4841-85c2-be2bb8e4dd20"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960200"",
      ""eplan_id"": ""1989520"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 2m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960200"",
      ""order_number"": ""7000-74301-7960200""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d2b576fb-8280-4ddf-b2b3-86cc26c2654e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d2b576fb-8280-4ddf-b2b3-86cc26c2654e"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960300"",
      ""eplan_id"": ""1989526"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 3m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960300"",
      ""order_number"": ""7000-74301-7960300""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 91725efc-a069-4ac5-a9c3-0c9865cf5178 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""91725efc-a069-4ac5-a9c3-0c9865cf5178"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960500"",
      ""eplan_id"": ""1989534"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960500"",
      ""order_number"": ""7000-74301-7960500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ff5e179f-76b1-461f-93d8-a3c0df007da9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ff5e179f-76b1-461f-93d8-a3c0df007da9"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7961000"",
      ""eplan_id"": ""1989543"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 10m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7961000"",
      ""order_number"": ""7000-74301-7961000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a7fdace5-fb5f-460b-8107-1dd47a670484 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a7fdace5-fb5f-460b-8107-1dd47a670484"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7962000"",
      ""eplan_id"": ""1989557"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 20m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7962000"",
      ""order_number"": ""7000-74301-7962000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0ee430f3-1921-43b6-a464-2cd3e27071c2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0ee430f3-1921-43b6-a464-2cd3e27071c2"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74305-796.jpg.png"",
      ""part_number"": ""MURR.7000-74305-7962000"",
      ""eplan_id"": ""1932372"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 Push Pull St. 0° AIDA / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 20m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74305-7962000"",
      ""order_number"": ""7000-74305-7962000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d12af6e3-f6c3-4113-88fc-1338c2af14ac (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d12af6e3-f6c3-4113-88fc-1338c2af14ac"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-659.jpg.png"",
      ""part_number"": ""MURR.7000-74301-6590250"",
      ""eplan_id"": ""1989277"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 2,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-6590250"",
      ""order_number"": ""7000-74301-6590250""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 08c8efd9-3159-49b1-b9d1-a9719109406c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""08c8efd9-3159-49b1-b9d1-a9719109406c"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960350"",
      ""eplan_id"": ""1989529"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 3,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960350"",
      ""order_number"": ""7000-74301-7960350""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 936a4062-c223-4ed1-8b70-165fad6e9421 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""936a4062-c223-4ed1-8b70-165fad6e9421"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7961500"",
      ""eplan_id"": ""1989550"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 15m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7961500"",
      ""order_number"": ""7000-74301-7961500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ccc27644-1a63-4b4b-b132-952dc319aecf (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ccc27644-1a63-4b4b-b132-952dc319aecf"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-44511-796.jpg.png"",
      ""part_number"": ""MURR.7000-44511-7961500"",
      ""eplan_id"": ""1931612"",
      ""designation"": ""Konfektionierte Datenleitung / M12 St. 0° / M12 St. 0° D-kod. geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 15m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-44511-7961500"",
      ""order_number"": ""7000-44511-7961500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 63e6a3a9-f775-4e91-8140-c5a83bf6c204 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""63e6a3a9-f775-4e91-8140-c5a83bf6c204"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-659.jpg.png"",
      ""part_number"": ""MURR.7000-74301-6590100"",
      ""eplan_id"": ""1989274"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 1m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-6590100"",
      ""order_number"": ""7000-74301-6590100""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 34fa027b-7713-4233-8b74-3aa29f1c3b52 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""34fa027b-7713-4233-8b74-3aa29f1c3b52"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-41131-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-41131-0000000"",
      ""eplan_id"": ""1687765"",
      ""designation"": ""Sensor-Aktor-Adapter / T-Stück SlimLine M12 St. / 2x M12 Bu. A-kod. 5-pol. / 2x 4-pol."",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-41131-0000000"",
      ""order_number"": ""7000-41131-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2b5188ef-17fc-498d-a1f0-0225ec1d945c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2b5188ef-17fc-498d-a1f0-0225ec1d945c"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12481-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12481-0000000"",
      ""eplan_id"": ""2300825"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 St. 0° A-kod. Schneidklemmanschluss 4-pol., 0,25 - 0,5mm², 4 - 5,1mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12481-0000000"",
      ""order_number"": ""7000-12481-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3c9c782d-5277-4c99-9c5d-d25e5cc23207 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3c9c782d-5277-4c99-9c5d-d25e5cc23207"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12491-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12491-0000000"",
      ""eplan_id"": ""2300826"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 St. 0° A-kod. Schneidklemmanschluss 4-pol., 0,14 - 0,34mm², 2,9 - 5,1mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12491-0000000"",
      ""order_number"": ""7000-12491-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e7dc2769-eed4-4285-919f-26237d748122 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e7dc2769-eed4-4285-919f-26237d748122"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12601-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12601-0000000"",
      ""eplan_id"": ""2300828"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 Bu. 0° A-kod. Schneidklemmanschluss 4-pol., 0,25 - 0,5mm², 4 - 5,1mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12601-0000000"",
      ""order_number"": ""7000-12601-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6cdbc4cd-4327-4091-8463-f193a1a32511 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6cdbc4cd-4327-4091-8463-f193a1a32511"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12611-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12611-0000000"",
      ""eplan_id"": ""2300829"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 Bu. 0° A-kod. Schneidklemmanschluss 4-pol., 0,14 - 0,34mm², 2,9 - 5,1mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12611-0000000"",
      ""order_number"": ""7000-12611-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cce8de6a-bfb5-4391-99e6-a3b7836f1018 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cce8de6a-bfb5-4391-99e6-a3b7836f1018"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CRelay-Modules%255C3000-16013-3100020.png.png"",
      ""part_number"": ""MURR.3000-16013-3100020"",
      ""eplan_id"": ""994060"",
      ""designation"": ""Schaltrelais / MIRO 6,2 steckbar Komplettmodul Ausgangsrelais (IN: 24 VAC/DC - OUT: 250 VAC/30VDC / 6 A)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3000-16013-3100020"",
      ""order_number"": ""3000-16013-3100020""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c5847510-7029-421f-8a3d-98cae78dd505 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c5847510-7029-421f-8a3d-98cae78dd505"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-40021-634.jpg.png"",
      ""part_number"": ""MURR.7000-40021-6340060"",
      ""eplan_id"": ""1985076"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° / M12 Bu. 0° A-kod. PUR 4x0.34 sw UL/CSA+schleppk. 0,6m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-40021-6340060"",
      ""order_number"": ""7000-40021-6340060""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cf533475-8ce4-4540-8743-235e7c4cd3d8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cf533475-8ce4-4540-8743-235e7c4cd3d8"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12901-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12901-0000000"",
      ""eplan_id"": ""2300834"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M12 Bu. 0° A-kod. Schraubklemmanschluss 4-pol., max. 0,75mm² 4 - 6mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12901-0000000"",
      ""order_number"": ""7000-12901-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f274ccac-dd3a-43ad-bf2c-0c2b7e7cb92c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f274ccac-dd3a-43ad-bf2c-0c2b7e7cb92c"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CPower%255C7000-50021-961.jpg.png"",
      ""part_number"": ""MURR.7000-50021-9610030"",
      ""eplan_id"": ""1748729"",
      ""designation"": ""Konfektionierte Energieleitung / 7/8'' St. 0° / 7/8'' Bu. 0° PUR 5x1.5 gr UL/CSA+schleppk. 0,3m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-50021-9610030"",
      ""order_number"": ""7000-50021-9610030""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 853b9cbc-32e3-49b9-81d1-81afd934de7a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""853b9cbc-32e3-49b9-81d1-81afd934de7a"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CPower%255C7000-50021-961.jpg.png"",
      ""part_number"": ""MURR.7000-50021-9611500"",
      ""eplan_id"": ""1748768"",
      ""designation"": ""Konfektionierte Energieleitung / 7/8'' St. 0° / 7/8'' Bu. 0° PUR 5x1.5 gr UL/CSA+schleppk. 15m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-50021-9611500"",
      ""order_number"": ""7000-50021-9611500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 76cb072e-a14d-43fe-ac87-ee1fd9359bdf (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""76cb072e-a14d-43fe-ac87-ee1fd9359bdf"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CMit-freiem-Leitungsende%255CSignal%255C7000-12021-234.jpg.png"",
      ""part_number"": ""MURR.7000-12021-2340100"",
      ""eplan_id"": ""1710220"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° A-kod. freies Ltg-ende PUR 4x0.34 gr UL/CSA+schleppk. 1m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12021-2340100"",
      ""order_number"": ""7000-12021-2340100""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7294df31-403e-4f44-b60c-fd7cf7e2d4c2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7294df31-403e-4f44-b60c-fd7cf7e2d4c2"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CMit-freiem-Leitungsende%255CSignal%255C7000-12181-233.jpg.png"",
      ""part_number"": ""MURR.7000-12181-2330300"",
      ""eplan_id"": ""1796567"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 Bu. 0° A-kod. freies Ltg-ende PUR 3x0.34 gr UL/CSA+schleppk. 3m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12181-2330300"",
      ""order_number"": ""7000-12181-2330300""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ad36cc7c-4a2d-4890-ac21-374807700267 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ad36cc7c-4a2d-4890-ac21-374807700267"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-50061-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-50061-0000000"",
      ""eplan_id"": ""2300852"",
      ""designation"": ""Sensor-Aktor-Adapter / T-Stück 7/8'' Bu. / 7/8\"" St. + 7/8\"" Bu. 5-pol."",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-50061-0000000"",
      ""order_number"": ""7000-50061-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 00d00ec5-11f5-44d9-ac0b-06e04155eef2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""00d00ec5-11f5-44d9-ac0b-06e04155eef2"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CPower%255C7000-50021-961.jpg.png"",
      ""part_number"": ""MURR.7000-50021-9610100"",
      ""eplan_id"": ""1748734"",
      ""designation"": ""Konfektionierte Energieleitung / 7/8'' St. 0° / 7/8'' Bu. 0° PUR 5x1.5 gr UL/CSA+schleppk. 1m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-50021-9610100"",
      ""order_number"": ""7000-50021-9610100""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3b4b459e-8419-4b15-9d75-6b693c982be3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3b4b459e-8419-4b15-9d75-6b693c982be3"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CMit-freiem-Leitungsende%255CPower%255C7000-78021-961.jpg.png"",
      ""part_number"": ""MURR.7000-78021-9610500"",
      ""eplan_id"": ""1748862"",
      ""designation"": ""Konfektionierte Energieleitung / 7/8'' Bu. 0° freies Ltg-ende PUR 5x1.5 gr UL/CSA+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-78021-9610500"",
      ""order_number"": ""7000-78021-9610500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d9d2b4ee-eeb2-4140-8614-edc08f0a4bc5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d9d2b4ee-eeb2-4140-8614-edc08f0a4bc5"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-40561-230.jpg.png"",
      ""part_number"": ""MURR.7000-40561-2300150"",
      ""eplan_id"": ""1930986"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° / M8 Bu. 0° A-kod. PUR 3x0.25 gr UL/CSA+schleppk. 1,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-40561-2300150"",
      ""order_number"": ""7000-40561-2300150""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c7234749-b603-471c-bdd2-93bd7c3966d9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c7234749-b603-471c-bdd2-93bd7c3966d9"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-74301-796.jpg.png"",
      ""part_number"": ""MURR.7000-74301-7960150"",
      ""eplan_id"": ""1989515"",
      ""designation"": ""Konfektionierte Datenleitung / RJ45 St. 0° / RJ45 St. 0° geschirmt PUR 1x4xAWG22 geschirmt gn UL/CSA+schleppk. 1,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74301-7960150"",
      ""order_number"": ""7000-74301-7960150""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c2229549-e3e6-4c02-bb5b-51cee5c7e0ef (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c2229549-e3e6-4c02-bb5b-51cee5c7e0ef"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CModules%255C9000_41091_0101000.png.png"",
      ""part_number"": ""MURR.9000-41091-0101000"",
      ""eplan_id"": ""1179439"",
      ""designation"": ""Stromüberwachungsgerät / Mico Pro Lastkreisüberwachung, 1-kanalig (IN: 24 V DC OUT: 24 V DC / 1-2-3-4-5-6-7-8-9-10A)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41091-0101000"",
      ""order_number"": ""9000-41091-0101000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7657ba04-b13c-455c-93f0-a55d03c6b97d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7657ba04-b13c-455c-93f0-a55d03c6b97d"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CAccessories%255C9000_41034_0000002.png.png"",
      ""part_number"": ""MURR.9000-41034-0000002"",
      ""eplan_id"": ""211430"",
      ""designation"": ""Überwachungsgerät (Zubehör) / MICO Zubehör (MICO Brückset (Inhalt 1 Set))"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41034-0000002"",
      ""order_number"": ""9000-41034-0000002""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d8c6667d-0747-404e-a4b7-32892a049d03 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d8c6667d-0747-404e-a4b7-32892a049d03"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CModules%255C9000_41190_0000000.png.png"",
      ""part_number"": ""MURR.9000-41190-0000000"",
      ""eplan_id"": ""1179443"",
      ""designation"": ""Stromüberwachungsgerät / Mico Pro Einspeisemodul (IN: 24 V DC / 40A, 16mm²)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41190-0000000"",
      ""order_number"": ""9000-41190-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f9f755e9-943f-4624-ae32-a3ad6861f054 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f9f755e9-943f-4624-ae32-a3ad6861f054"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255COptocouplers-Semiconductors%255CAccessories%255CWiring-accessories%255C90960.png.png"",
      ""part_number"": ""MURR.90960"",
      ""eplan_id"": ""1799026"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Verbindungsstecker (Steckbrücke)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""90960"",
      ""order_number"": ""90960""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4afe0f6f-1e1a-41ba-a1ad-69b980dcf709 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4afe0f6f-1e1a-41ba-a1ad-69b980dcf709"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CDistribution-System%255CIMPACT67%255C55092.jpg.png"",
      ""part_number"": ""MURR.55092"",
      ""eplan_id"": ""211473"",
      ""designation"": ""IMPACT67 PNIO DI8 DO8 / 8 digitale Eingänge + 8 digitale Ausgänge / PROFINET IO"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""IMPACT67 PNIO DI8 DO8"",
      ""order_number"": ""55092""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0870817a-96be-40eb-a207-146243a013ff (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0870817a-96be-40eb-a207-146243a013ff"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CModules%255C9000_41084_0401000.png.png"",
      ""part_number"": ""MURR.9000-41084-0401000"",
      ""eplan_id"": ""211453"",
      ""designation"": ""Stromüberwachungsgerät / MICO+ 4.10 Lastkreisüberwachung, 4-kanalig (IN: 24 V DC OUT: 24 V DC / 4-6-8-10 A)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41084-0401000"",
      ""order_number"": ""9000-41084-0401000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a359dc89-2535-4f00-97e8-ca191ecb6488 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a359dc89-2535-4f00-97e8-ca191ecb6488"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-08365-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-08365-0000000"",
      ""eplan_id"": ""1934825"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / M8 Bu. 0° A-kod. Schneidklemmanschluss, 3-pol., 0,25 - 0,5mm², 2,5 - 5mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-08365-0000000"",
      ""order_number"": ""7000-08365-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 52540b00-2ee9-40b5-a96d-745f0a33c8ff (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""52540b00-2ee9-40b5-a96d-745f0a33c8ff"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-41181-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-41181-0000000"",
      ""eplan_id"": ""1687773"",
      ""designation"": ""Sensor-Aktor-Adapter / T-Stück M12 St. / M12 Bu. A-kod. 5-pol. / 2x 5-pol."",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-41181-0000000"",
      ""order_number"": ""7000-41181-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1250ec36-b48e-4209-9aec-58d03befe014 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1250ec36-b48e-4209-9aec-58d03befe014"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CInterfaces%255CFront-Panel-Interfaces%255CInserts%255C4000_68000_4500004.png.png"",
      ""part_number"": ""MURR.4000-68000-4500004"",
      ""eplan_id"": ""1179310"",
      ""designation"": ""Frontplatte (Schaltschrank) / Modlink MSDD Kombieinsatz 1-fach Deutschland (2xRJ45)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""4000-68000-4500004"",
      ""order_number"": ""4000-68000-4500004""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ab4a9b65-d2d4-46b8-a2ad-32063bd15afa (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ab4a9b65-d2d4-46b8-a2ad-32063bd15afa"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-12961-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-12961-0000000"",
      ""eplan_id"": ""2300837"",
      ""designation"": ""Sensor-Aktor-Adapter / M12 Bu. 0° A-kod. Schraubklemmanschluss 5-pol., max. 0,75mm², 6 - 8mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12961-0000000"",
      ""order_number"": ""7000-12961-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a2e9d070-b838-4e31-a1b8-439061ba44d9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a2e9d070-b838-4e31-a1b8-439061ba44d9"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CInterfaces%255CFront-Panel-Interfaces%255CFrame%255C4000-68113-0000000.jpg.png"",
      ""part_number"": ""MURR.4000-68113-0000000"",
      ""eplan_id"": ""211711"",
      ""designation"": ""Modlink MSDD Einbaurahmen 1-fach Metall / matt vernickelt / Rahmen: Metall, matt vernickelt Deckel: Metall, matt vernickelt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""4000-68113-0000000"",
      ""order_number"": ""4000-68113-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 39efd3ae-4f64-45a2-af0c-aee9760ffad5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""39efd3ae-4f64-45a2-af0c-aee9760ffad5"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-78081-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-78081-0000000"",
      ""eplan_id"": ""2300862"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / 7/8'' St. 0° Schraubklemmanschluss 5-pol., max. 1,5mm², 6-8mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-78081-0000000"",
      ""order_number"": ""7000-78081-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 97aebff5-75e8-4e36-ba28-b841e67956d1 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""97aebff5-75e8-4e36-ba28-b841e67956d1"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-78091-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-78091-0000000"",
      ""eplan_id"": ""2283812"",
      ""designation"": ""Sensor-Aktor-Adapter / 7/8'' St. 0° Schneidklemmanschluss 5-pol., 0,75 - 1,5mm², 6,8 - 12,5mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-78091-0000000"",
      ""order_number"": ""7000-78091-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5158770a-2791-4792-868a-2ec5a86656ab (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5158770a-2791-4792-868a-2ec5a86656ab"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-78211-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-78211-0000000"",
      ""eplan_id"": ""2300863"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / 7/8'' Bu. 0° Schneidklemmanschluss \""5-pol., 0,75 - 1,5mm²; 6,8 - 12,5mm\"""",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-78211-0000000"",
      ""order_number"": ""7000-78211-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: aa214dd0-d4ca-4c83-bda8-42224b1868f9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""aa214dd0-d4ca-4c83-bda8-42224b1868f9"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-44001-840.jpg.png"",
      ""part_number"": ""MURR.7000-44001-8400050"",
      ""eplan_id"": ""1934582"",
      ""designation"": ""Konfektionierte Datenleitung / M12 St. 0° / M12 Bu. 0° B-kod. geschirmt PUR 1x2xAWG24 geschirmt vt UL/CSA+schleppk. 0,5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-44001-8400050"",
      ""order_number"": ""7000-44001-8400050""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7dfb85b1-802d-48e8-ad47-675111f690c6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7dfb85b1-802d-48e8-ad47-675111f690c6"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CDaten%255C7000-44001-840.jpg.png"",
      ""part_number"": ""MURR.7000-44001-8401000"",
      ""eplan_id"": ""1934622"",
      ""designation"": ""Konfektionierte Datenleitung / M12 St. 0° / M12 Bu. 0° B-kod. geschirmt PUR 1x2xAWG24 geschirmt vt UL/CSA+schleppk. 10m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-44001-8401000"",
      ""order_number"": ""7000-44001-8401000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 42022d8b-0f06-4213-b76b-aaf583c41618 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""42022d8b-0f06-4213-b76b-aaf583c41618"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C55562.png.png"",
      ""part_number"": ""MURR.55562"",
      ""eplan_id"": ""1179449"",
      ""designation"": ""Feldbus, Dez. Peripherie - Digitales Ein-/Ausgangs-Modul / MVK-MPNIO F DI16/8, MVK ProfiNet/PROFIsafe Kompaktmodul, Metall"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""55562"",
      ""order_number"": ""55562""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 64bed539-bd6d-4c0d-b3d8-88927e1ce841 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""64bed539-bd6d-4c0d-b3d8-88927e1ce841"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C55563.png.png"",
      ""part_number"": ""MURR.55563"",
      ""eplan_id"": ""1179450"",
      ""designation"": ""Feldbus, Dez. Peripherie - Digitales Ein-/Ausgangs-Modul / MVK-MPNIO F DI8/4 F DO4, MVK ProfiNet/PROFIsafe Kompaktmodul, Metall"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""55563"",
      ""order_number"": ""55563""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3fdb7739-67e0-4f6e-9972-33e367fc588b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3fdb7739-67e0-4f6e-9972-33e367fc588b"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-40021-634.jpg.png"",
      ""part_number"": ""MURR.7000-40021-6341500"",
      ""eplan_id"": ""1985123"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° / M12 Bu. 0° A-kod. PUR 4x0.34 sw UL/CSA+schleppk. 15m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-40021-6341500"",
      ""order_number"": ""7000-40021-6341500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 43db7e9f-b7cc-4e16-bcf9-44126fe257eb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""43db7e9f-b7cc-4e16-bcf9-44126fe257eb"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255Chousing%255C64792_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1411162"",
      ""eplan_id"": ""647514"",
      ""designation"": ""Kabelverschraubung / Kabelverschraubung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""G-INS-M16-S68N-NNES-S"",
      ""order_number"": ""1411162""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2d6d7333-30d7-4b3e-abc4-ac5f1544b373 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2d6d7333-30d7-4b3e-abc4-ac5f1544b373"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255Chousing%255C64792_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1411163"",
      ""eplan_id"": ""647515"",
      ""designation"": ""Kabelverschraubung / Kabelverschraubung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""G-INS-M20-S68N-NNES-S"",
      ""order_number"": ""1411163""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 76d5cea4-51ac-4f09-a030-27d775fcc49d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""76d5cea4-51ac-4f09-a030-27d775fcc49d"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C64630_2000_int_04.jpg.png"",
      ""part_number"": ""PXC.1641769"",
      ""eplan_id"": ""2132133"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SACC-M12MS-4QO-0,75"",
      ""order_number"": ""1641769""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9fff0762-c781-437d-86ee-a56bd967eac9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9fff0762-c781-437d-86ee-a56bd967eac9"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255Chousing%255C64792_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1411165"",
      ""eplan_id"": ""647516"",
      ""designation"": ""Kabelverschraubung / Kabelverschraubung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""G-INS-M25-M68N-NNES-S"",
      ""order_number"": ""1411165""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 77da0054-e409-428f-adce-2eea95f9acbb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""77da0054-e409-428f-adce-2eea95f9acbb"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C42086_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1507764"",
      ""eplan_id"": ""403696"",
      ""designation"": ""Bussystem-Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SACC-M12MSB-5CON-PG9 SH AU"",
      ""order_number"": ""1507764""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5aaec552-dd63-41cf-bad3-bd8485a15796 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5aaec552-dd63-41cf-bad3-bd8485a15796"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C61742_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1511857"",
      ""eplan_id"": ""403777"",
      ""designation"": ""Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SACC-M12MS-8CON-PG 9-SH"",
      ""order_number"": ""1511857""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 578b2254-3306-4a36-8c23-418f8db64756 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""578b2254-3306-4a36-8c23-418f8db64756"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C146005_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1513347"",
      ""eplan_id"": ""1237388"",
      ""designation"": ""Rundsteckverbinder (feldkonfektionierbar) / Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SACC-M12FS-8CON-PG9-M"",
      ""order_number"": ""1513347""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 08d8e233-0f49-46e6-9499-aa28d4d14d8e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""08d8e233-0f49-46e6-9499-aa28d4d14d8e"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C32838_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1513334"",
      ""eplan_id"": ""403788"",
      ""designation"": ""Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SACC-M12MS-8CON-PG9-M"",
      ""order_number"": ""1513334""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3e99d150-5517-45e4-bdc2-9bd50352955c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3e99d150-5517-45e4-bdc2-9bd50352955c"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C53471_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1404420"",
      ""eplan_id"": ""400662"",
      ""designation"": ""Steckverbinder"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SACC-M12FS-12SOL-PG 9-M"",
      ""order_number"": ""1404420""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 234d78c4-ccea-4e16-ad74-407839dea3a0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""234d78c4-ccea-4e16-ad74-407839dea3a0"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C58312_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1407416"",
      ""eplan_id"": ""401012"",
      ""designation"": ""Netzwerkkabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""NBC-MS/ 5,0-94B/R4AC SCO"",
      ""order_number"": ""1407416""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6f1cb696-9898-4af1-8d23-7bef39b6bafd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6f1cb696-9898-4af1-8d23-7bef39b6bafd"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C58313_1000_int_04.jpg.png"",
      ""part_number"": ""PXC.1407435"",
      ""eplan_id"": ""401027"",
      ""designation"": ""Netzwerkkabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""NBC-MS/ 2,0-94B/MS SCO"",
      ""order_number"": ""1407435""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 14fc99c5-c6d4-42b7-be49-95ee12e7b801 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""14fc99c5-c6d4-42b7-be49-95ee12e7b801"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C72748_2000_int_04.jpg.png"",
      ""part_number"": ""PXC.3212064"",
      ""eplan_id"": ""572088"",
      ""designation"": ""Durchgangsklemme / Hochstromklemme"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PTPOWER 35"",
      ""order_number"": ""3212064""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 11d65951-55c1-4f88-8aad-ed455a876baa (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""11d65951-55c1-4f88-8aad-ed455a876baa"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C72750_3000_int_04.jpg.png"",
      ""part_number"": ""PXC.3212066"",
      ""eplan_id"": ""572090"",
      ""designation"": ""Schutzleiterklemme / Schutzleiter-Reihenklemme"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PTPOWER 35-PE"",
      ""order_number"": ""3212066""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8172e4b3-5242-4f5e-b7d6-0d445d541b03 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8172e4b3-5242-4f5e-b7d6-0d445d541b03"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C73384_2000_int_04.jpg.png"",
      ""part_number"": ""PXC.3212065"",
      ""eplan_id"": ""572089"",
      ""designation"": ""Durchgangsklemme / Hochstromklemme"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PTPOWER 35 BU"",
      ""order_number"": ""3212065""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9aa20287-346c-4168-ba42-de7cf60b0984 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9aa20287-346c-4168-ba42-de7cf60b0984"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C49534_2000_int_04.jpg.png"",
      ""part_number"": ""PXC.3212131"",
      ""eplan_id"": ""418339"",
      ""designation"": ""Schutzleiterklemme / Schutzleiter-Reihenklemme"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PT 10-PE"",
      ""order_number"": ""3212131""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7addbb7f-a543-45ab-a660-a7316bc53df6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7addbb7f-a543-45ab-a660-a7316bc53df6"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C35087_2000_int_04.jpg.png"",
      ""part_number"": ""PXC.3030417"",
      ""eplan_id"": ""416064"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschlussdeckel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""D-ST 2,5"",
      ""order_number"": ""3030417""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3b6e2263-7a37-4e9b-a297-98e216d03e6a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3b6e2263-7a37-4e9b-a297-98e216d03e6a"",
      ""manufacturer_id"": ""85042b1c-f338-4da2-8cf7-0e242cf8bfb6"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PXC/512/PXC%255C35081_2000_int_04.jpg.png"",
      ""part_number"": ""PXC.3030514"",
      ""eplan_id"": ""416074"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschlussdeckel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""D-ST 2,5-QUATTRO"",
      ""order_number"": ""3030514""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 742dc322-f70c-443a-b9c2-8d8bb7dd49c0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""742dc322-f70c-443a-b9c2-8d8bb7dd49c0"",
      ""manufacturer_id"": ""87c181bf-9b04-4d16-9a65-9c38c719fac4"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/PILZ/512/PILZ%255CF-PNOZ-s11-188.jpg.png"",
      ""part_number"": ""PILZ.751111"",
      ""eplan_id"": ""1091438"",
      ""designation"": ""Gerät zur Überwachung von sicherheitsgerichteten Stromkreisen / PNOZsigma Kontakterweiterung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""PNOZ s11 C 24VDC 8 n/o 1 n/c"",
      ""order_number"": ""751111""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 281fc5fe-e975-4d6c-8488-dbbb29960063 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""281fc5fe-e975-4d6c-8488-dbbb29960063"",
      ""manufacturer_id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SE/512/Schneider%2520Electric%255CHarmony%2520XB5%255Czb5az009.jpg.png"",
      ""part_number"": ""SE.ZB5AZ009"",
      ""eplan_id"": ""598806"",
      ""designation"": ""Befestigungsflansch für Ø 22 mm Geräte XB5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": """",
      ""order_number"": ""ZB5AZ009""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 240a8a71-60d9-4b89-910f-22dc18db3ee6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""240a8a71-60d9-4b89-910f-22dc18db3ee6"",
      ""manufacturer_id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SE/512/Schneider%2520Electric%255CHarmony%2520XB4%255Czb4bs844.jpg.png"",
      ""part_number"": ""SE.ZB4BS844"",
      ""eplan_id"": ""598648"",
      ""designation"": ""Frontelem., rund f. Pilzdrucktaster Ø 22 - Drehentriegelung - Ø 40 mm - rot"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": """",
      ""order_number"": ""ZB4BS844""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0e9ce712-4172-494c-a8eb-9bf671ed92e9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0e9ce712-4172-494c-a8eb-9bf671ed92e9"",
      ""manufacturer_id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SE/512/Schneider%2520Electric%255CHarmony%2520XB5%255Czb5as844.jpg.png"",
      ""part_number"": ""SE.ZB5AS844"",
      ""eplan_id"": ""598738"",
      ""designation"": ""Frontelem., rund f. Not-Halt/Not-Aus-Taster Ø 40 - Drehentriegelung - Ø 22 - rot"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": """",
      ""order_number"": ""ZB5AS844""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0fcf063c-2b59-46a0-8bdc-1efedbb3bee8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0fcf063c-2b59-46a0-8bdc-1efedbb3bee8"",
      ""manufacturer_id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SE/512/Schneider%2520Electric%255CHarmony%2520XB5%255Czb5aw313.jpg.png"",
      ""part_number"": ""SE.ZB5AW313"",
      ""eplan_id"": ""598776"",
      ""designation"": ""Frontelement Leuchtdrucktaster - Ø 22 - weiß"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": """",
      ""order_number"": ""ZB5AW313""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1938c009-1f0d-4128-b188-3db550852318 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1938c009-1f0d-4128-b188-3db550852318"",
      ""manufacturer_id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SE/512/Schneider%2520Electric%255CHARMONY%255CHARMONY%2520SIGNALLING%255CSE_HARMONY_FIXING%2520UNIT%2520WITH%2520SUPPORT_80MM.png.png"",
      ""part_number"": ""SE.XVBZ02"",
      ""eplan_id"": ""850974"",
      ""designation"": ""FIXING BASE 80MM MIT SCHWARZER UNTERSTÜTZUNGSROHR"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""XVBZ02"",
      ""order_number"": ""XVBZ02""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 32dd5f4a-b10e-4126-9ae6-97e7a0842822 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""32dd5f4a-b10e-4126-9ae6-97e7a0842822"",
      ""manufacturer_id"": ""b2247a2f-33e0-4dda-ba68-fa07ee182cc1"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SE/512/Schneider%2520Electric%255CHARMONY%255CHARMONY%2520SIGNALLING%255CSE_HARMONY_FIXING%2520UNIT%2520WITH%2520SUPPORT_80MM.png.png"",
      ""part_number"": ""SE.XVBZ03"",
      ""eplan_id"": ""850976"",
      ""designation"": ""SCHWARZ ALU. TUBE 400MM PLASTIC BASE"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""XVBZ03"",
      ""order_number"": ""XVBZ03""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c5fd071c-ed5b-4ef0-a1d5-316e6037c3e4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c5fd071c-ed5b-4ef0-a1d5-316e6037c3e4"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_USB%255Cproduct_picture_G_NSA0_XX_92933.jpg.png"",
      ""part_number"": ""SIE.3RT2916-1BB00"",
      ""eplan_id"": ""705893"",
      ""designation"": ""UEBERSPANNUNGSBEGRENZER, VARISTOR, / AC 24...48V, DC 24...70V,  FUER HILFS- UND MOTORSCHUETZE / BGR. S00,"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2916-1BB00"",
      ""order_number"": ""3RT29161BB00""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 72323c42-6025-45f9-9a79-be3d2dabe94f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""72323c42-6025-45f9-9a79-be3d2dabe94f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00822P.png.png"",
      ""part_number"": ""SIE.3RT2015-1AB01"",
      ""eplan_id"": ""451606"",
      ""designation"": ""SCHUETZ,AC3:3KW 1S AC24V 50/60HZ / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2015-1AB01"",
      ""order_number"": ""3RT2015-1AB01""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 06303957-5c51-4674-a18c-6a279210ac1e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""06303957-5c51-4674-a18c-6a279210ac1e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255CP_D211_XX_00052I.jpg.png"",
      ""part_number"": ""SIE.6SL3066-2DA00-0AB0"",
      ""eplan_id"": ""574277"",
      ""designation"": ""SINAMICS KUPPLUNG FUER DRIVE-CLIQ"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3066-2DA00-0AB0"",
      ""order_number"": ""6SL3066-2DA00-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 40ca6638-46ef-4e78-9141-a4ae114d250b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""40ca6638-46ef-4e78-9141-a4ae114d250b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1ZSI%255Cproduct_picture_G_IC03_XX_06810P.png.png"",
      ""part_number"": ""SIE.3SU1900-0BC31-0AT0"",
      ""eplan_id"": ""522524"",
      ""designation"": ""NOT-HALT-UNTERLEGSCHILD, GELB / SIRIUS ACT NOT-HALT-Unterlegschild / NOT-HALT-Unterlegschild"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1900-0BC31-0AT0"",
      ""order_number"": ""3SU1900-0BC31-0AT0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4bf51a89-3d10-4ace-aa6b-6801b46d4038 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4bf51a89-3d10-4ace-aa6b-6801b46d4038"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1ZHA%255Cproduct_picture_G_IC03_XX_06811P.png.png"",
      ""part_number"": ""SIE.3SU1900-0FA10-0AA0"",
      ""eplan_id"": ""522560"",
      ""designation"": ""BLINDVERSCHLUSS, SCHWARZ / SIRIUS ACT Blindverschluss / Blindverschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1900-0FA10-0AA0"",
      ""order_number"": ""3SU1900-0FA10-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 43d8cb73-6761-4d54-9363-3b73a0df49bc (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""43d8cb73-6761-4d54-9363-3b73a0df49bc"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_G_NSA0_XX_93176P.png.png"",
      ""part_number"": ""SIE.3RV2917-4A"",
      ""eplan_id"": ""724975"",
      ""designation"": ""3PHAS-SAMMELSCHIENEN SYSTEMERWEITERUNG / SIRIUS 3-Phasen-Sammelschienen zur Systemerweiterung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2917-4A"",
      ""order_number"": ""3RV2917-4A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 03d25d20-c138-481d-acd6-59ec61039956 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""03d25d20-c138-481d-acd6-59ec61039956"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_G_NSA0_XX_93179P.png.png"",
      ""part_number"": ""SIE.3RV2917-4B"",
      ""eplan_id"": ""724976"",
      ""designation"": ""3PHAS-SAMMELSCHIENEN SYSTEMERWEITERUNG / SIRIUS 3-Phasen-Sammelschienen zur Systemerweiterung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2917-4B"",
      ""order_number"": ""3RV2917-4B""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 204b6d6e-22e1-473d-8906-02469db861a0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""204b6d6e-22e1-473d-8906-02469db861a0"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_G_NSA0_XX_93170P.png.png"",
      ""part_number"": ""SIE.3RV2917-1A"",
      ""eplan_id"": ""724973"",
      ""designation"": ""3PHAS-SAMMELSCHIENE M. EINSPEISUNG / SIRIUS 3-Phasen-Sammelschienen mit Einspeisung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2917-1A"",
      ""order_number"": ""3RV2917-1A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7e91b0fa-6d4f-48e4-9b49-b0a027f70fa3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7e91b0fa-6d4f-48e4-9b49-b0a027f70fa3"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VKL%255Cproduct_picture_G_NSA0_XX_93191P.png.png"",
      ""part_number"": ""SIE.3RV2917-5D"",
      ""eplan_id"": ""724980"",
      ""designation"": ""KLEMMENBLOCK ZUR STROMAUSSPEISUNG"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2917-5D"",
      ""order_number"": ""3RV2917-5D""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d1f09705-026d-4c02-b310-26d6c668d3ed (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d1f09705-026d-4c02-b310-26d6c668d3ed"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00822P.png.png"",
      ""part_number"": ""SIE.3RT2017-1AB01"",
      ""eplan_id"": ""451791"",
      ""designation"": ""SCHUETZ,AC3:5,5KW 1S AC24V 50/60HZ / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2017-1AB01"",
      ""order_number"": ""3RT2017-1AB01""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: abf8ea72-7720-40a8-b05d-b3a22115a777 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""abf8ea72-7720-40a8-b05d-b3a22115a777"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00860P.png.png"",
      ""part_number"": ""SIE.3RT2015-2BB42"",
      ""eplan_id"": ""451668"",
      ""designation"": ""SCHUETZ,AC3:3KW 1OE DC24V / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2015-2BB42"",
      ""order_number"": ""3RT2015-2BB42""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b79564bb-01e7-4457-8436-206c404f5ce0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b79564bb-01e7-4457-8436-206c404f5ce0"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RH2%255Cproduct_picture_G_NSA0_XX_01147P.png.png"",
      ""part_number"": ""SIE.3RH2244-2BB40"",
      ""eplan_id"": ""703915"",
      ""designation"": ""HILFSSCHUETZ,4S+4OE,DC24V / SIRIUS Hilfsschütz / FUER SUVA APPLIKATIONEN"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RH2244-2BB40"",
      ""order_number"": ""3RH2244-2BB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a905402c-04e8-474b-a2bb-2159bded211a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a905402c-04e8-474b-a2bb-2159bded211a"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY5110-7"",
      ""eplan_id"": ""455828"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY5110-7"",
      ""order_number"": ""5SY5110-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b2e44ec8-d4da-4fe8-8cc3-04ed3c45955c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b2e44ec8-d4da-4fe8-8cc3-04ed3c45955c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4116-7"",
      ""eplan_id"": ""455345"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4116-7"",
      ""order_number"": ""5SY4116-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 46596187-917d-4816-b775-2d3ca34cf7bd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""46596187-917d-4816-b775-2d3ca34cf7bd"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technologie%255Cproduct_picture_P_KT01_XX_01344I.jpg.png"",
      ""part_number"": ""SIE.6EP1961-2BA41"",
      ""eplan_id"": ""459203"",
      ""designation"": ""SITOP PSE200U / SELEKTIVITAETSMODUL 10A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP1961-2BA41"",
      ""order_number"": ""6EP19612BA41""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 33fb28e8-48c1-47b1-a6e8-91deba544efb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""33fb28e8-48c1-47b1-a6e8-91deba544efb"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1GLE%255Cproduct_picture_G_IC03_XX_08392I.jpg.png"",
      ""part_number"": ""SIE.3SU1806-0AA00-0AB1"",
      ""eplan_id"": ""559886"",
      ""designation"": ""GEHAEUSE KUNSTSTOFF, 6 BEFEHLSSTELLEN / SIRIUS ACT Befehls- und Meldegeräte / Gehäuse für Aufbau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1806-0AA00-0AB1"",
      ""order_number"": ""3SU1806-0AA00-0AB1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: eef27795-8828-45f9-bd30-36c515fc856d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""eef27795-8828-45f9-bd30-36c515fc856d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4313-7"",
      ""eplan_id"": ""455531"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4313-7"",
      ""order_number"": ""5SY4313-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a3772126-2749-4ed3-990f-cf26fc6199cb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a3772126-2749-4ed3-990f-cf26fc6199cb"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04717P.png.png"",
      ""part_number"": ""SIE.5SY4206-7"",
      ""eplan_id"": ""455415"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4206-7"",
      ""order_number"": ""5SY4206-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 89cfe941-a936-4ea9-9798-dcb7482e8d25 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""89cfe941-a936-4ea9-9798-dcb7482e8d25"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4325-7"",
      ""eplan_id"": ""455557"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4325-7"",
      ""order_number"": ""5SY4325-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 02d341fe-5dde-478f-846e-cbe50c216272 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""02d341fe-5dde-478f-846e-cbe50c216272"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4110-7"",
      ""eplan_id"": ""455325"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4110-7"",
      ""order_number"": ""5SY4110-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e156934e-2379-43ec-bd36-6aa1aed13cf0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e156934e-2379-43ec-bd36-6aa1aed13cf0"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SL%255Cproduct_picture_G_I202_XX_26133P.png.png"",
      ""part_number"": ""SIE.5SL4302-6"",
      ""eplan_id"": ""957537"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SL4302-6"",
      ""order_number"": ""5SL4302-6""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2382d2a8-376e-4d83-90d3-ed291dfe5009 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2382d2a8-376e-4d83-90d3-ed291dfe5009"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4316-7"",
      ""eplan_id"": ""455544"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4316-7"",
      ""order_number"": ""5SY4316-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9683ce8d-e388-40fa-bcf6-2de2219949cf (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9683ce8d-e388-40fa-bcf6-2de2219949cf"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_92870P.png.png"",
      ""part_number"": ""SIE.3RT2028-1FB40"",
      ""eplan_id"": ""705626"",
      ""designation"": ""SCHUETZ,AC3:18,5KW 1S+1OE DC24V M.DIODE / SIRIUS Leistungsschütz / SCHRAUBANSCHLUSS"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2028-1FB40"",
      ""order_number"": ""3RT2028-1FB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 01ac457b-8d8b-4b12-ab38-743ad76a5b36 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""01ac457b-8d8b-4b12-ab38-743ad76a5b36"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93053P.png.png"",
      ""part_number"": ""SIE.3RV2011-1JA15"",
      ""eplan_id"": ""452822"",
      ""designation"": ""LEISTUNGSSCHALTER SCHRAUBANSCHL. 10A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1JA15"",
      ""order_number"": ""3RV2011-1JA15""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 58ad99e7-3ac4-4ac2-afd9-ab0cf603c706 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""58ad99e7-3ac4-4ac2-afd9-ab0cf603c706"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93056P.png.png"",
      ""part_number"": ""SIE.3RV2411-1AA20"",
      ""eplan_id"": ""452992"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 1,6A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2411-1AA20"",
      ""order_number"": ""3RV2411-1AA20""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 03c7758a-04cf-462e-af82-88468b7c3fe9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""03c7758a-04cf-462e-af82-88468b7c3fe9"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93059P.png.png"",
      ""part_number"": ""SIE.3RV2011-1BA25"",
      ""eplan_id"": ""452777"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 2A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1BA25"",
      ""order_number"": ""3RV2011-1BA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 80500c0b-3338-4af2-b520-0cfaf9a2d11b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""80500c0b-3338-4af2-b520-0cfaf9a2d11b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93059P.png.png"",
      ""part_number"": ""SIE.3RV2011-1GA25"",
      ""eplan_id"": ""452812"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 6,3A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1GA25"",
      ""order_number"": ""3RV2011-1GA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fccbc9ad-2f65-479f-bcb0-34cfe4f8f88f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fccbc9ad-2f65-479f-bcb0-34cfe4f8f88f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93059P.png.png"",
      ""part_number"": ""SIE.3RV2011-1JA25"",
      ""eplan_id"": ""452825"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 10A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1JA25"",
      ""order_number"": ""3RV2011-1JA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e88defb8-01ee-4496-976d-4cec844b7322 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e88defb8-01ee-4496-976d-4cec844b7322"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VKL%255Cproduct_picture_G_NSA0_XX_93215P.png.png"",
      ""part_number"": ""SIE.3RV2925-5AB"",
      ""eplan_id"": ""724983"",
      ""designation"": ""3-PHASEN-EINSPEISEKLEMME BGR.S0/S00"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2925-5AB"",
      ""order_number"": ""3RV2925-5AB""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: eaa17e65-bc32-4d74-bd32-c503a82803e7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""eaa17e65-bc32-4d74-bd32-c503a82803e7"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VKL%255Cproduct_picture_G_NSA0_XX_93245P.png.png"",
      ""part_number"": ""SIE.3RV2928-1H"",
      ""eplan_id"": ""724996"",
      ""designation"": ""KLEMMENBLOCK TYPE E BAUGR. S00/S0"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2928-1H"",
      ""order_number"": ""3RV2928-1H""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 044be7e1-52d2-442e-83c1-00812a813769 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""044be7e1-52d2-442e-83c1-00812a813769"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93059P.png.png"",
      ""part_number"": ""SIE.3RV2011-1HA25"",
      ""eplan_id"": ""452818"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 8A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1HA25"",
      ""order_number"": ""3RV2011-1HA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 92454bb3-ab85-4dca-b2b2-dd8fa0a4325d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""92454bb3-ab85-4dca-b2b2-dd8fa0a4325d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93059P.png.png"",
      ""part_number"": ""SIE.3RV2011-1DA25"",
      ""eplan_id"": ""452791"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 3,2A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1DA25"",
      ""order_number"": ""3RV2011-1DA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 92bb67d7-96ae-496e-ba5b-103b8cb16b79 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""92bb67d7-96ae-496e-ba5b-103b8cb16b79"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93074P.png.png"",
      ""part_number"": ""SIE.3RV2021-4EA25"",
      ""eplan_id"": ""452866"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 32A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2021-4EA25"",
      ""order_number"": ""3RV2021-4EA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d401416b-7c1c-422a-a192-ced7dbc91c5b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d401416b-7c1c-422a-a192-ced7dbc91c5b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_G_IC03_XX_06268P.png.png"",
      ""part_number"": ""SIE.3RV1915-1BB"",
      ""eplan_id"": ""724949"",
      ""designation"": ""3PHAS-SAMMELSCHIENEN BGR.S0/S00"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV1915-1BB"",
      ""order_number"": ""3RV1915-1BB""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7b2739ae-1faa-43fe-9686-befb26c8e1ed (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7b2739ae-1faa-43fe-9686-befb26c8e1ed"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_G_IC03_XX_06306P.png.png"",
      ""part_number"": ""SIE.3RV1915-1DB"",
      ""eplan_id"": ""724951"",
      ""designation"": ""3PHAS-SAMMELSCHIENEN BGR.S0/S00"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV1915-1DB"",
      ""order_number"": ""3RV1915-1DB""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cbf6643b-f3e6-4e00-837e-f0a01c0cffe3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cbf6643b-f3e6-4e00-837e-f0a01c0cffe3"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3NA%255CP_I201_XX_04202I300300.jpg.png"",
      ""part_number"": ""SIE.3NA3820"",
      ""eplan_id"": ""450280"",
      ""designation"": ""NH-SICHERUNGSEINSATZ GL/GG +SPANNUNGSFUEHREND.GRIFFLASCHEN / MIT STIRNKENNMELDER GR.000, 50A, AC 500V/DC 250V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3NA3820"",
      ""order_number"": ""3NA3820""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 51eca69e-780c-4a71-880b-0e61d39d7b45 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""51eca69e-780c-4a71-880b-0e61d39d7b45"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3NA%255CP_I201_XX_01854I300300.jpg.png"",
      ""part_number"": ""SIE.3NA3836"",
      ""eplan_id"": ""450294"",
      ""designation"": ""NH-SICHERUNGSEINSATZ GL/GG +SPANNUNGSFUEHREND.GRIFFLASCHEN / MIT STIRNKENNMELDER GR.00, 160A, AC 500V/DC 250V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3NA3836"",
      ""order_number"": ""3NA3836""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4ae00443-dec2-49be-b2d5-1bbecdf19f9f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4ae00443-dec2-49be-b2d5-1bbecdf19f9f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3NA%255CP_I201_XX_04202I300300.jpg.png"",
      ""part_number"": ""SIE.3NA3814"",
      ""eplan_id"": ""450275"",
      ""designation"": ""NH-SICHERUNGSEINSATZ GL/GG +SPANNUNGSFUEHREND.GRIFFLASCHEN / MIT STIRNKENNMELDER GR.000, 35A, AC 500V/DC 250V"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3NA3814"",
      ""order_number"": ""3NA3814""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3ad5a200-eb91-4bc7-b9d1-5e1156849283 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3ad5a200-eb91-4bc7-b9d1-5e1156849283"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001474%255Cproduct_picture_P_NSG0_XX_00311P.png.png"",
      ""part_number"": ""SIE.3NP1923-1BE20"",
      ""eplan_id"": ""1093789"",
      ""designation"": ""Dreifachklemme 3x 2,5 - 16mm2 / SENTRON Dreifachklemme 3x 2,5 - 16mm² Zubehör für Sicherungs-Lasttrennschalter 3NP1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3NP1923-1BE20"",
      ""order_number"": ""3NP1923-1BE20""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b13eac09-2138-4e0e-8d04-be5e22f06052 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b13eac09-2138-4e0e-8d04-be5e22f06052"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C780%255C780-317.jpg.png"",
      ""part_number"": ""WAGO.780-317"",
      ""eplan_id"": ""502796"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, orange"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""780-317"",
      ""order_number"": ""780-317""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a7a60a59-0f02-41ae-ba71-37befd97395e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a7a60a59-0f02-41ae-ba71-37befd97395e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00852P.png.png"",
      ""part_number"": ""SIE.3RT2017-2JB41"",
      ""eplan_id"": ""705115"",
      ""designation"": ""KOPPELSCHUETZ,AC3:5,5KW 1S DC24V,M.DIODE / SIRIUS Koppelschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2017-2JB41"",
      ""order_number"": ""3RT2017-2JB41""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b6a3d425-fcdf-493f-bb09-4d241f09fce7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b6a3d425-fcdf-493f-bb09-4d241f09fce7"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00860P.png.png"",
      ""part_number"": ""SIE.3RT2016-2BB42"",
      ""eplan_id"": ""451761"",
      ""designation"": ""SCHUETZ,AC3:4KW 1OE DC24V / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2016-2BB42"",
      ""order_number"": ""3RT2016-2BB42""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ccd95990-a800-40cf-a4ea-3b9092b2e502 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ccd95990-a800-40cf-a4ea-3b9092b2e502"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00976P.png.png"",
      ""part_number"": ""SIE.3RT2017-2BB44-3MA0"",
      ""eplan_id"": ""451856"",
      ""designation"": ""SCHUETZ,AC3:5,5KW 2S+2OE DC24V / SIRIUS Leistungsschütz / HILFSSCHALTER UNLOESBAR FUER SUVA APPLIKATIONEN"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2017-2BB44-3MA0"",
      ""order_number"": ""3RT2017-2BB44-3MA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 453799d8-9f89-489d-9edf-58acbd930426 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""453799d8-9f89-489d-9edf-58acbd930426"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00972P.png.png"",
      ""part_number"": ""SIE.3RT2016-1BB44-3MA0"",
      ""eplan_id"": ""451726"",
      ""designation"": ""SCHUETZ,AC3:4KW 2S+2OE DC24V / SIRIUS Leistungsschütz / HILFSSCHALTER UNLOESBAR FUER SUVA APPLIKATIONEN"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2016-1BB44-3MA0"",
      ""order_number"": ""3RT2016-1BB44-3MA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 869a947d-e2a6-46f3-b8b0-d8bf734409e9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""869a947d-e2a6-46f3-b8b0-d8bf734409e9"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RH2%255Cproduct_picture_G_IC03_XX_18856P.png.png"",
      ""part_number"": ""SIE.3RH2271-2BB40"",
      ""eplan_id"": ""703929"",
      ""designation"": ""HILFSSCHUETZ,7S+1OE,DC24V / SIRIUS Hilfsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RH2271-2BB40"",
      ""order_number"": ""3RH2271-2BB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 004b6050-5484-4b59-aec8-90e8a32b834e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""004b6050-5484-4b59-aec8-90e8a32b834e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00976P.png.png"",
      ""part_number"": ""SIE.3RT2015-2BB44-3MA0"",
      ""eplan_id"": ""451671"",
      ""designation"": ""SCHUETZ,AC3:3KW 2S+2OE DC24V / SIRIUS Leistungsschütz / HILFSSCHALTER UNLOESBAR FUER SUVA APPLIKATIONEN"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2015-2BB44-3MA0"",
      ""order_number"": ""3RT2015-2BB44-3MA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c5ab5e05-9cd6-4910-91e2-8c231b0a9a42 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c5ab5e05-9cd6-4910-91e2-8c231b0a9a42"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BSS%255Cproduct_picture_G_IC03_XX_07233P.png.png"",
      ""part_number"": ""SIE.3SU1050-5BF01-0AA0"",
      ""eplan_id"": ""464022"",
      ""designation"": ""SCHLUESSELSCHALTER CES, O-I / SIRIUS ACT Schlüsselschalter / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1050-5BF01-0AA0"",
      ""order_number"": ""3SU1050-5BF01-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8a33d221-a2f0-48d2-90c5-54f274e294f6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8a33d221-a2f0-48d2-90c5-54f274e294f6"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1KD%255Cproduct_picture_G_IC03_XX_07573P.png.png"",
      ""part_number"": ""SIE.3SU1130-0AB10-3BA0"",
      ""eplan_id"": ""706393"",
      ""designation"": ""DRUCKTASTER, SCHWARZ / SIRIUS ACT Drucktaster / Komplettgerät"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1130-0AB10-3BA0"",
      ""order_number"": ""3SU1130-0AB10-3BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 372508da-53f6-46f9-9776-d062749aac0e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""372508da-53f6-46f9-9776-d062749aac0e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MLE%255Cproduct_picture_G_IC03_XX_07615P.png.png"",
      ""part_number"": ""SIE.3SU1401-2BB60-3AA0"",
      ""eplan_id"": ""522068"",
      ""designation"": ""LED-MODUL, WEISS / SIRIUS ACT LED-Modul / LED-Modul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-2BB60-3AA0"",
      ""order_number"": ""3SU1401-2BB60-3AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: bfb75da5-8ba1-4d15-b30a-80f9b80cda6b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""bfb75da5-8ba1-4d15-b30a-80f9b80cda6b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MLE%255Cproduct_picture_G_IC03_XX_07615P.png.png"",
      ""part_number"": ""SIE.3SU1401-2BB20-3AA0"",
      ""eplan_id"": ""522060"",
      ""designation"": ""LED-MODUL, ROT / SIRIUS ACT LED-Modul / LED-Modul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-2BB20-3AA0"",
      ""order_number"": ""3SU1401-2BB20-3AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a9067c68-d7b5-4216-9780-471cac9ad749 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a9067c68-d7b5-4216-9780-471cac9ad749"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MLE%255Cproduct_picture_G_IC03_XX_07615P.png.png"",
      ""part_number"": ""SIE.3SU1401-2BB40-3AA0"",
      ""eplan_id"": ""522064"",
      ""designation"": ""LED-MODUL, GRUEN / SIRIUS ACT LED-Modul / LED-Modul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-2BB40-3AA0"",
      ""order_number"": ""3SU1401-2BB40-3AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5f0609af-afb8-4a52-93fa-bbfba26793b5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5f0609af-afb8-4a52-93fa-bbfba26793b5"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BD%255Cproduct_picture_G_IC03_XX_07896P.png.png"",
      ""part_number"": ""SIE.3SU1000-0AB10-0AA0"",
      ""eplan_id"": ""462696"",
      ""designation"": ""DRUCKTASTER, SCHWARZ / SIRIUS ACT Drucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1000-0AB10-0AA0"",
      ""order_number"": ""3SU1000-0AB10-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ea74e8b9-8eaa-4079-81f4-8e00e7898145 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ea74e8b9-8eaa-4079-81f4-8e00e7898145"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_07384P.png.png"",
      ""part_number"": ""SIE.3SU1400-2AA10-3CA0"",
      ""eplan_id"": ""521989"",
      ""designation"": ""KONTAKTMODUL 1OE / SIRIUS ACT Kontaktmodul / Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-2AA10-3CA0"",
      ""order_number"": ""3SU1400-2AA10-3CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d1d62819-2b5f-48b5-9db4-f37b7513ab87 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d1d62819-2b5f-48b5-9db4-f37b7513ab87"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_06768P.png.png"",
      ""part_number"": ""SIE.3SU1400-2AA10-3BA0"",
      ""eplan_id"": ""521987"",
      ""designation"": ""KONTAKTMODUL 1S / SIRIUS ACT Kontaktmodul / Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-2AA10-3BA0"",
      ""order_number"": ""3SU1400-2AA10-3BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1d9a2e3c-e936-4d12-aa0f-d5ce3803e8d1 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1d9a2e3c-e936-4d12-aa0f-d5ce3803e8d1"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05987P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP20-0BA0"",
      ""eplan_id"": ""458593"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ A0 BU15-P16+A10+2B / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP20-0BA0"",
      ""order_number"": ""6ES7193-6BP20-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5b6516e7-bf12-430d-83b3-52d83b632c29 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5b6516e7-bf12-430d-83b3-52d83b632c29"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07504P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP20-0DA0"",
      ""eplan_id"": ""458594"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ A0 BU15-P16+A10+2D / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP20-0DA0"",
      ""order_number"": ""6ES7193-6BP20-0DA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2199767b-22bd-4127-ace5-2e9aaecf08b4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2199767b-22bd-4127-ace5-2e9aaecf08b4"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_G_ST70_XX_00877P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP04-2MA0"",
      ""eplan_id"": ""707432"",
      ""designation"": ""10 FARBKENNZEICHNUNGSSCHILDER CC04 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP04-2MA0"",
      ""order_number"": ""6ES7193-6CP04-2MA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 66250d89-ef90-44ea-811c-ccd9745aaad5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""66250d89-ef90-44ea-811c-ccd9745aaad5"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255CG_ST70_XX_02288P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP11-2MT0"",
      ""eplan_id"": ""963799"",
      ""designation"": ""10 Farbkennzeichnungsschilder CC11 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP11-2MT0"",
      ""order_number"": ""6ES7193-6CP11-2MT0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1f043ec7-ff28-45d8-af4a-d5e463e4136b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1f043ec7-ff28-45d8-af4a-d5e463e4136b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255CP_ST70_XX_07880P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP12-2MT0"",
      ""eplan_id"": ""963800"",
      ""designation"": ""10 Farbkennzeichnungsschilder CC12 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP12-2MT0"",
      ""order_number"": ""6ES7193-6CP12-2MT0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1a8f3e1f-15ed-4308-a356-64bde755844d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1a8f3e1f-15ed-4308-a356-64bde755844d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255CP_ST70_XX_07881P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP13-2MT0"",
      ""eplan_id"": ""963801"",
      ""designation"": ""10 Farbkennzeichnungsschilder CC13 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP13-2MT0"",
      ""order_number"": ""6ES7193-6CP13-2MT0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7958778c-b78b-45a6-9005-605a967b5cca (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7958778c-b78b-45a6-9005-605a967b5cca"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_06461P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP01-2MA0"",
      ""eplan_id"": ""458597"",
      ""designation"": ""10 FARBKENNZEICHNUNGSSCHILDER CC01 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP01-2MA0"",
      ""order_number"": ""6ES7193-6CP01-2MA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 637fca96-7c56-40a4-9faf-828b57996fda (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""637fca96-7c56-40a4-9faf-828b57996fda"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C781%255C781-607.jpg.png"",
      ""part_number"": ""WAGO.781-607"",
      ""eplan_id"": ""502826"",
      ""designation"": ""Schutzleiter-Reihenklemme / 2-Leiter-Schutzleiterklemme, 4 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""781-607"",
      ""order_number"": ""781-607""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cbd64f30-4146-436b-adb3-4d8be0c46461 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cbd64f30-4146-436b-adb3-4d8be0c46461"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_06462P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP02-2MA0"",
      ""eplan_id"": ""458598"",
      ""designation"": ""10 FARBKENNZEICHNUNGSSCHILDER CC02 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP02-2MA0"",
      ""order_number"": ""6ES7193-6CP02-2MA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 86940293-2da7-4f2f-9249-ec2fab64ae02 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""86940293-2da7-4f2f-9249-ec2fab64ae02"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_06464P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP71-2AA0"",
      ""eplan_id"": ""458600"",
      ""designation"": ""10 FARBKENNZEICHNUNGSSCHILDER CC71 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP71-2AA0"",
      ""order_number"": ""6ES7193-6CP71-2AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 47f65d43-9991-4587-a1cf-a364f4f0af88 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""47f65d43-9991-4587-a1cf-a364f4f0af88"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_06466P.png.png"",
      ""part_number"": ""SIE.6ES7193-6CP73-2AA0"",
      ""eplan_id"": ""458602"",
      ""designation"": ""10 FARBKENNZEICHNUNGSSCHILDER CC73 / SIMATIC DP, ET 200SP"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6CP73-2AA0"",
      ""order_number"": ""6ES7193-6CP73-2AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 48778244-f2bb-4cf6-93cb-e858df7ba842 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""48778244-f2bb-4cf6-93cb-e858df7ba842"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05959P.png.png"",
      ""part_number"": ""SIE.6ES7132-6BD20-0BA0"",
      ""eplan_id"": ""457433"",
      ""designation"": ""SIMATIC ET 200SP DQ 4x24 VDC/2 A ST / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7132-6BD20-0BA0"",
      ""order_number"": ""6ES7132-6BD20-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 51e40e63-7fe5-4200-801a-40ed1d5fb816 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""51e40e63-7fe5-4200-801a-40ed1d5fb816"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07162P.png.png"",
      ""part_number"": ""SIE.6ES7136-6BA00-0CA0"",
      ""eplan_id"": ""707288"",
      ""designation"": ""SIMATIC ET 200SP F-DI 8x24VDC HF / Digitalmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7136-6BA00-0CA0"",
      ""order_number"": ""6ES7136-6BA00-0CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 47083d64-20dd-49f7-a81f-ed7af34f903a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""47083d64-20dd-49f7-a81f-ed7af34f903a"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05863P.png.png"",
      ""part_number"": ""SIE.6ES7131-6BH01-0BA0"",
      ""eplan_id"": ""994279"",
      ""designation"": ""SIMATIC ET 200SP DI 16x 24V DC ST, VPE 1 / Digitalmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7131-6BH01-0BA0"",
      ""order_number"": ""6ES7131-6BH01-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 12322394-cff1-4b14-9f77-5b4ee1ce6201 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""12322394-cff1-4b14-9f77-5b4ee1ce6201"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_G_ST70_XX_02089P.png.png"",
      ""part_number"": ""SIE.6ES7132-6HD01-0BB1"",
      ""eplan_id"": ""936594"",
      ""designation"": ""SIMATIC ET 200SP RQ 4x120 VDC ... 230 VAC/5 A NO ST / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7132-6HD01-0BB1"",
      ""order_number"": ""6ES7132-6HD01-0BB1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 753f8700-bd5f-43d4-a566-cc51b78dca0e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""753f8700-bd5f-43d4-a566-cc51b78dca0e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07593P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP20-0BB0"",
      ""eplan_id"": ""707427"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ B0 BU20-P12+A4+0B VPE 1 / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP20-0BB0"",
      ""order_number"": ""6ES7193-6BP20-0BB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6ecc7db2-5dad-449f-be8e-5eddf60060fd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6ecc7db2-5dad-449f-be8e-5eddf60060fd"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05972P.png.png"",
      ""part_number"": ""SIE.6ES7135-6HD00-0BA1"",
      ""eplan_id"": ""457974"",
      ""designation"": ""SIMATIC ET 200SP AQ 4xU/I ST / Analogmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7135-6HD00-0BA1"",
      ""order_number"": ""6ES7135-6HD00-0BA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c60687b6-c7f7-4731-87f1-f615072b4c56 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c60687b6-c7f7-4731-87f1-f615072b4c56"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05974P.png.png"",
      ""part_number"": ""SIE.6ES7134-6HD01-0BA1"",
      ""eplan_id"": ""994292"",
      ""designation"": ""SIMATIC ET 200SP AI 4x U/I 2-wire / Analogmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7134-6HD01-0BA1"",
      ""order_number"": ""6ES7134-6HD01-0BA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 441f19a3-5b26-45d6-939a-aa0879d8fd94 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""441f19a3-5b26-45d6-939a-aa0879d8fd94"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05858P.png.png"",
      ""part_number"": ""SIE.6ES7193-6AF00-0AA0"",
      ""eplan_id"": ""707417"",
      ""designation"": ""SIMATIC ET 200SP, BUSADAPTER BA 2XFC, 2X FAST CONNECT ANSCHLUSS FUER PROFINET"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6AF00-0AA0"",
      ""order_number"": ""6ES7193-6AF00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ec778af8-727b-4057-a12a-20cfe0716f52 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ec778af8-727b-4057-a12a-20cfe0716f52"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200%255Cproduct_picture_P_ST70_XX_05241P.png.png"",
      ""part_number"": ""SIE.6ES7972-0BB52-0XA0"",
      ""eplan_id"": ""936620"",
      ""designation"": ""PB-ANSCHL.-STECK., 90GRAD, MIT PG-BUCHSE / SIMATIC DP, ET 200 / PROFIBUS-Stecker"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7972-0BB52-0XA0"",
      ""order_number"": ""6ES7972-0BB52-0XA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 851de642-e434-4e71-a862-30d8f0d84233 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""851de642-e434-4e71-a862-30d8f0d84233"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200%255Cproduct_picture_P_ST70_XX_05237P.png.png"",
      ""part_number"": ""SIE.6ES7972-0BA52-0XA0"",
      ""eplan_id"": ""936615"",
      ""designation"": ""PB-ANSCHL.-STECK., 90GRAD,OHNE PG-BUCHSE / SIMATIC DP, ET 200 / PROFIBUS-Stecker"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7972-0BA52-0XA0"",
      ""order_number"": ""6ES7972-0BA52-0XA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 371c37e4-9bce-4524-b4be-e0afdb6e8337 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""371c37e4-9bce-4524-b4be-e0afdb6e8337"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200%255Cproduct_picture_P_ST70_XX_05240P.png.png"",
      ""part_number"": ""SIE.6ES7972-0BB42-0XA0"",
      ""eplan_id"": ""936619"",
      ""designation"": ""ANSCHL.-STECK. F. PROFIBUS, M. PG-BUCHSE / SIMATIC DP, ET 200 / PROFIBUS-Stecker"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7972-0BB42-0XA0"",
      ""order_number"": ""6ES7972-0BB42-0XA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 710572df-de8b-4282-9c81-24b338245f12 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""710572df-de8b-4282-9c81-24b338245f12"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Communication%255CSCALANCE_XB000%255C6GK5005-0BA00-1AB2.jpg.png"",
      ""part_number"": ""SIE.6GK5005-0BA00-1AB2"",
      ""eplan_id"": ""707687"",
      ""designation"": ""SCALANCE XB005 / SCALANCE XB-000 unmanaged"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6GK5005-0BA00-1AB2"",
      ""order_number"": ""6GK5005-0BA00-1AB2""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d943f09c-876b-4daa-a074-eda95a28ebc3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d943f09c-876b-4daa-a074-eda95a28ebc3"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CPUSH_BUTTON_PANEL%255CHMIproduct_picture_P_ST70_XX_05416P.png.png"",
      ""part_number"": ""SIE.6AV3688-3AY36-0AX0"",
      ""eplan_id"": ""456752"",
      ""designation"": ""SIMATIC HMI KP8 PN Key Panel, 8 Kurzhubtasten mit mehrfarbigen LED'S, PROFINET Schnittstellen 8 konfigurierbare DE/DA Pins, DC 24V durchschleifbar parametrierbar ab STEP 7 V5.5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV3688-3AY36-0AX0"",
      ""order_number"": ""6AV3688-3AY36-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 63bf0e3a-30cc-4b33-8b85-e0101b9318f5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""63bf0e3a-30cc-4b33-8b85-e0101b9318f5"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CMobile_Panel%255Cproduct_picture_P_ST80_XX_02495P.png.png"",
      ""part_number"": ""SIE.6AV2125-2AE03-0AX0"",
      ""eplan_id"": ""840814"",
      ""designation"": ""SIMATIC HMI ANSCHLUSS-BOX KOMPAKT"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2125-2AE03-0AX0"",
      ""order_number"": ""6AV2125-2AE03-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 86e369fc-49b0-4c46-8f77-3fd9fbff45b8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""86e369fc-49b0-4c46-8f77-3fd9fbff45b8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_05980P.png.png"",
      ""part_number"": ""SIE.6ES7193-6PA00-0AA0"",
      ""eplan_id"": ""707439"",
      ""designation"": ""ET200SP, SERVERMODUL"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6PA00-0AA0"",
      ""order_number"": ""6ES7193-6PA00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7bb18d2d-d51a-486f-8aa9-655a7d565a19 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7bb18d2d-d51a-486f-8aa9-655a7d565a19"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CDP%255CP_ST70_XX_04962P.png.png"",
      ""part_number"": ""SIE.6ES7158-0AD01-0XA0"",
      ""eplan_id"": ""458540"",
      ""designation"": ""SIMATIC DP, DP/DP-Koppler Koppelmodul zum Verbinden von zwei PROFIBUS-DP Netzen redundante Stromeinspeisung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7158-0AD01-0XA0"",
      ""order_number"": ""6ES7158-0AD01-0XA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a634dee3-fd90-43f7-9325-1cf499f6da6b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a634dee3-fd90-43f7-9325-1cf499f6da6b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C7KM_MFM%255Cproduct_picture_P_NSE0_XX_01251P.png.png"",
      ""part_number"": ""SIE.7KM2112-0BA00-3AA0"",
      ""eplan_id"": ""461805"",
      ""designation"": ""7KM PAC3200 / SENTRON 7KM PAC3200, Basic"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7KM2112-0BA00-3AA0"",
      ""order_number"": ""7KM2112-0BA00-3AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 236d447c-25dc-4324-99fc-4245640b9eaa (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""236d447c-25dc-4324-99fc-4245640b9eaa"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CS7-300%255Cproduct_picture_P_ST70_XX_00026P.png.png"",
      ""part_number"": ""SIE.6ES7331-7KF02-0AB0"",
      ""eplan_id"": ""458883"",
      ""designation"": ""SM331, 8AE, 9/12/14BIT / SIMATIC, S7-300 / Analogmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7331-7KF02-0AB0"",
      ""order_number"": ""6ES7331-7KF02-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 863c9e53-54e3-4c27-8c46-f1f7cfffb357 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""863c9e53-54e3-4c27-8c46-f1f7cfffb357"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technology%255CPOWER%2520SUPPLIES%255C6EP33338SB000AY0.jpg.png"",
      ""part_number"": ""SIE.6EP3333-8SB00-0AY0"",
      ""eplan_id"": ""707073"",
      ""designation"": ""SITOP PSU8200 24 V/5 A\nGEREGELTE STROMVERSORGUNG\nEINGANG: AC 120/230 V\nAUSGANG: DC 24 V/5 A\n*EX-ZULASSUNG NICHT MEHR VERFUGVBAR*"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP3333-8SB00-0AY0"",
      ""order_number"": ""6EP3333-8SB00-0AY0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6720ec95-5cc2-42e5-aa08-4dadcdebf58c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6720ec95-5cc2-42e5-aa08-4dadcdebf58c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CS7-1500%255Cproduct_picture_P_ST70_XX_08551P.png.png"",
      ""part_number"": ""SIE.6ES7515-2FM02-0AB0"",
      ""eplan_id"": ""1094049"",
      ""designation"": ""SIMATIC S7-1500F, CPU 1515F-2 PN, Zentralbaugruppe mit Arbeitsspeicher 750 KB für Programm und 3MByte für Daten, 1. Schnittstelle: PROFINET IRT mit 2 Port Switch, 2. Schnittstelle: PROFINET RT, 30 ns Bit-Performance, SIMATIC Memory Card notwendig"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7515-2FM02-0AB0"",
      ""order_number"": ""6ES7515-2FM02-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8bf0cb96-064e-4ebb-8234-e504ea67312d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8bf0cb96-064e-4ebb-8234-e504ea67312d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200S%255Cproduct_picture_P_ST70_XX_00495P.png.png"",
      ""part_number"": ""SIE.6ES7131-4BF00-0AA0"",
      ""eplan_id"": ""456993"",
      ""designation"": ""ET200S, ELEKTRONIKMODUL, 8DI DC 24V / SIMATIC DP, ET 200S / Digitalmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7131-4BF00-0AA0"",
      ""order_number"": ""6ES7131-4BF00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 04d23388-a9cb-4a9b-98a4-8f2d4f10bade (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""04d23388-a9cb-4a9b-98a4-8f2d4f10bade"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200S%255Cproduct_picture_P_ST70_XX_00492P.png.png"",
      ""part_number"": ""SIE.6ES7134-4GB01-0AB0"",
      ""eplan_id"": ""457589"",
      ""designation"": ""ET200S, EL-MOD., 2AI STD I-2DMU, 0-20MA, / SIMATIC DP, ET 200S / Analogmodul Eingang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7134-4GB01-0AB0"",
      ""order_number"": ""6ES7134-4GB01-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 66aed3c2-4010-4817-a93d-1e7d6bb24d1d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""66aed3c2-4010-4817-a93d-1e7d6bb24d1d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200pro%255Cproduct_picture_P_ST70_XX_02822P.png.png"",
      ""part_number"": ""SIE.6ES7142-4BF00-0AA0"",
      ""eplan_id"": ""458375"",
      ""designation"": ""ET 200pro, EM 8DO DC24V/0.5A / SIMATIC, ET 200pro / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7142-4BF00-0AA0"",
      ""order_number"": ""6ES7142-4BF00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0a53172b-e8d1-417c-afb0-59727466ac6d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0a53172b-e8d1-417c-afb0-59727466ac6d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200pro%255Cproduct_picture_P_ST70_XX_03977P.png.png"",
      ""part_number"": ""SIE.6ES7194-4CA00-0AA0"",
      ""eplan_id"": ""458634"",
      ""designation"": ""ET 200pro, CM IO 4 x M12 / SIMATIC, ET 200pro / Anschlussmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7194-4CA00-0AA0"",
      ""order_number"": ""6ES7194-4CA00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: dafe6d5b-8bb0-4db5-a72c-8d0ca95189c1 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""dafe6d5b-8bb0-4db5-a72c-8d0ca95189c1"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07902P.png.png"",
      ""part_number"": ""SIE.6ES7155-6AA01-0BN0"",
      ""eplan_id"": ""936596"",
      ""designation"": ""SIMATIC ET 200SP, Bundle PROFINET IM, IM 155-6PN ST, max. 32 Peripheriemodule und 16 ET 200AL Module, Single Hot SWAP, Bundle besteht aus: Interface-Modul (6ES7155-6AU01-0BN0), Server-Modul (6ES7193-6PA00-0AA0), Busadapter BA 2xRJ45 (6ES7193-6AR00-0AA0)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7155-6AA01-0BN0"",
      ""order_number"": ""6ES7155-6AA01-0BN0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 669886ff-ec66-4a78-b8d7-838ab0de6d5c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""669886ff-ec66-4a78-b8d7-838ab0de6d5c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CHMI%255Cproduct_picture_P_ST80_XX_02786P.png.png"",
      ""part_number"": ""SIE.6AV2181-5AF05-0AX0"",
      ""eplan_id"": ""1094011"",
      ""designation"": ""Anschlusskabel 5 M KTP Mobile / SIMATIC, HMI / Anschlusskabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2181-5AF05-0AX0"",
      ""order_number"": ""6AV2181-5AF05-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2a56494a-00c4-4682-b3c9-2b20a4bffc51 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2a56494a-00c4-4682-b3c9-2b20a4bffc51"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VKL%255Cproduct_picture_G_NSA0_XX_93185P.png.png"",
      ""part_number"": ""SIE.3RV2917-5BA00"",
      ""eplan_id"": ""724978"",
      ""designation"": ""ERWEITERUNGSSTECKER ALS ERSATZTEIL"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2917-5BA00"",
      ""order_number"": ""3RV2917-5BA00""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cc446982-595e-488b-814b-024e811c2dee (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cc446982-595e-488b-814b-024e811c2dee"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_P_NSB0_XX_00945P.png.png"",
      ""part_number"": ""SIE.3RV1917-7B"",
      ""eplan_id"": ""724959"",
      ""designation"": ""TRAGSCHIENE 45MM"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV1917-7B"",
      ""order_number"": ""3RV1917-7B""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a6efc662-f3c3-494a-b51f-f315832846e8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a6efc662-f3c3-494a-b51f-f315832846e8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VKL%255Cproduct_picture_G_NSA0_XX_93182P.png.png"",
      ""part_number"": ""SIE.3RV2917-5AA00"",
      ""eplan_id"": ""724977"",
      ""designation"": ""VERBINDUNGSSTECKER BAUGR. S00"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2917-5AA00"",
      ""order_number"": ""3RV2917-5AA00""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f4d3f3f7-0ac6-479d-8150-654b2a6bba4c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f4d3f3f7-0ac6-479d-8150-654b2a6bba4c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VVB%255Cproduct_picture_G_IC03_XX_03005P.png.png"",
      ""part_number"": ""SIE.3RV2927-5AA00"",
      ""eplan_id"": ""724992"",
      ""designation"": ""VERBINDUNGSSTECKER BAUGR. S0 / SIRIUS Verbindungsstecker / für Leistungsschalter S0 Federzuganschluss"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2927-5AA00"",
      ""order_number"": ""3RV2927-5AA00""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 30dfddee-b9d1-411c-a8a3-04a46a02b681 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""30dfddee-b9d1-411c-a8a3-04a46a02b681"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_VVB%255Cproduct_picture_G_NSA0_XX_92450P.png.png"",
      ""part_number"": ""SIE.3RA2911-2AA00"",
      ""eplan_id"": ""724935"",
      ""designation"": ""VERBIND.BAUSTEIN FUER 3RV2011 UND 3RT201 / SIRIUS Verbindungsbaustein / Betätigungsspannung Schütz: AC und DC"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RA2911-2AA00"",
      ""order_number"": ""3RA2911-2AA00""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8d49fd2f-2229-44b7-bd90-ace6f57093d0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8d49fd2f-2229-44b7-bd90-ace6f57093d0"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001474%255Cproduct_picture_P_NSG0_XX_00106P.png.png"",
      ""part_number"": ""SIE.3LD9251-0A"",
      ""eplan_id"": ""1006378"",
      ""designation"": ""Klemmenabdeckung / SENTRON Klemmenabdeckung / Zubehör für Haupt- und NOT-AUS-Schalter 3LD2"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD9251-0A"",
      ""order_number"": ""3LD9251-0A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f6324633-9f1a-4390-a656-db86d797489b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f6324633-9f1a-4390-a656-db86d797489b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3LD%255Cproduct_picture_G_I202_XX_32155P.png.png"",
      ""part_number"": ""SIE.3LD2704-1TP51"",
      ""eplan_id"": ""573394"",
      ""designation"": ""HAUPTSCHALTER / SENTRON Lasttrennschalter / Lasttrennschalter 3LD"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD2704-1TP51"",
      ""order_number"": ""3LD2704-1TP51""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f76b81d9-9dac-415b-837a-f29b02c61a05 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f76b81d9-9dac-415b-837a-f29b02c61a05"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001474%255Cproduct_picture_G_I202_XX_38486P.png.png"",
      ""part_number"": ""SIE.3LD9344-2CA"",
      ""eplan_id"": ""1093765"",
      ""designation"": ""Tuerkopplungsdrehantrieb / SENTRON Türkopplungsdrehantrieb Zubehör für Lasttrennschalter 3LD3"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD9344-2CA"",
      ""order_number"": ""3LD9344-2CA""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1e4c637b-c57a-4f12-9e33-53943cd8aa88 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1e4c637b-c57a-4f12-9e33-53943cd8aa88"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CS7-1500%255Cproduct_picture_P_ST70_XX_06310P.png.png"",
      ""part_number"": ""SIE.6ES7590-1AF30-0AA0"",
      ""eplan_id"": ""707600"",
      ""designation"": ""PROFILSCHIENE  530MM (20,9\"") / SIMATIC, S7-1500"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7590-1AF30-0AA0"",
      ""order_number"": ""6ES7590-1AF30-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c575db9c-f55e-4c6a-b65b-bd15ff122627 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c575db9c-f55e-4c6a-b65b-bd15ff122627"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINUMERIK%255CP_NC01_XX_00715.jpg.png"",
      ""part_number"": ""SIE.6FC5403-0AA20-0AA0"",
      ""eplan_id"": ""572844"",
      ""designation"": ""SINUMERIK / SINUMERIK_HT8_O._HANDR_"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6FC5403-0AA20-0AA0"",
      ""order_number"": ""6FC5403-0AA20-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1eaf3fc3-9ccf-4657-b1b2-61c6ffbee2aa (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1eaf3fc3-9ccf-4657-b1b2-61c6ffbee2aa"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technologie%255Cproduct_picture_P_KT01_XX_01066I.jpg.png"",
      ""part_number"": ""SIE.6EP1437-3BA10"",
      ""eplan_id"": ""459177"",
      ""designation"": ""SITOP PSU8200 / 24 V/40 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP1437-3BA10"",
      ""order_number"": ""6EP14373BA10""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c1aca309-e561-4060-91e4-424dabbf960e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c1aca309-e561-4060-91e4-424dabbf960e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200S%255Cproduct_picture_P_ST70_XX_03907P.png.png"",
      ""part_number"": ""SIE.6ES7151-3BA23-0AB0"",
      ""eplan_id"": ""458456"",
      ""designation"": ""ET200S, INTERFACEMODUL  IM151-3 PN HF / SIMATIC DP, ET 200S / Interfacemodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7151-3BA23-0AB0"",
      ""order_number"": ""6ES7151-3BA23-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d88224dd-7aac-42a2-ba48-5ce6151027d3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d88224dd-7aac-42a2-ba48-5ce6151027d3"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3LD%255Cproduct_picture_G_I202_XX_32970P.png.png"",
      ""part_number"": ""SIE.3LD2504-0TK51"",
      ""eplan_id"": ""573367"",
      ""designation"": ""Lasttrennschalter 3LD, Hauptschalter / SENTRON Lasttrennschalter 3LD / Hauptschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD2504-0TK51"",
      ""order_number"": ""3LD2504-0TK51""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 96f7a28a-abaf-4ed5-b89f-cc79525b5a45 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""96f7a28a-abaf-4ed5-b89f-cc79525b5a45"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MLE%255Cproduct_picture_G_IC03_XX_06880P.png.png"",
      ""part_number"": ""SIE.3SU1401-2BB20-1AA0"",
      ""eplan_id"": ""522059"",
      ""designation"": ""LED-MODUL, ROT / SIRIUS ACT LED-Modul / LED-Modul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-2BB20-1AA0"",
      ""order_number"": ""3SU1401-2BB20-1AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c7e67735-fd5d-4ed2-9694-ca7f5cd62cc1 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c7e67735-fd5d-4ed2-9694-ca7f5cd62cc1"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00836P.png.png"",
      ""part_number"": ""SIE.3RT2015-1BB42"",
      ""eplan_id"": ""451630"",
      ""designation"": ""SCHUETZ,AC3:3KW 1OE DC24V / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2015-1BB42"",
      ""order_number"": ""3RT2015-1BB42""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7571216a-6559-43ad-9576-11144dd802fb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7571216a-6559-43ad-9576-11144dd802fb"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4308-7"",
      ""eplan_id"": ""455518"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4308-7"",
      ""order_number"": ""5SY4308-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 77547a2b-d487-4fb1-8403-ceb97d5975af (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""77547a2b-d487-4fb1-8403-ceb97d5975af"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4306-7"",
      ""eplan_id"": ""455514"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4306-7"",
      ""order_number"": ""5SY4306-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 470b4d2e-0d12-488b-a86b-2c254be1138d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""470b4d2e-0d12-488b-a86b-2c254be1138d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4311-7"",
      ""eplan_id"": ""455527"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4311-7"",
      ""order_number"": ""5SY4311-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2f36d0e8-f962-4a71-9d57-d43646f58649 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2f36d0e8-f962-4a71-9d57-d43646f58649"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technology%255C6EP19612BA21.jpg.png"",
      ""part_number"": ""SIE.6EP1961-2BA21"",
      ""eplan_id"": ""459201"",
      ""designation"": ""SITOP PSE200U / SELEKTIVITAETSMODUL 10A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP1961-2BA21"",
      ""order_number"": ""6EP1961-2BA21""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3d55d337-d721-4e12-a9f7-cb9024b9a19f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3d55d337-d721-4e12-a9f7-cb9024b9a19f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_07382P.png.png"",
      ""part_number"": ""SIE.3SU1400-2AA10-1CA0"",
      ""eplan_id"": ""521985"",
      ""designation"": ""KONTAKTMODUL 1OE / SIRIUS ACT Kontaktmodul / Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-2AA10-1CA0"",
      ""order_number"": ""3SU1400-2AA10-1CA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9e0defb5-6179-4e15-b70b-f8598e166a00 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9e0defb5-6179-4e15-b70b-f8598e166a00"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BKN%255Cproduct_picture_G_IC03_XX_18435P.png.png"",
      ""part_number"": ""SIE.3SU1002-2BF10-0AA0"",
      ""eplan_id"": ""977738"",
      ""designation"": ""KNEBELSCHALTER, O-I, SCHWARZ / SIRIUS ACT Knebelschalter / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1002-2BF10-0AA0"",
      ""order_number"": ""3SU1002-2BF10-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cfae6675-ac95-49e4-941e-59c1de4321c2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cfae6675-ac95-49e4-941e-59c1de4321c2"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MLE%255Cproduct_picture_G_IC03_XX_06880P.png.png"",
      ""part_number"": ""SIE.3SU1401-2BB60-1AA0"",
      ""eplan_id"": ""522067"",
      ""designation"": ""LED-MODUL, WEISS / SIRIUS ACT LED-Modul / LED-Modul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-2BB60-1AA0"",
      ""order_number"": ""3SU1401-2BB60-1AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fbc05348-e99f-44d5-9d9a-1109ecd0865e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fbc05348-e99f-44d5-9d9a-1109ecd0865e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technology%255CPOWER%2520SUPPLIES%255CP_KT01_XX_01335I.jpg.png"",
      ""part_number"": ""SIE.6EP1333-2BA20"",
      ""eplan_id"": ""459153"",
      ""designation"": ""SITOP PSU100S / 24 V/5 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP1333-2BA20"",
      ""order_number"": ""6EP1333-2BA20""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7de193d7-ef25-4d95-b694-a34167c97266 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7de193d7-ef25-4d95-b694-a34167c97266"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4116-6"",
      ""eplan_id"": ""455343"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4116-6"",
      ""order_number"": ""5SY4116-6""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8f0c78fa-9c1d-453c-985a-0af7c8599e74 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8f0c78fa-9c1d-453c-985a-0af7c8599e74"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04718P.png.png"",
      ""part_number"": ""SIE.5SY4332-7"",
      ""eplan_id"": ""455564"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4332-7"",
      ""order_number"": ""5SY4332-7""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5b60dfc5-5d0f-4324-901a-3c7280e0d9d4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5b60dfc5-5d0f-4324-901a-3c7280e0d9d4"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3LD%255Cproduct_picture_G_I202_XX_33201P.png.png"",
      ""part_number"": ""SIE.3LD2054-1TL51"",
      ""eplan_id"": ""625648"",
      ""designation"": ""Lasttrennschalter 3LD, Hauptschalter / SENTRON Lasttrennschalter 3LD / Hauptschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD2054-1TL51"",
      ""order_number"": ""3LD2054-1TL51""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5d81a01b-a97c-4799-9307-8d3fcfc32eb7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5d81a01b-a97c-4799-9307-8d3fcfc32eb7"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93059P.png.png"",
      ""part_number"": ""SIE.3RV2011-1EA25"",
      ""eplan_id"": ""452798"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 4A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1EA25"",
      ""order_number"": ""3RV2011-1EA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 03d42204-0483-4649-bf76-911a1eea0b08 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""03d42204-0483-4649-bf76-911a1eea0b08"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001267%255Cproduct_picture_P_I201_XX_00828P.png.png"",
      ""part_number"": ""SIE.5SE2300"",
      ""eplan_id"": ""454182"",
      ""designation"": ""NEOZED-Sicherungseinsatz / SENTRON NEOZED-Sicherungseinsatz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SE2300"",
      ""order_number"": ""5SE2300""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 95252207-83ca-45d5-b44e-25da7e2a6844 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""95252207-83ca-45d5-b44e-25da7e2a6844"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00964P.png.png"",
      ""part_number"": ""SIE.3RT2023-2KB40"",
      ""eplan_id"": ""705263"",
      ""designation"": ""KOPPELSCHUETZ,AC3:, 4KW 1S+1OE DC24V / SIRIUS Koppelschütz / FEDERZUGANSCHLUSS"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2023-2KB40"",
      ""order_number"": ""3RT2023-2KB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b32b11de-c52d-443c-8f0f-56557a798013 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b32b11de-c52d-443c-8f0f-56557a798013"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C8WD4%255Cproduct_picture_G_IC03_XX_04845P.png.png"",
      ""part_number"": ""SIE.8WD4408-0CC"",
      ""eplan_id"": ""1239335"",
      ""designation"": ""SIRIUS Winkel für Fußmontage / Winkel für Fussmontage, Zub. für Signalsäulen, D=70mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""8WD4408-0CC"",
      ""order_number"": ""8WD4408-0CC""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4512586a-e6e6-461c-ab49-b2da8714fd62 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4512586a-e6e6-461c-ab49-b2da8714fd62"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93053P.png.png"",
      ""part_number"": ""SIE.3RV2011-1GA15"",
      ""eplan_id"": ""452809"",
      ""designation"": ""LEISTUNGSSCHALTER SCHRAUBANSCHL. 6,3A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2011-1GA15"",
      ""order_number"": ""3RV2011-1GA15""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3e130a9a-7f04-4b86-88aa-664dda6e15d0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3e130a9a-7f04-4b86-88aa-664dda6e15d0"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4110-6"",
      ""eplan_id"": ""455323"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4110-6"",
      ""order_number"": ""5SY4110-6""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6d8a72b6-6260-4ee9-80a6-4b2943178af8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6d8a72b6-6260-4ee9-80a6-4b2943178af8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RQ3%255Cproduct_picture_G_IC03_XX_13626P.png.png"",
      ""part_number"": ""SIE.3RQ3018-1AB00"",
      ""eplan_id"": ""704633"",
      ""designation"": ""AUSGANGSKOPPELGLIED AC/DC24V,1 WECHSLER / SIRIUS Koppelrelais mit Relaisausgang (nicht steckbar)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RQ3018-1AB00"",
      ""order_number"": ""3RQ3018-1AB00""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 12cc004d-b3b1-448e-92c4-3e869140b663 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""12cc004d-b3b1-448e-92c4-3e869140b663"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C3LD%255Cproduct_picture_G_I202_XX_32986P.png.png"",
      ""part_number"": ""SIE.3LD2504-0TK53"",
      ""eplan_id"": ""573368"",
      ""designation"": ""Lasttrennschalter 3LD, Not-Aus-Schalter / SENTRON Lasttrennschalter 3LD / Not-Aus-Schalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD2504-0TK53"",
      ""order_number"": ""3LD2504-0TK53""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fc8e637c-3214-42e8-b9ca-8e1b55a9d00f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fc8e637c-3214-42e8-b9ca-8e1b55a9d00f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RT2%255Cproduct_picture_G_NSA0_XX_00964P.png.png"",
      ""part_number"": ""SIE.3RT2026-2BB40"",
      ""eplan_id"": ""452200"",
      ""designation"": ""SCHUETZ,AC3:11KW 1S+1OE DC24V / SIRIUS Leistungsschütz"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RT2026-2BB40"",
      ""order_number"": ""3RT2026-2BB40""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3c31b2be-3fda-4af0-b82b-acc64a577c49 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3c31b2be-3fda-4af0-b82b-acc64a577c49"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RV2%255Cproduct_picture_G_NSA0_XX_93074P.png.png"",
      ""part_number"": ""SIE.3RV2021-4BA25"",
      ""eplan_id"": ""452849"",
      ""designation"": ""LEISTUNGSSCHALTER FEDERZUGANSCHL. 20A / SIRIUS Leistungsschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV2021-4BA25"",
      ""order_number"": ""3RV2021-4BA25""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7cb03c2d-c14b-468d-9f35-54b93561a84e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7cb03c2d-c14b-468d-9f35-54b93561a84e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_07374P.png.png"",
      ""part_number"": ""SIE.3SU1400-1AA10-3DA0"",
      ""eplan_id"": ""979490"",
      ""designation"": ""KONTAKTMODUL 2S / SIRIUS ACT Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1AA10-3DA0"",
      ""order_number"": ""3SU1400-1AA10-3DA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 34997bd9-e3fa-4c5b-a78b-40bea1eb0015 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""34997bd9-e3fa-4c5b-a78b-40bea1eb0015"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_P_ST70_XX_07595P.png.png"",
      ""part_number"": ""SIE.6ES7193-6BP20-0BB1"",
      ""eplan_id"": ""707428"",
      ""designation"": ""SIMATIC ET 200SP BU-Typ B1 BU20-P12+A0+4B / BaseUnit"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7193-6BP20-0BB1"",
      ""order_number"": ""6ES7193-6BP20-0BB1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7ba741a6-b547-4e61-930f-769bde944e4e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7ba741a6-b547-4e61-930f-769bde944e4e"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3RZ_SAS%255Cproduct_picture_G_IC03_XX_06302P.png.png"",
      ""part_number"": ""SIE.3RV1915-1CB"",
      ""eplan_id"": ""724950"",
      ""designation"": ""3PHAS-SAMMELSCHIENEN BGR.S0/S00"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV1915-1CB"",
      ""order_number"": ""3RV1915-1CB""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 86ad1f71-ad3a-42fc-b1fc-aa3052400330 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""86ad1f71-ad3a-42fc-b1fc-aa3052400330"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Technology%255CPOWER%2520SUPPLIES%255C6EP34368SB000AY0.jpg.png"",
      ""part_number"": ""SIE.6EP3436-8SB00-0AY0"",
      ""eplan_id"": ""707076"",
      ""designation"": ""SITOP PSU8200 3ph 24 V/20 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6EP3436-8SB00-0AY0"",
      ""order_number"": ""6EP3436-8SB00-0AY0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6cf73fa6-d6ac-4238-bba5-b83f9acb94db (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6cf73fa6-d6ac-4238-bba5-b83f9acb94db"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SU%255Cproduct_picture_P_I201_XX_04767P.png.png"",
      ""part_number"": ""SIE.5SU1354-1KK06"",
      ""eplan_id"": ""1238435"",
      ""designation"": ""FI/LS-Schalter / SENTRON FI/LS-Schalter unverzögert"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SU1354-1KK06"",
      ""order_number"": ""5SU1354-1KK06""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 97c211f7-314b-431d-b74c-d2f9187e0717 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""97c211f7-314b-431d-b74c-d2f9187e0717"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_06766P.png.png"",
      ""part_number"": ""SIE.3SU1400-1AA10-3HA0"",
      ""eplan_id"": ""713494"",
      ""designation"": ""KONTAKTMODUL 1OE MONTAGEUEBERWACHT / SIRIUS ACT Kontaktmodul / Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1AA10-3HA0"",
      ""order_number"": ""3SU1400-1AA10-3HA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 234d68e0-4908-41c5-a219-722213f2290d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""234d68e0-4908-41c5-a219-722213f2290d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001474%255Cproduct_picture_P_NSG0_XX_00139P.png.png"",
      ""part_number"": ""SIE.3LD9200-5B"",
      ""eplan_id"": ""968856"",
      ""designation"": ""Hilfsschalter / SENTRON Hilfsschalter / Zubehör für Haupt- und NOT-AUS-Schalter 3LD2 Frontbefestigung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD9200-5B"",
      ""order_number"": ""3LD9200-5B""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a9a4a83d-aa4c-429e-a7a4-0396b5dc7160 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a9a4a83d-aa4c-429e-a7a4-0396b5dc7160"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001470%255Cproduct_picture_P_I201_XX_04774P.png.png"",
      ""part_number"": ""SIE.5ST3805-1"",
      ""eplan_id"": ""1006474"",
      ""designation"": ""für FI-Leitungsschutzschalter T=70mm für Anbau von Zusatzkomponenten (1 Satz=5 Stück im Polybeutel)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5ST3805-1"",
      ""order_number"": ""5ST3805-1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: be3cd329-c9f0-40d1-a9fa-d2639f21794c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""be3cd329-c9f0-40d1-a9fa-d2639f21794c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MKO%255Cproduct_picture_G_IC03_XX_06728P.png.png"",
      ""part_number"": ""SIE.3SU1400-1AA10-1FA0"",
      ""eplan_id"": ""978231"",
      ""designation"": ""KONTAKTMODUL 1S+1OE / SIRIUS ACT Kontaktmodul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1400-1AA10-1FA0"",
      ""order_number"": ""3SU1400-1AA10-1FA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0e8a1f7c-8eba-4682-a7cd-52b242d7e049 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0e8a1f7c-8eba-4682-a7cd-52b242d7e049"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CS7-1500%255Cproduct_picture_P_ST70_XX_06310P.png.png"",
      ""part_number"": ""SIE.6ES7590-1AB60-0AA0"",
      ""eplan_id"": ""707597"",
      ""designation"": ""PROFILSCHIENE 160MM (6,3\"") / SIMATIC, S7-1500"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7590-1AB60-0AA0"",
      ""order_number"": ""6ES7590-1AB60-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8f5953ff-1131-453a-b79e-973aa1a2ccdd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8f5953ff-1131-453a-b79e-973aa1a2ccdd"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CS7-1500%255Cproduct_picture_P_ST70_XX_06310P.png.png"",
      ""part_number"": ""SIE.6ES7590-1AC40-0AA0"",
      ""eplan_id"": ""707598"",
      ""designation"": ""PROFILSCHIENE 245MM (9,6\"") / SIMATIC, S7-1500"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7590-1AC40-0AA0"",
      ""order_number"": ""6ES7590-1AC40-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f04ac4eb-b9fd-42ce-b369-1695b4565c4f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f04ac4eb-b9fd-42ce-b369-1695b4565c4f"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BNH%255Cproduct_picture_G_IC03_XX_06873P.png.png"",
      ""part_number"": ""SIE.3SU1000-1HB20-0AA0"",
      ""eplan_id"": ""462808"",
      ""designation"": ""NOT-HALT-PILZDRUCKTASTER, 40MM, ROT / SIRIUS ACT NOT-HALT-Pilzdrucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1000-1HB20-0AA0"",
      ""order_number"": ""3SU1000-1HB20-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ed580e04-284a-4188-8319-9286a4a5e17b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ed580e04-284a-4188-8319-9286a4a5e17b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1ZSO%255Cproduct_picture_G_IC03_XX_07758P.png.png"",
      ""part_number"": ""SIE.3SU1900-0KH80-0AA0"",
      ""eplan_id"": ""994201"",
      ""designation"": ""HUTSCHIENENMONTAGE-ADAPTER / SIRIUS ACT Adapter / für Hutschienenmontage"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1900-0KH80-0AA0"",
      ""order_number"": ""3SU1900-0KH80-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ccc0c439-c9bc-4aaf-bfd5-633a5291726b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ccc0c439-c9bc-4aaf-bfd5-633a5291726b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": """",
      ""part_number"": ""SIE.3RV1935-3C"",
      ""eplan_id"": ""724966"",
      ""designation"": ""3PHAS-SAMMELSCHIENEN BGR.S2"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3RV1935-3C"",
      ""order_number"": ""3RV1935-3C""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 89d42ca5-2652-4d3c-9c78-c1db0882e629 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""89d42ca5-2652-4d3c-9c78-c1db0882e629"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255Cproduct_picture_G_ST70_XX_02085P.png.png"",
      ""part_number"": ""SIE.6ES7132-6BH01-0BA0"",
      ""eplan_id"": ""994288"",
      ""designation"": ""SIMATIC ET 200SP DQ 16x24 VDC/0,5 A ST / Digitalmodul Ausgang"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7132-6BH01-0BA0"",
      ""order_number"": ""6ES7132-6BH01-0BA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6f0983b3-f12c-4cbf-bfba-5ba957289286 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6f0983b3-f12c-4cbf-bfba-5ba957289286"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C5SY%255Cproduct_picture_P_I201_XX_04734P.png.png"",
      ""part_number"": ""SIE.5SY4102-6"",
      ""eplan_id"": ""958127"",
      ""designation"": ""SENTRON Leitungsschutzschalter"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""5SY4102-6"",
      ""order_number"": ""5SY4102-6""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d28df921-bc29-4999-99bf-a02ae3c0ec96 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d28df921-bc29-4999-99bf-a02ae3c0ec96"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CLow_Voltage%255C1001474%255Cproduct_picture_P_NSG0_XX_00107P.png.png"",
      ""part_number"": ""SIE.3LD9281-2A"",
      ""eplan_id"": ""1006380"",
      ""designation"": ""Klemmenabdeckung / SENTRON Klemmenabdeckung / Zubehör für Haupt- und NOT-AUS-Schalter 3LD2"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3LD9281-2A"",
      ""order_number"": ""3LD9281-2A""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8042a8b9-9fd6-41de-ae5a-8a884faba5a8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8042a8b9-9fd6-41de-ae5a-8a884faba5a8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1BD%255Cproduct_picture_G_IC03_XX_07905P.png.png"",
      ""part_number"": ""SIE.3SU1001-0AB50-0AA0"",
      ""eplan_id"": ""463086"",
      ""designation"": ""LEUCHTDRUCKTASTER, BLAU / SIRIUS ACT Leuchtdrucktaster / Betätigungs-/Meldeelement"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1001-0AB50-0AA0"",
      ""order_number"": ""3SU1001-0AB50-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4a88fe70-a714-4145-8a18-ef43fcc6006d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4a88fe70-a714-4145-8a18-ef43fcc6006d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CIndustrial_Controls%255C3SU1MLE%255Cproduct_picture_G_IC03_XX_06774P.png.png"",
      ""part_number"": ""SIE.3SU1401-1BB60-3AA0"",
      ""eplan_id"": ""522006"",
      ""designation"": ""LED-MODUL, WEISS / SIRIUS ACT LED-Modul / LED-Modul"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""3SU1401-1BB60-3AA0"",
      ""order_number"": ""3SU1401-1BB60-3AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2cdb906e-2441-473a-a7bd-92f5844764c5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2cdb906e-2441-473a-a7bd-92f5844764c5"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": """",
      ""part_number"": ""SIE.6SL3162-2MA00-0AC0"",
      ""eplan_id"": ""708017"",
      ""designation"": ""MOTORSTECKER MIT SCHRAUBANSCHLUSS / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3162-2MA00-0AC0"",
      ""order_number"": ""6SL3162-2MA00-0AC0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ebeb338e-83f9-4110-b9a8-389b01792e0d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ebeb338e-83f9-4110-b9a8-389b01792e0d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255C1005371%255Cproduct_picture_P_D211_XX_00205P.png.png"",
      ""part_number"": ""SIE.6SL3040-1MA01-0AA0"",
      ""eplan_id"": ""461985"",
      ""designation"": ""SINAMICS S120 CONTROL UNIT CU320-2 PN / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3040-1MA01-0AA0"",
      ""order_number"": ""6SL3040-1MA01-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: aa599617-f95c-46ce-83f8-a82d4eecab95 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""aa599617-f95c-46ce-83f8-a82d4eecab95"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C281%255C281-312.jpg.png"",
      ""part_number"": ""WAGO.281-312"",
      ""eplan_id"": ""496173"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""281-312"",
      ""order_number"": ""281-312""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5b483a92-d9cb-4007-be6d-5d0f43b229da (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5b483a92-d9cb-4007-be6d-5d0f43b229da"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C281%255C281-631.jpg.png"",
      ""part_number"": ""WAGO.281-631"",
      ""eplan_id"": ""496283"",
      ""designation"": ""Durchgangsreihenklemme / 3-Leiter-Durchgangsklemme, 4 mm², 32 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""281-631"",
      ""order_number"": ""281-631""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0238fad8-5c6b-41df-965e-a9f3460bd29e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0238fad8-5c6b-41df-965e-a9f3460bd29e"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C781-604.jpg.png"",
      ""part_number"": ""WAGO.781-604"",
      ""eplan_id"": ""502825"",
      ""designation"": ""2-Leiter-Durchgangsklemme / für Anwendungen Ex i geeignet"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""781-604"",
      ""order_number"": ""781-604""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3427ddd5-625b-48ec-a123-d0d9d7187921 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3427ddd5-625b-48ec-a123-d0d9d7187921"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C249%255C249-117.jpg.png"",
      ""part_number"": ""WAGO.249-117"",
      ""eplan_id"": ""1222682"",
      ""designation"": ""Endklammer/-halter für Reihenklemme / Schraubenlose Endklammer, 10 mm breit, für Tragschiene 35 x 15 und 35 x 7,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""249-117"",
      ""order_number"": ""249-117""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: bb54a5dc-e7cd-425b-8635-c6a2fc8bd01b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""bb54a5dc-e7cd-425b-8635-c6a2fc8bd01b"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C249%255C249-119.jpg.png"",
      ""part_number"": ""WAGO.249-119"",
      ""eplan_id"": ""729480"",
      ""designation"": ""Halterung für Bezeichnungsmaterial / Gruppenschildträger, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""249-119"",
      ""order_number"": ""249-119""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cafb2bf6-417e-4327-a5a6-70eeb4612619 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cafb2bf6-417e-4327-a5a6-70eeb4612619"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-1292.jpg.png"",
      ""part_number"": ""WAGO.2016-1292"",
      ""eplan_id"": ""1222243"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 1 mm dick, orange"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-1292"",
      ""order_number"": ""2016-1292""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0cbf4c47-5db1-4a8d-8fed-286f08cd0cb4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0cbf4c47-5db1-4a8d-8fed-286f08cd0cb4"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-2201.jpg.png"",
      ""part_number"": ""WAGO.2002-2201"",
      ""eplan_id"": ""489636"",
      ""designation"": ""Durchgangsreihenklemme / Doppelstockklemme, 2,5 mm², 24 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-2201"",
      ""order_number"": ""2002-2201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b487685b-ef33-4edb-9c93-1f354dd9c2ec (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b487685b-ef33-4edb-9c93-1f354dd9c2ec"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C285%255C285-435.jpg.png"",
      ""part_number"": ""WAGO.285-435"",
      ""eplan_id"": ""1222356"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Brücker, isoliert"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""285-435"",
      ""order_number"": ""285-435""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d1a77c2a-a184-43e4-8f23-b54affd03adb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d1a77c2a-a184-43e4-8f23-b54affd03adb"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C282%255C282-402.jpg.png"",
      ""part_number"": ""WAGO.282-402"",
      ""eplan_id"": ""496416"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Brücker, 41 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""282-402"",
      ""order_number"": ""282-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 38df638a-fdc6-460d-90f0-181105884a53 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""38df638a-fdc6-460d-90f0-181105884a53"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C280%255C280-402.jpg.png"",
      ""part_number"": ""WAGO.280-402"",
      ""eplan_id"": ""1222020"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Brücker, 24 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""280-402"",
      ""order_number"": ""280-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 41e10ee0-aae7-405e-8bbc-2e3501439a5f (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""41e10ee0-aae7-405e-8bbc-2e3501439a5f"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-410.jpg.png"",
      ""part_number"": ""WAGO.2001-410"",
      ""eplan_id"": ""489551"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 10-fach, Nennstrom 18 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-410"",
      ""order_number"": ""2001-410""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b2bcaf74-885e-4205-b8a0-e6b22ba68182 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b2bcaf74-885e-4205-b8a0-e6b22ba68182"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-405.jpg.png"",
      ""part_number"": ""WAGO.2001-405"",
      ""eplan_id"": ""489546"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 5-fach, Nennstrom 18 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-405"",
      ""order_number"": ""2001-405""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: cfbffb67-9043-4e77-aa2e-1fe4377ad249 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""cfbffb67-9043-4e77-aa2e-1fe4377ad249"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-404.jpg.png"",
      ""part_number"": ""WAGO.2001-404"",
      ""eplan_id"": ""489545"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 4-fach, Nennstrom 18 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-404"",
      ""order_number"": ""2001-404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4d03cf94-08dd-404c-a4af-9f4d50455b37 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4d03cf94-08dd-404c-a4af-9f4d50455b37"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-403.jpg.png"",
      ""part_number"": ""WAGO.2001-403"",
      ""eplan_id"": ""489544"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 3-fach, Nennstrom 18 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-403"",
      ""order_number"": ""2001-403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9758a26e-fc60-40d4-b963-3434bfa78ba5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9758a26e-fc60-40d4-b963-3434bfa78ba5"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-402.jpg.png"",
      ""part_number"": ""WAGO.2001-402"",
      ""eplan_id"": ""489543"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 2-fach, Nennstrom 18 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-402"",
      ""order_number"": ""2001-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d47286a9-64e3-4779-a610-949c35f95590 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d47286a9-64e3-4779-a610-949c35f95590"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-410.jpg.png"",
      ""part_number"": ""WAGO.2002-410"",
      ""eplan_id"": ""1222725"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 10-fach, Nennstrom 25 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-410"",
      ""order_number"": ""2002-410""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a62d098e-9229-4766-bdb3-1d139512be37 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a62d098e-9229-4766-bdb3-1d139512be37"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-406.jpg.png"",
      ""part_number"": ""WAGO.2002-406"",
      ""eplan_id"": ""1222712"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 6-fach, Nennstrom 25 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-406"",
      ""order_number"": ""2002-406""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7da49840-a7af-41ef-b9cc-910df0e7c506 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7da49840-a7af-41ef-b9cc-910df0e7c506"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-410.jpg.png"",
      ""part_number"": ""WAGO.2004-410"",
      ""eplan_id"": ""489846"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 10-fach, Nennstrom 32 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-410"",
      ""order_number"": ""2004-410""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7c11f8a0-c0b8-4b31-93e2-72b15b2f1cca (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7c11f8a0-c0b8-4b31-93e2-72b15b2f1cca"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-405.jpg.png"",
      ""part_number"": ""WAGO.2004-405"",
      ""eplan_id"": ""489840"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 5-fach, Nennstrom 32 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-405"",
      ""order_number"": ""2004-405""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 52663464-91c0-4380-9881-da418b115d94 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""52663464-91c0-4380-9881-da418b115d94"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-404.jpg.png"",
      ""part_number"": ""WAGO.2004-404"",
      ""eplan_id"": ""489839"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 4-fach, Nennstrom 32 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-404"",
      ""order_number"": ""2004-404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: dd35b87b-6381-4964-acec-ee6bcbca1578 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""dd35b87b-6381-4964-acec-ee6bcbca1578"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-403.jpg.png"",
      ""part_number"": ""WAGO.2004-403"",
      ""eplan_id"": ""489838"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 3-fach, Nennstrom 32 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-403"",
      ""order_number"": ""2004-403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: badd8e99-15c4-4e76-92af-1cb300cefe56 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""badd8e99-15c4-4e76-92af-1cb300cefe56"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-402.jpg.png"",
      ""part_number"": ""WAGO.2004-402"",
      ""eplan_id"": ""489837"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 2-fach, Nennstrom 32 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-402"",
      ""order_number"": ""2004-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2ad6bf03-3a8e-4eb6-929b-bacc1c5d242b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2ad6bf03-3a8e-4eb6-929b-bacc1c5d242b"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-405.jpg.png"",
      ""part_number"": ""WAGO.2006-405"",
      ""eplan_id"": ""1222491"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 5-fach, Nennstrom 41 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-405"",
      ""order_number"": ""2006-405""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 26412cda-0b42-471d-bfc1-906d03ad8cae (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""26412cda-0b42-471d-bfc1-906d03ad8cae"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-404.jpg.png"",
      ""part_number"": ""WAGO.2006-404"",
      ""eplan_id"": ""1222490"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 4-fach, Nennstrom 41 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-404"",
      ""order_number"": ""2006-404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2d9e2e35-7ac9-4ad1-b667-ea356b0b03d7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2d9e2e35-7ac9-4ad1-b667-ea356b0b03d7"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-403.jpg.png"",
      ""part_number"": ""WAGO.2006-403"",
      ""eplan_id"": ""1222489"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 3-fach, Nennstrom 41 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-403"",
      ""order_number"": ""2006-403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 99041a20-4c65-40e5-86f8-9f4942bc8fbb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""99041a20-4c65-40e5-86f8-9f4942bc8fbb"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-499.jpg.png"",
      ""part_number"": ""WAGO.2006-499"",
      ""eplan_id"": ""1222496"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Reduzierbrücker, isoliert, von 6/4 mm² auf 4/2,5/1,5 mm², Nennstrom 32 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-499"",
      ""order_number"": ""2006-499""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: dc32b6d2-4815-42e9-93b7-5669f5249658 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""dc32b6d2-4815-42e9-93b7-5669f5249658"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-402.jpg.png"",
      ""part_number"": ""WAGO.2006-402"",
      ""eplan_id"": ""1222488"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 2-fach, Nennstrom 41 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-402"",
      ""order_number"": ""2006-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7c5546a0-7ca2-4cae-bc67-34a579fff121 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7c5546a0-7ca2-4cae-bc67-34a579fff121"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-404.jpg.png"",
      ""part_number"": ""WAGO.2010-404"",
      ""eplan_id"": ""1222235"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 4-fach, Nennstrom 57 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-404"",
      ""order_number"": ""2010-404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 252e18ff-9e2b-4eec-99aa-88d701f1b555 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""252e18ff-9e2b-4eec-99aa-88d701f1b555"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-403.jpg.png"",
      ""part_number"": ""WAGO.2010-403"",
      ""eplan_id"": ""1222234"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 3-fach, Nennstrom 57 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-403"",
      ""order_number"": ""2010-403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c2d98b5d-378e-428c-a1dd-b94ef576ac59 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c2d98b5d-378e-428c-a1dd-b94ef576ac59"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-402.jpg.png"",
      ""part_number"": ""WAGO.2010-402"",
      ""eplan_id"": ""1222233"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 2-fach, Nennstrom 57 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-402"",
      ""order_number"": ""2010-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3bc1ab22-5abe-47e7-b673-5f5e1d9bb9c6 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3bc1ab22-5abe-47e7-b673-5f5e1d9bb9c6"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-404.jpg.png"",
      ""part_number"": ""WAGO.2016-404"",
      ""eplan_id"": ""1222502"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 4-fach, Nennstrom 76 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-404"",
      ""order_number"": ""2016-404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 91a221de-4e1b-4891-a426-ed169d289383 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""91a221de-4e1b-4891-a426-ed169d289383"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-403.jpg.png"",
      ""part_number"": ""WAGO.2016-403"",
      ""eplan_id"": ""1222501"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 3-fach, Nennstrom 76 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-403"",
      ""order_number"": ""2016-403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8121962f-3082-41a7-9564-095ed902d19c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8121962f-3082-41a7-9564-095ed902d19c"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-402.jpg.png"",
      ""part_number"": ""WAGO.2016-402"",
      ""eplan_id"": ""1222500"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 2-fach, Nennstrom 76 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-402"",
      ""order_number"": ""2016-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 243f82de-5bc7-44b0-a320-8bd818523023 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""243f82de-5bc7-44b0-a320-8bd818523023"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-499.jpg.png"",
      ""part_number"": ""WAGO.2016-499"",
      ""eplan_id"": ""1222508"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Reduzierbrücker, isoliert, von 16/10 mm² auf 10/6/4/2,5 mm², Nennstrom 57 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-499"",
      ""order_number"": ""2016-499""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 03228d05-cbb7-401d-926c-5cdfee17806d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""03228d05-cbb7-401d-926c-5cdfee17806d"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-405.jpg.png"",
      ""part_number"": ""WAGO.2002-405"",
      ""eplan_id"": ""1222708"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 5-fach, Nennstrom 25 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-405"",
      ""order_number"": ""2002-405""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: bf6e254b-fb79-40d1-879e-b40c15859f8d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""bf6e254b-fb79-40d1-879e-b40c15859f8d"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-404.jpg.png"",
      ""part_number"": ""WAGO.2002-404"",
      ""eplan_id"": ""1222705"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 4-fach, Nennstrom 25 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-404"",
      ""order_number"": ""2002-404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9664c2a6-0873-46ec-a2bf-f688402284c8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9664c2a6-0873-46ec-a2bf-f688402284c8"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-403.jpg.png"",
      ""part_number"": ""WAGO.2002-403"",
      ""eplan_id"": ""1222702"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 3-fach, Nennstrom 25 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-403"",
      ""order_number"": ""2002-403""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9f473aa0-3ede-4303-b46f-cc1c99cfdec3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9f473aa0-3ede-4303-b46f-cc1c99cfdec3"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-402.jpg.png"",
      ""part_number"": ""WAGO.2002-402"",
      ""eplan_id"": ""1222699"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Kammbrücker, isoliert, 2-fach, Nennstrom 25 A"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-402"",
      ""order_number"": ""2002-402""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8d727da7-0ac3-4adb-be15-82bf9c358f24 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8d727da7-0ac3-4adb-be15-82bf9c358f24"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C781%255C781-601.jpg.png"",
      ""part_number"": ""WAGO.781-601"",
      ""eplan_id"": ""502824"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 4 mm², 32 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""781-601"",
      ""order_number"": ""781-601""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f918dccf-e5e5-4d3e-975e-5d882fbe9664 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f918dccf-e5e5-4d3e-975e-5d882fbe9664"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-1201.jpg.png"",
      ""part_number"": ""WAGO.2001-1201"",
      ""eplan_id"": ""489510"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 1,5 mm², 18 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-1201"",
      ""order_number"": ""2001-1201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b87a891e-c777-493e-b496-d8364a6def16 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b87a891e-c777-493e-b496-d8364a6def16"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-1204.jpg.png"",
      ""part_number"": ""WAGO.2001-1204"",
      ""eplan_id"": ""489513"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 1,5 mm², 18 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-1204"",
      ""order_number"": ""2001-1204""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9563299a-1368-4209-a1e4-90934f4721c4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9563299a-1368-4209-a1e4-90934f4721c4"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-1207.jpg.png"",
      ""part_number"": ""WAGO.2001-1207"",
      ""eplan_id"": ""489516"",
      ""designation"": ""Schutzleiter-Reihenklemme / 2-Leiter-Schutzleiterklemme, 1,5 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-1207"",
      ""order_number"": ""2001-1207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9bced1f8-d4af-4863-a630-ca658eae105a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9bced1f8-d4af-4863-a630-ca658eae105a"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-1401.jpg.png"",
      ""part_number"": ""WAGO.2001-1401"",
      ""eplan_id"": ""489530"",
      ""designation"": ""Durchgangsreihenklemme / 4-Leiter-Durchgangsklemme, 1,5 mm², 18 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-1401"",
      ""order_number"": ""2001-1401""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 525923e5-95fd-44e1-822e-a1039e04747c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""525923e5-95fd-44e1-822e-a1039e04747c"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2001%255C2001-1407.jpg.png"",
      ""part_number"": ""WAGO.2001-1407"",
      ""eplan_id"": ""489536"",
      ""designation"": ""Schutzleiter-Reihenklemme / 4-Leiter-Schutzleiterklemme, 1,5 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2001-1407"",
      ""order_number"": ""2001-1407""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d9fae7ec-096a-4115-be58-4b1b26789cd5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d9fae7ec-096a-4115-be58-4b1b26789cd5"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1204.jpg.png"",
      ""part_number"": ""WAGO.2002-1204"",
      ""eplan_id"": ""489575"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 2,5 mm², 24 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1204"",
      ""order_number"": ""2002-1204""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5eec07ef-3daf-43aa-ae8d-6b37d41593b9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5eec07ef-3daf-43aa-ae8d-6b37d41593b9"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1291.jpg.png"",
      ""part_number"": ""WAGO.2002-1291"",
      ""eplan_id"": ""489582"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 0,8 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1291"",
      ""order_number"": ""2002-1291""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 82dd06e3-8563-4e84-bb2b-ba3a369fe1e2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""82dd06e3-8563-4e84-bb2b-ba3a369fe1e2"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1404.jpg.png"",
      ""part_number"": ""WAGO.2002-1404"",
      ""eplan_id"": ""489605"",
      ""designation"": ""Durchgangsreihenklemme / 4-Leiter-Durchgangsklemme, 2,5 mm², 24 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1404"",
      ""order_number"": ""2002-1404""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5a553811-5d58-4b29-a925-f74b058c9f86 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5a553811-5d58-4b29-a925-f74b058c9f86"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-1491.jpg.png"",
      ""part_number"": ""WAGO.2002-1491"",
      ""eplan_id"": ""489614"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 0,8 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-1491"",
      ""order_number"": ""2002-1491""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 109b8816-0764-4561-9420-fab59f523a9d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""109b8816-0764-4561-9420-fab59f523a9d"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-2202.jpg.png"",
      ""part_number"": ""WAGO.2002-2202"",
      ""eplan_id"": ""489637"",
      ""designation"": ""Durchgangsreihenklemme / Doppelstockklemme, 2,5 mm², 24 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-2202"",
      ""order_number"": ""2002-2202""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: de6806de-c63f-40e7-933a-afdc2659aa05 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""de6806de-c63f-40e7-933a-afdc2659aa05"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-2291.jpg.png"",
      ""part_number"": ""WAGO.2002-2291"",
      ""eplan_id"": ""489664"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 0,8 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-2291"",
      ""order_number"": ""2002-2291""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: baa87cfe-9d30-4414-be36-2eb855b1acc8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""baa87cfe-9d30-4414-be36-2eb855b1acc8"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-3217.jpg.png"",
      ""part_number"": ""WAGO.2002-3217"",
      ""eplan_id"": ""489708"",
      ""designation"": ""Schutzleiter-Reihenklemme / Dreistockklemme, 2,5 mm², 24 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-3217"",
      ""order_number"": ""2002-3217""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8f8c1a45-c343-42da-93d4-f5cc541af11b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8f8c1a45-c343-42da-93d4-f5cc541af11b"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-3291.jpg.png"",
      ""part_number"": ""WAGO.2002-3291"",
      ""eplan_id"": ""489724"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 0,8 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-3291"",
      ""order_number"": ""2002-3291""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e648baf7-d591-4292-ba98-6b5370ac8141 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e648baf7-d591-4292-ba98-6b5370ac8141"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-1301.jpg.png"",
      ""part_number"": ""WAGO.2004-1301"",
      ""eplan_id"": ""489805"",
      ""designation"": ""Durchgangsreihenklemme / 3-Leiter-Durchgangsklemme, 4 mm², 32 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-1301"",
      ""order_number"": ""2004-1301""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8fbbee44-ba42-49fe-82c2-85ab669a2b71 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8fbbee44-ba42-49fe-82c2-85ab669a2b71"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-1304.jpg.png"",
      ""part_number"": ""WAGO.2004-1304"",
      ""eplan_id"": ""489808"",
      ""designation"": ""Durchgangsreihenklemme / 3-Leiter-Durchgangsklemme, 4 mm², 32 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-1304"",
      ""order_number"": ""2004-1304""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8bc931a1-4553-40ef-8a6a-94df3bb9cbb7 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8bc931a1-4553-40ef-8a6a-94df3bb9cbb7"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-1307.jpg.png"",
      ""part_number"": ""WAGO.2004-1307"",
      ""eplan_id"": ""489811"",
      ""designation"": ""Schutzleiter-Reihenklemme / 3-Leiter-Schutzleiterklemme, 4 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-1307"",
      ""order_number"": ""2004-1307""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 0c29e8d8-d838-4bc3-90b7-9dd1a3f46474 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""0c29e8d8-d838-4bc3-90b7-9dd1a3f46474"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2004%255C2004-1391.jpg.png"",
      ""part_number"": ""WAGO.2004-1391"",
      ""eplan_id"": ""489816"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 1 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2004-1391"",
      ""order_number"": ""2004-1391""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b9d0dd25-56c4-40ac-844a-fda81d9c2a3b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b9d0dd25-56c4-40ac-844a-fda81d9c2a3b"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-1204.jpg.png"",
      ""part_number"": ""WAGO.2010-1204"",
      ""eplan_id"": ""1222218"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 10 mm², 57 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-1204"",
      ""order_number"": ""2010-1204""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3cb3d668-4a90-4dd0-bc97-c61377a33cc0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3cb3d668-4a90-4dd0-bc97-c61377a33cc0"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-1207.jpg.png"",
      ""part_number"": ""WAGO.2010-1207"",
      ""eplan_id"": ""1222221"",
      ""designation"": ""Schutzleiter-Reihenklemme / 2-Leiter-Schutzleiterklemme, 10 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-1207"",
      ""order_number"": ""2010-1207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1035c728-ce0b-4275-9900-441fe6491506 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1035c728-ce0b-4275-9900-441fe6491506"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-1291.jpg.png"",
      ""part_number"": ""WAGO.2010-1291"",
      ""eplan_id"": ""1222222"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 1 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-1291"",
      ""order_number"": ""2010-1291""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7fe612d0-8c66-45a4-ac18-1a9da0001ddb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7fe612d0-8c66-45a4-ac18-1a9da0001ddb"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-1201.jpg.png"",
      ""part_number"": ""WAGO.2016-1201"",
      ""eplan_id"": ""489949"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 16 mm², 76 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-1201"",
      ""order_number"": ""2016-1201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 026eeaab-ffc2-44af-adb9-6ff8fff33886 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""026eeaab-ffc2-44af-adb9-6ff8fff33886"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-1204.jpg.png"",
      ""part_number"": ""WAGO.2016-1204"",
      ""eplan_id"": ""489951"",
      ""designation"": ""Durchgangsreihenklemme / 2-Leiter-Durchgangsklemme, 16 mm², 76 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-1204"",
      ""order_number"": ""2016-1204""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8c024a83-71f3-4a41-9434-3efaa5ba7726 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8c024a83-71f3-4a41-9434-3efaa5ba7726"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2016%255C2016-1291.jpg.png"",
      ""part_number"": ""WAGO.2016-1291"",
      ""eplan_id"": ""1222242"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 1 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2016-1291"",
      ""order_number"": ""2016-1291""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f125fba3-e637-45d9-9afc-75c99b51bb1a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f125fba3-e637-45d9-9afc-75c99b51bb1a"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C280%255C280-560.jpg.png"",
      ""part_number"": ""WAGO.280-560"",
      ""eplan_id"": ""495923"",
      ""designation"": ""Initiator/Aktor-Reihenklemme / 3-Leiter-Initiatorenklemme, 2,5 mm², 20 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""280-560"",
      ""order_number"": ""280-560""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 16077f85-a594-4c26-b4bb-ef9964ac51cd (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""16077f85-a594-4c26-b4bb-ef9964ac51cd"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C289-201.jpg.png"",
      ""part_number"": ""WAGO.289-201"",
      ""eplan_id"": ""496979"",
      ""designation"": ""Bauteilmodul mit LED / mit 16 Stück / LED rot"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""289-201"",
      ""order_number"": ""289-201""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 4fffbd76-7f32-4060-a0b8-69e0722df6c2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""4fffbd76-7f32-4060-a0b8-69e0722df6c2"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C790%255C790-108.jpg.png"",
      ""part_number"": ""WAGO.790-108"",
      ""eplan_id"": ""1222581"",
      ""designation"": ""Schirmanschlussklemme / Schirmklemmbügel, 11 mm breit, kontaktierbarer Schirmdurchmesser, 3 ... 8 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""790-108"",
      ""order_number"": ""790-108""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 14759ca3-e90c-4525-a332-03a4b1ba47e5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""14759ca3-e90c-4525-a332-03a4b1ba47e5"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C790%255C790-116.jpg.png"",
      ""part_number"": ""WAGO.790-116"",
      ""eplan_id"": ""1222433"",
      ""designation"": ""Schirmanschlussklemme / Schirmklemmbügel, 19 mm breit, kontaktierbarer Schirmdurchmesser, 7 ... 16 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""790-116"",
      ""order_number"": ""790-116""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ca20f566-6034-4f85-9267-9fd1bfadb185 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ca20f566-6034-4f85-9267-9fd1bfadb185"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2010%255C2010-1301.jpg.png"",
      ""part_number"": ""WAGO.2010-1301"",
      ""eplan_id"": ""1222224"",
      ""designation"": ""Durchgangsreihenklemme / 3-Leiter-Durchgangsklemme, 10 mm², 57 A, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2010-1301"",
      ""order_number"": ""2010-1301""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 3b9e2db7-6af8-4bab-a329-a6539ec411c5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""3b9e2db7-6af8-4bab-a329-a6539ec411c5"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2002%255C2002-2207.jpg.png"",
      ""part_number"": ""WAGO.2002-2207"",
      ""eplan_id"": ""489640"",
      ""designation"": ""Schutzleiter-Reihenklemme / Doppelstockklemme, 2,5 mm², grün-gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2002-2207"",
      ""order_number"": ""2002-2207""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 910297a3-3dde-45c7-a27d-0115a9c05086 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""910297a3-3dde-45c7-a27d-0115a9c05086"",
      ""manufacturer_id"": ""d2b4f7e4-a6c2-4e67-8838-4f5c511d77dc"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WAGO/512/WAGO%255C2006%255C2006-1291.jpg.png"",
      ""part_number"": ""WAGO.2006-1291"",
      ""eplan_id"": ""1222206"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschluss- und Zwischenplatte, 1 mm dick, grau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""2006-1291"",
      ""order_number"": ""2006-1291""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5fd2e4e8-78a3-4fc0-af86-8d5a9055f57c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5fd2e4e8-78a3-4fc0-af86-8d5a9055f57c"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19636000009999.jpg.png"",
      ""part_number"": ""WEI.1963600000"",
      ""eplan_id"": ""636404"",
      ""designation"": ""Steckverbinder RJ45 / Steckverbinder RJ45, IP20, Anschluss 1: RJ45, Anschluss 2: IDC8-adrig, 4-adrig, EIA/TIA T568 A, EIA/TIA T568 B, PROFINETAWG 26/7...AWG 22/7"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""IE-PS-RJ45-FH-BK"",
      ""order_number"": ""1963600000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c1877432-c333-451f-88ce-00b2df563dbb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c1877432-c333-451f-88ce-00b2df563dbb"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19249100009999.jpg.png"",
      ""part_number"": ""WEI.1924910000"",
      ""eplan_id"": ""511296"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Trennwand (Klemmen) Abschluss- und Zwischenplatte, 92.6 mm x 41.5 mm, dunkelbeige"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZAP/TW ZDK 2.5/3AN"",
      ""order_number"": ""1924910000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 59182f06-ef15-4600-90a0-58012993c182 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""59182f06-ef15-4600-90a0-58012993c182"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19062300009999.jpg.png"",
      ""part_number"": ""WEI.1906230000"",
      ""eplan_id"": ""507713"",
      ""designation"": ""Querverbinder (Klemmen) / Querverbinder (Klemmen), gesteckt, Polzahl: 4, Raster in mm: 8.00, Isoliert: Ja, 41 A, gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 6N/4"",
      ""order_number"": ""1906230000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2bc3288a-cf4a-4665-b309-f2e26fc86d67 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2bc3288a-cf4a-4665-b309-f2e26fc86d67"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C16089400009999.jpg.png"",
      ""part_number"": ""WEI.1608940000"",
      ""eplan_id"": ""506622"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 10, Raster in mm: 5.10, Isoliert: Ja, 24 A, gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 2.5/10"",
      ""order_number"": ""1608940000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 67f71df2-850f-4ac3-81ee-16a33e35bf80 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""67f71df2-850f-4ac3-81ee-16a33e35bf80"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C16085100009999.jpg.png"",
      ""part_number"": ""WEI.1608510000"",
      ""eplan_id"": ""506589"",
      ""designation"": ""Durchgangs-Reihenklemme / Durchgangs-Reihenklemme, Zugfederanschluss, 2.5 mm², 800 V, 24 A, Anzahl Anschlüsse: 2"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZDU 2.5"",
      ""order_number"": ""1608510000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c95bb2cd-88ca-46da-bf09-77294c9e35b5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c95bb2cd-88ca-46da-bf09-77294c9e35b5"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19883200009999.jpg.png"",
      ""part_number"": ""WEI.1988320000"",
      ""eplan_id"": ""636462"",
      ""designation"": ""Abschluss- und Zwischenplatte für Reihenklemme / Abschlussplatte (Klemmen) 84 mm x 2.4 mm, dunkelbeige"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AEP AP11"",
      ""order_number"": ""1988320000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: e7fd9d56-2bfa-4d77-bb8f-d6ea436e365e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""e7fd9d56-2bfa-4d77-bb8f-d6ea436e365e"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C01403200009999.jpg.png"",
      ""part_number"": ""WEI.0140320000"",
      ""eplan_id"": ""505326"",
      ""designation"": ""Ein- und mehrpolige Klemmenleiste / Ein- und mehrpolige Klemmenleiste, Schraubanschluss, 2.5 mm², 500 V, 24 A, Polzahl: 4, 25 mm, mittelgelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""KS 4 O.D4"",
      ""order_number"": ""0140320000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 043ed9c4-70d1-4c81-9dbc-39734b1a1b6b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""043ed9c4-70d1-4c81-9dbc-39734b1a1b6b"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C16085500009999.jpg.png"",
      ""part_number"": ""WEI.1608550000"",
      ""eplan_id"": ""506592"",
      ""designation"": ""Durchgangs-Reihenklemme / Durchgangs-Reihenklemme, Zugfederanschluss, 2.5 mm², 800 V, 24 A, Anzahl Anschlüsse: 3"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZDU 2.5/3AN BL"",
      ""order_number"": ""1608550000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2b547a3d-aaee-47e8-a041-c2adedbb4b59 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2b547a3d-aaee-47e8-a041-c2adedbb4b59"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C17336400009999.jpg.png"",
      ""part_number"": ""WEI.1733640000"",
      ""eplan_id"": ""506901"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 32, Raster in mm: 8.10, Isoliert: Ja, 41 A, gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 6/32 GE"",
      ""order_number"": ""1733640000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8780c358-2a3f-4089-af6f-a6f9ea82486d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8780c358-2a3f-4089-af6f-a6f9ea82486d"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C17683100009999.jpg.png"",
      ""part_number"": ""WEI.1768310000"",
      ""eplan_id"": ""507004"",
      ""designation"": ""Schutzleiter-Reihenklemme / Schutzleiter-Reihenklemme, Zugfederanschluss, 16 mm², 800 V, Anzahl Anschlüsse: 3, Anzahl der Etagen: 1, grün / gelb"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZPE 16/3AN"",
      ""order_number"": ""1768310000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 409e112f-becc-4362-a605-b9213b69357b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""409e112f-becc-4362-a605-b9213b69357b"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19855300009999.jpg.png"",
      ""part_number"": ""WEI.1985530000"",
      ""eplan_id"": ""636413"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 2, Raster in mm: 3.50, Isoliert: Ja, 17.5 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 1.5N/2 BL"",
      ""order_number"": ""1985530000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d7330b53-eb9e-472e-90cb-078ff427ca61 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d7330b53-eb9e-472e-90cb-078ff427ca61"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19855500009999.jpg.png"",
      ""part_number"": ""WEI.1985550000"",
      ""eplan_id"": ""636415"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 3, Raster in mm: 3.50, Isoliert: Ja, 17.5 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 1.5N/3 BL"",
      ""order_number"": ""1985550000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6f6931ce-ca8e-4651-be73-aa30df7b0af8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6f6931ce-ca8e-4651-be73-aa30df7b0af8"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19855900009999.jpg.png"",
      ""part_number"": ""WEI.1985590000"",
      ""eplan_id"": ""636419"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 5, Raster in mm: 3.50, Isoliert: Ja, 17.5 A, blau"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 1.5N/5 BL"",
      ""order_number"": ""1985590000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a326b1ef-3821-4f74-aced-8a20076e3ec5 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a326b1ef-3821-4f74-aced-8a20076e3ec5"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19856500009999.jpg.png"",
      ""part_number"": ""WEI.1985650000"",
      ""eplan_id"": ""636425"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 2, Raster in mm: 3.50, Isoliert: Ja, 17.5 A, rot"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 1.5N/2 RD"",
      ""order_number"": ""1985650000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 51ff7944-042f-4ef6-bb04-34d77f40d256 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""51ff7944-042f-4ef6-bb04-34d77f40d256"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19857100009999.jpg.png"",
      ""part_number"": ""WEI.1985710000"",
      ""eplan_id"": ""636431"",
      ""designation"": ""Querverbinder/Brücker für Reihenklemme / Querverbinder (Klemmen) gesteckt, Polzahl: 5, Raster in mm: 3.50, Isoliert: Ja, 17.5 A, rot"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZQV 1.5N/5 RD"",
      ""order_number"": ""1985710000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d1b3cb5d-8585-4ea6-be20-e17f60352df4 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d1b3cb5d-8585-4ea6-be20-e17f60352df4"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19881300009999.jpg.png"",
      ""part_number"": ""WEI.1988130000"",
      ""eplan_id"": ""636447"",
      ""designation"": ""Durchgangs-Reihenklemme / Einspeiseklemme, PUSH IN, dunkelbeige, 6 mm², 41 A, 500 V, Anzahl Anschlüsse: 1, Anzahl der Etagen: 1, TS 35, V-0, Wemid"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AAP11 6 LO BL"",
      ""order_number"": ""1988130000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: fc3b62ac-c86c-43e5-9132-05fbb82f647e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""fc3b62ac-c86c-43e5-9132-05fbb82f647e"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19881600009999.jpg.png"",
      ""part_number"": ""WEI.1988160000"",
      ""eplan_id"": ""636449"",
      ""designation"": ""Durchgangs-Reihenklemme / Potentialverteilerklemme, PUSH IN, dunkelbeige, 1.5 mm², 17.5 A, 500 V, Anzahl Anschlüsse: 6, Anzahl der Etagen: 1, TS 35, V-0, Wemid"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AAP11 1.5 LI RD"",
      ""order_number"": ""1988160000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 47bf7c34-3ffe-4d6c-a551-ab7f6c7656eb (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""47bf7c34-3ffe-4d6c-a551-ab7f6c7656eb"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19881700009999.jpg.png"",
      ""part_number"": ""WEI.1988170000"",
      ""eplan_id"": ""636450"",
      ""designation"": ""Durchgangs-Reihenklemme / Potentialverteilerklemme, PUSH IN, dunkelbeige, 1.5 mm², 17.5 A, 500 V, Anzahl Anschlüsse: 6, Anzahl der Etagen: 1, TS 35, V-0, Wemid"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AAP11 1.5 LI BL"",
      ""order_number"": ""1988170000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5dea493f-5ae6-4c77-ad12-20a3d06fa34a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5dea493f-5ae6-4c77-ad12-20a3d06fa34a"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19897800009999.jpg.png"",
      ""part_number"": ""WEI.1989780000"",
      ""eplan_id"": ""636464"",
      ""designation"": ""Durchgangs-Reihenklemme / Einspeiseklemme, PUSH IN, dunkelbeige, 6 mm², 41 A, 500 V, Anzahl Anschlüsse: 1, Anzahl der Etagen: 1, TS 35, V-0, Wemid"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AAP11 6 LO RD"",
      ""order_number"": ""1989780000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2037ddd6-7d05-4c08-b5ce-c76ffa657984 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2037ddd6-7d05-4c08-b5ce-c76ffa657984"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C10223000009999.jpg.png"",
      ""part_number"": ""WEI.1022300000"",
      ""eplan_id"": ""505860"",
      ""designation"": ""Durchgangs-Reihenklemme / Mehrstock-Reihenklemme, Schraubanschluss, 2.5 mm², 400 V, 24 A, Anzahl der Etagen: 2, dunkelbeige"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""WDK 2.5V"",
      ""order_number"": ""1022300000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b902236c-37b8-4ff6-a903-0a4e0235502e (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b902236c-37b8-4ff6-a903-0a4e0235502e"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C19919200009999.jpg.png"",
      ""part_number"": ""WEI.1991920000"",
      ""eplan_id"": ""636496"",
      ""designation"": ""Endklammer/-halter für Klemme / Endwinkel, WEMID GF 30, dunkelbeige, Tragschiene: TS 35, geschraubt"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""AEB 35 SC/1"",
      ""order_number"": ""1991920000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 27e27d31-5d3a-4753-98c4-514354939451 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""27e27d31-5d3a-4753-98c4-514354939451"",
      ""manufacturer_id"": ""842c631b-f669-424b-ab6c-110fbaa3cf3e"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/WEI/512/Weidmueller%255C88179200009999.jpg.png"",
      ""part_number"": ""WEI.8817920000"",
      ""eplan_id"": ""511425"",
      ""designation"": ""Trenn- und Messtrenn-Reihenklemme / Trenn- und Messtrenn-Reihenklemme, Zugfederanschluss, 6 mm², 24 V, 20 A, schwenkbar, Quertrennung: ohne, TS 35, dunkelbeige"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ZTR 6-2 E / 24V UC"",
      ""order_number"": ""8817920000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d750b188-ca8b-443d-adf5-eada04c63c09 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d750b188-ca8b-443d-adf5-eada04c63c09"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_0019700_Product_1.jpg.png"",
      ""part_number"": ""LAPP.0019700"",
      ""eplan_id"": ""181854"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC 110 ORANGE 2X1"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC 110 ORANGE"",
      ""order_number"": ""0019700""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: d89c71f1-30f7-4f35-a807-dc2a10953227 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""d89c71f1-30f7-4f35-a807-dc2a10953227"",
      ""manufacturer_id"": ""c888b246-aef2-4131-860c-8d07186495ed"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/BAL/512/BALLUFF%255CBAL_BUS005H_preview.png.png"",
      ""part_number"": ""BAL.BUS005H"",
      ""eplan_id"": ""1678138"",
      ""designation"": ""Ultraschall Abstandssensor"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BUS M30M1-PWX-07/035-S92K"",
      ""order_number"": ""BUS005H""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 718c35fc-4409-49fb-8568-dc2f8656af12 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""718c35fc-4409-49fb-8568-dc2f8656af12"",
      ""manufacturer_id"": ""7976e3b2-9e4a-4736-bbc3-83b009f88253"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/LAPP/512/LAPP%255COELFLEX_0026100_Product_1.jpg.png"",
      ""part_number"": ""LAPP.0026152"",
      ""eplan_id"": ""182382"",
      ""designation"": ""Anschluss- und Steuerleitungen / ÖLFLEX CLASSIC FD 810 5G1,5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""ÖLFLEX® CLASSIC FD 810"",
      ""order_number"": ""0026152""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2a36fec7-7b9a-497b-9394-04534e521cfe (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2a36fec7-7b9a-497b-9394-04534e521cfe"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CDistribution-System%255CIMPACT67%255C55091.jpg.png"",
      ""part_number"": ""MURR.55091"",
      ""eplan_id"": ""211472"",
      ""designation"": ""IMPACT67 PNIO DI16 / 16 digitale Eingänge / PROFINET IO"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""IMPACT67 PNIO DI16"",
      ""order_number"": ""55091""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 951bfbd4-393a-4d50-aaf6-33bb01a2c11b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""951bfbd4-393a-4d50-aaf6-33bb01a2c11b"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CVerbindungsleitung%255CSignal%255C7000-40041-732.jpg.png"",
      ""part_number"": ""MURR.7000-40041-7320500"",
      ""eplan_id"": ""1748525"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 St. 0° / M12 Bu. 0° A-kod. PUR 5x0.34 sw UL/CSA+schleppk. 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-40041-7320500"",
      ""order_number"": ""7000-40041-7320500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6bb7280a-52f9-45bf-b2ef-9bf56fcdf3a9 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6bb7280a-52f9-45bf-b2ef-9bf56fcdf3a9"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CSV%255Cfri221902695.jpg.png"",
      ""part_number"": ""RIT.9635035"",
      ""eplan_id"": ""1712193"",
      ""designation"": ""Board / SV Board, 160 A, 690 V (AC), 600 V (DC), 3-polig, BHT: 800x160x45,1 mm"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""SV.9635035"",
      ""order_number"": ""9635035""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a386d689-21df-4f03-8a83-c8b385734cff (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a386d689-21df-4f03-8a83-c8b385734cff"",
      ""manufacturer_id"": ""661a295d-65f4-41c9-9626-fa53bf0abb8c"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SEW/512/SEW%255CWiderst%25C3%25A4nde%255CDrahtwiderstand.JPG.png"",
      ""part_number"": ""SEW.BW047-010-T"",
      ""eplan_id"": ""945921"",
      ""designation"": ""Bremswiderstand 47 Ω / 0,8 kW / IP20 / Sachnummer: 17983207"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""BW047-010-T"",
      ""order_number"": ""BW047-010-T""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b63d853a-4fd6-4a52-a289-01af47cab12c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b63d853a-4fd6-4a52-a289-01af47cab12c"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CAnschlusstechnik%255CMit-freiem-Leitungsende%255CSignal%255C7000-12221-614.jpg.png"",
      ""part_number"": ""MURR.7000-12221-6140500"",
      ""eplan_id"": ""1930275"",
      ""designation"": ""Konfektionierte Sensor-Aktor-Leitung / M12 Bu. 0° A-kod. freies Ltg-ende PVC 4x0.34 sw UL/CSA 5m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-12221-6140500"",
      ""order_number"": ""7000-12221-6140500""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 44e675b7-b19d-4ac9-b757-7cc7ab8983f0 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""44e675b7-b19d-4ac9-b757-7cc7ab8983f0"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255C7000-74041-0000000.jpg.png"",
      ""part_number"": ""MURR.7000-74041-0000000"",
      ""eplan_id"": ""2300858"",
      ""designation"": ""Rechtecksteckverbinder (feldkonfektionierbar) / Push Pull RJ45 St. 0° Schneidklemmanschluss 4-pol., 0,14 - 0,34mm², 4,5 - 11mm, geschirmt CAT5"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""7000-74041-0000000"",
      ""order_number"": ""7000-74041-0000000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 18ec71b3-70c5-4507-a8b8-a49a67acdf24 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""18ec71b3-70c5-4507-a8b8-a49a67acdf24"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CHMI%255Cproduct_picture_P_ST80_XX_03232P.png.png"",
      ""part_number"": ""SIE.6AV6646-1BA18-0NA0"",
      ""eplan_id"": ""1083011"",
      ""designation"": ""SIMATIC ITC1900 V3 / SIMATIC, HMI"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV6646-1BA18-0NA0"",
      ""order_number"": ""6AV6646-1BA18-0NA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: a2d3e937-fd70-420a-a23d-12e1a64aac8a (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""a2d3e937-fd70-420a-a23d-12e1a64aac8a"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CHMI%255Cproduct_picture_P_ST80_XX_03469P.png.png"",
      ""part_number"": ""SIE.6AV2128-3XB06-0AX1"",
      ""eplan_id"": ""1483446"",
      ""designation"": ""SIMATIC HMI MTP2200, Unified Comfort Panel, Touchbedienung, 21,5\"" Widescreen-TFT-Display, 16 MIO Farben, PROFINET Schnittstelle, projektierbar ab WinCC Unified Comfort V16, enthält Open Source SW, die unentgeltlich überlassen wird siehe beiliegende DVD"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2128-3XB06-0AX1"",
      ""order_number"": ""6AV2128-3XB06-0AX1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 16f1947f-3dcb-4978-94ca-e91c05b1c50b (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""16f1947f-3dcb-4978-94ca-e91c05b1c50b"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00088P.png.png"",
      ""part_number"": ""SIE.6SL3100-0BE25-5AB0"",
      ""eplan_id"": ""574280"",
      ""designation"": ""AIMO 400V 55KW 6SL3100-0BE25-5AB0 SINAMI / ACTIVE INTERFACE MODULE / 400V 55KW"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3100-0BE25-5AB0"",
      ""order_number"": ""6SL3100-0BE25-5AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 9900dfca-8cf0-4636-9c7f-d15d0f429851 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""9900dfca-8cf0-4636-9c7f-d15d0f429851"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D212_XX_00013P.png.png"",
      ""part_number"": ""SIE.6SL3130-7TE25-5AA3"",
      ""eplan_id"": ""574345"",
      ""designation"": ""SINAMICS S120 ALM 92A 55KW / ACTIVE LINE MODULE / 400V 55KW"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3130-7TE25-5AA3"",
      ""order_number"": ""6SL3130-7TE25-5AA3""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 7dcc4fbd-adf1-40c5-a218-d6f197d8cb2c (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""7dcc4fbd-adf1-40c5-a218-d6f197d8cb2c"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00396P.png.png"",
      ""part_number"": ""SIE.6SL3120-1TE22-4AD0"",
      ""eplan_id"": ""936630"",
      ""designation"": ""SINAMICS S120 SINGLE MOMO 24A D-Type"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-1TE22-4AD0"",
      ""order_number"": ""6SL3120-1TE22-4AD0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f24b885b-3022-4a6c-8fd8-04316a5a17f2 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f24b885b-3022-4a6c-8fd8-04316a5a17f2"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00401P.png.png"",
      ""part_number"": ""SIE.6SL3120-1TE24-5AC0"",
      ""eplan_id"": ""936631"",
      ""designation"": ""SINAMICS S120 SINGLE MOMO 45A C-Type"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-1TE24-5AC0"",
      ""order_number"": ""6SL3120-1TE24-5AC0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c83706c1-2438-429f-82d1-d1fe9743c709 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c83706c1-2438-429f-82d1-d1fe9743c709"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00340P.png.png"",
      ""part_number"": ""SIE.6SL3120-2TE21-0AD0"",
      ""eplan_id"": ""592708"",
      ""designation"": ""SINAMICS S120 DOUBLE MOMO 9A/9A D-Type / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-2TE21-0AD0"",
      ""order_number"": ""6SL3120-2TE21-0AD0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: aedd8199-1db3-457e-a311-d887e90ba644 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""aedd8199-1db3-457e-a311-d887e90ba644"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": """",
      ""part_number"": ""SIE.6ES7615-7DF10-0AB0"",
      ""eplan_id"": ""1083041"",
      ""designation"": ""SIMATIC S7-1500 Drive Controller / CPU 1507D TF / Drive Controller"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7615-7DF10-0AB0"",
      ""order_number"": ""6ES7615-7DF10-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2f66553f-106d-4cdb-99c0-80c2741fbc08 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2f66553f-106d-4cdb-99c0-80c2741fbc08"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CHMI%255Cproduct_picture_P_ST80_XX_02786P.png.png"",
      ""part_number"": ""SIE.6AV2181-5AF15-0AX0"",
      ""eplan_id"": ""1094014"",
      ""designation"": ""Anschlusskabel 15 M KTP Mobile / SIMATIC, HMI / Anschlusskabel"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2181-5AF15-0AX0"",
      ""order_number"": ""6AV2181-5AF15-0AX0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: f15d7012-f77e-4866-8b4f-9cfcab923b5d (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""f15d7012-f77e-4866-8b4f-9cfcab923b5d"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CHMI%255Cproduct_picture_P_ST80_XX_03453P.png.png"",
      ""part_number"": ""SIE.6AV2128-3QB06-0AX1"",
      ""eplan_id"": ""1483442"",
      ""designation"": ""SIMATIC HMI MTP1500, Unified Comfort Panel, Touchbedienung, 15,6\"" Widescreen-TFT-Display, 16 MIO Farben, PROFINET Schnittstelle, projektierbar ab WinCC Unified Comfort V16, enthält Open Source SW, die unentgeltlich überlassen wird siehe beiliegende DVD"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6AV2128-3QB06-0AX1"",
      ""order_number"": ""6AV2128-3QB06-0AX1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 45eb03f5-db07-4140-8d00-5871d49ac475 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""45eb03f5-db07-4140-8d00-5871d49ac475"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CAutomation_Systems%255CET%2520200SP%255C6ES7155-6AA02-0BN0.png.png"",
      ""part_number"": ""SIE.6ES7155-6AA02-0BN0"",
      ""eplan_id"": ""1985699"",
      ""designation"": ""SIMATIC ET 200SP, Bundle PROFINET Interface-Modul IM 155-6 PN ST, max. 32 Peripheriemodule, und 16 ET 200AL Module, Multi Hot SWAP, optionale PN-Zugentlastung, PN Security Class 1, Bundle besteht aus: Interface-Modul (6ES7155-6AU02-0BN0), Server-Modul (6ES7193-6PA00-0AA0), SIMATIC Busadapter BA 2x RJ45 (6ES7193-6AR00-0AA0)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7155-6AA02-0BN0"",
      ""order_number"": ""6ES7155-6AA02-0BN0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 95b78b33-c13b-4c58-bc0d-2ddcc16d6c43 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""95b78b33-c13b-4c58-bc0d-2ddcc16d6c43"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://shop.murrelektronik.at/out/pictures/master/product/1/IMG850116_zoom.png"",
      ""part_number"": ""MURR.9000-41000-0000006"",
      ""eplan_id"": """",
      ""designation"": ""Mico Pro Abdeckplatten Set, Abdeckplatte rechts und links in grün"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41000-0000006"",
      ""order_number"": ""9000-41000-0000006""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: ce67e4ee-7de0-4150-9e88-51cdc61e6966 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""ce67e4ee-7de0-4150-9e88-51cdc61e6966"",
      ""manufacturer_id"": ""50ee9a8a-2f60-4ac0-9e81-68007981bccd"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/MURR/512/MURR%255CElectronics-in-the-Control-Cabinet%255CIntelligent-Power-Distribution%255CModules%255C9000_41190_0000000.png.png"",
      ""part_number"": ""MURR.9000-41190-0000001"",
      ""eplan_id"": """",
      ""designation"": ""Stromüberwachungsgerät / Mico Pro Einspeisemodul (IN: 24 V DC / 40A, 16mm²)"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""9000-41190-0000001"",
      ""order_number"": ""9000-41190-0000001""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: dc771e51-c37b-4657-9d36-b8b811c3d934 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""dc771e51-c37b-4657-9d36-b8b811c3d934"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": """",
      ""part_number"": ""SIE.6ES7954-8LP80-0AA0"",
      ""eplan_id"": """",
      ""designation"": ""SIMATIC S7, Memory Card für S7-1500T Motion Control KinPlus 3,3V Flash, 2 GByte"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7954-8LP80-0AA0"",
      ""order_number"": ""6ES7954-8LP80-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1852aa10-ae75-42e8-b104-6c481f1cc635 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1852aa10-ae75-42e8-b104-6c481f1cc635"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINUMERIK%255Cproduct_picture_P_NC01_XX_01667P.png.png"",
      ""part_number"": ""SIE.6FC5317-5AA00-0AA0"",
      ""eplan_id"": ""1094069"",
      ""designation"": ""NCU 1750 MIT PLC 1500F / SINUMERIK CNC-Steuerung"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6FC5317-5AA00-0AA0"",
      ""order_number"": ""6FC5317-5AA00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: dcd0ef62-6524-4759-8a6e-09b4cab56c85 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""dcd0ef62-6524-4759-8a6e-09b4cab56c85"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINUMERIK%255Cproduct_picture_P_NC01_XX_01667P.png.png"",
      ""part_number"": ""SIE.6FC5317-5AA00-0AA1"",
      ""eplan_id"": """",
      ""designation"": ""SINUMERIK ONE NCU 1750 mit PLC-1500F"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6FC5317-5AA00-0AA1"",
      ""order_number"": ""6FC5317-5AA00-0AA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 6bc919d3-b7a8-4090-9bfe-97fb3caf9541 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""6bc919d3-b7a8-4090-9bfe-97fb3caf9541"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINUMERIK%255Cproduct_picture_P_NC01_XX_00675P.png.png"",
      ""part_number"": ""SIE.6SL3040-1NB00-0AA0"",
      ""eplan_id"": ""574256"",
      ""designation"": ""SINAMICS NUMERIC CONTR.EXTENSION NX15.3 / SINAMICS Numeric Control Extension"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3040-1NB00-0AA0"",
      ""order_number"": ""6SL3040-1NB00-0AA0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 1883cb12-2727-4c94-8662-c8527d28b792 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""1883cb12-2727-4c94-8662-c8527d28b792"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00338P.png.png"",
      ""part_number"": ""SIE.6SL3120-1TE15-0AD0"",
      ""eplan_id"": ""592700"",
      ""designation"": ""SINAMICS S120 SINGLE MOMO 5A D-Type / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-1TE15-0AD0"",
      ""order_number"": ""6SL3120-1TE15-0AD0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 2950b8c9-0f9b-49a7-aebf-072ce1b818ba (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""2950b8c9-0f9b-49a7-aebf-072ce1b818ba"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00338P.png.png"",
      ""part_number"": ""SIE.6SL3120-1TE21-8AD0"",
      ""eplan_id"": ""592703"",
      ""designation"": ""SINAMICS S120 SINGLE MOMO 18A D-Type / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-1TE21-8AD0"",
      ""order_number"": ""6SL3120-1TE21-8AD0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8fafe200-9188-46f1-885a-f732361403ed (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8fafe200-9188-46f1-885a-f732361403ed"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00341P.png.png"",
      ""part_number"": ""SIE.6SL3120-2TE21-8AD0"",
      ""eplan_id"": ""592710"",
      ""designation"": ""SINAMICS S120 DOUBLE MOMO 18A/18A D-Type / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-2TE21-8AD0"",
      ""order_number"": ""6SL3120-2TE21-8AD0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 8d682b2d-0d03-4e69-b778-0108d848aa25 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""8d682b2d-0d03-4e69-b778-0108d848aa25"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/SIE/512/Siemens%255CDrive_Technology%255CSINAMICS%255Cproduct_picture_P_D211_XX_00340P.png.png"",
      ""part_number"": ""SIE.6SL3120-2TE13-0AD0"",
      ""eplan_id"": ""592706"",
      ""designation"": ""SINAMICS S120 DOUBLE MOMO 3A/3A D-Type / SINAMICS S120"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6SL3120-2TE13-0AD0"",
      ""order_number"": ""6SL3120-2TE13-0AD0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 5a5a00a1-7ce5-46df-9630-bee8a87bfbf8 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""5a5a00a1-7ce5-46df-9630-bee8a87bfbf8"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://support.industry.siemens.com/cs/images/109792546/HT10_klein.png"",
      ""part_number"": ""SIE.6FC5403-0AA21-0AA1"",
      ""eplan_id"": """",
      ""designation"": ""SINUMERIK Handheld terminal HT 10 Handbediengerät mit 10\"" Multitouch Display für SINUMERIK CNC"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6FC5403-0AA21-0AA1"",
      ""order_number"": ""6FC5403-0AA21-0AA1""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: b7c7950a-6edf-48f0-b018-ca4b6499d1f3 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""b7c7950a-6edf-48f0-b018-ca4b6499d1f3"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://shop.efi-automation.com/thumbnail/ff/c3/b0/1693310939/6AV2181-5AF08-0AX0_01_800x800.jpg?1728407297"",
      ""part_number"": ""SIE.6XV1440-4BN15"",
      ""eplan_id"": """",
      ""designation"": ""Anschlusskabel PN für Mobile Panels (PROFINET), Länge 15m"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6XV1440-4BN15"",
      ""order_number"": ""6XV1440-4BN15""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: 626e2088-c611-4af3-a2a9-52b711c49f88 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""626e2088-c611-4af3-a2a9-52b711c49f88"",
      ""manufacturer_id"": ""542e64c3-8fe0-47ec-adf7-a72163587c4a"",
      ""preview"": ""https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRo92asw5vsGBvXiQ5awBcca4A1KrYH9nwU3b4X5WIDzzLrL9WXBuZ2MM3xEHY_IhQmDtUTk6RA19MaE8y-dM7GhQTfE1enRv2TFEi50yzy03-r6SVXB4IztOfTt9zospj_51mgVewu4g&usqp=CAc"",
      ""part_number"": ""SIE.6ES7518-3UT10-0AB0"",
      ""eplan_id"": """",
      ""designation"": ""SIMATIC S7-1500TF, CPU 1518TF-3 PN, Zentralbaugruppe mit Arbeitsspeicher 18 MB für Programm und 150 MB für Daten, 1. Schnittstelle: PROFINET IRT SIMATIC Memory Card notwendig"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""6ES7518-3UT10-0AB0"",
      ""order_number"": ""6ES7518-3UT10-0AB0""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion

    #region << ***Create record*** Id: c3577347-c9ca-4111-978b-d8887b6c6f49 (article) >>
    {
        var json = @"{
      ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
      ""id"": ""c3577347-c9ca-4111-978b-d8887b6c6f49"",
      ""manufacturer_id"": ""aed8d379-e2b5-4ff4-8817-b03535f9c2b2"",
      ""preview"": ""https://cs8dpprodwesa.blob.core.windows.net/prodi1-picturefile/RIT/512/Rittal%255CVX%255Cfri181615495.jpg.png"",
      ""part_number"": ""RIT.8486000"",
      ""eplan_id"": ""933763"",
      ""designation"": ""Anreih-Schranksystem VX25 / VX Anreih-Schranksystem, BHT: 400x1800x600 mm, Stahlblech, mit Montageplatte, eintürig an Frontseite. Das Produkt ist erhältlich in diesen Regionen/Ländern: EMEA, AMERICAS. Das Produkt ist nicht erhältlich in diesen Regionen/Ländern: NORTH AMERICA,APAC,OCEANIA,BR, MX"",
      ""is_blocked"": false,
      ""article_type"": ""14a2d274-c18e-46f8-a920-2814ea5faa2d"",
      ""type_number"": ""VX.8486000"",
      ""order_number"": ""8486000""
    }";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("article", rec);
    
    }
    #endregion


    #endregion

    #region projects
    #region << ***Create record*** Id: f83fe235-2676-4342-b434-933952b228c0 (project) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""f83fe235-2676-4342-b434-933952b228c0"",
  ""name"": ""FRAI Caterpillar"",
  ""number"": ""24013"",
  ""inventory_project"": false,
  ""requires_part_list"": true
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("project", rec);
        
    }
    #endregion
    #endregion

    #region part lists
    #region << ***Create record*** Id: a0a6c30d-7f4a-4798-a220-74a34eae00d5 (part_list) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""project_id"": ""f83fe235-2676-4342-b434-933952b228c0"",
  ""name"": ""Siemens Antriebstechnik"",
  ""is_active"": true
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: d29b58c6-1ed8-43c0-9d2e-19a9d8d12692 (part_list) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""project_id"": ""f83fe235-2676-4342-b434-933952b228c0"",
  ""name"": ""Siemens Steuerungskomponenten, HMI"",
  ""is_active"": true
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list", rec);
        
    }
    #endregion
    #endregion

    #region part list entries
    #region << ***Create record*** Id: 23f8c705-e580-46ad-9316-ad3a7b7f8ac0 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""23f8c705-e580-46ad-9316-ad3a7b7f8ac0"",
  ""part_list_id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""article_id"": ""16f1947f-3dcb-4978-94ca-e91c05b1c50b"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 08bc3255-10fd-488c-a4e3-53e9f0c40173 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""08bc3255-10fd-488c-a4e3-53e9f0c40173"",
  ""part_list_id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""article_id"": ""9900dfca-8cf0-4636-9c7f-d15d0f429851"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 79f5a617-3d90-40bd-bd08-108026915b0a (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""79f5a617-3d90-40bd-bd08-108026915b0a"",
  ""part_list_id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""article_id"": ""7dcc4fbd-adf1-40c5-a218-d6f197d8cb2c"",
  ""amount"": 6.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 74c7bc20-1512-4e14-bb51-7300c7cd7d14 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""74c7bc20-1512-4e14-bb51-7300c7cd7d14"",
  ""part_list_id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""article_id"": ""f24b885b-3022-4a6c-8fd8-04316a5a17f2"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 5ad3d16d-9212-4822-ad7c-04977d5e3ef2 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""5ad3d16d-9212-4822-ad7c-04977d5e3ef2"",
  ""part_list_id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""article_id"": ""c83706c1-2438-429f-82d1-d1fe9743c709"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 7ff65726-e75e-4d51-a9c7-a4889cd1a545 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""7ff65726-e75e-4d51-a9c7-a4889cd1a545"",
  ""part_list_id"": ""a0a6c30d-7f4a-4798-a220-74a34eae00d5"",
  ""article_id"": ""ebeb338e-83f9-4110-b9a8-389b01792e0d"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 95c72c48-9512-4b0e-8c63-ae86bd072894 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""95c72c48-9512-4b0e-8c63-ae86bd072894"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""78536c71-d174-4131-a98d-f10fc101fe3f"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 3efe0542-4eb0-473e-8c87-f86ce7ff27ce (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""3efe0542-4eb0-473e-8c87-f86ce7ff27ce"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""2f66553f-106d-4cdb-99c0-80c2741fbc08"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 924be736-895c-4fe9-97ec-b037733f0be0 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""924be736-895c-4fe9-97ec-b037733f0be0"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""f15d7012-f77e-4866-8b4f-9cfcab923b5d"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 6bb2183f-5e6e-417d-b967-c95e40977546 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""6bb2183f-5e6e-417d-b967-c95e40977546"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""00f421b2-010c-4abe-9251-fe0462238754"",
  ""amount"": 8.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 75ce13d2-ebba-4f55-8451-80823377b350 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""75ce13d2-ebba-4f55-8451-80823377b350"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""d943f09c-876b-4daa-a074-eda95a28ebc3"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 1a54f5dc-38b8-4fbb-9911-d2d303d47177 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""1a54f5dc-38b8-4fbb-9911-d2d303d47177"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""45eb03f5-db07-4140-8d00-5871d49ac475"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 9c5017f8-ef1c-40ac-a796-31f73d4af76c (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""9c5017f8-ef1c-40ac-a796-31f73d4af76c"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""d70c2110-6cd5-4049-a57e-45788a3370db"",
  ""amount"": 8.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 11723e7f-5f46-4ddf-af1d-b0eb795a7c95 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""11723e7f-5f46-4ddf-af1d-b0eb795a7c95"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""77fe9174-873c-426a-a50e-004989782fca"",
  ""amount"": 8.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 9b5cbfdf-ab52-4c48-89c6-cbfb6057c95c (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""9b5cbfdf-ab52-4c48-89c6-cbfb6057c95c"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""8f2fe0fd-abd7-42c7-92b3-ef3d6986193d"",
  ""amount"": 8.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 537e3374-94d4-4fd0-b01f-7aafeac467d4 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""537e3374-94d4-4fd0-b01f-7aafeac467d4"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""1516b06b-8bd7-4950-80b4-ebc0d2f35670"",
  ""amount"": 8.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 1ced2f5e-e599-4a62-90f2-cc6e30ded6f6 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""1ced2f5e-e599-4a62-90f2-cc6e30ded6f6"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""626e2088-c611-4af3-a2a9-52b711c49f88"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: 800d29f5-4c69-4395-bc8b-5512332e909f (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""800d29f5-4c69-4395-bc8b-5512332e909f"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""dc771e51-c37b-4657-9d36-b8b811c3d934"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion

    #region << ***Create record*** Id: f328317e-881d-44f7-8e1f-bbe9f70f9ed5 (part_list_entry) >>
    {
        var json = @"{
  ""$type"": ""WebVella.Erp.Api.Models.EntityRecord, WebVella.Erp"",
  ""id"": ""f328317e-881d-44f7-8e1f-bbe9f70f9ed5"",
  ""part_list_id"": ""d29b58c6-1ed8-43c0-9d2e-19a9d8d12692"",
  ""article_id"": ""8f5953ff-1131-453a-b79e-973aa1a2ccdd"",
  ""amount"": 2.0,
  ""device_tag"": """"
}";
        EntityRecord rec = JsonConvert.DeserializeObject<EntityRecord>(json);
        recMan.CreateRecord("part_list_entry", rec);
        
    }
    #endregion


    #endregion
}