namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses.Locations
{
    [Snippet]
    public class WarehouseLocationRowIsNotCurrentRecordSnippet : RowRecordIsNotCurrentRecordSnippet
    {
        protected override string IdParameter => "wId";
    }
}
