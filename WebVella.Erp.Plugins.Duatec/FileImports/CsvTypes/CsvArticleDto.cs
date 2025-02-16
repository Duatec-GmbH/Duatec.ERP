namespace WebVella.Erp.Plugins.Duatec.FileImports.CsvTypes
{
    internal class CsvArticleDto
    {
        public CsvArticleDto(string partNumber, string orderNumber, int amount)
        {
            PartNumber = partNumber;
            OrderNumber = orderNumber;
            Amount = amount;
        }

        public string PartNumber { get; }

        public string OrderNumber { get; }

        public int Amount { get; }
    }
}
