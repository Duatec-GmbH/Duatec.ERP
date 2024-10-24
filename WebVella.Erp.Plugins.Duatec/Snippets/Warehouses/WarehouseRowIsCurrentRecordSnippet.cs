namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses
{
    [Snippet]
    public class WarehouseRowIsCurrentRecordSnippet : RowRecordIsCurrentRecordSnippet
    {
        protected override string IdParameter => "wId";
    }
}
