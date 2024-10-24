namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.Locations
{
    [Snippet]
    public class WarehouseLocationRowIsCurrentRecordSnippet : RowRecordIsCurrentRecordSnippet
    {
        protected override string IdParameter => "wlId";
    }
}
