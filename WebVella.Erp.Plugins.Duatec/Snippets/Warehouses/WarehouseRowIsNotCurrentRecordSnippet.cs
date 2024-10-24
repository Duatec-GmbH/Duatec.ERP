namespace WebVella.Erp.Plugins.Duatec.Snippets.Warehouses
{
    [Snippet]
    public class WarehouseRowIsNotCurrentRecordSnippet : RowRecordIsNotCurrentRecordSnippet
    {
        protected override string IdParameter => "wId";
    }
}
